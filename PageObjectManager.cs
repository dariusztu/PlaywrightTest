using Microsoft.Playwright;

public class PageObjectManager
{
    private readonly IPage _page;
    private HomePage _homePage;
    private LoginPage _loginPage;

    public PageObjectManager(IPage page)
    {
        _page = page;
    }

    public HomePage HomePage
    {
        get
        {
            if (_homePage == null)
            {
                _homePage = new HomePage(_page);
            }
            return _homePage;
        }
    }

        public LoginPage LoginPage
    {
        get
        {
            if (_loginPage == null)
            {
                _loginPage = new LoginPage(_page);
            }
            return _loginPage;
        }
    }

    // Add other page objects as needed
}
