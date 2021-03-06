
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

Public Module HelpSystem

    'This dictionary is the definitions for commands.
    Public definitions As Dictionary(Of String, String)
    Public moddefs As New Dictionary(Of String, String)

    ''' <summary>
    ''' Updates the shell help dictionary to reflect the available commands
    ''' </summary>
    Public Sub InitHelp()
        definitions = New Dictionary(Of String, String) From {{"adduser", DoTranslation("Adds users", currentLang)},
                                                              {"alias", DoTranslation("Adds aliases to commands", currentLang)},
                                                              {"arginj", DoTranslation("Injects arguments to the kernel (reboot required)", currentLang)},
                                                              {"beep", DoTranslation("Beep in 'n' Hz and time in 'n' milliseconds", currentLang)},
                                                              {"blockdbgdev", DoTranslation("Block a debug device by IP address", currentLang)},
                                                              {"bsynth", DoTranslation("Loads the synth file and plays it.", currentLang)},
                                                              {"calc", DoTranslation("Calculator to calculate expressions.", currentLang)},
                                                              {"cdbglog", DoTranslation("Deletes everything in debug log", currentLang)},
                                                              {"chattr", DoTranslation("Changes attribute of a file", currentLang)},
                                                              {"chdir", DoTranslation("Changes directory", currentLang)},
                                                              {"chhostname", DoTranslation("Changes host name", currentLang)},
                                                              {"chlang", DoTranslation("Changes language", currentLang)},
                                                              {"chmal", DoTranslation("Changes MAL, the MOTD After Login", currentLang)},
                                                              {"chmotd", DoTranslation("Changes MOTD, the Message Of The Day", currentLang)},
                                                              {"choice", DoTranslation("Makes user choices", currentLang)},
                                                              {"chpwd", DoTranslation("Changes password for current user", currentLang)},
                                                              {"chusrname", DoTranslation("Changes user name", currentLang)},
                                                              {"cls", DoTranslation("Clears the screen", currentLang)},
                                                              {"copy", DoTranslation("Creates another copy of a file under different directory or name.", currentLang)},
                                                              {"debuglog", DoTranslation("Shows debug logs", currentLang)},
                                                              {"dirinfo", DoTranslation("Provides information about a directory", currentLang)},
                                                              {"disconndbgdev", DoTranslation("Disconnect a debug device", currentLang)},
                                                              {"dismissnotif", DoTranslation("Dismisses a notification", currentLang)},
                                                              {"echo", DoTranslation("Writes text into the console", currentLang)},
                                                              {"edit", DoTranslation("Edits a text file", currentLang)},
                                                              {"fileinfo", DoTranslation("Provides information about a file", currentLang)},
                                                              {"ftp", DoTranslation("Use an FTP shell to interact with servers", currentLang)},
                                                              {"get", DoTranslation("Downloads a file to current working directory", currentLang)},
                                                              {"help", DoTranslation("Help page", currentLang)},
                                                              {"hwinfo", DoTranslation("Prints hardware information", currentLang)},
                                                              {"input", DoTranslation("Allows user to enter input", currentLang)},
                                                              {"list", DoTranslation("List file/folder contents in current folder", currentLang)},
                                                              {"lockscreen", DoTranslation("Locks your screen with a password", currentLang)},
                                                              {"logout", DoTranslation("Logs you out", currentLang)},
                                                              {"loteresp", DoTranslation("Respond to love or hate comments.", currentLang)},
                                                              {"lsdbgdev", DoTranslation("Lists debugging devices connected", currentLang)},
                                                              {"lsmail", DoTranslation("Lists all mails in the specific user.", currentLang)},
                                                              {"mathbee", DoTranslation("See if you can solve mathematical equations on time", currentLang)},
                                                              {"md", DoTranslation("Creates a directory", currentLang)},
                                                              {"mkfile", DoTranslation("Makes a new file", currentLang)},
                                                              {"mktheme", DoTranslation("Makes a new theme", currentLang)},
                                                              {"move", DoTranslation("Moves a file to another directory", currentLang)},
                                                              {"netinfo", DoTranslation("Lists information about all available interfaces", currentLang)},
                                                              {"perm", DoTranslation("Manage permissions for users", currentLang)},
                                                              {"ping", DoTranslation("Pings an address", currentLang)},
                                                              {"put", DoTranslation("Uploads a file to specified website", currentLang)},
                                                              {"reboot", DoTranslation("Restarts your computer (WARNING: No syncing, because it is not a final kernel)", currentLang)},
                                                              {"reloadconfig", DoTranslation("Reloads configuration file that is edited.", currentLang)},
                                                              {"reloadmods", DoTranslation("Reloads mods.", currentLang)},
                                                              {"reloadsaver", DoTranslation("Reloads screensaver file in KSMods", currentLang)},
                                                              {"rexec", DoTranslation("Remotely executes a command to remote PC", currentLang)},
                                                              {"rm", DoTranslation("Removes a directory or a file", currentLang)},
                                                              {"rdebug", DoTranslation("Enables or disables remote debugging.", currentLang)},
                                                              {"rmuser", DoTranslation("Removes a user from the list", currentLang)},
                                                              {"savescreen", DoTranslation("Saves your screen from burn outs", currentLang)},
                                                              {"search", DoTranslation("Searches for specified string in the provided file", currentLang)},
                                                              {"setsaver", DoTranslation("Sets up kernel screensavers", currentLang)},
                                                              {"setthemes", DoTranslation("Sets up kernel themes", currentLang)},
                                                              {"settings", DoTranslation("Changes kernel configuration", currentLang)},
                                                              {"sftp", DoTranslation("Lets you use an SSH FTP server", currentLang)},
                                                              {"shownotifs", DoTranslation("Shows all received notifications", currentLang)},
                                                              {"showtd", DoTranslation("Shows date and time", currentLang)},
                                                              {"showtdzone", DoTranslation("Shows date and time in zones", currentLang)},
                                                              {"shutdown", DoTranslation("The kernel will be shut down", currentLang)},
                                                              {"spellbee", DoTranslation("See if you can spell words correctly on time", currentLang)},
                                                              {"sshell", DoTranslation("Connects to an SSH server.", currentLang)},
                                                              {"sumfile", DoTranslation("Calculates file sums.", currentLang)},
                                                              {"sumfiles", DoTranslation("Calculates sums of files in specified directory.", currentLang)},
                                                              {"sysinfo", DoTranslation("System information", currentLang)},
                                                              {"unblockdbgdev", DoTranslation("Unblock a debug device by IP address", currentLang)},
                                                              {"update", DoTranslation("System update", currentLang)},
                                                              {"usermanual", DoTranslation("Takes you to our GitHub Wiki.", currentLang)},
                                                              {"verify", DoTranslation("Verifies sanity of the file", currentLang)},
                                                              {"weather", DoTranslation("Shows weather info for specified city. Uses OpenWeatherMap.", currentLang)}}
    End Sub

    ''' <summary>
    ''' Shows the help of a command, or command list if nothing is specified
    ''' </summary>
    ''' <param name="command">A specified command</param>
    Public Sub ShowHelp(Optional ByVal command As String = "")

        Dim wholesslist As String() = IO.Directory.GetFiles(paths("Mods"), "*SS.m", IO.SearchOption.TopDirectoryOnly)
        Dim NormalUserCmds As New List(Of String)
        If command = "" Then

            If simHelp = False Then
                For Each cmd As String In definitions.Keys
                    If (Not strictCmds.Contains(cmd)) Or (strictCmds.Contains(cmd) And adminList(signedinusrnm)) Then
                        W("- {0}: ", False, ColTypes.HelpCmd, cmd) : W("{0}", True, ColTypes.HelpDef, definitions(cmd))
                    End If
                Next
                For Each cmd As String In moddefs.Keys
                    W("- {0}: ", False, ColTypes.HelpCmd, cmd) : W("{0}", True, ColTypes.HelpDef, moddefs(cmd))
                Next
                For Each cmd As String In Aliases.Keys
                    W("- {0}: ", False, ColTypes.HelpCmd, cmd) : W("{0}", True, ColTypes.HelpDef, definitions(Aliases(cmd)))
                Next
                W(DoTranslation("* You can use multiple commands using the colon between commands.", currentLang), True, ColTypes.Neutral)
            Else
                For Each cmd As String In Aliases.Keys
                    W("{0}({1}), ", False, ColTypes.HelpCmd, cmd, Aliases(cmd))
                Next
                For Each cmd As String In moddefs.Keys
                    W("{0}, ", False, ColTypes.HelpCmd, cmd)
                Next
                For Each cmd As String In availableCommands
                    If (Not strictCmds.Contains(cmd)) Or (strictCmds.Contains(cmd) And adminList(signedinusrnm)) Then
                        NormalUserCmds.Add(cmd)
                    End If
                Next
                W(String.Join(", ", NormalUserCmds), True, ColTypes.HelpCmd)
            End If

        ElseIf command = "adduser" Then

            W(DoTranslation("Usage:", currentLang) + " adduser <userName> [password] [confirm]", True, ColTypes.Neutral)

        ElseIf command = "alias" Then

            W(DoTranslation("Usage:", currentLang) + " alias <rem/add> <1=Shell/2=RDebug/3=FTPShell/4=SFTPShell/5=MailShell> <alias> <cmd>", True, ColTypes.Neutral)

        ElseIf command = "arginj" Then

            W(DoTranslation("Usage:", currentLang) + " arginj [Arguments separated by spaces]" + vbNewLine +
              "       " + DoTranslation("where arguments will be {0}", currentLang), True, ColTypes.Neutral, String.Join(", ", AvailableArgs))

        ElseIf command = "beep" Then

            W(DoTranslation("Usage:", currentLang) + " beep <37-32767 Hz> <milliseconds>", True, ColTypes.Neutral)

        ElseIf command = "blockdbgdev" Then

            W(DoTranslation("Usage:", currentLang) + " blockdbgdev <ipaddress>", True, ColTypes.Neutral)

        ElseIf command = "bsynth" Then

            W(DoTranslation("Usage:", currentLang) + " bsynth <script-file>", True, ColTypes.Neutral)

        ElseIf command = "calc" Then

            W(DoTranslation("Usage:", currentLang) + " calc <expression>", True, ColTypes.Neutral)

        ElseIf command = "cdbglog" Then

            W(DoTranslation("Usage:", currentLang) + " cdbglog: " + DoTranslation("Deletes everything in debug log", currentLang), True, ColTypes.Neutral)

        ElseIf command = "chattr" Then

            W(DoTranslation("Usage:", currentLang) + " chattr <file> +/-<attributes>", True, ColTypes.Neutral)
            W(DoTranslation("where <attributes> is one of the following:", currentLang) + vbNewLine, True, ColTypes.Neutral)
            W("- Normal: ", False, ColTypes.HelpCmd) : W(DoTranslation("The file is a normal file", currentLang), True, ColTypes.HelpDef)                   'Normal   = 128
            W("- ReadOnly: ", False, ColTypes.HelpCmd) : W(DoTranslation("The file is a read-only file", currentLang), True, ColTypes.HelpDef)              'ReadOnly = 1
            W("- Hidden: ", False, ColTypes.HelpCmd) : W(DoTranslation("The file is a hidden file", currentLang), True, ColTypes.HelpDef)                   'Hidden   = 2
            W("- Archive: ", False, ColTypes.HelpCmd) : W(DoTranslation("The file is an archive. Used for backups.", currentLang), True, ColTypes.HelpDef)  'Archive  = 32

        ElseIf command = "chdir" Then

            W(DoTranslation("Usage:", currentLang) + " chdir <directory/..>", True, ColTypes.Neutral)

        ElseIf command = "chhostname" Then

            W(DoTranslation("Usage:", currentLang) + " chhostname <HostName>", True, ColTypes.Neutral)

        ElseIf command = "chlang" Then

            W(DoTranslation("Usage:", currentLang) + " chlang <language>" + vbNewLine +
              "<language>: " + String.Join("/", availableLangs), True, ColTypes.Neutral)

        ElseIf command = "chmotd" Then

            W(DoTranslation("Usage:", currentLang) + " chmotd [Message]", True, ColTypes.Neutral)

        ElseIf command = "chmal" Then

            W(DoTranslation("Usage:", currentLang) + " chmal [Message]", True, ColTypes.Neutral)

        ElseIf command = "choice" Then

            W(DoTranslation("Usage:", currentLang) + " choice <$variable> <answers> <input>" + vbNewLine +
              "       " + DoTranslation("where <$variable> is any variable that will be used to store response", currentLang) + vbNewLine +
              "       " + DoTranslation("where <answers> are one-lettered answers of the question separated in slashes", currentLang), True, ColTypes.Neutral)

        ElseIf command = "chpwd" Then

            W(DoTranslation("Usage:", currentLang) + " chpwd <Username> <UserPass> <newPass> <confirm>", True, ColTypes.Neutral)

        ElseIf command = "chusrname" Then

            W(DoTranslation("Usage:", currentLang) + " chusrname <oldUserName> <newUserName>", True, ColTypes.Neutral)

        ElseIf command = "cls" Then

            W(DoTranslation("Usage:", currentLang) + " cls: " + DoTranslation("to clear screen.", currentLang), True, ColTypes.Neutral)

        ElseIf command = "copy" Then

            W(DoTranslation("Usage:", currentLang) + " copy <source> <target>: " + DoTranslation("To copy files to another directory or different name", currentLang), True, ColTypes.Neutral)

        ElseIf command = "debuglog" Then

            W(DoTranslation("Usage:", currentLang) + " debuglog: " + DoTranslation("Shows you debug logs so you can send the log to us.", currentLang), True, ColTypes.Neutral)

        ElseIf command = "dirinfo" Then

            W(DoTranslation("Usage:", currentLang) + " dirinfo <directory>", True, ColTypes.Neutral)

        ElseIf command = "dismissnotif" Then

            W(DoTranslation("Usage:", currentLang) + " dismissnotif <notificationNumber>: " + DoTranslation("Dismisses a notification", currentLang), True, ColTypes.Neutral)

        ElseIf command = "disconndbgdev" Then

            W(DoTranslation("Usage:", currentLang) + " disconndbgdev <ip>", True, ColTypes.Neutral)

        ElseIf command = "echo" Then

            W(DoTranslation("Usage:", currentLang) + " echo <text>", True, ColTypes.Neutral)

        ElseIf command = "edit" Then

            W(DoTranslation("Usage:", currentLang) + " edit <file>", True, ColTypes.Neutral)

        ElseIf command = "fileinfo" Then

            W(DoTranslation("Usage:", currentLang) + " fileinfo <file>", True, ColTypes.Neutral)

        ElseIf command = "ftp" Then

            W(DoTranslation("Usage:", currentLang) + " ftp <server>: " + DoTranslation("Initializes the FTP shell.", currentLang), True, ColTypes.Neutral)

        ElseIf command = "get" Then

            W(DoTranslation("Usage:", currentLang) + " get <URL> [username]", True, ColTypes.Neutral)

        ElseIf command = "hwinfo" Then

            W(DoTranslation("Usage:", currentLang) + " hwinfo: " + DoTranslation("Prints hardware information", currentLang), True, ColTypes.Neutral)

        ElseIf command = "input" Then

            W(DoTranslation("Usage:", currentLang) + " input <$variable> <question>", True, ColTypes.Neutral)

        ElseIf command = "list" Then

            W(DoTranslation("Usage:", currentLang) + " list [oneDirectory]" + vbNewLine +
              "       list: " + DoTranslation("to get current directory.", currentLang), True, ColTypes.Neutral)

        ElseIf command = "loteresp" Then

            W(DoTranslation("Usage:", currentLang) + " loteresp: " + DoTranslation("Respond to love or hate comments.", currentLang), True, ColTypes.Neutral)

        ElseIf command = "lsdbgdev" Then

            W(DoTranslation("Usage:", currentLang) + " lsdbgdev" + vbNewLine +
              "       lsdbgdev: " + DoTranslation("Lists all connected debugging devices.", currentLang), True, ColTypes.Neutral)

        ElseIf command = "lsmail" Then

            W(DoTranslation("Usage:", currentLang) + " lsmail [emailAddress]", True, ColTypes.Neutral)

        ElseIf command = "reloadsaver" Then

            W(DoTranslation("Usage:", currentLang) + " reloadsaver <modNameSS.m>" + vbNewLine +
              "       " + DoTranslation("where modnameSS.m will be", currentLang) + " {0}", True, ColTypes.Neutral, String.Join(", ", wholesslist))

        ElseIf command = "lockscreen" Then

            W(DoTranslation("Usage:", currentLang) + " lockscreen: " + DoTranslation("Locks your screen with the password.", currentLang) + vbNewLine +
              "       " + DoTranslation("Friends of", currentLang) + " lockscreen: savescreen", True, ColTypes.Neutral)

        ElseIf command = "logout" Then

            W(DoTranslation("Usage:", currentLang) + " logout: " + DoTranslation("Logs you out of the user.", currentLang) + vbNewLine +
              "       " + DoTranslation("Friends of", currentLang) + " logout: reboot, shutdown", True, ColTypes.Neutral)

        ElseIf command = "mathbee" Then

            W(DoTranslation("Usage:", currentLang) + " mathbee: " + DoTranslation("See if you can solve mathematical equations on time", currentLang), True, ColTypes.Neutral)

        ElseIf command = "md" Then

            W(DoTranslation("Usage:", currentLang) + " md <anything>", True, ColTypes.Neutral)

        ElseIf command = "mkfile" Then

            W(DoTranslation("Usage:", currentLang) + " mkfile <anything>", True, ColTypes.Neutral)

        ElseIf command = "mktheme" Then

            W(DoTranslation("Usage:", currentLang) + " mktheme <themeName>", True, ColTypes.Neutral)

        ElseIf command = "move" Then

            W(DoTranslation("Usage:", currentLang) + " move <source> <target>: " + DoTranslation("To move files to another directory", currentLang), True, ColTypes.Neutral)

        ElseIf command = "netinfo" Then

            W(DoTranslation("Usage:", currentLang) + " netinfo: " + DoTranslation("Get every network information", currentLang), True, ColTypes.Neutral)

        ElseIf command = "perm" Then

            W(DoTranslation("Usage:", currentLang) + " perm <userName> <Administrator/Disabled> <Allow/Disallow>", True, ColTypes.Neutral)

        ElseIf command = "ping" Then

            W(DoTranslation("Usage:", currentLang) + " ping [times] <Address1> <Address2> ...", True, ColTypes.Neutral)

        ElseIf command = "put" Then

            W(DoTranslation("Usage:", currentLang) + " put <FileName> <URL> [username]", True, ColTypes.Neutral)

        ElseIf command = "rm" Then

            W(DoTranslation("Usage:", currentLang) + " rm <directory/file>", True, ColTypes.Neutral)

        ElseIf command = "rdebug" Then

            W(DoTranslation("Usage:", currentLang) + " rdebug: " + DoTranslation("Enables or disables remote debugging.", currentLang), True, ColTypes.Neutral)

        ElseIf command = "reboot" Then

            W(DoTranslation("Usage:", currentLang) + " reboot: " + DoTranslation("Restarts your simulated computer.", currentLang) + vbNewLine +
              "       " + DoTranslation("Friends of", currentLang) + " reboot: shutdown, logout", True, ColTypes.Neutral)

        ElseIf command = "reloadmods" Then

            W(DoTranslation("Usage:", currentLang) + " reloadmods: " + DoTranslation("Reloads modifications.", currentLang), True, ColTypes.Neutral)

        ElseIf command = "reloadconfig" Then

            W(DoTranslation("Usage:", currentLang) + " reloadconfig: " + DoTranslation("Reloads the configuration that is changed by the end-user or by tool.", currentLang) + vbNewLine +
              "       " + DoTranslation("Colors doesn't require a restart, but most of the settings require you to restart.", currentLang), True, ColTypes.Neutral)

        ElseIf command = "rexec" Then

            W(DoTranslation("Usage:", currentLang) + " rexec <address> <command>: " + DoTranslation("Remotely executes a command to remote PC", currentLang), True, ColTypes.Neutral)

        ElseIf command = "rmuser" Then

            W(DoTranslation("Usage:", currentLang) + " rmuser <Username>", True, ColTypes.Neutral)

        ElseIf command = "savescreen" Then

            W(DoTranslation("Usage:", currentLang) + " savescreen: " + DoTranslation("shows you a selected screensaver, while protecting your screen from burn outs.", currentLang) + vbNewLine +
              "       " + DoTranslation("Friends of", currentLang) + " savescreen: lockscreen", True, ColTypes.Neutral)

        ElseIf command = "search" Then

            W(DoTranslation("Usage:", currentLang) + " search <StringEnclosedInDoubleQuotes> <File>", True, ColTypes.Neutral)

        ElseIf command = "setsaver" Then

            W(DoTranslation("Usage:", currentLang) + " setsaver <modNameSS.m/{0}>", True, ColTypes.Neutral, String.Join("/", ScrnSvrdb.Keys))
            If wholesslist.Length > 0 Then
                W("       " + DoTranslation("where modnameSS.m will be", currentLang) + " {0}", True, ColTypes.Neutral, String.Join(", ", wholesslist))
            End If

        ElseIf command = "setthemes" Then

            W(DoTranslation("Usage:", currentLang) + " setthemes <Theme>" + vbNewLine +
              "       " + "<Theme>: " + String.Join(", ", colorTemplates.Keys), True, ColTypes.Neutral)

        ElseIf command = "settings" Then

            W(DoTranslation("Usage:", currentLang) + " settings", True, ColTypes.Neutral)

        ElseIf command = "sftp" Then

            W(DoTranslation("Usage:", currentLang) + " sftp <server>: " + DoTranslation("Initializes the SFTP shell.", currentLang), True, ColTypes.Neutral)

        ElseIf command = "shownotifs" Then

            W(DoTranslation("Usage:", currentLang) + " shownotifs: " + DoTranslation("Shows all received notifications", currentLang), True, ColTypes.Neutral)

        ElseIf command = "showtd" Then

            W(DoTranslation("Usage:", currentLang) + " showtd: " + DoTranslation("Shows the date and time.", currentLang), True, ColTypes.Neutral)

        ElseIf command = "showtdzone" Then

            W(DoTranslation("Usage:", currentLang) + " showtdzone <timezone/all>: " + DoTranslation("Shows the date and time in zones.", currentLang), True, ColTypes.Neutral)

        ElseIf command = "shutdown" Then

            W(DoTranslation("Usage:", currentLang) + " shutdown: " + DoTranslation("Shuts down your simulated computer.", currentLang) + vbNewLine +
              "       " + DoTranslation("Friends of", currentLang) + " shutdown: reboot, logout", True, ColTypes.Neutral)

        ElseIf command = "spellbee" Then

            W(DoTranslation("Usage:", currentLang) + " spellbee: " + DoTranslation("See if you can spell words correctly on time", currentLang), True, ColTypes.Neutral)

        ElseIf command = "sshell" Then

            W(DoTranslation("Usage:", currentLang) + " sshell <address> <port> <username>: " + DoTranslation("Connects to an SSH server.", currentLang), True, ColTypes.Neutral)

        ElseIf command = "sumfile" Then

            W(DoTranslation("Usage:", currentLang) + " sumfile <MD5/SHA1/SHA256/SHA512> <file>: " + DoTranslation("Calculates file sums.", currentLang), True, ColTypes.Neutral)

        ElseIf command = "sumfiles" Then

            W(DoTranslation("Usage:", currentLang) + " sumfiles <MD5/SHA1/SHA256/SHA512> <dir> [outputFile]", True, ColTypes.Neutral)

        ElseIf command = "sysinfo" Then

            W(DoTranslation("Usage:", currentLang) + " sysinfo: " + DoTranslation("Shows system information and versions.", currentLang), True, ColTypes.Neutral)

        ElseIf command = "unblockdbgdev" Then

            W(DoTranslation("Usage:", currentLang) + " unblockdbgdev <ipaddress>", True, ColTypes.Neutral)

        ElseIf command = "update" Then

            W(DoTranslation("Usage:", currentLang) + " update: " + DoTranslation("System update", currentLang), True, ColTypes.Neutral)

        ElseIf command = "usermanual" Then

            W(DoTranslation("Usage:", currentLang) + " usermanual: " + DoTranslation("Takes you to our GitHub Wiki.", currentLang), True, ColTypes.Neutral)

        ElseIf command = "verify" Then

            W(DoTranslation("Usage:", currentLang) + " verify <MD5/SHA1/SHA256/SHA512> <calculatedhash> <hashfile/expectedhash> <file>", True, ColTypes.Neutral)

        ElseIf command = "weather" Then

            W(DoTranslation("Usage:", currentLang) + " weather <CityID/CityName>: " + DoTranslation("Shows weather info for specified city. Uses OpenWeatherMap.", currentLang) + vbNewLine +
                                                                                      DoTranslation("You can always consult http://bulk.openweathermap.org/sample/city.list.json.gz for the list of cities with their IDs.", currentLang), True, ColTypes.Neutral)

        Else

            W(DoTranslation("No help for command ""{0}"".", currentLang), True, ColTypes.Err, command)

        End If

    End Sub

End Module
