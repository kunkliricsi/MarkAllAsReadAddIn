using Microsoft.Office.Tools.Ribbon;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using MarkAllRead.Properties;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace MarkAllRead
{
    public partial class MarkAllAsReadRibbon
    {
        private IReadOnlyCollection<Outlook.Folder> _folders;
        private DialogLauncher _form;

        private void MarkAllAsRead_Load(object sender, RibbonUIEventArgs e)
        {
            if (Settings.Default.UpgradeRequired)
            {
                Settings.Default.Upgrade();
                Settings.Default.UpgradeRequired = false;
                Settings.Default.Save();
            }

            var storedFolders = Settings.Default.SelectedFolders;

            _form = new DialogLauncher(Globals.ThisAddIn.Application, storedFolders?.Cast<string>());
            _folders = _form.SelectedFolders;
        }

        private void groupMarkAll_DialogLauncherClick(object sender, RibbonControlEventArgs e)
        {
            var result = _form.ShowDialog();
            if (result == DialogResult.OK)
            {
                _folders = _form.SelectedFolders;
                Settings.Default.SelectedFolders = new StringCollection();
                Settings.Default.SelectedFolders.AddRange(_folders.Select(f => f.Name).ToArray());
                Settings.Default.Save();
            }
        }

        private void buttonMarkAll_Click(object sender, RibbonControlEventArgs e)
        {
            if (!_folders.Any())
            {
                groupMarkAll_DialogLauncherClick(sender, e);
                return;
            }

            Task.Run(() =>
            {
                foreach (var folder in _folders)
                {
                    var folderItems = folder.Items.Restrict("[Unread]=true");

                    for (int m = folderItems.Count; m > 0; m--)
                    {
                        Outlook.MailItem mail = folderItems[m];

                        if (mail.UnRead)
                        {
                            mail.UnRead = false;
                            mail.Save();
                        }

                        Marshal.ReleaseComObject(mail);
                    }

                    Marshal.ReleaseComObject(folderItems);
                }
            });
        }
    }
}
