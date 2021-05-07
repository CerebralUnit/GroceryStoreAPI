using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Repository
{
    public class JsonRepositoryContext : IJsonRepositoryContext
    {
        private string filePath = null;
         
        public JsonRepositoryContext(string jsonFilePath) 
        {
            filePath = jsonFilePath;
        }
        
        public async Task<string> RetrieveJsonAsync()
        {
            string json = null;

            using (var jsonReader = new StreamReader(filePath))
            {
                json = await jsonReader.ReadToEndAsync();
            }

            return json;
        }

        public async Task<bool> SaveJsonAsync(string json)
        {
            try
            {
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                //Someday we would log this exception or throw it with custom data 
                return false;
            }

            return true;
        }
    }
}
