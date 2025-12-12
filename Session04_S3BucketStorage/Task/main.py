import uuid
from fastapi import FastAPI, UploadFile, File, HTTPException
from fastapi.responses import StreamingResponse
import boto3
from botocore.exceptions import ClientError
from io import BytesIO

app = FastAPI()

BUCKET = "testbucket"

s3 = boto3.client(
    "s3",
    endpoint_url="http://localhost:9000",
    aws_access_key_id="root",
    aws_secret_access_key="password",
)

@app.post("/api/files")
async def upload_file(file: UploadFile = File(...)):
    try:
        object_name = str(uuid.uuid4())
        s3.upload_fileobj(file.file, BUCKET, object_name)
        # If you want to preserve original file metadata
        # s3.upload_fileobj(
        #     file.file,
        #     BUCKET,
        #     object_name,
        #     ExtraArgs={
        #         "Metadata": {
        #             "original_filename": file.filename,
        #             "content_type": file.content_type
        #         }
        #     }
        # )
        return {"status": "ok", "id": object_name}
    except ClientError as e:
        raise HTTPException(status_code=500, detail=str(e))


@app.get("/api/files/{file_id}")
async def get_file(file_id: str):
    file_stream = BytesIO()
    
    try:
        s3.download_fileobj(BUCKET, file_id, file_stream)
    except ClientError as e:
        raise HTTPException(status_code=404, detail="File not found")

    file_stream.seek(0)
    
    # To retrieve metadata (stored previously)
    # try:
    #     head = s3.head_object(Bucket=BUCKET, Key=file_id)
    #     original_filename = head["Metadata"].get("original_filename", file_id)
    # except ClientError:
    #     original_filename = file_id

    return StreamingResponse(
        file_stream,
        media_type="application/octet-stream",
        headers={"Content-Disposition": f"attachment; filename={file_id}"}
        # headers={"Content-Disposition": f'attachment; filename="{original_filename}"'}
    )
