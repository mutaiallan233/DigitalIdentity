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
            var existingVouchee = _vouchee.GetVouchee(id);
            if (existingVouchee != null)
            {
                existingVouchee.Voice = string.IsNullOrEmpty(vouchee.Voice) ? existingVouchee.Voice : vouchee.Voice;
                existingVouchee.PhotoUrls = (vouchee.photos.Count < 1) ? existingVouchee.PhotoUrls : vouchee.PhotoUrls;
                existingVouchee.VoucherRefId = (vouchee.VoucherRefId == default(Guid)) ? existingVouchee.VoucherRefId : vouchee.VoucherRefId;
                existingVouchee.gender = string.IsNullOrEmpty(vouchee.gender.ToString()) ? existingVouchee.gender : vouchee.gender;
                existingVouchee.Dob = (vouchee.Dob == default(DateTime)) ? existingVouchee.Dob : vouchee.Dob;
                existingVouchee.FirstName = string.IsNullOrEmpty(vouchee.FirstName) ? existingVouchee.FirstName : vouchee.FirstName;
                existingVouchee.LastName = string.IsNullOrEmpty(vouchee.LastName) ? existingVouchee.LastName : vouchee.LastName;
                existingVouchee.Nationality = string.IsNullOrEmpty(vouchee.Nationality) ? existingVouchee.Nationality : vouchee.Nationality;
                existingVouchee.Connection = (vouchee.Connections.Count < 1) ? existingVouchee.Connection : vouchee.Connection;

                _vouchee.UpdateVouchee(existingVouchee);
                return Ok($"Vouchee with id: {id} was updated successfully");
            }
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
