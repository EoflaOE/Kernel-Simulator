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

Imports System.Net.Sockets

Public Module RPC_Commands

    Dim Commands As New List(Of String) From {"<Request:Shutdown>", 'Request will be like this: <Request:Shutdown>(IP)
                                              "<Request:Reboot>",   'Request will be like this: <Request:Reboot>(IP)
                                              "<Request:Lock>",     'Request will be like this: <Request:Lock>(IP)
                                              "<Request:SaveScr>",  'Request will be like this: <Request:SaveScr>(IP)
                                              "<Request:Exec>"}     'Request will be like this: <Request:Exec>(CMD)

    ''' <summary>
    ''' Send an RPC command to another instance of KS using the specified address
    ''' </summary>
    ''' <param name="Request">A request</param>
    ''' <param name="IP">An IP address which the RPC is hosted</param>
    Public Sub SendCommand(ByVal Request As String, ByVal IP As String)
        Dim Cmd As String = Request.Remove(Request.IndexOf("("))
        Wdbg("I", "Command: {0}", Cmd)
        Dim Arg As String = Request.Substring(Request.IndexOf("(") + 1)
        Wdbg("I", "Prototype Arg: {0}", Arg)
        Arg = Arg.Remove(Arg.Count - 1)
        Wdbg("I", "Finished Arg: {0}", Arg)
        Dim Malformed As Boolean
        If Commands.Contains(Cmd) Then
            Wdbg("I", "Command found.")
            Dim ByteMsg() As Byte = {}
            If Cmd = "<Request:Shutdown>" Then
                Wdbg("I", "Stream opened for device {0}", Arg)
                ByteMsg = Text.Encoding.Default.GetBytes("ShutdownConfirm, " + Arg + vbNewLine)
            ElseIf Cmd = "<Request:Reboot>" Then
                Wdbg("I", "Stream opened for device {0}", Arg)
                ByteMsg = Text.Encoding.Default.GetBytes("RebootConfirm, " + Arg + vbNewLine)
            ElseIf Cmd = "<Request:Lock>" Then
                Wdbg("I", "Stream opened for device {0}", Arg)
                ByteMsg = Text.Encoding.Default.GetBytes("LockConfirm, " + Arg + vbNewLine)
            ElseIf Cmd = "<Request:SaveScr>" Then
                Wdbg("I", "Stream opened for device {0}", Arg)
                ByteMsg = Text.Encoding.Default.GetBytes("SaveScrConfirm, " + Arg + vbNewLine)
            ElseIf Cmd = "<Request:Exec>" Then
                Wdbg("I", "Stream opened for device {0} to execute ""{1}""", IP, Arg)
                ByteMsg = Text.Encoding.Default.GetBytes("ExecConfirm, " + Arg + vbNewLine)
            Else
                Wdbg("E", "Malformed request. {0}", Cmd)
                Malformed = True
            End If
            If Not Malformed Then
                Wdbg("I", "Sending response to device...")
                RPCListen.Send(ByteMsg, ByteMsg.Length, IP, RPCPort)
                EventManager.RaiseRPCCommandSent(Cmd)
            End If
        End If
    End Sub

    ''' <summary>
    ''' Thread to listen to commands.
    ''' </summary>
    Sub RecCommand()
        Dim endp As New IPEndPoint(IPAddress.Any, RPCPort)
        While RPCThread.IsAlive
            Dim buff() As Byte
            Dim ip As String = ""
            Dim msg As String = ""
            Try
                buff = RPCListen.Receive(endp)
                msg = Text.Encoding.Default.GetString(buff)
                Wdbg("RPC: Received message {0}", msg)
                EventManager.RaiseRPCCommandReceived(msg)
                If msg.StartsWith("ShutdownConfirm") Then
                    Wdbg("I", "Shutdown confirmed from remote access.")
                    PowerManage("shutdown")
                ElseIf msg.StartsWith("RebootConfirm") Then
                    Wdbg("I", "Reboot confirmed from remote access.")
                    PowerManage("reboot")
                ElseIf msg.StartsWith("LockConfirm") Then
                    Wdbg("I", "Lock confirmed from remote access.")
                    LockScreen()
                ElseIf msg.StartsWith("SaveScrConfirm") Then
                    Wdbg("I", "Save screen confirmed from remote access.")
                    ShowSavers(defSaverName)
                ElseIf msg.StartsWith("ExecConfirm") Then
                    If LoggedIn Then
                        Wdbg("I", "Exec confirmed from remote access.")
                        Console.WriteLine()
                        GetLine(False, msg.Replace("ExecConfirm, ", "").Replace(vbNewLine, ""))
                    Else
                        Wdbg("W", "Tried to exec from remote access while not logged in. Dropping packet...")
                    End If
                Else
                    Wdbg("W", "Not found. Message was {0}", msg)
                End If
            Catch ex As Exception
                Dim SE As SocketException = CType(ex.InnerException, SocketException)
                If Not IsNothing(SE) Then
                    If Not SE.SocketErrorCode = SocketError.TimedOut Then
                        Wdbg("E", "Error from host {0}: {1}", ip, SE.SocketErrorCode.ToString)
                        WStkTrc(ex)
                    End If
                Else
                    Wdbg("E", "Fatal error: {0}", ex.Message)
                    WStkTrc(ex)
                    EventManager.RaiseRPCCommandError(msg, ex)
                End If
            End Try
        End While
    End Sub

End Module
