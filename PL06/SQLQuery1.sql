create table course(
	id int identity primary key,
	name nvarchar(150) not null
);

create table student(
	number int primary key,
	name nvarchar(200) not null,
	courseId int references course(id)
);