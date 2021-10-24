resource "aws_apigatewayv2_api" "api" {
  name          = "api-${var.group}-${var.env}-${var.app_name}"
  protocol_type = "HTTP"
}
resource "aws_apigatewayv2_stage" "api" {
  api_id = aws_apigatewayv2_api.api.id
  name   = var.env
}

resource "aws_apigatewayv2_integration" "api" {
  api_id           = aws_apigatewayv2_api.api.id
  integration_type = "AWS_PROXY"

  connection_type      = "INTERNET"
  integration_method   = "ANY"
  integration_uri      = aws_lambda_function.app.invoke_arn
  passthrough_behavior = "WHEN_NO_MATCH"
}

resource "aws_apigatewayv2_route" "api" {
  api_id    = aws_apigatewayv2_api.api.id
  route_key = "ANY /${var.app_name}/{proxy+}"

  target = "integrations/${aws_apigatewayv2_integration.api.id}"
}
