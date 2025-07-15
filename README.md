***THIS DOCUMENTATION IS A WORK IN PROGRESS***

<div align="center">

  ![Release](https://img.shields.io/badge/release-0.9-development+rc1)&nbsp;&nbsp;
  ![License](https://img.shields.io/badge/license-apache-blue)

</div>

# dvn

## What

**dvn** is a command-line utility that helps start up a development environment.

## Why

For example, let's say you are working on a project named "MyProject", and that project requires

* A Visual Studio 2022 solution named `"MyProject"`
* A Visual Studio Code workspace named `"MyProject-Documentation"`
* A Visual Studio Code workspace named `"Other-Documentation"`
* GitHub Desktop

In addition, you want to backup a bunch of data before you start a development session.

You *could* do all of the above steps manually.

Or you could let `dvn` do it for you.

## How, Part One

When you type `dvn myproject`:

* Data will be backed up as a .zip file
* Visual Studio solutions and workspaces will start
* Other applications will start

## How, Part Two

dvn uses manifest files to tell it what to do.

When dvn starts, it loads a [manifest file](#the-manifest-file) that tells it:

* If it should backup data, and if so what data and where to
* What applications to start

# Commands

dvn recognizes the following commands:

* `~$ dvn %environment%`  
This is the main dvn command, and tells dvn to load the `%environment%.dvn` manifest file. If a `%environment%.dvn` manifest file does not exist, a default manifest template is created.

* `~$ dvn help`  
Show the help information

* `~$ dvn info`  
Show information about dvn

* `~$ dvn list`  
List the available environments

# The Manifest file

```json
{
  "Name": "web",
  "Description": "Environment description",
  "BackupData": true,
  "BackupSources": [
    "path\\to\\\source01",
	"path\\to\\\source02",
	"path\\to\\\source03"
  ],
  "BackupTarget": ""path\\to\\\target"
  "Application": [
    {
      "Name": "GitHub Desktop",
      "Description": "GitHub Desktop",
      "FileName": "GitHubDesktop.exe",
      "Arguments": null,
      "WorkingDirectory": "C:\\Users\\Chris.Banwarth\\AppData\\Local\\GitHubDesktop"
    }
  ]
}
```

Each application you want to launch needs the following information:

* `Name`: The application name
* `Description`: The application description
* `FileName`: The filename that launches the application
* `Arguments`: Application arguments
* `WorkingDirectory`: The path where the application is located

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

The path in this example isn't valid because I use a portable version of VSCode.

Please note the `\\`, since the `\` needs to be escaped.
