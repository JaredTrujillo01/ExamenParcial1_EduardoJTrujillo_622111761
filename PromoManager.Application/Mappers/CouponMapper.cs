using PromoManager.Application.DTOs;
using PromoManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoManager.Application.Mappers
{
    //SRP: esta clase solo se encarga de la conversión entre entidades
    public static class CouponMapper
    {
        public static CouponDTOs ToDto(this Coupon coupon)
        {
            return new CouponDTOs
            {
                Id = coupon.Id,
                Code = coupon.Code,
                Kind = coupon.Kind,
                Amount = coupon.Amount,
                IsActive = coupon.IsActive,
                CreatedAt = coupon.CreatedAt,
                ExpiresAt = coupon.ExpiresAt
            };
        }
    }
}
