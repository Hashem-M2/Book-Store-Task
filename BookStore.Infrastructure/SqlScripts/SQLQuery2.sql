CREATE PROCEDURE AddAuthor
    @Name NVARCHAR(100),
    @Bio NVARCHAR(MAX) = NULL, -- Optional Bio
    @BirthDate DATE = NULL -- Optional BirthDate
AS
BEGIN
    INSERT INTO Authors (Name, Bio, BirthDate)
    VALUES (@Name, @Bio, @BirthDate);
END;
 

 CREATE PROCEDURE GetAllAuthors
AS
BEGIN
    SELECT AuthorId, Name, Bio, BirthDate
    FROM Authors;
END;


CREATE PROCEDURE GetAuthorById
    @AuthorId INT
AS
BEGIN
    SELECT AuthorId, Name, Bio, BirthDate
    FROM Authors
    WHERE AuthorId = @AuthorId;
END;

CREATE PROCEDURE UpdateAuthor
    @AuthorId INT,
    @Name NVARCHAR(100),
    @Bio NVARCHAR(MAX) = NULL, -- Optional Bio
    @BirthDate DATE = NULL -- Optional BirthDate
AS
BEGIN
    UPDATE Authors
    SET Name = @Name,
        Bio = @Bio,
        BirthDate = @BirthDate
    WHERE AuthorId = @AuthorId;
END;

CREATE PROCEDURE DeleteAuthor
    @AuthorId INT
AS
BEGIN
    DELETE FROM Authors
    WHERE AuthorId = @AuthorId;
END;

CREATE PROCEDURE AddBook
    @Title NVARCHAR(200),
    @TypeBook NVARCHAR(100) = NULL, -- Optional TypeBook
    @Price DECIMAL(18, 2),
    @PublishedDate DATE = NULL, -- Optional PublishedDate
    @AuthorId INT
AS
BEGIN
    INSERT INTO Books (Title, TypeBook, Price, PublishedDate, AuthorId)
    VALUES (@Title, @TypeBook, @Price, @PublishedDate, @AuthorId);
END;


CREATE PROCEDURE GetAllBooks
AS
BEGIN
    SELECT B.BookId, B.Title, B.TypeBook, B.Price, B.PublishedDate, A.Name AS AuthorName
    FROM Books B
    INNER JOIN Authors A ON B.AuthorId = A.AuthorId;
END;




ALTER PROCEDURE GetAllBooks
AS
BEGIN
    SELECT 
        B.BookId, 
        B.Title, 
        B.TypeBook, 
        B.Price, 
        B.PublishedDate, 
        B.AuthorId,  -- Make sure AuthorId is included
        A.Name AS AuthorName
    FROM Books B
    INNER JOIN Authors A ON B.AuthorId = A.AuthorId;
END;










CREATE PROCEDURE GetBookById
    @BookId INT
AS
BEGIN
    SELECT B.BookId, B.Title, B.TypeBook, B.Price, B.PublishedDate, A.Name AS AuthorName
    FROM Books B
    INNER JOIN Authors A ON B.AuthorId = A.AuthorId
    WHERE B.BookId = @BookId;
END;


CREATE PROCEDURE UpdateBook
    @BookId INT,
    @Title NVARCHAR(200),
    @TypeBook NVARCHAR(100) = NULL, -- Optional TypeBook
    @Price DECIMAL(18, 2),
    @PublishedDate DATE = NULL, -- Optional PublishedDate
    @AuthorId INT
AS
BEGIN
    UPDATE Books
    SET Title = @Title,
        TypeBook = @TypeBook,
        Price = @Price,
        PublishedDate = @PublishedDate,
        AuthorId = @AuthorId
    WHERE BookId = @BookId;
END;



-- Execute the stored procedure to update a book
EXEC UpdateBook 
    @BookId = 1, 
    @Title = 'Updated Book Title', 
    @TypeBook = 'Fiction', 
    @Price = 29.99, 
    @PublishedDate = '2024-11-21', 
    @AuthorId = 1;


CREATE PROCEDURE DeleteBook
    @BookId INT
AS
BEGIN
    DELETE FROM Books
    WHERE BookId = @BookId;
END;



EXEC AddBook 
    @Title = 'Sample4 Title', 
    @TypeBook = 'Fiction', 
    @Price = 19.99, 
    @PublishedDate = '2023-01-01', 
    @AuthorId = 1;
	

	EXEC GetAllBooks


