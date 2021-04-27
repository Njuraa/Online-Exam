CREATE Database [examMaha]
GO
USE [examMaha]
GO
/****** Object:  StoredProcedure [dbo].[CRUDAnswers]    Script Date: 01/19/2020 17:10:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[CRUDAnswers]
@Action CHAR(1),
@QuestionId bigint=null,
@AnswerId bigint = NULL,
@Answer VARCHAR(250) = NULL,
@IsRight bit = NULL,
@LoggedInUser BIGINT=null
AS
BEGIN
	IF(@Action = 'S')
	BEGIN
	print 'S'
		select Answer,IsRight,A.QuestionId,QM.Question,A.IsActive,A.CreatedBy,
		A.CreatedDate,A.UpdatedBy,A.UpdatedDate FROM Answer A
		JOIN QuestionMaster QM ON QM.QuestionId=A.QuestionId
		WHERE AnswerId=@AnswerId
	END
	ELSE IF(@Action = 'I')
	BEGIN
		if  exists(SELECT NULL FROM Answer where Answer=@Answer AND QuestionId=@QuestionId)
		BEGIN
			SELECT 'This answer already exists.' AS CRUDStatus
		END
		ELSE
		BEGIN
			INSERT INTO Answer(Answer,IsRight,QuestionId,IsActive,CreatedBy,CreatedDate)
			VALUES(@Answer,@IsRight,@QuestionId,1,@LoggedInUser,GETDATE());

			IF(@@ROWCOUNT > 0)
			BEGIN
				SELECT 'success' AS CRUDStatus
			END
		END
	END
	ELSE IF(@Action = 'U')
	BEGIN
		UPDATE Answer
		SET Answer = @Answer,
			QuestionId = @QuestionId,
			IsRight = @IsRight,
			UpdatedBy = @LoggedInUser,
			UpdatedDate = GETDATE()
		WHERE AnswerId=@AnswerId

		IF(@@ROWCOUNT > 0)
		BEGIN
			SELECT 'success' AS CRUDStatus
		END
	END
	ELSE IF(@Action = 'D')
	BEGIN
		Update Answer SET IsActive=0,UpdatedBy = @LoggedInUser,UpdatedDate = GETDATE() Where AnswerId=@AnswerId
		SELECT 'One answer removed successfully!!!' AS CRUDStatus
	END
	IF(@Action = 'L')
	BEGIN
		select AnswerId,Answer,IsRight,A.QuestionId,QM.Question,A.IsActive,A.CreatedBy,
		A.CreatedDate,A.UpdatedBy,A.UpdatedDate FROM Answer A
		JOIN QuestionMaster QM ON A.QuestionId=QM.QuestionId
		WHERE A.IsActive=1
	END
END

GO

/****** Object:  StoredProcedure [dbo].[CRUDAnswerType]    Script Date: 01/19/2020 17:10:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[CRUDAnswerType]
@Action CHAR(1),
@AnswerTypeId int=null,
@AnswerType VARCHAR(300) = NULL,
@Description VARCHAR(300) = NULL,
@LoggedInUser BIGINT=null
AS
BEGIN
	IF(@Action = 'S')
	BEGIN
	print 'S'
		select AnswerTypeId,AnswerType,Description,IsActive,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate FROM AnswerType 
		WHERE AnswerTypeId=@AnswerTypeId
	END
	ELSE IF(@Action = 'I')
	BEGIN
		if  exists(SELECT NULL FROM AnswerType where AnswerType=@AnswerType)
		BEGIN
			SELECT 'This answer type already exists.' AS CRUDStatus
		END
		ELSE
		BEGIN
			INSERT INTO AnswerType(AnswerType,Description,IsActive,CreatedBy,CreatedDate)
			VALUES(@AnswerType,@Description,1,@LoggedInUser,GETDATE());

			IF(@@ROWCOUNT > 0)
			BEGIN
				SELECT 'success' AS CRUDStatus
			END
		END
	END
	ELSE IF(@Action = 'U')
	BEGIN
		UPDATE AnswerType
		SET AnswerType = @AnswerType,
			Description = @Description,
			UpdatedBy = @LoggedInUser,
			UpdatedDate = GETDATE()
		WHERE AnswerTypeId=@AnswerTypeId

		IF(@@ROWCOUNT > 0)
		BEGIN
			SELECT 'success' AS CRUDStatus
		END
	END
	ELSE IF(@Action = 'D')
	BEGIN
		Update AnswerType SET IsActive=0,UpdatedBy = @LoggedInUser,UpdatedDate = GETDATE() Where AnswerTypeId=@AnswerTypeId
		SELECT 'One answer type removed successfully!!!' AS CRUDStatus
	END
	ELSE IF(@Action = 'L')
	BEGIN
	print 'S'
		select AnswerTypeId,AnswerType,Description,IsActive,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate FROM AnswerType  
		WHERE IsActive=1
	END
END

GO

/****** Object:  StoredProcedure [dbo].[CRUDCourses]    Script Date: 01/19/2020 17:10:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[CRUDCourses]
@Action CHAR(1),
@CourseId int = NULL,
@CourseName VARCHAR(100) = NULL,
@Description VARCHAR(300) = NULL,
@Eligibility VARCHAR(200) = NULL,
@LoggedInUser BIGINT=null
AS
BEGIN
	IF(@Action = 'S')
	BEGIN
	print 'S'
		select CourseId,CourseName,Description,Eligibility,IsActive,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate FROM CourseMaster 
		WHERE CourseId=@CourseId
	END
	ELSE IF(@Action = 'I')
	BEGIN
		if  exists(SELECT NULL FROM CourseMaster where CourseName=@CourseName)
		BEGIN
			SELECT 'This Course already exists.' AS CRUDStatus
		END
		ELSE
		BEGIN
			INSERT INTO CourseMaster(CourseName,Description,Eligibility,IsActive,CreatedBy,CreatedDate)
			VALUES(@CourseName,@Description,@Eligibility,1,@LoggedInUser,GETDATE());

			IF(@@ROWCOUNT > 0)
			BEGIN
				SELECT 'success' AS CRUDStatus
			END
		END
	END
	ELSE IF(@Action = 'U')
	BEGIN
		UPDATE CourseMaster
		SET CourseName = @CourseName,
			Description = @Description,
			Eligibility = @Eligibility,
			UpdatedBy = @LoggedInUser,
			UpdatedDate = GETDATE()
		WHERE CourseId=@CourseId

		IF(@@ROWCOUNT > 0)
		BEGIN
			SELECT 'success' AS CRUDStatus
		END
	END
	ELSE IF(@Action = 'D')
	BEGIN
		Update CourseMaster SET IsActive=0 Where CourseId=@CourseId
		SELECT 'One Course removed successfully!!!' AS CRUDStatus
	END
	IF(@Action = 'L')
	BEGIN
		select CourseId,CourseName,Description,Eligibility,IsActive,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate FROM CourseMaster 
		WHERE IsActive=1
	END
END

GO

/****** Object:  StoredProcedure [dbo].[CRUDExams]    Script Date: 01/19/2020 17:10:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[CRUDExams]  
@Action CHAR(1),  
@StudentExamId bigint=null,  
@StudentId BIGINT = NULL,  
@CourseId int = NULL,  
@Description VARCHAR(300) = NULL,  
@ExamTime bigint = NULL,  
@ExamDate date = NULL,  
@Fees decimal(10,2) = NULL,  
@IsExpired bit = NULL,  
@ExamResult varchar(50) = NULL,  
@IsAppeared bit = NULL,  
@LoggedInUser bigint = NULL  
AS  
BEGIN  
 IF(@Action = 'S')  
 BEGIN  
  SELECT StudentExamId,StudentId,SE.CourseId,SE.Description,ExamTimeId,ExamDate,SE.IsActive,IsExpired,ExamResult,IsAppeared,  
  SE.Fees,SE.CreatedBy,SE.CreatedDate,SE.UpdatedBy,SE.UpdatedDate FROM StudentExams SE  
  JOIN UserMaster UM ON UM.UserId=SE.StudentId AND UM.UserTypeId=3  
  WHERE SE.IsActive = 1 AND StudentExamId=@StudentExamId  
 END  
 ELSE IF(@Action = 'I')  
 BEGIN  
  IF exists(select null from StudentExams WHERE Convert(date,ExamDate)=convert(date,@ExamDate) and CourseId=@CourseId)  
  BEGIN  
   SELECT 'You have already registered for this exam ' AS CRUDStatus  
  END  
  ELSE  
  BEGIN  
   INSERT INTO StudentExams(StudentId,CourseId,[Description],ExamTimeId,ExamDate,IsExpired,  
   ExamResult,IsAppeared,Fees,IsActive,CreatedBy,CreatedDate)  
   VALUES(@StudentId,@CourseId,@Description,@ExamTime,@ExamDate,0,@ExamResult,0,@Fees,1,@LoggedInUser,GETDATE())  
     
   IF(@@ROWCOUNT > 0)  
   BEGIN  
    SELECT 'success' AS CRUDStatus  
   END  
  END  
 END  
 ELSE IF(@Action = 'U')  
 BEGIN  
  UPDATE StudentExams  
  SET StudentId = @StudentId,  
   CourseId = @CourseId,  
   ExamTimeId = @ExamTime,  
   [Description] = @Description,  
   ExamDate = @ExamDate,  
   Fees=@Fees,  
   UpdatedBy = @LoggedInUser,  
   UpdatedDate = GETDATE()  
  WHERE StudentId = @StudentId  
  IF(@@ROWCOUNT > 0)  
  BEGIN  
   SELECT 'success' AS CRUDStatus  
  END  
 END  
 ELSE IF(@Action='L')  
 BEGIN  
 
	;with RESULT as 
(
	select Sum(case when AM.IsRight = 1 then QM.Marks else 0 end) Marks,QA.StudentExamId  from QuestionAnswer  QA
	join Answer AM ON AM.AnswerID=QA.AnswerId
	JOIN QuestionMaster QM ON QM.QuestionId=AM.QuestionId
	WHERE  QA.StudentId=@StudentId
	group By QA.StudentExamId
),
TotalMarks AS
(
	select Sum(QM.Marks) AS Total,SE.StudentExamId,RE.Marks FROM  QuestionMaster QM
	JOIN StudentExams SE ON SE.CourseId=QM.CourseId
	LEFT JOIN RESULT RE ON RE.StudentExamId=SE.StudentExamID
	WHERE  SE.StudentId=@StudentId
	Group by SE.StudentExamId,RE.Marks
),
  EXAM as
(
SELECT SE.StudentExamId,(UM.FirstName+' '+ UM.LastName) StudentName,StudentId,SE.CourseId,CM.CourseName,SE.Description,ET.ExamTime,SE.ExamTimeId ,
Convert(VARCHAR,ExamDate) AS ExamDate,SE.IsActive,ExamResult,isnull(IsAppeared,0) IsAppeared,Total, Marks,
Convert(bit,case When ExamDate<convert(date,getdate()) then 1 else 0 end) AS IsExpired, 
SE.Fees,SE.CreatedBy,SE.CreatedDate,SE.UpdatedBy,SE.UpdatedDate FROM StudentExams SE  
JOIN UserMaster UM ON UM.UserId=SE.StudentId AND UM.UserTypeId=3  
JOIN CourseMaster CM ON CM.CourseId=SE.CourseId  
JOIN ExamTimes ET ON ET.ExamTimesId=SE.ExamTimeId  
LEFT JOIN TotalMarks RE ON RE.StudentExamId=SE.StudentExamId
WHERE SE.IsActive = 1 AND StudentId=@StudentId 
)
select * from EXAM
  --SELECT StudentExamId,(UM.FirstName+' '+ UM.LastName) StudentName,StudentId,SE.CourseId,CM.CourseName,SE.Description,ET.ExamTime,SE.ExamTimeId ,
  --Convert(VARCHAR,ExamDate) AS ExamDate,SE.IsActive,ExamResult,IsAppeared, 
  --Convert(bit,case When ExamDate<convert(date,getdate()) then 1 else 0 end) AS IsExpired, 
  --SE.Fees,SE.CreatedBy,SE.CreatedDate,SE.UpdatedBy,SE.UpdatedDate FROM StudentExams SE  
  --JOIN UserMaster UM ON UM.UserId=SE.StudentId AND UM.UserTypeId=3  
  --JOIN CourseMaster CM ON CM.CourseId=SE.CourseId  
  --JOIN ExamTimes ET ON ET.ExamTimesId=SE.ExamTimeId  
  --WHERE SE.IsActive = 1 AND StudentId=@StudentId 
  --Order by  ExamDate desc
 END  
END
GO

/****** Object:  StoredProcedure [dbo].[CRUDFees]    Script Date: 01/19/2020 17:10:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[CRUDFees]
@Action CHAR(1),
@FeesId int=null,
@CourseId int = NULL,
@Offer VARCHAR(200) = NULL,
@Description VARCHAR(300) = NULL,
@Amount decimal(10,2),
@SGST decimal(10,2),
@CGST decimal(10,2),
@LoggedInUser BIGINT=null
AS
BEGIN
	IF(@Action = 'S')
	BEGIN
	print 'S'
		IF(@CourseId>0)
		BEGIN
			select FeesId,FM.CourseId,FM.Description,Offer,Amount,SGST,CGST,FM.IsActive,FM.CreatedBy,FM.CreatedDate,
			FM.UpdatedBy,FM.UpdatedDate,CM.CourseName FROM FeesMaster FM JOIN CourseMaster CM ON CM.CourseID=FM.CourseId 
			WHERE FM.IsActive=1 AND FM.CourseId=@CourseId
		END
		ELSE
		BEGIN
			select FeesId,FM.CourseId,FM.Description,Offer,Amount,SGST,CGST,FM.IsActive,FM.CreatedBy,FM.CreatedDate,
			FM.UpdatedBy,FM.UpdatedDate,CM.CourseName FROM FeesMaster FM JOIN CourseMaster CM ON CM.CourseID=FM.CourseId 
			WHERE FeesId=@FeesId AND FM.IsActive=1
		END
	END
	ELSE IF(@Action = 'I')
	BEGIN
		if  exists(SELECT NULL FROM FeesMaster where CourseId=@CourseId AND IsActive=1)
		BEGIN
			SELECT 'This Course Fees details already exists.' AS CRUDStatus
		END
		ELSE
		BEGIN
			INSERT INTO FeesMaster(CourseId,Description,Offer,Amount,SGST,CGST,IsActive,CreatedBy,CreatedDate)
			VALUES(@CourseId,@Description,@Offer,@Amount,@SGST,@CGST,1,@LoggedInUser,GETDATE());

			IF(@@ROWCOUNT > 0)
			BEGIN
				SELECT 'success' AS CRUDStatus
			END
		END
	END
	ELSE IF(@Action = 'U')
	BEGIN
		UPDATE FeesMaster
		SET CourseId = @CourseId,
			Description = @Description,
			Offer = @Offer,
			Amount=@Amount,
			SGST=@SGST,
			CGST=@CGST,
			UpdatedBy = @LoggedInUser,
			UpdatedDate = GETDATE()
		WHERE FeesId=@FeesId

		IF(@@ROWCOUNT > 0)
		BEGIN
			SELECT 'success' AS CRUDStatus
		END
	END
	ELSE IF(@Action = 'D')
	BEGIN
		Update FeesMaster SET IsActive=0 Where FeesId=@FeesId
		SELECT 'One Course Fees details removed successfully!!!' AS CRUDStatus
	END
	ELSE IF(@Action = 'L')
	BEGIN
	print 'S'
		select FeesId,FM.CourseId,FM.Description,Offer,Amount,SGST,CGST,FM.IsActive,FM.CreatedBy,FM.CreatedDate,
		FM.UpdatedBy,FM.UpdatedDate,CM.CourseName FROM FeesMaster FM 
		JOIN CourseMaster CM ON CM.CourseID=FM.CourseId
		WHERE FM.IsActive=1
	END
END

GO

/****** Object:  StoredProcedure [dbo].[CRUDQuestions]    Script Date: 01/19/2020 17:10:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[CRUDQuestions]
@Action CHAR(1),
@QuestionId bigint=null,
@CourseId int = NULL,
@Question VARCHAR(250) = NULL,
@AnswerTypeId int = NULL,
@Marks VARCHAR(200) = NULL,
@LoggedInUser BIGINT=null
AS
BEGIN
	IF(@Action = 'S')
	BEGIN
	print 'S'
		select QuestionId,Question,QM.CourseId,CM.CourseName,AT.AnswerType,QM.AnswerTypeId,Marks,QM.IsActive,QM.CreatedBy,
		QM.CreatedDate,QM.UpdatedBy,QM.UpdatedDate FROM QuestionMaster QM
		JOIN CourseMaster CM ON CM.CourseId=QM.CourseId
		JOIN AnswerType AT ON AT.AnswerTypeId=QM.AnswerTypeId
		WHERE  QuestionID=@QuestionId
	END
	ELSE IF(@Action = 'I')
	BEGIN
		if  exists(SELECT NULL FROM QuestionMaster where Question=@Question AND CourseID=@CourseId AND IsActive=1)
		BEGIN
			SELECT 'This Course already exists.' AS CRUDStatus
		END
		ELSE
		BEGIN
			INSERT INTO QuestionMaster(CourseId,Question,AnswerTypeId,Marks,IsActive,CreatedBy,CreatedDate)
			VALUES(@CourseId,@Question,@AnswerTypeId,@Marks,1,@LoggedInUser,GETDATE());

			IF(@@ROWCOUNT > 0)
			BEGIN
				SELECT 'success' AS CRUDStatus
			END
		END
	END
	ELSE IF(@Action = 'U')
	BEGIN
		UPDATE QuestionMaster
		SET CourseId = @CourseId,
			Question = @Question,
			AnswerTypeId = @AnswerTypeId,
			Marks=@Marks,
			UpdatedBy = @LoggedInUser,
			UpdatedDate = GETDATE()
		WHERE QuestionId=@QuestionId

		IF(@@ROWCOUNT > 0)
		BEGIN
			SELECT 'success' AS CRUDStatus
		END
	END
	ELSE IF(@Action = 'D')
	BEGIN
		Update QuestionMaster SET IsActive=0,UpdatedBy = @LoggedInUser,UpdatedDate = GETDATE() Where QuestionId=@QuestionId
		SELECT 'One Course removed successfully!!!' AS CRUDStatus
	END
	IF(@Action = 'L')
	BEGIN
		select QuestionId,Question,QM.CourseId,CM.CourseName,AT.AnswerType,QM.AnswerTypeId,Marks,QM.IsActive,QM.CreatedBy,
		QM.CreatedDate,QM.UpdatedBy,QM.UpdatedDate FROM QuestionMaster QM
		JOIN CourseMaster CM ON CM.CourseId=QM.CourseId
		JOIN AnswerType AT ON AT.AnswerTypeId=QM.AnswerTypeId
		WHERE QM.IsActive=1
	END
	ELSE IF(@Action='Q')
	BEGIN
		select QuestionId,Question,QM.CourseId,CM.CourseName,AT.AnswerType,QM.AnswerTypeId,Marks,QM.IsActive,QM.CreatedBy,
		QM.CreatedDate,QM.UpdatedBy,QM.UpdatedDate FROM QuestionMaster QM
		JOIN CourseMaster CM ON CM.CourseId=QM.CourseId
		JOIN AnswerType AT ON AT.AnswerTypeId=QM.AnswerTypeId
		WHERE QM.IsActive=1 AND QM.CourseId=@CourseId
	END
END

GO

/****** Object:  StoredProcedure [dbo].[CRUDStudentDetails]    Script Date: 01/19/2020 17:10:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[CRUDStudentDetails]
@Action CHAR(1),
@StudentId BIGINT = NULL,
@StudentUniqueId VARCHAR(100) = NULL,
@Password VARCHAR(100) = NULL,
@FirstName VARCHAR(100) = NULL,
@LastName VARCHAR(100) = NULL,
@MobileNo VARCHAR(20) = NULL,
@EmailId VARCHAR(50) = NULL,
@UserTypeId INT = NULL,
@IsActive CHAR(1) = NULL,
@UserId INT = NULL
AS
BEGIN
	IF(@Action = 'S')
	BEGIN
		SELECT StudentId, StudentUniqueId, FirstName, LastName, MobileNo, UserTypeId, UserTypeId 
		FROM StudentDetails 
		WHERE IsActive = @IsActive
	END
	ELSE IF(@Action = 'I')
	BEGIN
		INSERT INTO StudentDetails(StudentUniqueId,[Password],FirstName,LastName,MobileNo,EmailId,UserTypeId,IsActive,CreatedBy,CreatedDate)
		VALUES(@StudentUniqueId,@Password,@FirstName,@LastName,@MobileNo,@EmailId,@UserTypeId,@IsActive,@UserId,GETDATE())
	END
	ELSE IF(@Action = 'U')
	BEGIN
		UPDATE StudentDetails
		SET [Password] = @Password,
			FirstName = @FirstName,
			LastName = @LastName,
			MobileNo = @MobileNo,
			EmailId = @EmailId,
			IsActive = @IsActive,
			UpdatedBy = @UserId,
			UpdatedDate = GETDATE()
		WHERE StudentId = @StudentId
	END
END
GO

/****** Object:  StoredProcedure [dbo].[CRUDUsers]    Script Date: 01/19/2020 17:10:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[CRUDUsers]
@Action CHAR(1),
@UserPassword VARCHAR(100) = NULL,
@FirstName VARCHAR(100) = NULL,
@LastName VARCHAR(100) = NULL,
@MobileNo VARCHAR(20) = NULL,
@EmailId VARCHAR(50) = NULL,	
@UserTypeId INT = NULL,
@ProfilePicPath VARCHAR(100) = NULL,
@IsActive CHAR(1) = NULL,
@UserId INT = NULL,
@LoggedInUser BIGINT=null
AS
BEGIN
	IF(@Action = 'S')
	BEGIN
	print 'S'
		select UserId,UserPassword,FirstName,LastName,MobileNo,EmailId,UM.UserTypeId,UM.IsActive,UM.CreatedBy,UM.CreatedDate,UM.UpdatedBy,
		UM.UpdatedDate,ProfilePicPath,UT.UserType from  UserMaster UM 
		JOIN UserTypeMaster UT ON UT.UserTypeId=UM.UserTypeId
		--WHERE (@UserId IS NULL OR UserId = UserId) AND IsActive = @IsActive
		WHERE UserId=@UserId
	END
	ELSE IF(@Action = 'I')
	BEGIN
		if  exists(SELECT NULL FROM UserMaster where EmailId=@EmailId)
		BEGIN
			SELECT 'This user already exists.' AS CRUDStatus
		END
		ELSE
		BEGIN
			INSERT INTO UserMaster(UserPassword,FirstName,LastName,MobileNo,EmailId,UserTypeId,ProfilePicPath,IsActive,CreatedBy,CreatedDate)
			VALUES(@UserPassword,@FirstName,@LastName,@MobileNo,@EmailId,@UserTypeId,@ProfilePicPath,1,@LoggedInUser,GETDATE());

			IF(@@ROWCOUNT > 0)
			BEGIN
				SELECT 'success' AS CRUDStatus
			END
		END
	END
	ELSE IF(@Action = 'U')
	BEGIN
		UPDATE UserMaster
		SET UserPassword = @UserPassword,
			FirstName = @FirstName,
			LastName = @LastName,
			MobileNo = @MobileNo,
			EmailId = @EmailId,
			ProfilePicPath = @ProfilePicPath,
			IsActive = 1,
			UpdatedBy = @LoggedInUser,
			UpdatedDate = GETDATE()
		WHERE UserId = @UserId

		IF(@@ROWCOUNT > 0)
		BEGIN
			SELECT 'success' AS CRUDStatus
		END
	END
	ELSE IF(@Action = 'D')
	BEGIN
		Update UserMaster SET IsActive=0 Where UserId=@UserId
		SELECT 'One user removed successfully!!!' AS CRUDStatus
	END
END

GO

/****** Object:  StoredProcedure [dbo].[GetUserTypes]    Script Date: 01/19/2020 17:10:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[GetUserTypes]
AS
BEGIN
	--Don't Fetch Superadmin user
	SELECT * FROM UserTypeMaster WHERE UserTypeId <> 1
END
GO

/****** Object:  StoredProcedure [dbo].[UserLogin]    Script Date: 01/19/2020 17:10:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[UserLogin]	--UserLogin '8998765434','1'
@LoginId VARCHAR(50),
@UserPassword VARCHAR(100)
AS
BEGIN
	SELECT UserId,FirstName,LastName,MobileNo,EmailId,UserTypeId
	FROM UserMaster
	WHERE (MobileNo = @LoginId OR EmailId = @LoginId) AND UserPassword = @UserPassword
END
GO

/****** Object:  StoredProcedure [dbo].[uspAddQuestionAnswer]    Script Date: 01/19/2020 17:10:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[uspAddQuestionAnswer]
(
	@QuestionAnswerId bigint=null ,
	@QuestionId bigint,
	@CourseId int,
	@AnswerId bigint,
	@StudentExamId bigint,
	@StudentId bigint,
	@LoggedInUser bigint
)
AS
BEGIN
	insert into QuestionAnswer(QuestionId,AnswerId,StudentExamId,StudentId,IsActive,CreatedBy,CreatedDate,CourseId)
	VALUES(@QuestionId,@AnswerId,@StudentExamId,@StudentId,1,@LoggedInUser,GETDATE(),@CourseId)
	
	IF(@@ROWCOUNT > 0)
	BEGIN
		set @QuestionAnswerId=@@IDENTITY
		SELECT 'success' AS CRUDStatus,@QuestionAnswerId AS QuestionAnswerId
	END
	
	Update StudentExams SET IsAppeared=1 Where StudentExamId=@StudentExamId
END



GO

/****** Object:  StoredProcedure [dbo].[uspCrudExamTimes]    Script Date: 01/19/2020 17:10:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[uspCrudExamTimes]
@Action char(1),
@ExamTimesId bigint=null,
@ExamTime varchar(30)=null,
@Description varchar(300)=null,
@LoggedInUser bigint = NULL
AS
BEGIN
	IF(@Action='S')
	BEGIN
		SELECT ExamTimesId,ExamTime,Description,IsActive,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate FROM ExamTimes WHERE IsActive=1 AND ExamTimesId=@ExamTimesId
	END
	ELSE IF(@Action = 'I')
	BEGIN
		INSERT INTO ExamTimes(ExamTime,Description,IsActive,CreatedBy,CreatedDate)
		VALUES(@ExamTime,@Description,1,@LoggedInUser,GETDATE())
	END	
	ELSE IF(@Action = 'U')
	BEGIN
		UPDATE ExamTimes SET ExamTime=@ExamTime,Description=@Description WHERE ExamTimesId=@ExamTimesId
	END
	ELSE IF(@Action = 'L')
	BEGIN
		SELECT ExamTimesId,ExamTime,Description,IsActive,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate FROM ExamTimes WHERE IsActive=1
	END
END
GO

/****** Object:  StoredProcedure [dbo].[uspSelectQuestionPaper]    Script Date: 01/19/2020 17:10:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[uspSelectQuestionPaper]
@StudentId bigint=null,
@ExamId bigint=null
AS
BEGIN
	select QuestionId,Question,QM.CourseId,CM.CourseName,AT.AnswerType,QM.AnswerTypeId,Marks,QM.IsActive,QM.CreatedBy,
	QM.CreatedDate,QM.UpdatedBy,QM.UpdatedDate,SE.StudentExamId,SE.StudentId FROM QuestionMaster QM
	JOIN StudentExams SE ON SE.CourseId=QM.CourseId
	JOIN CourseMaster CM ON CM.CourseId=SE.CourseId
	JOIN AnswerType AT ON AT.AnswerTypeId=QM.AnswerTypeId
	WHERE QM.IsActive=1 AND SE.StudentExamId =@ExamId AND SE.StudentId=@StudentId
	
	select AnswerId,Answer,IsRight,A.QuestionId,QM.Question,A.IsActive,A.CreatedBy,
	A.CreatedDate,A.UpdatedBy,A.UpdatedDate FROM Answer A
	JOIN QuestionMaster QM ON A.QuestionId=QM.QuestionId
	WHERE A.IsActive=1 AND A.QuestionId in(select QuestionId FROM QuestionMaster JOIN StudentExams SE ON SE.CourseId=QM.CourseId WHERE QM.IsActive=1 
	AND SE.StudentExamId =@ExamId AND SE.StudentId=@StudentId)
END
GO

/****** Object:  StoredProcedure [dbo].[uspUserList]    Script Date: 01/19/2020 17:10:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[uspUserList]
@UserId bigint=0,
@Username varchar(50)=null,
@UserTypeId int=null
AS
BEGIN
if(@UserTypeId>0)
BEGIN
	select UserId,UserPassword,FirstName,LastName,MobileNo,EmailId,UM.UserTypeId,UM.IsActive,UM.CreatedBy,UM.CreatedDate,UM.UpdatedBy,
	UM.UpdatedDate,ProfilePicPath,UT.UserType from  UserMaster UM
	JOIN UserTypeMaster UT ON UT.UserTypeId=UM.UserTypeId Where UM.IsActive=1
	AND UM.UserTypeId=@UserTypeId
END
ELSE
BEGIN
	select UserId,UserPassword,FirstName,LastName,MobileNo,EmailId,UM.UserTypeId,UM.IsActive,UM.CreatedBy,UM.CreatedDate,UM.UpdatedBy,
UM.UpdatedDate,ProfilePicPath,UT.UserType from  UserMaster UM
JOIN UserTypeMaster UT ON UT.UserTypeId=UM.UserTypeId Where UM.IsActive=1
END
END


GO


