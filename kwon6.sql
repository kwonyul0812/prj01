DROP TABLE item PURGE
/
DROP SEQUENCE item_sequence
/
DROP TRIGGER item_trigger
/
CREATE TABLE item(item_no NUMBER PRIMARY KEY, sub_category_no NUMBER NOT NULL, name VARCHAR(30) NOT NULL, price NUMBER NOT NULL, stock NUMBER DEFAULT 0, FOREIGN KEY (sub_category_no) REFERENCES sub_category(sub_category_no))
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
INSERT INTO item (sub_category_no, name, price) VALUES (1, 'ICE아메리카노', 2000)
/
INSERT INTO item (sub_category_no, name, price) VALUES (1, '믹스커피', 1500)
/
INSERT INTO item (sub_category_no, name, price) VALUES (1, 'HOT아메리카노', 2000)
/
INSERT INTO item (sub_category_no, name, price) VALUES (1, '헤이즐넛아메리카노', 2500)
/
INSERT INTO item (sub_category_no, name, price) VALUES (1, '꿀아메리카노', 2700)
/
INSERT INTO item (sub_category_no, name, price) VALUES (2, '카페라뗴', 2900)
/
INSERT INTO item (sub_category_no, name, price) VALUES (2, '바닐라라떼', 3400)
/
INSERT INTO item (sub_category_no, name, price) VALUES (2, '카푸치노', 3000)
/
INSERT INTO item (sub_category_no, name, price) VALUES (2, '카라멜마끼아또', 3700)
/
INSERT INTO item (sub_category_no, name, price) VALUES (2, '카페모카', 4000)
/
INSERT INTO item (sub_category_no, name, price) VALUES (3, '콜드브루오리지널', 3500)
/
INSERT INTO item (sub_category_no, name, price) VALUES (3, '콜드브루라떼', 4000)
/
INSERT INTO item (sub_category_no, name, price) VALUES (4, '레몬에이드', 3500)
/
INSERT INTO item (sub_category_no, name, price) VALUES (4, '자몽에이드', 3500)
/
INSERT INTO item (sub_category_no, name, price) VALUES (4, '청포도에이드', 3500)
/
INSERT INTO item (sub_category_no, name, price) VALUES (4, '망고에이드', 3500)
/
INSERT INTO item (sub_category_no, name, price) VALUES (5, '망고요거트스무디', 4000)
/
INSERT INTO item (sub_category_no, name, price) VALUES (5, '딸기요거트스무디', 4000)
/
INSERT INTO item (sub_category_no, name, price) VALUES (5, '플레인요거트스무디', 4000)
/
INSERT INTO item (sub_category_no, name, price) VALUES (5, '초코스무디', 4000)
/
INSERT INTO item (sub_category_no, name, price) VALUES (6, '아이스티', 3000)
/
INSERT INTO item (sub_category_no, name, price) VALUES (6, '유자차', 3300)
/
INSERT INTO item (sub_category_no, name, price) VALUES (6, '캐모마일', 2500)
/
INSERT INTO item (sub_category_no, name, price) VALUES (6, '페퍼민트', 2500)
/
INSERT INTO item (sub_category_no, name, price) VALUES (7, '소금빵', 3200)
/
INSERT INTO item (sub_category_no, name, price) VALUES (7, '크로크무슈', 3800)
/
INSERT INTO item (sub_category_no, name, price) VALUES (7, '허니브레드', 4500)
/
INSERT INTO item (sub_category_no, name, price) VALUES (7, '초코쿠키', 2900)
/
INSERT INTO item (sub_category_no, name, price) VALUES (8, '치즈케이크', 3500)
/
INSERT INTO item (sub_category_no, name, price) VALUES (8, '초코케이크', 3500)
/
INSERT INTO item (sub_category_no, name, price) VALUES (8, '티라미수케이크', 3500)
/