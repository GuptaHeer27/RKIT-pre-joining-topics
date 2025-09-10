CREATE DATABASE StudentDB;
USE StudentDB;

CREATE TABLE Students(
    student_id int,
    name varchar(10),
    age int,
    gender varchar(10),
    course_id int
    );
    
CREATE TABLE Courses(
   course_id int,
   course_name varchar(12),
   duration time
   );
   
CREATE TABLE Marks(
   mark_id int,
   student_id int,
   subject varchar(10),
   score int
   );

ALTER TABLE Students
ADD Email varchar(30);

DROP TABLE IF EXists Marks;

INSERT INTO Students
VALUES 
(101,'Aa',21,'FEMALE',01),
(102,'Bb',22,'MALE',01),
(103,'Cc',20,'FEMALE',02),
(104,'Dd',21,'MALE',07),
(105,'Ee',24,'FEMALE',03);


INSERT INTO Courses
VALUES
(01,'java','04:00:00'),
(02,'python','03:00:00'),
(03,'C','03:00:00'),
(04,'html','03:00:00'),
(07,'css','03:00:00');

INSERT INTO Marks
VALUES
(1,101,'English',100),
(2,102,'English',95),
(3,103,'English',80),
(4,104,'English',75),
(5,105,'English',82);

SET SQL_SAFE_UPDATES = 0;


UPDATE Students
SET course_id='04'
WHERE
     Student_id='102';

DELETE FROM Students
WHERE
     Student_id='104';

