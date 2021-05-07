using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Core
{
    public interface IRepository<TObjectType, TPrimaryKeyType> where TObjectType : new()
    {
        Task<bool> Create(TObjectType obj);

        Task<TObjectType> Retrieve(TPrimaryKeyType primaryKey);

        Task<bool> Update(TObjectType obj);

        Task<bool> Delete(TPrimaryKeyType primaryKey);
         
        Task<List<TObjectType>> RetrieveAll();
    }
}
