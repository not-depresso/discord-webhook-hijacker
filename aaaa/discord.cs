using System;
using System.Collections.Specialized;
using System.Net;

public class dWebHook : IDisposable
{
    private readonly WebClient dWebClient;
    private static NameValueCollection discordValues = new NameValueCollection();
    public string WebHook { get; set; }
    public string UserName { get; set; }
    public string ProfilePicture { get; set; }

    public dWebHook()
    {
        dWebClient = new WebClient();
        WebHook = "";
        UserName = "";
        ProfilePicture = "";
    }


    public void SendMessage(string msgSend)
    {
        discordValues.Clear();
        discordValues.Add("username", UserName);
        discordValues.Add("avatar_url", ProfilePicture);
        discordValues.Add("content", msgSend);
        try
        {
            dWebClient.UploadValues(WebHook, discordValues);
        }
        catch (WebException)
        {
            Console.WriteLine("Invalid webhook!");
        }
    }

    public void Dispose()
    {
        dWebClient.Dispose();
    }
}