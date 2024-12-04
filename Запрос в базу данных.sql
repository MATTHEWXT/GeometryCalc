SELECT p.Name AS ProductName, c.Name AS CategoryName
FROM products p
LEFT JOIN categories c ON p.category_id = c.Id;