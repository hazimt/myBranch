-- Select rows from table 'Customers'
SELECT count(*) FROM dbo.Customers
HAVING count(*)<5;

-- Select rows from table 'Customers'
SELECT count(*) as "MyRecords" FROM dbo.Customers
HAVING count(*)<5;


-- Select using LIKE
select * from Customers
where Name LIKE 'K%';

-- Select using LIKE
select * from Customers
where Name LIKE '%K%';


-- Select using between
select * from Customers
where Name between 'D' and 'K';

-- Select using LIKE
select * from Customers
where Name between 'D' and 'O';


-- Select using IN
--SELECT * FROM table WHERE column IN (1, 2, 3)
-- Is effectively
--SELECT * FROM table WHERE column = 1 OR column = 2 OR column = 3


select * from Customers
where Name IN ('Orlando', 'Keith', 'Janet');



-- Top
Select * from Customers;

Select top 3 * from Customers;

Select top 30 percent * from Customers;

