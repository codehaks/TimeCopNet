﻿using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeCop.TimeSheet.Domain.Models;

public class Hour
{

    public int Id { get; set; }
    public required string StaffName { get; set; }
    public required int StaffId { get; set; }
    public required LocalDateTime LogTime { get; set; }
    public required string Status { get; set; }
    public string? Note { get; set; }
}
