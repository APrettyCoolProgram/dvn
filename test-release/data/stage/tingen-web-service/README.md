<!-- u250611 -->

<div align="center">

  ![logo](/.github/image/logo/tngnsrvc-320x568.png)

  ![Release](https://img.shields.io/badge/release-25.7-teal)&nbsp;&nbsp;
  ![License](https://img.shields.io/badge/license-apache-blue)

</div>

# The Tingen Web Service

[Netsmart's Avatar™](https://www.ntst.com/Solutions-and-Services/Offerings/myAvatar) is a behavioral health EHR that offers a recovery-focused suite of solutions that leverage real-time analytics and clinical decision support to drive value-based care.

While Avatar™ is a robust platform, it isn't perfect. The good news is that you can extend myAvatar™ functionality via Netsmart's Avatar™ Web Services, and/or custom web services that are written by other Avatar™ users.

**Tingen** is one such custom web service which includes various tools and utilities for Avatar™ that aren't included in the official release, and provides a solid foundation for building additional functionality quickly and efficiently.

## Tingen features

* Several built-in tools and utilities that extend the functionality of Avatar™
* A solid foundation to build additional Avatar™ custom tools and utilities
* Extremely customizable
* Robust logging
* ...and [more](https://github.com/spectrum-health-systems/Tingen-Documentation/blob/main/static/tngnwsvc/features.md)!

# Tingen development

The Tingen web service is actually *two* components:

<div align="center">
		<table>
		<tr>
			<td>
				<img src="https://github.com/spectrum-health-systems/tingen-web-service/raw/development/.github/image/logo/tngnsrvc-228x278.png"></a>
			</td>
      <td>
				<a HREF="https://github.com/spectrum-health-systems/outpost31"><img src="https://github.com/spectrum-health-systems/outpost31/blob/main/.github/image/logo/o31-194x254.png"></a>
			</td>
		</tr>
    <tr>
			<td align="center">
				The Tingen <b>front end</b>
			</td>
      <td align="center">
				The Tingen <b>back end</b>
			</td>
		</tr>
	</table>
</div>

And they work like this:

```mermaid
flowchart RL
  subgraph TingenWebService["The Tingen Web Service"]
    direction LR
    %% Components
    Tingen(Tingen)
    Outpost31(Outpost31) 
  end
  %% Layout
  Avatar(Avatar) -- Request --> Tingen --> Outpost31 -- Reply --> Avatar
  %% Styles
  style Avatar color:#000000,fill:#1b8eb7,stroke:#FFFFFF,stroke-width:2px
  style Tingen color:#000000,fill:#ff9800,stroke:#4caf50,stroke-width:3px
  style Outpost31 color:#000000,fill:#ff9800,stroke:#4caf50,stroke-width:3px
```

# Tingen releases

There are three types of Tingen Web Service releases:

## 1. Development

> **Development releases may be broken and not fully tested, and *should not be used in production environments.***

Tingen Web Service development uses:

* The Tingen Web Service [development branch](https://github.com/spectrum-health-systems/tingen-web-service/tree/development)
* The Outpost31 [development branch](https://github.com/spectrum-health-systems/outpost31/tree/development)

## 2. Stable

> **Using stable releases in production environments *is not recommended.***

Once the development version of the Tingen Web Service has been tested and verified to be **stable**, they are merged with:

* The Tingen Web Service [main branch](https://github.com/spectrum-health-systems/tingen-web-service) **&lArr; YOU ARE HERE**
* The Outpost31 [main branch](https://github.com/spectrum-health-systems/outpost31)

## 3. Community

> **Community releases are intended for use in production environments.**

Once a stable release has been in production at Spectrum Health Systems for a few months, it is released as a Tingen Web Service **Community Release**.

<div align="center">
	<table>
		<tr>
			<td>
				<a HREF="https://github.com/spectrum-health-systems/Tingen-CommunityRelease"><img src="https://github.com/spectrum-health-systems/Tingen-CommunityRelease/blob/main/.github/image/logo/TingenCommunityRelease_logo_194x254.png"></a>
			</td>
		</tr>
	</table>
</div>

# Documentation

There's a *ton* of [documentation](https://github.com/spectrum-health-systems/tingen-documentation) for the Tingen Web Service (and other Tingen projects), such as:

* The [Tingen Web Service manual](https://github.com/spectrum-health-systems/tingen-documentation/tree/main/manuals/tngnsrvc)
* API documentation for the [Tingen Web Service](https://spectrum-health-systems.github.io/tingen-documentation/api/shfb-tingen-web-service/) and [Outpost31](https://spectrum-health-systems.github.io/tingen-documentation/api/shfb-outpost31/)
* The Tingen Web Service [CHANGELOG](CHANGELOG.md) and [ROADMAP](ROADMAP.md)
