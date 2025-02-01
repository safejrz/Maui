using Microsoft.Extensions.Configuration;
using ShopApp.DataAccess;
using ShopApp.Models.Config;
using System.Net.Http.Json;

namespace ShopApp.Services;

public class CompraService
{
    private HttpClient _client = new HttpClient();
    private Settings _settings;

    public CompraService(HttpClient client, IConfiguration configuration)
    {
        _client = client;
        _settings = configuration.GetSection(nameof(Settings)).Get<Settings>();   
    }

    public async Task<bool> EnviarData(IEnumerable<ShopCart> compras)
    {
        var uri = $"{_settings.UrlBase}api/compra";


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
