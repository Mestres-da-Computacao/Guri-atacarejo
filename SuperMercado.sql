-- Criação das tabelas
CREATE TABLE GA_Clientes (
    IdCliente INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    CPF VARCHAR(14) UNIQUE NOT NULL,
    Genero CHAR(1) CHECK (Genero IN ('M', 'F', 'O')),
    Email VARCHAR(100),
    Celular VARCHAR(15)
);

CREATE TABLE GA_Cargos (
    IdCargo INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(50) NOT NULL,
    SalarioBase DECIMAL(18,2) NOT NULL,
    Nivel VARCHAR(20)
);

CREATE TABLE Departamentos (
    IdDepartamento INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(50) NOT NULL
);

CREATE TABLE GA_Funcionarios (
    IdCliente INT PRIMARY KEY,
    FKCargo INT NOT NULL,
    Nome VARCHAR(100) NOT NULL,
    CPF VARCHAR(14) UNIQUE NOT NULL,
    DataNascimento DATE NOT NULL,
    Genero CHAR(1) CHECK (Genero IN ('M', 'F', 'O')),
    Telefone VARCHAR(15) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    DataAdmissao DATE NOT NULL,
    Salario DECIMAL(18,2) NOT NULL,
    StatusFuncionamento VARCHAR(20) DEFAULT 'Ativo' CHECK (StatusFuncionamento IN ('Ativo', 'Inativo', 'Afastado')),
    CONSTRAINT FK_Funcionarios_Clientes FOREIGN KEY (IdCliente) REFERENCES GA_Clientes(IdCliente),
    CONSTRAINT FK_Funcionarios_Cargos FOREIGN KEY (FKCargo) REFERENCES GA_Cargos(IdCargo)
);

CREATE TABLE GA_Fornecedor (
    IdFornecedor INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    CNPJ VARCHAR(18) UNIQUE NOT NULL,
    Email VARCHAR(100) NOT NULL,
    Telefone VARCHAR(15)  NOT NULL,
    Endereco VARCHAR(200) NOT NULL
);

CREATE TABLE GA_Categoria (
    IdCategoria INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(50) NOT NULL,
    Descricao VARCHAR(200)
);

CREATE TABLE GA_Produtos (
    IdProduto INT IDENTITY(1,1) PRIMARY KEY,
    FKFornecedor INT NOT NULL,
    FKCategoria INT NOT NULL,
    Nome VARCHAR(100) NOT NULL,
    UnidadeMedida VARCHAR(20) NOT NULL,
    Preco DECIMAL(18,2) NOT NULL,
    DataValidade DATE,
    CONSTRAINT FK_Produtos_Fornecedor FOREIGN KEY (FKFornecedor) REFERENCES GA_Fornecedor(IdFornecedor),
    CONSTRAINT FK_Produtos_Categoria FOREIGN KEY (FKCategoria) REFERENCES GA_Categoria(IdCategoria)
);

CREATE TABLE GA_Estoque (
    IdEstoque INT IDENTITY(1,1) PRIMARY KEY,
    FKProdutos INT NOT NULL UNIQUE, -- REGISTRO ÚNICO
    QuantidadeAtual INT NOT NULL DEFAULT 0,
    QuantidadeMinima INT NOT NULL DEFAULT 0,
    StatusEstoque VARCHAR(20) DEFAULT 'Disponível' CHECK (StatusEstoque IN ('Disponível', 'Indisponível', 'próximo ao Minimo')),
    CONSTRAINT FK_Estoque_Produtos FOREIGN KEY (FKProdutos) REFERENCES GA_Produtos(IdProduto)
);

CREATE TABLE GA_Compra (
    IdCompra INT IDENTITY(1,1) PRIMARY KEY,
    FKFornecedor INT NOT NULL,
    FKFuncionario INT NOT NULL,
    DataCompra DATE NOT NULL,
    ValorTotal DECIMAL(18,2) NOT NULL,
    StatusCompra VARCHAR(20) DEFAULT 'Pendente' CHECK (StatusCompra IN ('Pendente', 'Pago', 'Cancelado')),
    FormaPagamento VARCHAR(50),
    DataEntrega DATE,
    CONSTRAINT FK_Compra_Fornecedor FOREIGN KEY (FKFornecedor) REFERENCES GA_Fornecedor(IdFornecedor),
    CONSTRAINT FK_Compra_Funcionarios FOREIGN KEY (FKFuncionario) REFERENCES GA_Funcionarios(IdCliente)
);

CREATE TABLE GA_ItensCompra (
    IdItemCompra INT IDENTITY(1,1) PRIMARY KEY,
    FKCompra INT NOT NULL,
    FKProduto INT NOT NULL,
    Quantidade INT NOT NULL CHECK (Quantidade > 0),
    PrecoUnitario DECIMAL(18,2) NOT NULL,
    Subtotal DECIMAL(18,2) NOT NULL,
    CONSTRAINT FK_ItensCompra_Compra FOREIGN KEY (FKCompra) REFERENCES GA_Compra(IdCompra),
    CONSTRAINT FK_ItensCompra_Produtos FOREIGN KEY (FKProduto) REFERENCES GA_Produtos(IdProduto)
);

CREATE TABLE GA_Venda (
    IdVenda INT IDENTITY(1,1) PRIMARY KEY,
    FKCliente INT NOT NULL,
    FKFuncionario INT NOT NULL,
    DataVenda DATE NOT NULL,
    ValorTotal DECIMAL(18,2) NOT NULL,
    FormaPagamento VARCHAR(50),
    StatusVenda VARCHAR(20) DEFAULT 'Pendente' CHECK (StatusVenda IN ('Pendente', 'Pago', 'Cancelado')),
    CONSTRAINT FK_Venda_Clientes FOREIGN KEY (FKCliente) REFERENCES GA_Clientes(IdCliente),
    CONSTRAINT FK_Venda_Funcionarios FOREIGN KEY (FKFuncionario) REFERENCES GA_Funcionarios(IdCliente)
);

CREATE TABLE GA_ItensVenda (
    IdItemVenda INT IDENTITY(1,1) PRIMARY KEY,
    FKVenda INT NOT NULL,
    FKProduto INT NOT NULL,
    Quantidade INT NOT NULL CHECK (Quantidade > 0),
    PrecoUnitario DECIMAL(18,2) NOT NULL,
    Subtotal DECIMAL(18,2) NOT NULL,
    CONSTRAINT FK_ItensVenda_Venda FOREIGN KEY (FKVenda) REFERENCES GA_Venda(IdVenda),
    CONSTRAINT FK_ItensVenda_Produtos FOREIGN KEY (FKProduto) REFERENCES GA_Produtos(IdProduto)
);