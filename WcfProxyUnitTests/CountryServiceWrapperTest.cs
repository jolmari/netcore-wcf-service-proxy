using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using WcfProxy.CountryServiceReference;
using WcfServiceProxy;
using WcfServiceProxy.Models;
using WcfServiceProxy.Proxy;
using Xunit;

namespace WcfProxyUnitTests
{
    public class CountryServiceWrapperTest
    {
        private Mock<IWcfProxy<ICountryServiceChannel>> _mockProxy;
        private string _endpointUrl = "testUrl";

        private CountryServiceWrapper _wrapper;

        private static IEnumerable<CountryDto> ResultDataSet => new[]
        {
            new CountryDto
            {
                Code = "fi",
                Name = "Finland"
            },
            new CountryDto
            {
                Code = "se",
                Name = "Sweden"
            },
        };

        public CountryServiceWrapperTest()
        {
            _mockProxy = new Mock<IWcfProxy<ICountryServiceChannel>>();

            _wrapper = new CountryServiceWrapper(_mockProxy.Object);
        }

        [Fact]
        public void GetCountries_ShouldReturn_ResultsInMappedFormat()
        {
            // Arrange
            var response = new GetCountriesResponse
            {
                GetCountriesResult = ResultDataSet.ToArray()
            };

            _mockProxy
                .Setup(x => x.Execute(It.IsAny<Func<ICountryServiceChannel, GetCountriesResponse>>()))
                .Returns(response);

            // Act
            var result = _wrapper.GetCountries();

            // Assert
            result
                .Should().HaveCount(2)
                .And.ContainSingle(x => x.Code == "fi" && x.Name == "Finland");
        }

        [Fact]
        public async void GetCountriesAsync_ShouldReturn_ResultsInMappedFormat()
        {
            // Arrange
            var response = new GetCountriesResponse
            {
                GetCountriesResult = ResultDataSet.ToArray()
            };

            _mockProxy
                .Setup(x => x.Execute(It.IsAny<Func<ICountryServiceChannel, Task<GetCountriesResponse>>>()))
                .Returns(Task.FromResult(response));

            // Act
            var result = await _wrapper.GetCountriesAsync();

            // Assert
            result
                .Should().HaveCount(2)
                .And.ContainSingle(x => x.Code == "fi" && x.Name == "Finland");
        }

        [Fact]
        public void SaveCountry_ShouldCallExecute()
        {
            // Arrange
            var input = new Country();

            // Act
            _wrapper.SaveCountry(input);

            // Assert
            _mockProxy.Verify(x =>
                x.Execute(It.IsAny<Func<ICountryServiceChannel, SaveCountryResponse>>()), Times.Once);
        }

        [Fact]
        public async void SaveCountryAsync_ShouldCallExecute()
        {
            // Arrange
            var input = new Country();

            // Act
            await _wrapper.SaveCountryAsync(input);

            // Assert
            _mockProxy.Verify(x =>
                x.Execute(It.IsAny<Func<ICountryServiceChannel, Task<SaveCountryResponse>>>()), Times.Once);
        }

        [Fact]
        public void Clear_ShouldCallExecute()
        {
            // Act
            _wrapper.Clear();

            // Assert
            _mockProxy.Verify(x =>
                x.Execute(It.IsAny<Func<ICountryServiceChannel, ClearResponse>>()), Times.Once);
        }

        [Fact]
        public async void ClearAsync_ShouldCallExecute()
        {
            // Act
            await _wrapper.ClearAsync();

            // Assert
            _mockProxy.Verify(x =>
                x.Execute(It.IsAny<Func<ICountryServiceChannel, Task<ClearResponse>>>()), Times.Once);
        }
    }
}
