namespace MasMovil.Componentes.Citaciones.Shared.Utils.Helpers
{
    using Microsoft.ApplicationInsights;
    using System;
    using System.Collections.Generic;
   
    public static class AppInsightsHelper
    {
        readonly static TelemetryClient telemetryClient = new TelemetryClient();

        public static void TrackDomainEvent(string eventName, string marca, string sessionId)
        {
            var properties = new Dictionary<string, string>
            {
               { "Marca", marca },
               { "SesionId", sessionId }
            };

            telemetryClient.TrackEvent(eventName, properties);
        }

        public static void TrackDomainEvent(string eventName, IDictionary<string, string> properties)
        {
            telemetryClient.TrackEvent(eventName, properties);
        }

        public static void TrackEvent<T>(string eventName, T obj)
        {
            var dictionary = SetTrackEventProperties(obj);
            telemetryClient.TrackEvent(eventName, dictionary);
        }

        static Dictionary<string, string> SetTrackEventProperties<T>(T obj)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var property in obj.GetType().GetProperties())
            {
                var value = property.GetValue(obj)?.ToString();
                if (!string.IsNullOrWhiteSpace(value))
                {
                    dictionary.Add(property.Name, value);
                }
            }
            return dictionary;
        }

        public static void TrackException(Exception ex)
        {
            telemetryClient.TrackException(ex);
        }
    }
}