
-- first need start solution ! 

Insert into Roles (Name,Description) Values('Admin', 'Admin')
Insert into Roles (Name,Description) Values('Moderator', 'Moderator')
Insert into Roles (Name,Description) Values('User', 'User')

Insert into Users (Email,Login,CreationDateTime,RoleId) Values('admin@forum.ru', 'admin@forum.ru', GETDATE(), (Select Id From Roles Where Name = 'Admin'))
Insert into Users (Email,Login,CreationDateTime,RoleId) Values('moderator@forum.ru', 'moderator@forum.ru',GETDATE(), (Select Id From Roles Where Name = 'Moderator'))
Insert into Users (Email,Login,CreationDateTime,RoleId) Values('user@forum.ru', 'user@forum.ru',GETDATE(), (Select Id From Roles Where Name = 'User'))

--password - qwerty123
Insert into webpages_Membership (UserId,CreateDate,IsConfirmed,Password, PasswordSalt ) Values((Select Id From Users Where Email like '%admin@forum.ru%'), GETDATE(),1,'APoL++hKEj8m06NTZFPBpe3TvtiJbD1QbFb0j/HtTqtbTGo1Bl3W49Np6liBzuLGZg==','')
Insert into webpages_Membership (UserId,CreateDate,IsConfirmed,Password, PasswordSalt) Values((Select Id From Users Where Email like '%moderator@forum.ru%'), GETDATE(),1,'APoL++hKEj8m06NTZFPBpe3TvtiJbD1QbFb0j/HtTqtbTGo1Bl3W49Np6liBzuLGZg==','')
Insert into webpages_Membership (UserId,CreateDate,IsConfirmed,Password, PasswordSalt ) Values((Select Id From Users Where Email like '%user@forum.ru%'), GETDATE(),1,'APoL++hKEj8m06NTZFPBpe3TvtiJbD1QbFb0j/HtTqtbTGo1Bl3W49Np6liBzuLGZg==','')