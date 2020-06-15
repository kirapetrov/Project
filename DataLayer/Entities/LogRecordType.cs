using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class LogRecordType
    {
        [Key]
        public int Id { get; set; }

        public int Number { get; set; }

        public string Name { get; set; }
    }
}
