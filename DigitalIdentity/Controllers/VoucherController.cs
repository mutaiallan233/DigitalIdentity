using DigitalIdentity.Data.Databases.Contexts;
using DigitalIdentity.Data.Databases.Interfaces;
using DigitalIdentity.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DigitalIdentity.Api.Controllers
{
    [ApiController]
    [Route("api/voucher")]
    public class VoucherController : ControllerBase
    {
        private ISqlVoucher _sqlVoucher;

        public VoucherController(ISqlVoucher sqlVoucher)
        {
            _sqlVoucher = sqlVoucher;
        }

        [HttpGet("get-allVouchers")]
        public IActionResult GetAllVouchers()
        {
           return Ok(_sqlVoucher.GetAllVouchers());
        }

        [HttpGet("{id}")]
        public IActionResult GetVoucher(Guid id)
        {
            var voucher = _sqlVoucher.GetVoucher(id);
            if(voucher == null)
            {
                return NotFound($"Voucher with id:{id} not found");
            }
            return Ok(voucher);
        }

        [HttpPost("post")]
        public IActionResult PostVoucher(VoucherContext voucherContext)
        {
            _sqlVoucher.CreateVoucher(voucherContext);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + voucherContext.Id, voucherContext);
        }

        [HttpPatch("{id}")]

        public IActionResult UpdateVoucher(Guid id, VoucherContext voucherContext)
        {
            var existingVoucher = _sqlVoucher.GetVoucher(id);
            if (existingVoucher != null)
            {
                voucherContext.Id = existingVoucher.Id;
                
                _sqlVoucher.UpdateVoucher(voucherContext);
                return Ok($"Voucher with id: {id} was updated successfully");
            }
            return NotFound($"Voucher with id: {id} was not found");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVoucher(Guid Id)
        {
            var voucher = _sqlVoucher.GetVoucher(Id);
            if( voucher == null)
            {
                return NotFound($"Cannot delete missing voucher! id: {Id}");
            }
            _sqlVoucher.DeleteVoucher(voucher);
          return Ok("Deleted Successfully");
        }
    }
}
