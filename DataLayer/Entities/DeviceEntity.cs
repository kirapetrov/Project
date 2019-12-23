using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Devices")]
public class DeviceEntity
{

    [Key]
    public int DeviceId { get; set; }

    public string SerialNumber { get; set; }

    public int UserId { get; set; }

    public UserEntity User { get; set; }

    public DeviceEntity() { }

    public DeviceEntity(string serialNumber)
    {
        SerialNumber = serialNumber;
    }
}