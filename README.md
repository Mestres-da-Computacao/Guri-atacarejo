# Guri-atacarejo
Trabalho do 3° bimestre de DS e BD

O projeto apresenta um sistema funcional de mercado no windows form, que é conectado a um servidor de banco de dados.

## Banco de dados local

O aplicativo usa a instância `(localdb)\MSSQLLocalDB` e o catálogo `db_250405`, autenticando com a conta do Windows atual. Para preparar o banco em uma máquina local:

1. Instale o SQL Server Express LocalDB.
2. No SQL Server Management Studio, conecte-se a `(localdb)\MSSQLLocalDB` usando autenticação do Windows.
3. Abra e execute o arquivo `SuperMercado.sql` deste repositório nessa conexão. O script cria `db_250405` e suas tabelas se ainda não existirem.

Se o aplicativo ainda não conseguir abrir o catálogo, confirme que o script foi executado sem erros na mesma instância LocalDB configurada acima.
