DROP TABLE member PURGE
/
DROP SEQUENCE member_sequence
/
DROP TRIGGER member_trigger
/
CREATE TABLE member(member_no NUMBER PRIMARY KEY, id VARCHAR(20) UNIQUE NOT NULL , password VARCHAR(20) NOT NULL, name varchar(20) NOT NULL, phone VARCHAR(20) NOT NULL, member_type_no NUMBER NOT NULL, FOREIGN KEY (member_type_no) REFERENCES member_type(member_type_no))
/
CREATE SEQUENCE member_sequence START WITH 1 INCREMENT BY 1
/
CREATE OR REPLACE TRIGGER member_trigger 
BEFORE INSERT ON member
FOR EACH ROW 
BEGIN 
	:NEW.member_no := member_sequence.NEXTVAL; 
END; 
/
INSERT INTO member (id, password, name, phone, member_type_no) VALUES ('kwonyul', '1234', '권율', '010-4440-2063', 1)
/
INSERT INTO member (id, password, name, phone, member_type_no) VALUES ('test', '1234', '홍길동', '010-4440-2063', 1)
/
