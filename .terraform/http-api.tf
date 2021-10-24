resource "aws_apigatewayv2_api" "api" {
  name = "api-${var.group}-${var.env}-${var.app_name}"
  protocol_type = "HTTP"
}
