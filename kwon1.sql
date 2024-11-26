DROP TABLE member_type PURGE
/
CREATE TABLE member_type(member_type_no NUMBER PRIMARY KEY, name VARCHAR(20))
/
INSERT INTO member_type VALUES(1, '일반회원')
/
INSERT INTO member_type VALUES(2, '관리자')
/
