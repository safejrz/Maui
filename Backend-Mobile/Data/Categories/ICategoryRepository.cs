using NetKubernetes.Models; 

namespace NetKubernetes.Data.Categories;

public interface ICategoryRepository {

    Task<IEnumerable<Category>> GetAllCategories();

}