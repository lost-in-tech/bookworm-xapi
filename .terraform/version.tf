terraform {
  required_providers {
    aws = {
      source  = "hashicorp/aws"
      version = "~> 3.0"
    }
  }
  backend "s3" {
    bucket = "bookworm-tf-state"
    key    = "retail-xapi-bookworm-stack"
    region = "ap-southeast-2"
  }
}

provider "aws" {
  region = var.aws_region
}
