using DataLayer.Entities;

namespace ProjectService.DataTransferObjects
{
    public class UserDto
    {
        public string Login { get; set; }

        public string Name { get; set; }

        public UserDto() { }

        public UserDto(string login, string name)
        {
            Name = name;
        }

        public UserDto(User userEntity)
        {
            Login = userEntity.Login;
            Name = userEntity.Name;
        }

        public User GetEntity()
        {
            return new User(Login, Name);
        }
    }
}