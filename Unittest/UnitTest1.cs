using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Threading.Tasks;
namespace Unittest
{
    public class UnitTest1:IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient client;
        public UnitTest1()
        {
            var factory=new WebApplicationFactory<Program>();
            _factory=factory;
            client=_factory.CreateClient();
        }

        [Fact(Skip ="Moved test to theory")]
        public async Task Test1()
        {
            //arrange
            var client=_factory.CreateClient();

            //act
            var response = await client.GetAsync("/Sample/Index");
            int code = (int)response.StatusCode;

            //assert
            Assert.Equal(200, code);
        }
        //[Theory]
        //[InlineData("/Home")]
        //[InlineData("/Home/Privacy")]
        //[InlineData("/Content")]
        //[InlineData("/Sample/Index")]
        //public async void Test2(string url)
        //{
        //    //arrange
        //    var client = _factory.CreateClient();

        //    //act
        //    var response = await client.GetAsync(url);
        //    int code = (int)response.StatusCode;

        //    //assert
        //    Assert.Equal(200, code);
        //}
        [Theory]
        [InlineData("Maharashtra")]
        [InlineData("Jammu")]
        [InlineData("Kerala")]
        [InlineData("Karnataka")]
        [InlineData("UP")]
        public async Task TestForStates(string state_name)
        {
            //Arragne

            //Act
            var response = await client.GetAsync("/Sample/Index");
            var pageContent = await response.Content.ReadAsStringAsync();
            var contentString = pageContent.ToString();

            //Assert
            Assert.Contains(state_name, contentString);

        }

    }
}