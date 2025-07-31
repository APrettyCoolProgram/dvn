<!-- u250715 -->

<div align="center">

  ![](./.github/repo-resource/image/logo/dvn-logo.png)

  ![Release](https://img.shields.io/badge/release-1.0-teal)&nbsp;&nbsp;
  [![Windows](https://custom-icon-badges.demolab.com/badge/Windows-0078D6?logo=windows11&logoColor=white)](#)&nbsp;&nbsp;
  [![.NET](https://img.shields.io/badge/.NET-9-512BD4?)](#)&nbsp;&nbsp;
  [![C#](https://custom-icon-badges.demolab.com/badge/C%23-%23239120.svg?logo=cshrp&logoColor=white)](#)&nbsp;&nbsp;
  ![License](https://img.shields.io/badge/license-apache-blue)

</div>

# About **dvn**

**dvn** is a command-line utility for managing development environments.

Let's say you are working something called "MyProject", which requires:

* A Visual Studio 2022 solution named "*MyProject*"
* A Visual Studio Code workspace named "*MyProject-Documentation*"
* A Visual Studio Code workspace named "*Other-Documentation*"
* GitHub Desktop
* Specific data to be backed up

You *could* do all of the above steps manually, *or* you could let **dvn** do it for you.

Typing `dvn myproject` will:

* Data will be backed up
* Your Visual Studio solutions and workspaces will start
* GitHub Desktop will start

## Pre-requisites

* Windows operating system (MacOS/Linux versions are on the roadmap)
* [.NET 9](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)

# Initial setup

## Installing **dvn**

**dvn** is a portable application, so "installing" is simple:

1. Download the [latest release]()
2. Extract the contents of the downloaded file to a folder of your choice
3. Open a terminal in the that folder

You'll notice that the folder contains a single item: `dvn.exe`

## Creating the **dvn** framework

Using the terminal window you opened, type: `~$ dvn`

Since this is the first time you are executing **dvn**, you will see a message letting you know that the *framework* - the files and folders **dvn** needs - will be created.

Now you can start using **dvn**

# Using **dvn**

This is the **dvn** syntax:

```ps
> dvn <command> [-option01 -option02 ...]
```

## **dvn** *commands*

**dvn** *requires* that you pass a valid `command`.

In general, you'll use the `%environment-name%` command, which will start the specified development environment (or create a blank [manifest file](), if one doesn't exist).

For example, to start/create the `myproj` environment, you would type

```csharp
> dvn myproj
```

Other commands include:

* `about` - Displays information about dvn  

* `help`  - Displays the dvn help information  

* `list`  - Lists available development environments  

For example, you can get a list of valid commands by typing

```bat
> dvn help
```


## **dvn** *options*

**dvn** also accepts `options`, which are...optional

Options:

* Must be a single character
* Start with the `-` (dash) character
* Are separated by a space

For example, you can force the data for the myproj environment to be backed up by typing


```console
dvn myproj -b
```
```ps
dvn myproj -b
```

```cmd
dvn myproj -b
```

```csharp
dvn myproj -b
```

The available options are:

* `-b` - Force the data backup process for an environment




<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>


The information **dvn** needs to do what it does is contained in [*manifest files*](#the-manifest-file).

When **dvn** starts, it loads a manifest file that tells it:

A default manifest looks like this:

```json
{
  "Name": "Environment name",
  "Description": "Environment description",
  "BackupData": false,
  "BackupSources": [
    "\\Path\\To\\Source1",
    "\\Path\\To\\Source2"
  ],
  "BackupTarget": "\\Path\\To\\Backup",
  "Application": [
    {
      "Name": null,
      "Description": null,
      "FileName": null,
      "Argument": null,
      "WorkingDirectory": null
    }
  ]
}
```

## Manifest components

### Name

The **Name** component is the name of the development environment.

This value should match the file name (e.g., ***MyEnvironment***.dvn).

If **dvn** creates a new manifest file, it will set `Name` to the `command` that was passed.

For example, `~$ dvn MyEnvironment` will create a MyEnvironment.dvn file with the following:

```json
    "Name": "MyEnvironment",
```






> **REMINDER!**  
> Any `\` characters need to be escaped as `\\`!




# Usage

To use **dvn**, type: `dvn <command> [-options]`


## Commands

**dvn** recognizes the following commands:

* `~$ dvn %environment%`  
Load the `%environment%.dvn` manifest file, or create a default manifest template if one does not exist.

* `~$ dvn help`  
Show the **dvn** help information

* `~$ dvn info`  
Show information about **dvn**

* `~$ dvn list`  
List the available environments

## Options

**dvn** recognizes the following options:

* `-b`  
Force data to be backed up.  



### File path syntax




## Description

The **Description** component is the description of the development environment, and is displayed when using the `~$ dvn list` command.

For example:

```text
~$ dvn list

=========
   dvn
=========

  Available environments:

  MyEnvironment - The development environment for my project!
```

If **dvn** creates a new manifest file, it will set `Description` to the "Environment description".

It is recommended that you manually change the `Description` to accurately describe the environment.

## BackupData

The `BackupData` component determines if specified data is to be backed up prior to starting an environment.

Since this process can take some time, the default setting is `false`, with the option of using the [`-b`](#options) option to force the backup of data.

## BackupSources

You can backup any folder by placing its path in the `BackupSources` list.

BackupSources are compressed into timestamped .zip files, and placed in the [`BackupTarget`](#backuptarget) location.

### Ignored data

While any directory can be backed up, this feature is intended to be used to backup source code repositories. As such, the following data is ignored so file sizes are kept to a minimum:

```text
Files:
".DS_Store",
"Thumbs.db",
"desktop.ini",
"package-lock.json",
"yarn.lock",
"pnpm-lock.yaml",
"npm-shrinkwrap.json"

Folders:
"node_modules",
"bin",
"obj",
".git",
".vs",
".vscode",
".idea",
"packages"
```

## BackupTarget

All [`BackupSources`](#backupsources) are compressed into timestamped .zip files, and placed in the `BackupTarget` location.

## Applications

**dvn** can start most applications.

Each application needs to have its own `Application` component, which has its own sub components.

### Name

The application name. This is currently not used.

### Description 

The application description. This is currently not used.

### FileName

The file name (executable) that is used to launch the application.

### Arguments

Any arguments that you want to pass to the application.

### WorkingDirectory

The path where the application executable is located.

For example, to launch Visual Studio Code:

```json
{
    "Name": "Visual Studio Code",
    "Description": "Visual Studio Code IDE",
    "FileName": "Code.exe",
    "Arguments": "",
    "WorkingDirectory": "\\path\\to\\VisualStudio"
}
```

You can launch specific Visual Studio Code workspaces by passing the workspace as an argument:

```json
{
    "Name": "Visual Studio Code",
    "Description": "Visual Studio Code IDE",
    "FileName": "Code.exe",
    "Arguments": "Project-documentation.code-workspace | exit /b",
    "WorkingDirectory": "\\path\\to\\VisualStudio"
}
```

The `.\.dvn\configs\dvn.config` file contains the [configuration settings]() for **dvn**, but for now you can leave this file alon

# Configuring **dvn**
## Basic confituration
## Advanced configuration