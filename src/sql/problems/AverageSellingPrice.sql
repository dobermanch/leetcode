/* https://leetcode.com/problems/average-selling-price/ */

Create table If Not Exists Prices (product_id int, start_date date, end_date date, price int)
Create table If Not Exists UnitsSold (product_id int, purchase_date date, units int)
Truncate table Prices
insert into Prices (product_id, start_date, end_date, price) values ('1', '2019-02-17', '2019-02-28', '5')
insert into Prices (product_id, start_date, end_date, price) values ('1', '2019-03-01', '2019-03-22', '20')
insert into Prices (product_id, start_date, end_date, price) values ('2', '2019-02-01', '2019-02-20', '15')
insert into Prices (product_id, start_date, end_date, price) values ('2', '2019-02-21', '2019-03-31', '30')
Truncate table UnitsSold
insert into UnitsSold (product_id, purchase_date, units) values ('1', '2019-02-25', '100')
insert into UnitsSold (product_id, purchase_date, units) values ('1', '2019-03-01', '15')
insert into UnitsSold (product_id, purchase_date, units) values ('2', '2019-02-10', '200')
insert into UnitsSold (product_id, purchase_date, units) values ('2', '2019-03-22', '30')

/* Solution MySQL */
SELECT 
    p.product_id,
    round(sum(1.0 * p.price * ifnull(us.units, 0)) / sum(ifnull(us.units, 1)), 2) AS average_price
FROM Prices p
LEFT JOIN UnitsSold us ON p.product_id = us.product_id
WHERE 
    us.purchase_date BETWEEN p.start_date AND p.end_date 
    OR us.product_id IS NULL
GROUP BY p.product_id

/* Solution T_SQL*/
SELECT 
    p.product_id,
    round(sum(1.0 * p.price * isnull(us.units, 0)) / sum(isnull(us.units, 1)), 2) AS average_price
FROM Prices p
LEFT JOIN UnitsSold us ON p.product_id = us.product_id
WHERE 
    us.purchase_date BETWEEN p.start_date AND p.end_date
    OR us.product_id IS NULL
GROUP BY p.product_id
