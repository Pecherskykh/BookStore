using BookStore.BusinessLogic.Models.Base;
using System.Threading.Tasks;

namespace BookStore.BusinessLogic.Services.Interfaces
{
    public interface IBaseService<Model> where Model : BaseModel
    {
        Task<Model> FindByIdAsync(long modelId);
        Task<BaseModel> CreateAsync(Model model);
        Task<BaseModel> UpdateAsync(Model model);
        Task<BaseModel> RemoveAsync(Model model);
    }
}
