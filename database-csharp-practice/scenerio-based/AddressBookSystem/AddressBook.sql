CREATE database AddressBook;
use AddressBook;
CREATE TABLE AddressBooks (
    AddressBookId INT IDENTITY(1,1) CONSTRAINT PK_AddressBooks PRIMARY KEY,
    Name          NVARCHAR(100) NOT NULL,
    Description   NVARCHAR(255) NULL,
    CreatedAt     DATETIME2     NOT NULL CONSTRAINT DF_AddressBooks_CreatedAt DEFAULT SYSUTCDATETIME()
);

-- Ensure each Address Book name is unique
CREATE UNIQUE INDEX UX_AddressBooks_Name ON AddressBooks(Name);

CREATE TABLE Contacts (
    ContactId     INT IDENTITY(1,1) CONSTRAINT PK_Contacts PRIMARY KEY,
    AddressBookId INT NOT NULL,
    FirstName     NVARCHAR(50)  NOT NULL,
    LastName      NVARCHAR(50)  NOT NULL,
    Address       NVARCHAR(255) NULL,
    City          NVARCHAR(100) NULL,
    State         NVARCHAR(100) NULL,
    Zip           NVARCHAR(20)  NULL,
    Phone         NVARCHAR(50)  NULL,
    Email         NVARCHAR(100) NULL,
    CreatedAt     DATETIME2     NOT NULL CONSTRAINT DF_Contacts_CreatedAt DEFAULT SYSUTCDATETIME(),
    ModifiedAt    DATETIME2     NULL
);

-- Foreign key: each contact belongs to one AddressBook
ALTER TABLE Contacts
ADD CONSTRAINT FK_Contacts_AddressBooks
    FOREIGN KEY (AddressBookId)
    REFERENCES AddressBooks(AddressBookId)
    ON DELETE CASCADE;  -- delete contacts when the address book is deleted
CREATE UNIQUE INDEX UX_Contacts_AddressBook_Person
ON Contacts(AddressBookId, FirstName, LastName);

CREATE INDEX IX_Contacts_City
ON Contacts(City);

CREATE INDEX IX_Contacts_State
ON Contacts(State);

INSERT INTO AddressBooks (Name, Description)
VALUES
    ('Family', 'Family contacts'),
    ('Office', 'Office contacts');

-- Suppose Family has AddressBookId = 1, Office = 2

INSERT INTO Contacts (AddressBookId, FirstName, LastName, Address, City, State, Zip, Phone, Email)
VALUES
    (1, 'John', 'Doe', '123 Main St', 'Mumbai', 'Maharashtra', '400001', '9876543210', 'john.doe@example.com'),
    (1, 'Jane', 'Doe', '456 Park Rd', 'Pune', 'Maharashtra', '411001', '9123456789', 'jane.doe@example.com'),
    (2, 'John', 'Doe', '789 Office Ln', 'Bengaluru', 'Karnataka', '560001', '9988776655', 'john.doe@office.com');
    select * from Contacts;
    select * from AddressBooks;