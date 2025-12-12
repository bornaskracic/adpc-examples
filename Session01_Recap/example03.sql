-- Example 03
-- NOTE: Make sure to setup the database by using '_setup.sql' script as described in README.md file. Retrieve the following:

-- a) Top 5 students by average number of scored points on the exams
SELECT 
    s.id,
    s.first_name,
    s.last_name,
    AVG(ea.points_scored) AS avg_points
FROM student s
JOIN exam_application ea 
    ON ea.student_id = s.id
GROUP BY s.id
ORDER BY avg_points DESC
LIMIT 5;

-- b) Most popular exams (by number of applications)
SELECT 
    e.id,
    e.exam_name,
    e.exam_date,
    COUNT(ea.student_id) AS application_count
FROM exam e
LEFT JOIN exam_application ea 
    ON ea.exam_id = e.id
GROUP BY e.id
ORDER BY application_count DESC;

-- c) Exam pass rate (in percentages)
SELECT 
    ROUND(
        100.0 * SUM(CASE WHEN ea.points_scored >= e.max_points * 0.5 THEN 1 ELSE 0 END)
        / COUNT(*) , 2
    ) AS pass_rate_percent
FROM exam_application ea
JOIN exam e 
    ON e.id = ea.exam_id;