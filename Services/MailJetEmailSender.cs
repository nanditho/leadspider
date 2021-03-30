using System.Threading.Tasks;
using Mailjet.Client;
using Mailjet.Client.Resources;
using System;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;

namespace LeadSpider.Services
{
    public class MailJetEmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;
        public MailJetOptions _mailJetOptions;
        public MailJetEmailSender(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            _mailJetOptions = _configuration.GetSection("MailJet").Get<MailJetOptions>();
            MailjetClient client = new MailjetClient(_mailJetOptions.ApiKey, _mailJetOptions.SecretKey);
            
            MailjetRequest request = new MailjetRequest {
                Resource = Send.Resource,
                }
                    .Property(Send.Messages, new JArray {
                    new JObject {
                    {
                    "From",
                    new JObject {
                        {"Email", "teddysmithdev@gmail.com"}, 
                        {"Name", "Teddy"}
                    }
                    }, {
                    "To",
                    new JArray {
                        new JObject {
                        {
                        "Email",
                        "teddysmithdev@gmail.com"
                        }, {
                        "Name",
                        "Teddy"
                        }
                        }
                    }
                    }, {
                    "Subject",
                    subject
                    }, {
                    "TextPart",
                    "My first Mailjet email"
                    }, {
                    "HTMLPart",
                    htmlMessage
                    }, {
                    "CustomID",
                    "AppGettingStartedTest"
                    }
                    }
                    });
                    MailjetResponse response = await client.PostAsync(request);
                    if (response.IsSuccessStatusCode) {
                        Console.WriteLine(string.Format("Total: {0}, Count: {1}\n", response.GetTotal(), response.GetCount()));
                        Console.WriteLine(response.GetData());
                    } else {
                        Console.WriteLine(string.Format("StatusCode: {0}\n", response.StatusCode));
                        Console.WriteLine(string.Format("ErrorInfo: {0}\n", response.GetErrorInfo()));
                        Console.WriteLine(response.GetData());
                        Console.WriteLine(string.Format("ErrorMessage: {0}\n", response.GetErrorMessage()));
                    }
                }
            }
        }
