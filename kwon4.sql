DROP TABLE major_category PURGE
/
CREATE TABLE major_category(major_category_no NUMBER PRIMARY KEY, name VARCHAR(20) NOT NULL)
/
INSERT INTO major_category VALUES(1, '커피')
/
INSERT INTO major_category VALUES(2, '음료')
/
INSERT INTO major_category VALUES(3, '푸드')
/