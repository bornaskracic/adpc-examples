import argparse

import boto3

s3 = boto3.client(
    's3',
    endpoint_url="http://localhost:9000",
    aws_access_key_id="root",
    aws_secret_access_key="password",
)

bucket = "testbucket"

parser = argparse.ArgumentParser()
parser.add_argument("id", help="Unique identifier of the file")
parser.add_argument("destination", help="Destination filepath")
args = parser.parse_args()

s3.download_file(bucket, args.id, args.destination)

print(f"Downloaded - {args.destination}")