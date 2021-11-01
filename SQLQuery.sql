Create Procedure Sp_LoadAllCountry
AS
Begin
Select * from Countries
End
GO
Create Procedure Sp_LoadAllCityByCountryId
(
@countryId int
)
AS
Begin
Select * from Cities where CountryID=@countryId
End
GO

Create Procedure Sp_LoadAllGender
AS
Begin
Select * from Genders
End
GO
Create Procedure Sp_LoadAllHobby
AS
Begin
Select * from Hobbies
End
GO

Create Procedure Sp_LoadAllFavoriteHobbyByProfileId
(
@profileId int
)
AS
Begin
Select fh.FavouriteHobbyId,h.HobbyId,h.HobbyName from FavouriteHobbies fh
Inner Join Hobbies h on fh.HobbyId=h.HobbyId
where ProfileId=@profileId
End
GO
exec Sp_LoadAllFavoriteHobbyByProfileId 1