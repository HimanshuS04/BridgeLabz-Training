Create database Bank;
Use Bank;
CREATE table Accounts(
    AccountId int Primary key,
    HolderName Varchar(100),
    Balance decimal(18,2)
);
Create table Transactions(
    TransactionId int Primary key IDENTITY(1,1),
    AccountId int,
    Amount decimal(18,2),
    Type VARCHAR(20),
    CreatedDate DateTime  default GETDATE(),
    FOREIGN key (AccountId) References Accounts(AccountId)
);
INSERT INTO Accounts(AccountId, HolderName, Balance)
VALUES (1, 'Himanshu', 10000);

select * from Accounts;
select * from Transactions;