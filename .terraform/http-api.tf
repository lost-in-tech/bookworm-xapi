resource "aws_apigatewayv2_api" "api" {
  name          = "api-${var.group}-${var.env}-${var.app_name}"
  protocol_type = "HTTP"
  cors_configuration {
    allow_origins = ["https://www.ruhul-amin.net"]
    allow_methods = ["POST", "GET", "PUT", "OPTIONS"]
    allow_headers = ["content-type"]
    max_age       = 300
  }
}

# resource "aws_apigatewayv2_stage" "api" {
#   api_id      = aws_apigatewayv2_api.api.id
#   name        = var.env
#   auto_deploy = true
# }

resource "aws_apigatewayv2_integration" "api" {
  api_id             = aws_apigatewayv2_api.api.id
  integration_type   = "AWS_PROXY"
  integration_method = "POST"
  integration_uri    = aws_lambda_function.app.invoke_arn
}

resource "aws_apigatewayv2_route" "api" {
  api_id    = aws_apigatewayv2_api.api.id
  route_key = "ANY /{proxy+}"

  target = "integrations/${aws_apigatewayv2_integration.api.id}"
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

  value = aws_apigatewayv2_api.api.api_endpoint
}
