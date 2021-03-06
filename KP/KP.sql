USE [KP]
GO
/****** Object:  Table [dbo].[admins]    Script Date: 30.08.2021 17:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[admins](
	[id_admin] [int] IDENTITY(1,1) NOT NULL,
	[admin_login] [varchar](100) NULL,
	[admin_password] [varchar](100) NULL,
	[admin_name] [varchar](100) NULL,
	[admin_lastname] [varchar](100) NULL,
	[admin_secondname] [varchar](100) NULL,
	[dateofbirth] [date] NULL,
	[email] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_admin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[countries]    Script Date: 30.08.2021 17:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[countries](
	[id_country] [int] IDENTITY(1,1) NOT NULL,
	[name_country] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_country] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[creators_film]    Script Date: 30.08.2021 17:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[creators_film](
	[id_creator] [int] IDENTITY(1,1) NOT NULL,
	[actor_name] [varchar](100) NULL,
	[actor_lastname] [varchar](100) NULL,
	[actor_secondname] [varchar](100) NULL,
	[dateofbirth] [date] NULL,
	[dateofcareer] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_creator] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DataUsers]    Script Date: 30.08.2021 17:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DataUsers](
	[id_Users] [int] NOT NULL,
	[login] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NULL,
 CONSTRAINT [PK_DataUsers] PRIMARY KEY CLUSTERED 
(
	[login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[films]    Script Date: 30.08.2021 17:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[films](
	[id_film] [int] IDENTITY(1,1) NOT NULL,
	[id_country] [int] NULL,
	[name_film] [varchar](100) NULL,
	[date_creation] [date] NULL,
	[rating] [int] NULL,
	[id_genre] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_film] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[genres]    Script Date: 30.08.2021 17:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[genres](
	[id_genre] [int] IDENTITY(1,1) NOT NULL,
	[name_genre] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_genre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[marks]    Script Date: 30.08.2021 17:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[marks](
	[id_users] [int] NOT NULL,
	[id_films] [int] NOT NULL,
	[marks] [float] NULL,
	[comments] [varchar](1000) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_users] ASC,
	[id_films] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[role_actors]    Script Date: 30.08.2021 17:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[role_actors](
	[id_creator] [int] NOT NULL,
	[id_film] [int] NOT NULL,
	[role_actor] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_creator] ASC,
	[id_film] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 30.08.2021 17:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id_users] [int] IDENTITY(1,1) NOT NULL,
	[user_name] [varchar](100) NULL,
	[user_lastname] [varchar](100) NULL,
	[user_secondname] [varchar](100) NULL,
	[dataofbirth] [date] NULL,
	[email] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_users] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[DataUsers] ([id_Users], [login], [password]) VALUES (8, N'666666', N'666666')
INSERT [dbo].[DataUsers] ([id_Users], [login], [password]) VALUES (9, N'shguts', N'shguts')
INSERT [dbo].[DataUsers] ([id_Users], [login], [password]) VALUES (10, N'SpaceGuard', N'123123')
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([id_users], [user_name], [user_lastname], [user_secondname], [dataofbirth], [email]) VALUES (8, N'fewfewfefew', N'weffewfwfew', N'ewffwefewfew', CAST(N'2002-12-12' AS Date), N'66234@mail.ru')
INSERT [dbo].[Users] ([id_users], [user_name], [user_lastname], [user_secondname], [dataofbirth], [email]) VALUES (9, N'Максим', N'Макаров', N'Максимович', CAST(N'2002-12-12' AS Date), N'shguts@mail.ru')
INSERT [dbo].[Users] ([id_users], [user_name], [user_lastname], [user_secondname], [dataofbirth], [email]) VALUES (10, N'Михаил', N'Масленников', N'Отчество', CAST(N'2002-04-02' AS Date), N'miha.masel1@gmail.com')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[DataUsers]  WITH CHECK ADD  CONSTRAINT [FK_DataUsers_Users] FOREIGN KEY([id_Users])
REFERENCES [dbo].[Users] ([id_users])
GO
ALTER TABLE [dbo].[DataUsers] CHECK CONSTRAINT [FK_DataUsers_Users]
GO
ALTER TABLE [dbo].[films]  WITH CHECK ADD  CONSTRAINT [FK_films_countries] FOREIGN KEY([id_country])
REFERENCES [dbo].[countries] ([id_country])
GO
ALTER TABLE [dbo].[films] CHECK CONSTRAINT [FK_films_countries]
GO
ALTER TABLE [dbo].[films]  WITH CHECK ADD  CONSTRAINT [FK_films_genres] FOREIGN KEY([id_genre])
REFERENCES [dbo].[genres] ([id_genre])
GO
ALTER TABLE [dbo].[films] CHECK CONSTRAINT [FK_films_genres]
GO
ALTER TABLE [dbo].[marks]  WITH CHECK ADD  CONSTRAINT [FK_marks_films] FOREIGN KEY([id_films])
REFERENCES [dbo].[films] ([id_film])
GO
ALTER TABLE [dbo].[marks] CHECK CONSTRAINT [FK_marks_films]
GO
ALTER TABLE [dbo].[marks]  WITH CHECK ADD  CONSTRAINT [FK_marks_Users] FOREIGN KEY([id_users])
REFERENCES [dbo].[Users] ([id_users])
GO
ALTER TABLE [dbo].[marks] CHECK CONSTRAINT [FK_marks_Users]
GO
ALTER TABLE [dbo].[role_actors]  WITH CHECK ADD  CONSTRAINT [FK_role_actors_creators_film] FOREIGN KEY([id_creator])
REFERENCES [dbo].[creators_film] ([id_creator])
GO
ALTER TABLE [dbo].[role_actors] CHECK CONSTRAINT [FK_role_actors_creators_film]
GO
ALTER TABLE [dbo].[role_actors]  WITH CHECK ADD  CONSTRAINT [FK_role_actors_films] FOREIGN KEY([id_film])
REFERENCES [dbo].[films] ([id_film])
GO
ALTER TABLE [dbo].[role_actors] CHECK CONSTRAINT [FK_role_actors_films]
GO
