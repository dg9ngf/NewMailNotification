// Copyright (c) 2007, Yves Goergen, http://unclassified.software/source/systemsound
//
// Copying and distribution of this file, with or without modification, are permitted provided the
// copyright notice and this notice are preserved. This file is offered as-is, without any warranty.

using System;
using System.IO;
using System.Media;
using Microsoft.Win32;

namespace NewMailNotification
{
	public class SystemSound
	{
		public static SystemSound Default
		{
			get
			{
				return new SystemSound(".Default");
			}
		}

		public static SystemSound AppFault
		{
			get
			{
				return new SystemSound("AppGPFault");
			}
		}

		public static SystemSound SystemStart
		{
			get
			{
				return new SystemSound("SystemStart");
			}
		}

		public static SystemSound SystemExit
		{
			get
			{
				return new SystemSound("SystemExit");
			}
		}

		public static SystemSound UserLogon
		{
			get
			{
				return new SystemSound("WindowsLogon");
			}
		}

		public static SystemSound UserLogoff
		{
			get
			{
				return new SystemSound("WindowsLogoff");
			}
		}

		public static SystemSound AppOpen
		{
			get
			{
				return new SystemSound("Open");
			}
		}

		public static SystemSound AppClose
		{
			get
			{
				return new SystemSound("Close");
			}
		}

		public static SystemSound WindowMaximise
		{
			get
			{
				return new SystemSound("Maximize");
			}
		}

		public static SystemSound WindowMinimise
		{
			get
			{
				return new SystemSound("Minimize");
			}
		}

		public static SystemSound WindowRestoreUp
		{
			get
			{
				return new SystemSound("RestoreUp");
			}
		}

		public static SystemSound WindowRestoreDown
		{
			get
			{
				return new SystemSound("RestoreDown");
			}
		}

		public static SystemSound MenuCommand
		{
			get
			{
				return new SystemSound("MenuCommand");
			}
		}

		public static SystemSound MenuPopup
		{
			get
			{
				return new SystemSound("MenuPopup");
			}
		}

		public static SystemSound PrintComplete
		{
			get
			{
				return new SystemSound("PrintComplete");
			}
		}

		public static SystemSound LowBattery
		{
			get
			{
				return new SystemSound("LowBatteryAlarm");
			}
		}

		public static SystemSound CriticalBattery
		{
			get
			{
				return new SystemSound("CriticalBatteryAlarm");
			}
		}

		public static SystemSound DeviceConnect
		{
			get
			{
				return new SystemSound("DeviceConnect");
			}
		}

		public static SystemSound DeviceDisconnect
		{
			get
			{
				return new SystemSound("DeviceDisconnect");
			}
		}

		public static SystemSound DeviceFail
		{
			get
			{
				return new SystemSound("DeviceFail");
			}
		}

		public static SystemSound InternetAlert
		{
			get
			{
				return new SystemSound("InternetAlert");
			}
		}

		public static SystemSound Critical
		{
			get
			{
				return new SystemSound("SystemHand");
			}
		}

		public static SystemSound Exclamation
		{
			get
			{
				return new SystemSound("SystemExclamation");
			}
		}

		public static SystemSound Notification
		{
			get
			{
				return new SystemSound("SystemNotification");
			}
		}

		public static SystemSound Question
		{
			get
			{
				return new SystemSound("SystemQuestion");
			}
		}

		public static SystemSound Mail
		{
			get
			{
				return new SystemSound("MailBeep");
			}
		}

		public static SystemSound BlockedPopup
		{
			get
			{
				return new SystemSound("BlockedPopup", "Explorer");
			}
		}

		public static SystemSound EmptyRecycleBin
		{
			get
			{
				return new SystemSound("EmptyRecycleBin", "Explorer");
			}
		}

		public static SystemSound Navigating
		{
			get
			{
				return new SystemSound("Navigating", "Explorer");
			}
		}

		/// <summary>
		/// Find a custom sound that is not available through this class' static members.
		/// </summary>
		/// <param name="category"></param>
		/// <param name="name"></param>
		/// <returns>SystemSound object that you can call <c>Play()</c> on</returns>
		public static SystemSound Find(string category, string name)
		{
			if (category.Contains("\\")) throw new ArgumentException("category argument must not contain '\\' character");
			if (name.Contains("\\")) throw new ArgumentException("name argument must not contain '\\' character");
			return new SystemSound(name, category);
		}

		string category = ".Default";
		string name = "";
		
		private SystemSound(string name)
		{
			this.name = name;
		}

		private SystemSound(string name, string category)
		{
			this.name = name;
			this.category = category;
		}

		/// <summary>
		/// Play the sound associated with this event, if any.
		/// In case of failure, a default PC speaker beep is played.
		/// </summary>
		public void Play()
		{
			try
			{
				object snd = Registry.CurrentUser.OpenSubKey(@"AppEvents\Schemes\Apps\" + category + @"\" + name + @"\.Current").GetValue("");
				if (snd is string && (snd as string) != "")
				{
					string path = snd as string;
					if (!Path.IsPathRooted(path))
						path = Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.System)) + "\\Media\\" + path;

					SoundPlayer sp = new SoundPlayer(path);
					sp.Play();
				}
			}
			catch
			{
				Console.Beep();
			}
		}

		/// <summary>
		/// Gets a value indicating whether a sound has been set for this event.
		/// </summary>
		public bool IsSet
		{
			get
			{
				try
				{
					object snd = Registry.CurrentUser.OpenSubKey(@"AppEvents\Schemes\Apps\" + category + @"\" + name + @"\.Current").GetValue("");
					if (snd is string && (snd as string) != "")
					{
						string path = snd as string;
						if (!Path.IsPathRooted(path))
							path = Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.System)) + "\\Media\\" + path;

						return File.Exists(path);
					}
					return false;
				}
				catch
				{
					return false;
				}
			}
		}
	}
}
