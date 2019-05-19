# Livraria

1) Arquitetura e Tecnologias utilizadas:
	a) Back-end
		Arquitetura DDD (Domain-Driven Design);
		DI (Dependency Injection);
		DTO (Data-Transfer-Object);
		Repositório;
		API .NET Core 2.2
		Entity Framework Core 2.2.4
		
	b) Front-end
		Bootstrap (Framework CSS)
		Knockout JS (Framework Javascript MVVM)
		
	c) Banco de Dados
		SQL Server 2017

		
2) Instruções de Deploy
	
	Passos para a publicação do Projeto (Visual Studio 2019):
	a)Botão direito no Projeto que deseja realizar a publicação
	b) Clicar em "Publish/Publicar"
	c) Clicar em New/Novo (para criar um novo Perfil de Publicação)
	d) Selecionar a opção "Folder/Pasta", e indicar um diretório onde deverá ser gerado os arquivos para publicação da Aplicação
	e) Clicar em "Publish/Publicar"
	f) Subir os arquivos para o servidor.

2.1) Banco de Dados
	Criar um banco de dados (a partir do script já existente no projeto)
	Caminho: 3 - Infraestrutura / Livraria.Infrastructure / Data / Script Criação.sql
	
	Após a criação do banco de dados no SQL Server deverá ser alterado a string de conexão no projeto na linha 28.
	Caminho: 3 - Infraestrutura / Livraria.Infrastructure / Data / LivrariaContext.cs
	
2.2) Publicação da API
	Projeto a ser publicado: "Livraria.API". 
	Caminho: 4 - Services/Livraria.API.
	
	Seguir os "Passos para a publicação do Projeto (Visual Studio 2019)" indicados no início do item 2

2.3) Publicação do Projeto Web
	Já com a URL (o caminho) da API, alterar a Url "Base" no projeto no arquivo de configuração do projeto "Livraria.Web"
	Caminho: 1 - UI/Livraria.Web/appsettings.json
	
	Após alterar a url no arquivo appsettings.json, Seguir os "Passos para a publicação do Projeto (Visual Studio 2019)" indicados no início do item 2.
