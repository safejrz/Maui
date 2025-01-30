using NetKubernetes.Models;

namespace NetKubernetes.Data.Inmuebles;

public interface IInmuebleRepository {

    Task<bool> SaveChanges();

    Task<IEnumerable<Inmueble>> GetAllInmuebles();

    Task<Inmueble> GetInmuebleById(int id);

    Task CreateInmueble(Inmueble inmueble);

    Task DeleteInmueble(int id); 

    Task<IEnumerable<Inmueble>> SearchInmuebles(string search);

    Task<IEnumerable<Inmueble>> GetByCategoryId(int id);

    Task<IEnumerable<Inmueble>> GetTrending();
    
}