# |---+-> Kernel Simulator <-+---|

[![Build status](https://ci.appveyor.com/api/projects/status/9anm0jc0x9raoy8x/branch/master?svg=true)](https://ci.appveyor.com/project/EoflaOE/kernel-simulator/branch/master) [![Build Status](https://travis-ci.org/EoflaOE/Kernel-Simulator.svg?branch=master)](https://travis-ci.org/EoflaOE/Kernel-Simulator)

This kernel simulator simulates our **future** kernel that is planned by us and is not a final planned version of Kernel, since it was minimal.

## |-----+--> _Notes_ <--+-----|

- This kernel simulator _will_ continue to be developed, even if we made the real PC version of Kernel.

- It can only be Console at the moment, while we are developing a GUI for this simulator.

- We took out Windows XP support in favor of NuGet and .NET Framework 4.7.2.

- This branch doesn't archive NuGet packages.

## |-----+--> _Prerequisites_ <--+-----|

1. For Windows systems

- Windows 7 or higher

- Microsoft .NET Framework 4.6.1 or higher

2. For Unix systems

- Any Unix system that contains the latest version of [Mono Runtime](http://www.mono-project.com/docs/about-mono/languages/visualbasic/). MonoDevelop(32-bit or 64-bit)/JetBrains Rider(64-bit) is required to build from source.

## |-----+--> _Build Instructions_ <--+-----|

- For Windows systems

1. Install Microsoft Visual Studio 2017, or higher.

2. After installation, extract the source code, open VS2017, and click on **Open Project...**

3. Go to the source directory, and double-click the solution file

4. Right click on the project on the right, and select **Properties**

5. Go to **Compile**, click **Browse...** on **Build output path:**, and select your build path. When you're finished, click on **OK** button.

6. Click on the **Build** menu bar, and click on **Build Kernel Simulator**

7. In **Windows Explorer**, go to the build directory and then double-click on the executable file. 

- For Unix systems (MonoDevelop)

1. Install [Mono Runtime](http://www.mono-project.com/docs/about-mono/languages/visualbasic/) and MonoDevelop.

2. After installation, extrace the source code, and open MonoDevelop, and click on **Open...**

3. Go to the source directory, and double-click the solution file
	
4. Change the output directory if you are building using **Release**.

5. Click on the **Build** menu bar, and click on build button to compile.

6. In **your file manager**, go to the build directory and then double-click on the executable file.

## |-----+--> _History_ <--+-----|

If you want to see the history, go to the main branch.

## |-----+--> _Contributors_ <--+-----|

**EoflaOE:** Owner of Kernel Simulator

**Oxygen Team:** Icon creator

## |-----+--> _Open Source Libraries used_ <--+-----|

MadMilkman.Ini

Source code: https://github.com/MarioZ/MadMilkman.Ini

Copyright (c) 2016, Mario Zorica

License (Apache 2.0): https://github.com/MarioZ/MadMilkman.Ini/blob/master/LICENSE

Newtonsoft.Json

Source code: https://github.com/JamesNK/Newtonsoft.Json

Copyright (c) 2007, James Newton-King

License (MIT): https://github.com/JamesNK/Newtonsoft.Json/blob/master/LICENSE.md

FluentFTP

Source code: https://github.com/robinrodricks/FluentFTP

Copyright (c) 2011-2016, J.P. Trosclair

Copyright (c) 2016-present, Robin Rodricks

License (MIT): https://github.com/robinrodricks/FluentFTP/blob/master/LICENSE.TXT

## |-----+--> _License - GNU GPL_ <--+-----|

    Kernel Simulator - Simulates our future planned Kernel
    Copyright (C) 2018-2019  EoflaOE

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

