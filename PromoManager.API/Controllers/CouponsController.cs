using Microsoft.AspNetCore.Mvc;
using PromoManager.Application.Services;
using PromoManager.Application.DTOs;

namespace PromoManager.API.Controllers
{
    public class CouponsController
    {
        [ApiController]
        [Route("api/[controller]")]
        public class CouponController : ControllerBase
        {
            private readonly AppServices _couponService;

            public CouponController(AppServices couponService)
            {
                _couponService = couponService;
            }

            // GET: api/coupons
            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var list = await _couponService.GetAllAsync();
                return Ok(list);
            }

            // POST: api/coupons
            [HttpPost]
            public async Task<IActionResult> Create([FromBody] CreCouponRequest request)
            {
                try
                {
                    var dto = await _couponService.CreateAsync(request);
                    return Ok(dto);
                }
                catch (Exception ex)
                {
                    return BadRequest(new { message = ex.Message });
                }
            }

            // GET: api/coupons/{code}
            [HttpGet("{code}")]
            public async Task<IActionResult> GetByCode(string code)
            {
                var dto = await _couponService.GetByCodeAsync(code);
                if (dto is null)
                    return NotFound(new { message = "Cupón no encontrado." });

                return Ok(dto);
            }

            // POST: api/coupons/{code}/deactivate
            [HttpPost("{code}/deactivate")]
            public async Task<IActionResult> Deactivate(string code)
            {
                try
                {
                    await _couponService.DeactivateAsync(code);
                    return Ok(new { message = "Cupón desactivado correctamente." });
                }
                catch (KeyNotFoundException ex)
                {
                    return NotFound(new { message = ex.Message });
                }
                catch (Exception ex)
                {
                    return BadRequest(new { message = ex.Message });
                }
            }

            // DELETE: api/coupons/{code}
            [HttpDelete("{code}")]
            public async Task<IActionResult> Delete(string code)
            {
                try
                {
                    await _couponService.DeleteAsync(code);
                    return Ok(new { message = "Cupón eliminado." });
                }
                catch (KeyNotFoundException ex)
                {
                    return NotFound(new { message = ex.Message });
                }
            }

            // GET: api/coupons/{code}/validate
            [HttpGet("{code}/validate")]
            public async Task<IActionResult> Validate(string code)
            {
                var (valid, reason) = await _couponService.ValidateAsync(code);
                return Ok(new { valid, reason });
            }
        }

    }
}
