using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities
{
    [Table("LogRecordTypes")]
    public class LogRecordType
    {
        public int LogRecordTypeId { get; set; }

        public int Number { get; set; }

        public string Name { get; set; }

        public LogRecordType() { }
    }
}
