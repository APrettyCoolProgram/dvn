# Testing dvn vX.x

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

- [ ] Copy `dvn.exe` to a test location
- [ ] Open a terminal window at that location
- [ ] Confirm that the only file at that location is `dvn.exe`

## Testing `dvn`

### 01: Framework creation

- [ ] Confirm the dvn framework does not exist
- [ ] Type `dvn` at the command line
- [ ] Verify the "Welcome to dvn" message is displayed
- [ ] Verify dvn exits gracefully
- [ ] Verify the dvn framework was created

### 02: Message display

- [ ] Type `dvn`
- [ ] Verify the "Missing arguments" message is displayed
- [ ] Verify dvn exits gracefully

## Testing `dvn about`

### 01: Framework creation

- [ ] Confirm the dvn framework does not exist
- [ ] Type `dvn about` at the command line
- [ ] Verify the "Welcome to dvn" message is displayed
- [ ] Verify dvn exits gracefully
- [ ] Verify the dvn framework was created

### 02: Message display

- [ ] Type `dvn about`
- [ ] Verify the "About dvn" message is displayed
- [ ] Verify dvn exits gracefully

## Testing `dvn help`

### 01: Framework creation

- [ ] Confirm the dvn framework does not exist
- [ ] Type `dvn help` at the command line
- [ ] Verify the "Welcome to dvn" message is displayed
- [ ] Verify dvn exits gracefully
- [ ] Verify the dvn framework was created

### 02: Message display

- [ ] Type `dvn help`
- [ ] Verify the "Help" message is displayed
- [ ] Verify dvn exits gracefully

## Testing `dvn list`

### 01: Framework creation

- [ ] Confirm the dvn framework does not exist
- [ ] Type `dvn list` at the command line
- [ ] Verify the "Welcome to dvn" message is displayed
- [ ] Verify dvn exits gracefully
- [ ] Verify the dvn framework was created

### 02: Message display

- [ ] Type `dvn list`
- [ ] Verify the "No environments found" message is displayed
- [ ] Verify dvn exits gracefully

## Testing `dvn %environment-name%`

### Framework creation

### 01: Framework creation

- [ ] Confirm the dvn framework does not exist
- [ ] Type `dvn test` at the command line
- [ ] Verify the "Welcome to dvn" message is displayed
- [ ] Verify dvn exits gracefully
- [ ] Verify the dvn framework was created

### 02: Message display

- [ ] Type `dvn test`
- [ ] Verify the "Manifest doesn't exist" message is displayed
- [ ] Verify dvn exits gracefully
- [ ] Verify that `.\.dvn\manifests\test.dvn.manifest` exists

### 03: Empty manifest

- [ ] Open the `.\.dvn\manifests\test.dvn.manifest` file
- [ ] Change the "EnvironmentDescription" value to `Testing environment`
- [ ] Save the manifest file
- [ ] Type: `dvn test`
- [ ] Verify that "Launching environment: Testing environment" is displayed
- [ ] Verify that "Backup is disabled" is displayed
- [ ] Verify that "There aren't any applications defined" is displayed
- [ ] Verify dvn exits gracefully

### 04: Application launch

- [ ] Open the `.\.dvn\manifests\test.dvn.manifest` file
- [ ] Change the "ManifestApplications" value from:

```json
"ManifestApplications": [
{
    "Name": null,
    "Description": null,
    "FileName": null,
    "Arguments": null,
    "WorkingDirectory": null
}
```

to

```json
{
    "Name": "GitHub Desktop",
    "Description": "GitHub Desktop",
    "FileName": "GitHubDesktop.exe",
    "Arguments": null,
    "WorkingDirectory": "C:\\Users\\%username%\\AppData\\Local\\GitHubDesktop"
},
```

- [ ] Save the manifest file
- [ ] Type: `dvn test`
- [ ] Verify that "Launching environment: Testing environment" is displayed
- [ ] Verify that "Backup is disabled" is displayed
- [ ] Verify that the GitHub Desktop application launches
- [ ] Verify dvn exits gracefully

### 05: Backup data via the manifest

- [ ] Open the `.\.dvn\manifests\test.dvn.manifest` file
- [ ] Change the "BackupEnabled" value to `true`
- [ ] Change the "BackupSources" value from

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

- [ ] Change the "BackupSources" value to `"C:\\Users\\%username\\Backup"`
- [ ] Save the manifest file
- [ ] Type: `dvn test`
- [ ] Verify that "Launching environment: testing" is displayed
- [ ] Verify that "Backup is enabled" is displayed
- [ ] Verify that the "Backing up %subDirectory%" message is displayed
- [ ] Verify that the GitHub Desktop application launches
- [ ] Verify dvn exits gracefully
- [ ] Verify that the three archived files in `"C:\\Users\\%username\\Backup"` have the correct timestamp and data.

### 06: Backup data via command line option

- [ ] Open the `.\.dvn\manifests\test.dvn.manifest` file
- [ ] Change the "BackupEnabled" value to `false`
- [ ] Save the manifest file
- [ ] Type: `dvn test`
- [ ] Verify that "Launching environment: testing" is displayed
- [ ] Verify that "Backup is disabled" is displayed
- [ ] Verify that the GitHub Desktop application launches
- [ ] Verify dvn exits gracefully
- [ ] Type: `dvn test -b`
- [ ] Verify that "Launching environment: testing" is displayed
- [ ] Verify that "Backup is enabled" is displayed
- [ ] Verify that the "Backing up %subDirectory%" message is displayed
- [ ] Verify that the GitHub Desktop application launches
- [ ] Verify dvn exits gracefully
- [ ] Verify that the three archived files in `"C:\\Users\\%username\\Backup"` have the correct timestamp and data.
