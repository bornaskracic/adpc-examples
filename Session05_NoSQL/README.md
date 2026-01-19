Before running the examples, first create the virtual environment:

```bash
cd Session05_NoSQL
python -m venv ./venv
./venv/scripts/Activate
```

Then install the required packages:
```bash
pip install -r requirements.txt
```

Then create the appopriate Docker container running MongoDb bucket storage:
```bash
docker run -d \
  --name my-mongo \
  -p 27017:27017 \
  -e MONGO_INITDB_ROOT_USERNAME=root \
  -e MONGO_INITDB_ROOT_PASSWORD=example \
  mongo:8.2
```

#### Example 01
Find a way to enter and retrieve survey data in a non-relational database collection (the survey is defined by the name, question, date until which it is active and 2 to 4 offered answers). Select the language/environment you want to work in.

(1) Check if the database exists.
(2) Create an instance of the BsonDocument class.
(3) Using the insertOne and insertMany methods, insert data into the database.
(4) The poll contains the name, question, date until which it is active and 2 to 4 offered answers.
(5) Explore how the find method works to filter data.
(6) Get all surveys that are active.
(7) Retrieve all polls containing the word "elections".

Example of the BSON document (poll):
```json
{
  "_id": ObjectId,
  "title": "Favorite programming language?",
  "date_created": ISODate("2025-12-12T00:00:00Z"),
  "options": [
    {"option": "Python", "votes": 10},
    {"option": "JavaScript", "votes": 5}
  ]
}
```
