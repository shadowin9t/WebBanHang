CREATE DATABASE WebBanHang;
GO
USE WebBanHang;
CREATE TABLE tb_user
    (
      username CHAR(20) PRIMARY KEY ,
      password NVARCHAR(256) ,
      firstname NVARCHAR(30) ,
      lastname NVARCHAR(30) ,
      email NVARCHAR(50)
    );
CREATE TABLE tb_status
    (
      statusid INT PRIMARY KEY ,
      statusname NVARCHAR(30)
    );

INSERT  INTO tb_status
VALUES  ( 1, N'Đang dùng' );
INSERT  INTO tb_status
VALUES  ( 2, N'Khóa' );

CREATE TABLE tb_category
    (
      categoryid CHAR(10) PRIMARY KEY ,
      categoryname NVARCHAR(30) ,
      discription NVARCHAR(500) ,
      categoryimage NVARCHAR(200) ,
      createddate DATETIME ,
      username CHAR(20) FOREIGN KEY REFERENCES tb_user ( username ) ,
      statusid INT FOREIGN KEY REFERENCES tb_status ( statusid )
    );
CREATE TABLE tb_product
    (
      productid CHAR(10) PRIMARY KEY ,
      productname NVARCHAR(30) ,
      feature BIT ,
      shortdiscription NVARCHAR(200) ,
      discription NVARCHAR(500) ,
      price FLOAT ,
      finalprice FLOAT ,
      displayimage NVARCHAR(200) ,
      quantity INT ,
      statusid INT FOREIGN KEY REFERENCES tb_status ( statusid ) ,
      createdby CHAR(20) FOREIGN KEY REFERENCES tb_user ( username ) ,
      createddate DATETIME ,
      categoryid CHAR(10) FOREIGN KEY REFERENCES tb_category ( categoryid )
    );

CREATE TABLE tb_permission
    (
      permissionid CHAR(30) PRIMARY KEY ,
      permissionname NVARCHAR(255)
    );



CREATE TABLE tb_permission_user
    (
      permissionid CHAR(30)
        FOREIGN KEY REFERENCES tb_permission ( permissionid ) ,
      username CHAR(20) FOREIGN KEY REFERENCES tb_user ( username ) ,
      PRIMARY KEY ( permissionid, username )
    );
SELECT  *
FROM    tb_permission_user;

INSERT  INTO dbo.tb_user
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


INSERT  INTO tb_permission
VALUES  ( 'SUPER_ADMIN', N'Quyền quản trị hệ thống' );
INSERT  INTO tb_permission
VALUES  ( 'USER_ADMIN', N'Quyền quản lí người dùng' );
INSERT  INTO tb_permission
VALUES  ( 'PRODUCT_ADMIN', N'Quyền quản lí sản phẩm' );
INSERT  INTO tb_permission
VALUES  ( 'ORDER_ADMIN', N'Quyền quản lí đơn đặt hàng' );
INSERT  INTO tb_permission
VALUES  ( 'ARTICLE_ADMIN', N'Quyền quản lí bài viết' );

INSERT  INTO tb_permission_user
VALUES  ( 'SUPER_ADMIN', 'admin' );


CREATE TABLE tb_Customer
    (
      CustomerId NVARCHAR(30) PRIMARY KEY ,
      Phone NVARCHAR(30) ,
      Adress NVARCHAR(200) ,
      FirtName NVARCHAR(30) ,
      LastName NVARCHAR(30) ,
      CreatedDate DATETIME ,
      Email NVARCHAR(30) ,
      Pass NVARCHAR(256)
    );

CREATE TABLE tb_OrderStatus
    (
      OrderStatusId NVARCHAR(10) PRIMARY KEY ,
      OrderStatusName NVARCHAR(30)
    );

CREATE TABLE tb_Order
    (
      OrderId NVARCHAR(10) PRIMARY KEY ,
      CreatedDate DATETIME ,
      OrderDate DATETIME ,
      CustomerId NVARCHAR(30) NOT NULL ,
      OrderAdrees NVARCHAR(200) ,
      StatusOrderId NVARCHAR(10) NOT NULL ,
      FOREIGN KEY ( CustomerId ) REFERENCES dbo.tb_Customer ( CustomerId ) ,
      FOREIGN KEY ( StatusOrderId ) REFERENCES dbo.tb_OrderStatus ( OrderStatusId )
    );

CREATE TABLE tb_OrderDetail
    (
      OrderId NVARCHAR(10) NOT NULL ,
      productid CHAR(10) NOT NULL ,
      PRIMARY KEY ( OrderId, productid ) ,
      FOREIGN KEY ( OrderId ) REFERENCES dbo.tb_Order ( OrderId ) ,
      FOREIGN KEY ( productid ) REFERENCES dbo.tb_product ( productid )
    );