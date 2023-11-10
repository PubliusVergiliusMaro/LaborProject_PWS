using SendGrid;
using SendGrid.Helpers.Mail;

namespace LaborProject_PWS.Services.EmailServices
{
	public class EmailSender : IEmailSender
	{
		public async Task SendEmailAsync(string email, string subject, string message)
		{
			var apiKey = "SenGrid_API_Key";
			var client = new SendGridClient(apiKey);
			var from = new EmailAddress("olegredko45@gmail.com", "Example User");
			var to = new EmailAddress(email, "Example User");
			var msg = MailHelper.CreateSingleEmail(from, to, subject, message, $"<strong>{message}</strong>");
			var response = await client.SendEmailAsync(msg);
		}
	}
}
