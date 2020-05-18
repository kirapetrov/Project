using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities
{
    [Table("DeviceLogs")]
    public class DeviceLogEntity
    {
        [Key]
        public int DeviceLogId { get; set; }

        public int DeviceId { get; set; }

        public DeviceEntity Device { get; set; }

        public int LogRecordTypeId { get; set; }

        public LogRecordType LogRecordType { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DateTimeOccurrence { get; set; }

        public string Message { get; set; }

        public DeviceLogEntity() { }

        public DeviceLogEntity(string message)
        {
            Message = message;
        }
    }
}