CREATE DATABASE BD_M15_Casas

-- Cirar tebelas 

CREATE TABLE Clientes(
    n_cartao_cidadao INT PRIMARY KEY NOT NULL,
    nome VARCHAR(200) NOT NULL,
    morada VARCHAR(200) NOT NULL,
    telemovel VARCHAR(12) NOT NULL,
    gmail VARCHAR(1000) NOT NULL,
    pass VARCHAR(45) NOT NULL,
    vendedor_ou_comprador VARCHAR(11) NOT NULL,
    img LONGBLOB
);

CREATE TABLE Casa(
    idCasa INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    img LONGBLOB,
    n_cartao_cidadao INT,
    nome_rua VARCHAR(200) NOT NULL,
    cidade_distrito VARCHAR(200) NOT NULL,
    ano INT NOT NULL,
    preco DECIMAL(10,2) NOT NULL,
    n_visitas INT NOT NULL,
    quando_visitada VARCHAR(11) NOT NULL,   

    FOREIGN KEY (n_cartao_cidadao) REFERENCES Clientes(n_cartao_cidadao)
);

CREATE TABLE Favoritos (
    idFavorito INT AUTO_INCREMENT PRIMARY KEY,
    idCasa INT,
    n_cartao_cidadao INT,
    FOREIGN KEY (idCasa) REFERENCES Casa(idCasa),
    FOREIGN KEY (n_cartao_cidadao) REFERENCES Clientes(n_cartao_cidadao)
);