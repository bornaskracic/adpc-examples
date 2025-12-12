import argparse
import uuid

import boto3

s3 = boto3.client(
    's3',
    endpoint_url="http://localhost:9000",
    aws_access_key_id="root",
    aws_secret_access_key="password",
)

bucket = "testbucket"

parser = argparse.ArgumentParser()
parser.add_argument("filepath", help="File to process")
args = parser.parse_args()

object_name = str(uuid.uuid4())
s3.upload_file(args.filepath, bucket, object_name)

print("Uploaded!")
