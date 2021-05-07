using System.Text.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GroceryStoreAPI.Repository 
{
    public abstract class BaseJSONRepository<T>
    {
        private IJsonRepositoryContext context;
        private string json;

        public BaseJSONRepository(IJsonRepositoryContext repositoryContext)
        {
            context = repositoryContext;
        }
         
        protected async Task<List<T>> RetrieveListAsync()
        {
            string json = await context.RetrieveJsonAsync();
            List<T> list = JsonConvert.DeserializeObject<List<T>>(json);
          
            return list;
        }

        protected async Task<T> RetrieveObjectAsync()
        {
            string json = await context.RetrieveJsonAsync();
            T obj = JsonConvert.DeserializeObject<T>(json);
           
            return obj;
        }

        protected async Task<bool> SaveObjectAsync(T obj)
        {
            bool succeeded = false;

            try
            { 
                string json = JsonConvert.SerializeObject(obj);
                succeeded = await context.SaveJsonAsync(json);
            }
            catch(Exception ex)
            {
                //Someday we would log this exception or throw it with custom data 
            }
             
            return succeeded;
        }

        
    }
}
