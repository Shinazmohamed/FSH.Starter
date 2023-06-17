resource "aws_s3_bucket" "s3_bucket" {
  bucket = "shinaz-fsh-backend-1"
  tags = {
    Name = "shinaz-fsh-backend-1"
  }
  lifecycle {
    prevent_destroy = false
  }
}
