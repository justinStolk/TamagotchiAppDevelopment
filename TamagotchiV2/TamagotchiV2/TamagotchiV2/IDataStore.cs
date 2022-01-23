using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TamagotchiV2
{
    public interface IDataStore<T>
    {

        Task<bool> CreateItem(T item);
        Task<T> ReadItem();
        Task<bool> UpdateItem(T item);
        Task<bool> DeleteItem(T item);


    }
}
