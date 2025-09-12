CREATE DATABASE LibraryDB;
USE LibraryDB;

CREATE TABLE Authors (
    author_id INT AUTO_INCREMENT PRIMARY KEY,
    author_name VARCHAR(50) NOT NULL,
    country VARCHAR(50)
);

CREATE TABLE Books (
    book_id INT AUTO_INCREMENT PRIMARY KEY,
    title VARCHAR(200) NOT NULL,
    author_id INT,
    published_year INT,
    genre VARCHAR(50),
    available_copies INT DEFAULT 0,
    FOREIGN KEY (author_id) REFERENCES Authors(author_id)
);

CREATE TABLE Borrowers (
    borrower_id INT AUTO_INCREMENT PRIMARY KEY,
    borrower_name VARCHAR(100) NOT NULL,
    membership_date DATE
);

INSERT INTO Authors (author_name, country) VALUES
('J.K. Rowling', 'UK'),
('George Orwell', 'UK'),
('Mark Twain', 'USA');

INSERT INTO Books (title, author_id, published_year, genre, available_copies) VALUES
('Harry Potter', 1, 1997, 'Fantasy', 5),
('1984', 2, 1949, 'Dystopian', 3),
('Animal Farm', 2, 1945, 'Political Satire', 4),
('Adventures of Tom Sawyer', 3, 1876, 'Adventure', 2);

INSERT INTO Borrowers (borrower_name, membership_date) VALUES
('Alice', '2022-01-15'),
('Bob', '2022-02-10'),
('Charlie', '2022-03-05');

-- Joins
SELECT b.title, a.author_name, b.genre
FROM Books b
JOIN Authors a ON b.author_id = a.author_id;

SELECT a.author_name, COUNT(b.book_id) AS total_books
FROM Authors a
LEFT JOIN Books b ON a.author_id = b.author_id
GROUP BY a.author_name;

SELECT genre, AVG(available_copies) AS avg_copies
FROM Books
GROUP BY genre;

