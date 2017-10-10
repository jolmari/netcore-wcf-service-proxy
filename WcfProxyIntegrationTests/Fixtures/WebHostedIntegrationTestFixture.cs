using System;
using System.IO;
using System.Net.Http;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using NetCoreWebApp;

namespace WcfProxyIntegrationTests.Fixtures
{
    public class WebHostedIntegrationTestFixture : IDisposable
    {
        private readonly TestServer _server;

        public WebHostedIntegrationTestFixture()
        {
            var startupAssembly = typeof(Startup).GetTypeInfo().Assembly;
            var contentRoot = GetProjectPath(string.Empty, startupAssembly);

            _server = new TestServer(new WebHostBuilder()
                .UseContentRoot(contentRoot)
                .UseEnvironment("production")
                .UseStartup<Startup>());
            Client = _server.CreateClient();
        }

        public HttpClient Client { get; }

        public void Dispose()
        {
            Client.Dispose();
            _server.Dispose();
        }

        /// <summary>
        ///     Gets the full path to the target project that we wish to test
        /// </summary>
        /// <param name="projectRelativePath">
        ///     The parent directory of the target project.
        ///     e.g. src, samples, test, or test/Websites
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
                    var projectFileInfo = new FileInfo(Path.Combine(projectDirectoryInfo.FullName, projectName,
                        $"{projectName}.csproj"));
                    if (projectFileInfo.Exists)
                        return Path.Combine(projectDirectoryInfo.FullName, projectName);
                }
            } while (directoryInfo.Parent != null);

            throw new Exception($"Project root could not be located using the application root {applicationBasePath}.");
        }
    }
}