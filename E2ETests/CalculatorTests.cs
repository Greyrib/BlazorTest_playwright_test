using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace E2ETests;

public class CalculatorTests : PageTest
{
    [Test]
    public async Task Add_TwoNumbers_ShowsSum()
    {
        await Page.GotoAsync("http://localhost:5000/calculator");

        await Page.FillAsync("input[name='number1']", "2");
        await Page.PressAsync("input[name='number1']", "Tab");
        await Page.FillAsync("input[name='number2']", "3");
        await Page.PressAsync("input[name='number2']", "Tab");

        await Page.ClickAsync("button[name='AddNumbers']");

        await Expect(Page.Locator("input[name='total']")).ToHaveValueAsync("5");
    }
}