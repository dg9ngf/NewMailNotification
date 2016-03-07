using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Automation;
using System.Windows.Forms;

namespace NewMailNotification
{
	public partial class NotifyForm : Form
	{
		private string accountName;
		private string subject;

		public NotifyForm()
		{
			InitializeComponent();

			panel1.Left = 1;
			panel1.Top = 1;
			panel1.Width = ClientSize.Width - 2;
			panel1.Height = ClientSize.Height - 2;

			captionLabel.MaximumSize = new Size(ClientSize.Width - captionLabel.Left * 2, captionLabel.Height);
			subjectLabel.MaximumSize = new Size(ClientSize.Width - subjectLabel.Left * 2, subjectLabel.Height);
			senderLabel.MaximumSize = new Size(ClientSize.Width - senderLabel.Left * 2, senderLabel.Height);

			string[] args = Environment.GetCommandLineArgs();
			if (args.Length >= 4)
			{
				accountName = args[1];
				captionLabel.Text = "New mail for " + args[1];
				subject = args[2];
				subjectLabel.Text = args[2];
				senderLabel.Text = args[3];
			}

			Left = Screen.PrimaryScreen.WorkingArea.Left + 5;
			Top = Screen.PrimaryScreen.WorkingArea.Bottom - Height - 5;

			SystemSound.Mail.Play();

			Opacity = 0;
			new Animation(AnimationTypes.FadeIn, this, 100, null, 200);
		}

		protected override CreateParams CreateParams
		{
			get
			{
				var cp = base.CreateParams;
				cp.ExStyle |= 0x08000000;   // WS_EX_NOACTIVATE (don't focus the notification window when it's shown)
				return cp;
			}
		}

		private void NotifyForm_Click(object sender, EventArgs args)
		{
			new Animation(AnimationTypes.FadeOut, this, -100, _ => Close(), 200);

			new Thread(ThunderbirdThreadProc).Start();
		}

		private void timer1_Tick(object sender, EventArgs args)
		{
			new Animation(AnimationTypes.FadeOut, this, -100, _ => Close(), 2000);
		}

		/// <summary>
		/// Activates Thunderbird and selects the reported message in its account inbox.
		/// </summary>
		private void ThunderbirdThreadProc()
		{
			try
			{
				// Find Thunderbird window
				var thunderbirdWindow = AutomationElement.RootElement.FindAll(
						TreeScope.Children,
						new PropertyCondition(AutomationElement.ClassNameProperty, "MozillaWindowClass"))
					.OfType<AutomationElement>()
					.FirstOrDefault(a => a.Current.Name.EndsWith("Mozilla Thunderbird"));

				// Find UI elements
				var accountsTree = thunderbirdWindow.FindFirst(
					TreeScope.Descendants,
					new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Tree));

				var accountTreeItem = accountsTree.FindFirst(
					TreeScope.Children,
					new AndCondition(
						new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.TreeItem),
						new PropertyCondition(AutomationElement.NameProperty, accountName)));

				var inboxTreeItem = TreeWalker.ControlViewWalker.GetNextSibling(accountTreeItem);

				var invokePattern = inboxTreeItem.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
				invokePattern.Invoke();

				var tmp = TreeWalker.ControlViewWalker.GetParent(inboxTreeItem);
				var messageTable = TreeWalker.ControlViewWalker.GetNextSibling(tmp);
				for (int retry = 100; retry > 0 && messageTable == null; retry--)
				{
					Thread.Sleep(10);
					messageTable = TreeWalker.ControlViewWalker.GetNextSibling(tmp);
				}
				var messageCell = messageTable.FindFirst(
					TreeScope.Descendants,
					new PropertyCondition(AutomationElement.NameProperty, subject));
				for (int retry = 100; retry > 0 && messageCell == null; retry--)
				{
					Thread.Sleep(10);
					messageCell = messageTable.FindFirst(
						TreeScope.Descendants,
						new PropertyCondition(AutomationElement.NameProperty, subject));
				}
				var messageRow = TreeWalker.ControlViewWalker.GetParent(messageCell);

				// Select the reported message in the list
				invokePattern = messageRow.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
				invokePattern.Invoke();

				// Restore window in case it's minimised
				var windowplacement = SafeNativeMethods.WINDOWPLACEMENT.Default;
				SafeNativeMethods.GetWindowPlacement(new IntPtr(thunderbirdWindow.Current.NativeWindowHandle), ref windowplacement);
				var windowPattern = thunderbirdWindow.GetCurrentPattern(WindowPattern.Pattern) as WindowPattern;
				if ((windowplacement.Flags & 2 /*WPF_RESTORETOMAXIMIZED*/) != 0)
				{
					windowPattern.SetWindowVisualState(WindowVisualState.Maximized);
				}
				else
				{
					windowPattern.SetWindowVisualState(WindowVisualState.Normal);
				}
			}
			catch
			{
			}
		}
	}
}
