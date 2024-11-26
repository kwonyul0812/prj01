DROP TABLE stamp_detail PURGE
/
DROP SEQUENCE stamp_detail_sequence
/
DROP TRIGGER stamp_detail_trigger
/
CREATE TABLE stamp_detail(stamp_detail_no NUMBER PRIMARY KEY, member_no NUMBER NOT NULL, order_no NUMBER NOT NULL, is_used VARCHAR(1) CHECK (is_used IN ('Y', 'N')), count NUMBER NOT NULL, FOREIGN KEY (member_no) REFERENCES member(member_no), FOREIGN KEY (order_no) REFERENCES orders(order_no))
/
CREATE SEQUENCE stamp_detail_sequence START WITH 1 INCREMENT BY 1
/
CREATE OR REPLACE TRIGGER stamp_detail_trigger 
BEFORE INSERT ON stamp_detail
FOR EACH ROW 
BEGIN 
	:NEW.stamp_detail_no := stamp_detail_sequence.NEXTVAL; 
END; 
/
INSERT INTO stamp_detail (member_no, order_no, is_used, count) VALUES (1, 1, 'N', 10)
/