using Microsoft.Extensions.Configuration;
using Naspinski.Maps.Implementations.Google;
using Naspinski.Maps.Interfaces;

namespace Naspinski.Maps.Tests
{
    public class TestBase
    {
        protected readonly string GoogleMapsApiKey;
        protected readonly IMap Map;

        public TestBase()
        {
            var config = new ConfigurationBuilder()
                .AddUserSecrets<TestBase>()
                .Build();
            GoogleMapsApiKey = config["GOOGLE_MAPS_API_KEY"];
            Map = new GoogleMap(GoogleMapsApiKey);
        }
    }
}
