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
        private readonly Dictionary<TreeNode, Outlook.MAPIFolder> _nodeToFolders;
        private readonly HashSet<Outlook.MAPIFolder> _selectedFolders;
        private bool _selectAllPressed = false;

        public IReadOnlyCollection<Outlook.MAPIFolder> SelectedFolders => _selectedFolders;

        public DialogLauncher(Outlook.Application application, IEnumerable<string> alreadySelected = null)
        {
            InitializeComponent();

            _application = application;
            _nodeToFolders = new Dictionary<TreeNode, Outlook.MAPIFolder>();
            _selectedFolders = new HashSet<Outlook.MAPIFolder>();

            LoadFolders(alreadySelected?.ToArray());
        }

        private void LoadFolders(ICollection<string> alreadySelected = null)
        {
            void VisitNode(MAPIFolder folder, TreeNodeCollection nodes)
            {
                var name = folder.Name;
                var addedNode = nodes.Add(name);

                _nodeToFolders.Add(addedNode, folder);

                if (alreadySelected?.Contains(name) ?? false)
                {
                    addedNode.Checked = true;
                    _selectedFolders.Add(folder);
                }

                for (int i = folder.Folders.Count; i > 0; i--)
                {
                    VisitNode(folder.Folders[i], addedNode.Nodes);
                }
			}

            checkedTreeView1.BeginUpdate();
            VisitNode(_application.Session.DefaultStore.GetRootFolder(), checkedTreeView1.Nodes);
            checkedTreeView1.EndUpdate();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            _selectedFolders.Clear();

            foreach (var checkedNode in Flatten(checkedTreeView1.Nodes).Where(n => n.Checked))
            {
                _selectedFolders.Add(_nodeToFolders[checkedNode]);
            }
        }

		private void selectAllButton_Click(object sender, EventArgs e)
		{
            _selectAllPressed = !_selectAllPressed;
            SetAll(checkedTreeView1.Nodes, _selectAllPressed);

            selectAllButton.Text = (_selectAllPressed
                ? "Uns" : "S") 
                + "elect All";
        }

        private void checkedTreeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                if (e.Node.Nodes.Count > 0)
                {
                    SetAll(e.Node.Nodes, e.Node.Checked);
                }
            }
        }

        private void SetAll(TreeNodeCollection nodeCollection, bool isChecked)
        {
            foreach (var node in Flatten(nodeCollection))
            {
                node.Checked = isChecked;
            }
        }

        private IEnumerable<TreeNode> Flatten(TreeNodeCollection nodeCollection)
		{
            foreach (TreeNode node in nodeCollection)
			{
                yield return node;

                foreach (var child in Flatten(node.Nodes))
                    yield return child;
			}
		}

		private void checkedTreeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
		{
            e.Cancel = true;
		}

		private void DialogLauncher_Shown(object sender, EventArgs e)
		{
            checkedTreeView1.Nodes[0].Expand();
		}
	}
}