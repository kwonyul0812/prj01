DROP TABLE stamp PURGE
/
CREATE TABLE stamp(member_no NUMBER PRIMARY KEY, count NUMBER DEFAULT 0, FOREIGN KEY (member_no) REFERENCES member(member_no))
/
INSERT INTO stamp VALUES(1, 10)
/
INSERT INTO stamp VALUES(2, 10)
/