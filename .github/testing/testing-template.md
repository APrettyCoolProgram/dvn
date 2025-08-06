# Testing dvn vX.x

## The dvn framework

### Files
```text
.\.dvn\cnfg\dvn.config
```

### Folders

```text
.\apps
.\apps\win
.\.dvn
.\.dvn\bckp
.\.dvn\cnfg
.\.dvn\mnfst
.\.dvn\stg
.\.dvn\tmp
.\.dvn\trsh
.\data
.\data\repo
```

## Setup

- [] Copy `dvn.exe` to a test location
- [] Open a terminal window at that location
- [] Confirm that the only file at that location is `dvn.exe`

## 01: Testing the framework creation

- [] Confirm the dvn framework does not exist
- [] Type `dvn` at the command line
- [] Verify the "Welcome to dvn" message is displayed
- [] Verify dvn exits gracefully
- [] Verify the dvn framework was created
- [] Type `dvn`
- [] Verify the "Missing arguments" message is displayed
- [] Verify dvn exits gracefully

## 02: Testing standard commands

### `about`

- [] Confirm the dvn framework does not exist
- [] Type `dvn about` at the command line
- [] Verify the "Welcome to dvn" message is displayed
- [] Verify dvn exits gracefully
- [] Verify the dvn framework was created
- [] Type `dvn about`
- [] Verify the "About dvn" message is displayed
- [] Verify dvn exits gracefully

### `help`

- [] Confirm the dvn framework does not exist
- [] Type `dvn help` at the command line
- [] Verify the "Welcome to dvn" message is displayed
- [] Verify dvn exits gracefully
- [] Verify the dvn framework was created
- [] Type `dvn help`
- [] Verify the "Help" message is displayed
- [] Verify dvn exits gracefully

### `list`

- [] Confirm the dvn framework does not exist
- [] Type `dvn list` at the command line
- [] Verify the "Welcome to dvn" message is displayed
- [] Verify dvn exits gracefully
- [] Verify the dvn framework was created
- [] Type `dvn list`
- [] Verify the "No environments found" message is displayed
- [] Verify dvn exits gracefully

## 03: Environments

- [] Confirm the dvn framework does not exist
- [] Type `dvn test` at the command line
- [] Verify the "Welcome to dvn" message is displayed
- [] Verify dvn exits gracefully
- [] Verify the dvn framework was created
- [] Type `dvn test`
- [] Verify the "Manifest doesn't exist" message is displayed
- [] Verify dvn exits gracefully
- [] Verify that `.\.dvn\manifests\test.dvn.manifest` exists
- [] Open the `.\.dvn\manifests\test.dvn.manifest` file
- [] Change the "EnvironmentDescription" value to `Testing environment`
- [] Save the manifest file
- [] Type: `dvn test`
- [] Verify that "Launching environment: Testing environment" is displayed
- [] Verify that "Backup is disabled" is displayed
- [] Verify that "There aren't any applications defined" is displayed
- [] Verify that "No pages found" is displayed for both IExplore and Firefox
- [] Verify dvn exits gracefully

## 04: Environment applications

- [ ] Open the `.\.dvn\manifests\test.dvn.manifest` file
- [ ] Change the "ManifestApplications" value from:

```json
  "EnvironmentApplications":
  [
    {
    "Name": null,
    "Description": null,
    "FileName": null,
    "Arguments": null,
    "WorkingDirectory": null
    }
  ],
```

to

```json
  "EnvironmentApplications":
  [
    {
    "Name": "GitHub Desktop",
    "Description": "GitHub Desktop",
    "FileName": "GitHubDesktop.exe",
    "Arguments": null,
    "WorkingDirectory": "C:\\Users\\%username%\\AppData\\Local\\GitHubDesktop"
    }
  ],
```

- [] Save the manifest file
- [] Type: `dvn test`
- [] Verify that "Launching environment: Testing environment" is displayed
- [] Verify that "Backup is disabled" is displayed
- [] Verify that the GitHub Desktop application launches
- [] Verify dvn exits gracefully

## 05: Data backup

### Via manifest

- [] Open the `.\.dvn\manifests\test.dvn.manifest` file
- [] Change the "BackupEnabled" value to `true`
- [] Change the "BackupSources" value from

```json
  "BackupSources":
  [
    "\\Path\\To\\Source1",
    "\\Path\\To\\Source2"
  ],
```

to

```json
  "BackupSources":
  [
    "C:\\Users\\%username%\\GitHub\\one"
    "C:\\Users\\%username%\\GitHub\\two"
    "C:\\Users\\%username%\\GitHub\\three"
  ],
```

> NOTE: It's important to specify at least 2-3 BackupSources, so we can verify that the compressed files are different.

- [] Change the "BackupLocation" value to `"C:\\Users\\%username\\Backup"`
- [] Save the manifest file
- [] Type: `dvn test`
- [] Verify that "Launching environment: testing" is displayed
- [] Verify that "Backup is enabled" is displayed
- [] Verify that the "Backing up %subDirectory%" message is displayed
- [] Verify that the GitHub Desktop application launches
- [] Verify dvn exits gracefully
- [] Verify that the three archived files in `"C:\\Users\\%username\\Backup"` have the correct timestamp and data.

### Via command line

- [] Open the `.\.dvn\manifests\test.dvn.manifest` file
- [] Change the "BackupEnabled" value to `false`
- [] Save the manifest file
- [] Type: `dvn test`
- [] Verify that "Launching environment: testing" is displayed
- [] Verify that "Backup is disabled" is displayed
- [] Verify that the GitHub Desktop application launches
- [] Verify dvn exits gracefully
- [] Type: `dvn test -b`
- [] Verify that "Launching environment: testing" is displayed
- [] Verify that "Backup is enabled" is displayed
- [] Verify that the "Backing up %subDirectory%" message is displayed
- [] Verify that the GitHub Desktop application launches
- [] Verify dvn exits gracefully
- [] Verify that the three archived files in `"C:\\Users\\%username\\Backup"` have the correct timestamp and data.

## 06: Web Browser pages

### Some browsers

- [] Open the `.\.dvn\manifests\test.dvn.manifest` file
- [] Change the "WebBrowser" value from

```json
  "WebBrowser":
  {
    "BrowserPages": 
    {
      "Chrome":
      {
      },
      "Firefox":
      { 
      },
      "IExplore":
      {
      },
    }
  }
```

to

```json
  "WebBrowser":
  {
    "BrowserPages":
    {
	  "Chrome":
      {
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
```

- [] Verify that "Launching environment: testing" is displayed
- [] Verify that "Backup is disabled" is displayed
- [] Verify that the GitHub Desktop application launches
- [] Verify that the "No pages found for Chrome" is displayed
- [] Verify that the "Opening pages in browser" is displayed for both Firefox and IExplore
- [] Verify the pages open in both Firefox and IExplore
- [] Verify dvn exits gracefully

### All browsers

- [] Open the `.\.dvn\manifests\test.dvn.manifest` file
- [] Change the Chrome component of the "WebBrowser" value from

```json
"Chrome":
  {
  },
```

to

```json
"Chrome":
  {
    "Wikipedia": "https://www.google.com",
    "Weather.com": "https://www.weather.com"
  },
```

- [] Verify that "Launching environment: testing" is displayed
- [] Verify that "Backup is disabled" is displayed
- [] Verify that the GitHub Desktop application launches
- [] Verify that the "Opening pages in browser" is displayed for all browsers
- [] Verify the pages open in all browsers
- [] Verify dvn exits gracefully
