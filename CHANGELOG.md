## latest version 
> not released, available if you build from code
- [Notepad Sensor] Add confirm dialogBox when clearing notepad [#1](https://github.com/Fabrice-Deshayes-aka-Xtream/XtreamToolbox/issues/1)
- [Notepad Sensor] Import text file append instead of replace [#5](https://github.com/Fabrice-Deshayes-aka-Xtream/XtreamToolbox/issues/5)
- [MyComputer Sensor] Improve MyComputer sensor's contextual menu [#3](https://github.com/Fabrice-Deshayes-aka-Xtream/XtreamToolbox/issues/3)
- [About Form] Redesign about form and replace changelog by a link to github [#4](https://github.com/Fabrice-Deshayes-aka-Xtream/XtreamToolbox/issues/4)
- [Commons] Better GFX unity, use more GANT icons [#7](https://github.com/Fabrice-Deshayes-aka-Xtream/XtreamToolbox/issues/6)
- [Options] Fix time servers list (remove somes that don't work and use time.windows.com as default) [#6](https://github.com/Fabrice-Deshayes-aka-Xtream/XtreamToolbox/issues/6)
- [Storage Sensor] fix some bugs [#8](https://github.com/Fabrice-Deshayes-aka-Xtream/XtreamToolbox/issues/8)
  - fix icon for network drive
  - limit performance details for fixed drives, otherwise it cause error for network drives
  - remove compute of total/free size for CD Rom drive, it cause division by zero
  - reduce width of drive info to allow nice scroll bars if there is more than 7 drives
  - display in terrabyte (TB) for big space
  - fix read/write real time graph to better manage peek magnitude
- [Weather Sensor] fix exception when weather api return no current condition [#9](https://github.com/Fabrice-Deshayes-aka-Xtream/XtreamToolbox/issues/9)
- [Photo Renamer] bad count of affected files in simulation mode (always zero) [#10](https://github.com/Fabrice-Deshayes-aka-Xtream/XtreamToolbox/issues/10)
- [Storage Sensor] refresh drives list each time extended panel is shown [#11](https://github.com/Fabrice-Deshayes-aka-Xtream/XtreamToolbox/issues/11)
- [System Info Sensor] Reduce CPU usage when extended panel is not displayed
- [FavoriteLocation Sensor] Replace old sensor with new one to go quickly to my music, my document, my images, my video, my downloads... [#2](https://github.com/Fabrice-Deshayes-aka-Xtream/XtreamToolbox/issues/2)

## version 2018.12.31
- improve TimeICalManager sensor with left/right click actions
- fix shutdownManager sensor
  - icon size (regression from 2018.12.26)
  - timed actions are working now
- improve storage sensor by adding all devices (usb, cdrom...)
- use GANT icon for analog clock sensor
- en-US is now the default language
- fix code style(end)
- move p/invoke calls in NativeMethods class
- add credits to Mattias Sjögren, Valer BOCAN and 
  Syed Mehroz Alam in about screen
- update Newtonsoft package from 4.5.11 to 12.0.1
- remove dependency to google APIs

## version 2018.12.26
- fix code style (begin)
- write documentation in markdown format
- fix some wording
- find workaround for warning AL1073: Referenced assembly 
  'mscorlib.dll' targets a different processor
- put project on github

## version 2017.03.17
- use .NET framework 4.6.1
- build with new Visual Studio Community 2017

## version 2016.04.15
- prevent systray left mouse button click to open extended panels
- fix scrolling in read/write graph of storage manager

## version 2015.12.22
- fix number of processes and threads max in system info sensor (was 
  only refresh when extended panel was displayed)

## version 2015.12.05
- change systray icon for better look in win 10

## version 2015.09.15
- rewrite weather sensor because old weather channel api was not 
  available anymore

## version 2015.08.01
- recompile with visual studio 2015 community edition
- update google calendar and Global Mouse and Keyboard Hooks 
  dependency using nugets package manager (global mouse hooks 
  don't work with new .NET framework release on 07-2015)
- suppress win+x keyboard hook (cause some problems on my dev 
  machine)
- suppress win+print screen keyboard hook : this functionnality is now
  native on win 10

## version 2014.11.01
- Toolbox is now full 64x

## version 2010.11.05
- if no proxy user is configured, don't send proxy credential
- simplify keys hooking
- new functionality : print screen hooking
  . printscreen key make a screenshot in clipboard
  . ALT + prinscreen key make a foreground windowshot in clipboard
  . WIN + printscreen key save a screenshot image as file on a 
    configurable disk path (jpg/png/gif/tiff/bmp)
  . WIN + ALT + printscreen key save a foreground windowshot image
    as file on a configurable disk path(jpg/png/gif/tiff/bmp)
  
## version 2010.11.01
- correct recycle bin sensor for Windows 64 bits
- finished Google Calendar viewer in Calendar Sensor. Display only an
  empty calendar if no google account is set in option
- shutdown manager improvments (display nb of days/hours/min/sec 
  before plannified action).
- display IPV4 & IPV6 addresses in SysInfo sensor

## version 2010.08.28
- improved visibility of toolbox (activate visible sensors when toolbox 
  is activated) and activate toolbox when clicking on systray icon.
  
## version 2010.08.03
- improve options to allow proxy port configuration

## version 2010.05.10
- shutdown manager improvments

## version 2010.01.17
- refactoring of TimeManager Sensor using Google Calendar API
- TimeManager Sensor allow events deletion

## version 2009.12.30
- correct cross thread exception in SystemInformations Sensor
- automatically detect internet connection to refresh sensors 
  TimeIcalManager, Weather, Inbox
- autorefresh TimeIcalManager each 60 seconds (reload local and 
  remote calendar and refresh reminder icon if needed).
- add progress indicator when refreshing Inbox Sensor
- remove unused png resources

## version 2009.12.27
- refactoring of Shutdown manager : 
  . new hibernation functionnality
  . new switch user functionnality
  . add option to chose which action will be done by clicking on upper 
    or lower button
  . add contextual panel when right click on buttons allowing delayed 
    action like shutdown, log off, hibernate...
  
## version 2009.12.24 - Merry Christmas !!!
- remove sensor mediaplayer because of incompatibility with new
  ## version of winamp (5.571)
- remove sensor volume because of incompatibility with Windows 7

## version 2009.11.05
- correct My Computer Sensor with shortcut for Windows Update on Seven
- correct System information Sensor to display IPV4 instead 
  of V6 on Vista/Seven

## version 2009.10.24 - start of seven 64 bits improvments
- correct fatal bug in volume sensor. now toolbox start but 
  volume sensor don't work on Windows Seven
- update DDay.iCal librairie from 0.60 to 0.80 (correct some probleme 
  with google calendar)
- correct redraw bug in timeManagerSensor

## version 2009.04.25
- Better manage redraw (fade in on startup)
- Changing option won't realloc all sensor (only new ones)

## version 2009.04.21
- Optimize startup time of toolbox
- Suppress bad working auto hide options
- Add WIN+X to bring toolbox to front
- Correct bad toolbox width when exiting option
- Manage volume up/down/mute keys on volume sensor

## version 2009.04.18
- Enhance mouse control on volume sensor

## version 2009.04.11
- Allow volume control with mouse on volume sensor

## version 2009.04.04
- Add Volume Sensor with global keyboard hooks
- Improved auto hide function with global mouse hooks

## version 2009.03.14
- Correct System info sensor graph and vumeter

## version 2009.01.25
- Correct Winamp sensor (if no artist found, clear artist event tab)

## version 2008.12.27
- Improve SystemInfo sensor startup time

## version 2008.08.30
- Correct Weather sensor after interface's contract change with provider.

## version 2008.08.22
- Correct time manager extended panel title and display of today events
- Correct Winamp Sensor: if no meta data found, don’t try to change 
  what’s listen in messenger
- Reinit max read and write value in storage sensor when changing
  device. Add more space to display information line.

## version 2008.07.12
- Enhanced display informations on exif renamer
- Remove Fast Rss Reader (a lot of software do that better than me)
- Manage exception on cd cover display in Winamp Sensor
- Correct System infos sensors to display correct virtual memory size 
  even if pagefile is spawn on multiple drives.
- Change ## version management (use yyyy.mm.dd instead)
- suppress hide functionnality by systray icon (not well working
  with extended panel)
- correct tooltip display

2008-05 :: version 0.9.8.6
- Limit storage sensor to fixed drive only
- Add icon for exe application
- Allow connecting network drive on startup (see options)
- Offer to import or export options in XML format

2008-04 :: version 0.9.8.5
- Improve LAN/WAN system informations 
    . replace int16 by int32
    . you can now disable lan or wan
    . hide MS TCP Loopback network interface
- Use new ## version of DDay.iCal component (0.60) which correct some  
  bugs in TimeManager Sensor (bad hours)
- Correct null pointer exception bug with never diplayed extended panel 
  when moving toolbox
- Hide proxy password typing in options
- Use new ## version of C2DPushGraph component which correct bug after
  long workstation lock in System Sensor graph mode
- Allow drag'n drop on Recycle Bin Sensor

2007-12 :: version 0.9.8.4
- Correct bad counter in exif renamer tools
- Correct NTP time synchronizer (don't work if options weren’t open)
- Don't delete favorite locations if not found

2007-10 :: version 0.9.8.3
- Correct null pointer exception when moving toolbox
- Update Ical viewer en ical and DDay.iCal dll (0.40)
- Correct extended panel behaviour on hide/show with systray icon

2007-10 :: version 0.9.8.2
- Improve POP3 Checker sensor: you can choose your defaut email
  client and pop server port.
- Improve memory usage: 55 700 mb -> 38 700 mb :-)
- Let system automaticaly close ToolBox (ex: after windows update)
- French translation for Quicklaunch item's properties
- French translation for ICalendar viewer
- Review tab order in Quicklaunch item's properties
- Review tab order in ICalendar viewer
- Review tab order in Fast RSS Viewer
- Review tab order in Exif jpef renamer
- Review tab order in Option

2007-07 :: version 0.9.8.1
- New WAAC.dll for Winamp Sensor has a memory leak. Come back to 
  older version
- Unlock folder.jpg resource in Winamp Sensor when winamp 
  is closed.
- Correct BackgroundWorker behavior if called when busy.

2007-05 :: version 0.9.8
- Update WAAC dll for Winamp Sensor. Correct song samplerate in HZ.

2007-04 :: version 0.9.7
- Debugging of Winamp sensor
- Debugging of ICalendar viewer. Update DDay.iCal dll

2007-03 :: version 0.9.6
- New weather iconset by iconbest.com (by Wojciech Grzanka)
- Complete refactoring of Time Manager sensor, with support
  for ical calendar format (local or remote)
- Hide extended panels from alt-tab menu

2007-03 :: version 0.9.5
- Correct bug on QuickLaunch Sensor (shortcut property not saved 
  if modified)
- Correct bug on Winamp Sensor: 
  - avoid msgBox if artist not found on audioscrubber
  - correct Live Messenger "now playing" behavior.
  
2007-02 :: version 0.9
- Correct some bugs on storage sensor and recycle bin tooltips
- Adds some artist's tour info from LastFm (audio scrubber technology)
  on what's playing on winamp sensor.

2007-01 :: version 0.8
- Add new Winamp Sensor which analyzes current song played in
  Winamp (based on WAAC library by slowmo). 
  Display id3 tag and album cover. This sensor changes 
  "What's i'm listening" in MSN and Live Messenger too.
- Improve Storage sensor in design and functionality.
- Order classes in one package for each sensor.
- Improve CPU usage: less than 1% with all sensor on toolbox!

2006-12 :: version 0.7
- Debug time manager English date/time
- Debug Weather sensor (n/a still in background for nothing)
- Add max number of process and threads in SysInfo Sensor
- Update SysInfo Sensor 
  - add lan/wan send/receive without click
  - add new display mode in graph (based on work by Stuart Konen)
- Hide extended sensor panel from alt/tab view
- Add Drive Status Sensor
- Add Analogic Clock Sensor (based on work by Syed Mehroz Alam)
- Add .NET Framework ## version on about's form.
- Regenerate more optimized .ico for all forms.
- Update Calendar sensor (design, event manager and reminder)
- Update Inbox Sensor with spam manager

2006-11 :: version 0.6
- Manage arguments, start in directory and description in 
  QuickLaunch sensor
- Remove vumeter's tooltip on sensor sysInfo (setTooltip .NET bug)
- Remove trash's tooltip on sensor RecycleBin (setTooltip .NET bug)
- Catch exceptions in POP3Checker Sensor

2006-10 :: version 0.5
- Debug http proxy
- Debug network vumeter
- Move TimeManager options in calendar forms
- POP3 Checker Sensor
- Redesign icon with new GRANT pack

2006-09 :: version 0.4
- French translation of Key status sensor
- French translation of Time Manager sensor
- French translation of Note pad sensor
- French translation of About Form
- French translation of Image renamer
- French translation of Calc sensor
- French translation of Shutdown Manager sensor
- French translation of Recycle Bin sensor
- French translation of Favorite location sensor
- French translation of tray menu
- French translation of My Computer sensor
- French translation of Toolbox starter / ender / launcher
- French translation of Power Management sensor
- French translation of System Information sensor
- French translation of Fast Rss Viewer
- French translation of Weather sensor
- Implement Drag'n drop and delete options for Quicklaunch Sensor
- Manage .lnk shortcut in Quicklaunch Sensor (use code by Mattias Sjögren)
- Update auto show toolbox algorithm (screen border)
- Correct PowerStatus Sensor tooltips
- Enhanced design of My Computer Sensor's context menu
- Add "choose language" in general options
- Resize options form
- Caps Lock / Num Lock display status sensor
- Time synchronization using SNTP Time server (based on work by Valer Bocan)
- Enhance Image renamer (work in background, cancel allowed...)

2006-08 :: version 0.3
- Complete refactoring of Sensor's code with multithreading for long 
  delay sensor's initialization
- Progress barre on toolbox initialization
- Manage magnetic screen border on toolbox moves
- Add Photo Jpeg renamer
- Add HTTP proxy configuration
- Upgrade Notepad Sensor (clear, load and save as button)
- Externalize Rss Reader as tool which can be access by system tray

2006-07 :: version 0.2
- Development of My Computer Sensor
- Development of Notepad Sensor
- Development of Windows Calc Sensor
- Development of The Weather Channel Sensor

2006-06 :: version 0.1
- Design and development of generic toolbox sensor architecture
- Development of System information Sensor
- Development of Recycle bin Sensor
- Development of Favorite locations Sensor
- Development of Shutdown / restart / logoff Sensor
- Development of QuickLauncher Sensor
- Development of RSS Reader Sensor
