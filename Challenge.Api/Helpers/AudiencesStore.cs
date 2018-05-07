using Challenge.Api.Models;
using Microsoft.Owin.Security.DataHandler.Encoder;
using System;
using System.Collections.Concurrent;
using System.Configuration;
using System.Security.Cryptography;

namespace Challenge.Api.Helpers
{

    public static class AudiencesStore
    {
        public static ConcurrentDictionary<string, Audience> AudiencesList = new ConcurrentDictionary<string, Audience>();

        static AudiencesStore()
        {
            AddAudience(ConfigurationManager.AppSettings["JWT:AudienceName"]);
        }

        public static Audience AddAudience(string name)
        {
            var clientId = Guid.NewGuid().ToString("N");

            var key = new byte[32];
            RNGCryptoServiceProvider.Create().GetBytes(key);
            var base64Secret = TextEncodings.Base64Url.Encode(key);

            Audience newAudience = new Audience { ClientId = clientId, Base64Secret = base64Secret, Name = name };
            AudiencesList.TryAdd(name, newAudience);
            return newAudience;
        }

        public static Audience FindAudience(string name)
        {
            Audience audience = null;
            if (AudiencesList.TryGetValue(name, out audience))
            {
                return audience;
            }
            return null;
        }

    }
}