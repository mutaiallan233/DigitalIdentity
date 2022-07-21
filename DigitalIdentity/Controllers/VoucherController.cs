using DigitalIdentity.App.Business.Abstract;

using DigitalIdentity.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DigitalIdentity.Api.Controllers
{
    [ApiController]
    [Route("api/voucher")]
    public class VoucherController : ControllerBase
    {
        
        private IVoucher _voucher;

        public VoucherController( IVoucher voucher)
        {
            
            _voucher = voucher;
        }

        [HttpGet("get-allVouchers")]
        public IActionResult GetAllVouchers()
        {
            return Ok(_voucher.GetAllVouchers());
        }

        [HttpGet("{id}")]
        public IActionResult GetVoucher(Guid id)
        {
            var voucher = _voucher.GetVoucherById(id);
            if (voucher == null)
            {
                return NotFound($"Voucher with id:{id} not found");
            }
            return Ok(voucher);
        }

        [HttpPost("post")]
        public IActionResult PostVoucher(Voucher voucher)
        {
            _voucher.CreateVoucher(voucher);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + voucher.Id, voucher);
        }

        [HttpPatch("{uid}")]

        public IActionResult UpdateVoucher(Guid uid, Voucher voucher)
        {
            var existingVoucher = _voucher.GetVoucherById(uid);
            if (existingVoucher != null)
            {
                //existingVoucher.PhotoUrl = string.IsNullOrEmpty(voucher.PhotoUrl) ? existingVoucher.PhotoUrl : voucher.PhotoUrl;
               // existingVoucher.PhotoUrl =  existingVoucher.PhotoUrl ?? voucher.PhotoUrl;

                existingVoucher.Phone = string.IsNullOrEmpty(voucher.Phone) ? existingVoucher.Phone : voucher.Phone;
                existingVoucher.gender = string.IsNullOrEmpty(voucher.gender.ToString()) ? existingVoucher.gender : voucher.gender;
                existingVoucher.Designation = string.IsNullOrEmpty(voucher.Designation) ? existingVoucher.Designation : voucher.Designation;
                existingVoucher.FirstName = string.IsNullOrEmpty(voucher.FirstName) ? existingVoucher.FirstName : voucher.FirstName;
                existingVoucher.LastName = string.IsNullOrEmpty(voucher.LastName) ? existingVoucher.LastName : voucher.LastName;
                existingVoucher.IdNumber = string.IsNullOrEmpty(voucher.IdNumber) ? existingVoucher.IdNumber : voucher.IdNumber;

                _voucher.UpdateVoucher(existingVoucher);
                return Ok($"Voucher with id: {uid} was updated successfully");
            }
            return NotFound($"Voucher with id: {uid} was not found");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVoucher(Guid Id)
        {
            var voucher = _voucher.GetVoucherById(Id);
            if (voucher == null)
            {
                return NotFound($"Cannot delete missing voucher! id: {Id}");
            }
            _voucher.DeleteVoucher(voucher);
            return Ok("Deleted Successfully");
        }
    }
}
