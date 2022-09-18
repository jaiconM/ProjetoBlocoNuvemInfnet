using Azure;
using Azure.Data.Tables;

namespace MyEcommerce.Domain;
public record Produto : ITableEntity
{
    public string Codigo { get; set; } = default!;
    public string Nome { get; set; } = default!;
    public string LinkFoto { get; set; } = default!;
    public double ValorUnitario { get; set; }
    public string RowKey { get; set; }
    public string PartitionKey { get; set; } = default!;
    public ETag ETag { get; set; } = default!;
    public DateTimeOffset? Timestamp { get; set; } = DateTime.Now;

    public Produto()
    {
        RowKey = Guid.NewGuid().ToString();
    }
}
