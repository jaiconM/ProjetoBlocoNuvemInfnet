using Azure.Data.Tables;

namespace MyEcommerce.Data.AzureDataTableHelper;
public interface IAzureDataTable
{
    Task<TableClient> CriarClientComAzureCosmosDB(string nomeTabela);
}