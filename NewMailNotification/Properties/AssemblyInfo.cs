﻿using System.Reflection;
using System.Runtime.InteropServices;

[assembly: AssemblyProduct("NewMailNotification")]
[assembly: AssemblyTitle("NewMailNotification")]
[assembly: AssemblyDescription("NewMailNotification")]
[assembly: AssemblyCopyright("© Yves Goergen, GNU GPL")]
[assembly: AssemblyCompany("unclassified software development")]

// Assembly identity version. Must be a dotted-numeric version.
[assembly: AssemblyVersion("1.0")]

// Repeat for Win32 file version resource because the assembly version is expanded to 4 parts.
[assembly: AssemblyFileVersion("1.0")]

// Informational version string, used for the About dialog, error reports and the setup script.
// Can be any freely formatted string containing punctuation, letters and revision codes.
[assembly: AssemblyInformationalVersion("1.0")]

#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Release")]
#endif

[assembly: ComVisible(false)]
