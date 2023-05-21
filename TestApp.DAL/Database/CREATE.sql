CREATE TABLE Product(
Id int not null primary key identity(1,1),
[Name] NVARCHAR(64) Collate Cyrillic_General_CI_AS NOT NULL ,
Price DECIMAL NOT NULL DEFAULT(0),
[Description] nvarchar(256) Collate Cyrillic_General_CI_AS NULL
);

CREATE TABLE CustomerOrder(
Id int not null primary key identity(1,1),
CustomerName NVARCHAR(40) Collate Cyrillic_General_CI_AS NOT NULL,
OrderDate DATETIME NOT NULL DEFAULT(GETDATE()),
);
CREATE TABLE OrderDetails(
Id int not null primary key identity(1,1),
ProductId INT NOT NULL,
Amount INT NOT NULL DEFAULT(1),
TotalPrice DECIMAL NOT NULL DEFAULT(0),
foreign key(ProductId) REFERENCES Product(Id)
);