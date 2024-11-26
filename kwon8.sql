DROP TABLE cart_detail PURGE
/
CREATE TABLE cart_detail(cart_no NUMBER, item_no NUMBER, count NUMBER NOT NULL, total_price NUMBER NOT NULL, FOREIGN KEY (cart_no) REFERENCES cart(cart_no), FOREIGN KEY (item_no) REFERENCES item(item_no), CONSTRAINT pk_cart_detail PRIMARY KEY (cart_no, item_no))
/
INSERT INTO cart_detail VALUES(1, 1, 10, 20000)
/