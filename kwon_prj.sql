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

commit;