using LessonThree.Abstractions;
using LessonThree.Models.AuthorisationModels;

namespace LessonThree.Services
{
    public class AuthenticationService : IUserAuthenticationService
    {
        public UserModel Authenticate(LoginModel model)
        {
           if(model.Name == "admin" && model.Password == "password")
            {
                return new UserModel { Password = model.Password, Username = model.Name, Role = UserRole.Administrator};
            }

            if (model.Name == "user" && model.Password == "super")
            {
                return new UserModel { Password = model.Password, Username = model.Name, Role = UserRole.User };
            }
            return null;
        }
    }
}
