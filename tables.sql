create table Tarefa
(
	Id int not null identity primary key,
	Titulo nvarchar(100) not null,
	Descricao nvarchar(1000) not null,
	Status int not null,
	DataCriacao datetime not null,
	DataEdicao datetime,
	DataConclusao datetime
);

create table usuario
(
	Id int not null identity primary key,
	Nome nvarchar(100) not null,
	Usuario nvarchar(20) not null,
	Senha nvarchar(20) not null
);