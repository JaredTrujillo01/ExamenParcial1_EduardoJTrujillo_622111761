using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoManager.Domain.Entities
{
    //SRP: esta entidad solo representa un Cupón y sus reglas de negocio.
    public class Coupon
    {
        public Guid Id { get; private set; }
        public string Code { get; private set; }
        public string Kind { get; private set; }
        public decimal Amount { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? ExpiresAt { get; private set; }

        private Coupon() { }

        public Coupon(string kind, decimal amount, DateTime? expiresAt = null)
        {
            if (string.IsNullOrWhiteSpace(kind))
                throw new ArgumentException("El tipo de cupón es obligatorio.");

            if (amount <= 0)
                throw new ArgumentException("El monto debe ser mayor que cero.");

            Id = Guid.NewGuid();
            Code = Guid.NewGuid().ToString("N")[..8].ToUpper();
            Kind = kind;
            Amount = amount;
            ExpiresAt = expiresAt;
            IsActive = true;
            CreatedAt = DateTime.UtcNow;
        }

        public void Deactivate()
        {
            if (!IsActive)
                throw new InvalidOperationException("El cupón ya estaba inactivo.");
            IsActive = false;
        }

        public bool Validate(DateTime now)
        {
            if (!IsActive) return false;
            if (ExpiresAt is not null && ExpiresAt < now) return false;
            return true;
        }
    }
}