<!-- u250715 -->

<div align="center">

  ![](./.github/repo-resource/image/logo/dvn-logo.png)

  ![Release](https://img.shields.io/badge/release-1.0-teal)&nbsp;&nbsp;
  [![Windows](https://custom-icon-badges.demolab.com/badge/Windows-0078D6?logo=windows11&logoColor=white)](#)&nbsp;&nbsp;
  [![.NET](https://img.shields.io/badge/.NET-9-512BD4?)](#)&nbsp;&nbsp;
  [![C#](https://custom-icon-badges.demolab.com/badge/C%23-%23239120.svg?logo=cshrp&logoColor=white)](#)&nbsp;&nbsp;
  ![License](https://img.shields.io/badge/license-apache-blue)

</div>

# About `dvn`

`dvn` is a command-line utility that starts the components of a development environment.

Let's say you are working on a project named "MyProject", and that project requires:

* A Visual Studio 2022 solution named "*MyProject*"
* A Visual Studio Code workspace named "*MyProject-Documentation*"
* A Visual Studio Code workspace named "*Other-Documentation*"
* GitHub Desktop
* Specific data to be backed up

You *could* do all of the above steps manually, *or* you could let `dvn` do it for you.

When you type `dvn myproject` on a command line:

* Data will be backed up
* Your Visual Studio solutions and workspaces will start
* GitHub Desktop will start

# Configuration

The information `dvn` needs to do what it does is contained in [*manifest files*](#the-manifest-file).

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