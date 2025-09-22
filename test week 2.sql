

CREATE DATABASE Employee;
USE Employee;
CREATE TABLE Departments (
    dept_id INT PRIMARY KEY,
    dept_name VARCHAR(50) NOT NULL
);


CREATE TABLE Employees (
    emp_id INT PRIMARY KEY,
    name VARCHAR(50) NOT NULL,
    dept_id INT,
    salary DECIMAL(10,2)
    
);

-- Salaries table
CREATE TABLE Salaries (
    emp_id INT,
    month VARCHAR(20),
    amount DECIMAL(10,2)
);

INSERT INTO Departments VALUES
(1, 'HR'),
(2, 'IT'),
(3, 'Finance');


INSERT INTO Employees VALUES
(101, 'Alice', 1, 5000),
(102, 'Bob', 2, 7000),
(103, 'Charlie', 2, 8000),
(104, 'David', 3, 6000);

INSERT INTO Salaries VALUES
(101, 'Jan', 5000),
(102, 'Jan', 7000),
(103, 'Jan', 8000),
(104, 'Jan', 6000),
(101, 'Feb', 5000),
(102, 'Feb', 7000),
(103, 'Feb', 8000),
(104, 'Feb', 6000);

SELECT e.emp_id, e.name, d.dept_name, s.month, s.amount
FROM Employees e
INNER JOIN Departments d ON e.dept_id = d.dept_id
INNER JOIN Salaries s ON e.emp_id = s.emp_id
ORDER BY e.emp_id, s.month;

SELECT name, dept_id, salary
FROM Employees e
WHERE salary > (
    SELECT AVG(salary)
    FROM Employees
    WHERE dept_id = e.dept_id
);

DELIMITER $$

CREATE PROCEDURE GetYearlySalary(IN emp INT)
BEGIN
    SELECT e.name, SUM(s.amount) AS yearly_salary
    FROM Employees e
    JOIN Salaries s ON e.emp_id = s.emp_id
    WHERE e.emp_id = emp
    GROUP BY e.name;
END $$

DELIMITER ;

CALL GetYearlySalary(102);

-- Create a log table
CREATE TABLE SalaryLog (
    log_id INT AUTO_INCREMENT PRIMARY KEY,
    emp_id INT,
    month VARCHAR(20),
    amount DECIMAL(10,2),
    log_time TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);


DELIMITER $$

CREATE TRIGGER after_salary_insert
AFTER INSERT ON Salaries
FOR EACH ROW
BEGIN
    INSERT INTO SalaryLog(emp_id, month, amount)
    VALUES (NEW.emp_id, NEW.month, NEW.amount);
END $$

DELIMITER ;

CREATE VIEW EmployeeSalarySummary AS
SELECT e.emp_id, e.name, d.dept_name, SUM(s.amount) AS total_salary
FROM Employees e
JOIN Departments d ON e.dept_id = d.dept_id
JOIN Salaries s ON e.emp_id = s.emp_id
GROUP BY e.emp_id, e.name, d.dept_name;

SELECT * FROM EmployeeSalarySummary;

