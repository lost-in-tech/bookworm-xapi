resource "aws_cognito_user_pool" "main" {
  name = "${var.group}-${var.app_name}-${var.env}-userpool"


  username_attributes = ["email"]
  auto_verified_attributes = [ "email" ]

  account_recovery_setting {
    recovery_mechanism {
      name = "verified_email"
      priority = 1
    }
  }

  username_configuration {
    case_sensitive = false
  }

  
  password_policy {
    minimum_length = 8
    require_numbers = true
    require_lowercase = false
    require_uppercase = false
    require_symbols = false
  }

  admin_create_user_config {
    allow_admin_create_user_only = false
  }

  schema {
    attribute_data_type = "String"
    name = "name"
    required = true
    mutable = true
    string_attribute_constraints {
      min_length = 3
      max_length = 1028
    }    
  }

  tags = {
    Name = "${var.group}-${var.app_name}-${var.env}-userpool"
    Group = var.group
    Env = var.env
  }
}

resource "aws_cognito_user_pool_client" "main" {
  name = "${var.group}-${var.app_name}-${var.env}-xapiclient"
  user_pool_id = aws_cognito_user_pool.main.id
  generate_secret = false
  read_attributes = [ "email", "name" ]
  write_attributes = [ "name" ]
  explicit_auth_flows = ["ALLOW_REFRESH_TOKEN_AUTH","ALLOW_USER_PASSWORD_AUTH","ALLOW_ADMIN_USER_PASSWORD_AUTH"]

  refresh_token_validity = 90
  prevent_user_existence_errors = "ENABLED"
}

resource "aws_cognito_user_pool_domain" "main" {
  domain       =  "${var.group}-${var.app_name}-${var.env}"
  user_pool_id = aws_cognito_user_pool.main.id
}