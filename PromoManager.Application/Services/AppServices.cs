using PromoManager.Application.DTOs;
using PromoManager.Domain.Entities;
using PromoManager.Domain.Interfaces;
using PromoManager.Application.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoManager.Application.Services
{
    //DIP: depende de abstracciones del dominio.
    public class AppServices
    {
        private readonly ICouponWritter _repo;
        private readonly ICouponReader _reader;

        public AppServices (ICouponWritter repo, ICouponReader reader)
        {
            _repo = repo;
            _reader = reader;
        }

        public async Task<IEnumerable<CouponDTOs>> GetAllAsync()
        {
            var coupons = await _reader.GetAllAsync();
            return coupons.Select(c => c.ToDto());
        }

        public async Task<CouponDTOs> CreateAsync(CreCouponRequest request)
        {
            var coupon = new Coupon(request.Kind, request.Amount, request.ExpiresAt);
            await _repo.AddAsync(coupon);
            return coupon.ToDto();
        }

        public async Task<CouponDTOs?> GetByCodeAsync(string code)
        {
            var coupon = await _reader.GetByCodeAsync(code);
            return coupon?.ToDto();
        }

        public async Task DeactivateAsync(string code)
        {
            var coupon = await _reader.GetByCodeAsync(code)
                ?? throw new KeyNotFoundException("Cupón no encontrado.");

            coupon.Deactivate();
            await _repo.UpdateAsync(coupon);
        }

        public async Task DeleteAsync(string code)
        {
            await _repo.DeleteAsync(code);
        }

        public async Task<(bool valid, string? reason)> ValidateAsync(string code)
        {
            var coupon = await _reader.GetByCodeAsync(code);
            if (coupon == null)
                return (false, "Cupón no encontrado.");

            var valid = coupon.Validate(DateTime.UtcNow);
            return valid ? (true, null) : (false, "El cupón no es válido o ha expirado.");
        }
    }
}
