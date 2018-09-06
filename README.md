# |---+-> Kernel Simulator <-+---|

The build is currently [![Build status](https://ci.appveyor.com/api/projects/status/9anm0jc0x9raoy8x/branch/master?svg=true)](https://ci.appveyor.com/project/EoflaOE/kernel-simulator/branch/master)

This kernel simulator simulates our **future** kernel that is planned by us and is not a final planned version of Kernel, since it was minimal. Cannot log-in to Kernel Simulator on **root** account? The password is the _backwards_ of **root**.

## |-----+--> _Notes_ <--+-----|

- This kernel simulator _will_ continue to be developed, even if we made the real PC version of Kernel.

- It can only be Console at the moment, while we are developing a GUI for this simulator.

- The version of Firefox was old and so we cannot upload binary into release page. You have to build from source to use, or use an [archive](https://github.com/EoflaOE/Kernel-Simulator/tree/archive/bin/Windows), Because the machine that we're developing and building on doesn't have SSE2 support on our build CPU, **AMD Athlon XP 1500+**. To download, use above link.

## |-----+--> _Prerequisites_ <--+-----|

- Windows XP or higher (Kernel Simulator is planned to use .NET Framework 4.7 or higher to optimize usage for Windows 10 systems, etc.)

- [Microsoft .NET Framework 4.0](https://download.microsoft.com/download/1/B/E/1BE39E79-7E39-46A3-96FF-047F95396215/dotNetFx40_Full_setup.exe) or higher is **important and required** for Kernel Simulator to work fully. If you have Windows 8 or later, you might already have this version of Microsoft .NET Framework 4.0.

## |-----+--> _Build Instructions_ <--+-----|

1. Install [Microsoft Visual Basic Express 2010](https://visual-basic-express.soft32.com/old-version/386190/2010.express/) or [Visual Studio 2010](https://www.visualstudio.com/vs/older-downloads/ "Sign-in required"), or higher.

2. After installation, extract the source code, and open Microsoft Visual Basic / Studio 2010, and click on **Open Project...**

3. Go to the source directory, and double-click the solution file

4. Right click on the project on the right, and select **Properties**

5. Go to **Compile**, click **Browse...** on **Build output path:**, and select your build path. When you're finished, click on **OK** button.

6. Click on the **Build** menu bar, and click on **Build Kernel Simulator**

7. In **Windows Explorer**, go to the build directory and then double-click on the executable file.

## |-----+--> _History_ <--+-----|

If you want to see the history, go to the main branch of Kernel Simulator and see the history there.

## |-----+--> _Manual pages_ <--+-----|

The documentations can be found in source code of kernel simulator in `Kernel Simulator/Documentation`

**Documentation - main page:** Information about Kernel Simulator, this page

**Documentation - faq:** Frequently Asked Questions for Kernel Simulator

**Documentation - contributing rules:** Conditions for contributing Kernel Simulator

**Documentation - troubleshooting:** List of known and user-reported problems

* The text files will be moved to wiki section.

## |-----+--> _Contributors_ <--+-----|

**EoflaOE:** Owner of Kernel Simulator

**Paomedia:** Icon creator

## |-----+--> _License - GNU GPL_ <--+-----|

    Kernel Simulator - Simulates our future planned Kernel
    Copyright (C) 2018  EoflaOE

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.

