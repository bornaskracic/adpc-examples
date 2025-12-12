Before running the examples, first create the virtual environment:

```bash
cd Session04_S3BucketStorage
python -m venv ./venv
./venv/scripts/Activate
```

Then install the required packages:
```bash
pip install -r requirements.txt
```

Then create the appopriate Docker container running MiniO bucket storage:
```bash
docker run -d -p "9000:9000" -p "9001:9001" --name minio  -e "MINIO_ROOT_USER=root" -e "MINIO_ROOT_PASSWORD=password" quay.io/minio/minio server /home/shared --address :9000 --console-address :9001
```

Then you can run examples as:
```bash
python ./[Example]/main.py
```

Of course, make sure that environment is activated; the name of the environment should be displayed before the command prompt, for example in `Powershell`:
```bash
(venv) PS C:\repos\examples>
```

#### Example01
First example demonstrates how to upload file in the MiniO bucket. (Provoding `filepath` argument using `argparse` to read command line arguments). To run:
```bash
python Example01/main.py [filepath]
```

#### Example02
Second example demonstrates how to retrieve file from Minio bucket. To run:
```bash
python Example02/main.py [file_id] [destination_filepath]
```

#### Example03
Third examples shows a simple REST API application (written in FastAPI) that enables uploading and retrieving the file from MiniO storage.
To start the application (make sure that all requirements are installed - `fastapi`, `python-multipart`, `uvicorn`):
```bash
cd Task/
uvicorn main:app --reload
```