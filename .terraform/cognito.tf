resource "aws_cognito_user_pool" "main" {
  name = "${var.group}-${var.app_name}-${var.env}-userpool"
  tags = {
    Name = "${var.group}-${var.app_name}-${var.env}-userpool"
    Group = var.group
    Env = var.env
  }
}