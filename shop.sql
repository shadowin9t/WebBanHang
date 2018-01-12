
create database shop;
use shop;
create table tb_user(
username char(20) primary key,
password nvarchar(256),
firstname nvarchar(30),
lastname nvarchar(30),
email nvarchar(50)
);
create table tb_status(
statusid int primary key,
statusname nvarchar(30)
);

drop table tb_product;
drop table tb_category;

insert into tb_status values(1,N'Đang dùng');
insert into tb_status values(2, N'Khóa');

create table tb_category(
categoryid char(10) primary key,
categoryname nvarchar(30),
discription nvarchar(500),
categoryimage nvarchar(200),
createddate datetime,
username char(20) foreign key references tb_user(username),
statusid int foreign key references tb_status(statusid)
);
create table tb_product(
productid char(10) primary key,
productname nvarchar(30),
feature bit,
shortdiscription nvarchar(200),
discription nvarchar(500),
price float,
finalprice float,
displayimage nvarchar(200),
quantity int,
statusid int foreign key references tb_status(statusid),
createdby char(20) foreign key references tb_user(username),
createddate datetime,
categoryid char(10) foreign key references tb_category(categoryid)
);

create table tb_permission(
permissionid char(30) primary key,
permissionname nvarchar(255)
);



create table tb_permission_user(
permissionid char(30) foreign key references tb_permission(permissionid),
username char(20) foreign key references tb_user(username),
primary key (permissionid, username)
);
select * from tb_permission_user;

INSERT INTO dbo.tb_user
        ( username ,
          password ,
          firstname ,
          lastname ,
          email
        )
VALUES  ( 'admin' , -- username - char(20)
          N'admin' , -- password - nvarchar(256)
          N'hieu' , -- firstname - nvarchar(30)
          N'hieu' , -- lastname - nvarchar(30)
          N'hieu@gmail.com'  -- email - nvarchar(50)
        )


insert into tb_permission values('SUPER_ADMIN',N'Quyền quản trị hệ thống');
insert into tb_permission values('USER_ADMIN',N'Quyền quản lí người dùng');
insert into tb_permission values('PRODUCT_ADMIN',N'Quyền quản lí sản phẩm');
insert into tb_permission values('ORDER_ADMIN', N'Quyền quản lí đơn đặt hàng');
insert into tb_permission values('ARTICLE_ADMIN', N'Quyền quản lí bài viết');

insert into tb_permission_user values('SUPER_ADMIN','admin');
CREATE TABLE tb_Customer(
	CustomerId INT IDENTITY(2018,1) PRIMARY KEY,
	Phone NVARCHAR(30),
	Adress NVARCHAR(200),
	FirtName NVARCHAR(30),
	LastName NVARCHAR(30),
	CreatedDate DATETIME,
	Email NVARCHAR(30),
	Pass NVARCHAR(256)
);

CREATE TABLE tb_OrderStatus(
	OrderStatusId NVARCHAR(10) PRIMARY KEY,
	OrderStatusName NVARCHAR(30)
);

CREATE TABLE tb_Order(
	OrderId NVARCHAR(10) PRIMARY KEY,
	CreatedDate DATETIME,
	OrderDate DATETIME,
	CustomerId INT NOT NULL,
	OrderAdrees NVARCHAR(200),
	StatusOrderId NVARCHAR(10) NOT NULL,
	FOREIGN KEY (CustomerId) REFERENCES dbo.tb_Customer(CustomerId),
	FOREIGN KEY (StatusOrderId) REFERENCES dbo.tb_OrderStatus(OrderStatusId)
);

CREATE TABLE tb_OrderDetail(
	OrderId NVARCHAR(10) NOT NULL,
	productid char(10) NOT NULL,
	PRIMARY KEY (OrderId, productid),
	FOREIGN KEY (OrderId) REFERENCES dbo.tb_Order(OrderId),
	FOREIGN KEY (productid) REFERENCES dbo.tb_product(productid)
);