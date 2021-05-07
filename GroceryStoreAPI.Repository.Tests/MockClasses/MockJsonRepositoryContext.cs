using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Repository.Tests
{
    public class MockJsonRepositoryContext : IJsonRepositoryContext
    {
        internal string mockJson = @"
        {
            customers: [
                {""Id"":1,""Name"":""Lorem""},
                {""Id"":2,""Name"":""Ipsum""},
                {""Id"":3,""Name"":""Dolor""}
            ]
        }";

        public async Task<string> RetrieveJsonAsync()
        {
            return mockJson;
        }

        public async Task<bool> SaveJsonAsync(string json)
        {
            mockJson = json;
            return true;
        }
    }
}
