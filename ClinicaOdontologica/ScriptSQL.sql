
CREATE DATABASE Clinica
GO 

USE Clinica
GO

CREATE TABLE Pessoa(
	id_pessoa INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	nome VARCHAR(255) NOT NULL,
	data_nascimento DATE NOT NULL,
	sexo CHAR(1),
	cpf CHAR(11) NOT NULL
)

CREATE TABLE Contato (
	id_contato INT NOT NULL PRIMARY KEY IDENTITY (1,1),
	telefone VARCHAR(16) NOT NULL,
	email VARCHAR(255)
)

CREATE TABLE PessoaContato (
	id_contato INT NOT NULL,
	id_pessoa INT NOT NULL,
	CONSTRAINT PK_PessoaContato PRIMARY KEY (id_pessoa, id_contato),
	CONSTRAINT FK_id_contato FOREIGN KEY (id_contato) REFERENCES Contato(id_contato),
	CONSTRAINT FK_id_pessoa FOREIGN KEY (id_pessoa) REFERENCES Pessoa(id_pessoa)
)

CREATE TABLE Endereco (
	id_endereco INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	uf CHAR (2) NOT NULL,
	referencia VARCHAR(125) NOT NULL,
	cidade VARCHAR(125) NOT NULL,
	bairro VARCHAR(125) NOT NULL,
	complemento VARCHAR(125),
	numero INT NOT NULL,
	cep CHAR(9) NOT NULL,
	id_pessoa INT NOT NULL,
	logradouro VARCHAR(125),
	CONSTRAINT FK_id_pessoa_endereco FOREIGN KEY (id_pessoa) REFERENCES Pessoa (id_pessoa)
)

CREATE TABLE Cargo (
	id_cargo INT NOT NULL PRIMARY KEY IDENTITY (1, 1),
	nome VARCHAR(125) NOT NULL
)

CREATE TABLE Funcionario (
	id_funcionario INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	situacao TINYINT NOT NULL,
	salario DECIMAL(10,2),
	id_pessoa INT NOT NULL,
	id_cargo INT NOT NULL,
	CONSTRAINT FK_id_pessoa_funcionario FOREIGN KEY (id_pessoa) REFERENCES Pessoa(id_pessoa),
	CONSTRAINT FK_id_cargo FOREIGN KEY (id_cargo) REFERENCES Cargo(id_cargo)
)

CREATE TABLE Paciente (
	id_paciente INT NOT NULL PRIMARY KEY IDENTITY (1,1),
	numero_prontuario VARCHAR(125) NOT NULL,
	id_pessoa INT NOT NULL,
	CONSTRAINT FK_id_pessoa_paciente FOREIGN KEY (id_pessoa) REFERENCES Pessoa(id_pessoa)
)
		
CREATE TABLE Dentista (
	id_dentista INT NOT NULL PRIMARY KEY IDENTITY (1,1),
	cro VARCHAR(125) NOT NULL,
	id_pessoa INT NOT NULL,
	CONSTRAINT FK_id_pessoa_dentista FOREIGN KEY (id_pessoa) REFERENCES Pessoa(id_pessoa)
)

CREATE TABLE Servico (
	id_servico INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(125) NOT NULL,
	valor DECIMAL(10,2) NOT NULL
)

CREATE TABLE Consulta (
	id_consulta INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	observacao VARCHAR(125),
	data_consulta DATE NOT NULL,
	hora_consulta TIME NOT NULL,
	situacao TINYINT NOT NULL,
	id_paciente INT NOT NULL,
	CONSTRAINT FK_id_paciente_consulta FOREIGN KEY (id_paciente) REFERENCES Paciente (id_paciente),
	id_dentista INT NOT NULL,
	CONSTRAINT FK_id_dentista_consulta FOREIGN KEY (id_dentista) REFERENCES Dentista (id_dentista),
	id_servico INT NOT NULL,
	CONSTRAINT FK_id_servico_consulta FOREIGN KEY (id_servico) REFERENCES Servico(id_servico)
)

INSERT INTO Cargo (nome) VALUES('Dentista');

INSERT INTO Servico (nome, valor) VALUES('Restaurações', 1000);
INSERT INTO Servico (nome, valor) VALUES('Aplicação de flúor', 2000);
INSERT INTO Servico (nome, valor) VALUES('Tratamentos de canal', 3000);
INSERT INTO Servico (nome, valor) VALUES('Tratamento de bruxismo', 4000);
INSERT INTO Servico (nome, valor) VALUES('Remoções de dentes', 5000);
INSERT INTO Servico (nome, valor) VALUES('Enxertos ósseos', 6000);
INSERT INTO Servico (nome, valor) VALUES('Prótese dentária', 7000);
INSERT INTO Servico (nome, valor) VALUES('Clareamento dentário', 8000);
INSERT INTO Servico (nome, valor) VALUES('Lentes de contato', 9000);

GO



