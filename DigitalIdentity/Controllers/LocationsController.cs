using DigitalIdentity.Data.Databases.Interfaces;
using Microsoft.AspNetCore.Mvc;
using DigitalIdentity.Data.Entities;

namespace DigitalIdentity.Api.Controllers
{
    [ApiController]
    [Route("api/locations")]
    public class LocationsController : ControllerBase
    {
       private ISqlLocation _sqlLocation;


       public LocationsController(ISqlLocation sqlLocation)
        {
            this._sqlLocation = sqlLocation;
        }

        [HttpPost("post-location")]
        public IActionResult CreateLocation(Location location)
        {
            _sqlLocation.CreateLocation(location);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + location.Id, location);
        }

        [HttpGet("{id}")]
        public IActionResult GetLocation(Guid id)
        {
            var location = _sqlLocation.GetLocation(id);
            if(location == null)
            {
               return NotFound($"location with id {id} was not found");
            }
            return Ok(location);
        }

        [HttpGet]
        public IActionResult GetLocations()
        {
            return Ok(_sqlLocation.GetAllLocations());
        }

        
        [HttpDelete("delete-location/{id}")]

        public IActionResult DeleteLocation(Guid id)
        {
            var location = _sqlLocation.GetLocation(id);
            if (location != null)
            {
                _sqlLocation.DeleteLocation(location);
                return Ok($"location with id: {id} was deleted successfully");
            }
            return NotFound($"location with id: {id} was not found");
        }

       
        
        [HttpPatch("update-location/{id}")]

        public IActionResult UpdateLocation(Guid id, Location location)
        {
            var existingLocation = _sqlLocation.GetLocation(id);
            if (existingLocation != null)
            {
                location.Id = existingLocation.Id;
                location.Name = location.Name==null?existingLocation.Name:location.Name;
                location.AdministrativeArea = location.AdministrativeArea == null ? existingLocation.AdministrativeArea : location.AdministrativeArea;
               
                _sqlLocation.UpdateLocation(location);
                return Ok($"Location with id: {id} was updated successfully");
            }
            return NotFound($"Location with id: {id} was not found");
        }
    }
}
