<!--
  260617_code
  260617_documentation
-->
<div align="center">

  <picture>
    <source media="(prefers-color-scheme: dark)" srcset="/.github/repository/logo/dvn-306x407.png">
    <source media="(prefers-color-scheme: light)" srcset="/.github/repository/logo/dvn-306x407.png">
    <img alt="Fallback image description" src="/.github/repository/logo/dvn-306x407.png">
  </picture>

  <br/>

  ![RELEASE](https://img.shields.io/badge/version-1.2-teal)&nbsp;
  ![STAGE](https://img.shields.io/badge/stable-green)&nbsp; <!-- Alpha = Red, Beta = Yellow, Stable = Green -->
  ![LICENSE](https://img.shields.io/badge/license-apache-blue)&nbsp;
  ![Platform](https://img.shields.io/badge/Platform-Windows%20%7C%20macOS%20%7C%20Linux-lightgrey)&nbsp;

</div>

---

<h6 align="center">

  [MANUAL](docs/man/README.md)&nbsp;&bull;&nbsp;[CHANGELOG](docs/CHANGELOG.md)&nbsp;&bull;&nbsp;[ROADMAP](docs/ROADMAP.md)&nbsp;&bull;&nbsp;[KNOWN ISSUES](docs/KNOWN-ISSUES.md)

</h6>

---

### CONTENTS

| CONTENTS                                    |
|---------------------------------------------|
| [ABOUT DVN](#about-dvn)                     |
| [HOW IT WORKS](#how-it-works)               |
| [GETTING STARTED](#getting-started)         |
| [INSTALLING](#installing)                   |
| [USAGE](#usage)                             |
| [ACKNOWLEDGEMENTS](#acknowledgements)       |
| [RELATED PROJECTS](#related-projects)       |
| [LICENSE](#license)                         |

---

## ABOUT DVN

**dvn** is a command-line utility for managing development environments.

Let's say you are working something called "MyProject", which requires:

* A Visual Studio 2022 solution named "*MyProject*"
* A Visual Studio Code workspace named "*MyProject-Documentation*"
* A Visual Studio Code workspace named "*Other-Documentation*"
* GitHub Desktop
* A webpage containing API documentation
* Specific data to be backed up

You *could* do all of the above steps manually, *or* you could let **dvn** do it for you by typing

```bash
dvn myproject
```

<!--
### Features

* Feature — What it does and why it matters.
* Feature — What it does and why it matters.
* Feature — What it does and why it matters.
-->

### What's New

**v1.2**  

* Updated to .NET 10
* Updated XML documentation
* General code cleanup and refactoring

See the [CHANGELOG](docs/CHANGELOG.md) for more details.

<!--
### Built With

* [Technology or framework](URL)  - Role it plays in the project.
* [Technology or framework](URL)  - Role it plays in the project.
* [Technology or framework](URL)  - Role it plays in the project.

-->

<!--

## How It Works

A blurb describing how the project works at a high level.

-->

### Requirements

* [.NET 10 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)

## INSTALLING

**dvn** is a portable application, so "installing" is simple:

1. Download the [latest release]()
2. Extract the contents of the downloaded file to a folder of your choice

You'll notice that the folder you extracted to contains a single item: `dvn.exe`

## CONFIGURING

The `.\.dvn\configs\dvn.config` file contains the configuration settings for **dvn**.

Currently this file only contains a list of files and folders that are ignored when the data backup functionality is enabled (to keep file sizes are kept to a minimum), so their isn't much to configure.

### MANIFEST FILES

# Manifest files

When you start an environment by typing

```bash
dvn myproj
```

**dvn** looks for a manifest file named `.\.dvn\manifests\myproj.dvn.manifest`, which contains all of the information **dvn** needs to start the environment.

If the file does not exist, it is created using the default settings, which you will need to modify.

> **PLEASE NOTE!**  
> Any "`\`" characters in the manifest file need to be escaped as "`\\`".

## The default manifest

When a new manifest file is created, it looks like this:

```json
{
  "DevelopmentEnvironment": {
    "Name": "test2",
    "Description": "Default environment description.",
    "BackupEnabled": false,
    "BackupSources": null,
    "BackupLocation": null
  },
  "EnvironmentApplications": [
    {
      "Name": null,
      "Description": null,
      "FileName": null,
      "Arguments": null,
      "WorkingDirectory": null
    }
  ],
  "WebBrowser": {
    "BrowserPages": {
      "Chrome": {},
      "IExplore": {},
      "Firefox": {}
    }
  }
}
```

## Manifest components

Manifest files contain the following components:

* `Name`  
The name of the environment (e.g., "myproj").

* `Description`  
The description of the environment (e.g., "My project environment").

* `BackupEnabled`  
Determines if the data backup functionality is *enabled* ("true"), or *disabled* ("false").

* `BackupSources`  
Absolute paths to data that will be backed up, if the data backup functionality is enabled.  

* `BackupLocation`  
The absolute path where backups are created.

* `EnvironmentApplication`  
Each application that will be launched by **dvn** has it's own block with the following data:

  * `Name`  
  The name of the application

  * `Description`  
  Description of the application

  * `FileName`  
  The application file name

  * `Arguments`  
  Any command-line arguments

  * `WorkingDirectory`  
  The application working directory

* `WebBrowser`  
A list of webpages to be opened in specific web browsers

A completed manifest file looks like this:

```json
{
  "DevelopmentEnvironment": {
    "Name": "myproj",
    "Description": "My project environment",
    "BackupEnabled": true,
    "BackupSources": [
      "C:\\repositories\\MyProject",
      "C:\\data\\reports"
    ],
    "BackupLocation": "C:\\backups",
  },
  "EnvironmentApplications": [
    {
      "Name": "Visual Studio - MyProject",
      "Description": "MyProject solution",
      "FileName": "MyProject.sln",
      "Arguments": null,
      "WorkingDirectory": "C:\\repositories\\MyProject\\src"
    },
    {
    "Name": "Visual Studio Code - MyProject documentation",
    "Description": "MyProject documentation",
    "FileName": "Code.exe",
    "Arguments": "MyProject-documentation.code-workspace | exit /b",
    "WorkingDirectory": "\\path\\to\\VisualStudioCode"
    },
    {
    "Name": "Visual Studio Code - Other documentation",
    "Description": "Other documentation",
    "FileName": "Code.exe",
    "Arguments": "Other-documentation.code-workspace | exit /b",
    "WorkingDirectory": "\\path\\to\\VisualStudioCode"
    },
    {
      "Name": "GitHub Desktop",
      "Description": "GitHub Desktop",
      "FileName": "GitHubDesktop.exe",
      "Arguments": null,
      "WorkingDirectory": "C:\\Users\\JaneSmith\\AppData\\Local\\GitHubDesktop"
    }
  ],
  "WebBrowser":
  {
    "BrowserPages":
    {
	  "Chrome":
      {
        "Wikipedia": "https://www.google.com",
        "Weather.com": "https://www.weather.com"
      },
	  "Firefox":
      {
	      "Firefox": "https://www.firefox.com",
        "Wikipedia": "https://www.wikipedia.com"
      },
      "IExplore":
      {
        "Microsoft": "https://www.microsoft.com",
		    "Xbox": "https://xbox.com"
      }
    }
  }
}
```

> **REMINDER!**  
> Any `\` characters need to be escaped as `\\`!

The above manifest file will:

1. Start the "**myproj**" development environment
2. Backup the "**C:\repositories\MyProject**" and "**C:\data\reports**" to "**C:\backups**"
3. Start the "**MyProject**" solution in Visual Studio
4. Start the "**MyProject-Documentation**" workspace in Visual Studio Code
5. Start the "**Other-Documentation**" workspace in Visual Studio Code
6. Start the "**GitHub Desktop**" application
7. Open various web pages in various web browsers


## USAGE

### Creating the dvn framework

The **dvn framework** is comprised of the files and folders that are required by **dvn**. This framework doesn't exist yet, so we need to create it.

To create the **dvn** framework:

1. Open a terminal in the the folder that contains `dvn.exe`
2. Type

```bash
dvn
```

Since this is the first time you are executing **dvn**, you will see a message letting you know that the **dvn framework** will be created.





























### The dvn syntax

This is the **dvn** syntax:

```bash
dvn <command> [-option01 -option02 ...]
```

## Commands

**dvn** *requires* that you pass a valid `command`.

In general, you'll use the `%environment%` command, which will start the specified development environment (or create a blank [manifest file](), if one doesn't exist).

For example, to start/create the `myproj` environment, you would type

```bash
dvn myproj
```

To get a list of valid commands, type

```bash
dvn help
```

## Options

**dvn** also accepts `options`, which are...optional

Options:

* Must be a single character
* Start with the `-` (dash) character
* Are separated by a space

For example, you can force the data for the `myproj` environment to be backed up by typing

```bash
dvn myproj -b
```

To get a list of valid options, type

```bash
dvn help
```

## Documentation

Coming soon.

## License

Distributed under the [Apache 2.0 License](LICENSE).  
Copyright &copy; 2026 [A Pretty Cool Program](https://github.com/APrettyCoolProgram)

---

<h6 align="center">

  [FAQ](docs/FAQ.md)&nbsp;&bull;&nbsp;[DEVELOPMENT](docs/DEVELOPMENT.md)&nbsp;&bull;&nbsp;[API](docs/api/README.md)&nbsp;&bull;&nbsp;[TESTING](docs/TESTING.md)&nbsp;&bull;&nbsp;[SUPPORT](docs/SUPPORT.md)&nbsp;&bull;&nbsp;[NOTICES](docs/NOTICES.md)
  
</h6>

---

<sub>Last updated: 260417</sub>
