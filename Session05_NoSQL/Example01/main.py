from datetime import datetime

from pymongo import MongoClient

CONNECTION_STRING = "mongodb://root:example@localhost:27017"

client = MongoClient(CONNECTION_STRING)

dbs = client.list_database_names()

survey = {
    "title": "Favorite programming language?",
    "date_created": datetime(2025, 12, 12),
    "options": [
        {"option": "Python", "votes": 10},
        {"option": "JavaScript", "votes": 5}
  ]
}

db_name = "surveydb"
survey_db = client[db_name]
survey_collection = survey_db["surveys"]

# inactive_surveys = survey_collection.find({ "activeFrom": { "$gt" : datetime.now() }})

filtered_surveys = survey_collection.find({
    "and" : [
        { "question": {"$regex": "prog*", "$options": "i"} },
        { "activeFrom": {"$gt": datetime.now()} },  ""  
    ]
}) # similar to SELECT * FROM survey WHERE question MATCH "prog*/i" AND activeFrom CURRENT_TIMESTAMP

result = survey_collection.insert_one(survey)
print(f"inserted survey id={result.inserted_id}")
