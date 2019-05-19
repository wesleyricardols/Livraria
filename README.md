# Livraria

1) Arquitetura e Tecnologias utilizadas. <br />
	a) Back-end
        <ul>
            <li>Arquitetura DDD (Domain-Driven Design);</li>
            <li>DI (Dependency Injection);</li>
            <li>DTO (Data-Transfer-Object);</li>
            <li>Repositório;</li>
            <li>API .NET Core 2.2</li>
            <li>Entity Framework Core 2.2.4</li>
        </ul>
		
	b) Front-end
        <ul>
		    <li>Bootstrap (Framework CSS)</li>
            <li>Knockout JS (Framework Javascript MVVM)</li>
        </ul>
		
	c) Banco de Dados
        <ul>
		    <li>SQL Server 2017</li>
        </ul>
		
2) Instruções de Deploy
	
	Passos para a publicação do Projeto (Visual Studio 2019):
    <ol>
      <li>Botão direito no Projeto que deseja realizar a publicação</li>
      <li>Clicar em "Publish/Publicar"</li>
      <li>Clicar em New/Novo (para criar um novo Perfil de Publicação)</li>
      <li>Selecionar a opção "Folder/Pasta", e indicar um diretório onde deverá ser gerado os arquivos para publicação da Aplicação</li>
      <li>Clicar em "Publish/Publicar"</li>
      <li>Subir os arquivos para o servidor.</li>
    </ol>

2.1) Banco de Dados <br />
	Criar um banco de dados (a partir do script já existente no projeto)<br />
	Caminho: 3 - Infraestrutura / Livraria.Infrastructure / Data / Script Criação.sql<br />
	<br />
	Após a criação do banco de dados no SQL Server deverá ser alterado a string de conexão no projeto na linha 28.<br />
	Caminho: 3 - Infraestrutura / Livraria.Infrastructure / Data / LivrariaContext.cs
	
2.2) Publicação da API <br />
	Projeto a ser publicado: "Livraria.API". <br />
	Caminho: 4 - Services/Livraria.API. <br />
	<br />
	Seguir os "Passos para a publicação do Projeto (Visual Studio 2019)" indicados no início do item 2<br />

2.3) Publicação do Projeto Web <br />
	Já com a URL (o caminho) da API, alterar a Url "Base" no projeto no arquivo de configuração do projeto "Livraria.Web" <br />
	Caminho: 1 - UI/Livraria.Web/appsettings.json <br />
	<br />
	Após alterar a url no arquivo appsettings.json, Seguir os "Passos para a publicação do Projeto (Visual Studio 2019)" indicados no início do item 2.
