using PromoManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoManager.Domain.Interfaces
{
    //ISP: interfaz de solo lectura, separada de la de escritura.
    public interface ICouponReader
    {
        Task<Coupon?> GetByCodeAsync(string code);
        Task<IEnumerable<Coupon>> GetAllAsync();
    }
}
