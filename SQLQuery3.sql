SET IDENTITY_INSERT Customers ON;
INSERT INTO Customers (CustomerId, CustomerCode, FullName, Phone, Password)
VALUES
(1, 'C001', N'Nguyen Van A', '0901111111', '12345'),
(2, 'C002', N'Tran Thi B', '0902222222', '12345'),
(3, 'C003', N'Le Van C', '0903333333', 'abcde'),
(4, 'C004', N'Pham Thi D', '0904444444', '11111');
SET IDENTITY_INSERT Customers OFF;
GO