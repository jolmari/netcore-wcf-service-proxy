using System;
using System.IO;
using System.Net.Http;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using NetCoreWebApp;
using Xunit;

namespace WcfProxyIntegrationTests
{
    /// <summary>
    /// NET Core 2.0 has no support for WCF service hosting so in order to run these integration tests, the WCFServices project must be run manually
    /// in the background.
    /// </summary>
    public class HomeControllerIntegrationTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        
        public HomeControllerIntegrationTests()
        {
            var startupAssembly = typeof(Startup).GetTypeInfo().Assembly;
            var contentRoot = GetProjectPath(string.Empty, startupAssembly);
            
            _server = new TestServer(new WebHostBuilder()
                .UseContentRoot(contentRoot)
                .UseEnvironment("production")
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        public void Dispose()
        {
            _client.Dispose();
            _server.Dispose();
        }

        /// <summary>
        /// Gets the full path to the target project that we wish to test
        /// </summary>
        /// <param name="projectRelativePath">
        /// The parent directory of the target project.
        /// e.g. src, samples, test, or test/Websites
        /// </param>
        /// <param name="startupAssembly">The target project's assembly.</param>
        /// <returns>The full path to the target project.</returns>
        private static string GetProjectPath(string projectRelativePath, Assembly startupAssembly)
        {
            // Get name of the target project which we want to test
            var projectName = startupAssembly.GetName().Name;

            // Get currently executing test project path
            var applicationBasePath = AppContext.BaseDirectory;

            // Find the path to the target project
            var directoryInfo = new DirectoryInfo(applicationBasePath);
            do
            {
                directoryInfo = directoryInfo.Parent;

                var projectDirectoryInfo = new DirectoryInfo(Path.Combine(directoryInfo.FullName, projectRelativePath));
                if (projectDirectoryInfo.Exists)
                {
                    var projectFileInfo = new FileInfo(Path.Combine(projectDirectoryInfo.FullName, projectName, $"{projectName}.csproj"));
                    if (projectFileInfo.Exists)
                    {
                        return Path.Combine(projectDirectoryInfo.FullName, projectName);
                    }
                }
            }
            while (directoryInfo.Parent != null);

            throw new Exception($"Project root could not be located using the application root {applicationBasePath}.");
        }

        [Fact]
        public async void IndexShould_ReturnSuccessStatusCode()
        {
            // Act
            var response = await _client.GetAsync("/");

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
