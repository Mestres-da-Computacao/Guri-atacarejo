IF DB_ID('SuperMercado') IS NULL
BEGIN
    CREATE DATABASE SuperMercado;
END;
GO

USE SuperMercado;
GO


-- Criação das tabelas

-- 1.1. Clientes
IF OBJECT_ID('GA_Clientes', 'U') IS NULL
BEGIN
    CREATE TABLE GA_Clientes (
        IdCliente INT IDENTITY(1,1) PRIMARY KEY,
        Nome VARCHAR(100) NOT NULL,
        CPF VARCHAR(14) UNIQUE NOT NULL,
        Genero CHAR(1) CHECK (Genero IN ('M', 'F', 'O')),
        Email VARCHAR(100),
        Celular VARCHAR(15),
        NivelFidelidade INT,
        TotalComprasAcumuladas INT
    );
END;
GO

-- 1.2. Cargos
IF OBJECT_ID('GA_Cargos', 'U') IS NULL
BEGIN
    CREATE TABLE GA_Cargos (
        IdCargo INT IDENTITY(1,1) PRIMARY KEY,
        Nome VARCHAR(50) NOT NULL,
        SalarioBase DECIMAL(18,2) NOT NULL,
        Nivel INT
    );
END;
GO

-- 1.3. Departamentos
IF OBJECT_ID('GA_Departamentos', 'U') IS NULL
BEGIN
    CREATE TABLE GA_Departamentos (
        IdDepartamento INT IDENTITY(1,1) PRIMARY KEY,
        Nome VARCHAR(50) NOT NULL
    );
END;
GO

-- 1.4. Funcionarios
IF OBJECT_ID('GA_Funcionarios', 'U') IS NULL
BEGIN
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
END;
GO

-- 1.5. Fornecedor
IF OBJECT_ID('GA_Fornecedor', 'U') IS NULL
BEGIN
    CREATE TABLE GA_Fornecedor (
        IdFornecedor INT IDENTITY(1,1) PRIMARY KEY,
        Nome VARCHAR(100) NOT NULL,
        CNPJ VARCHAR(18) UNIQUE NOT NULL,
        Email VARCHAR(100),
        Telefone VARCHAR(15),
        Endereco VARCHAR(200) NOT NULL
    );
END;
GO

-- 1.6. Categoria
IF OBJECT_ID('GA_Categoria', 'U') IS NULL
BEGIN
    CREATE TABLE GA_Categoria (
        IdCategoria INT IDENTITY(1,1) PRIMARY KEY,
        Nome VARCHAR(50) NOT NULL,
        Descricao VARCHAR(200)
    );
END;
GO

-- 1.7. Produtos
IF OBJECT_ID('GA_Produtos', 'U') IS NULL
BEGIN
    CREATE TABLE GA_Produtos (
        IdProduto INT IDENTITY(1,1) PRIMARY KEY,
        FKFornecedor INT NOT NULL,
        FKCategoria INT NOT NULL,
        Nome VARCHAR(100) NOT NULL,
        UnidadeMedida VARCHAR(20) NOT NULL,
        Preco DECIMAL(18,2) NOT NULL CHECK (Preco >= 0),
        DataValidade DATE,
        CONSTRAINT FK_GA_Produtos_Fornecedor FOREIGN KEY (FKFornecedor) REFERENCES GA_Fornecedor(IdFornecedor),
        CONSTRAINT FK_GA_Produtos_Categoria FOREIGN KEY (FKCategoria) REFERENCES GA_Categoria(IdCategoria)
    );
END;
GO

-- 1.8. estoque
IF OBJECT_ID('GA_Estoque', 'U') IS NULL
BEGIN
    CREATE TABLE GA_Estoque (
        IdEstoque INT IDENTITY(1,1) PRIMARY KEY,
        FKProdutos INT NOT NULL UNIQUE,
        QuantidadeAtual INT NOT NULL DEFAULT 0 CHECK (QuantidadeAtual >= 0),
        QuantidadeMinima INT NOT NULL DEFAULT 0 CHECK (QuantidadeMinima >= 0),
        StatusEstoque VARCHAR(20) DEFAULT 'Disponível' CHECK (StatusEstoque IN ('Disponível', 'Indisponível', 'Próximo ao mínimo')),
        CONSTRAINT FK_GA_Estoque_Produtos FOREIGN KEY (FKProdutos) REFERENCES GA_Produtos(IdProduto)
    );
END;
GO

-- 1.9. Compra
IF OBJECT_ID('GA_Compra', 'U') IS NULL
BEGIN
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
END;
GO

-- 1.10. ItensCompra
IF OBJECT_ID('GA_ItensCompra', 'U') IS NULL
BEGIN
    CREATE TABLE GA_ItensCompra (
        IdItemCompra INT IDENTITY(1,1) PRIMARY KEY,
        FKCompra INT NOT NULL,
        FKProduto INT NOT NULL,
        Quantidade INT NOT NULL CHECK (Quantidade >= 0),
        PrecoUnitario DECIMAL(18,2) NOT NULL CHECK (PrecoUnitario >= 0),
        Subtotal DECIMAL(18,2) NOT NULL,
        CONSTRAINT FK_GA_ItensCompra_Compra FOREIGN KEY (FKCompra) REFERENCES GA_Compra(IdCompra),
        CONSTRAINT FK_GA_ItensCompra_Produtos FOREIGN KEY (FKProduto) REFERENCES GA_Produtos(IdProduto)
    );
END;
GO

-- 1.11. Venda
IF OBJECT_ID('GA_Venda', 'U') IS NULL
BEGIN
    CREATE TABLE GA_Venda (
        IdVenda INT IDENTITY(1,1) PRIMARY KEY,
        FKCliente INT,
        FKFuncionario INT NOT NULL,  -- referencia IdFuncionario
        DataVenda DATE NOT NULL,
        ValorTotal DECIMAL(18,2) NOT NULL DEFAULT 0,
        FormaPagamento VARCHAR(50),
        StatusVenda VARCHAR(20) DEFAULT 'Pendente' CHECK (StatusVenda IN ('Pendente', 'Pago', 'Cancelado')),
        CONSTRAINT FK_GA_Venda_Clientes FOREIGN KEY (FKCliente) REFERENCES GA_Clientes(IdCliente),
        CONSTRAINT FK_GA_Venda_Funcionarios FOREIGN KEY (FKFuncionario) REFERENCES GA_Funcionarios(IdFuncionario)
    );
END;
GO

-- 1.12. ItensVenda
IF OBJECT_ID('GA_ItensVenda', 'U') IS NULL
BEGIN
    CREATE TABLE GA_ItensVenda (
        IdItemVenda INT IDENTITY(1,1) PRIMARY KEY,
        FKVenda INT NOT NULL,
        FKProduto INT NOT NULL,
        Quantidade INT NOT NULL CHECK (Quantidade >= 0),
        PrecoUnitario DECIMAL(18,2) NOT NULL CHECK (PrecoUnitario >= 0),
        Subtotal DECIMAL(18,2) NOT NULL,
        Cancelado BIT NOT NULL DEFAULT 0, -- 0 = item ativo, 1 = item cancelado
        CONSTRAINT FK_GA_ItensVenda_Venda FOREIGN KEY (FKVenda) REFERENCES GA_Venda(IdVenda),
        CONSTRAINT FK_GA_ItensVenda_Produtos FOREIGN KEY (FKProduto) REFERENCES GA_Produtos(IdProduto)
    );
END;
GO


-- 2. Triggers da resenha

-- ============================================================
-- SUMÁRIO - TRIGGERS
-- ============================================================
-- 2.1. trg_UpdateTotalVenda
--      Atualiza automaticamente o valor total da venda.
--
-- 2.2. trg_UpdateTotalCompra
--      Atualiza automaticamente o valor total da compra.
--
-- 2.3. trg_BaixarEstoqueVenda
--      Baixa automaticamente a quantidade de produtos do estoque
--      quando uma venda é registrada.
--
-- 2.4. trg_AdicionarEstoqueCompra
--      Adiciona automaticamente os produtos ao estoque
--      quando uma compra é registrada.
--
-- 2.5. trg_AtualizarEstoqueMinimo
--      Atualiza o status do estoque conforme a quantidade atual
--      e a quantidade mínima definida.
--
-- 2.6. trg_DevolverEstoque_ItemCancelado
--      Devolve ao estoque os produtos de itens de venda cancelados.
--
-- 2.7. trg_CancelarItensAoCancelarVenda
--      Cancela automaticamente todos os itens ativos quando
--      uma venda inteira é cancelada.
-- ============================================================


-- Remove as antigas triggers de cálculo de subtotal, caso ainda existam
IF OBJECT_ID('trg_CalcSubtotal_ItensVenda', 'TR') IS NOT NULL
BEGIN
    DROP TRIGGER trg_CalcSubtotal_ItensVenda;
END;
GO

IF OBJECT_ID('trg_CalcSubtotal_ItensCompra', 'TR') IS NOT NULL
BEGIN
    DROP TRIGGER trg_CalcSubtotal_ItensCompra;
END;
GO


-- 2.1. Atualizar ValorTotal da Venda
CREATE OR ALTER TRIGGER trg_UpdateTotalVenda
ON GA_ItensVenda
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    ;WITH VendasAfetadas AS
    (
        SELECT FKVenda AS IdVenda
        FROM inserted

        UNION

        SELECT FKVenda AS IdVenda
        FROM deleted
    ),
    Totais AS
    (
        SELECT
            iv.FKVenda,
            SUM(iv.Subtotal) AS Total
        FROM GA_ItensVenda iv
        INNER JOIN VendasAfetadas va
            ON iv.FKVenda = va.IdVenda
        WHERE iv.Cancelado = 0
        GROUP BY iv.FKVenda
    )
    UPDATE v
    SET v.ValorTotal = ISNULL(t.Total, 0)
    FROM GA_Venda v
    INNER JOIN VendasAfetadas va
        ON v.IdVenda = va.IdVenda
    LEFT JOIN Totais t
        ON t.FKVenda = v.IdVenda;
END;
GO


-- 2.2. Atualizar ValorTotal da Compra
CREATE OR ALTER TRIGGER trg_UpdateTotalCompra
ON GA_ItensCompra
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

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


-- 2.3. Baixar Estoque(ao vender)
CREATE OR ALTER TRIGGER trg_BaixarEstoqueVenda
ON GA_ItensVenda
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

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


-- 2.4. Adicionar Estoque (ao comprar)
CREATE OR ALTER TRIGGER trg_AdicionarEstoqueCompra
ON GA_ItensCompra
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

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


-- 2.5. olhar estoque minimo e atualizar status
CREATE OR ALTER TRIGGER trg_AtualizarEstoqueMinimo
ON GA_Estoque
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE e
    SET StatusEstoque =
        CASE
            WHEN e.QuantidadeAtual <= 0 THEN 'Indisponível'
            WHEN e.QuantidadeAtual <= e.QuantidadeMinima THEN 'Próximo ao mínimo'
            ELSE 'Disponível'
        END
    FROM GA_Estoque e
    INNER JOIN inserted i
        ON e.IdEstoque = i.IdEstoque;
END;
GO


-- 2.6. Devolver ao estoque os itens que forem cancelados (individualmente ou em cascata pela venda inteira)
CREATE OR ALTER TRIGGER trg_DevolverEstoque_ItemCancelado
ON GA_ItensVenda
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT UPDATE(Cancelado)
        RETURN;

    -- Só age sobre itens que ACABARAM de ser cancelados (0 -> 1), evitando devolução duplicada
    IF NOT EXISTS
    (
        SELECT 1
        FROM inserted i
        INNER JOIN deleted d ON i.IdItemVenda = d.IdItemVenda
        WHERE i.Cancelado = 1 AND d.Cancelado = 0
    )
        RETURN;

    UPDATE e
    SET e.QuantidadeAtual = e.QuantidadeAtual + x.QuantidadeDevolvida
    FROM GA_Estoque e
    INNER JOIN
    (
        SELECT
            i.FKProduto,
            SUM(i.Quantidade) AS QuantidadeDevolvida
        FROM inserted i
        INNER JOIN deleted d ON i.IdItemVenda = d.IdItemVenda
        WHERE i.Cancelado = 1 AND d.Cancelado = 0
        GROUP BY i.FKProduto
    ) x
        ON e.FKProdutos = x.FKProduto;
END;
GO


-- 2.7. Ao cancelar a venda inteira, cancelar automaticamente todos os itens ainda ativos
CREATE OR ALTER TRIGGER trg_CancelarItensAoCancelarVenda
ON GA_Venda
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT UPDATE(StatusVenda)
        RETURN;

    -- Só age sobre vendas que ACABARAM de ser marcadas como 'Cancelado'
    IF NOT EXISTS
    (
        SELECT 1
        FROM inserted i
        INNER JOIN deleted d ON i.IdVenda = d.IdVenda
        WHERE i.StatusVenda = 'Cancelado' AND d.StatusVenda <> 'Cancelado'
    )
        RETURN;

    -- Marca os itens como cancelados; a trigger trg_DevolverEstoque_ItemCancelado
    -- devolve a quantidade ao estoque automaticamente (nested triggers)
    UPDATE iv
    SET iv.Cancelado = 1
    FROM GA_ItensVenda iv
    INNER JOIN inserted i ON iv.FKVenda = i.IdVenda
    INNER JOIN deleted d ON i.IdVenda = d.IdVenda
    WHERE i.StatusVenda = 'Cancelado'
      AND d.StatusVenda <> 'Cancelado'
      AND iv.Cancelado = 0;
END;
GO


-- 3. Procedures do andersonresenhudo

-- SUMÁRIO - PROCEDURES

-- 3.1. usp_RegistrarVenda
--      Registra uma nova venda, valida o estoque e insere
--      os itens da venda.
--
-- 3.2. usp_RegistrarCompra
--      Registra uma nova compra e insere os itens comprados,
--      adicionando os produtos ao estoque.
--
-- 3.3. usp_RelatorioEstoqueCritico
--      Exibe os produtos que estão abaixo ou no limite
--      do estoque mínimo.
--
-- 3.4. usp_CancelarVenda
--      Cancela uma venda inteira e devolve ao estoque
--      todos os seus itens ativos.
--
-- 3.5. usp_CancelarItensVenda
--      Cancela apenas os itens selecionados de uma venda
--      e devolve suas quantidades ao estoque.


-- 3.1. Registrar Venda(com validação de estoque)
CREATE OR ALTER PROCEDURE usp_RegistrarVenda
    @FKCliente INT = NULL,
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

        SET @IdVenda = SCOPE_IDENTITY();

        -- Insere os itens usando o preço cadastrado em GA_Produtos
        INSERT INTO GA_ItensVenda
        (
            FKVenda,
            FKProduto,
            Quantidade,
            PrecoUnitario,
            Subtotal
        )
        SELECT
            @IdVenda,
            j.FKProduto,
            j.Quantidade,
            p.Preco,
            j.Quantidade * p.Preco
        FROM OPENJSON(@ItensJson)
        WITH
        (
            FKProduto INT '$.FKProduto',
            Quantidade INT '$.Quantidade'
        ) j
        INNER JOIN GA_Produtos p
            ON p.IdProduto = j.FKProduto;

        -- Atualiza status da venda
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
CREATE OR ALTER PROCEDURE usp_RegistrarCompra
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

        INSERT INTO GA_Compra
        (
            FKFornecedor,
            FKFuncionario,
            DataCompra,
            ValorTotal,
            FormaPagamento,
            DataEntrega,
            StatusCompra
        )
        VALUES
        (
            @FKFornecedor,
            @FKFuncionario,
            GETDATE(),
            0,
            @FormaPagamento,
            @DataEntrega,
            'Pago'
        );

        SET @IdCompra = SCOPE_IDENTITY();

        INSERT INTO GA_ItensCompra
        (
            FKCompra,
            FKProduto,
            Quantidade,
            PrecoUnitario,
            Subtotal
        )
        SELECT
            @IdCompra,
            j.FKProduto,
            j.Quantidade,
            p.Preco,
            j.Quantidade * p.Preco
        FROM OPENJSON(@ItensJson)
        WITH
        (
            FKProduto INT '$.FKProduto',
            Quantidade INT '$.Quantidade'
        ) j
        INNER JOIN GA_Produtos p
            ON p.IdProduto = j.FKProduto;

        COMMIT TRANSACTION;

        SELECT
            @IdCompra AS IdCompraGerada,
            'Compra registrada com sucesso!' AS Mensagem;

    END TRY
    BEGIN CATCH

        IF XACT_STATE() <> 0
            ROLLBACK TRANSACTION;

        THROW;
    END CATCH
END;
GO


-- 3.4. Cancelar a venda inteira (devolve TODOS os itens ativos ao estoque)
-- Ex.: cliente sem dinheiro cancela a compra toda.
CREATE OR ALTER PROCEDURE usp_CancelarVenda
    @IdVenda INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        IF NOT EXISTS
        (
            SELECT 1
            FROM GA_Venda
            WHERE IdVenda = @IdVenda
        )
        BEGIN
            ROLLBACK TRANSACTION;
            RAISERROR('Venda não encontrada.', 16, 1);
            RETURN;
        END;

        IF EXISTS
        (
            SELECT 1
            FROM GA_Venda
            WHERE IdVenda = @IdVenda
              AND StatusVenda = 'Cancelado'
        )
        BEGIN
            ROLLBACK TRANSACTION;
            RAISERROR('Essa venda já está cancelada.', 16, 1);
            RETURN;
        END;

        -- A trigger trg_CancelarItensAoCancelarVenda cancela os itens,
        -- e a trigger trg_DevolverEstoque_ItemCancelado devolve o estoque
        UPDATE GA_Venda
        SET StatusVenda = 'Cancelado'
        WHERE IdVenda = @IdVenda;

        COMMIT TRANSACTION;

        SELECT
            @IdVenda AS IdVenda,
            'Venda cancelada e itens devolvidos ao estoque.' AS Mensagem;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0
            ROLLBACK TRANSACTION;

        THROW;
    END CATCH
END;
GO


-- 3.5. Cancelar apenas alguns itens de uma venda (devolve só os itens informados e conclui a venda)
CREATE OR ALTER PROCEDURE usp_CancelarItensVenda
    @IdVenda INT,
    @ItensJson NVARCHAR(MAX) -- lista de IdItemVenda pra cancelar, exemplo: [1, 2, 5]
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        IF NOT EXISTS
        (
            SELECT 1
            FROM GA_Venda
            WHERE IdVenda = @IdVenda
        )
        BEGIN
            ROLLBACK TRANSACTION;
            RAISERROR('Venda não encontrada.', 16, 1);
            RETURN;
        END;

        IF EXISTS
        (
            SELECT 1
            FROM GA_Venda
            WHERE IdVenda = @IdVenda
              AND StatusVenda = 'Cancelado'
        )
        BEGIN
            ROLLBACK TRANSACTION;
            RAISERROR('Não é possível cancelar itens de uma venda já cancelada.', 16, 1);
            RETURN;
        END;

        -- A trg_DevolverEstoque_ItemCancelado devolve ao estoque somente a quantidade dos itens marcados aqui
        UPDATE iv
        SET iv.Cancelado = 1
        FROM GA_ItensVenda iv
        INNER JOIN OPENJSON(@ItensJson)
            WITH (IdItemVenda INT '$') j
            ON iv.IdItemVenda = j.IdItemVenda
        WHERE iv.FKVenda = @IdVenda
          AND iv.Cancelado = 0;

        COMMIT TRANSACTION;

        SELECT
            @IdVenda AS IdVenda,
            'Itens cancelados e devolvidos ao estoque. Venda concluída normalmente.' AS Mensagem;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0
            ROLLBACK TRANSACTION;

        THROW;
    END CATCH
END;
GO


-- Exemplos de utilização das Procedures


-- Registrar uma nova venda.
-- O @ItensJson permite informar um ou vários produtos.
-- EXEC usp_RegistrarVenda
--     @FKCliente = 1,
--     @FKFuncionario = 2,
--     @FormaPagamento = 'Pix',
--     @ItensJson = '[
--         {"FKProduto": 1, "Quantidade": 2}
--     ]';


-- Registrar uma nova compra.
-- O @ItensJson permite informar um ou vários produtos.
-- EXEC usp_RegistrarCompra
--     @FKFornecedor = 1,
--     @FKFuncionario = 2,
--     @FormaPagamento = 'Boleto',
--     @DataEntrega = '2026-09-05',
--     @ItensJson = '[
--         {"FKProduto": 1, "Quantidade": 50},
--         {"FKProduto": 2, "Quantidade": 70}
--     ]';

-- Cancelar uma venda inteira.
-- Todos os itens ativos da venda serão cancelados e devolvidos ao estoque.
-- EXEC usp_CancelarVenda
--     @IdVenda = 15;


-- Cancelar apenas alguns itens de uma venda.
-- Neste exemplo, os itens 22 e 24 serão cancelados e devolvidos ao estoque.
-- EXEC usp_CancelarItensVenda
--     @IdVenda = 15,
--     @ItensJson = '[22, 24]';


-- VIEWS

CREATE OR ALTER VIEW vw_EstoqueCritico
AS
SELECT 
    p.Nome AS Produto,
    e.QuantidadeAtual,
    e.QuantidadeMinima,
    (e.QuantidadeMinima - e.QuantidadeAtual) AS FaltamParaMinimo,
    e.StatusEstoque
FROM GA_Estoque e
INNER JOIN GA_Produtos p 
    ON e.FKProdutos = p.IdProduto
WHERE e.QuantidadeAtual <= e.QuantidadeMinima;
GO

-- COMO USAR A VIEW
-- SELECT *
-- FROM vw_EstoqueCritico
-- ORDER BY FaltamParaMinimo DESC;