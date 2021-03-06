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

Public Class Exceptions

    ''' <summary>
    ''' There are no more users remaining
    ''' </summary>
    Public Class NullUsersException
        Inherits Exception
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal message As String)
            MyBase.New(message)
        End Sub
        Public Sub New(ByVal message As String, ByVal e As Exception)
            MyBase.New(message, e)
        End Sub
    End Class

    ''' <summary>
    ''' Not enough command arguments supplied in all shells
    ''' </summary>
    Public Class NotEnoughArgumentsException
        Inherits Exception
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal message As String)
            MyBase.New(message)
        End Sub
        Public Sub New(ByVal message As String, ByVal e As Exception)
            MyBase.New(message, e)
        End Sub
    End Class

    ''' <summary>
    ''' Thrown when alias source and destination have the same name
    ''' </summary>
    Public Class AliasInvalidOperationException
        Inherits Exception
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal message As String)
            MyBase.New(message)
        End Sub
        Public Sub New(ByVal message As String, ByVal e As Exception)
            MyBase.New(message, e)
        End Sub
    End Class

    ''' <summary>
    ''' Thrown when alias type is nonexistent
    ''' </summary>
    Public Class AliasNoSuchTypeException
        Inherits Exception
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal message As String)
            MyBase.New(message)
        End Sub
        Public Sub New(ByVal message As String, ByVal e As Exception)
            MyBase.New(message, e)
        End Sub
    End Class

    ''' <summary>
    ''' Thrown when alias source command is nonexistent
    ''' </summary>
    Public Class AliasNoSuchCommandException
        Inherits Exception
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal message As String)
            MyBase.New(message)
        End Sub
        Public Sub New(ByVal message As String, ByVal e As Exception)
            MyBase.New(message, e)
        End Sub
    End Class

    ''' <summary>
    ''' Thrown when alias already exists
    ''' </summary>
    Public Class AliasAlreadyExistsException
        Inherits Exception
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal message As String)
            MyBase.New(message)
        End Sub
        Public Sub New(ByVal message As String, ByVal e As Exception)
            MyBase.New(message, e)
        End Sub
    End Class

    ''' <summary>
    ''' Thrown when alias is nonexistent
    ''' </summary>
    Public Class AliasNoSuchAliasException
        Inherits Exception
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal message As String)
            MyBase.New(message)
        End Sub
        Public Sub New(ByVal message As String, ByVal e As Exception)
            MyBase.New(message, e)
        End Sub
    End Class

    ''' <summary>
    ''' Thrown when language is nonexistent
    ''' </summary>
    Public Class NoSuchLanguageException
        Inherits Exception
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal message As String)
            MyBase.New(message)
        End Sub
        Public Sub New(ByVal message As String, ByVal e As Exception)
            MyBase.New(message, e)
        End Sub
    End Class

    ''' <summary>
    ''' Thrown when synth file is invalid
    ''' </summary>
    Public Class InvalidSynthException
        Inherits Exception
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal message As String)
            MyBase.New(message)
        End Sub
        Public Sub New(ByVal message As String, ByVal e As Exception)
            MyBase.New(message, e)
        End Sub
    End Class

    ''' <summary>
    ''' Thrown when screensaver is nonexistent
    ''' </summary>
    Public Class NoSuchScreensaverException
        Inherits Exception
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal message As String)
            MyBase.New(message)
        End Sub
        Public Sub New(ByVal message As String, ByVal e As Exception)
            MyBase.New(message, e)
        End Sub
    End Class

    ''' <summary>
    ''' Thrown when there is a config error
    ''' </summary>
    Public Class ConfigException
        Inherits Exception
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal message As String)
            MyBase.New(message)
        End Sub
        Public Sub New(ByVal message As String, ByVal e As Exception)
            MyBase.New(message, e)
        End Sub
    End Class

    ''' <summary>
    ''' Thrown when there is a user creation error
    ''' </summary>
    Public Class UserCreationException
        Inherits Exception
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal message As String)
            MyBase.New(message)
        End Sub
        Public Sub New(ByVal message As String, ByVal e As Exception)
            MyBase.New(message, e)
        End Sub
    End Class

    ''' <summary>
    ''' Thrown when there is a user management error
    ''' </summary>
    Public Class UserManagementException
        Inherits Exception
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal message As String)
            MyBase.New(message)
        End Sub
        Public Sub New(ByVal message As String, ByVal e As Exception)
            MyBase.New(message, e)
        End Sub
    End Class

    ''' <summary>
    ''' Thrown when there is a user management error
    ''' </summary>
    Public Class PermissionManagementException
        Inherits Exception
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal message As String)
            MyBase.New(message)
        End Sub
        Public Sub New(ByVal message As String, ByVal e As Exception)
            MyBase.New(message, e)
        End Sub
    End Class

    ''' <summary>
    ''' Thrown when there is a hostname error
    ''' </summary>
    Public Class HostnameException
        Inherits Exception
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal message As String)
            MyBase.New(message)
        End Sub
        Public Sub New(ByVal message As String, ByVal e As Exception)
            MyBase.New(message, e)
        End Sub
    End Class

    ''' <summary>
    ''' Thrown when there is a color setting error
    ''' </summary>
    Public Class ColorException
        Inherits Exception
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal message As String)
            MyBase.New(message)
        End Sub
        Public Sub New(ByVal message As String, ByVal e As Exception)
            MyBase.New(message, e)
        End Sub
    End Class

    ''' <summary>
    ''' Thrown when there is a remote debugger device not found error
    ''' </summary>
    Public Class RemoteDebugDeviceNotFoundException
        Inherits Exception
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal message As String)
            MyBase.New(message)
        End Sub
        Public Sub New(ByVal message As String, ByVal e As Exception)
            MyBase.New(message, e)
        End Sub
    End Class

    ''' <summary>
    ''' Thrown when there is an FTP filesystem error
    ''' </summary>
    Public Class FTPFilesystemException
        Inherits Exception
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal message As String)
            MyBase.New(message)
        End Sub
        Public Sub New(ByVal message As String, ByVal e As Exception)
            MyBase.New(message, e)
        End Sub
    End Class

    ''' <summary>
    ''' Thrown when there is an SFTP filesystem error
    ''' </summary>
    Public Class SFTPFilesystemException
        Inherits Exception
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal message As String)
            MyBase.New(message)
        End Sub
        Public Sub New(ByVal message As String, ByVal e As Exception)
            MyBase.New(message, e)
        End Sub
    End Class

    ''' <summary>
    ''' Thrown when there is a mail error
    ''' </summary>
    Public Class MailException
        Inherits Exception
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal message As String)
            MyBase.New(message)
        End Sub
        Public Sub New(ByVal message As String, ByVal e As Exception)
            MyBase.New(message, e)
        End Sub
    End Class

    ''' <summary>
    ''' Thrown when there is no such mail directory
    ''' </summary>
    Public Class NoSuchMailDirectoryException
        Inherits Exception
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal message As String)
            MyBase.New(message)
        End Sub
        Public Sub New(ByVal message As String, ByVal e As Exception)
            MyBase.New(message, e)
        End Sub
    End Class

    ''' <summary>
    ''' Thrown when there is already a device
    ''' </summary>
    Public Class RemoteDebugDeviceAlreadyExistsException
        Inherits Exception
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal message As String)
            MyBase.New(message)
        End Sub
        Public Sub New(ByVal message As String, ByVal e As Exception)
            MyBase.New(message, e)
        End Sub
    End Class

End Class
