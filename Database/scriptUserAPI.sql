USE [Cadastro]
GO
/****** Object:  Table [dbo].[Escolaridade]    Script Date: 11/09/2022 16:35:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Escolaridade](
	[idEscolaridade] [int] IDENTITY(1,1) NOT NULL,
	[descricao] [varchar](250) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idEscolaridade] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 11/09/2022 16:35:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[cpf] [varchar](11) NOT NULL,
	[nome] [varchar](50) NOT NULL,
	[sobrenome] [varchar](50) NOT NULL,
	[dataNascimento] [date] NULL,
	[email] [varchar](150) NOT NULL,
	[escolaridadeId] [int] NOT NULL,
	[historicoEscolarId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
