DROP TABLE orders PURGE
/
DROP SEQUENCE orders_sequence
/
DROP TRIGGER orders_trigger
/
CREATE TABLE orders(order_no NUMBER PRIMARY KEY, cart_no NUMBER NOT NULL, order_date DATE DEFAULT SYSDATE, order_price NUMBER NOT NULL, FOREIGN KEY (cart_no) REFERENCES cart(cart_no))
/
CREATE SEQUENCE orders_sequence START WITH 1 INCREMENT BY 1
/
CREATE OR REPLACE TRIGGER orders_trigger 
BEFORE INSERT ON orders
FOR EACH ROW 
BEGIN 
	:NEW.order_no := orders_sequence.NEXTVAL; 
END;
/
INSERT INTO orders (cart_no, order_price) VALUES (1, 20000)
/