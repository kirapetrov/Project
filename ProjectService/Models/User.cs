using DataLayer;

namespace ProjectService.Models
{
    public class User 
    {
        public string Name {get;set;}

        public User()
        {
            
        }

        public User(string name)
        {
            Name = name;
        }

        public User(UserEntity userEntity)
        {
            Name = userEntity.Name;
        }

        public UserEntity GetEntity()
        {
            return new UserEntity(Name);
        }
    }
}