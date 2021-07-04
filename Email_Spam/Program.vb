Imports System
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Configuration

'automated console email app
Module Program
    Sub Main()
        Console.WriteLine("-Email Client-")

        'Values:
        '0 Full path of executing program with program name
        '1 First switch in command (-t)
        '2 First value (text1)
        '3 Second switch (-s)
        '4 Second value (text2)

        Dim clArgs() As String = Environment.GetCommandLineArgs()

        Dim mailRecipient As String = String.Empty
        Dim mailSubject As String = String.Empty
        Dim message As String = String.Empty

        'Test to see if two switches and two values were paased in as args
        'if yes, parse array

        '-t mail recipient
        '-s subject
        '-m message

        If clArgs.Count = 7 Then
            For i As Integer = 1 To 5 Step 2
                If clArgs(i) = "-t" Then
                    mailRecipient = clArgs(i + 1)
                ElseIf clArgs(i) = "-s" Then
                    mailSubject = clArgs(i + 1)
                ElseIf clArgs(i) = "-m" Then
                    message = clArgs(i + 1)
                End If
            Next
        Else
            Console.WriteLine("usage: -t -s -m")
        End If

        Console.WriteLine(mailRecipient)
        Console.WriteLine(mailSubject)
        Console.WriteLine(message)

        Console.ReadLine()

        'Console.WriteLine("Enter recipient address: ")
        'Dim mailRecipient As String = Console.ReadLine().Trim()

        'Console.WriteLine("Enter the Subject: ")
        'Dim mailSubject As String = Console.ReadLine().Trim()

        'Console.WriteLine("Please enter the Body: ")
        'Dim mailBody = Console.ReadLine().Trim()

        'Using mm As New MailMessage(ConfigurationManager.AppSettings("FromEmail"), mailRecipient)
        '    mm.Subject = mailSubject
        '    mm.Body = mailBody
        '    mm.IsBodyHtml = True

        '    Dim smtp As New SmtpClient(ConfigurationManager.AppSettings("Host"), ConfigurationManager.AppSettings("Port"))

        '    Dim NetworkCred As New NetworkCredential(ConfigurationManager.AppSettings("Username"), ConfigurationManager.AppSettings("Password"))
        '    smtp.UseDefaultCredentials = False
        '    smtp.Credentials = NetworkCred

        '    smtp.DeliveryMethod = SmtpDeliveryMethod.Network
        '    smtp.EnableSsl = True

        '    Console.WriteLine("Sending Email...")

        '    Try
        '        smtp.Send(mm)
        '        Console.WriteLine("Email Sent")

        '    Catch ex As Exception
        '        Console.WriteLine(ex.Message)
        '    End Try
        '    System.Threading.Thread.Sleep(3000)
        '    Environment.Exit(0)
        'End Using

    End Sub
End Module
