using System;
using System.Collections.Generic;

namespace EventManagement_Backend.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public string UserId { get; set; } = null!;

    public int EventId { get; set; }

    public decimal TotalAmount { get; set; }

    public DateTime PaymentDate { get; set; }

    public string PaymentStatus { get; set; } = null!;

    public virtual Event Event { get; set; } = null!;

    public virtual AspNetUser User { get; set; } = null!;
}
