﻿
'    Kernel Simulator  Copyright (C) 2018-2020  EoflaOE
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

Imports KS

<TestClass()> Public Class HardwareTests

    <TestMethod()> Public Sub TestProbeHardware()
        Try
            If Environment.OSVersion.ToString.Contains("Unix") Then
                ProbeHardwareLinux()
            Else
                ProbeHardware()
            End If
            Assert.IsTrue(HDDDone And CPUDone And ParDone And RAMDone)
        Catch afex As AssertFailedException
            Assert.Fail("Hardware is not properly parsed.")
        End Try
    End Sub

End Class