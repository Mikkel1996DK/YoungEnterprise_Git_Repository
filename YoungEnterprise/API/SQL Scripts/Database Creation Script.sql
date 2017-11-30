
use master

-- Create Database

IF DB_ID('DB_YoungEnterprise') IS NOT NULL
	DROP DATABASE DB_YoungEnterprise

CREATE DATABASE DB_YoungEnterprise
GO

USE DB_YoungEnterprise
GO

-- Create Tables 

IF Object_ID('tbl_Event') IS NOT NULL
	DROP TABLE tbl_Event
CREATE TABLE tbl_Event (fld_EventID INT IDENTITY(1,1) PRIMARY KEY,
						fld_EventDate DATE NOT NULL)

IF Object_ID('tbl_School') IS NOT NULL
	DROP TABLE tbl_School
CREATE TABLE tbl_School (fld_EventID INT FOREIGN KEY REFERENCES tbl_Event(fld_EventID) NOT NULL,
						 fld_SchoolID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
					     fld_SchoolUsername VARCHAR(40) NOT NULL,
						 fld_SchoolPassword CHAR(64) NOT NULL, -- Hashed with SHA-256
						 fld_SchoolName VARCHAR(50) NOT NULL)

IF Object_ID('tbl_Team') IS NOT NULL
	DROP TABLE tbl_Team
CREATE TABLE tbl_Team (fld_TeamName VARCHAR(30) PRIMARY KEY, 
					   fld_EventID INT FOREIGN KEY REFERENCES tbl_Event(fld_EventID) NOT NULL,
					   fld_SchoolID INT FOREIGN KEY REFERENCES tbl_School(fld_SchoolID) NOT NULL,
					   fld_SubjectCategory VARCHAR(30) NOT NULL,
					   fld_Report VARBINARY(MAX) NOT NULL)

IF Object_ID('tbl_Judge') IS NOT NULL
	DROP TABLE tbl_Judge
CREATE TABLE tbl_Judge (fld_JudgeID INT IDENTITY(1,1) PRIMARY KEY,
					    fld_EventID INT FOREIGN KEY REFERENCES tbl_Event(fld_EventID) NOT NULL,
						fld_JudgeUsername VARCHAR(40) NOT NULL,
						fld_JudgePassword CHAR(64) NOT NULL, -- Hashed with SHA-256
						fld_JudgeName VARCHAR(100) NOT NULL)

IF Object_ID('tbl_JudgePair') IS NOT NULL
	DROP TABLE tbl_JudgePair
CREATE TABLE tbl_JudgePair (fld_JudgePairID INT IDENTITY(1,1) PRIMARY KEY,
                            fld_JudgeIDA INT FOREIGN KEY REFERENCES tbl_Judge(fld_JudgeID) NOT NULL, 
                            fld_JudgeIDB INT FOREIGN KEY REFERENCES tbl_Judge(fld_JudgeID) NOT NULL)

IF Object_ID('tbl_Question') IS NOT NULL
	DROP TABLE tbl_Question
CREATE TABLE tbl_Question (fld_QuestionID INT IDENTITY(1,1)PRIMARY KEY, 
                           fld_QuestionText VARCHAR(260) NOT NULL,
						   fld_QuestionCategori VARCHAR(30) NOT NULL,
						   fld_QuestionModifier FLOAT NOT NULL)

IF Object_ID('tbl_Vote') IS NOT NULL
	DROP TABLE tbl_Vote
CREATE TABLE tbl_Vote(fld_VoteID INT IDENTITY(1,1) PRIMARY KEY,
					  fld_Points INT NOT NULL,
                      fld_JudgePairID INT FOREIGN KEY REFERENCES tbl_JudgePair(fld_JudgePairID) NOT NULL,
                      fld_TeamName VARCHAR(30) FOREIGN KEY REFERENCES tbl_Team(fld_TeamName) NOT NULL)

IF Object_ID('tbl_VoteAnswer') IS NOT NULL
	DROP TABLE tbl_VoteAnswer
CREATE TABLE tbl_VoteAnswer(fld_VoteAnswerID INT IDENTITY(1,1) PRIMARY KEY,
						      fld_QuestionID INT FOREIGN KEY REFERENCES tbl_Question(fld_QuestionID) NOT NULL,
							  fld_VoteID INT FOREIGN KEY REFERENCES tbl_Vote(fld_VoteID) NOT NULL)