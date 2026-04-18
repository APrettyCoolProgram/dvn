# Testing dvn v1.0

## The dvn framework

### Files
```text
.\.dvn\configs\dvn.config
```

### Folders

```text
.\apps
.\apps\win
.\.dvn
.\.dvn\backups
.\.dvn\configs
.\.dvn\manifests
.\.dvn\staging
.\.dvn\temporary
.\.dvn\trash
.\data
.\data\repositories
```

## Setup

- [x] Copy `dvn.exe` to a test location
- [x] Open a terminal window at that location
- [x] Confirm that the only file at that location is `dvn.exe`

## Testing `dvn`

### 01: Framework creation

- [x] Confirm the dvn framework does not exist
- [x] Type `dvn` at the command line
- [x] Verify the "Welcome to dvn" message is displayed
- [x] Verify dvn exits gracefully
- [x] Verify the dvn framework was created

### 02: Message display

- [x] Type `dvn`
- [x] Verify the "Missing arguments" message is displayed
- [x] Verify dvn exits gracefully

## Testing `dvn about`

### 01: Framework creation

- [x] Confirm the dvn framework does not exist
- [x] Type `dvn about` at the command line
- [x] Verify the "Welcome to dvn" message is displayed
- [x] Verify dvn exits gracefully
- [x] Verify the dvn framework was created

### 02: Message display

- [x] Type `dvn about`
- [x] Verify the "About dvn" message is displayed
- [x] Verify dvn exits gracefully

## Testing `dvn help`

### 01: Framework creation

- [x] Confirm the dvn framework does not exist
- [x] Type `dvn help` at the command line
- [x] Verify the "Welcome to dvn" message is displayed
- [x] Verify dvn exits gracefully
- [x] Verify the dvn framework was created

### 02: Message display

- [x] Type `dvn help`
- [x] Verify the "Help" message is displayed
- [x] Verify dvn exits gracefully

## Testing `dvn list`

### 01: Framework creation

- [x] Confirm the dvn framework does not exist
- [x] Type `dvn list` at the command line
- [x] Verify the "Welcome to dvn" message is displayed
- [x] Verify dvn exits gracefully
- [x] Verify the dvn framework was created

### 02: Message display

- [x] Type `dvn list`
- [x] Verify the "No environments found" message is displayed
- [x] Verify dvn exits gracefully

## Testing `dvn %environment-name%`

### Framework creation

### 01: Framework creation

- [x] Confirm the dvn framework does not exist
- [x] Type `dvn test` at the command line
- [x] Verify the "Welcome to dvn" message is displayed
- [x] Verify dvn exits gracefully
- [x] Verify the dvn framework was created

### 02: Message display

- [x] Type `dvn test`
- [x] Verify the "Manifest doesn't exist" message is displayed
- [x] Verify dvn exits gracefully
- [x] Verify that `.\.dvn\manifests\test.dvn.manifest` exists

### 03: Empty manifest

- [x] Open the `.\.dvn\manifests\test.dvn.manifest` file
- [x] Change the "EnvironmentDescription" value to `Testing environment`
- [x] Save the manifest file
- [x] Type: `dvn test`
- [x] Verify that "Launching environment: Testing environment" is displayed
- [x] Verify that "Backup is disabled" is displayed
- [x] Verify that "There aren't any applications defined" is displayed
- [x] Verify dvn exits gracefully

### 04: Application launch

- [ ] Open the `.\.dvn\manifests\test.dvn.manifest` file
- [ ] Change the "ManifestApplications" value from:

```json
"EnvironmentApplications": [
  {
      "Name": null,
      "Description": null,
      "FileName": null,
      "Arguments": null,
      "WorkingDirectory": null
  }
]
```

to

```json
"EnvironmentApplications": [
  {
      "Name": "GitHub Desktop",
      "Description": "GitHub Desktop",
      "FileName": "GitHubDesktop.exe",
      "Arguments": null,
      "WorkingDirectory": "C:\\Users\\%username%\\AppData\\Local\\GitHubDesktop"
  },
]
```

- [x] Save the manifest file
- [x] Type: `dvn test`
- [x] Verify that "Launching environment: Testing environment" is displayed
- [x] Verify that "Backup is disabled" is displayed
- [x] Verify that the GitHub Desktop application launches
- [x] Verify dvn exits gracefully

### 05: Backup data via the manifest

- [x] Open the `.\.dvn\manifests\test.dvn.manifest` file
- [x] Change the "BackupEnabled" value to `true`
- [x] Change the "BackupSources" value from

```json
  "BackupSources": [
    "\\Path\\To\\Source1",
    "\\Path\\To\\Source2"
  ],
```

to

```json
  "BackupSources": [
    "C:\\Users\\%username%\\GitHub\\one"
    "C:\\Users\\%username%\\GitHub\\two"
    "C:\\Users\\%username%\\GitHub\\three"
  ],
```

> NOTE: It's important to specify at least 2-3 BackupSources, so we can verify that the compressed files are different.

- [x] Change the "BackupSources" value to `"C:\\Users\\%username\\Backup"`
- [x] Save the manifest file
- [x] Type: `dvn test`
- [x] Verify that "Launching environment: testing" is displayed
- [x] Verify that the "Backing up %subDirectory%" message is displayed for each BackupSource
- [x] Verify that the GitHub Desktop application launches
- [x] Verify dvn exits gracefully
- [x] Verify that the three archived files in `"C:\\Users\\%username\\Backup"` have the correct timestamp and data.

### 06: Backup data via command line option

- [x] Open the `.\.dvn\manifests\test.dvn.manifest` file
- [x] Change the "BackupEnabled" value to `false`
- [x] Save the manifest file
- [x] Type: `dvn test`
- [x] Verify that "Launching environment: testing" is displayed
- [x] Verify that the "Backing up %subDirectory%" message is displayed for each BackupSource
- [x] Verify that the GitHub Desktop application launches
- [x] Verify dvn exits gracefully
- [x] Type: `dvn test -b`
- [x] Verify that "Launching environment: testing" is displayed
- [x] Verify that the "Backing up %subDirectory%" message is displayed for each BackupSource
- [x] Verify that the GitHub Desktop application launches
- [x] Verify dvn exits gracefully
- [x] Verify that the three archived files in `"C:\\Users\\%username\\Backup"` have the correct timestamp and data.
