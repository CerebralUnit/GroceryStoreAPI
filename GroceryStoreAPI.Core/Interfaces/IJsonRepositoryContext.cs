using System.Threading.Tasks;

namespace GroceryStoreAPI.Repository
{
    public interface IJsonRepositoryContext
    {
        Task<string> RetrieveJsonAsync();

        Task<bool> SaveJsonAsync(string json);
    }
}