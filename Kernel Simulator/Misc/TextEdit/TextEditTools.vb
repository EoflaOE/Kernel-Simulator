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
Imports System.Text

Public Module TextEditTools

    ''' <summary>
    ''' Opens the text file
    ''' </summary>
    ''' <param name="File">Target file. We recommend you to use <see cref="NeutralizePath(String)"></see> to neutralize path.</param>
    ''' <returns>True if successful; False if unsuccessful</returns>
    Public Function TextEdit_OpenTextFile(ByVal File As String) As Boolean
        Try
            Wdbg("I", "Trying to open file {0}...", File)
            TextEdit_FileStream = New FileStream(File, FileMode.Open)
            If IsNothing(TextEdit_FileLines) Then TextEdit_FileLines = New List(Of String)
            If IsNothing(TextEdit_FileLinesOrig) Then TextEdit_FileLinesOrig = New List(Of String)
            Wdbg("I", "File {0} is open. Length: {1}, Pos: {2}", File, TextEdit_FileStream.Length, TextEdit_FileStream.Position)
            Dim TextFileStreamReader As New StreamReader(TextEdit_FileStream)
            Do While Not TextFileStreamReader.EndOfStream
                Dim StreamLine As String = TextFileStreamReader.ReadLine
                TextEdit_FileLines.Add(StreamLine)
                TextEdit_FileLinesOrig.Add(StreamLine)
            Loop
            TextEdit_FileStream.Seek(0, SeekOrigin.Begin)
            Return True
        Catch ex As Exception
            Wdbg("E", "Open file {0} failed: {1}", File, ex.Message)
            WStkTrc(ex)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Closes text file
    ''' </summary>
    ''' <returns>True if successful; False if unsuccessful</returns>
    Public Function TextEdit_CloseTextFile() As Boolean
        Try
            Wdbg("I", "Trying to close file...")
            TextEdit_FileStream.Close()
            TextEdit_FileStream = Nothing
            Wdbg("I", "File is no longer open.")
            TextEdit_FileLines.Clear()
            TextEdit_FileLinesOrig.Clear()
            Return True
        Catch ex As Exception
            Wdbg("E", "Closing file failed: {0}", ex.Message)
            WStkTrc(ex)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Saves text file
    ''' </summary>
    ''' <returns>True if successful; False if unsuccessful</returns>
    Public Function TextEdit_SaveTextFile(ByVal ClearLines As Boolean) As Boolean
        Try
            Wdbg("I", "Trying to save file...")
            TextEdit_FileStream.SetLength(0)
            Wdbg("I", "Length set to 0.")
            Dim FileLinesByte() As Byte = Encoding.Default.GetBytes(TextEdit_FileLines.ToArray.Join(vbNewLine))
            Wdbg("I", "Converted lines to bytes. Length: {0}", FileLinesByte.Length)
            TextEdit_FileStream.Write(FileLinesByte, 0, FileLinesByte.Length)
            TextEdit_FileStream.Flush()
            Wdbg("I", "File is saved.")
            If ClearLines Then
                TextEdit_FileLines.Clear()
            End If
            TextEdit_FileLinesOrig.Clear()
            TextEdit_FileLinesOrig.AddRange(TextEdit_FileLines)
            Return True
        Catch ex As Exception
            Wdbg("E", "Saving file failed: {0}", ex.Message)
            WStkTrc(ex)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Handles autosave
    ''' </summary>
    Public Sub TextEdit_HandleAutoSaveTextFile()
        If TextEdit_AutoSaveFlag Then
            Try
                Threading.Thread.Sleep(TextEdit_AutoSaveInterval * 1000)
                If Not IsNothing(TextEdit_FileStream) Then
                    TextEdit_SaveTextFile(False)
                End If
            Catch ex As Exception
                WStkTrc(ex)
            End Try
        End If
    End Sub

    ''' <summary>
    ''' Was text edited?
    ''' </summary>
    Function TextEdit_WasTextEdited() As Boolean
        If TextEdit_FileLines IsNot Nothing And TextEdit_FileLinesOrig IsNot Nothing Then
            Return Not TextEdit_FileLines.SequenceEqual(TextEdit_FileLinesOrig)
        End If
        Return False
    End Function

End Module
