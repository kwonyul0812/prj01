DROP TABLE cart PURGE
/
DROP SEQUENCE cart_sequence
/
DROP TRIGGER cart_trigger
/
CREATE TABLE cart(cart_no NUMBER PRIMARY KEY, member_no NUMBER NOT NULL, is_purchased VARCHAR(1) CHECK (is_purchased IN ('Y', 'N')), FOREIGN KEY (member_no) REFERENCES member(member_no))
/
CREATE SEQUENCE cart_sequence START WITH 1 INCREMENT BY 1
/
CREATE OR REPLACE TRIGGER cart_trigger 
BEFORE INSERT ON cart 
FOR EACH ROW 
BEGIN 
	:NEW.cart_no := cart_sequence.NEXTVAL; 
END;
/
INSERT INTO cart (member_no, is_purchased) VALUES (1, 'N')
/