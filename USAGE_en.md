# How to use Mutter Launcher .NET

## About Mutter Launcer .NET

This is an application launcher, which is the mixing of command input and button selection.

You can grep from Miscellaneous list, picked up from the Start menu or the like.
Next, you can execute an item.

this software is suitable for people who come up with words at first, at the time starting the application, 

## Forms

![Main Form](https://raw.githubusercontent.com/Rab-Duck/Mutter-Launcher.NET/master/doc/MainForm.png)

## Install and requirements

Download and unzip a MutterLauncherNet_x_x_x.zip file from [release page](https://github.com/Rab-Duck/Mutter-Launcher.NET/releases).    
Set files to any folder.

It require .NET Framework 4.5(over 4.5.2 is better).
Windows Vista or later are supported.

## First step

1. When you start the MutterLauncherNet.exe, the icon appears in the task tray.
2. <kbd>Shift</kbd>+<kbd>Space</kbd> to open main form.  
3. If you enter the character at the text box of the top of the form, You can search items by partial match search.
(Searched from Start menu, Desktop, Control panel, PATH, my favorites)
4. When you grep what you want to start, it is to select it using the up and down keys and to started by Enter.

## How to search

example:
- "hoge" -> partial match search of "hoge" (equal to ".*hoge.*" Regex search)
- " hoge" → skip-matching of "hoge" (equal to ".\*h.\*o.\*g.\*e.\*" Regex search)
- "^hoge" → forward match search of "hoge" (equal to "^hoge.\*" Regex search)
- "hoge$" → backward match search of "hoge" (equal to ".\*hoge$" Regex search)
- "\hoge" → exact match search of "hoge" (equal to "^hoge$" Regex search)

## How to exec

- Enter -> Run
- Shift + Enter -> open folder
- ctrl + Enter -> Run as Admin

## How to setting
![Setting Form](https://raw.githubusercontent.com/Rab-Duck/Mutter-Launcher.NET/master/doc/SettingForm.png)

## About User Item

## About Update List

## Uninstall

## Lisence

MIT License
