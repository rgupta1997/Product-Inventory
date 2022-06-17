Create Table Product
(	
	ProductId int IDENTITY(1,1),
	IsDelete bit,
    Description varchar(255),
    Name varchar(255),
    Price decimal(18,2)
);



