CREATE TABLE Addition (
    id INT IDENTITY(1,1) PRIMARY KEY,
    first_num FLOAT NOT NULL,
    second_num FLOAT NOT NULL,
    result FLOAT
);
CREATE TABLE Subtraction (
    id INT IDENTITY(1,1) PRIMARY KEY,
    first_num FLOAT NOT NULL,
    second_num FLOAT NOT NULL,
    result FLOAT
);
CREATE TABLE Multiplication (
    id INT IDENTITY(1,1) PRIMARY KEY,
    first_num FLOAT NOT NULL,
    second_num FLOAT NOT NULL,
    result FLOAT
);
CREATE TABLE Division (
    id INT IDENTITY(1,1) PRIMARY KEY,
    first_num FLOAT NOT NULL,
    second_num FLOAT NOT NULL,
    result FLOAT
);
CREATE TABLE Square (
    id INT IDENTITY(1,1) PRIMARY KEY,
    num FLOAT NOT NULL,
    result FLOAT
);
CREATE TABLE SquareRoot (
    id INT IDENTITY(1,1) PRIMARY KEY,
    num FLOAT NOT NULL,
    result FLOAT
);
