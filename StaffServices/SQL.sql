CREATE DATABASE IF NOT EXISTS Staffs;
USE Staffs;

CREATE TABLE  Gender (
    GenderID INT PRIMARY KEY AUTO_INCREMENT,
    GenderDescription VARCHAR(20) NOT NULL
);

CREATE TABLE  Department (
    DepartmentID INT PRIMARY KEY AUTO_INCREMENT,
    DepartmentName VARCHAR(50) NOT NULL
);


CREATE TABLE  Employee (
    EmployeeID INT PRIMARY KEY AUTO_INCREMENT,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    DateOfBirth DATE NOT NULL,
    GenderID INT,
    DepartmentID INT,
    FOREIGN KEY (GenderID) REFERENCES Gender(GenderID),
    FOREIGN KEY (DepartmentID) REFERENCES Department(DepartmentID)
);

INSERT INTO Gender (GenderDescription) VALUES 
('Male'),
('Female'),
('Other');

INSERT INTO Department (DepartmentName) VALUES 
('Human Resources'),
('Finance'),
('Engineering'),
('Sales'),
('Marketing');

INSERT INTO Employee (FirstName, LastName, Email, DateOfBirth, GenderID, DepartmentID) VALUES 
('John', 'Doe', 'johndoe@example.com', '1990-01-15', 1, 3),
('Jane', 'Smith', 'janesmith@example.com', '1985-06-25', 2, 1),
('Alice', 'Johnson', 'alicejohnson@example.com', '1992-08-30', 2, 4),
('Robert', 'Brown', 'robertbrown@example.com', '1988-12-12', 1, 2),
('Emily', 'Davis', 'emilydavis@example.com', '1995-03-18', 2, 5),
('Michael', 'Wilson', 'michaelwilson@example.com', '1993-11-22', 1, 3),
('David', 'Lee', 'davidlee@example.com', '1987-07-05', 1, 1),
('Linda', 'Clark', 'lindaclark@example.com', '1991-09-14', 2, 2),
('Chris', 'Martinez', 'chrismartinez@example.com', '1989-10-28', 1, 4),
('Laura', 'Hernandez', 'laurahernandez@example.com', '1996-02-02', 2, 5);

