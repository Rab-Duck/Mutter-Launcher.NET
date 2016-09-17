# How to use Mutter Launcher .NET

## About Mutter Launcer .NET

This is an application launcher, which is the mixing of command input and button selection.

You can grep from Miscellaneous list, picked up from the Start menu or the like.
Next, you can execute an item.

this software is suitable for people who come up with words at first, at the time starting the application, 

## Forms

![Main Form](https://raw.githubusercontent.com/Rab-Duck/Mutter-Launcher.NET/master/doc/MainForm.png)
![Setting Form](https://raw.githubusercontent.com/Rab-Duck/Mutter-Launcher.NET/master/doc/SettingForm.png)

## Install and requirements

Download and unzip a MutterLauncherNet_x_x_x.zip file from [release page](https://github.com/Rab-Duck/Mutter-Launcher.NET/releases).    
Set files to any folder.

It require .NET Framework 4.5(over 4.5.2 is better).
Windows Vista or later are supported.

## First step

## How to search

example:
- "hoge" -> contains "hoge" (equal to ".*hoge.*" Regex search)
- " hoge" → skipmatching of "hoge" (equal to ".\*h.\*o.\*g.\*e.\*" Regex search)
- "^hoge" → start with "hoge" (equal to "^hoge.\*" Regex search)
- "hoge$" → end with "hoge" (equal to ".\*hoge$" Regex search)
- "\hoge" → equal to "hoge" (equal to "^hoge$" Regex search)

## How to exec

- Enter -> Run
- Shift + Enter -> open folder
- ctrl + Enter -> Run as Admin

## How to setting

## About User Item

## About Update List

## Uninstall

## Lisence

MIT License
