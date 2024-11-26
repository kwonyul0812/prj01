DROP TABLE sub_category PURGE
/
CREATE TABLE sub_category(sub_category_no NUMBER PRIMARY KEY, name VARCHAR(30) NOT NULL, major_category_no NUMBER NOT NULL, FOREIGN KEY (major_category_no) REFERENCES major_category(major_category_no))
/
INSERT INTO sub_category VALUES(1, '에스프레소', 1)
/
INSERT INTO sub_category VALUES(2, '라떼', 1)
/
INSERT INTO sub_category VALUES(3, '콜드브루', 1)
/
INSERT INTO sub_category VALUES(4, '에이드', 2)
/
INSERT INTO sub_category VALUES(5, '스무디', 2)
/
INSERT INTO sub_category VALUES(6, '티', 2)
/
INSERT INTO sub_category VALUES(7, '베이커리', 3)
/
INSERT INTO sub_category VALUES(8, '케이크', 3)
/