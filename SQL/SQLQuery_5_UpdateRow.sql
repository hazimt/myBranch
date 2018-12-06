-- The UPDATE statement is used to modify the existing records in a table.
--UPDATE table_name
--SET column1 = value1, column2 = value2...., columnN = valueN
--WHERE [condition];

UPDATE dbo.Customers
SET Name = 'Keithh', Location = 'Indiaa'
WHERE [CustomerId] = 2;


--Delete
--DELETE FROM table_name
--WHERE [condition];

DELETE FROM dbo.Customers
WHERE CustomerId = 2;

-- Insert
insert into dbo.Customers (CustomerId, Name, Location, Email)
values ('2', 'Keith', 'India', 'something@blah.com');
