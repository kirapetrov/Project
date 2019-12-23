
namespace ProjectService.DataTransferObjects
{
    public class UserDto
    {
        public string Name { get; set; }

        public UserDto()
        {

        }

        public UserDto(string name)
        {
            Name = name;
        }

        public UserDto(UserEntity userEntity)
        {
            Name = userEntity.Name;
        }

        public UserEntity GetEntity()
        {
            return new UserEntity(Name);
        }
    }
}