using PromoManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoManager.Domain.Interfaces
{
    //ISP: interfaz de escritura separada de la lectura.
    public interface ICouponWritter
    {
        Task AddAsync(Coupon coupon);
        Task UpdateAsync(Coupon coupon);
        Task DeleteAsync(string code);
    }
}
