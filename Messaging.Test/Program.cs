// See https://aka.ms/new-console-template for more information
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

public static class TwilioConfiguration
{
    public static string AccountSid => "AC09ca49d94bc545bfbd1c95702a9ddd98";

    public static string AuthToken => "2fb439fc231bdeb614a7e592bdf43e59";

    public static string Twilio => "+18444907575";

    public static string TwilioVirtual => "+18777804236";
}

internal class Program
{
    private static async Task Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        TwilioClient.Init(TwilioConfiguration.AccountSid, TwilioConfiguration.AuthToken);

         await MessageResource.CreateAsync(
            to: new PhoneNumber(TwilioConfiguration.TwilioVirtual),
            from: new PhoneNumber(TwilioConfiguration.Twilio),
            body: "TEST"
        );
    }
}