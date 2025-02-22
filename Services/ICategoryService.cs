using PagePortServer.Models;

namespace PagePortServer.Services
{
    public interface ICategoryService
    {
        IEnumerable <Category> GetCategories ();
        Category GetCategory (int id);

        Category UpdateCategory (int id,Category category);

        bool DeleteCategory (int id);

        IEnumerable<Book> GetCategoryBooks (int categoryId);
    }
}
