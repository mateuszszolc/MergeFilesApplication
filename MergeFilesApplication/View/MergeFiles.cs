using MergeFilesApplication.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MergeFilesApplication.View
{
    public partial class MergeFiles : Form
    {
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        List<string> filesToMerge = new List<string>();
        List<byte[]> filesByteArrayList = new List<byte[]>();
        public MergeFiles()
        {
            InitializeComponent();
            formatComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            formatComboBox.DataSource = StaticDetails.fileFormats;
            formatComboBox.SelectedIndex = 0;
            margeButton.Enabled = false;
            removeFilesButton.Enabled = false;
            filesListView.Enabled = false;
        }

        private void MergeFiles_Load(object sender, EventArgs e)
        {
            filesListView.Items.Clear();
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = $"{formatComboBox.SelectedItem.ToString()} files (*." +
                    $"{formatComboBox.SelectedItem.ToString().ToLower()})|*." +
                    $"{formatComboBox.SelectedItem.ToString().ToLower()};";
                openFileDialog.Multiselect = true;
                openFileDialog.InitialDirectory = desktopPath;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach(var file in openFileDialog.FileNames)
                    {
                        FileInfo fileInfo = new FileInfo(file);
                        string fileExtension = fileInfo.Extension;
                        double fileSize = Math.Round(MergeHelper.ConvertBytesToMegabytes(fileInfo.Length), 2, MidpointRounding.AwayFromZero);
                        filesToMerge.Add(file); //pelna sciezka
                        
                        if (!iconImageList.Images.Keys.Contains(fileExtension))
                        {
                            iconImageList.Images.Add(fileExtension, Icon.ExtractAssociatedIcon(fileInfo.FullName));
                        }

                        int index = iconImageList.Images.Keys.IndexOf(fileExtension);
                        ListViewItem listViewItem = new ListViewItem();
                        listViewItem.Text = fileInfo.Name; 
                        listViewItem.ImageIndex = index;
                        listViewItem.SubItems.Add(fileSize.ToString() + " MB");
                        filesListView.Items.Add(listViewItem);


                        if (filesToMerge.Count > 0 && filesListView.Items.Count > 0)
                        {
                            removeFilesButton.Enabled = true;
                        }

                        if (filesToMerge.Count > 1)
                        {
                            margeButton.Enabled = true;
                        }

                        if (filesToMerge.Count > 20 || filesListView.Items.Count > 20)
                        {
                            filesToMerge.Clear();
                            filesListView.Items.Clear();
                            throw new MergeException();
                        }
                    }

                }
            }
            catch(FileNameException fileNameException)
            {
                MessageBox.Show(fileNameException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(MergeException mergeException)
            {
                MessageBox.Show(mergeException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void margeButton_Click(object sender, EventArgs e)
        {
            try
            {
                MergeHelper.AddByteArrayOfEachFile(filesToMerge, ref filesByteArrayList);
                byte[] mergedFile;

                if(formatComboBox.SelectedItem.ToString() == "PDF")
                {
                    mergedFile = MergeHelper.MergePdfs(filesByteArrayList);
                }
                else if(formatComboBox.SelectedItem.ToString() == "DOCX")
                {
                    mergedFile = MergeHelper.DocxMerge(filesByteArrayList);
                }
                else
                {
                    mergedFile = null;
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = saveFileDialog.Filter = $"{formatComboBox.SelectedItem.ToString()} files (*." +
                    $"{formatComboBox.SelectedItem.ToString().ToLower()})|*." +
                    $"{formatComboBox.SelectedItem.ToString().ToLower()};";
                saveFileDialog.FileName = "MergedFile";
                saveFileDialog.OverwritePrompt = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string savePath = Path.Combine(desktopPath, saveFileDialog.FileName);

                    if (formatComboBox.SelectedItem.ToString() == "PDF" || formatComboBox.SelectedItem.ToString() == "DOCX")
                    {
                        File.WriteAllBytes(savePath, mergedFile);
                    }                  
                    else
                    {
                        MergeHelper.TxtMerge(savePath, filesToMerge);
                    }
                }
            }
            catch(InvalidOperationException invalidOperationEx)
            {
                MessageBox.Show(invalidOperationEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception)
            {
                MessageBox.Show("Cannot merge attached files", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void removeFilesButton_Click(object sender, EventArgs e)
        {
            if (filesToMerge.Count > 0 && filesListView.Items.Count > 0)
            { 
                 filesToMerge.Clear();
                 filesListView.Items.Clear();
                removeFilesButton.Enabled = false;
                margeButton.Enabled = false;
            }
        }

        private void formatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            filesToMerge.Clear();
            filesListView.Items.Clear();
            removeFilesButton.Enabled = false;
            margeButton.Enabled = false;
        }
    }
}
