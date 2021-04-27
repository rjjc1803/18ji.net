CREATE DATABASE LoveStudy

CREATE TABLE T_User--�û���
(
	[UserID] INT IDENTITY(54321,1),--�˺� �������У��Ǳ�ʶ����ʶ���ӡ�������Ϊ1	
	Name VARCHAR(50) ,--����	
	PassWord INT NOT NULL,--����
	WorkID INT NOT NULL,--ѧ�Ż��߹���
	Gender CHAR(2) NOT  NULL,--�Ա�
	SchName VARCHAR(50) ,--ѧУ����
	EMail VARCHAR(20) NOT NULL,--��������
	Profession INT  NOT NULL,--ְҵ��101Ϊѧ����202Ϊ��ʦ
	TestqueID  INT,--�Ծ���
	ClassID  INT,--�༶���
	PRIMARY KEY([UserID]),--����Լ��
)

CREATE TABLE  Class   --�༶��
(
	[ClassID] INT IDENTITY(20013,2),--	���
	Name VARCHAR(50) ,--����
	SchName VARCHAR(50) ,--ѧУ����
	TeacherID INT NOT NULL,	--	
	Content VARCHAR(100),--�༶���
	PRIMARY KEY([ClassID]),--����Լ��	
)

CREATE TABLE  Subject--ѧ�Ʊ�
(
	[SubjectID] INT IDENTITY(3001,3),--	���
	Name VARCHAR(50) ,
	PRIMARY KEY([SubjectID]),--����Լ��	
)

CREATE TABLE  Topic--����
(
	[TopicID] INT IDENTITY(4001,4),--	���	
	Name VARCHAR(50),
	Category VARCHAR(50),
	UserID INT,
	PRIMARY KEY([TopicID]),--����Լ��	
)

CREATE TABLE  Choice--ѡ�����
(
	[ChoiceID] INT IDENTITY(5001,2),--	���	
	Name VARCHAR(50),--��Ŀ
	Fraction INT,--����
	Answer varchar(50),
	Content varchar(500),--����	
	Topic INT ,--����� ���Ϲ���
	PRIMARY KEY([ChoiceID]),--����Լ��	
)

CREATE TABLE  MoreChoice--��ѡ���
(
   [MoreChoiceID] INT IDENTITY(5000,2),--	���	
    Name VARCHAR(5000),--��Ŀ
	Fraction INT,--����
	Answer varchar(1000),
	Content varchar(5000),--����	
	Topic INT ,--����� ���Ϲ���
	PRIMARY KEY([MoreChoiceID]),--����Լ��		
)

CREATE TABLE  Judge--�ж����
(
	[JudgeID] INT IDENTITY(1000,2),--	���	
	Name VARCHAR(500),
    Fraction INT,--����
	Answer VARCHAR(50),--1Ϊ��2Ϊ��
	Topic INT ,--����� ���Ϲ���	
	PRIMARY KEY([JudgeID]),--����Լ��	
)

CREATE TABLE  QueAnswer--�ʴ����
(
	[QueAnswerID] INT IDENTITY(1001,2),--	���	
	Name VARCHAR(1000),
    Fraction INT,--����
	Answer varchar(5000),--
	Topic INT ,--����� ���Ϲ���
	PRIMARY KEY([QueAnswerID]),--����Լ��	
)

CREATE TABLE  Exam--
(
	[ExamID] INT IDENTITY(20001,1),--	���	
	TestID INT ,--�Ծ���
	QuestionID INT, --��Ŀ���
	PRIMARY KEY([ExamID]),--����Լ��	
)

CREATE TABLE  Test--�Ծ��
(
	[TestID] INT IDENTITY(7001,1),--	���	
    Name VARCHAR(50) ,--�Ծ���	
	ObjNumber INT ,--�͹������
	SubNumber INT,--������
	TestStatus VARCHAR(20)  ,--�Ծ�״̬101δ����202����303������404���Խ���
	Score  INT,--�ܷ�
	UserID INT,--�Ծ�ӵ����
	PRIMARY KEY([TestID]),--����Լ��	
)

CREATE TABLE  StuTest--
(
	[StuTestID] INT IDENTITY(10001,1),--	���	
	TestID INT ,--�Ծ���
	ClassID INT, --�༶���
	StuID INT,--ѧ�����
	PRIMARY KEY([StuTestID]),--����Լ��	
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





