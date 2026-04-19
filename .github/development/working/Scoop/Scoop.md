> Last updated April 19, 2026

# Scoop

Scoop must be installed on an NTFS-formatted drive.

## Installing Scoop

Open PowerShell in Administrator mode, and run the following command:

The first command makes your device allow running the installation and management scripts. This is necessary because Windows 10 client devices restrict execution of any PowerShell scripts by default.

`Set-ExecutionPolicy -ExecutionPolicy RemoteSigned -Scope CurrentUser`

Since we want to install Scoop to a custom location, we need to download the installer.

This command will download the installer to the current directory (default: `Windows\system32`). You can change the path if you want to save it somewhere else.

`irm get.scoop.sh -outfile 'install.ps1'`

Next, open PowerShell in non-Administrator mode, and navigate to the directory where you downloaded the installer:

Install Scoop by running the installer:

`.\install.ps1 -ScoopDir 'V:\Scoop\Apps' -ScoopGlobalDir 'V:\Scoop\GlobalApps' -NoProxy`

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


