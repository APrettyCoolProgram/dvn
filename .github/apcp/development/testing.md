# Testing

## Setup

1. Copy `dvn.exe` to a test location
2. Open a terminal window at that location

## Testing framework setup

1. Confirm all framework components are removed prior to testing each of these commands:

* `> dvn`
* `> dvn about`
* `> dvn help`
* `> dvn list`
* `> dvn myenv`

2. Verify each of the above commands displays the welcome message, creates the dvn framework, then exits.

## Testing missing arguments

1. Confirm that all framework components exist
2. Type: `dvn`
3. Verify the "Missing arugments" message is displayed
4. Verify dvn exits gracefully

## Testing the `about` command

1. Type: `dvn about`
2. Verify the "Missing arguments" message is displayed
3. Verify dvn exits gracefully

## Testing the `help` command

1. Type: `dvn help`
2. Verify the "Help" message is displayed, and dvn exits
3. Verify dvn exits gracefully

## Testing manifest creation

1. Type: `dvn test`
2. Verify the "Manifest doesn't exist" message is displayed, and dvn exits
3. Verify the `.\.dvn\manifests\test.dvn.manifest` exists
4. Verify dvn exits gracefully

## Testing load empty manifest

1. Open the `.\.dvn\manifests\test.dvn.manifest` file
2. Change the "EnvironmentDescription" value to `Testing environment`
3. Save the manifest file
4. Type: `dvn test`
5. Verify that "Launching environment: Testing environment" is displayed
6. Verify that "Backup is disabled" is displayed
7. Verify that "There aren't any applications defined" is displayed
8. Verify dvn exits gracefully

## Testing load manifest with application

1. Open the `.\.dvn\manifests\test.dvn.manifest` file
2. Change the "ManifestApplications" value from:

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
    "WorkingDirectory": "C:\\Users\\Chris.Banwarth\\AppData\\Local\\GitHubDesktop"
},
```

3. Save the manifest file
4. Type: `dvn test`
5. Verify that "Launching environment: Testing environment" is displayed
6. Verify that "Backup is disabled" is displayed
7. Verify that the GitHub Desktop application launches
8. Verify dvn exits gracefully

## Testing data backup functionality

1. Open the `.\.dvn\manifests\test.dvn.manifest` file
2. Change the "BackupEnabled" value to `true`
3. Change the "BackupSources" value from

```json
  "BackupSources": [
    "\\Path\\To\\Source1",
    "\\Path\\To\\Source2"
  ],
```

to

```json
  "BackupSources": [
    "C:\\Users\\%username%\\GitHub\\dvn"
  ],
```

4. Change the "BackupSources" value to `"C:\\Users\\%username\\Backup"`
5. Save the manifest file
6. Type: `dvn test`
7. Verify that "Launching environment: testing" is displayed
8. Verify that "Backup is disabled" is displayed
9. Verify that the GitHub Desktop application launches
10. Verify dvn exits gracefully