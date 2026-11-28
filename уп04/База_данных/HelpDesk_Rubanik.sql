CREATE DATABASE HelpDesk_Rubanik;
GO
USE HelpDesk_Rubanik;
GO
CREATE TABLE Roles
(
    Id INT IDENTITY(1,1) CONSTRAINT PK_Roles PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL CONSTRAINT UQ_Roles_Name UNIQUE
);
GO
CREATE TABLE Categories
(
    Id INT IDENTITY(1,1) CONSTRAINT PK_Categories PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL CONSTRAINT UQ_Categories_Name UNIQUE
);
GO
CREATE TABLE Priorities
(
    Id INT IDENTITY(1,1) CONSTRAINT PK_Priorities PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL CONSTRAINT UQ_Priorities_Name UNIQUE,
    SortOrder INT NOT NULL
);
GO
CREATE TABLE Statuses
(
    Id INT IDENTITY(1,1) CONSTRAINT PK_Statuses PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL CONSTRAINT UQ_Statuses_Name UNIQUE
);
GO
CREATE TABLE Users
(
    Id INT IDENTITY(1,1) CONSTRAINT PK_Users PRIMARY KEY,
    Login NVARCHAR(50) NOT NULL CONSTRAINT UQ_Users_Login UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    FullName NVARCHAR(150) NOT NULL,
    RoleId INT NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_Users_Roles FOREIGN KEY (RoleId) REFERENCES Roles(Id)
);
GO
CREATE TABLE Tickets
(
    Id INT IDENTITY(1,1) CONSTRAINT PK_Tickets PRIMARY KEY,
    UserId INT NOT NULL,
    CategoryId INT NOT NULL,
    PriorityId INT NOT NULL,
    StatusId INT NOT NULL,
    Description NVARCHAR(1000) NOT NULL,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    AssignedUserId INT NULL,
    CONSTRAINT FK_Tickets_Users FOREIGN KEY (UserId) REFERENCES Users(Id),
    CONSTRAINT FK_Tickets_Categories FOREIGN KEY (CategoryId) REFERENCES Categories(Id),
    CONSTRAINT FK_Tickets_Priorities FOREIGN KEY (PriorityId) REFERENCES Priorities(Id),
    CONSTRAINT FK_Tickets_Statuses FOREIGN KEY (StatusId) REFERENCES Statuses(Id),
    CONSTRAINT FK_Tickets_AssignedUser FOREIGN KEY (AssignedUserId) REFERENCES Users(Id)
);
GO
SET IDENTITY_INSERT Roles ON;
INSERT INTO Roles (Id, Name) VALUES (1, N'Администратор');
INSERT INTO Roles (Id, Name) VALUES (2, N'Специалист');
INSERT INTO Roles (Id, Name) VALUES (3, N'Пользователь');
SET IDENTITY_INSERT Roles OFF;
GO
SET IDENTITY_INSERT Categories ON;
INSERT INTO Categories (Id, Name) VALUES (1, N'Оборудование');
INSERT INTO Categories (Id, Name) VALUES (2, N'Программное обеспечение');
INSERT INTO Categories (Id, Name) VALUES (3, N'Сеть');
INSERT INTO Categories (Id, Name) VALUES (4, N'Учётная запись');
INSERT INTO Categories (Id, Name) VALUES (5, N'Периферия');
INSERT INTO Categories (Id, Name) VALUES (6, N'Другое');
SET IDENTITY_INSERT Categories OFF;
GO
SET IDENTITY_INSERT Priorities ON;
INSERT INTO Priorities (Id, Name, SortOrder) VALUES (1, N'Низкий', 1);
INSERT INTO Priorities (Id, Name, SortOrder) VALUES (2, N'Средний', 2);
INSERT INTO Priorities (Id, Name, SortOrder) VALUES (3, N'Высокий', 3);
SET IDENTITY_INSERT Priorities OFF;
GO
SET IDENTITY_INSERT Statuses ON;
INSERT INTO Statuses (Id, Name) VALUES (1, N'Новая');
INSERT INTO Statuses (Id, Name) VALUES (2, N'В работе');
INSERT INTO Statuses (Id, Name) VALUES (3, N'Выполнена');
INSERT INTO Statuses (Id, Name) VALUES (4, N'Отклонена');
SET IDENTITY_INSERT Statuses OFF;
GO
SET IDENTITY_INSERT Users ON;
INSERT INTO Users (Id, Login, PasswordHash, FullName, RoleId, IsActive) VALUES (1, N'admin', N'100000.kfeUYV+IlzJMN1YqZ3gq9g==.kQItwawon5n0p2GTBXYg/+egICubxOkEDbNFpEiVjwc=', N'Рубаник Станислав', 1, 1);
INSERT INTO Users (Id, Login, PasswordHash, FullName, RoleId, IsActive) VALUES (2, N'support1', N'100000.xp7nbU7/jTwiZpdXAbl37w==.2v7kcGVk596eigl+s7Ufa6T8DYgfLLA6Gjt63xcUzaM=', N'Петров Иван Сергеевич', 2, 1);
INSERT INTO Users (Id, Login, PasswordHash, FullName, RoleId, IsActive) VALUES (3, N'user1', N'100000.Yt6/xkpr5k0VsG3V3UrDQg==.Y5awh7nFz5VszImQkwtfwKWsQ72rdYZSgQXjlpLO5mI=', N'Сидорова Анна Павловна', 3, 1);
SET IDENTITY_INSERT Users OFF;
GO
SET IDENTITY_INSERT Tickets ON;
INSERT INTO Tickets (Id, UserId, CategoryId, PriorityId, StatusId, Description, CreatedAt, AssignedUserId) VALUES (1, 3, 3, 3, 1, N'Нет доступа в Интернет', '2026-11-20T15:17:53.470', NULL);
INSERT INTO Tickets (Id, UserId, CategoryId, PriorityId, StatusId, Description, CreatedAt, AssignedUserId) VALUES (2, 3, 2, 2, 2, N'Не запускается Microsoft Word', '2026-11-20T15:17:53.470', 2);
INSERT INTO Tickets (Id, UserId, CategoryId, PriorityId, StatusId, Description, CreatedAt, AssignedUserId) VALUES (3, 3, 1, 1, 3, N'Не работает принтер', '2026-11-20T15:17:53.470', 2);
INSERT INTO Tickets (Id, UserId, CategoryId, PriorityId, StatusId, Description, CreatedAt, AssignedUserId) VALUES (4, 3, 5, 2, 1, N'Не работает принтер в кабинете 214', '2026-11-20T15:17:53.470', NULL);
INSERT INTO Tickets (Id, UserId, CategoryId, PriorityId, StatusId, Description, CreatedAt, AssignedUserId) VALUES (5, 3, 4, 3, 4, N'Забыт пароль от учётной записи', '2026-11-20T15:17:53.470', 2);
SET IDENTITY_INSERT Tickets OFF;
GO
