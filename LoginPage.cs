using System.Threading.Tasks;
using Microsoft.Playwright;

public class LoginPage : BasePage
{
    protected readonly IPage _page;

    private ILocator LoginInputSelector => _page.Locator("//*[@data-test='username']");
    private ILocator PasswordInputSelector => _page.Locator("//*[@data-test='password']");
    private ILocator LoginButtonSelector => _page.Locator("//*[@data-test='login-button']");


    public LoginPage(IPage page) : base(page)
    {
        _page = page;
    }

    

        public async Task ClickLoginInputField()
    {
        await LoginInputSelector.ClickAsync();
    }

        public async Task ClickPasswordInputField()
    {
        await PasswordInputSelector.ClickAsync();
    }

    public async Task EnterLogin(string login)
    {
        
        await LoginInputSelector.TypeAsync(login);
        
    }

        public async Task EnterPassword(string password)
    {
        await PasswordInputSelector.TypeAsync(password);
    }

    public async Task ClickLoginButton()
    {
        await LoginButtonSelector.ClickAsync();
    }

    // Add any other common methods or properties here
}
