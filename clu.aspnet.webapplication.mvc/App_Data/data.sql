use [PhotoSharingDB]

SELECT 
	--p.[PhotoId] AS [PhotoId],
	p.[Title] AS [PhotoTitle],
	--p.[ImageMimeType] AS [PhotoMimeType],
	p.[Description] AS [PhotoDescription],
	p.[CreatedDate] AS [PhotoCreatedDate],
	p.[UserName] AS [PhotoUserName],
	p.[Location] AS [PhotoLocation],
	--p.[Longitude] AS [PhotoLongitude],
	--p.[Latitude] AS [PhotoLattitude],
	--c.[CommentID] AS [CommentId],
	c.[UserName] AS [CommentUserName],
	c.[Subject] AS [CommentSubject],
	c.[Body] AS [CommentBody]
FROM dbo.[Photos] p
	LEFT OUTER JOIN dbo.[Comments] c
		ON c.[PhotoID] = p.[PhotoID]
ORDER BY p.[CreatedDate] DESC, p.[UserName] ASC, c.[UserName] ASC