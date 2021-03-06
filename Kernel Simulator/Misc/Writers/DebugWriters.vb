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

Module DebugWriters

    Public dbgWriter As StreamWriter
    Public DebugQuota As Double = 1073741824 '1073741824 bytes = 1 GiB (1 GB for Windows)
    Public dbgStackTraces As New List(Of String)

    ''' <summary>
    ''' Outputs the text into the debugger file, and sets the time stamp.
    ''' </summary>
    ''' <param name="text">A sentence that will be written to the the debugger file. Supports {0}, {1}, ...</param>
    ''' <param name="vars">Endless amounts of any variables that is separated by commas.</param>
    Public Sub Wdbg(ByVal Level As Char, ByVal text As String, ByVal ParamArray vars() As Object)
        If DebugMode Then
            'Open debugging stream
            If IsNothing(dbgWriter) Or IsNothing(dbgWriter?.BaseStream) Then dbgWriter = New StreamWriter(paths("Debugging"), True) With {.AutoFlush = True}

            Dim STrace As New StackTrace(True)
            Dim Source As String = Path.GetFileName(STrace.GetFrame(1).GetFileName)
            Dim LineNum As String = STrace.GetFrame(1).GetFileLineNumber
            Dim Func As String = STrace.GetFrame(1).GetMethod.Name
            Dim OffendingIndex As New List(Of String)

            'Apparently, GetFileName on Mono in Linux doesn't work for MDB files made using pdb2mdb for PDB files that are generated by Visual Studio, so we take the last entry for the backslash to get the source file name.
            If IsOnUnix() Then
                Source = Source.Split("\")(Source.Split("\").Length - 1)
            End If

            'Check for debug quota
            CheckForExceed()

            'For contributors who are testing new code: Uncomment the two Debug.WriteLine lines for immediate debugging (Immediate Window)
            If Not Source Is Nothing And Not LineNum = 0 Then
                'Debug to file and all connected debug devices (raw mode)
                dbgWriter.WriteLine($"{KernelDateTime.ToShortDateString} {KernelDateTime.ToShortTimeString} [{Level}] ({Func} - {Source}:{LineNum}): {text}", vars)
                For i As Integer = 0 To dbgConns.Count - 1
                    Try
                        dbgConns.Keys(i).WriteLine($"{KernelDateTime.ToShortDateString} {KernelDateTime.ToShortTimeString} [{Level}] ({Func} - {Source}:{LineNum}): {text}", vars)
                    Catch ex As Exception
                        OffendingIndex.Add(GetSWIndex(dbgConns.Keys(i)))
                        WStkTrc(ex)
                    End Try
                Next
                'Debug.WriteLine($"{KernelDateTime.ToShortDateString} {KernelDateTime.ToShortTimeString} [{Level}] ({Func} - {Source}:{LineNum}): {text}", vars)
            Else 'Rare case, unless debug symbol is not found on archives.
                dbgWriter.WriteLine($"{KernelDateTime.ToShortDateString} {KernelDateTime.ToShortTimeString} [{Level}] {text}", vars)
                For i As Integer = 0 To dbgConns.Count - 1
                    Try
                        dbgConns.Keys(i).WriteLine($"{KernelDateTime.ToShortDateString} {KernelDateTime.ToShortTimeString} [{Level}] {text}", vars)
                    Catch ex As Exception
                        OffendingIndex.Add(GetSWIndex(dbgConns.Keys(i)))
                        WStkTrc(ex)
                    End Try
                Next
                'Debug.WriteLine($"{KernelDateTime.ToShortDateString} {KernelDateTime.ToShortTimeString}: [{Level}] {text}", vars)
            End If

            'Disconnect offending clients who are disconnected
            For Each i As Integer In OffendingIndex
                If i <> -1 Then
                    DebugDevices.Keys(i).Disconnect(True)
                    EventManager.RaiseRemoteDebugConnectionDisconnected(DebugDevices.Values(i))
                    Wdbg("W", "Debug device {0} ({1}) disconnected.", dbgConns.Values(i), DebugDevices.Values(i))
                    dbgConns.Remove(dbgConns.Keys(i))
                    DebugDevices.Remove(DebugDevices.Keys(i))
                End If
            Next
            OffendingIndex.Clear()
        End If
    End Sub

    ''' <summary>
    ''' Outputs the text into the debugger devices, and sets the time stamp. Note that it doesn't print where did the debugger debug in source files.
    ''' </summary>
    ''' <param name="text">A sentence that will be written to the the debugger devices. Supports {0}, {1}, ...</param>
    ''' <param name="vars">Endless amounts of any variables that is separated by commas.</param>
    Public Sub WdbgDevicesOnly(ByVal Level As Char, ByVal text As String, ByVal ParamArray vars() As Object)
        If DebugMode Then
            Dim OffendingIndex As New List(Of String)

            'For contributors who are testing new code: Uncomment the two Debug.WriteLine lines for immediate debugging (Immediate Window)
            For i As Integer = 0 To dbgConns.Count - 1
                Try
                    dbgConns.Keys(i).WriteLine($"{KernelDateTime.ToShortDateString} {KernelDateTime.ToShortTimeString} [{Level}] {text}", vars)
                Catch ex As Exception
                    OffendingIndex.Add(GetSWIndex(dbgConns.Keys(i)))
                    WStkTrc(ex)
                End Try
            Next
            'Debug.WriteLine($"{KernelDateTime.ToShortDateString} {KernelDateTime.ToShortTimeString}: [{Level}] {text}", vars)

            'Disconnect offending clients who are disconnected
            For Each i As Integer In OffendingIndex
                If i <> -1 Then
                    DebugDevices.Keys(i).Disconnect(True)
                    EventManager.RaiseRemoteDebugConnectionDisconnected(DebugDevices.Values(i))
                    Wdbg("W", "Debug device {0} ({1}) disconnected.", dbgConns.Values(i), DebugDevices.Values(i))
                    dbgConns.Remove(dbgConns.Keys(i))
                    DebugDevices.Remove(DebugDevices.Keys(i))
                End If
            Next
            OffendingIndex.Clear()
        End If
    End Sub

    ''' <summary>
    ''' Writes the exception's stack trace to the debugger
    ''' </summary>
    ''' <param name="Ex">An exception</param>
    Public Sub WStkTrc(ByVal Ex As Exception)
        If DebugMode Then
            'These two vbNewLines are padding for accurate stack tracing.
            dbgStackTraces.Add($"{vbNewLine}{Ex.ToString.Substring(0, Ex.ToString.IndexOf(":"))}: {Ex.Message}{vbNewLine}{Ex.StackTrace}{vbNewLine}")

            'Print stack trace to debugger
            Dim StkTrcs As String() = dbgStackTraces(0).Replace(Chr(13), "").Split(Chr(10))
            For i As Integer = 0 To StkTrcs.Length - 1
                Wdbg("E", StkTrcs(i))
            Next
        End If
    End Sub

    ''' <summary>
    ''' Checks to see if the debug file exceeds the quota
    ''' </summary>
    Public Sub CheckForExceed()
        Try
            Dim FInfo As New FileInfo(paths("Debugging"))
            Dim OldSize As Double = FInfo.Length
            Dim Lines() As String = ReadAllLinesNoBlock(paths("Debugging"))
            If OldSize > DebugQuota Then
                dbgWriter.Close()
                dbgWriter = New StreamWriter(paths("Debugging")) With {.AutoFlush = True}
                For l As Integer = 5 To Lines.Length - 2 'Remove the first 5 lines from stream.
                    dbgWriter.WriteLine(Lines(l))
                Next
                Wdbg("W", "Max debug quota size exceeded, was {0} MB.", FormatNumber(OldSize / 1024 / 1024, 1))
            End If
        Catch ex As Exception
            WStkTrc(ex)
            Exit Sub
        End Try
    End Sub

End Module
