variable "app_name" {
  type    = string
  default = "xapi-bookworm"
}

variable "app_port" {
  default = 80
}

variable "app_health_check_path" {
  default = "/ping"
}

variable "app_count" {
  description = "Number of docker containers to run"
  default     = 2
}

variable "app_image" {
  default = "nginx"
}

variable "fargate_cpu" {
  description = "Fargate instance CPU units to provision (1 vCPU = 1024 CPU units)"
  default     = "256"
}

variable "fargate_memory" {
  description = "Fargate instance memory to provision (in MiB)"
  default     = "512"
}


variable "group" {
  type    = string
  default = "retail"
}

variable "env" {
  type    = string
  default = "dev"
}

variable "aws_region" {
  description = "The AWS region to create things in."
  default     = "ap-southeast-2"
}

variable "ecs_task_execution_role_name" {
  description = "ECS task execution role name"
  default     = "role-ecs-task-execution"
}
