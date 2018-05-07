namespace Challenge.Shared.Models.Configuration
{
    using System;
   
    public class AccessTokenResult
    {
        public string SessionId { get; set; }
        public DateTime ExpiredTime { get; set; }
    }
}
