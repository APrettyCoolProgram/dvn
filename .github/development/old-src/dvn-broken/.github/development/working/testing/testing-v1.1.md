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

- [x] Copy `dvn.exe` to a test location
- [x] Open a terminal window at that location
- [x] Confirm that the only file at that location is `dvn.exe`

## 01: Testing the framework creation

- [x] Confirm the dvn framework does not exist
- [x] Type `dvn` at the command line
- [x] Verify the "Welcome to dvn" message is displayed
- [x] Verify dvn exits gracefully
- [x] Verify the dvn framework was created
- [x] Type `dvn`
- [x] Verify the "Missing arguments" message is displayed
- [x] Verify dvn exits gracefully

## 02: Testing standard commands

### `about`

- [x] Confirm the dvn framework does not exist
- [x] Type `dvn about` at the command line
- [x] Verify the "Welcome to dvn" message is displayed
- [x] Verify dvn exits gracefully
- [x] Verify the dvn framework was created
- [x] Type `dvn about`
- [x] Verify the "About dvn" message is displayed
- [x] Verify dvn exits gracefully

### `help`

- [x] Confirm the dvn framework does not exist
- [x] Type `dvn help` at the command line
- [x] Verify the "Welcome to dvn" message is displayed
- [x] Verify dvn exits gracefully
- [x] Verify the dvn framework was created
- [x] Type `dvn help`
- [x] Verify the "Help" message is displayed
- [x] Verify dvn exits gracefully

### `list`

- [x] Confirm the dvn framework does not exist
- [x] Type `dvn list` at the command line
- [x] Verify the "Welcome to dvn" message is displayed
- [x] Verify dvn exits gracefully
- [x] Verify the dvn framework was created
- [x] Type `dvn list`
- [x] Verify the "No environments found" message is displayed
- [x] Verify dvn exits gracefully

## 03: Environments

- [x] Confirm the dvn framework does not exist
- [x] Type `dvn test` at the command line
- [x] Verify the "Welcome to dvn" message is displayed
- [x] Verify dvn exits gracefully
- [x] Verify the dvn framework was created
- [x] Type `dvn test`
- [x] Verify the "Manifest doesn't exist" message is displayed
- [x] Verify dvn exits gracefully
- [x] Verify that `.\.dvn\manifests\test.dvn.manifest` exists
- [x] Open the `.\.dvn\manifests\test.dvn.manifest` file
- [x] Change the "EnvironmentDescription" value to `Testing environment`
- [x] Save the manifest file
- [x] Type: `dvn test`
- [x] Verify that "Launching environment: Testing environment" is displayed
- [x] Verify that "Backup is disabled" is displayed
- [x] Verify that "There aren't any applications defined" is displayed
- [x] Verify that "No pages found" is displayed for both IExplore and Firefox
- [x] Verify dvn exits gracefully

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

- [x] Save the manifest file
- [x] Type: `dvn test`
- [x] Verify that "Launching environment: Testing environment" is displayed
- [x] Verify that "Backup is disabled" is displayed
- [x] Verify that the GitHub Desktop application launches
- [x] Verify dvn exits gracefully

## 05: Data backup

### Via manifest

- [x] Open the `.\.dvn\manifests\test.dvn.manifest` file
- [x] Change the "BackupEnabled" value to `true`
- [x] Change the "BackupSources" value from

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

- [x] Change the "BackupLocation" value to `"C:\\Users\\%username\\Backup"`
- [x] Save the manifest file
- [x] Type: `dvn test`
- [x] Verify that "Launching environment: testing" is displayed
- [x] Verify that "Backup is enabled" is displayed
- [x] Verify that the "Backing up %subDirectory%" message is displayed
- [x] Verify that the GitHub Desktop application launches
- [x] Verify dvn exits gracefully
- [x] Verify that the three archived files in `"C:\\Users\\%username\\Backup"` have the correct timestamp and data.

### Via command line

- [x] Open the `.\.dvn\manifests\test.dvn.manifest` file
- [x] Change the "BackupEnabled" value to `false`
- [x] Save the manifest file
- [x] Type: `dvn test`
- [x] Verify that "Launching environment: testing" is displayed
- [x] Verify that "Backup is disabled" is displayed
- [x] Verify that the GitHub Desktop application launches
- [x] Verify dvn exits gracefully
- [x] Type: `dvn test -b`
- [x] Verify that "Launching environment: testing" is displayed
- [x] Verify that "Backup is enabled" is displayed
- [x] Verify that the "Backing up %subDirectory%" message is displayed
- [x] Verify that the GitHub Desktop application launches
- [x] Verify dvn exits gracefully
- [x] Verify that the three archived files in `"C:\\Users\\%username\\Backup"` have the correct timestamp and data.

## 06: Web Browser pages

### Some browsers

- [x] Open the `.\.dvn\manifests\test.dvn.manifest` file
- [x] Change the "WebBrowser" value from

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

- [x] Verify that "Launching environment: testing" is displayed
- [x] Verify that "Backup is disabled" is displayed
- [x] Verify that the GitHub Desktop application launches
- [x] Verify that the "No pages found for Chrome" is displayed
- [x] Verify that the "Opening pages in browser" is displayed for both Firefox and IExplore
- [x] Verify the pages open in both Firefox and IExplore
- [x] Verify dvn exits gracefully

### All browsers

- [x] Open the `.\.dvn\manifests\test.dvn.manifest` file
- [x] Change the Chrome component of the "WebBrowser" value from

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

- [x] Verify that "Launching environment: testing" is displayed
- [x] Verify that "Backup is disabled" is displayed
- [x] Verify that the GitHub Desktop application launches
- [x] Verify that the "Opening pages in browser" is displayed for all browsers
- [x] Verify the pages open in all browsers
- [x] Verify dvn exits gracefully
