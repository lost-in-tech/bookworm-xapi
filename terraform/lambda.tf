locals {
  app_name = "${var.group}-${var.env}-${var.app_name}"
}

resource "aws_lambda_function" "app" {
  filename         = data.archive_file.src.output_path
  function_name    = local.app_name
  role             = aws_iam_role.lambda.arn
  handler          = "Bookworm.Xapi::Bookworm.Xapi.LambdaEntryPoint::FunctionHandlerAsync"
  source_code_hash = data.archive_file.src.output_base64sha256
  runtime          = "dotnetcore3.1"
  memory_size      = 128
  architectures    = ["arm64"]

  environment {
    variables = {
      Auth__ClientId = aws_cognito_user_pool_client.main.id
      Auth__ClientSecret = aws_cognito_user_pool_client.main.client_secret
      Auth__UserPoolId = aws_cognito_user_pool.main.id
      Auth__Domain = aws_cognito_user_pool_domain.main.domain
    }
  }

  tags = {
    Group = var.group
    Env   = var.env
    Name  = local.app_name
  }
}

data "archive_file" "src" {
  output_path = "${path.module}/publish/lambda.zip"
  source_dir  = "${path.module}/../publish"
  excludes    = ["__init__.py", "*.pyc"]
  type        = "zip"
}
