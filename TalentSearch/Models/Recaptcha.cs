using Newtonsoft.Json;
using System.Collections.Generic;

namespace TalentSearch.Models
{
    public class Recaptcha
    {

    }

    public class CaptchaResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("error-codes")]
        public List<string> ErrorCodes { get; set; }
    }
}