using BookStore.BusinessLogic.Models.Token;
using BookStore.BusinessLogic.Models.Users;
using System.Threading.Tasks;

namespace BookStore.Presentation.Helper.Interface
{
    public interface IJwtHelper
    {
        TokenModel GenerateTokenModel(UserModelItem user);
        bool CheckToken(string token);
    }
}
