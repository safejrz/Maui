using ShopApp.DataAccess;
using System.Net.Http.Json;

namespace ShopApp.Services;

public class CompraService
{
    private HttpClient _client = new HttpClient();

    public CompraService(HttpClient client)
    {
        _client = client;
    }

    public async Task<bool> EnviarData(IEnumerable<ShopCart> compras)
    {
        var uri = $"http://172.19.160.1/api/compra";

        var body = new
        {
            data = compras.Select(compra => new
            {
                clientId = compra.ClientId,
                productId = compra.ProductId,
                cantidad = compra.Quantity,
                productoPrecio = compra.ProductPrice,
            }).ToArray()
        };

        var result = await _client.PostAsJsonAsync(uri, body);
        return result.IsSuccessStatusCode;
    }
}
