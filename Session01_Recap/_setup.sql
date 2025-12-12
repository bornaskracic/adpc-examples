CREATE TABLE student (
    id SERIAL PRIMARY KEY,
    first_name TEXT,
    last_name TEXT,
    enrollment_year INT
);

CREATE TABLE exam (
    id SERIAL PRIMARY KEY,
    exam_name TEXT,
    exam_date DATE,
    max_points INT
);

CREATE TABLE exam_application (
    id SERIAL PRIMARY KEY,
    student_id INT REFERENCES student(id),
    exam_id INT REFERENCES exam(id),
    points_scored NUMERIC(5,2),
    status TEXT 
);

INSERT INTO student (first_name, last_name, enrollment_year)
SELECT
    (ARRAY['Alice','Bob','Charlie','Diana','Eve','Frank','Grace','Hank','Ivy','Jack'])[floor(random()*10+1)],
    (ARRAY['Smith','Johnson','Williams','Brown','Jones','Miller','Davis','Garcia','Rodriguez','Wilson'])[floor(random()*10+1)],
    (2020 + floor(random()*5))
FROM generate_series(1, 100);

INSERT INTO exam (exam_name, exam_date, max_points)
SELECT
    (ARRAY['Math','Physics','Chemistry','Biology','History','English','Computer Science'])[floor(random()*7+1)],
    CURRENT_DATE - (floor(random()*365)) * INTERVAL '1 day', 
    100
FROM generate_series(1, 20);

INSERT INTO exam_application (student_id, exam_id, points_scored, status)
SELECT
    floor(random()*100 + 1),  
    floor(random()*20 + 1),    
    round((random()*100)::numeric, 2),
    (ARRAY['passed','failed','absent'])[floor(random()*3+1)]
FROM generate_series(1, 500);