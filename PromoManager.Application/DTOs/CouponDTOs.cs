using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoManager.Application.DTOs
{
    //ISP: Interfaz de escritura separada de la lectura.
    public class CouponDTOs
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Kind { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ExpiresAt { get; set; }
    }
}
