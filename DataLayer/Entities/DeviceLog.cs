using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities
{
    public class DeviceLog
    {
        [Key]
        public int Id { get; set; }

        public int DeviceId { get; set; }

        public Device Device { get; set; }

        public int LogRecordTypeId { get; set; }

        public LogRecordType LogRecordType { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DateTimeOccurrence { get; set; }
        
        public string Message { get; set; }

        public DeviceLog() { }

        public DeviceLog(string message)
        {
            Message = message;
        }
    }
}