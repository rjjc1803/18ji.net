CREATE DATABASE LoveStudy

CREATE TABLE T_User--用户表
(
	[UserID] INT IDENTITY(54321,1),--账号 自增长列，是标识，标识种子、增量均为1	
	Name VARCHAR(50) ,--姓名	
	PassWord INT NOT NULL,--密码
	WorkID INT NOT NULL,--学号或者工号
	Gender CHAR(2) NOT  NULL,--性别
	SchName VARCHAR(50) ,--学校名称
	EMail VARCHAR(20) NOT NULL,--电子邮箱
	Profession INT  NOT NULL,--职业：101为学生，202为教师
	TestqueID  INT,--试卷编号
	ClassID  INT,--班级编号
	PRIMARY KEY([UserID]),--主键约束
)

CREATE TABLE  Class   --班级表
(
	[ClassID] INT IDENTITY(20013,2),--	编号
	Name VARCHAR(50) ,--名称
	SchName VARCHAR(50) ,--学校名称
	TeacherID INT NOT NULL,	--	
	Content VARCHAR(100),--班级简介
	PRIMARY KEY([ClassID]),--主键约束	
)

CREATE TABLE  Subject--学科表
(
	[SubjectID] INT IDENTITY(3001,3),--	编号
	Name VARCHAR(50) ,
	PRIMARY KEY([SubjectID]),--主键约束	
)

CREATE TABLE  Topic--题库表
(
	[TopicID] INT IDENTITY(4001,4),--	编号	
	Name VARCHAR(50),
	Category VARCHAR(50),
	UserID INT,
	PRIMARY KEY([TopicID]),--主键约束	
)

CREATE TABLE  Choice--选择题表
(
	[ChoiceID] INT IDENTITY(5001,2),--	编号	
	Name VARCHAR(50),--题目
	Fraction INT,--分数
	Answer varchar(50),
	Content varchar(500),--内容	
	Topic INT ,--题库编号 向上关联
	PRIMARY KEY([ChoiceID]),--主键约束	
)

CREATE TABLE  MoreChoice--多选题表
(
   [MoreChoiceID] INT IDENTITY(5000,2),--	编号	
    Name VARCHAR(5000),--题目
	Fraction INT,--分数
	Answer varchar(1000),
	Content varchar(5000),--内容	
	Topic INT ,--题库编号 向上关联
	PRIMARY KEY([MoreChoiceID]),--主键约束		
)

CREATE TABLE  Judge--判断题表
(
	[JudgeID] INT IDENTITY(1000,2),--	编号	
	Name VARCHAR(500),
    Fraction INT,--分数
	Answer VARCHAR(50),--1为对2为错
	Topic INT ,--题库编号 向上关联	
	PRIMARY KEY([JudgeID]),--主键约束	
)

CREATE TABLE  QueAnswer--问答题表
(
	[QueAnswerID] INT IDENTITY(1001,2),--	编号	
	Name VARCHAR(1000),
    Fraction INT,--分数
	Answer varchar(5000),--
	Topic INT ,--题库编号 向上关联
	PRIMARY KEY([QueAnswerID]),--主键约束	
)

CREATE TABLE  Exam--
(
	[ExamID] INT IDENTITY(20001,1),--	编号	
	TestID INT ,--试卷编号
	QuestionID INT, --题目编号
	PRIMARY KEY([ExamID]),--主键约束	
)

CREATE TABLE  Test--试卷表
(
	[TestID] INT IDENTITY(7001,1),--	编号	
    Name VARCHAR(50) ,--试卷名	
	ObjNumber INT ,--客观题分数
	SubNumber INT,--主观题
	TestStatus VARCHAR(20)  ,--试卷状态101未发布202发布303考试中404考试结束
	Score  INT,--总分
	UserID INT,--试卷拥有者
	PRIMARY KEY([TestID]),--主键约束	
)

CREATE TABLE  StuTest--
(
	[StuTestID] INT IDENTITY(10001,1),--	编号	
	TestID INT ,--试卷编号
	ClassID INT, --班级编号
	StuID INT,--学生编号
	PRIMARY KEY([StuTestID]),--主键约束	
)

DELETE FROM dbo.T_User  WHERE UserID=54
UPDATE dbo.T_User SET PassWord=123 WHERE UserID=54325

  

SELECT * FROM dbo.Topic
SELECT * FROM dbo.Choice
SELECT * FROM dbo.Judge
SELECT * FROM dbo.QueAnswer
SELECT * FROM dbo.MoreChoice
SELECT * FROM dbo.Exam
SELECT * FROM dbo.StuTest
SELECT * FROM dbo.Test
SELECT * FROM dbo.Class
SELECT * FROM dbo.T_User





