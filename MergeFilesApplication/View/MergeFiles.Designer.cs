namespace MergeFilesApplication.View
{
    partial class MergeFiles
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.formatComboBox = new System.Windows.Forms.ComboBox();
            this.chooseFileLabel = new System.Windows.Forms.Label();
            this.filesListView = new System.Windows.Forms.ListView();
            this.fileNameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fileSizeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.iconImageList = new System.Windows.Forms.ImageList(this.components);
            this.uploadButton = new System.Windows.Forms.Button();
            this.margeButton = new System.Windows.Forms.Button();
            this.removeFilesButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // formatComboBox
            // 
            this.formatComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.formatComboBox.FormattingEnabled = true;
            this.formatComboBox.Location = new System.Drawing.Point(254, 25);
            this.formatComboBox.Name = "formatComboBox";
            this.formatComboBox.Size = new System.Drawing.Size(121, 21);
            this.formatComboBox.TabIndex = 0;
            this.formatComboBox.SelectedIndexChanged += new System.EventHandler(this.formatComboBox_SelectedIndexChanged);
            // 
            // chooseFileLabel
            // 
            this.chooseFileLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chooseFileLabel.AutoSize = true;
            this.chooseFileLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chooseFileLabel.Location = new System.Drawing.Point(100, 25);
            this.chooseFileLabel.Name = "chooseFileLabel";
            this.chooseFileLabel.Size = new System.Drawing.Size(137, 19);
            this.chooseFileLabel.TabIndex = 1;
            this.chooseFileLabel.Text = "Choose File Format:";
            // 
            // filesListView
            // 
            this.filesListView.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.filesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fileNameHeader,
            this.fileSizeHeader});
            this.filesListView.FullRowSelect = true;
            this.filesListView.HideSelection = false;
            this.filesListView.LargeImageList = this.iconImageList;
            this.filesListView.Location = new System.Drawing.Point(12, 73);
            this.filesListView.Name = "filesListView";
            this.filesListView.Size = new System.Drawing.Size(300, 385);
            this.filesListView.SmallImageList = this.iconImageList;
            this.filesListView.TabIndex = 2;
            this.filesListView.UseCompatibleStateImageBehavior = false;
            this.filesListView.View = System.Windows.Forms.View.Details;
            // 
            // fileNameHeader
            // 
            this.fileNameHeader.Text = "File Name";
            this.fileNameHeader.Width = 175;
            // 
            // fileSizeHeader
            // 
            this.fileSizeHeader.Text = "File Size";
            this.fileSizeHeader.Width = 121;
            // 
            // iconImageList
            // 
            this.iconImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.iconImageList.ImageSize = new System.Drawing.Size(16, 16);
            this.iconImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // uploadButton
            // 
            this.uploadButton.Location = new System.Drawing.Point(360, 104);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.Size = new System.Drawing.Size(75, 23);
            this.uploadButton.TabIndex = 3;
            this.uploadButton.Text = "Upload";
            this.uploadButton.UseVisualStyleBackColor = true;
            this.uploadButton.Click += new System.EventHandler(this.uploadButton_Click);
            // 
            // margeButton
            // 
            this.margeButton.Location = new System.Drawing.Point(360, 152);
            this.margeButton.Name = "margeButton";
            this.margeButton.Size = new System.Drawing.Size(75, 23);
            this.margeButton.TabIndex = 4;
            this.margeButton.Text = "Merge";
            this.margeButton.UseVisualStyleBackColor = true;
            this.margeButton.Click += new System.EventHandler(this.margeButton_Click);
            // 
            // removeFilesButton
            // 
            this.removeFilesButton.Location = new System.Drawing.Point(360, 201);
            this.removeFilesButton.Name = "removeFilesButton";
            this.removeFilesButton.Size = new System.Drawing.Size(75, 23);
            this.removeFilesButton.TabIndex = 5;
            this.removeFilesButton.Text = "Clear";
            this.removeFilesButton.UseVisualStyleBackColor = true;
            this.removeFilesButton.Click += new System.EventHandler(this.removeFilesButton_Click);
            // 
            // MergeFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.removeFilesButton);
            this.Controls.Add(this.margeButton);
            this.Controls.Add(this.uploadButton);
            this.Controls.Add(this.filesListView);
            this.Controls.Add(this.chooseFileLabel);
            this.Controls.Add(this.formatComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MergeFiles";
            this.Text = "Merge Files";
            this.Load += new System.EventHandler(this.MergeFiles_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox formatComboBox;
        private System.Windows.Forms.Label chooseFileLabel;
        private System.Windows.Forms.ListView filesListView;
        private System.Windows.Forms.ImageList iconImageList;
        private System.Windows.Forms.ColumnHeader fileNameHeader;
        private System.Windows.Forms.ColumnHeader fileSizeHeader;
        private System.Windows.Forms.Button uploadButton;
        private System.Windows.Forms.Button margeButton;
        private System.Windows.Forms.Button removeFilesButton;
    }
}