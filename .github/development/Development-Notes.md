<div align="center">

  <h1>dvn: Development - Notes</h1>

</div>

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

* The default template is now created with null values, instead of examples
* Created the dvn.Manifest namespace, and moved associated files
* Renamed some of the framework directories to keep paths short
* Renamed a few methods so their names were more descriptive
* Removed some of the .New() methods, since the default template is created with null values
* Code/comment cleanup/refactoring

***

<br>

<sub>Last updated: 260416</sub>
