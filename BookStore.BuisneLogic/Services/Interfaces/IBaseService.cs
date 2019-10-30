using BookStore.BusinessLogic.Models.Authors;
using BookStore.BusinessLogic.Models.Base;
using BookStore.DataAccess.Entities.Base;
using BookStore.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLogic.Services.Interfaces
{
    public interface IBaseService<Model> where Model : BaseModel
    {
        Task<Model> FindByIdAsync(long modelId);
        Task<long> CreateAsync(Model model);
        Task<BaseModel> UpdateAsync(Model model);
        Task<BaseModel> RemoveAsync(Model model);
    }
}
