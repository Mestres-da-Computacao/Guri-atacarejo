USE db_250405;
GO

-- ============================================================
-- 1. TABELAS INDEPENDENTES (Sem chaves estrangeiras)
-- ============================================================

-- 1.1. GA_Cargos
INSERT INTO GA_Cargos (Nome, SalarioBase, Nivel) VALUES 
('Repositor', 2000.00, 1),
('Operador de Caixa', 1800.00, 1),
('Gerente', 5000.00, 3),
('Açougueiro', 2500.00, 2),
('Auxiliar de Limpeza', 1500.00, 1);

-- 1.2. GA_Departamentos
INSERT INTO GA_Departamentos (Nome) VALUES 
('Estoque'),
('Frente de Caixa'),
('Gerência'),
('Açougue'),
('Limpeza');

-- 1.3. GA_Clientes
INSERT INTO GA_Clientes (Nome, CPF, Genero, Email, Celular, NivelFidelidade, TotalComprasAcumuladas) VALUES 
('João Silva', '111.111.111-11', 'M', 'joao@email.com', '11911111111', 1, 0),
('Maria Souza', '222.222.222-22', 'F', 'maria@email.com', '11922222222', 2, 0),
('Carlos Pereira', '333.333.333-33', 'M', 'carlos@email.com', '11933333333', 1, 0),
('Ana Costa', '444.444.444-44', 'F', 'ana@email.com', '11944444444', 3, 0),
('Pedro Santos', '555.555.555-55', 'M', 'pedro@email.com', '11955555555', 1, 0);

-- 1.4. GA_Fornecedor
INSERT INTO GA_Fornecedor (Nome, CNPJ, Email, Telefone, Endereco) VALUES 
('Ambev S.A.', '11.111.111/0001-11', 'contato@ambev.com', '1133333333', 'Rua das Bebidas, 100'),
('Coca-Cola Company', '22.222.222/0001-22', 'contato@coca.com', '1144444444', 'Av. Refrigerantes, 200'),
('Nestlé Brasil', '33.333.333/0001-33', 'contato@nestle.com', '1155555555', 'Rua dos Doces, 300'),
('BRF (Perdigão)', '44.444.444/0001-44', 'contato@brf.com', '1166666666', 'Rod. das Carnes, 400'),
('Unilever', '55.555.555/0001-55', 'contato@unilever.com', '1177777777', 'Av. Limpeza, 500');

-- 1.5. GA_Categoria
INSERT INTO GA_Categoria (Nome, Descricao) VALUES 
('Bebidas', 'Bebidas alcoólicas e não alcoólicas'),
('Doces e Guloseimas', 'Chocolates, balas e biscoitos'),
('Carnes e Frios', 'Carnes bovinas, suínas e aves'),
('Limpeza', 'Produtos de limpeza doméstica'),
('Higiene Pessoal', 'Produtos de higiene e beleza');


-- ============================================================
-- 2. TABELAS DEPENDENTES NÍVEL 1
-- ============================================================

-- 2.1. GA_Funcionarios (Depende de Cargos e Departamentos)
INSERT INTO GA_Funcionarios (FKCargo, FKDepartamento, Nome, CPF, DataNascimento, Genero, Telefone, Email, Senha, DataEmissao, Salario, StatusFuncionamento) VALUES 
(1, 1, 'Roberto Alves', '666.666.666-66', '1990-05-15', 'M', '11966666666', 'roberto@email.com', '123', '2023-01-10', 2000.00, 'Ativo'),
(2, 2, 'Fernanda Lima', '777.777.777-77', '1995-08-20', 'F', '11977777777', 'fernanda@email.com', '123', '2023-02-15', 1800.00, 'Ativo'),
(3, 3, 'Marcos Paulo', '888.888.888-88', '1985-03-10', 'M', '11988888888', 'marcos@email.com', '123', '2022-11-01', 5000.00, 'Ativo'),
(4, 4, 'Juliana Mendes', '999.999.999-99', '1992-12-05', 'F', '11999999999', 'juliana@email.com', '123', '2023-05-20', 2500.00, 'Ativo'),
(5, 5, 'José Souza', '000.000.000-00', '1980-01-25', 'M', '11900000000', 'jose@email.com', '123', '2021-06-15', 1500.00, 'Ativo');

-- 2.2. GA_Produtos (Depende de Fornecedor e Categoria)
INSERT INTO GA_Produtos (FKFornecedor, FKCategoria, Nome, UnidadeMedida, Preco) VALUES 
(1, 1, 'Cerveja Brahma Lata 350ml', 'UN', 3.50),
(2, 1, 'Refrigerante Coca-Cola 2L', 'UN', 8.50),
(3, 2, 'Chocolate Nestlé Crunch', 'UN', 6.00),
(4, 3, 'Peito de Frango Congelado', 'KG', 15.90),
(5, 4, 'Detergente Ypê 500ml', 'UN', 2.80);


-- ============================================================
-- 3. TABELAS DEPENDENTES NÍVEL 2 (Lotes e Estoque)
-- ============================================================

-- 3.1. GA_Lote (Depende de Fornecedor e Produto)
-- Nota: A coluna [Preço] não é inserida aqui pois a trigger calculará o valor.
INSERT INTO GA_Lote (FKFornecedores, FKProduto, Quantidade, DataValidade) VALUES 
(1, 1, 200, '2026-12-31'),
(2, 2, 100, '2026-10-15'),
(3, 3, 150, '2026-05-20'),
(4, 4, 50, '2026-08-30'),
(5, 5, 300, '2027-01-01');

-- 3.2. GA_Estoque (Depende de Lote)
-- Nota: Inserimos com QuantidadeAtual = 0. A trigger trg_AdicionarEstoqueCompra 
-- vai abastecer esse estoque quando inserirmos os ItensCompra no passo seguinte.
INSERT INTO GA_Estoque (FKLote, QuantidadeAtual, QuantidadeMinima) VALUES 
(1, 0, 20),
(2, 0, 15),
(3, 0, 30),
(4, 0, 10),
(5, 0, 50);


-- ============================================================
-- 4. TABELAS DEPENDENTES NÍVEL 3 (Compras e Vendas)
-- ============================================================

-- 4.1. GA_Compra (Depende de Fornecedor e Funcionario)
INSERT INTO GA_Compra (FKFornecedor, FKFuncionario, DataCompra, StatusCompra, FormaPagamento, DataEntrega) VALUES 
(1, 1, '2025-10-01', 'Pago', 'Boleto', '2025-10-05'),
(2, 1, '2025-10-02', 'Pago', 'Pix', '2025-10-06'),
(3, 2, '2025-10-03', 'Pendente', 'Cartão', '2025-10-10'),
(4, 4, '2025-10-04', 'Pago', 'Boleto', '2025-10-07'),
(5, 5, '2025-10-05', 'Pago', 'Pix', '2025-10-08');

-- 4.2. GA_ItensCompra (Depende de Compra e Lote)
-- Nota: Inserir esses itens vai acionar as triggers para:
-- 1. Calcular o valor total da compra;
-- 2. Adicionar a quantidade ao estoque (que estava 0);
-- 3. Calcular o preço total do Lote.
INSERT INTO GA_ItensCompra (FKCompra, FKLote, Quantidade, PrecoUnitario, Subtotal) VALUES 
(1, 1, 200, 2.50, 500.00),
(2, 2, 100, 5.00, 500.00),
(3, 3, 150, 4.00, 600.00),
(4, 4, 50, 10.00, 500.00),
(5, 5, 300, 1.50, 450.00);

-- 4.3. GA_Venda (Depende de Cliente e Funcionario)
INSERT INTO GA_Venda (FKCliente, FKFuncionario, DataVenda, FormaPagamento, StatusVenda) VALUES 
(1, 2, '2025-10-10', 'Pix', 'Pago'),
(2, 2, '2025-10-11', 'Cartão', 'Pago'),
(3, 3, '2025-10-12', 'Dinheiro', 'Pago'),
(4, 2, '2025-10-13', 'Pix', 'Pendente'),
(5, 3, '2025-10-14', 'Cartão', 'Pago');

-- 4.4. GA_ItensVenda (Depende de Venda e Lote)
-- Nota: Inserir esses itens vai acionar as triggers para:
-- 1. Calcular o valor total da venda;
-- 2. Baixar a quantidade do estoque (que foi abastecido no passo 4.2).
INSERT INTO GA_ItensVenda (FKVenda, FKLote, Quantidade, PrecoUnitario, Subtotal, Cancelado) VALUES 
(1, 1, 2, 3.50, 7.00, 0),
(2, 2, 1, 8.50, 8.50, 0),
(3, 3, 3, 6.00, 18.00, 0),
(4, 4, 1, 15.90, 15.90, 0),
(5, 5, 2, 2.80, 5.60, 0);

GO