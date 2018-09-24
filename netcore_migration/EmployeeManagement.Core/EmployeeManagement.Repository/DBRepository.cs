using Microsoft.Azure.Documents;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository
{
    public abstract class DBRepository<T> where T : class
    {
        public abstract Task<T> GetItem(int id);
        public abstract Task<IEnumerable<T>> GetItems(Expression<Func<T, bool>> predicate);
        public abstract Task<IEnumerable<T>> GetItems();
        public abstract Task<Document> CreateItems(T item);
        public abstract Task<Document> UpdateItemAsync(int id, T item);
        public abstract Task<Document> DeleteItemAsync(int id);

    }
}
