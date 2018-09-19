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
    public class ProjectProvider : IConfigurationProvider<Project>
    {
        public async Task<Document> Add(Project model)
        {
            var result = await DocumentDBRepository<Project>.CreateItemAsync(model);
            return result;
        }

        public async Task<Document> Delete(int id)
        {
            var result = await DocumentDBRepository<Project>.DeleteItemAsync(id);
            return result;
        }

        public async Task<IEnumerable<Project>> GetAll()
        {
            var result = await DocumentDBRepository<Project>.GetItemsAsync();
            return result;
        }

        public async Task<IEnumerable<Project>> GetAllByQuery(Expression<Func<Project, bool>> predicate)
        {
            var result = await DocumentDBRepository<Project>.GetItemsAsync(predicate);
            return result;
        }

        public async Task<IEnumerable<Project>> GetSpecificById(int id)
        {
            var result = await DocumentDBRepository<Project>.GetItemsAsync(d => d.Id == id);
            return result;
        }

        public async Task<Document> Update(Project model)
        {
            var result = await DocumentDBRepository<Project>.UpdateItemAsync(model.Id, model);
            return result;
        }
    }
}
