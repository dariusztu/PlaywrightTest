using System.Threading.Tasks;
using Microsoft.Playwright;

public abstract class BasePage
{
    protected readonly IPage _page;

    protected BasePage(IPage page)
    {
        _page = page;
    }

    public async Task GotoAsync(string url)
    {
        await _page.GotoAsync(url);
    }

    public async Task<string> GetTitleAsync()
    {
        return await _page.TitleAsync();
    }

    // Add any other common methods or properties here
}
