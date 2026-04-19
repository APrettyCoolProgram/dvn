> Last updated April 19, 2026

# Scoop

Scoop must be installed on an NTFS-formatted drive.

## Installing Scoop

### Scoop prerequisites

> This command must be run before using dvn, in an elevated PowerShell terminal (Administrator mode).

The first command makes your device allow running the installation and management scripts. This is necessary because Windows 10 client devices restrict execution of any PowerShell scripts by default.

`Set-ExecutionPolicy -ExecutionPolicy RemoteSigned -Scope CurrentUser`

### Downloading the Scoop installer

Since we want to install Scoop to a custom location, we need to download the installer so we can run it with the appropriate parameters.

This command will download the installer to the root of the drive you want to install Scoop on (e.g. `V:\install.ps1`):

`$@"irm get.scoop.sh -outfile '{drive}:\install.ps1'"`

### Installing Scoop

> The current version of dvn does not use global installs.

Install Scoop by running the installer:

`$@"{drive}:\install.ps1 -ScoopDir '{drive}:\Scoop\' -NoProxy"`




Make sure the required buckets are added::

`scoop bucket add extras`
`scoop bucket add sysinternals`


## Installing Scoop Apps
`
* `scoop install extras/audacity`
* `scoop install extras/autohotkey`
* `scoop install extras/cpu-z`
* `scoop install extras/cryptomator`
     * suggests installing 'nonportable/winfsp-np
* `scoop install extras/crystaldiskinfo`
* `scoop install extras/crystaldiskmark`
* `scoop install dbeaver`
* `scoop install extras/discord`
* `scoop install extras/draw.io`
* `scoop install extras/etcher`
* `scoop install extras/ferdium`
* `scoop install extras/filezilla`
* `scoop install extras/firefox`
* `scoop install extras/gimp`
* `scoop install extras/gisto`
* `scoop install extras/godot-mono`
* `scoop install extras/gpu-z`
* `scoop install extras/hwinfo`
* `scoop install extras/kitty`
* `scoop install extras/love`
* `scoop install extras/notepadplusplus`
* `scoop install extras/putty`
* `scoop install extras/rufus`
* `scoop install extras/signal`
* `scoop install extras/smartgit`
* `scoop install extras/sublime-text`
* `scoop install sysinternals/sysinternals-suite`
* `scoop install extras/telegram`
* `scoop install extras/yumi-exfat`
* `scoop install extras/vlc`
* `scoop install extras/vscode`
* `scoop install extras/windirstat`
* `scoop install extras/xampp`
    * suggests installing extras/vcredist2022


