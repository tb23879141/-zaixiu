using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFrmTalk.Model;

namespace WinFrmTalk.Live
{
    public partial class FrmLiveTest : Form
    {
        public FrmLiveTest()
        {
            InitializeComponent();
            //vlcControl1.EndInit();
        }

        private void VlcControl1_VlcLibDirectoryNeeded(object sender, Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs e)
        {
            //var currentAssembly = Assembly.GetEntryAssembly();
            //var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;
            //if (currentDirectory == null)
            //    return;
            //if (AssemblyName.GetAssemblyName(currentAssembly.Location).ProcessorArchitecture == ProcessorArchitecture.X86)
            //    e.VlcLibDirectory = new DirectoryInfo(System.IO.Path.Combine(currentDirectory, @"libvlc\win-x86\"));
            //else
            //    e.VlcLibDirectory = new DirectoryInfo(System.IO.Path.Combine(currentDirectory, @"libvlc\win-x64\"));

            //    var currentAssembly = Assembly.GetEntryAssembly();
            //    var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;

            //    if (currentDirectory == null)
            //        return;
            //    if (IntPtr.Size == 4)
            //        e.VlcLibDirectory = new DirectoryInfo(Path.GetFullPath(@".\libvlc\win-x86\"));
            //    else
            //        e.VlcLibDirectory = new DirectoryInfo(Path.GetFullPath(@".\libvlc\win-x64\"));

            //    if (!e.VlcLibDirectory.Exists)
            //    {
            //        var folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            //        folderBrowserDialog.Description = "Select Vlc libraries folder.";
            //        folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;
            //        folderBrowserDialog.ShowNewFolderButton = true;
            //        if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            //        {
            //            e.VlcLibDirectory = new DirectoryInfo(folderBrowserDialog.SelectedPath);
            //        }
            //    }

            var currentAssembly = Assembly.GetEntryAssembly();
            var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;
            if (currentDirectory == null)
                return;
            if (AssemblyName.GetAssemblyName(currentAssembly.Location).ProcessorArchitecture == ProcessorArchitecture.X86)
                e.VlcLibDirectory = new DirectoryInfo(Path.Combine(currentDirectory, @"libvlc\win-x86\"));
            else
                e.VlcLibDirectory = new DirectoryInfo(Path.Combine(currentDirectory, @"libvlc\win-x64\"));
            if (!e.VlcLibDirectory.Exists)
            {
                var folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
                folderBrowserDialog.Description = "Select Vlc libraries folder.";
                folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;
                folderBrowserDialog.ShowNewFolderButton = true;
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    e.VlcLibDirectory = new DirectoryInfo(folderBrowserDialog.SelectedPath);
                }
            }
        }
    }
}

