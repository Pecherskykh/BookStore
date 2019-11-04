using BookStore.BusinessLogic.Models.Users;
using System.Threading.Tasks;

namespace BookStore.Presentation.Helper.Interface
{
    public interface IJwtHelper
    {
        Task<TokenModel> GenerateTokenModel(UserModelItem user);
    }
}
