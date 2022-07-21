
using DigitalIdentity.App.Business.Abstract;
using DigitalIdentity.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DigitalIdentity.Api.Controllers
{
    [ApiController]
    public class OtpController : ControllerBase
    {
        private readonly string _baseUrl;

        readonly IConfiguration configuration;
        private readonly IOtpManager _otpManager;

        public OtpController(IConfiguration _configuration, IOtpManager otpManager)
        {
            this.configuration = _configuration;
            this._otpManager = otpManager;
            _baseUrl = configuration["BaseUrl"];
        }
        [HttpPost("generate-otp")]
        public async Task<IActionResult> GenerateOtp(GenRequestOtpModel model)
        {
            var response = await _otpManager.GenerateOtpAsync(model);
            if (response != null)
            {
                if (response.Successful)
                {
                    return Ok(response);
                }
                return NoContent();

            }
            return BadRequest("Could not Complete  the Request");
            //client.DefaultRequestHeaders.Accept.Clear();
            //var response = await client.PostAsJsonAsync(_baseUrl + "v1/otp/generate, model);
            //if (response.IsSuccessStatusCode)
            //{
            //    var result = await response.Content.ReadFromJsonAsync<OtpResponseModel>();
            //    return Ok(result);
            //}
            //return BadRequest("request failed");

        }
        [HttpPost("regenerate-otp")]
        public async Task<IActionResult> RegenerateOtp(BaseOtpModel model)
        {
            var response = await _otpManager.RegenerateOtpAsync(model);
            if (response != null)
            {
                if (response.Successful)
                {
                    return Ok(response);
                }
                return NoContent();

            }
            return BadRequest("Could not Complete  the Request");
            //var response = await client.PostAsJsonAsync(_baseUrl + "v1/otp/regenerate", model);
            //if (response.IsSuccessStatusCode)
            //{
            //    var result = await response.Content.ReadFromJsonAsync<OtpResponseModel>();
            //    return Ok(result);
            //}
            //return BadRequest("request failed");
        }
        [HttpPost("verify-otp")]
        public async Task<IActionResult> VerifyOtp(VerRequestOtpModel model)
        {
            var response = await _otpManager.VerifyOtpAsync(model);
            if (response != null)
            {
                if (response.Successful)
                {
                    return Ok(response);
                }
                return NoContent();

            }
            return BadRequest("Could not Complete  the Request");
            //var response = await client.PostAsJsonAsync(_baseUrl + "v1/otp/verify", model);
            //if (response.IsSuccessStatusCode)
            //{
            //    var result = await response.Content.ReadFromJsonAsync<OtpResponseModel>();
            //    return Ok(result);
            //}
            //return BadRequest("request failed");
        }





    }
}
