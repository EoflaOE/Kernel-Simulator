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

Public Module Filesystem

    'Variables
    Public CurrDirStructure As New List(Of String)
    Public CurrDir As String

    'Subs
    Public Sub SetCurrDir(ByVal dir As String)
        Dim direct As String
        If EnvironmentOSType.Contains("Unix") Then
            direct = CurrDir + "/" + dir
        Else
            direct = CurrDir + "\" + dir
        End If
        If IO.Directory.Exists(direct) Then
            Dim Parser As New IO.DirectoryInfo(direct)
            CurrDir = Parser.FullName
            InitStructure()
        Else
            Wln(DoTranslation("Directory {0} not found", currentLang), "neutralText", dir)
        End If
    End Sub
    Public Sub ReadContents(ByVal filename As String)
        Using FStream As New IO.StreamReader(filename)
            While Not FStream.EndOfStream
                Wln(FStream.ReadLine, "neutralText")
            End While
        End Using
    End Sub
    Public Sub Init()
        If EnvironmentOSType.Contains("Unix") Then
            CurrDir = Environ("HOME")
        Else
            CurrDir = Environ("USERPROFILE")
        End If
        InitStructure()
    End Sub
    Public Sub InitStructure()
        CurrDirStructure.AddRange(IO.Directory.EnumerateFileSystemEntries(CurrDir, "*", IO.SearchOption.TopDirectoryOnly))
        CurrDirStructure.Add(CurrDir)
    End Sub
    Public Sub List(ByVal folder As String)
        If Not folder = CurrDir Then folder = CurrDir + folder
        If CurrDirStructure.Contains(folder) Then
            If IO.Directory.Exists(folder) Then
                For Each Entry As String In IO.Directory.EnumerateFileSystemEntries(folder)
                    Try
                        If IO.File.Exists(Entry) Then
                            Dim FInfo As New IO.FileInfo(Entry)

                            'Print information
                            Wln("- " + Entry + ": " + DoTranslation("{0} KB, Created in {1} {2}, Modified in {3} {4}", currentLang), "neutralText",
                                FormatNumber(FInfo.Length / 1024, 2),
                                FormatDateTime(FInfo.CreationTime, DateFormat.ShortDate),
                                FormatDateTime(FInfo.CreationTime, DateFormat.ShortTime),
                                FormatDateTime(FInfo.LastWriteTime, DateFormat.ShortDate),
                                FormatDateTime(FInfo.LastWriteTime, DateFormat.ShortTime))
                        ElseIf IO.Directory.Exists(Entry) Then
                            Dim DInfo As New IO.DirectoryInfo(Entry)

                            'Get all file sizes in a folder
                            Dim Files As List(Of IO.FileInfo) = DInfo.EnumerateFiles("*", IO.SearchOption.AllDirectories).ToList
                            Dim TotalSize As Long = 0 'In bytes
                            For Each DFile As IO.FileInfo In Files
                                TotalSize += DFile.Length
                            Next

                            'Print information
                            Wln("- " + Entry + ": " + DoTranslation("{0} KB, Created in {1} {2}, Modified in {3} {4}", currentLang), "neutralText",
                                FormatNumber(TotalSize / 1024, 2),
                                FormatDateTime(DInfo.CreationTime, DateFormat.ShortDate),
                                FormatDateTime(DInfo.CreationTime, DateFormat.ShortTime),
                                FormatDateTime(DInfo.LastWriteTime, DateFormat.ShortDate),
                                FormatDateTime(DInfo.LastWriteTime, DateFormat.ShortTime))
                        End If
                    Catch ex As UnauthorizedAccessException 'Error while getting info
                        Wln("- " + DoTranslation("You are not authorized to get info for {0}.", currentLang), "neutralText", Entry)
                    End Try
                Next
            Else
                Wln(DoTranslation("Directory {0} not found", currentLang), "neutralText", folder)
            End If
        Else
            Wln(DoTranslation("{0} is not found.", currentLang), "neutralText", folder)
        End If
    End Sub

End Module
