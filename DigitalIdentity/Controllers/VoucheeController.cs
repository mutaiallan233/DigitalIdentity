using DigitalIdentity.Data.Databases.Contexts;
using DigitalIdentity.Data.Databases.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DigitalIdentity.Api.Controllers
{
    [ApiController]
    [Route("api/vouchee")]
    public class VoucheeController : ControllerBase
    {
        private ISqlVouchee _sqlVouchee;

        public VoucheeController(ISqlVouchee sqlVouchee)
        {
            _sqlVouchee = sqlVouchee;
        }

        [HttpGet("get-allVouchees")]
        public IActionResult GetAllVouchees()
        {
            return Ok(_sqlVouchee.GetAllVouchees());
        }

        [HttpGet("{id}")]
        public IActionResult GetVouchee(Guid id)
        {
            var vouchee = _sqlVouchee.GetVouchee(id);
            if (vouchee == null) { return NotFound($"Vouchee with id:{id} not found"); }
            return Ok(vouchee);
        }

        [HttpPost("post")]
        public IActionResult PostVouchee(VoucheeContext voucheeContext)
        {
            _sqlVouchee?.CreateVouchee(voucheeContext);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + voucheeContext.Id, voucheeContext);
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateVouchee(Guid id, VoucheeContext voucheeContext)
        {
            var existingVouchee = _sqlVouchee.GetVouchee(id);
            if(existingVouchee != null)
            {
                voucheeContext.Id = existingVouchee.Id;

                _sqlVouchee.UpdateVouchee(voucheeContext);
                return Ok($"Voucher with id:{id} was updated successfully");
            }
            return NotFound($"Vouchee with id: {id} was not found");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVouchee(Guid id)
        {
            var vouchee = _sqlVouchee.GetVouchee(id);
            if (vouchee == null)
            {
                return NotFound($"Cannot delete missing vouchee! id: {id}");
            }
            _sqlVouchee.DeleteVouchee(vouchee);
          return Ok("Delete Successfully");
        }
    }
}
