\------------>>> Notes



IMPORTANT: You may have to switch from 'IIS Express' to 'BlazorDemo', in the dropwon-tab next to the one which chooses the startup configuration (in the toolbar up near the menus, in Visual Studio).



Note: According to the clanker, it SHOULD work when run from the test explorer, but I was personally unable to run the test, because the \[Run Test] buttons get disabled when starting the project. This hasn't been resolved per current writing (10-11-2026).



\* \* \* REMEMBER THAT FOR THE E2E TO WORK, THE PROJECT NEEDS TO BE RUNNING (F5). \* \* \*



\------------>>>



\------------>>> E2E Playwright Setup (Long Version)



1\. Create test project \& add to solution

dotnet new nunit -n E2ETests -f net8.0

dotnet sln add E2ETests



2\. Add Playwright

dotnet add E2ETests package Microsoft.Playwright.NUnit



3\. Build, then install the browsers (only needed once)

dotnet build E2ETests

pwsh E2ETests\\bin\\Debug\\net8.0\\playwright.ps1 install chromium

This needs PowerShell 7 (pwsh). If you don't have it, run wingetl first.



// Alternative (if no powershell 7) :

\& ".\\E2ETests\\bin\\Debug\\net8.0\\.playwright\\node\\win32\_x64\\node.exe" ".\\E2ETests\\bin\\Debug\\net8.0\\.playwright\\package\\cli.js" install chromium



4\. Write the test. Replace the generated UnitTest1.cs with:

using Microsoft.Playwright.NUnit;



namespace E2ETests;



public class CalculatorTests : PageTest

{

&#x20;   \[Test]

&#x20;   public async Task Add\_TwoNumbers\_ShowsSum()

&#x20;   {

&#x20;       await Page.GotoAsync("http://localhost:5000/calculator")



&#x20;       await Page.FillAsync("input\[name='number1']", "2");

&#x20;       await Page.PressAsync("input\[name='number1']", "Tab");

&#x20;       await Page.FillAsync("input\[name='number2']", "3");

&#x20;       await Page.PressAsync("input\[name='number2']", "Tab");                                                                                              

&#x20;       await Page.ClickAsync("button\[name='AddNumbers']");                                                                                                 

&#x20;       await Expect(Page.Locator("input\[name='total']")).ToHaveValueAsync("5");                                                                                }

}                                                                                                                                                           

5\. Start the app. In VS, select the BlazorDemo profile and press Ctrl+F5. That runs it without the debugger and leaves it running. Playwright doesn't start your app for you.



6\. Run the test

dotnet test E2ETests

You can also use Test Explorer in VS.



\------------>>>

\------------>>>

\------------>>>

\------------>>>



















\------------>>> TL;DR Variant



dotnet new nunit -n E2ETests -f net8.0

dotnet sln add E2ETests



dotnet add E2ETests package Microsoft.Playwright.NUnit

dotnet build E2ETests



\& ".\\E2ETests\\bin\\Debug\\net8.0\\.playwright\\node\\win32\_x64\\node.exe" ".\\E2ETests\\bin\\Debug\\net8.0\\.playwright\\package\\cli.js" install chromium



// TODO Lav test filen i test projektet ; se kode ovenfor eller i klassen



// Run the test

dotnet test E2ETests













\------------>>>

\------------>>>

\------------>>>

\------------>>>





























