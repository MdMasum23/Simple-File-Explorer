using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace FileExplorer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = folderDialog.SelectedPath;
                    txtPath.Text = selectedPath; // Set the path to the TextBox
                    DisplayFilesInDirectory(selectedPath);
                }
            }
        }

        private void DisplayFilesInDirectory(string path)
        {
            try
            {
                lstFiles.Items.Clear(); // Clear previous items
                string[] files = Directory.GetFiles(path); // Get all files in the directory
                foreach (string file in files)
                {
                    lstFiles.Items.Add(Path.GetFileName(file)); // Add file names to ListBox
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstFiles_DoubleClick(object sender, EventArgs e)
        {
            if (lstFiles.SelectedItem != null)
            {
                string filePath = System.IO.Path.Combine(txtPath.Text, lstFiles.SelectedItem.ToString());
                try
                {
                    System.Diagnostics.Process.Start(filePath); // Open file with default application
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Cannot open file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtPath_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
