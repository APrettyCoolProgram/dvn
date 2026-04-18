<div align="center">

  <h1>Repository: Development Notes</h1>

</div>

#### CONTENTS

* [Notes](#notes)
* [Roadmap](#roadmap)
* [Known Issues](#known-issues)
* [Version History](#version-history)

***

# Notes

# dvn Changelog

## 1.2.0





***

<sub>Last updated: 260417</sub>

* `NEW` The **Install** command
* `NEW` The **Request** command










<!-- u250815 -->

<div align="center">

  ![](/.github/readme-resource/dvn-changelog-306x407.png)

</div>

# Version 1.2


<!-- In development
* `NEW` The ability to install applications using the `install` command

* `MODIFIED` Both `help` and `list` are now `Options`, and are more robust
-->

<!--
<details>
  <summary>Development notes</summary>
-->

<br>

> Version 1.2 makes a few  major changes to **dvn**, including:  
> ⤇ The **Install** command  
> ⤇ The **Request** command-line component  
> ⤇ How the command-line components are set  
> ⤇ A rework of the **Help** and **List** functionality

The **Install** command
* The ***install*** command allows a small list of applications to be installed.
* Added `Core.Installer.cs` to handle the new install command functionality
* Added the install command to Arguments.ParseCommand()
* Added [AutoHotKey]() as an installable application

The **Request** command-line component
* The install command makes it necessary to have an additional non-command, non-option component to the command-line parameters, so the ***Request*** command-line component was created.

Optional **Options**
* The **help** and **list** commands are depreciated, and their functionality is now included in the ***Options*** functionality
* Both options covers more stuff, so they broken down into separate components
* Added `Core.HelpInformer.cs` and `Core.Lister.cs` to handle the new functionality

Modifications to how the command-line components are set
* The contents of Core.CommandLine.cs have been moved to Core.Argument.cs
* The way the command-line components are set is significantly more complex

Other changes
* Renamed the `App` namespace => `Core`, to match other APCP projects
* Data backup functionality moved to `Core` namespace, and renamed to `Core.Archiver.cs`
* Setup the foundations for determining Operating System, which is disabled for now
* Code refactors and comment cleanup

<!--
</details>
-->

<br>

***

# Version 1.1

* `NEW` Web pages can now be opened with Chrome, Firefox, and Edge

<details>
  <summary>Development notes</summary>

* The default template is now created with null values, instead of examples
* Created the dvn.Manifest namespace, and moved associated files
* Renamed some of the framework directories to keep paths short
* Renamed a few methods so their names were more descriptive
* Removed some of the .New() methods, since the default template is created with null values
* Code/comment cleanup/refactoring

</details>

<br>

***

# Version 1.0

No notes, sorry!



***

# Roadmap

***

# Known Issues

***

# Version History

***

<br>

<sub>Last updated: 260416</sub>
