# |---+-> Kernel Simulator <-+---|

AppVeyor: [![Build status](https://ci.appveyor.com/api/projects/status/9anm0jc0x9raoy8x/branch/master?svg=true)](https://ci.appveyor.com/project/EoflaOE/kernel-simulator/branch/master) 

TravisCI: [![Build Status](https://travis-ci.org/EoflaOE/Kernel-Simulator.svg?branch=master)](https://travis-ci.org/EoflaOE/Kernel-Simulator)

This kernel simulator simulates our **future** kernel that is planned by us and is not a final planned version of Kernel, since it was minimal.

## |-----+--> _Notes_ <--+-----|

- This kernel simulator _will_ continue to be developed, even if we made the real PC version of Kernel.

- It can only be Console at the moment, while we are developing a GUI for this simulator.

- We took out Windows XP support in 0.0.5.9 in favor of NuGet and .NET Framework 4.7.

- Two documentations, faq and troubleshooting, are deleted because they are not updated regularly.

## |-----+--> _Prerequisites_ <--+-----|

1. For Windows systems

- Windows 7 or higher

- Microsoft .NET Framework 4.7 or higher

2. For Unix systems

- Any Unix system that contains the latest version of [Mono Runtime](http://www.mono-project.com/docs/about-mono/languages/visualbasic/). MonoDevelop(32-bit or 64-bit)/JetBrains Rider(64-bit) is required to build from source.

## |-----+--> _Build Instructions_ <--+-----|

- For Windows systems

1. Install Microsoft Visual Studio 2019, or higher.

2. After installation, extract the source code, open VS2019, and click on **Open Project...**

3. Go to the source directory, and double-click the solution file

4. Right click on the project on the right, and select **Properties**

5. Go to **Compile**, click **Browse...** on **Build output path:**, and select your build path. When you're finished, click on **OK** button.

6. Click on the **Build** menu bar, and click on **Build Kernel Simulator**

7. In **Windows Explorer**, go to the build directory and then double-click on the executable file. 

- For Unix systems (MonoDevelop)

1. Install [Mono Runtime](http://www.mono-project.com/docs/about-mono/languages/visualbasic/) and MonoDevelop.

2. After installation, extract the source code, open MonoDevelop, and click on **Open...**

3. Go to the source directory, and double-click the solution file
	
4. Change the output directory if you are building using **Release**.

5. Click on the **Build** menu bar, and click on build button to compile.

6. In **your file manager**, go to the build directory and then double-click on the executable file.

## |-----+--> _History_ <--+-----|

Please note that dates mentioned here is for development date changes only. If you want to access the old versions, see `archive` branch.

**2/22/2018 - 0.0.1:** Initial release, normally, for Windows.

**3/16/2018 - 0.0.1.1:** Added "showmotd", changed a message and better checking for integer overflow on Beep Frequency.

**3/31/2018 - 0.0.2:** Code re-design, more commands, implemented basic Internet, argument system, changing password, and more changes.

**4/5/2018 - 0.0.2.1:** Fix bug for "Command Not Found" message, and added forgotten checking for root in "chhostname" and "chmotd".

**4/9/2018 - 0.0.2.2:** Fix bug for network list where double PC names show up on both listing ways, Error handling on listing networks.

**4/11/2018 - 0.0.2.3:** Fix crash on arguments after reboot, fix bugs, and more.

**4/30/2018 - 0.0.3:** Fix bugs, Log-in system rewritten, added commands, added arguments, added permission system, custom colors, and more.

**5/2/2018 - 0.0.3.1:** Shell title edited in preparation for the big release, fix bugs with removing users, fix blank command, and added admin checking.

**5/20/2018 - 0.0.4:** Change of startup text, customizable settings, Themes, Command-line arguments, Command argument and full parsing, Actual directory system (alpha), more commands, calculator, debugging with stack trace, debugging logs (unfinished), no RAM leak, fix bugs, and more.

**5/22/2018 - 0.0.4.1:** Fix bugs in changing directory, Fix bugs in "help chdir", added alias for changing directory named "cd", and config update.

**7/15/2018 - 0.0.4.5:** Fix bugs when any probers failed to probe hardware, added more details in probers, Help system improved, Fix bugs in color prompts, Prompts deprecated, and more.

**7/16/2018 - 0.0.4.6:** Removed extraneous "fed" that stands as the removed command in 0.0.4.5, Preparation for 0.0.5's custom substitutions.

**7/17/2018 - 0.0.4.7:** Better Error Handling for "ping" command, Fixed "unitconv" usage message

**7/21/2018 - 0.0.4.9:** Better Error Handling for "unitconv" command, Added temporary aliases (not final because there is no "showaliases" command), fix some bugs, added time zones ("showtdzone", and show current time zone in "showtd"), Added "alias", "chmal", and "showmal", Made MOTD after login customizable, Allowed special characters on passwords to ensure security, Made Kernel Simulator single-instance to avoid interferences, and more.

**8/1/2018 - 0.0.4.10:** Fused "sysinfo" with "lsdrivers", Improved Help definition (used dictionary for preparation for modding), added "lscomp" which can list all online and offline computers by names only, Added error handler for "lsnet" and "lsnettree", fixed grammatical mistakes in "lsnet" and "lsnettree", added mods (commands not implemented yet - <modname>.m), added screensavers, changed the behavior of showing MOTD, fixed bug where instance checking after reboot of the kernel would say that it has more than one instance and should close, and more.

**8/3/2018 - 0.0.4.11:** Removed pre-defined aliases, Fixed known bug that is mentioned.

**8/16/2018 - 0.0.4.12:** Replaced disco command with a screensaver. It seems like 0.0.5 will be released because it looks stable, but we have some remaining changes before the final release.

**9/4/2018 - 0.0.5.0:** Removed prompts, fixed MAL username probing, added "showaliases", fixed alias parsing, removed the requirement to provide command to remove alias, and implementation of user-made commands in mods

**9/6/2018 - 0.0.5.1:** Follow-up release removed unused code, improved behavior of debugging logs, and improved readability of a debug message while probing mods with commands without definitions.

**9/9/2018 - 0.0.5.2:** Made GPU probing on boot, removing "gpuprobe" argument, changed behavior of updating config

**9/22/2018 - 0.0.5.5:** Re-written config, Forbidden aliases, added missing help entries for "showalises", added more MOTD and MAL placeholders, fixed repeating message of RAM status, and an FTP client has been added, finally!

**10/12/2018 - 0.0.5.6:** Improved probers, username list on log-in, better compatibility with Unix

**10/13/2018 - 0.0.5.7:** Fixed crash when starting when running on a file name that is other than "Kernel Simulator.exe", Better error handling for FTP, Added current directory printing in FTP, removed "version" command, fixed the "Quiet Probe" value being set "Quiet Probe", Expanded "sysinfo", Fixed configuration reader not closing when exiting kernel, (Unix) Fixed a known bug

**11/1/2018 - 0.0.5.8:** Removed beeping when rebooting and shutting down, Removed "beep" command, (Windows) Probers will now continue even if they failed, Disposing memory now no longer uses VB6 method of handling errors

**12/24/2018 - 0.0.5.9:** Mods will now be stopped when shutting down, Mods can have their own name and their own version, fixed debugger not closing properly when rebooting or shutting down, Shell now no longer exit the application when an exception happens, Debugging now more sensitive (except for getting commands), Now debug writer doesn't support writing without new lines, You are finally allowed to include spaces in your hostname as well as hostnames that is less than 4 characters like "joe", Deprecated useless and abusive commands, Removed extra checks for IANA timezones resulting in no more registry way, fixed listing networks, Added currency converter that uses the Internet (If we have added local values, we have to release more updates which is time-consuming, so the Internet way conserves time and updates), we have finally allowed users to view debug logs using KS with the debugging off, we have improved FTP client, for those who don't speak English can now set their own language although the default is English, fixed missing help entry for "lscomp", Added kernel manual pages, took out Windows XP support, fixed NullReferenceException when there are errors trying to compile mods, added testMods cmdline argument, and more...

**2/16/2019 - 0.0.5.10:** Improved readability of manual pages (vbTab is now filtered and will not cause issues), Now the translator prints debug info when a string is not found in the translation list, Hardware Prober: Stop spamming "System.__ComObject" to debugger to allow easy reading, Manpage Parser: Stop filling debug logs with useless "Checking for..." texts and expanded few debug messages, Fixed the BIOS string not showing, Removed unnecessary sleep platform checks, Removed "nohwprobe" kernel argument as hardware probing is important, Removed unnecessary timezone platform checks, Updated FluentFTP and Newtonsoft.Json libraries to their latest stable versions, No stack duplicates except the password part in Login, Fixed bug of MAL and MOTD not refreshing between logins, Fixed bug of sysinfo (the message settings not printing), The kernel now prints environment used on boot, debug, and on sysinfo command, Made writing events obsolete

**2/18/2019 - 0.0.5.11:** Made GPU and BIOS probing `<Obsolete>`, No more COM calls when probing hardware, Removed a useless file that has hard drive data, Fixed the translation of sysinfo when displaying the kernel configuration section, Removed status probing from HDD and RAM (See why on `usermanual History of Kernel Simulator`, section `Truth about status probing`), Fixed the CHS section not appearing if the hard drive has the Manufacturer value, Fixed the translator not returning English value if the translation list doesn't contain such value, Fixed the GPU prober assuming that Microsoft Basic Display Driver is not a basic driver, Made screensavers be probed on boot, Fixed NullReferenceException when trying to load the next screensaver after an error occured on the previous screensaver, Fixed the OS info not translated when starting up a kernel, Fixed language config not preserving when updating, Debug information now prints to VS2017 debug output window (You still have to turn on debugging), Made the loadsaver command reloadsaver, Removed useless and abusive commands (echo, panicsim and choice)

**2/22/2019 - 0.0.5.12:** Now createConf cmdline arg only creates config if the config file isn't found, Some preparations for 0.0.6 (slimming down only), Removed the GPU and BIOS probing, Now older KS config won't be allowed to be updated here (Workaround: You need to remove your old KS config file and re-run the app), Fixed the Environment.OS bug on Windows 10 (10.0) where it returns Windows 8 (6.2) version, Fixed the placeholders not parsing when using showmotd/showmal command, Fixed the simple help not showing mods, Fixed built-in commands not running after you run mod commands or alias commands, Fixed NullReferenceException when debugging, Improved alias listing, Fixed the printing text exception message not translating to current language, Fixed the "/" or "\" appearing before the modname when probing mods and screensavers, Removed unnecessary fixup in translation, Fixed more stack overflows in FTP shell, Fixed the FTP message translation translating "'help'" as the language when it's supposed to be a command, Fixed the command not found message when not entering anything in FTP shell

**4/14/2019 - 0.0.5.13:** More slimming by JetBrains ReSharper for VS2017, Implemented Linux hardware probing (You need to install inxi for HDD probes to work), Increased .NET requirement to 4.7, Removed warning about binding redirects in MonoDevelop, Increased VS version requirement to VS2019, Removed annoying "Naming rule violation" by using suggested option

**6/13/2019 - 0.0.5.14:** Replaced fake file system with real one (access to your files), Fixed the wrong `changedir` help command being shown instead of `chdir`, `cdir,` which shows the current directory, is now obsolete, Fixed crash while rebooting the kernel

**6/19/2019 - 0.0.6:** New icon, Updated FluentFTP and Newtonsoft.Json libs, Removed writing events, Re-written login (Not all, but re-designed), Fixed the chpwd command not changing password if the target doesn't have password, Fixed chpwd not checking if a normal user changes admin password, Fixed adduser not adding users without passwords, Fixed adduser adding users with passwords even if they don't match, Removed cdir, Added config entry for screensaver name, Implemented debugging and dump files for kernel errors, Shipped with .pdb debugging symbols for KS, Fixed reboot not clearing screen, Added Dutch, Finnish, Italian, Malay, Swedish and Turkey languages (switch to a compatible font in console), Countries and currencies are now listed when not providing enough arguments or issuing "help currency", Fixed help list not updating for new language update when rebooting, Added permanent aliases (located under your profile, aliases.csv), The password is now hidden when logging in to maintain security, Fixed users being removed after each reboot

**6/21/2019 - 0.0.6.1:** Removed currency information showing on help (will bring it back later), Users are now required to enter their API Key from apilayer.net to convert currencies (Basic plan, get at http://currencylayer.com/product, untested: couldn't pay for basic plan)

**6/24/2019 - 0.0.6.2:** Fixed debug log show command not working because the path was not found (typo: Debugger -> Debugging), Added a notice in listing PC commands about latest versions of Windows 10, Fixed debug kernel header not writing when run with debug argument on, Fixed the debug log being empty every reboot and start, Allowed clearing debug log in command using cdbglog, Used built-in FtpVerify enumerators, removing our hash check for older versions of FluentFTP, Better debugging experience, Debugging now shows line number and source file if pdb is on the same folder, Allowed modding using C#

**6/24/2019 - 0.0.6.2a:** Added checking for processor instructions (currently used in kernel booting to see if SSE2 is supported)

**6/25/2019 - 0.0.6.2b:** Added a command named `sses` to list all SSE versions

**6/26/2019 - 0.0.6.3:** Fixed `quiet` not being entirely quiet, Fixed messages not appearing after signing in (ex. Adding user message), Allowed changing language using command, Fixed the help text showing after executing `sses`, Added Czech language

**6/28/2019 - 0.0.6.4:** Fixed NullReferenceException when changing language, Fixed massive documentation newlines when trying to parse an empty word that is not on the beginning (Please note that we still have newline issues in the first line), Added Ubuntu theme, Removed unused flag, Removed extra requirement to parse colors on boot (removed greed), Made reading FTP file size human-readable

**7/6/2019 - 0.0.6.4a:** Fixed Linux hardware probing failing even if succeeded, Fixed RAM prober showing MemTotal: prefix, Made message about libcpanel-json-xs-perl clear

**7/7/2019 - 0.0.6.4b:** Made one preparation for 0.0.6.5: Downloading debug symbols on startup if not found

**7/25/2019 - 0.0.6.5:** Fixed dump files being created without extension, Localized dumps and manpages, Upgraded language version to the latest, Fixed some bugs about filesystem, Fixed CPU clock speed showing up twice in latest processors (processors that have clock speed on their internal names, for ex. "Intel(R) Core(TM) i7-8700 CPU @ 3.20GHz"), Fixed progress bar of FTP transfers so it uses new format, Added ETA and speed

**7/26/2019 - 0.0.6.6:** Updated manual page for new commands, Removed currency command (unpaid)

## |-----+--> _Manual pages_ <--+-----|

The documentations can be found in source code of kernel simulator in `Kernel Simulator/Documentation` and are localized to supported languages.

**Documentation - main page:** Information about Kernel Simulator, this page

**Documentation - contributing rules:** Conditions for contributing to Kernel Simulator

* The text files will be moved to wiki section.

## |-----+--> _Contributors_ <--+-----|

**EoflaOE:** Owner of Kernel Simulator

**Paomedia:** Icon creator

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

