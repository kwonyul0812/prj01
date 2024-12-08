SELECT i.item_no, sc.name AS sub_category_name, i.name AS item_name, cd.count, cd.total_price FROM cart_detail cd JOIN item i ON cd.item_no = i.item_no JOIN sub_category sc ON i.sub_category_no = sc.sub_category_no  WHERE cart_no = 2;

delete from cart_detail where cart_no = 2;
commit;

SELECT * FROM orders o JOIN cart c ON o.cart_no = c.cart_no where c.member_no = 24;
DELETE FROM orders where cart_no = 2;
DELETE FROM cart_detail where cart_no = 2;
commit;

select * from orders;
delete from orders where order_no > 40 and order_no < 55;
commit;
delete from cart where cart_no > 20 and cart_no < 40;
delete from cart_detail where cart_no > 1;


SELECT o.order_no, o.cart_no, TO_CHAR(o.order_date, 'YYYY-MM-DD') AS order_date, o.order_price 
                                    FROM orders o 
                                    JOIN cart c ON o.cart_no = c.cart_no 
                                    WHERE c.member_no = 24 
                                    AND o.order_date BETWEEN TO_DATE('2024-11-21', 'YYYY-MM-DD') AND TO_DATE('2024-11-28 23:59:59', 'YYYY-MM-DD HH24:MI:SS')
                                    ORDER BY o.order_no DESC;
                                    
SELECT o.order_no, o.cart_no, TO_CHAR(o.order_date, 'YYYY-MM-DD') AS order_date, o.order_price 
FROM orders o 
JOIN cart c ON o.cart_no = c.cart_no 
WHERE c.member_no = 24
ORDER BY o.order_no DESC;

INSERT INTO member(id, password, name, phone, member_type_no) VALUES ('admin', '1234', '관리자', '010-1234-1234', 2);
commit;

ALTER TABLE item ADD (stock NUMBER DEFAULT 0);
commit;

ALTER TABLE item ADD (delCheck NUMBER DEFAULT 0);
commit;

SELECT i.name AS item_name, i.price, i.stock, mc.name AS major_name, sc.name AS sub_name  FROM item i
JOIN sub_category sc ON i.sub_category_no = sc.sub_category_no
JOIN major_category mc ON sc.major_category_no = mc.major_category_no;