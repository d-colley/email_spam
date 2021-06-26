Imports System
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Configuration

'automated console email app
Module Program
    Sub Main(args As String())
        Console.WriteLine("-Email Client-")

        Console.WriteLine("Enter recipient address: ")
        Dim mailRecipient As String = Console.ReadLine().Trim()

        Console.WriteLine("Enter the Subject: ")
        Dim mailSubject As String = Console.ReadLine().Trim()

        Console.WriteLine("Please enter the Body: ")
        Dim mailBody = Console.ReadLine().Trim()

        Using mm As New MailMessage(ConfigurationManager.AppSettings("FromEmail"), mailRecipient)
            mm.Subject = mailSubject
            mm.Body = mailBody
            mm.IsBodyHtml = True

            Dim smtp As New SmtpClient(ConfigurationManager.AppSettings("Host"), ConfigurationManager.AppSettings("Port"))

            Dim NetworkCred As New NetworkCredential(ConfigurationManager.AppSettings("Username"), ConfigurationManager.AppSettings("Password"))
            smtp.UseDefaultCredentials = False
            smtp.Credentials = NetworkCred

            smtp.DeliveryMethod = SmtpDeliveryMethod.Network
            smtp.EnableSsl = True

            Console.WriteLine("Sending Email...")

            Try
                smtp.Send(mm)
                Console.WriteLine("Email Sent")

            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
            System.Threading.Thread.Sleep(3000)
            Environment.Exit(0)
        End Using

    End Sub
End Module
