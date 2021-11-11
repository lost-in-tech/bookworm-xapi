output "cognito-client-secret" {
  value = aws_cognito_user_pool_client.main.client_secret
  sensitive = true
}

output "cognito-client-id" {
  value = aws_cognito_user_pool_client.main.id
}