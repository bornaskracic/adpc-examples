create table student_group(
	id bigserial primary key,
	name varchar(10) not null,
	academic_year smallint not null
);

CREATE TABLE student(
	id bigserial primary key,
	first_name varchar(255) not null,
	last_name varchar(255) not null,
	jmbag char(13) not null,
	group_id bigserial,
	CONSTRAINT student_group FOREIGN KEY (group_id) REFERENCES student_group(id)
);

CREATE TABLE course(
	id bigserial primary key,
	name varchar(255) not null,
	academic_year smallint not null
);

create table student_course(
	id bigserial primary key,
	student_id bigserial not null references student(id),
	course_id bigserial not null references course(id),
	created_at timestamp not null
);

create table schoolwork(
	id bigserial primary key,
	name varchar(255) not null,
	task_text varchar(255) not null,
	learning_outcome smallint not null,
	max_points smallint not null
);

create table student_solution(
	id bigserial primary key,
	student_id bigserial not null references student(id),
	schoolwork_id bigserial not null references schoolwork(id),
	solution text,
	submitted_at timestamp not null,
	points_graded smallint
);


INSERT INTO student_group (name, academic_year) VALUES
    ('Group A', 2024),
    ('Group B', 2024),
    ('Group C', 2023);

-- Seed for student table
INSERT INTO student (first_name, last_name, jmbag, group_id) VALUES
    ('John', 'Doe', '1234567890123', 1),
    ('Jane', 'Smith', '9876543210987', 2),
    ('Alice', 'Johnson', '4567891234567', 1),
    ('Bob', 'Brown', '3210987654321', 3);

-- Seed for course table
INSERT INTO course (name, academic_year) VALUES
    ('Advanced Programming', 2024),
    ('Data Structures', 2024),
    ('Operating Systems', 2023);

-- Seed for student_course table
INSERT INTO student_course (student_id, course_id, created_at) VALUES
    (1, 1, '2024-01-15 10:00:00'),  -- John enrolled in Advanced Programming
    (1, 2, '2024-01-16 11:00:00'),  -- John enrolled in Data Structures
    (2, 1, '2024-01-17 09:00:00'),  -- Jane enrolled in Advanced Programming
    (3, 2, '2024-01-18 12:00:00'),  -- Alice enrolled in Data Structures
    (4, 3, '2023-11-10 14:00:00');  -- Bob enrolled in Operating Systems

-- Seed for schoolwork table (Programming tasks)
INSERT INTO schoolwork (name, task_text, learning_outcome, max_points) VALUES
    ('Basic C++ Program', 'Write a C++ program that prints "Hello, World!"', 1, 10),
    ('Python Sorting Algorithm', 'Implement quicksort in Python', 2, 20),
    ('Operating System Scheduler', 'Design a simple round-robin scheduler in C++', 3, 30);

-- Seed for student_solution table
INSERT INTO student_solution (student_id, schoolwork_id, solution, submitted_at, points_graded) VALUES
    (1, 1, '#include <iostream> int main() { std::cout << "Hello, World!"; return 0; }', '2024-01-20 15:30:00', 10),  -- John's solution to Basic C++ Program
    (2, 2, 'def quicksort(arr): if len(arr) <= 1: return arr ...', '2024-01-21 16:45:00', 18),  -- Jane's solution to Python Sorting Algorithm
    (3, 2, 'def quicksort(arr): if len(arr) <= 1: return arr ...', '2024-01-22 17:30:00', NULL),  -- Alice submitted but not yet graded
    (4, 3, '#include <iostream> ... int main() { ... }', '2023-12-10 10:15:00', 25);  -- Bob's solution to OS Scheduler
