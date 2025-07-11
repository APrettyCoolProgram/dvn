# dvn

**dvn** is a command-line utility that helps bring up a development environment.
















For example, let's say you are working on a project named "MyProject" that needs the following:

* A Visual Studio solution
* A Visual Studio Code workspace
* GitHub Desktop
* A browser opened to API documentation
* A specific WSL session

In addition:

* You want to backup the current development data before modifying anything
* Something else
* Something else.

When you type `dvn myproject` on the command line:

* All current data will be backed up
* Visual Studio solutions and workspaces will start
* Other applications will start
* Virtual machines will start

# Commands

* `~$ dvn`
* `~$ dvn help`  
Show the help information

* `~$ dvn list`  
List the available environments

* `~$ dvn new`  
Create a new environment template file

* `~$ dvn %environment%`  
Start the specified environment

# Template file

The `~$ dvn new` command creates a new `default.devn` file in `\AppData\`

```json
{
  "DevEnvName": "Environment Name",
  "Applications": [
    {
      "Name": "Application name",
      "Description": "Application description",
      "FileName": "filename",
      "Arguments": "-arg1 -arg2",
      "WorkingDirectory": "\\path\\to\\application"
    },
    {
      "Name": "Application name",
      "Description": "Application description",
      "FileName": "filename",
      "Arguments": "-arg1 -arg2",
      "WorkingDirectory": "\\path\\to\\application"
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
