using WcfProxyIntegrationTests.Fixtures;
using Xunit;

namespace WcfProxyIntegrationTests
{
    /// <summary>
    /// NET Core 2.0 has no support for WCF service hosting so in order to run these integration tests, the WCFServices project must be run manually
    /// in the background.
    /// </summary>
    public class HomeControllerIntegrationTests : IClassFixture<WebHostedIntegrationTestFixture>
    {
        private readonly WebHostedIntegrationTestFixture fixture;

        public HomeControllerIntegrationTests(WebHostedIntegrationTestFixture fixture)
        {
            this.fixture = fixture;
        }
        
        [Fact]
        public async void IndexShould_ReturnSuccessStatusCode()
        {
            // Act
            var response = await fixture.Client.GetAsync("/");

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
