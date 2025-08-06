[b1110]
* Added the ability to open web pages in Edge and/or Firefox
* The default template is now created with null values, instead of examples (the README.md will explain how they should be setup)
* Renamed the following (to keep path names from getting too long):
  - .\.dvn\backups => .\.dvn\bckp
  - .\.dvn\configs => .\.dvn\cnfg
  - .\.dvn\Manifests => .\.dvn\mnfst
  - .\.dvn\Staging => .\.dvn\stg
  - .\.dvn\Temporary => .\.dvn\tmp
  - .\.dvn\Trash => .\.dvn\trsh
  - .\.dvn\Repositories => .\.dvn\repo
* Removed:
  - App.Manifest.DvnEnvironment.New()
* Renamed:
  - App.Manifest.DvnManifest.CreateNew() => App.Manifest.DvnManifest.CreateDefault()

***

[b0719]
* Renamed the following:
  - DevelopmentEnvironment.cs => DvnEnvironment.cs
  - EnvironmentApplication.cs => DvnApplication.cs
  - Manifest.cs => DvnManifest.cs
* Created dvn.Manifest namespace
* Moved the following from the dvn.App namespace to the dvn.Manifest namespace:
  - DvnEnvironment.cs
  - DvnApplication.cs
  - DvnManifest.cs
* Created dvn.Manifest.DvnWebBrowser.cs