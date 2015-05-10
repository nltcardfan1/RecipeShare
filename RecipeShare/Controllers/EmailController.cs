using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecipeShare.Models;

namespace RecipeShare.Controllers
{
    public class EmailController : Controller
    {
        // GET: Email
		//public ActionResult Index()
		//{
		//	return View();
		//}

	    public static void SendEmail(string email)
	    {
			const String FROM = "nltcardfan1@gmail.com";   // Replace with your "From" address. This address must be verified.
			String TO = email;  // Replace with a "To" address. If your account is still in the
			// sandbox, this address must be verified.

			const String SUBJECT = "Amazon SES test (SMTP interface accessed using C#)";
			const String BODY = "This email was sent through the Amazon SES SMTP interface by using C#.";

			// Supply your SMTP credentials below. Note that your SMTP credentials are different from your AWS credentials.
			const String SMTP_USERNAME = "AKIAI2KYLEOHJCKYEJCA";  // Replace with your SMTP username. 
			const String SMTP_PASSWORD = "AjsGbXVxM3yoSGKRZUHbI8GHFuwrmqwoE9czIJbmWjED";  // Replace with your SMTP password.

			// Amazon SES SMTP host name. This example uses the us-west-2 region.
			const String HOST = "email-smtp.us-east-1.amazonaws.com";

			// Port we will connect to on the Amazon SES SMTP endpoint. We are choosing port 587 because we will use
			// STARTTLS to encrypt the connection.
			const int PORT = 587;

			using(System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(HOST,PORT))
			{
				// Create a network credential with your SMTP user name and password.
				client.Credentials = new System.Net.NetworkCredential(SMTP_USERNAME,SMTP_PASSWORD);

				// Use SSL when accessing Amazon SES. The SMTP session will begin on an unencrypted connection, and then 
				// the client will issue a STARTTLS command to upgrade to an encrypted connection using SSL.
				client.EnableSsl = true;

				// Send the email. 
				try
				{
					Console.WriteLine("Attempting to send an email through the Amazon SES SMTP interface...");
					client.Send(FROM,TO,SUBJECT,BODY);
					Console.WriteLine("Email sent!");
				}
				catch(Exception ex)
				{
					Logger.LogException(ex);
				}
			}
	    }
    }

	
}