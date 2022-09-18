using Azure.Data.Tables;
using MyEcommerce.Data.AzureDataTableHelper;
using MyEcommerce.Domain;
using MyEcommerce.Domain.Repository;

namespace MyEcommerce.Data.Repository;
public class ProdutoRepository : IProdutoRepository
{
    private const string NomeTabela = "Produto";
    private const string PartitionKey = "Produto";
    private readonly IAzureDataTable _azureDataTable;

    public ProdutoRepository(IAzureDataTable azureDataTable)
    {
        _azureDataTable = azureDataTable;
    }

    public async Task<Produto> Create(Produto produto)
    {
        TableClient tableClient = await _azureDataTable.CriarClientComAzureCosmosDB(NomeTabela);

        produto.PartitionKey = PartitionKey;

        await tableClient.AddEntityAsync(produto);

        return produto;
    }

    public async Task<Produto> GetById(string id)
    {
        TableClient tableClient = await _azureDataTable.CriarClientComAzureCosmosDB(NomeTabela);

        return await tableClient.GetEntityAsync<Produto>(rowKey: id, partitionKey: PartitionKey);
    }

    public async Task<Produto> Update(Produto produto)
    {
        TableClient tableClient = await _azureDataTable.CriarClientComAzureCosmosDB(NomeTabela);

        await tableClient.UpdateEntityAsync(produto, produto.ETag);

        return produto;
    }

    public async Task RemoveById(string id)
    {
        TableClient tableClient = await _azureDataTable.CriarClientComAzureCosmosDB(NomeTabela);

        await tableClient.DeleteEntityAsync(PartitionKey, id);
    }

    public async Task<List<Produto>> GetAll()
    {
        TableClient tableClient = await _azureDataTable.CriarClientComAzureCosmosDB(NomeTabela);

        List<Produto> produtos = tableClient.Query<Produto>(x => x.PartitionKey == PartitionKey).ToList();

        return produtos;
    }

}
