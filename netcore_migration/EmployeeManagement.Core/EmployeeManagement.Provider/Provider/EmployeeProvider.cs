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
    public class EmployeeProvider : IConfigurationProvider<Employee>
    {
        public async Task<Document> Add(Employee model)
        {
            var result = await DocumentDBRepository<Employee>.CreateItemAsync(model);
            return result;
        }

        public async Task<Document> Delete(int id)
        {
           var result = await DocumentDBRepository<Employee>.DeleteItemAsync(id.ToString());
           return result;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            var result = await DocumentDBRepository<Employee>.GetItemsAsync();
            return result;
        }

        public async Task<IEnumerable<Employee>> GetAllByQuery(Expression<Func<Employee, bool>> predicate)
        {
            var result = await DocumentDBRepository<Employee>.GetItemsAsync(predicate);
            return result;
        }

        public async Task<IEnumerable<Employee>> GetSpecificById(int id)
        {
            var result = await DocumentDBRepository<Employee>.GetItemsAsync(d => d.EmployeeId == id.ToString());
            return result;
        }

        public async Task<Document> Update(Employee model)
        {
            var result = await DocumentDBRepository<Employee>.UpdateItemAsync(model.EmployeeId, model);
            return result;
        }
    }
}
