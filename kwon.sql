DROP TABLE stamp_detail PURGE
/
DROP SEQUENCE stamp_detail_sequence
/
DROP TRIGGER stamp_detail_trigger
/
DROP TABLE orders PURGE
/
DROP SEQUENCE orders_sequence
/
DROP TRIGGER orders_trigger
/
DROP TABLE cart_detail PURGE
/
DROP TABLE cart PURGE
/
DROP SEQUENCE cart_sequence
/
DROP TRIGGER cart_trigger
/
DROP TABLE item PURGE
/
DROP SEQUENCE item_sequence
/
DROP TRIGGER item_trigger
/
DROP TABLE sub_category PURGE
/
DROP TABLE major_category PURGE
/
DROP TABLE stamp PURGE
/
DROP TABLE member PURGE
/
DROP SEQUENCE member_sequence
/
DROP TRIGGER member_trigger
/
DROP TABLE member_type PURGE
/
CREATE TABLE member_type(member_type_no NUMBER PRIMARY KEY, name VARCHAR(20))
/
INSERT INTO member_type VALUES(1, '일반회원')
/
INSERT INTO member_type VALUES(2, '관리자')
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
INSERT INTO member (id, password, name, phone, member_type_no) VALUES ('admin', '1234', '관리자', '010-4440-2063', 2)
/
INSERT INTO member (id, password, name, phone, member_type_no) VALUES ('test', '1234', '홍길동', '010-4440-2063', 1)
/
CREATE TABLE stamp(member_no NUMBER PRIMARY KEY, count NUMBER DEFAULT 0, FOREIGN KEY (member_no) REFERENCES member(member_no))
/
INSERT INTO stamp VALUES(1, 10)
/
INSERT INTO stamp VALUES(2, 10)
/
CREATE TABLE major_category(major_category_no NUMBER PRIMARY KEY, name VARCHAR(20) NOT NULL)
/
INSERT INTO major_category VALUES(1, '커피')
/
INSERT INTO major_category VALUES(2, '음료')
/
INSERT INTO major_category VALUES(3, '푸드')
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
CREATE TABLE item(item_no NUMBER PRIMARY KEY, sub_category_no NUMBER NOT NULL, name VARCHAR(30) NOT NULL, price NUMBER NOT NULL, stock NUMBER DEFAULT 0, delCheck NUMBER DEFAULT 0, FOREIGN KEY (sub_category_no) REFERENCES sub_category(sub_category_no))
/
CREATE SEQUENCE item_sequence START WITH 1 INCREMENT BY 1
/
CREATE OR REPLACE TRIGGER item_trigger 
BEFORE INSERT ON item 
FOR EACH ROW 
BEGIN 
	:NEW.item_no := item_sequence.NEXTVAL; 
END;
/
INSERT INTO item (sub_category_no, name, price, stock) VALUES (1, 'ICE아메리카노', 2000, 100)
/
INSERT INTO item (sub_category_no, name, price, stock) VALUES (1, '믹스커피', 1500, 100)
/
INSERT INTO item (sub_category_no, name, price, stock) VALUES (1, 'HOT아메리카노', 2000, 100)
/
INSERT INTO item (sub_category_no, name, price, stock) VALUES (1, '헤이즐넛아메리카노', 2500, 100)
/
INSERT INTO item (sub_category_no, name, price, stock) VALUES (1, '꿀아메리카노', 2700, 100)
/
INSERT INTO item (sub_category_no, name, price, stock) VALUES (2, '카페라뗴', 2900, 100)
/
INSERT INTO item (sub_category_no, name, price, stock) VALUES (2, '바닐라라떼', 3400, 100)
/
INSERT INTO item (sub_category_no, name, price, stock) VALUES (2, '카푸치노', 3000, 100)
/
INSERT INTO item (sub_category_no, name, price, stock) VALUES (2, '카라멜마끼아또', 3700, 100)
/
INSERT INTO item (sub_category_no, name, price, stock) VALUES (2, '카페모카', 4000, 100)
/
INSERT INTO item (sub_category_no, name, price, stock) VALUES (3, '콜드브루오리지널', 3500, 100)
/
INSERT INTO item (sub_category_no, name, price, stock) VALUES (3, '콜드브루라떼', 4000, 100)
/
INSERT INTO item (sub_category_no, name, price, stock) VALUES (4, '레몬에이드', 3500, 100)
/
INSERT INTO item (sub_category_no, name, price, stock) VALUES (4, '자몽에이드', 3500, 100)
/
INSERT INTO item (sub_category_no, name, price, stock) VALUES (4, '청포도에이드', 3500, 100)
/
INSERT INTO item (sub_category_no, name, price, stock) VALUES (4, '망고에이드', 3500, 100)
/
INSERT INTO item (sub_category_no, name, price, stock) VALUES (5, '망고요거트스무디', 4000, 100)
/
INSERT INTO item (sub_category_no, name, price, stock) VALUES (5, '딸기요거트스무디', 4000, 100)
/
INSERT INTO item (sub_category_no, name, price, stock) VALUES (5, '플레인요거트스무디', 4000, 100)
/
INSERT INTO item (sub_category_no, name, price, stock) VALUES (5, '초코스무디', 4000, 100)
/
INSERT INTO item (sub_category_no, name, price, stock) VALUES (6, '아이스티', 3000, 100)
/
INSERT INTO item (sub_category_no, name, price, stock) VALUES (6, '유자차', 3300, 100)
/
INSERT INTO item (sub_category_no, name, price, stock) VALUES (6, '캐모마일', 2500, 100)
/
INSERT INTO item (sub_category_no, name, price, stock) VALUES (6, '페퍼민트', 2500, 100)
/
INSERT INTO item (sub_category_no, name, price, stock) VALUES (7, '소금빵', 3200, 100)
/
INSERT INTO item (sub_category_no, name, price, stock) VALUES (7, '크로크무슈', 3800, 100)
/
INSERT INTO item (sub_category_no, name, price, stock) VALUES (7, '허니브레드', 4500, 100)
/
INSERT INTO item (sub_category_no, name, price, stock) VALUES (7, '초코쿠키', 2900, 100)
/
INSERT INTO item (sub_category_no, name, price, stock) VALUES (8, '치즈케이크', 3500, 100)
/
INSERT INTO item (sub_category_no, name, price, stock) VALUES (8, '초코케이크', 3500, 100)
/
INSERT INTO item (sub_category_no, name, price, stock) VALUES (8, '티라미수케이크', 3500, 100)
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
CREATE TABLE cart_detail(cart_no NUMBER, item_no NUMBER, count NUMBER NOT NULL, total_price NUMBER NOT NULL, FOREIGN KEY (cart_no) REFERENCES cart(cart_no), FOREIGN KEY (item_no) REFERENCES item(item_no), CONSTRAINT pk_cart_detail PRIMARY KEY (cart_no, item_no))
/
INSERT INTO cart_detail VALUES(1, 1, 10, 20000)
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