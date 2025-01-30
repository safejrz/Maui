using NetKubernetes.Models; 

namespace NetKubernetes.Data.Compras;

public interface ICompraRepository {
    Task SaveCompras(IEnumerable<Compra> compras);

    Task<IEnumerable<Compra>> GetAll();
}