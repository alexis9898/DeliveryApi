using BLL.Model;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IAccountService
    {
        Task<bool> SignUp(SignUpModel signUpModel);
        Task<UserModel> LoginAsync(SignInModel signInModel);

        Task<UserDataModel> FindUserById(string id);

    }
}
