using System.ComponentModel.DataAnnotations;

namespace TimeCop.TimeSheet.Data;

public class Staff
{
    public int Id { get; set; }

    [MaxLength(50)]
    public required string FirstName { get; set; }

    [MaxLength(50)]
    public required string LastName { get; set; }

    public bool IsActive { get; set; }

    public int HolidayAllowance { get; set; }

    public int ContractHours { get; set; }
}
