using DigitalIdentity.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalIdentity.App.Business.Abstract
{
    public interface IOtpManager
    {
        public Task<OtpResponseModel> GenerateOtpAsync(GenRequestOtpModel model);
        public Task<OtpResponseModel> VerifyOtpAsync(VerRequestOtpModel model);
        public Task<OtpResponseModel> RegenerateOtpAsync(BaseOtpModel model);
    }
}
