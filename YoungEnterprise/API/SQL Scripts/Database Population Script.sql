USE DB_YoungEnterprise



GO

-- Clear all table
DELETE FROM tbl_VoteAnswer
DELETE FROM tbl_Vote
DELETE FROM tbl_Question
DELETE FROM tbl_JudgePair
DELETE FROM tbl_Judge
DELETE FROM tbl_Team
DELETE FROM tbl_School
DELETE FROM tbl_Event


-- Insert fresh records into all tables
INSERT INTO tbl_Event(fld_EventDate)
	   VALUES ('2017-11-22')

INSERT INTO tbl_School(fld_EventID, fld_SchoolUsername, fld_SchoolPassword, fld_SchoolName)
	   VALUES (1, 'administrator@bcs.dk', '123456', 'Business College Syd')

INSERT INTO tbl_School(fld_EventID, fld_SchoolUsername, fld_SchoolPassword, fld_SchoolName)
	   VALUES (1, 'admin@oestreskole.dk', '444555', 'Østre Skole Thisted')

INSERT INTO tbl_Team(fld_TeamName, fld_SchoolID, fld_SubjectCategory, fld_Report)
	   VALUES ('TeamNavn_One', 1, 'Trade & Skills', CAST('asdf' as varbinary(max)))

INSERT INTO tbl_Team(fld_TeamName, fld_SchoolID, fld_SubjectCategory, fld_Report)
	   VALUES ('TeamNavn_Two', 2, 'Science & Technology', CAST('xysv' as varbinary(max)))

INSERT INTO tbl_Judge(fld_EventID, fld_JudgeUsername, fld_JudgePassword, fld_JudgeName)
	   VALUES (1, 'judgeOne@gmail.com', '112233', 'Jøren Hansen')

INSERT INTO tbl_Judge(fld_EventID, fld_JudgeUsername, fld_JudgePassword, fld_JudgeName)
	   VALUES (1, 'judgeTwo@gmail.com', '654321', 'Mads Petersen')

INSERT INTO tbl_Judge(fld_EventID, fld_JudgeUsername, fld_JudgePassword, fld_JudgeName)
	   VALUES (1, 'judgeThreeo@gmail.com', '123456', 'Hans Jensen')

INSERT INTO tbl_JudgePair(fld_JudgeIDA, fld_JudgeIDB)
	   VALUES (1, 2)
	 
INSERT INTO tbl_Question (fld_QuestionText, fld_QuestionCategori, fld_QuestionSubject, fld_QuestionModifier)
	   VALUES ('Hvem spiller trommer?', 'Report', 'Trade and Skills', 1.5)

INSERT INTO tbl_Question (fld_QuestionText, fld_QuestionCategori, fld_QuestionSubject, fld_QuestionModifier)
	   VALUES ('Hvem var Nikola Tesla?', 'Interview', 'Science and Technology', 1)

INSERT INTO tbl_Question (fld_QuestionText, fld_QuestionCategori, fld_QuestionSubject, fld_QuestionModifier)
	   VALUES ('Hvem var Jesus?', 'Report', 'Trade and Skills', 1)

INSERT INTO tbl_Vote (fld_Points, fld_JudgePairID, fld_TeamName)
	   VALUES (2, 1, 'TeamNavn_One')

INSERT INTO tbl_Vote (fld_Points, fld_JudgePairID, fld_TeamName)
	   VALUES (3, 1, 'TeamNavn_One')

INSERT INTO tbl_Vote (fld_Points, fld_JudgePairID, fld_TeamName)
	   VALUES (1, 1, 'TeamNavn_Two')

INSERT INTO tbl_Vote (fld_Points, fld_JudgePairID, fld_TeamName)
	   VALUES (4, 1, 'TeamNavn_Two')

INSERT INTO tbl_VoteAnswer (fld_QuestionID, fld_VoteID)
	   VALUES (1, 1)

INSERT INTO tbl_VoteAnswer (fld_QuestionID, fld_VoteID)
	   VALUES (2, 2)

INSERT INTO tbl_VoteAnswer (fld_QuestionID, fld_VoteID)
	   VALUES (1, 3)

INSERT INTO tbl_VoteAnswer (fld_QuestionID, fld_VoteID)
	   VALUES (2, 4)