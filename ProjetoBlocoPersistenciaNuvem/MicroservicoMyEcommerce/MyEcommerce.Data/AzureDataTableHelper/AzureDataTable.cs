using Azure.Data.Tables;
using Microsoft.Extensions.Configuration;

namespace MyEcommerce.Data.AzureDataTableHelper;

public class AzureDataTable : IAzureDataTable
{
    private readonly IConfiguration _configuration;

    public AzureDataTable(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<TableClient> CriarClientComAzureCosmosDB(string nomeTabela)
    {
        TableServiceClient tableServiceClient = new(_configuration["AzureCosmosDBConnection"]);
        TableClient tableClient = tableServiceClient.GetTableClient(tableName: nomeTabela);
        await tableClient.CreateIfNotExistsAsync();
        return tableClient;
    }
}
