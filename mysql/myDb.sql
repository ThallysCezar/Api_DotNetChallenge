SELECT * FROM projetodesafiomatheus.stockitem;

INSERT INTO projetodesafiomatheus.stockitem (Id, ProductId, Quantity, StoreId, CostPriceProduct)
SELECT 
  NULL AS Id,
  FLOOR(RAND() * 1000) + 6 AS ProductId,
  FLOOR(RAND() * 100) AS Quantity,
  FLOOR(RAND() * 1000) + 6 AS StoreId,
  (RAND() * (100 - 0) + 0) AS CostPriceProduct
FROM
  (SELECT 1 UNION SELECT 2 UNION SELECT 3 UNION SELECT 4 UNION SELECT 5
   UNION SELECT 6 UNION SELECT 7 UNION SELECT 8 UNION SELECT 9 UNION SELECT 10) AS numbers;
