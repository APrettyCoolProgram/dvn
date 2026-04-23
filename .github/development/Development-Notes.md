<div align="center">

  <h1>dvn: Development - Notes</h1>

</div>

## Notes from v2.0




## Notes from v1.2

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

## Error codes

### Used

66210 - Missing command

### Available

97415 80386 52335 93889 06784 16341 21547 00466 21863 32642 25331 23123 51546 57167 44410 02844 78239 50283 30238 38626 52401 11952 79948 29018 39342 00523 56948 20823 82802 73315 62862 46322 80175 03398 49508 92525 55950 82129 27532

***

<br>

<sub>Last updated: 260416</sub>
