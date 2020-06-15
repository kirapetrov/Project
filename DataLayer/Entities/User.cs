using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Login { get; set; }

        public string Name { get; set; }

        public ICollection<Device> Devices { get; set; }

        public User()
        {
            Devices = new List<Device>();
        }

        public User(string login, string name) : this()
        {
            Login = login;
            Name = name;
        }
    }
}