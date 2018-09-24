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
    public class SkillProvider : IConfigurationProvider<Skills>
    {
        public async Task<Document> Add(Skills model)
        {
            var result = await DocumentDBRepository<Skills>.CreateItemAsync(model);
            return result;
        }

        public async Task<Document> Delete(int id)
        {
            var result = await DocumentDBRepository<Skills>.DeleteItemAsync(id.ToString());
            return result;
        }

        public async Task<IEnumerable<Skills>> GetAll()
        {
            var result = await DocumentDBRepository<Skills>.GetItemsAsync();
            return result;
        }

        public async Task<IEnumerable<Skills>> GetAllByQuery(Expression<Func<Skills, bool>> predicate)
        {
            var result = await DocumentDBRepository<Skills>.GetItemsAsync(predicate);
            return result;
        }

        public async Task<IEnumerable<Skills>> GetSpecificById(int id)
        {
            var result = await DocumentDBRepository<Skills>.GetItemsAsync(d => d.SkillId == id.ToString());
            return result;
        }

        public async Task<Document> Update(Skills model)
        {
            var result = await DocumentDBRepository<Skills>.UpdateItemAsync(model.SkillId, model);
            return result;
        }
    }
}
