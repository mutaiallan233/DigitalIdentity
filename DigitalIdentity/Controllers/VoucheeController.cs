using DigitalIdentity.App;
using DigitalIdentity.App.Business.Abstract;
using DigitalIdentityBl.Models;
using Microsoft.AspNetCore.Mvc;

namespace DigitalIdentity.Api.Controllers
{
    [ApiController]
    [Route("api/vouchee")]
    public class VoucheeController : ControllerBase
    {
        private IVouchee _vouchee;
  

        public VoucheeController(IVouchee sqlVouchee)
        {
            _vouchee = sqlVouchee;
        }

        [HttpGet("get-allVouchees")]
        public IActionResult GetAllVouchees()
        {
            return Ok(_vouchee.GetAllVouchees());
        }

        [HttpGet("{id}")]
        public IActionResult GetVouchee(Guid id)
        {
            var vouchee = _vouchee.GetVouchee(id);
            if (vouchee == null) { return NotFound($"Vouchee with id:{id} not found"); }
            return Ok(vouchee);
        }

        [HttpPost("post")]
        public IActionResult PostVouchee(Vouchee vouchee)
        {
            _vouchee?.CreateVouchee(vouchee);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + vouchee.Id, vouchee);
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateVouchee(Guid id, Vouchee vouchee)
        {
            //var existingVoucher = _vouchee.GetVouchee(id);
            /*if(existingVouchee != null)
            {
                voucheeContext.Id = existingVouchee.Id;

                _vouchee.UpdateVouchee(voucheeContext);
                return Ok($"Voucher with id:{id} was updated successfully");
            }*/
            //if (existingVoucher != null)
            //{
                //existingVouchee.PhotoUrl = string.IsNullOrEmpty(voucherContext.PhotoUrl) ? existingVoucher.PhotoUrl : voucherContext.PhotoUrl;
                //existingVoucher.PhotoUrl = existingVoucher.PhotoUrl ?? vouchee.PhotoUrl;

               // existingVoucher.Phone = string.IsNullOrEmpty(voucherContext.Phone) ? existingVoucher.Phone : voucherContext.Phone;
               // existingVoucher.gender = string.IsNullOrEmpty(voucherContext.gender.ToString()) ? existingVoucher.gender : voucherContext.gender;
                //existingVoucher.Designation = string.IsNullOrEmpty(voucherContext.Designation) ? existingVoucher.Designation : voucherContext.Designation;
                //existingVoucher.FirstName = string.IsNullOrEmpty(vouchee.FirstName) ? existingVoucher.FirstName : voucherContext.FirstName;
               // existingVoucher.LastName = string.IsNullOrEmpty(voucherContext.LastName) ? existingVoucher.LastName : voucherContext.LastName;
                //existingVoucher.IdNumber = string.IsNullOrEmpty(voucherContext.IdNumber) ? existingVoucher.IdNumber : voucherContext.IdNumber;

              //  _vouchee.UpdateVouchee(existingVoucher);
                //return Ok($"Voucher with id: {id} was updated successfully");
            //}
            return NotFound($"Vouchee with id: {id} was not found");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVouchee(Guid id)
        {
            var vouchee = _vouchee.GetVouchee(id);
            if (vouchee == null)
            {
                return NotFound($"Cannot delete missing vouchee! id: {id}");
            }
            _vouchee.DeleteVouchee(vouchee);
          return Ok("Delete Successfully");
        }
    }
}
