terraform {
  backend "s3" {
    bucket         = "shinaz-fsh-backend-1"
    key            = "api/staging/terraform.tfstate"
    region         = "ap-south-1"
    dynamodb_table = "fsh-state-locks"
  }
}
