# |---+-> Kernel Simulator <-+---|

![Glitter Matrix screensaver](https://i.imgur.com/whpea5H.png)

[![Build status](https://ci.appveyor.com/api/projects/status/9anm0jc0x9raoy8x/branch/master?svg=true)](https://ci.appveyor.com/project/EoflaOE/kernel-simulator/branch/master) [![Build Status](https://travis-ci.org/EoflaOE/Kernel-Simulator.svg?branch=master)](https://travis-ci.org/EoflaOE/Kernel-Simulator) ![GitHub repo size](https://img.shields.io/github/repo-size/EoflaOE/Kernel-Simulator?color=purple&label=size) [![GitHub All Releases](https://img.shields.io/github/downloads/EoflaOE/Kernel-Simulator/total?color=purple&label=d/l)](https://github.com/EoflaOE/Kernel-Simulator/releases) [![GitHub release (latest by date including pre-releases)](https://img.shields.io/github/v/release/EoflaOE/Kernel-Simulator?color=purple&include_prereleases&label=github)](https://github.com/EoflaOE/Kernel-Simulator/releases/latest) [![Chocolatey Version (including pre-releases)](https://img.shields.io/chocolatey/v/ks?color=purple&include_prereleases)](https://chocolatey.org/packages/KS/) [![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/KS?color=purple)](https://www.nuget.org/packages/KS/) [![GitHub](https://img.shields.io/github/license/EoflaOE/Kernel-Simulator?color=purple)](https://github.com/EoflaOE/Kernel-Simulator/blob/master/LICENSE)

This simulator simulates our **future** kernel that is planned by us and is not a final planned version of Kernel, since it was minimal. KS _will_ continue to be developed, even if we made the real PC version of Kernel.

After 4 months of development, we are announcing that the kernel version 0.0.8 is finally finished! We are making releases as soon as we can.

## |-----+--> _Notes_ <--+-----|

- We took out Windows XP support in 0.0.5.9 in favor of NuGet and .NET Framework 4.8.

- We don't archive NuGet packages, and we don't archive full binary archive with VLC (only KS and its `*.dll` dependencies) because of GitHub's limitations of 100 MB file sizes. To use them, you have to extract the `libvlc` directory from the full ZIP file from release to the root directory.

## |-----+--> _Virus Warning_ <--+-----|

Unfortunately, some parts of KS have been taken to avoid detection in the source code of a malicious executable file called payslip.exe. It got its entries for the following cybersecurity analyzers:

* Hybrid Analysis (downloadable for researchers): https://www.hybrid-analysis.com/sample/756b94b872cada97c6ebcbc65c47734e3238f171db719d428a42f6ac8bc93e4f

* VirusTotal (downloadable for researchers): https://www.virustotal.com/gui/file/756b94b872cada97c6ebcbc65c47734e3238f171db719d428a42f6ac8bc93e4f/detection

For more information, inspect [this wiki page](https://github.com/EoflaOE/Kernel-Simulator/wiki/Studying-payslip-virus).

## |-----+--> _Prerequisites_ <--+-----|

1. For Windows systems

- Windows 7 or higher

- Microsoft .NET Framework 4.8 or higher

2. For Unix systems

- Any Unix system that contains the latest version of [Mono Runtime](http://www.mono-project.com/docs/about-mono/languages/visualbasic/). MonoDevelop(32-bit or 64-bit)/JetBrains Rider(64-bit) is required to build from source.

- Microsoft.VisualBasic.dll 10.0 (Debian and its derivatives: `sudo apt install libmono-microsoft-visualbasic10.0-cil`)

- VLC Media Player (For TTS and playback for test shell) (Debian and its derivatives: `sudo apt install vlc libvlc-dev gtk-sharp2`)

- Inxi application (For hard drive probation) (Debian and its derivatives: `sudo apt install inxi`)

## |-----+--> _Build Instructions_ <--+-----|

- For Windows systems

1. Install Microsoft Visual Studio 2017, or higher.

2. After installation, extract the source code, open Visual Studio, and click on **Open Project...**

3. Go to the source directory, and double-click the solution file

4. Right click on the project on the right, and select **Properties**

5. Go to **Compile**, click **Browse...** on **Build output path:**, and select your build path. When you're finished, click on **OK** button.

6. Click on the **Build** menu bar, and click on **Build Kernel Simulator**

7. In **Windows Explorer**, go to the build directory and then double-click on the executable file. 

Notice: You must have **at least** Visual Studio 2017, because of how the syntax is formatted inside the project file, as well as the NuGet properties inside.

- For Unix systems (MonoDevelop)

1. Install [Mono Runtime](http://www.mono-project.com/docs/about-mono/languages/visualbasic/), `libmono-microsoft-visualbasic10.0-cil`, and MonoDevelop.

2. After installation, extract the source code, open MonoDevelop, and click on **Open...**

3. Go to the source directory, and double-click the solution file
	
4. Change the output directory if you are building using **Release**.

5. Click on the **Build** menu bar, and click on build button to compile.

6. In **your file manager**, go to the build directory and then double-click on the executable file.

* For Unix Systems that can do 64-bit (JetBrains Rider)

1. Install [Mono Runtime](http://www.mono-project.com/docs/about-mono/languages/visualbasic/), Git, and `libmono-microsoft-visualbasic10.0-cil`. Remember to install Mono Runtime from the website, not your distro's repos. Mono 6.0.0 is at least required.

2. Install JetBrains Rider from their website or snap if you use Ubuntu 64-bit

3. After installation, open JetBrains Rider, and follow the configuration steps

4. When the main menu opens, choose "Check out from Version Control" and then "Git"

5. Write on the URL "https://github.com/EoflaOE/Kernel-Simulator.git" and press "Test" to verify your connectivity

6. Press Clone, and git will download 200+ MB of data (because of archive branch), then Rider will open up. Don't worry if the progress bar stops moving. It's based on the amount of objects, not the size, because Rider and/or Git still hasn't implemented progress bar by repo size yet.

7. You will get some errors about the inability to resolve `My.Computer`. Ignore these, as they won't interrupt the compilation.

8. Click on the hammer button to build, or the Run button. When the Edit configuration screen appears, tick the checkbox named "Use External Console".

9. If you used the hammer button, then open your file explorer, go to the build directory, and double-click on the executable file.

NOTE: We recommend running builds using the bug button to make breakpoints work. The run button is not like MonoDevelop or Visual Studio. Visual Studio is lighter than Rider, although it's only available for Windows.

## |-----+--> _History_ <--+-----|

If you want to see the history, go to the main branch.

## |-----+--> _Contributors_ <--+-----|

**EoflaOE:** Owner of Kernel Simulator

**Oxygen Team:** Icon creator

## |-----+--> _Open Source Libraries Used_ <--+-----|

Below entries are the open source libraries that is used by KS. They are required for execution.

### MadMilkman.Ini

Source code: https://github.com/MarioZ/MadMilkman.Ini

Copyright (c) 2016, Mario Zorica

License (Apache 2.0): https://github.com/MarioZ/MadMilkman.Ini/blob/master/LICENSE

### Newtonsoft.Json

Source code: https://github.com/JamesNK/Newtonsoft.Json

Copyright (c) 2007, James Newton-King

License (MIT): https://github.com/JamesNK/Newtonsoft.Json/blob/master/LICENSE.md

### FluentFTP

Source code: https://github.com/robinrodricks/FluentFTP

Copyright (c) 2011-2016, J.P. Trosclair

Copyright (c) 2016-present, Robin Rodricks

License (MIT): https://github.com/robinrodricks/FluentFTP/blob/master/LICENSE.TXT

### LibVLCSharp

Source code: https://code.videolan.org/videolan/LibVLCSharp

Copyright � 1996-2020 the VideoLAN team

License (LGPLv2.1): https://code.videolan.org/videolan/LibVLCSharp/blob/3.x/LICENSE

### VLC (used by LibVLCSharp)

Source code: https://code.videolan.org/videolan/vlc

Copyright � 1996-2020 the VideoLAN team

License (GNU GPL 2.0): https://code.videolan.org/videolan/vlc/blob/master/COPYING

### SSH.NET

Source code: https://github.com/sshnet/SSH.NET/

Copyright (c) Renci

License (MIT): https://github.com/sshnet/SSH.NET/blob/develop/LICENSE

## |-----+--> _License - GNU GPL_ <--+-----|

    Kernel Simulator - Simulates our future planned Kernel
    Copyright (C) 2018-2020  EoflaOE

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

