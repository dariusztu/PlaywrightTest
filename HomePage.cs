using System.Threading.Tasks;
using Microsoft.Playwright;

public class HomePage : BasePage
{
    
    protected readonly IPage _page;

    // Define the selectors as variables
    private ILocator producsTitle => _page.Locator("//*[contains(@class, 'title')]");

    public HomePage(IPage page) : base(page)
    {
        _page = page;
        
    }
    
    // Add methods specific to the HomePage

    public async Task<bool> CheckIfTitleContainsGivenValue(string titleCheck)
    {
        var actualTitle = await producsTitle.InnerTextAsync();
        return actualTitle.Equals(titleCheck);
    }

    // Add more methods as needed
}
