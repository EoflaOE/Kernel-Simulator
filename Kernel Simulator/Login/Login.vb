﻿
'    Kernel Simulator  Copyright (C) 2018-2019  EoflaOE
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

Public Module Login

    'Variables
    Public userword As New Dictionary(Of String, String)()      'List of usernames and passwords
    Public answeruser As String                                 'Input of username
    Public answerpass As String                                 'Input of password
    Public password As String                                   'Password for user we're logging in to
    Public signedinusrnm As String                              'Username that is signed in
    Private showMOTDOnceFlag As Boolean = True                  'Show MOTD every LoginPrompt() session

    Sub LoginPrompt()
        While True
            'Fire event PreLogin
            EventManager.RaisePreLogin()

            'Extremely rare situation except if modded: Check to see if there are any users
            If userword.Count = 0 Then 'Check if user amount is zero
                Throw New EventsAndExceptions.NullUsersException(DoTranslation("There is no more users remaining in the list.", currentLang))
            End If

            'Prompts user to log-in
            If clsOnLogin = True Then
                Console.Clear()
            End If

            'Generate user list
            Wln(vbNewLine + DoTranslation("Available usernames: {0}", currentLang), "neutralText", String.Join(", ", userword.Keys))

            'Login process
            If (showMOTD = False) Or (showMOTDOnceFlag = False) Then
                W(vbNewLine + DoTranslation("Username: ", currentLang), "input")
            ElseIf showMOTDOnceFlag = True And showMOTD = True Then
                W(vbNewLine + ProbePlaces(MOTDMessage) + vbNewLine + vbNewLine + DoTranslation("Username: ", currentLang), "input")
            End If
            showMOTDOnceFlag = False
            answeruser = Console.ReadLine()

            'Parse input
            If InStr(answeruser, " ") > 0 Then
                Wln(DoTranslation("Spaces are not allowed.", currentLang), "neutralText")
            ElseIf answeruser.IndexOfAny("[~`!@#$%^&*()-+=|{}':;.,<>/?]".ToCharArray) <> -1 Then
                Wln(DoTranslation("Special characters are not allowed.", currentLang), "neutralText")
            ElseIf userword.ContainsKey(answeruser) Then
                If disabledList(answeruser) = False Then
                    ShowPasswordPrompt(answeruser)
                Else
                    Wln(DoTranslation("User is disabled.", currentLang), "neutralText")
                End If
            Else
                Wln(DoTranslation("Wrong username.", currentLang), "neutralText")
            End If
        End While
    End Sub

    Sub ShowPasswordPrompt(ByVal usernamerequested As String)

        'Error handler
        On Error Resume Next

        'Prompts user to enter a user's password
        While True
            Wdbg("User {0} is not disabled", usernamerequested)

            'Get the password from dictionary
            password = userword.Item(usernamerequested)

            'Check if there's the password
            If Not password = Nothing Then
                'Wait for input
                W(DoTranslation("{0}'s password: ", currentLang), "input", usernamerequested)

                'Get input
                While True
                    Dim character As Char = Console.ReadKey(True).KeyChar
                    Wdbg("Parse char: {0}", character)
                    If character = vbCr Or character = vbLf Then
                        Console.WriteLine()
                        Exit While
                    Else
                        answerpass += character
                    End If
                End While

                'Parse password input
                If InStr(answerpass, " ") > 0 Then
                    Wln(DoTranslation("Spaces are not allowed.", currentLang), "neutralText")
                    If Not maintenance Then
                        If Not LockMode Then
                            Exit Sub
                        End If
                    End If
                Else
                    If userword.TryGetValue(usernamerequested, password) AndAlso password = answerpass Then
                        Wdbg("ASSERT(Parse({0}, {1})) = True | ASSERT({1} = {2}) = True", usernamerequested, password, answerpass)

                        'Log-in instantly
                        SignIn(usernamerequested)
                        Exit Sub
                    Else
                        Wln(DoTranslation("Wrong password.", currentLang), "neutralText")
                        If Not maintenance Then
                            If Not LockMode Then
                                Exit Sub
                            End If
                        End If
                    End If
                End If
            Else
                'Log-in instantly
                SignIn(usernamerequested)
                Exit Sub
            End If
        End While

    End Sub

    Public Sub SignIn(ByVal signedInUser As String)

        'Release lock
        If LockMode Then
            LockMode = False
            EventManager.RaisePostUnlock()
            Exit Sub
        End If

        'Resets inputs
        answerpass = Nothing
        answeruser = Nothing
        arguser = Nothing
        argword = Nothing

        'Resets outputs
        password = Nothing
        LoginFlag = False
        CruserFlag = False
        signedinusrnm = Nothing

        'Sign in to user.
        signedinusrnm = signedInUser
        If LockMode = True Then LockMode = False
        showMOTDOnceFlag = True
        Wln(ProbePlaces(MAL), "neutralText")

        'Fire event PostLogin
        EventManager.RaisePostLogin()

        'Initialize shell
        InitializeShell()

    End Sub

End Module
