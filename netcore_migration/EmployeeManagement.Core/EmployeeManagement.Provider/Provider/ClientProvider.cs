using EmployeeManagement.Model;
using EmployeeManagement.Provider.Interface;
using EmployeeManagement.Repository;
using Microsoft.Azure.Documents;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Provider.Provider
{
    public class ClientProvider : IConfigurationProvider<Client>
    {
        public async Task<Document> Add(Client model)
        {
            var result = await DocumentDBRepository<Client>.CreateItemAsync(model);
            return result;
        }

        public async Task<Document> Delete(int id)
        {
            var result = await DocumentDBRepository<Client>.DeleteItemAsync(id);
            return result;
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            var result = await DocumentDBRepository<Client>.GetItemsAsync();
            return result;
        }

        public async Task<IEnumerable<Client>> GetAllByQuery(Expression<Func<Client, bool>> predicate)
        {
            var result = await DocumentDBRepository<Client>.GetItemsAsync(predicate);
            return result;
        }

        public async Task<IEnumerable<Client>> GetSpecificById(int id)
        {
            var result = await DocumentDBRepository<Client>.GetItemsAsync(d => d.ClientId == id);
            return result;
        }

        public async Task<Document> Update(Client model)
        {
            var result = await DocumentDBRepository<Client>.UpdateItemAsync(model.ClientId, model);
            return result;
        }
    }
}
