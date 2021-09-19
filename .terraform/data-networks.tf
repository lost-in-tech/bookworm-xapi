data "aws_vpc" "main" {
  tags = {
    Name = "vpc-${var.group}-${var.env}"
  }
}

data "aws_subnet_ids" "main" {
  vpc_id = data.aws_vpc.main.id

  tags = {
    Scope = "public"
  }
}

data "aws_subnet_ids" "private" {
  vpc_id = data.aws_vpc.main.id

  tags = {
    Scope = "private"
  }
}

data "aws_security_group" "ecs_tasks" {
  tags = {
    Name = "sg-ecs-tasks-${var.group}-${var.env}"
  }
}

data "aws_alb" "main" {
  tags = {
    Name  = "alb-${var.group}-${var.env}-${"public" == "public" ? "pub" : "prv"}",
    Scope = "public"
  }
}

data "aws_alb_listener" "main" {
  load_balancer_arn = data.aws_alb.main.arn
  port              = 80

  tags = {
    Name = "listener-${var.group}-${"public" == "public" ? "pub" : "prv"}"
  }
}

data "aws_iam_role" "ecs_service_role" {
  name = "role-ecs-service-${var.group}-${var.env}"
}

data "aws_ecs_cluster" "main" {
  cluster_name = "${var.group}-${var.env}-cluster"
}
