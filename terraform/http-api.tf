resource "aws_apigatewayv2_api" "api" {
  name          = "api-${var.group}-${var.env}-${var.app_name}"
  protocol_type = "HTTP"
  cors_configuration {
    allow_origins = ["https://www.ruhul-amin.net", "http://localhost:8080", "http://retail-mobi-bookworm20211016101127523000000001.s3-website-ap-southeast-2.amazonaws.com"]
    allow_methods = ["POST", "GET", "PUT", "OPTIONS"]
    allow_headers = ["content-type"]
    max_age       = 300
  }
}

resource "aws_apigatewayv2_stage" "api" {
  api_id      = aws_apigatewayv2_api.api.id
  name        = var.env
  auto_deploy = true

  access_log_settings {
    destination_arn = aws_cloudwatch_log_group.api_gw.arn

    format = jsonencode({
      requestId               = "$context.requestId"
      sourceIp                = "$context.identity.sourceIp"
      requestTime             = "$context.requestTime"
      protocol                = "$context.protocol"
      httpMethod              = "$context.httpMethod"
      resourcePath            = "$context.resourcePath"
      routeKey                = "$context.routeKey"
      status                  = "$context.status"
      responseLength          = "$context.responseLength"
      integrationErrorMessage = "$context.integrationErrorMessage"
      }
    )
  }
}

resource "aws_apigatewayv2_integration" "api" {
  api_id             = aws_apigatewayv2_api.api.id
  integration_type   = "AWS_PROXY"
  integration_method = "POST"
  integration_uri    = aws_lambda_function.app.invoke_arn
  payload_format_version = "2.0"
}

resource "aws_apigatewayv2_route" "public" {
  api_id    = aws_apigatewayv2_api.api.id
  route_key = "ANY /public/{proxy+}"

  target = "integrations/${aws_apigatewayv2_integration.api.id}"
}

resource "aws_apigatewayv2_route" "private" {
  api_id    = aws_apigatewayv2_api.api.id
  route_key = "ANY /private/{proxy+}"

  target = "integrations/${aws_apigatewayv2_integration.api.id}"

  authorization_type = "JWT"
  authorizer_id = aws_apigatewayv2_authorizer.private.id  
}

resource "aws_apigatewayv2_authorizer" "private" {
  api_id = aws_apigatewayv2_api.api.id
  authorizer_type = "JWT"
  identity_sources = [ "$request.header.Authorization" ]
  name = "private-endpoint-auth"
  authorizer_result_ttl_in_seconds = 300

  jwt_configuration {
    audience = [ aws_cognito_user_pool_client.main.id ]
    issuer = "https://${aws_cognito_user_pool.main.endpoint}"
  }
}

resource "aws_cloudwatch_log_group" "api_gw" {
  name = "/aws/api_gw/${aws_apigatewayv2_api.api.name}"

  retention_in_days = 30
}

resource "aws_lambda_permission" "api_gw" {
  statement_id  = "AllowExecutionFromAPIGateway"
  action        = "lambda:InvokeFunction"
  function_name = aws_lambda_function.app.function_name
  principal     = "apigateway.amazonaws.com"
  source_arn    = "${aws_apigatewayv2_api.api.execution_arn}/*/*"
}


output "base_url" {
  description = "Base URL for API Gateway stage."

  value = aws_apigatewayv2_stage.api.invoke_url
}
