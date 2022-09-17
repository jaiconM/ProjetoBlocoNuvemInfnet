
1 - Criar um database com nome MyEcommerceDB

2 - Atualizar a connectionString em MyEcommerceAuthorize.Api > appsettings.json

3 - Via Tools > Nuget Package Manager > Package Manager Console
	A - Para instalar as ferramentas para criar migrations e atualizar a base de dados:
	 > Install-Package Microsoft.EntityFrameworkCore.Tools

	B - Setar como Defautl project no Package Manager Console o MyEcommerceAuthorize.Data

	C - Para criar/atualizar as migrations:
	 > Add-Migration NomeDaMigration

	D - Para atualizar a base de dados (aplicar as migrations):
	 > Update-Database
