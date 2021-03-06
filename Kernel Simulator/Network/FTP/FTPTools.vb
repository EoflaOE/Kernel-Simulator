﻿
'    Kernel Simulator  Copyright (C) 2018-2021  EoflaOE
'
'    This file is part of Kernel Simulator
'
'    Kernel Simulator is free software: you can redistribute it and/or modify
'    it under the terms of the GNU General Public License as published by
'    the Free Software Foundation, either version 3 of the License, or
'    (at your option) any later version.
'
'    Kernel Simulator is distributed in the hope that it will be useful,
'    but WITHOUT ANY WARRANTY; without even the implied warranty of
'    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'    GNU General Public License for more details.
'
'    You should have received a copy of the GNU General Public License
'    along with this program.  If not, see <https://www.gnu.org/licenses/>.

Imports System.IO
Imports System.Net.Security

Public Module FTPTools

    ''' <summary>
    ''' Prompts user for a password
    ''' </summary>
    ''' <param name="user">A user name</param>
    ''' <param name="Address">A host address</param>
    ''' <param name="Port">A port for the address</param>
    Public Sub PromptForPassword(ByVal user As String, Optional ByVal Address As String = "", Optional ByVal Port As Integer = 0, Optional ByVal EncryptionMode As FtpEncryptionMode = FtpEncryptionMode.Explicit)
        'Make a new FTP client object instance (Used in case logging in using speed dial)
        If IsNothing(ClientFTP) Then
            ClientFTP = New FtpClient With {
                            .Host = Address,
                            .Port = Port,
                            .RetryAttempts = 3,
                            .EncryptionMode = EncryptionMode
                        }
        End If

        'Prompt for password
        W(DoTranslation("Password for {0}: ", currentLang), False, ColTypes.Input, user)

        'Get input
        pass = ReadLineNoInput("*")
        Console.WriteLine()

        'Set up credentials
        ClientFTP.Credentials = New NetworkCredential(user, pass)

        'Connect to FTP
        ConnectFTP()
    End Sub

    ''' <summary>
    ''' Tries to connect to the FTP server
    ''' </summary>
    ''' <param name="address">An FTP server. You may specify it like "[address]" or "[address]:[port]"</param>
    Public Sub TryToConnect(ByVal address As String)
        If connected = True Then
            W(DoTranslation("You should disconnect from server before connecting to another server", currentLang), True, ColTypes.Err)
        Else
            Try
                'Create an FTP stream to connect to
                Dim FtpHost As String = address.Replace("ftpes://", "").Replace("ftps://", "").Replace("ftp://", "").Replace(address.Substring(address.LastIndexOf(":")), "")
                Dim FtpPort As String = address.Replace("ftpes://", "").Replace("ftps://", "").Replace("ftp://", "").Replace(FtpHost + ":", "")

                'Check to see if no port is provided by client
                If FtpHost = FtpPort Then
                    FtpPort = 0 'Used for detecting of SSL is being used or not dynamically on connection
                End If

                'Make a new FTP client object instance
                ClientFTP = New FtpClient With {
                    .Host = FtpHost,
                    .Port = FtpPort,
                    .RetryAttempts = 3,
                    .EncryptionMode = FtpEncryptionMode.Explicit
                }

                'Get encryption type from address
                If address.StartsWith("ftp://") Then
                    ClientFTP.EncryptionMode = FtpEncryptionMode.None
                ElseIf address.StartsWith("ftps://") Then
                    ClientFTP.EncryptionMode = FtpEncryptionMode.Implicit
                ElseIf address.StartsWith("ftpes://") Then
                    ClientFTP.EncryptionMode = FtpEncryptionMode.Explicit
                End If

                'Add handler for SSL validation
                AddHandler ClientFTP.ValidateCertificate, New FtpSslValidation(AddressOf TryToValidate)

                'Prompt for username
                W(DoTranslation("Username for {0}: ", currentLang), False, ColTypes.Input, address)
                user = Console.ReadLine()
                If user = "" Then
                    Wdbg("W", "User is not provided. Fallback to ""anonymous""")
                    user = "anonymous"
                End If

                PromptForPassword(user)
            Catch ex As Exception
                Wdbg("W", "Error connecting to {0}: {1}", address, ex.Message)
                WStkTrc(ex)
                If DebugMode = True Then
                    W(DoTranslation("Error when trying to connect to {0}: {1}", currentLang) + vbNewLine +
                      DoTranslation("Stack Trace: {2}", currentLang), True, ColTypes.Err, address, ex.Message, ex.StackTrace)
                Else
                    W(DoTranslation("Error when trying to connect to {0}: {1}", currentLang), True, ColTypes.Err, address, ex.Message)
                End If
            End Try
        End If
    End Sub

    ''' <summary>
    ''' Tries to connect to the FTP server.
    ''' </summary>
    Private Sub ConnectFTP()
        'Prepare profiles
        W(DoTranslation("Preparing profiles... It could take several minutes...", currentLang), True, ColTypes.Neutral)
        Dim profiles As List(Of FtpProfile) = ClientFTP.AutoDetect(FTPFirstProfileOnly)
        Dim profsel As New FtpProfile
        Wdbg("I", "Profile count: {0}", profiles.Count)
        If profiles.Count > 1 Then 'More than one profile
            W(DoTranslation("More than one profile found. Select one:", currentLang) + vbNewLine +
              "#, " + DoTranslation("Host Name, Username, Data Type, Encoding, Encryption, Protocols", currentLang), True, ColTypes.Neutral)
            For i As Integer = 0 To profiles.Count - 1
                W($"{i + 1}: {profiles(i).Host}, {profiles(i).Credentials.UserName}, {profiles(i).DataConnection}, {profiles(i).Encoding.EncodingName}, {profiles(i).Encryption}, {profiles(i).Protocols}", True, ColTypes.Neutral)
            Next
            Dim profanswer As Char
            Dim profanswered As Boolean
            While Not profanswered
                profanswer = Console.ReadKey(True).KeyChar
                Wdbg("I", "Selection: {0}", profanswer)
                If IsNumeric(profanswer) Then
                    Try
                        Wdbg("I", "Profile selected")
                        profsel = profiles(Val(profanswer) - 1)
                        profanswered = True
                    Catch ex As Exception
                        Wdbg("I", "Profile invalid")
                        W(DoTranslation("Invalid profile selection.", currentLang) + vbNewLine, True, ColTypes.Err)
                        WStkTrc(ex)
                    End Try
                End If
            End While
        ElseIf profiles.Count = 1 Then
            profsel = profiles(0) 'Select first profile
        Else 'Failed trying to get profiles
            W(DoTranslation("Error when trying to connect to {0}: Connection timeout or lost connection", currentLang), True, ColTypes.Err, ClientFTP.Host)
            Exit Sub
        End If

        'Connect
        W(DoTranslation("Trying to connect to {0} with profile {1}...", currentLang), True, ColTypes.Neutral, ClientFTP.Host, profiles.IndexOf(profsel))
        Wdbg("I", "Connecting to {0} with {1}...", ClientFTP.Host, profiles.IndexOf(profsel))
        ClientFTP.Connect(profsel)

        'Show that it's connected
        W(DoTranslation("Connected to {0}", currentLang), True, ColTypes.Neutral, ClientFTP.Host)
        Wdbg("I", "Connected.")
        connected = True

        'Prepare to print current FTP directory
        currentremoteDir = ClientFTP.GetWorkingDirectory
        Wdbg("I", "Working directory: {0}", currentremoteDir)
        ftpsite = ClientFTP.Host

        'Write connection information to Speed Dial file if it doesn't exist there
        If Not File.Exists(paths("FTPSpeedDial")) Then
            Dim FileTemp As StreamWriter = File.CreateText(paths("FTPSpeedDial"))
            FileTemp.Close()
        End If
        Dim SpeedDialLines As String() = File.ReadAllLines(paths("FTPSpeedDial"))
        Wdbg("I", "Speed dial length: {0}", SpeedDialLines.Length)
        If SpeedDialLines.Contains(ftpsite + "," + CStr(ClientFTP.Port) + "," + user) Then
            Wdbg("I", "Site already there.")
            Exit Sub
        Else
            'Speed dial format is below:
            'Site,Port,Username,Encryption
            Dim SpeedDialWriter As New StreamWriter(paths("FTPSpeedDial")) With {.AutoFlush = True}
            Wdbg("I", "Opened stream for speed dial.")
            SpeedDialWriter.WriteLine(ftpsite + "," + CStr(ClientFTP.Port) + "," + user + "," + ClientFTP.EncryptionMode.ToString)
            Wdbg("I", "Written information to file.")
            SpeedDialWriter.Close()
            Wdbg("I", "Closed stream for speed dial.")
        End If
    End Sub

    ''' <summary>
    ''' Tries to validate certificate
    ''' </summary>
    Public Sub TryToValidate(control As FtpClient, e As FtpSslValidationEventArgs)
        Wdbg("I", "Certificate checks")
        If e.PolicyErrors = SslPolicyErrors.None Then
            Wdbg("I", "Certificate accepted.")
            Wdbg("I", e.Certificate.GetRawCertDataString)
            e.Accept = True
        Else
            Wdbg("W", $"Certificate error is {e.PolicyErrors}")
            W(DoTranslation("During certificate validation, there are certificate errors. It might be the first time you've connected to the server or the certificate might have been expired. Here's an error:", currentLang), True, ColTypes.Err)
            W("- {0}", True, ColTypes.Err, e.PolicyErrors.ToString)
            Dim Answer As String = ""
            Do Until Answer.ToLower = "y" Or Answer.ToLower = "n"
                W(DoTranslation("Are you sure that you want to connect?", currentLang) + " (y/n) ", False, ColTypes.Input)
                Answer = Console.ReadKey.KeyChar
                Console.WriteLine()
                Wdbg("I", $"Answer is {Answer}")
                If Answer.ToLower = "y" Then
                    Wdbg("W", "Certificate accepted, although there are errors.")
                    Wdbg("I", e.Certificate.GetRawCertDataString)
                    e.Accept = True
                ElseIf Answer.ToLower <> "n" Then
                    Wdbg("W", "Invalid answer.")
                    W(DoTranslation("Invalid answer. Please try again.", currentLang), True, ColTypes.Err)
                End If
            Loop
        End If
    End Sub

    ''' <summary>
    ''' Opens speed dial prompt
    ''' </summary>
    Sub QuickConnect()
        If File.Exists(paths("FTPSpeedDial")) Then
            Dim SpeedDialLines As String() = File.ReadAllLines(paths("FTPSpeedDial"))
            Wdbg("I", "Speed dial length: {0}", SpeedDialLines.Length)
            Dim Counter As Integer = 1
            Dim Answer As String
            Dim Answering As Boolean = True
            If Not SpeedDialLines.Count = 0 Then
                For Each SpeedDialLine As String In SpeedDialLines
                    Wdbg("I", "Speed dial line: {0}", SpeedDialLine)
                    W(DoTranslation("Select an address to connect to:", currentLang), True, ColTypes.Neutral)
                    W("{0}: {1}", True, ColTypes.Neutral, Counter, SpeedDialLine)
                    Counter += 1
                Next
                While Answering
                    W(">> ", False, ColTypes.Input)
                    Answer = Console.ReadKey.KeyChar
                    Wdbg("I", "Response: {0}", Answer)
                    Console.WriteLine()
                    If IsNumeric(Answer) Then
                        Wdbg("I", "Response is numeric. IsNumeric(Answer) returned true. Checking to see if in-bounds...")
                        Dim AnswerInt As Integer = Answer
                        If AnswerInt <= SpeedDialLines.Length Then
                            Answering = False
                            Wdbg("I", "Response is in-bounds. Connecting...")
                            Dim ChosenSpeedDialLine As String = SpeedDialLines(AnswerInt - 1)
                            Wdbg("I", "Chosen connection: {0}", ChosenSpeedDialLine)
                            Dim ChosenLineSeparation As String() = ChosenSpeedDialLine.Split(",")
                            Dim Address As String = ChosenLineSeparation(0)
                            Dim Port As String = ChosenLineSeparation(1)
                            Dim Username As String = ChosenLineSeparation(2)
                            Dim Encryption As FtpEncryptionMode = ChosenLineSeparation(3)
                            Wdbg("I", "Address: {0}, Port: {1}, Username: {2}, Encryption: {3}", Address, Port, Username, Encryption)
                            PromptForPassword(Username, Address, Port, Encryption)
                        Else
                            Wdbg("I", "Response is out-of-bounds. Retrying...")
                            W(DoTranslation("The selection is out of range. Select between 1-{0}. Try again.", currentLang), True, ColTypes.Err, SpeedDialLines.Length)
                        End If
                    Else
                        Wdbg("W", "Response isn't numeric. IsNumeric(Answer) returned false.")
                        W(DoTranslation("The selection is not a number. Try again.", currentLang), True, ColTypes.Err)
                    End If
                End While
            Else
                Wdbg("E", "Speed dial is empty. Lines count is 0.")
                W(DoTranslation("Speed dial is empty. Connect to a server to add an address to it.", currentLang), True, ColTypes.Err)
            End If
        Else
            Wdbg("E", "File doesn't exist.")
            W(DoTranslation("Speed dial doesn't exist. Connect to a server to add an address to it.", currentLang), True, ColTypes.Err)
        End If
    End Sub

End Module

Class FTPTracer
    Inherits TraceListener 'Both Write and WriteLine do exactly the same thing, which is writing to a debugger.

    ''' <summary>
    ''' Writes any message that the tracer has received to the debugger.
    ''' </summary>
    ''' <param name="Message">A message</param>
    Public Overloads Overrides Sub Write(ByVal Message As String)
        Wdbg("I", Message)
    End Sub

    ''' <summary>
    ''' Writes any message that the tracer has received to the debugger. Please note that this does exactly as Write() since the debugger only supports writing with newlines.
    ''' </summary>
    ''' <param name="Message">A message</param>
    Public Overloads Overrides Sub WriteLine(ByVal Message As String)
        Wdbg("I", Message)
    End Sub
End Class