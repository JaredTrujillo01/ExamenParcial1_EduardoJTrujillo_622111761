using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoManager.Application.DTOs
{
    public class CreCouponRequest
    {
        public string Kind { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime? ExpiresAt { get; set; }
    }
}
