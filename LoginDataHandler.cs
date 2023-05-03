using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class LoginDataHandler
{
    public List<LoginWrapper> LoginData { get; }

    public LoginDataHandler(string filePath)
    {
        var jsonContent = File.ReadAllText(filePath);
        LoginData = JsonConvert.DeserializeObject<List<LoginWrapper>>(jsonContent);
    }

    public IEnumerable<LoginConfiguration> Logins
    {
        get
        {
            foreach (var loginWrapper in LoginData)
            {
                yield return loginWrapper.Login;
            }
        }
    }
}
