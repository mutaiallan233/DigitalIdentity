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
            if (voucher == null)
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

        [HttpPatch("{uid}")]

        public IActionResult UpdateVoucher(Guid uid, VoucherContext voucherContext)
        {
            var existingVoucher = _sqlVoucher.GetVoucher(uid);
            if (existingVoucher != null)
            {
                existingVoucher.PhotoUrl = string.IsNullOrEmpty(voucherContext.PhotoUrl) ? existingVoucher.PhotoUrl : voucherContext.PhotoUrl;
                existingVoucher.Phone = string.IsNullOrEmpty(voucherContext.Phone) ? existingVoucher.Phone : voucherContext.Phone;
                existingVoucher.gender = string.IsNullOrEmpty(voucherContext.gender.ToString()) ? existingVoucher.gender : voucherContext.gender;
                existingVoucher.Designation = string.IsNullOrEmpty(voucherContext.Designation) ? existingVoucher.Designation : voucherContext.Designation;
                existingVoucher.FirstName = string.IsNullOrEmpty(voucherContext.FirstName) ? existingVoucher.FirstName : voucherContext.FirstName;
                existingVoucher.LastName = string.IsNullOrEmpty(voucherContext.LastName) ? existingVoucher.LastName : voucherContext.LastName;
                existingVoucher.IdNumber = string.IsNullOrEmpty(voucherContext.IdNumber) ? existingVoucher.IdNumber : voucherContext.IdNumber;

                _sqlVoucher.UpdateVoucher(existingVoucher);
                return Ok($"Voucher with id: {uid} was updated successfully");
            }
            return NotFound($"Voucher with id: {uid} was not found");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVoucher(Guid Id)
        {
            var voucher = _sqlVoucher.GetVoucher(Id);
            if (voucher == null)
            {
                return NotFound($"Cannot delete missing voucher! id: {Id}");
            }
            _sqlVoucher.DeleteVoucher(voucher);
            return Ok("Deleted Successfully");
        }
    }
}
