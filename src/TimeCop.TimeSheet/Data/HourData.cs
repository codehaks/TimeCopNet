using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeCop.TimeSheet.Data;

/*	[id] [int] IDENTITY(1,1) NOT NULL,
	[staffname] [varchar](100) NOT NULL,
	[logtime] [datetime] NOT NULL,
	[status] [varchar](50) NOT NULL,
	[note] [varchar](max) NULL,
	[ModifiedBy] [varchar](40) NULL,
	[staffId] [int] NOT NULL,
	[ModifyTo] [datetime] NULL,
	[ModifyState] [int] NULL,
	[ModifyFrom] [datetime] NULL,
	[ModifyReason] [nchar](250) NULL,
	[ImagePath] [nvarchar](max) NULL,
*/

public class HourData
{
    public int Id { get; set; }
    public required string StaffName { get; set; }
    public string StaffId { get; set; }
    public LocalTime LogTime { get; set; }
    public required string Status { get; set; }
    public string? Note { get; set; }

    public string? ModifiedBy { get; set; }

    public string? ModifyState { get; set; }

    public string? ModifyReason { get; set; }
    public LocalTime? ModifiedTo { get; set; }
    public LocalTime? ModifiedFrom { get; set; }

}
