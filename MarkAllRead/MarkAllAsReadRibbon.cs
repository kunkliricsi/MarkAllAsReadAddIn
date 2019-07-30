﻿using Microsoft.Office.Tools.Ribbon;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace MarkAllRead
{
    public partial class MarkAllAsReadRibbon
    {
        private IReadOnlyCollection<Outlook.Folder> _folders;
        private DialogLauncher _form;

        private void MarkAllAsRead_Load(object sender, RibbonUIEventArgs e)
        {
            var storedFolders = Properties.Settings.Default.SelectedFolders;

            _form = new DialogLauncher(Globals.ThisAddIn.Application, storedFolders?.Cast<string>());
            _folders = _form.SelectedFolders;
        }

        private void groupMarkAll_DialogLauncherClick(object sender, RibbonControlEventArgs e)
        {
            var result = _form.ShowDialog();
            if (result == DialogResult.OK)
            {
                _folders = _form.SelectedFolders;
                Properties.Settings.Default.SelectedFolders = new StringCollection();
                Properties.Settings.Default.SelectedFolders.AddRange(_folders.Select(f => f.Name).ToArray());
                Properties.Settings.Default.Save();
            }
        }

        private void buttonMarkAll_Click(object sender, RibbonControlEventArgs e)
        {
            if (!_folders.Any())
            {
                MessageBox.Show("No folder is selected.", "Mark All As Read", MessageBoxButtons.OK);
                return;
            }

            Task.Run(() =>
            {
                for (int i = 0; i < 7; i++)
                    foreach (var folder in _folders)
                        foreach (Outlook.MailItem item in folder.Items.Restrict("[Unread]=true"))
                        {
                            item.UnRead = false;
                            item.Save();
                        }
            });
        }
    }
}