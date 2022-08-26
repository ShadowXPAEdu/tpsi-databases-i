-- Table Servidor
DROP TABLE Servidor;

CREATE TABLE Servidor (
    ID_Servidor NUMBER,
    Regiao VARCHAR2(3) NOT NULL,
    Nome_Serv VARCHAR2(15) NOT NULL UNIQUE,
    CONSTRAINT "PK_Serv" PRIMARY KEY(ID_Servidor)
);

-- Table Conta
DROP TABLE Conta;

CREATE TABLE Conta (
    ID_Conta NUMBER,
    ID_Servidor NUMBER NOT NULL UNIQUE,
    Username VARCHAR2(12) NOT NULL UNIQUE,
    Email VARCHAR2(50) NOT NULL UNIQUE,
    Password_Conta VARCHAR(15) NOT NULL,
    isGM NUMBER(1) NOT NULL CHECK(isGM = 0 OR isGM = 1),
    isLogged NUMBER(1) NOT NULL CHECK(isLogged = 0 OR isLogged = 1),
    isBanned NUMBER(1) NOT NULL CHECK(isBanned = 0 OR isBanned = 1),
    CONSTRAINT "PK_Conta" PRIMARY KEY(ID_Conta),
    CONSTRAINT "FK_Serv_Conta" FOREIGN KEY(ID_Servidor) REFERENCES Servidor(ID_Servidor)
);

-- Table Personagem
DROP TABLE Personagem;

CREATE TABLE Personagem (
    ID_Personagem NUMBER,
    ID_Conta NUMBER NOT NULL UNIQUE,
    ID_Class NUMBER NOT NULL UNIQUE,
    Nome_Pers VARCHAR2(15) NOT NULL UNIQUE,
    Slot NUMBER(1) NOT NULL CHECK(Slot >= 1 AND Slot <= 5),
    Genero CHAR(1) NOT NULL CHECK(Genero = 'M' OR Genero = 'F'),
    CONSTRAINT "PK_Pers" PRIMARY KEY(ID_Personagem),
    CONSTRAINT "FK_Conta_Pers" FOREIGN KEY(ID_Conta) REFERENCES Conta(ID_Conta),
    CONSTRAINT "FK_Class_Pers" FOREIGN KEY(ID_Class) REFERENCES Classe(ID_Class)
);

-- Table Banco
DROP TABLE Banco;

CREATE TABLE Banco (
    ID_Personagem NUMBER,
    Creditos NUMBER(7) NOT NULL,
    CONSTRAINT "PK_Banco" PRIMARY KEY(ID_Personagem),
    CONSTRAINT "FK_Pers_Banco" FOREIGN KEY(ID_Personagem) REFERENCES Personagem(ID_Personagem)
);

-- Table Classe
DROP TABLE Classe;

CREATE TABLE Classe (
    ID_Class NUMBER,
    Nome_Class VARCHAR2(12) NOT NULL UNIQUE,
    TipoDano VARCHAR2(10) NOT NULL,
    TipoAtaque VARCHAR2(10) NOT NULL,
    CONSTRAINT "PK_Class" PRIMARY KEY (ID_Class)
);

-- Table Clan
DROP TABLE Clan;

CREATE TABLE Clan (
    ID_Clan NUMBER,
    Nome_Clan VARCHAR2(12) NOT NULL UNIQUE,
    CONSTRAINT "PK_Clan" PRIMARY KEY(ID_Clan)
);

-- Table Pertence
DROP TABLE Pertence;

CREATE TABLE Pertence (
	ID_Clan NUMBER NOT NULL,
	ID_Personagem NUMBER NOT NULL,
	isLeader NUMBER(1) NOT NULL CHECK(isLeader = 0 OR isLeader = 1),
	isSubLeader NUMBER(1) NOT NULL CHECK(isSubLeader = 0 OR isSubLeader = 1),
	CONSTRAINT "PK_Pertence" PRIMARY KEY(ID_Clan, ID_Personagem),
	CONSTRAINT "FK_Pert_Clan" FOREIGN KEY(ID_Clan) REFERENCES Clan(ID_Clan),
	CONSTRAINT "FK_Pert_Pers" FOREIGN KEY(ID_Personagem) REFERENCES Personagem(ID_Personagem)
);


-- Introduzir valores defeito

CREATE SEQUENCE SEQ_PK_Serv;

CREATE SEQUENCE SEQ_PK_Conta;

CREATE SEQUENCE SEQ_PK_Personagem;

CREATE SEQUENCE SEQ_PK_Class;

INSERT INTO Servidor
VALUES(SEQ_PK_Serv.NEXTVAL, 'PT', 'Leão');

INSERT INTO Conta
VALUES(SEQ_PK_Conta.NEXTVAL, SEQ_PK_Serv.CURRVAL, 'Shrekstrator', 'shrekovski@shreki.pt', 'adminshreky', 1, 0, 0);

INSERT INTO Personagem
VALUES(SEQ_PK_Personagem.NEXTVAL, SEQ_PK_Conta.CURRVAL, SEQ_PK_Class.CURRVAL, 'Leandro', 3, 'M');

INSERT INTO Banco
VALUES(SEQ_PK_Personagem.CURRVAL, 9999999);

INSERT INTO Classe
VALUES(SEQ_PK_Class.NEXTVAL, 'Warrior', 'Physical', 'Melee');
