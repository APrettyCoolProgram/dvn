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

1. Copy `dvn.exe` to a test location
2. Open a terminal window at that location
3. Confirm that the only file at that location is `dvn.exe`

## Testing `dvn`

### 01: Framework creation

1. Confirm the dvn framework does not exist
2. Type `dvn` at the command line
3. Verify the "Welcome to dvn" message is displayed
4. Verify dvn exits gracefully
5. Verify the dvn framework was created

### 02: Message display

6. Type `dvn`
7. Verify the "Missing arguments" message is displayed
8. Verify dvn exits gracefully

## Testing `dvn about`

### 01: Framework creation

-[X] Confirm the dvn framework does not exist
2. Type `dvn about` at the command line
3. Verify the "Welcome to dvn" message is displayed
4. Verify dvn exits gracefully
5. Verify the dvn framework was created

### 02: Message display

6. Type `dvn about`
7. Verify the "About dvn" message is displayed
8. Verify dvn exits gracefully

## Testing `dvn help`

### 01: Framework creation

1. Confirm the dvn framework does not exist
2. Type `dvn help` at the command line
3. Verify the "Welcome to dvn" message is displayed
4. Verify dvn exits gracefully
5. Verify the dvn framework was created

### 02: Message display

6. Type `dvn help`
7. Verify the "Help" message is displayed
8. Verify dvn exits gracefully

## Testing `dvn list`

### 01: Framework creation

1. Confirm the dvn framework does not exist
2. Type `dvn list` at the command line
3. Verify the "Welcome to dvn" message is displayed
4. Verify dvn exits gracefully
5. Verify the dvn framework was created

### 02: Message display

6. Type `dvn list`
7. Verify the "No environments found" message is displayed
8. Verify dvn exits gracefully

## Testing `dvn %environment-name%`

### Framework creation

### 01: Framework creation

1. Confirm the dvn framework does not exist
2. Type `dvn test` at the command line
3. Verify the "Welcome to dvn" message is displayed
4. Verify dvn exits gracefully
5. Verify the dvn framework was created

### 02: Message display

6. Type `dvn test`
7. Verify the "Manifest doesn't exist" message is displayed
8. Verify dvn exits gracefully
9. Verify that `.\.dvn\manifests\test.dvn.manifest` exists

### 03: Empty manifest

10. Open the `.\.dvn\manifests\test.dvn.manifest` file
11. Change the "EnvironmentDescription" value to `Testing environment`
12. Save the manifest file
13. Type: `dvn test`
14. Verify that "Launching environment: Testing environment" is displayed
15. Verify that "Backup is disabled" is displayed
16. Verify that "There aren't any applications defined" is displayed
17. Verify dvn exits gracefully

### 04: Application launch

18. Open the `.\.dvn\manifests\test.dvn.manifest` file
19. Change the "ManifestApplications" value from:

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

20. Save the manifest file
21. Type: `dvn test`
22. Verify that "Launching environment: Testing environment" is displayed
23. Verify that "Backup is disabled" is displayed
24. Verify that the GitHub Desktop application launches
25. Verify dvn exits gracefully

### 05: Backup data via the manifest

26. Open the `.\.dvn\manifests\test.dvn.manifest` file
27. Change the "BackupEnabled" value to `true`
28. Change the "BackupSources" value from

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

29. Change the "BackupSources" value to `"C:\\Users\\%username\\Backup"`
30. Save the manifest file
31. Type: `dvn test`
32. Verify that "Launching environment: testing" is displayed
33. Verify that "Backup is enabled" is displayed
34. Verify that the "Backing up %subDirectory%" message is displayed
35. Verify that the GitHub Desktop application launches
36. Verify dvn exits gracefully
37. Verify that the three archived files in `"C:\\Users\\%username\\Backup"` have the correct timestamp and data.

### 06: Backup data via command line option

38. Open the `.\.dvn\manifests\test.dvn.manifest` file
39. Change the "BackupEnabled" value to `false`
40. Save the manifest file
41. Type: `dvn test`
42. Verify that "Launching environment: testing" is displayed
43. Verify that "Backup is disabled" is displayed
44. Verify that the GitHub Desktop application launches
45. Verify dvn exits gracefully
46. Type: `dvn test -b`
47. Verify that "Launching environment: testing" is displayed
48. Verify that "Backup is enabled" is displayed
49. Verify that the "Backing up %subDirectory%" message is displayed
50. Verify that the GitHub Desktop application launches
51. Verify dvn exits gracefully
52. Verify that the three archived files in `"C:\\Users\\%username\\Backup"` have the correct timestamp and data.
