using Naspinski.Maps.Interfaces;
using System.Threading.Tasks;
using Xunit;

namespace Naspinski.Maps.Tests
{
    public class GoogleMapTests : TestBase
    {
        public GoogleMapTests() : base() { }

        [Fact]
        public async Task BasicAddress()
        {
            IAddress address = Map.GetAddress("212 N 1st St Unit 311, Minneapolis, MN 55401");
            await address.GetAddress();
            Assert.Equal("Central Minneapolis", address.Neighborhood);
            Assert.Equal("1557", address.PostalCodeSuffix);
        }

        [Fact]
        public async Task ZipGetsAddress()
        {
            IAddress address = Map.GetAddress("55401");
            await address.GetAddress();
            Assert.Equal("Hennepin County", address.County);
            Assert.Equal("Minneapolis", address.City);
        }

        [Fact]
        public async Task BadAddress()
        {
            IAddress address = Map.GetAddress("alsdjfhaljsdfhalhjsdfalfsdh");
            await address.GetAddress();
            Assert.Equal("ZERO_RESULTS", address.Status);
        }
    }
}
