using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using System.Linq;

namespace PlaywrightExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Create an instance of the GlobalTestConfiguration class
            var globalTestConfiguration = new GlobalTestConfiguration("appsettings.json");

            using var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = globalTestConfiguration.Headless });
            //var page = await browser.NewPageAsync();

            // Create an instance of the LoginDataHandler class
            var loginDataHandler = new LoginDataHandler("parametersLoginTest.json");

            var pages = new List<IPage>(); // Store pages to close them later
            foreach (var loginConfiguration in loginDataHandler.Logins)
            {
                var page = await browser.NewPageAsync();
                
                
            // Use the PageObjectManager class
            var pageObjectManager = new PageObjectManager(page);
            var homePage = pageObjectManager.HomePage;
            var loginPage = pageObjectManager.LoginPage;
            await homePage.GotoAsync("https://www.saucedemo.com/");
            Console.WriteLine(await homePage.GetTitleAsync());
            // Use the first login and password from the JSON file
            LoginConfiguration firstLogin = loginDataHandler.Logins.ElementAt(0);

            await loginPage.EnterLogin("standard_user");
            await loginPage.EnterPassword("secret_sauce");
            
            await loginPage.ClickLoginButton();
            bool result = await homePage.CheckIfTitleContainsGivenValue("Products");
            if (result)
                {
                Console.WriteLine($"Test passed for user {loginConfiguration.Username}.");
                }
                else{
        
                Console.WriteLine($"Test failed for user {loginConfiguration.Username}.");
                }
            



            await page.CloseAsync();
            }

                        // Close the browser instance after all iterations are done
            await browser.CloseAsync();

            // Keep the program running until you press a key
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
              
        }
    }
}

