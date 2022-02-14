create table Users 
(
	UserID int primary key identity(1,1),
	FullName varchar(50),
	ID varchar(15) unique,
	phone varchar(15),
	Addres varchar(120),
	traveled_out varchar(6),
		Resualt varchar(250)

);