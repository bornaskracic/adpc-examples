-- Example 04
-- Insert the two students into the database using transaction. Make sure to make a mistake while inserting the second student 
-- (e.g. explicit definition of duplicate primary key) and ensure that transaction didn't execute.

BEGIN;
INSERT INTO student(id, first_name, last_name)
VALUES (1001, 'Alice', 'Brown');
-- Second insert causes a failure (duplicate primary key)
INSERT INTO student(id, first_name, last_name)
VALUES (1001, 'Bob', 'Smith');
COMMIT;  -- will NOT execute because the transaction is aborted

-- Ensure that the transaction did not execute correctly:
SELECT * FROM student WHERE id = 1001;
