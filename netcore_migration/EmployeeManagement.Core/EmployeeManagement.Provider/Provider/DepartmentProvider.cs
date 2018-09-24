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
    public class DepartmentProvider : IConfigurationProvider<Department>
    {
        public async Task<Document> Add(Department model)
        {
            var result = await DocumentDBRepository<Department>.CreateItemAsync(model);
            return result;
        }

        public async Task<Document> Delete(int id)
        {
            var result = await DocumentDBRepository<Department>.DeleteItemAsync(id.ToString());
            return result;
        }

        public async Task<IEnumerable<Department>> GetAll()
        {
            var result = await DocumentDBRepository<Department>.GetItemsAsync();
            return result;
        }

        public async Task<IEnumerable<Department>> GetAllByQuery(Expression<Func<Department, bool>> predicate)
        {
            var result = await DocumentDBRepository<Department>.GetItemsAsync(predicate);
            return result;
        }

        public async Task<IEnumerable<Department>> GetSpecificById(int id)
        {
            var result = await DocumentDBRepository<Department>.GetItemsAsync(d => d.DepartmentId == id.ToString());
            return result;
        }

        public async Task<Document> Update(Department model)
        {
            var result = await DocumentDBRepository<Department>.UpdateItemAsync(model.DepartmentId, model);
            return result;
        }
    }
}
