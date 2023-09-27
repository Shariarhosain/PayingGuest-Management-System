CREATE TABLE [dbo].[Guest_Booking] (
    [UserName]          NVARCHAR (50) NOT NULL,
    [HouseNumber]       NCHAR (10)    NOT NULL,
    [BookedStatus]      NCHAR (10)    NOT NULL,
    [RequestedCheckout] NCHAR (10)    NULL
);

GO
CREATE TABLE [dbo].[Guest_Booking_History] (
    [OwnerName]        NVARCHAR (50)  NOT NULL,
    [OwnerPhone]       NCHAR (20)     NOT NULL,
    [OwnerEmail]       NVARCHAR (MAX) NOT NULL,
    [HouseNumber]      NCHAR (10)     NOT NULL,
    [NumberOfRoom]     NCHAR (10)     NOT NULL,
    [PreferableGender] NVARCHAR (50)  NOT NULL,
    [HouseLocation]    NVARCHAR (50)  NOT NULL,
    [Cost]             NVARCHAR (50)  NOT NULL,
    [HouseBooked]      NVARCHAR (50)  NOT NULL,
    [HouseBooked_Date] NVARCHAR (50)  NULL,
    [GuestName]        NVARCHAR (50)  NOT NULL,
    [GuestPhone]       NVARCHAR (50)  NOT NULL,
    [GuestEmail]       NVARCHAR (50)  NOT NULL,
    [GuestGender]      NVARCHAR (50)  NOT NULL,
    [BookedStatus]     NVARCHAR (50)  NOT NULL,
    [Checkout]         NVARCHAR (50)  NULL,
    [GuestUserName]    NVARCHAR (50)  NULL
);

GO
CREATE TABLE [dbo].[Guest_Registation] (
    [Name]     NVARCHAR (50)  NULL,
    [Email]    NVARCHAR (50)  NULL,
    [Phone]    NCHAR (11)     NULL,
    [Address]  NVARCHAR (100) NULL,
    [Gender]   NCHAR (10)     NULL,
    [UserName] NVARCHAR (50)  NOT NULL,
    [Password] NVARCHAR (50)  NOT NULL,
    [Status]   NCHAR (50)     NULL
);

GO
CREATE TABLE [dbo].[Host_post] (
    [HouseNumber]      NCHAR (10)    NOT NULL,
    [NumberOfRoom]     NCHAR (10)    NULL,
    [PreferableGender] NCHAR (10)    NULL,
    [Address]          NCHAR (20)    NULL,
    [Cost]             NCHAR (50)    NULL,
    [HouseBooked]      NCHAR (10)    NULL,
    [UserName]         NVARCHAR (50) NULL
);

GO
CREATE TABLE [dbo].[Host_Registation] (
    [Name]     NVARCHAR (50)  NULL,
    [Email]    NVARCHAR (50)  NULL,
    [Phone]    NCHAR (11)     NULL,
    [Address]  NVARCHAR (100) NULL,
    [Gender]   NCHAR (10)     NULL,
    [UserName] NVARCHAR (50)  NOT NULL,
    [Password] NVARCHAR (50)  NOT NULL,
    [Status]   NCHAR (50)     NULL
);

GO
CREATE TABLE [dbo].[Review] (
    [GuestName]        NVARCHAR (50) NULL,
    [HostName]         NVARCHAR (50) NULL,
    [AdminGuestReview] NVARCHAR (50) NULL,
    [GuestReview]      NVARCHAR (50) NULL,
    [HostReview]       NVARCHAR (50) NULL,
    [AdminHostReview]  NCHAR (10)    NULL
);

GO
ALTER TABLE [dbo].[Guest_Booking]
    ADD CONSTRAINT [FK_Guest_Booking_Guest_Registation] FOREIGN KEY ([UserName]) REFERENCES [dbo].[Guest_Registation] ([UserName]);

GO
ALTER TABLE [dbo].[Guest_Booking_History]
    ADD CONSTRAINT [FK_Guest_Booking_History_Guest_Registation] FOREIGN KEY ([GuestUserName]) REFERENCES [dbo].[Guest_Registation] ([UserName]);

GO
ALTER TABLE [dbo].[Guest_Booking_History]
    ADD CONSTRAINT [FK_Guest_Booking_History_Host_post] FOREIGN KEY ([HouseNumber]) REFERENCES [dbo].[Host_post] ([HouseNumber]);

GO
ALTER TABLE [dbo].[Guest_Booking]
    ADD CONSTRAINT [FK_Guest_Booking_Host_post] FOREIGN KEY ([HouseNumber]) REFERENCES [dbo].[Host_post] ([HouseNumber]);

GO
ALTER TABLE [dbo].[Host_post]
    ADD CONSTRAINT [FK_Host_post_Host_Registation] FOREIGN KEY ([UserName]) REFERENCES [dbo].[Host_Registation] ([UserName]);

GO
ALTER TABLE [dbo].[Review]
    ADD CONSTRAINT [FK_Review_Guest_Registation] FOREIGN KEY ([GuestName]) REFERENCES [dbo].[Guest_Registation] ([UserName]);

GO
ALTER TABLE [dbo].[Review]
    ADD CONSTRAINT [FK_Review_Host_Registation] FOREIGN KEY ([HostName]) REFERENCES [dbo].[Host_Registation] ([UserName]);

GO
ALTER TABLE [dbo].[Guest_Registation]
    ADD CONSTRAINT [PK_Guest_Registation] PRIMARY KEY CLUSTERED ([UserName] ASC);

GO
ALTER TABLE [dbo].[Host_post]
    ADD CONSTRAINT [PK_Host_post] PRIMARY KEY CLUSTERED ([HouseNumber] ASC);

GO
ALTER TABLE [dbo].[Host_Registation]
    ADD CONSTRAINT [PK_Host_Registation] PRIMARY KEY CLUSTERED ([UserName] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_Guest_Booking]
    ON [dbo].[Guest_Booking]([UserName] ASC);

GO
