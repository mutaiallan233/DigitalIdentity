using DigitalIdentity.App.Business.Abstract;
using DigitalIdentity.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DigitalIdentity.App.Business.Managers
{
    public class OtpManager : IOtpManager
    {
        private readonly string _baseUrl;
        readonly HttpClient client;

        public OtpManager(string baseUrl, HttpClient client)
        {
            _baseUrl = baseUrl;
            this.client = client;
        }

        public async Task<OtpResponseModel> GenerateOtpAsync(GenRequestOtpModel model)
        {
            OtpResponseModel? otpResponseModel = new();
            var response = await client.PostAsJsonAsync(_baseUrl + "v1/otp/generate", model);
            if (response.IsSuccessStatusCode)
            {
                otpResponseModel = await response.Content.ReadFromJsonAsync<OtpResponseModel>();

            }
            return otpResponseModel!;
        }

        public async Task<OtpResponseModel> RegenerateOtpAsync(BaseOtpModel model)
        {
            OtpResponseModel? otpResponseModel = new();
            var response = await client.PostAsJsonAsync(_baseUrl + "v1/otp/regenerate", model);
            if (response.IsSuccessStatusCode)
            {
                otpResponseModel = await response.Content.ReadFromJsonAsync<OtpResponseModel>();

            }
            return otpResponseModel!;
        }

        public async Task<OtpResponseModel> VerifyOtpAsync(VerRequestOtpModel model)
        {
            OtpResponseModel? otpResponseModel = new();
            var response = await client.PostAsJsonAsync(_baseUrl + "v1/otp/verify", model);
            if (response.IsSuccessStatusCode)
            {
                otpResponseModel = await response.Content.ReadFromJsonAsync<OtpResponseModel>();

            }
            return otpResponseModel!;
        }
    }
}
