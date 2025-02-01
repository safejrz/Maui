namespace NetKubernetes.Dtos.CompraDtos;

public class CompraItemRequestDto {

    public int ClientId { get; set; }

    public int ProductId { get; set; }

    public int Cantidad { get; set; }
    public decimal ProductoPrecio { get; set; }
}