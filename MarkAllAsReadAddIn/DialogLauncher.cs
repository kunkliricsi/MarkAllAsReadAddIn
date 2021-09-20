using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace MarkAllRead
{
	public partial class DialogLauncher : Form
    {
        private readonly Outlook.Application _application;
        private readonly Dictionary<string, Outlook.Folder> _nameToFolders;
        private readonly HashSet<Outlook.Folder> _selectedFolders;
        private bool _selectAllPressed = false;

        public IReadOnlyCollection<Outlook.Folder> SelectedFolders => _selectedFolders;

        public DialogLauncher(Outlook.Application application, IEnumerable<string> alreadySelected = null)
        {
            InitializeComponent();

            _application = application;
            _nameToFolders = new Dictionary<string, Outlook.Folder>();
            _selectedFolders = new HashSet<Outlook.Folder>();

            LoadFolders(alreadySelected?.ToArray());
        }

        private void LoadFolders(ICollection<string> alreadySelected = null)
        {
            var folders = FlattenFolder(_application.Session.DefaultStore.GetRootFolder() as Folder).GroupBy(f => f.Name).Select(g => g.First()).ToList();

            foreach (var folder in folders)
            {
                var name = folder.Name;

                if (!_nameToFolders.ContainsKey(name))
                    _nameToFolders.Add(name, folder);

                var itemIndex = checkedListBox1.Items.Add(name);

                if (alreadySelected?.Contains(name) ?? false)
                {
                    checkedListBox1.SetItemChecked(itemIndex, true);
                    _selectedFolders.Add(folder);
                }
            }

            checkedListBox1.TopIndex = 0;
        }

        private IEnumerable<Folder> FlattenFolder(Folder parent)
        {
            IEnumerable<Folder> folders = new List<Folder> { parent };

            for (int i = parent.Folders.Count; i > 0; i--)
            {
                folders = folders.Union(FlattenFolder(parent.Folders[i] as Folder ?? throw new InvalidCastException()));
            }

            return folders;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            _selectedFolders.Clear();

            foreach (string item in checkedListBox1.CheckedItems)
            {
                _selectedFolders.Add(_nameToFolders[item]);
            }
        }

		private void selectAllButton_Click(object sender, EventArgs e)
		{
            void SetAll(bool isChecked)
			{
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, isChecked);
                }
            }

            _selectAllPressed = !_selectAllPressed;
            SetAll(_selectAllPressed);

            selectAllButton.Text = (_selectAllPressed
                ? "Uns" : "S") 
                + "elect All";
		}
	}
}