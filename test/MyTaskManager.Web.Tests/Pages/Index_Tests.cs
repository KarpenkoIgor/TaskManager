using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace MyTaskManager.Pages;

public class Index_Tests : MyTaskManagerWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
