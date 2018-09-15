create database quantumkey
use quantumkey
create table reg(uid int identity(1,1),uname varchar(25) primary key,pwd varchar(25),secret varchar(8),LoginDate varchar(20),logintime varchar(20))
select * from reg
drop table reg
create table recreg(uid int identity(1,1),uname varchar(25) primary key,pwd varchar(25),secret varchar(8),LoginDate varchar(20),logintime varchar(20))
select * from recreg
insert into reg values('aaa','aaaaaa',12345678,'24 February 2008','16:30:39')
drop table recreg
delete from recreg

backup database quantumkey to disk='d:\quantumkey'
restore database quantumkey from disk='d:\quantumkey'