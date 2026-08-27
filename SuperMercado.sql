-- Criação das tabelas

-- 1.1. Clientes
CREATE TABLE GA_Clientes (
    IdCliente INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    CPF VARCHAR(14) UNIQUE NOT NULL,
    Genero CHAR(1) CHECK (Genero IN ('M', 'F', 'O')),
    Email VARCHAR(100),
    Celular VARCHAR(15),
    NivelFidelidade INT,
    TotalComprasAcumuladas INT,
);
GO

-- 1.2. Cargos
CREATE TABLE GA_Cargos (
    IdCargo INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(50) NOT NULL,
    SalarioBase DECIMAL(18,2) NOT NULL,
    Nivel VARCHAR(20)
);
GO

-- 1.3. Departamentos
CREATE TABLE GA_Departamentos (
    IdDepartamento INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(50) NOT NULL
);
GO

-- 1.4. Funcionarios
CREATE TABLE GA_Funcionarios (
    IdFuncionario INT IDENTITY(1,1) PRIMARY KEY,
    FKCargo INT NOT NULL,
    FKDepartamento INT NOT NULL,
    Nome VARCHAR(100) NOT NULL,
    CPF VARCHAR(14) UNIQUE NOT NULL,
    DataNascimento DATE NOT NULL,
    Genero CHAR(1) CHECK (Genero IN ('M', 'F', 'O')),
    Telefone VARCHAR(15),
    Email VARCHAR(100),
    DataEmissao DATE NOT NULL,
    Salario DECIMAL(18,2) NOT NULL,
    StatusFuncionamento VARCHAR(20) DEFAULT 'Ativo' CHECK (StatusFuncionamento IN ('Ativo', 'Inativo', 'Afastado')),
    CONSTRAINT FK_GA_Funcionarios_Cargos FOREIGN KEY (FKCargo) REFERENCES GA_Cargos(IdCargo),
    CONSTRAINT FK_GA_Funcionarios_Departamentos FOREIGN KEY (FKDepartamento) REFERENCES GA_Departamentos(IdDepartamento)
);
GO

-- 1.5. Fornecedor
CREATE TABLE GA_Fornecedor (
    IdFornecedor INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    CNPJ VARCHAR(18) UNIQUE NOT NULL,
    Email VARCHAR(100),
    Telefone VARCHAR(15),
    Endereco VARCHAR(200) NOT NULL
);
GO

-- 1.6. Categoria
CREATE TABLE GA_Categoria (
    IdCategoria INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(50) NOT NULL,
    Descricao VARCHAR(200)
);
GO

-- 1.7. Produtos
CREATE TABLE GA_Produtos (
    IdProduto INT IDENTITY(1,1) PRIMARY KEY,
    FKFornecedor INT NOT NULL,
    FKCategoria INT NOT NULL,
    Nome VARCHAR(100) NOT NULL,
    UnidadeMedida VARCHAR(20) NOT NULL,
    Preco DECIMAL(18,2) NOT NULL,
    DataValidade DATE,
    CONSTRAINT FK_GA_Produtos_Fornecedor FOREIGN KEY (FKFornecedor) REFERENCES GA_Fornecedor(IdFornecedor),
    CONSTRAINT FK_GA_Produtos_Categoria FOREIGN KEY (FKCategoria) REFERENCES GA_Categoria(IdCategoria)
);
GO

-- 1.8. estoque
CREATE TABLE GA_Estoque (
    IdEstoque INT IDENTITY(1,1) PRIMARY KEY,
    FKProdutos INT NOT NULL UNIQUE,
    QuantidadeAtual INT NOT NULL DEFAULT 0,
    QuantidadeMinima INT NOT NULL DEFAULT 0,
    StatusEstoque VARCHAR(20) DEFAULT 'Disponível' CHECK (StatusEstoque IN ('Disponível', 'Indisponível', 'Próximo ao mínimo')),
    CONSTRAINT FK_GA_Estoque_Produtos FOREIGN KEY (FKProdutos) REFERENCES GA_Produtos(IdProduto)
);
GO

-- 1.9. Compra
CREATE TABLE GA_Compra (
    IdCompra INT IDENTITY(1,1) PRIMARY KEY,
    FKFornecedor INT NOT NULL,
    FKFuncionario INT NOT NULL,  -- referencia IdFuncionario
    DataCompra DATE NOT NULL,
    ValorTotal DECIMAL(18,2) NOT NULL DEFAULT 0,
    StatusCompra VARCHAR(20) DEFAULT 'Pendente' CHECK (StatusCompra IN ('Pendente', 'Pago', 'Cancelado')),
    FormaPagamento VARCHAR(50),
    DataEntrega DATE,
    CONSTRAINT FK_GA_Compra_Fornecedor FOREIGN KEY (FKFornecedor) REFERENCES GA_Fornecedor(IdFornecedor),
    CONSTRAINT FK_GA_Compra_Funcionarios FOREIGN KEY (FKFuncionario) REFERENCES GA_Funcionarios(IdFuncionario)
);
GO

-- 1.10. ItensCompra
CREATE TABLE GA_ItensCompra (
    IdItemCompra INT IDENTITY(1,1) PRIMARY KEY,
    FKCompra INT NOT NULL,
    FKProduto INT NOT NULL,
    Quantidade INT NOT NULL CHECK (Quantidade > 0),
    PrecoUnitario DECIMAL(18,2) NOT NULL,
    Subtotal DECIMAL(18,2) NOT NULL,
    CONSTRAINT FK_GA_ItensCompra_Compra FOREIGN KEY (FKCompra) REFERENCES GA_Compra(IdCompra),
    CONSTRAINT FK_GA_ItensCompra_Produtos FOREIGN KEY (FKProduto) REFERENCES GA_Produtos(IdProduto)
);
GO

-- 1.11. Venda
CREATE TABLE GA_Venda (
    IdVenda INT IDENTITY(1,1) PRIMARY KEY,
    FKCliente INT NOT NULL,
    FKFuncionario INT NOT NULL,  -- referencia IdFuncionario
    DataVenda DATE NOT NULL,
    ValorTotal DECIMAL(18,2) NOT NULL DEFAULT 0,
    FormaPagamento VARCHAR(50),
    StatusVenda VARCHAR(20) DEFAULT 'Pendente' CHECK (StatusVenda IN ('Pendente', 'Pago', 'Cancelado')),
    CONSTRAINT FK_GA_Venda_Clientes FOREIGN KEY (FKCliente) REFERENCES GA_Clientes(IdCliente),
    CONSTRAINT FK_GA_Venda_Funcionarios FOREIGN KEY (FKFuncionario) REFERENCES GA_Funcionarios(IdFuncionario)
);
GO

-- 1.12. ItensVenda
CREATE TABLE GA_ItensVenda (
    IdItemVenda INT IDENTITY(1,1) PRIMARY KEY,
    FKVenda INT NOT NULL,
    FKProduto INT NOT NULL,
    Quantidade INT NOT NULL CHECK (Quantidade > 0),
    PrecoUnitario DECIMAL(18,2) NOT NULL,
    Subtotal DECIMAL(18,2) NOT NULL,
    CONSTRAINT FK_GA_ItensVenda_Venda FOREIGN KEY (FKVenda) REFERENCES GA_Venda(IdVenda),
    CONSTRAINT FK_GA_ItensVenda_Produtos FOREIGN KEY (FKProduto) REFERENCES GA_Produtos(IdProduto)
);
GO


-- 2. Triggers da resenha

-- 2.1. Calcular Subtotal(venda)
CREATE OR ALTER TRIGGER trg_CalcSubtotal_ItensVenda
ON GA_ItensVenda
INSTEAD OF INSERT
AS
BEGIN
    SET NOCOUNT ON;

    IF (ROWCOUNT_BIG() = 0)
        RETURN;

    INSERT INTO GA_ItensVenda
    (
        FKVenda,
        FKProduto,
        Quantidade,
        PrecoUnitario,
        Subtotal
    )
    SELECT
        FKVenda,
        FKProduto,
        Quantidade,
        PrecoUnitario,
        Quantidade * PrecoUnitario
    FROM inserted;
END;
GO

-- 2.2. Calcular Subtotal(compra)
CREATE OR ALTER TRIGGER trg_CalcSubtotal_ItensCompra
ON GA_ItensCompra
INSTEAD OF INSERT
AS
BEGIN
    SET NOCOUNT ON;

    IF (ROWCOUNT_BIG() = 0)
        RETURN;

    INSERT INTO GA_ItensCompra
    (
        FKCompra,
        FKProduto,
        Quantidade,
        PrecoUnitario,
        Subtotal
    )
    SELECT
        FKCompra,
        FKProduto,
        Quantidade,
        PrecoUnitario,
        Quantidade * PrecoUnitario
    FROM inserted;
END;
GO

-- 2.3. Atualizar ValorTotal da Venda
CREATE OR ALTER TRIGGER trg_UpdateTotalVenda
ON GA_ItensVenda
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    IF (ROWCOUNT_BIG() = 0)
        RETURN;

    ;WITH VendasAfetadas AS
    (
        SELECT FKVenda AS IdVenda
        FROM inserted

        UNION

        SELECT FKVenda AS IdVenda
        FROM deleted
    )
    UPDATE v
    SET v.ValorTotal = ISNULL(t.Total, 0)
    FROM GA_Venda v
    INNER JOIN VendasAfetadas va
        ON v.IdVenda = va.IdVenda
    OUTER APPLY
    (
        SELECT SUM(iv.Subtotal) AS Total
        FROM GA_ItensVenda iv
        WHERE iv.FKVenda = v.IdVenda
    ) t;
END;
GO

-- 2.4. Atualizar ValorTotal da Compra
CREATE OR ALTER TRIGGER trg_UpdateTotalCompra
ON GA_ItensCompra
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    IF (ROWCOUNT_BIG() = 0)
        RETURN;

    ;WITH ComprasAfetadas AS
    (
        SELECT FKCompra AS IdCompra
        FROM inserted

        UNION

        SELECT FKCompra AS IdCompra
        FROM deleted
    )
    UPDATE c
    SET c.ValorTotal = ISNULL(t.Total, 0)
    FROM GA_Compra c
    INNER JOIN ComprasAfetadas ca
        ON c.IdCompra = ca.IdCompra
    OUTER APPLY
    (
        SELECT SUM(ic.Subtotal) AS Total
        FROM GA_ItensCompra ic
        WHERE ic.FKCompra = c.IdCompra
    ) t;
END;
GO

-- 2.5. Baixar Estoque(ao vender)
CREATE OR ALTER TRIGGER trg_BaixarEstoqueVenda
ON GA_ItensVenda
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    IF (ROWCOUNT_BIG() = 0)
        RETURN;

    -- Verifica se todos os produtos possuem estoque cadastrado
    IF EXISTS
    (
        SELECT 1
        FROM inserted i
        LEFT JOIN GA_Estoque e
            ON e.FKProdutos = i.FKProduto
        WHERE e.IdEstoque IS NULL
    )
    BEGIN
        RAISERROR('Não existe registro de estoque para um ou mais produtos da venda.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END;

    -- Verifica se o estoque será suficiente
    IF EXISTS
    (
        SELECT 1
        FROM GA_Estoque e
        INNER JOIN
        (
            SELECT
                FKProduto,
                SUM(Quantidade) AS QuantidadeVendida
            FROM inserted
            GROUP BY FKProduto
        ) i
            ON e.FKProdutos = i.FKProduto
        WHERE e.QuantidadeAtual < i.QuantidadeVendida
    )
    BEGIN
        RAISERROR('Estoque insuficiente para um ou mais produtos da venda.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END;

    -- Baixa o estoque agrupando os produtos repetidos
    UPDATE e
    SET e.QuantidadeAtual = e.QuantidadeAtual - i.QuantidadeVendida
    FROM GA_Estoque e
    INNER JOIN
    (
        SELECT
            FKProduto,
            SUM(Quantidade) AS QuantidadeVendida
        FROM inserted
        GROUP BY FKProduto
    ) i
        ON e.FKProdutos = i.FKProduto;
END;
GO

-- 2.6. Adicionar Estoque (ao comprar)
CREATE OR ALTER TRIGGER trg_AdicionarEstoqueCompra
ON GA_ItensCompra
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    IF (ROWCOUNT_BIG() = 0)
        RETURN;

    -- verifica se o produto tem estoque CADASTRADO se NÃO tiver mostra ERRO
    IF EXISTS
    (
        SELECT 1
        FROM inserted i
        LEFT JOIN GA_Estoque e
            ON e.FKProdutos = i.FKProduto
        WHERE e.IdEstoque IS NULL
    )
    BEGIN
        RAISERROR('Não existe registro de estoque para um ou mais produtos da compra.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END;

    -- Adiciona o estoque agrupando os produtos repetidos
    UPDATE e
    SET e.QuantidadeAtual = e.QuantidadeAtual + i.QuantidadeComprada
    FROM GA_Estoque e
    INNER JOIN
    (
        SELECT
            FKProduto,
            SUM(Quantidade) AS QuantidadeComprada
        FROM inserted
        GROUP BY FKProduto
    ) i
        ON e.FKProdutos = i.FKProduto;
END;
GO

-- 2.7. olhar estoque minimo e atualizar status
CREATE OR ALTER TRIGGER trg_VerificarEstoqueMinimo
ON GA_Estoque
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    IF (ROWCOUNT_BIG() = 0)
        RETURN;

    IF UPDATE(QuantidadeAtual)
    BEGIN
        UPDATE e
        SET StatusEstoque = CASE 
            WHEN e.QuantidadeAtual <= 0 THEN 'Indisponível'
            WHEN e.QuantidadeAtual <= e.QuantidadeMinima THEN 'Próximo ao mínimo'
            ELSE 'Disponível'
        END
        FROM GA_Estoque e
        INNER JOIN inserted i
            ON e.IdEstoque = i.IdEstoque;
    END
END;
GO
-- 3. Procedures do andersonresenhudo

-- 3.1. Registrar Venda(com validação de estoque)
CREATE OR ALTER PROCEDURE usp_RegistrarVenda
    @FKCliente INT,
    @FKFuncionario INT,
    @FormaPagamento VARCHAR(50),
    @ItensJson NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @IdVenda INT;
        DECLARE @Produto INT;
        DECLARE @Qtd INT;
        DECLARE @EstoqueAtual INT;

        -- Cursor para validar estoque antes de inserir
        DECLARE cur CURSOR LOCAL FOR
        SELECT FKProduto, Quantidade
        FROM OPENJSON(@ItensJson)
        WITH (
            FKProduto INT '$.FKProduto',
            Quantidade INT '$.Quantidade'
        );

        OPEN cur;

        FETCH NEXT FROM cur INTO @Produto, @Qtd;

        WHILE @@FETCH_STATUS = 0
        BEGIN
            SET @EstoqueAtual = 0;

            SELECT @EstoqueAtual = QuantidadeAtual
            FROM GA_Estoque
            WHERE FKProdutos = @Produto;

            IF @EstoqueAtual < @Qtd
            BEGIN
                CLOSE cur;
                DEALLOCATE cur;

                ROLLBACK TRANSACTION;

                RAISERROR(
                    'Estoque insuficiente para o produto informado.',
                    16,
                    1
                );

                RETURN;
            END;

            FETCH NEXT FROM cur INTO @Produto, @Qtd;
        END;

        CLOSE cur;
        DEALLOCATE cur;

        -- Insere as infos da venda
        INSERT INTO GA_Venda
        (
            FKCliente,
            FKFuncionario,
            DataVenda,
            ValorTotal,
            FormaPagamento,
            StatusVenda
        )
        VALUES
        (
            @FKCliente,
            @FKFuncionario,
            GETDATE(),
            0,
            @FormaPagamento,
            'Pendente'
        );

        SET @IdVenda = SCOPE_IDENTITY(); -- Retorna o último ID gerado dentro do escopo(neste caso retornaria o IdVenda) (o escopo é qualquer módulo de execução{procedures, triggers e funcs)

        -- Insere os itens (a trigger calcula subtotal e baixa estoque)
        INSERT INTO GA_ItensVenda
        (
            FKVenda,
            FKProduto,
            Quantidade,
            PrecoUnitario
        )
        SELECT
            @IdVenda,
            FKProduto,
            Quantidade,
            PrecoUnitario
        FROM OPENJSON(@ItensJson)
        WITH
        (
            FKProduto INT '$.FKProduto',
            Quantidade INT '$.Quantidade',
            PrecoUnitario DECIMAL(18,2) '$.PrecoUnitario'
        );

        -- Atualiza status da venda (paga e etc...)
        UPDATE GA_Venda
        SET StatusVenda = 'Pago'
        WHERE IdVenda = @IdVenda;

        COMMIT TRANSACTION;

        SELECT
            @IdVenda AS IdVendaGerada,
            'Venda realizada com sucesso!' AS Mensagem;

    END TRY
    BEGIN CATCH

        IF CURSOR_STATUS('local', 'cur') >= 0
        BEGIN
            CLOSE cur;
        END;

        IF CURSOR_STATUS('local', 'cur') >= -1
        BEGIN
            DEALLOCATE cur;
        END;

        IF XACT_STATE() <> 0
        BEGIN
            ROLLBACK TRANSACTION;
        END;

        RAISERROR(
            'Erro ao registrar a venda.',
            16,
            1
        );

    END CATCH;
END;
GO

-- 3.2. Registrar Compra (entrada de mercadorias)
CREATE PROCEDURE usp_RegistrarCompra
    @FKFornecedor INT,
    @FKFuncionario INT,
    @FormaPagamento VARCHAR(50),
    @DataEntrega DATE,
    @ItensJson NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;
    BEGIN TRY
        DECLARE @IdCompra INT;

        INSERT INTO GA_Compra (FKFornecedor, FKFuncionario, DataCompra, ValorTotal, FormaPagamento, DataEntrega, StatusCompra)
        VALUES (@FKFornecedor, @FKFuncionario, GETDATE(), 0, @FormaPagamento, @DataEntrega, 'Pago');
        SET @IdCompra = SCOPE_IDENTITY(); -- Retorna a última identity(id) gerada dentro do escopo (o escopo é qualquer módulo de execução{triggers, procedures e funções}

        INSERT INTO GA_ItensCompra (FKCompra, FKProduto, Quantidade, PrecoUnitario)
        SELECT @IdCompra, FKProduto, Quantidade, PrecoUnitario
        FROM OPENJSON(@ItensJson)
        WITH (FKProduto INT '$.FKProduto', Quantidade INT '$.Quantidade', PrecoUnitario DECIMAL(18,2) '$.PrecoUnitario');

        COMMIT TRANSACTION;
        SELECT @IdCompra AS IdCompraGerada, 'Compra registrada com sucesso!' AS Mensagem;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

-- 3.3. Relatório de Estoque
CREATE PROCEDURE usp_RelatorioEstoqueCritico
AS
BEGIN
    SELECT 
        p.Nome AS Produto,
        e.QuantidadeAtual,
        e.QuantidadeMinima,
        (e.QuantidadeMinima - e.QuantidadeAtual) AS FaltamParaMinimo,
        e.StatusEstoque
    FROM GA_Estoque e
    INNER JOIN GA_Produtos p ON e.FKProdutos = p.IdProduto
    WHERE e.QuantidadeAtual <= e.QuantidadeMinima
    ORDER BY (e.QuantidadeMinima - e.QuantidadeAtual) DESC;
END;
GO