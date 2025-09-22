using System.Threading.Tasks;
using myproj.Models.TokenAuth;
using myproj.Web.Controllers;
using Shouldly;
using Xunit;

namespace myproj.Web.Tests.Controllers
{
    public class HomeController_Tests: myprojWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}