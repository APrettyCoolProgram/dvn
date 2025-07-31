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

# Using **dvn**

This is the **dvn** syntax:

```csharp
> dvn <command> [-option01 -option02 ...]
```

## Commands

**dvn** *requires* that you pass a valid `command`.

In general, you'll use the `%environment-name%` command, which will start the specified development environment (or create a blank [manifest file](), if one doesn't exist).

For example, to start/create the `myproj` environment, you would type

```csharp
> dvn myproj
```

To get a list of valid commands, type

```csharp
> dvn help
```

## Options

**dvn** also accepts `options`, which are...optional

Options:

* Must be a single character
* Start with the `-` (dash) character
* Are separated by a space

For example, you can force the data for the `myproj` environment to be backed up by typing

```csharp
> dvn myproj -b
```

To get a list of valid options, type

```csharp
> dvn help
```

# Manifest files

When you start an environment by typing

```csharp
> dvn myproj
```

**dvn** looks for a manifest file named `.\.dvn\manifests\myproj.dvn.manifest`, which contains all of the information **dvn** needs to start the environment.

If the file does not exist, it is created using the default settings, which you will need to modify.


## The default manifest

When a new manifest file is created, it looks like this:

```json
{
  "EnvironmentName": "myproj",
  "EnvironmentDescription": "Environment description",
  "BackupEnabled": false,
  "BackupSources": [
    "\\Path\\To\\Source1",
    "\\Path\\To\\Source2"
  ],
  "BackupLocation": "\\Path\\To\\Backup",
  "ManifestApplications": [
    {
      "Name": null,
      "Description": null,
      "FileName": null,
      "Arguments": null,
      "WorkingDirectory": null
    }
  ]
}
```

## Manifest components

> **REMINDER!**  
> Any `\` characters need to be escaped as `\\`!

Manifest files contain the following components:

* `EnvironmentName`  
The name of the environment (e.g., "myproj").

* EnvironmentDescription`  
The description of the environment (e.g., "My project environment").

* `BackupEnabled`  
Determines if the data backup functionality is *enabled* ("true"), or *disabled* ("false").

* `BackupSources`  
Absolute paths to data that will be backed up, if the data backup functionality is enabled.  

* `BackupLocation`  
The absolute path  where backups are created.

* `ManifestApplications`  
Each application that will be launched by **dvn** has it's own block with the following data:

  *  `Name`  
  The name of the application

  * `Description`  
  Description of the application

  * `FileName`  
  The application file name

  * `Arguments`  
  Any command-line arguments

  * `WorkingDirectory`  
  The application working directory

A completed manifest file looks like this:

```json
{
  "EnvironmentName": "myproj",
  "EnvironmentDescription": "My project environment",
  "BackupEnabled": true,
  "BackupSources": [
    "C:\\repositories\\MyRepository",
    "C:\\data\\reports"
  ],
  "BackupLocation": "C:\\backups",
  "ManifestApplications": [
    {
      "Name": "GitHub Desktop",
      "Description": "GitHub Desktop",
      "FileName": "GitHubDesktop.exe",
      "Arguments": null,
      "WorkingDirectory": "C:\\Users\\JaneSmith\\AppData\\Local\\GitHubDesktop"
    },
    {
    "Name": "Visual Studio Code",
    "Description": "Visual Studio Code IDE",
    "FileName": "Code.exe",
    "Arguments": "Project-documentation.code-workspace | exit /b",
    "WorkingDirectory": "\\path\\to\\VisualStudio"
}
  ]
}
```

The above manifest file will:

1. Start the "**myproj**" development environment
2. Backup the "**C:\repositories\MyRepository**" and "**C:\data\reports**" to "**C:\backups**"
3. Start the "**GitHub Desktop**" application
4. Start "**Visual Studio Code**", using the "**Project-Documentation**" workspace

# Configuring **dvn**

## Ignored data

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