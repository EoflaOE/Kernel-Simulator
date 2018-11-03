﻿
'    Kernel Simulator  Copyright (C) 2018  EoflaOE
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

Imports System.Net
Imports System.Net.NetworkInformation
Imports System.DirectoryServices
Imports System.Net.Sockets.AddressFamily

Public Module NetworkTools

    'Variables
    Public adapterNumber As Long
    Public Computers As String

    Public Sub ListOnlineAndOfflineHosts()

        'Check if main network is available
        If My.Computer.Network.IsAvailable Then

            'Variables
            Dim ComputerNames() = Computers.Split({" "c}, StringSplitOptions.RemoveEmptyEntries)

            'Display information
            Wln("net: Your computer name on network is {0}" + vbNewLine + _
                "net: Your host name is {1}" + vbNewLine + _
                "net: It appears that computers are in the domain or workgroup:", "neutralText", My.Computer.Name, HName)

            'List online and offline computers
            For Each cmp In ComputerNames
                Wln("net: {0}", "neutralText", cmp)
            Next

        Else

            Wln("net: WiFi or Ethernet is disconnected.", "neutralText")

        End If

    End Sub

    Public Sub ListHostsInNetwork()

        'Error Handler
        On Error Resume Next

        'Check if main network is available
        If My.Computer.Network.IsAvailable Then

            'Variables
            Dim HostNameFromDNS As String
            Dim IPHostEntry As IPHostEntry
            Dim ComputerNames() = Computers.Split({" "c}, StringSplitOptions.RemoveEmptyEntries)

            'Display infromation
            Wln("net: Your computer name on network is {0}" + vbNewLine + _
                "net: Your host name is {1}" + vbNewLine + _
                "net: It appears that computers are connected below:", "neutralText", My.Computer.Name, HName)

            'List IP addresses of computers
            For Each cmp In ComputerNames
                HostNameFromDNS = cmp
                IPHostEntry = Dns.GetHostEntry(HostNameFromDNS)
                Dim p As New System.Net.NetworkInformation.Ping()
                For Each ipheal In IPHostEntry.AddressList
                    Dim reply = p.Send(ipheal, 100)
                    If (reply.Status = IPStatus.Success) Then
                        Wln("net: {0}: {1}", "neutralText", cmp, ipheal)
                    End If
                Next
            Next

            'Get router address
            W("net: Router Address: ", "neutralText")
            HostNameFromDNS = Dns.GetHostName()
            IPHostEntry = Dns.GetHostEntry(HostNameFromDNS)
            For Each ip In IPHostEntry.AddressList
                For Each router As NetworkInterface In NetworkInterface.GetAllNetworkInterfaces()
                    For Each UnicastIPAI As UnicastIPAddressInformation In router.GetIPProperties.UnicastAddresses
                        If UnicastIPAI.Address.AddressFamily = InterNetwork Then
                            If ip.Equals(UnicastIPAI.Address) Then
                                Dim adapterProperties As IPInterfaceProperties = router.GetIPProperties()
                                For Each gateway As GatewayIPAddressInformation In adapterProperties.GatewayAddresses
                                    Wln(gateway.Address.ToString(), "neutralText")
                                Next
                            End If
                        End If
                    Next
                Next
            Next

        Else

            Wln("net: WiFi or Ethernet is disconnected.", "neutralText")

        End If

    End Sub

    Public Sub GetNetworkComputers()

        'Error Handler
        On Error Resume Next

        'Variables
        Dim alWorkGroups As New ArrayList
        Dim de As New DirectoryEntry

        'Clear "Computers" variable for cleanup
        Computers = Nothing

        'Get workgroups and domain
        de.Path = "WinNT:"
        For Each d As DirectoryEntry In de.Children
            If d.SchemaClassName = "Domain" Then alWorkGroups.Add(d.Name)
            d.Dispose()
        Next

        'Get computers
        For Each workgroup As String In alWorkGroups
            de.Path = "WinNT://" & workgroup
            For Each d As DirectoryEntry In de.Children
                If d.SchemaClassName = "Computer" Then
                    Computers = Computers + " " + d.Name + " "
                End If
                d.Dispose()
            Next
        Next

    End Sub

    Public Sub ListHostsInTree()

        'Error Handler
        On Error Resume Next

        'Check if main network is available
        If My.Computer.Network.IsAvailable Then

            'Variables
            Dim HostNameFromDNS As String = Dns.GetHostName()
            Dim IPHostEntry As Net.IPHostEntry = Dns.GetHostEntry(HostNameFromDNS)
            Dim ComputerNames() = Computers.Split({" "c}, StringSplitOptions.RemoveEmptyEntries)

            'Get router
            For Each ip In IPHostEntry.AddressList
                For Each router As NetworkInterface In NetworkInterface.GetAllNetworkInterfaces()
                    For Each UnicastIPAI As UnicastIPAddressInformation In router.GetIPProperties.UnicastAddresses
                        If UnicastIPAI.Address.AddressFamily = InterNetwork Then
                            If ip.Equals(UnicastIPAI.Address) Then
                                Dim adapterProperties As IPInterfaceProperties = router.GetIPProperties()
                                For Each gateway As GatewayIPAddressInformation In adapterProperties.GatewayAddresses
                                    Wln(gateway.Address.ToString(), "neutralText")
                                Next
                            End If
                        End If
                    Next
                Next
            Next

            'Get IP addresses of computers
            For Each cmp In ComputerNames
                HostNameFromDNS = cmp
                IPHostEntry = Dns.GetHostEntry(HostNameFromDNS)
                Dim p As New System.Net.NetworkInformation.Ping()
                For Each ipheal In IPHostEntry.AddressList
                    Dim reply = p.Send(ipheal, 100)
                    If (reply.Status = IPStatus.Success) Then
                        Wln("|-> {0}: {1}", "neutralText", cmp, ipheal)
                    End If
                Next
            Next

        Else

            Wln("net: WiFi or Ethernet is disconnected.", "neutralText")

        End If

    End Sub

    Public Sub getProperties()

        Dim proper As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties
        Dim adapters As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces
        For Each adapter As NetworkInterface In adapters
            adapterNumber = adapterNumber + 1
            If adapter.Supports(NetworkInterfaceComponent.IPv4) = False Then
                If (DebugMode = True) Then
                    Wdbg("{0} doesn't support IPv4 because ASSERT(adapter.Supp(IPv4) = True) = False.", True, adapter.Description)
                End If
                GoTo Cont
            ElseIf (adapter.NetworkInterfaceType = NetworkInterfaceType.Ethernet Or _
                    adapter.NetworkInterfaceType = NetworkInterfaceType.Ethernet3Megabit Or _
                    adapter.NetworkInterfaceType = NetworkInterfaceType.FastEthernetFx Or _
                    adapter.NetworkInterfaceType = NetworkInterfaceType.FastEthernetT Or _
                    adapter.NetworkInterfaceType = NetworkInterfaceType.GigabitEthernet Or _
                    adapter.NetworkInterfaceType = NetworkInterfaceType.Wireless80211) Then
                Dim adapterProperties As IPInterfaceProperties = adapter.GetIPProperties()
                Dim p As IPv4InterfaceProperties = adapterProperties.GetIPv4Properties
                Dim s As IPv4InterfaceStatistics = adapter.GetIPv4Statistics
                If (p Is Nothing) Then
                    Wln("Failed to get properties for adapter {0}", "neutralText", adapter.Description)
                ElseIf (s Is Nothing) Then
                    Wln("Failed to get statistics for adapter {0}", "neutralText", adapter.Description)
                End If
                Wln("Adapter Number: {0}" + vbNewLine + _
                    "Adapter Name: {1}" + vbNewLine + _
                    "Maximum Transmission Unit: {2} Units" + vbNewLine + _
                    "DHCP Enabled: {3}" + vbNewLine + _
                    "Non-unicast packets: {4}/{5}" + vbNewLine + _
                    "Unicast packets: {6}/{7}" + vbNewLine + _
                    "Error incoming/outgoing packets: {8}/{9}", "neutralText", _
                    adapterNumber, adapter.Description, p.Mtu, p.IsDhcpEnabled, s.NonUnicastPacketsSent, s.NonUnicastPacketsReceived, _
                    s.UnicastPacketsSent, s.UnicastPacketsReceived, s.IncomingPacketsWithErrors, s.OutgoingPacketsWithErrors)
            Else
                If (DebugMode = True) Then
                    Wdbg("Adapter {0} doesn't belong in netinfo because the type is {1}", True, adapter.Description, adapter.NetworkInterfaceType)
                End If
                GoTo Cont
            End If
Cont:
        Next

    End Sub

End Module