using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static getProcessFilePath.myProcess;

namespace getProcessFilePath
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            setProcTreeView();
         }

        void setProcTreeView()
        {
            myProcess processManager = new myProcess();
            List<PROCESSENTRY32> ProcessList = processManager.GetProcessList(out string error);

            TreeNode root = new TreeNode();
            root.Text = $"{ProcessList.Count()}個進程";
            TreeNode node = null;
            foreach(PROCESSENTRY32 process in ProcessList)
            {
                node = new TreeNode();
                node.Text = $"PID: {process.th32ProcessID,-8}Name: {process.szExeFile}";
                
                root.Nodes.Add(node);
            }

            ProcesstreeView.Nodes.Add(root);
        }

    }
}
