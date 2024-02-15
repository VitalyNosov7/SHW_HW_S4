using LessonThree.Models.AuthorisationModels;

namespace LessonThree.Abstractions
{
    public interface IUserAuthenticationService
    {
        UserModel Authenticate(LoginModel model);
    }
}
