CREATE DATABASE Bookstore;
USE Bookstore;


CREATE TABLE Authors (
    AuthorID INT PRIMARY KEY IDENTITY(1,1), 
    Name VARCHAR(100) NOT NULL,
    Bio TEXT,
    BirthDate DATE
);

CREATE TABLE Books (
    BookID INT PRIMARY KEY IDENTITY(1,1),
    Title VARCHAR(150) NOT NULL,
    TypeBook VARCHAR(50),
    Price DECIMAL(10, 2) NOT NULL,
    PublishedDate DATE,
    AuthorID INT 
    CONSTRAINT FK_Books_Authors FOREIGN KEY (AuthorID) REFERENCES Authors(AuthorID)
);