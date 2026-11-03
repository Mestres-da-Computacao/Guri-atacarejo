# Guri-atacarejo
Trabalho do 3° bimestre de DS e BD

O projeto apresenta um sistema funcional de mercado no windows form, que é conectado a um servidor de banco de dados.

## Banco de dados local

O aplicativo usa a instância `(localdb)\MSSQLLocalDB` e o catálogo `db_250405`, autenticando com a conta do Windows atual. Para preparar o banco em uma máquina local:

1. Instale o SQL Server Express LocalDB.
2. No SQL Server Management Studio, conecte-se a `(localdb)\MSSQLLocalDB` usando autenticação do Windows.
3. Abra e execute o arquivo `SuperMercado.sql` deste repositório nessa conexão. O script cria `db_250405` e suas tabelas se ainda não existirem.

Se o aplicativo ainda não conseguir abrir o catálogo, confirme que o script foi executado sem erros na mesma instância LocalDB configurada acima.

## Sistema de gestão de mercado

O projeto de sistema de mercado, desenvolvido pelo nosso grupo foi feito para uma rede de mercado fictícia chamada “Guri Atacadista”.
O projeto consiste em um sistema de caixa, de gerenciamento financeiro, clientes e funcionários. Ao abri-lo pode-se ver uma splash screen que abre o sistema de login dos funcionários, onde cada funcionário tem cadastrado um nível, enquanto maior o nível mais funções podem ser acessadas. Pela tela de menu é possível acessar:
•	Sistema de caixa, que consiste nos botões de adicionar produto (informando o código do produto e do lote e a quantidade), alterar produto (muda a quantidade ou remove o item), cancelar venda e finalizar venda. A tela mostra a lista de produtos da venda com preço unitário e total, os detalhes do produto selecionado (nome, preço, unidade de medida e validade), o cliente da venda (ou “Não registrado”), a forma de pagamento (com campo de troco quando for dinheiro) e o valor total. O sistema confere o estoque do lote antes de aceitar a quantidade e, ao finalizar, registra a venda no banco de dados, que baixa o estoque automaticamente;
•	Clientes, onde é possível registrar um cliente (nome, CPF, gênero, e-mail e telefone, com validação dos dados), fazer o login do cliente pelo CPF para vinculá-lo à venda e fazer o logout do cliente;
•	Funcionários, com a opção de logout, que encerra a sessão e volta para a tela de login;
•	Mais opções (visível apenas para funcionários de nível maior que 1), com o registro de produtos, o registro de funcionários, o registro de fornecedores, o registro de lotes e a compra de lotes;
•	Relatórios (também restrito a níveis maiores que 1), com o relatório de movimentação financeira e o relatório de fluxo de estoque.
Tecnologias utilizadas
•	Linguagem C# com Windows Forms `.NET Framework`, em uma solução do Visual Studio `Guri_atacarejo.sln`;
•	Banco de dados SQL Server;
•	Acesso aos dados por DataSets tipados e TableAdapters, além de SqlClient em algumas telas;
•	Componentes visuais personalizados (caixas de texto, listas e datas com cantos arredondados) e uma classe de responsividade que ajusta os formulários ao tamanho da tela.

## Fluxo de funcionamento

1. Ao abrir o programa, a splash screen é exibida por cerca de 4 segundos e em seguida abre a tela de login.
2. O funcionário informa usuário e senha. Se forem válidos, o sistema guarda na sessão o id, o nome e o nível (cargo) do funcionário e abre o painel de caixa; caso contrário, mostra a mensagem de login inválido.
3. No painel, o funcionário monta a venda adicionando produtos. Cada item é ligado a um lote, e o sistema impede quantidades maiores que o estoque disponível do lote.
4. Opcionalmente, o cliente é identificado pelo CPF. Depois o funcionário escolhe a forma de pagamento e finaliza a venda.
5. A venda é gravada pelo procedimento usp_RegistrarVenda, que valida o estoque de cada lote em uma única transação. Gatilhos (triggers) atualizam o total da venda, baixam o estoque e atualizam o total acumulado de compras do cliente.
Controle de acesso
Cada funcionário possui um cargo com um nível. O nível 1 acessa apenas o caixa e as opções de clientes e funcionários (logout). Níveis acima de 1 também acessam os menus “Mais opções” e “Relatórios”.
Telas do sistema
•	Splash screen: tela inicial com a logo do Guri Atacadista, que abre o login.
•	Login de funcionários: usuário e senha, com opção de sair do sistema.
•	Painel (caixa): tela principal de vendas, descrita acima.
•	Registro de clientes e login de cliente: cadastro com validação de CPF (formato 123.456.789-00), e-mail e telefone, e identificação do cliente na venda.
•	Cadastro de funcionários: nome, CPF, data de nascimento, gênero, telefone, e-mail, departamento, cargo e salário.
•	Cadastro de produtos: código, nome, descrição, categoria, preço e quantidade.
•	Registro de fornecedores: nome, CNPJ, e-mail, telefone e endereço.
•	Registro de lotes: fornecedor, produto, quantidade, data de validade (não pode ser anterior a hoje) e custo.
•	Compra de lotes: tela de compra de mercadorias de um fornecedor, com cartões de produtos, total da compra e atalhos para registrar lote e fornecedor.
•	Relatório de movimentação financeira: lista as compras e vendas com data, tipo e valor, com filtro por dia, mês ou ano.
•	Relatório de estoque: mostra o estoque de cada produto (somando seus lotes) e, ao clicar em um produto, as compras e vendas dele no período escolhido.

## Banco de dados

O banco do supermercado é criado pelo script SuperMercado.sql, na raiz do projeto. As tabelas, todas com o prefixo GA (Guri Atacarejo), são:
•	GA_Clientes: dados do cliente, nível de fidelidade e total de compras acumuladas;
•	GA_Cargos, GA_Departamentos e GA_Funcionarios: estrutura de pessoal, com senha, salário e status (Ativo, Inativo ou Afastado);
•	GA_Fornecedor, GA_Categoria e GA_Produtos: fornecedores e catálogo de produtos, com unidade de medida e preço;
•	GA_Lote e GA_Estoque: cada lote tem quantidade, validade e preço; o estoque é controlado por lote, com quantidade atual, mínima e status (Disponível, Indisponível ou Próximo ao mínimo);
•	GA_Compra e GA_ItensCompra: compras de mercadorias de fornecedores e seus itens;
•	GA_Venda e GA_ItensVenda: vendas, formas de pagamento, status (Pendente, Pago ou Cancelado) e itens, que podem ser cancelados individualmente.
Triggers: cálculo automático do total de vendas e compras; baixa do estoque do lote na venda; entrada no estoque na compra; atualização do status do estoque conforme a quantidade mínima; devolução ao estoque de itens cancelados; cancelamento dos itens quando a venda inteira é cancelada; e atualização do total acumulado de compras do cliente.
Procedimentos armazenados: usp_RegistrarVenda, usp_RegistrarCompra, usp_RelatorioEstoqueCritico, usp_CancelarVenda e usp_CancelarItensVenda.
Como executar
•	Instalar o SQL Server Express LocalDB;
•	No SQL Server Management Studio, conectar em `(localdb)\MSSQLLocalDB` com autenticação do Windows e executar o arquivo `SuperMercado.sql`;
•	Abrir a solução `Guri_atacarejo.sln` no Visual Studio e executar o projeto.

