namespace LessonThree.Models.AuthorisationModels
{
    public class UserModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
    }
}
