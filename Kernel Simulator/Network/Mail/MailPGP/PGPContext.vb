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

Imports MimeKit.Cryptography
Imports Org.BouncyCastle.Bcpg.OpenPgp

Public Class PGPContext
    Inherits GnuPGContext

    ''' <summary>
    ''' Gets password for secret key.
    ''' </summary>
    ''' <param name="key">Target key</param>
    ''' <returns>Entered Password</returns>
    Protected Overrides Function GetPasswordForKey(key As PgpSecretKey) As String
        W(DoTranslation("Write password for key ID {0}", currentLang) + ": ", False, ColTypes.Input, key.KeyId)
        Dim Password As String = ReadLineNoInput("*")
        Console.WriteLine()
        Return Password
    End Function
End Class
