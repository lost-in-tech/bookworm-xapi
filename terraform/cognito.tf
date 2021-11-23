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

  verification_message_template {
    default_email_option = "CONFIRM_WITH_LINK"
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
  explicit_auth_flows = ["ADMIN_NO_SRP_AUTH"]

  refresh_token_validity = 90
  prevent_user_existence_errors = "ENABLED"
}

resource "aws_cognito_user_pool_domain" "main" {
  domain       =  "${var.group}-${var.app_name}-${var.env}"
  user_pool_id = aws_cognito_user_pool.main.id
}

resource "aws_cognito_resource_server" "main" {
  name =  "resource-server-${var.group}-${var.app_name}-${var.env}"
  identifier = "https://${var.group}-${var.app_name}-${var.env}.com.au"
  user_pool_id = aws_cognito_user_pool.main.id

  scope {
    scope_name = "customer"
    scope_description = "customer of the application"
  }
}