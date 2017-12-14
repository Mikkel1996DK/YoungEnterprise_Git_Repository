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
	   VALUES (1, 'admin@oestreskole.dk', '444555', '�stre Skole Thisted')

INSERT INTO tbl_Team(fld_TeamName, fld_SchoolID, fld_SubjectCategory, fld_Report)
	   VALUES ('TeamNavn_One', 1, 'Trade and Skills', CAST('asdf' as varbinary(max)))

INSERT INTO tbl_Team(fld_TeamName, fld_SchoolID, fld_SubjectCategory, fld_Report)
	   VALUES ('TeamNavn_Two', 2, 'Science and Technology', CAST('xysv' as varbinary(max)))

INSERT INTO tbl_Judge(fld_EventID, fld_JudgeUsername, fld_JudgePassword, fld_JudgeName)
	   VALUES (1, 'judgeOne@gmail.com', '112233', 'J�ren Hansen')

INSERT INTO tbl_Judge(fld_EventID, fld_JudgeUsername, fld_JudgePassword, fld_JudgeName)
	   VALUES (1, 'judgeTwo@gmail.com', '654321', 'Mads Petersen')

INSERT INTO tbl_Judge(fld_EventID, fld_JudgeUsername, fld_JudgePassword, fld_JudgeName)
	   VALUES (1, 'judgeThree@gmail.com', '123456', 'Hans Jensen')

INSERT INTO tbl_JudgePair(fld_JudgeIDA, fld_JudgeIDB)
	   VALUES (1, 2)
	 
INSERT INTO tbl_Question (fld_QuestionText, fld_QuestionCategori, fld_QuestionSubject, fld_QuestionModifier)
	   VALUES ('I hvilket omfang har eleverne inddraget priskalkulation? Hvor realistisk er den, og har eleverne truffet afs�tningsm�ssige beslutninger p� baggrund af priskalkulationen?', 'Report', 'Trade and Skills', 1.5)

INSERT INTO tbl_Question (fld_QuestionText, fld_QuestionCategori, fld_QuestionSubject, fld_QuestionModifier)
	   VALUES ('I hvor h�j grad argumenterer eleverne for deres valg af materialer til produktet? Hvis produktet er en serviceydelse, skal der kigges p� de produkter, som indg�r i ydelsen.', 'Report', 'Trade and Skills', 1.5)

INSERT INTO tbl_Question (fld_QuestionText, fld_QuestionCategori, fld_QuestionSubject, fld_QuestionModifier)
	   VALUES ('I hvor h�j grad evner teamet i rapporten at dokumentere overblik over elementerne i den succesfulde virksomheds etablering?', 'Interview', 'Science and Technology', 2)

INSERT INTO tbl_Question (fld_QuestionText, fld_QuestionCategori, fld_QuestionSubject, fld_QuestionModifier)
	   VALUES ('I hvor h�j grad har teamet benyttet sig af viden fra og dialog med eksterne resurser / eksternt netv�rk � f.eks. relevante virksomheder/institutioner/instanser? Hvordan har denne dialog udviklet ideen?', 'Interview', 'Science and Technology', 2)

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