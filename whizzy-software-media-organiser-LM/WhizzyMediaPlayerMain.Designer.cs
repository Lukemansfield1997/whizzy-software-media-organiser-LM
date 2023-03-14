﻿namespace whizzy_software_media_organiser_LM
{
    partial class WhizzyMediaPlayerMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WhizzyMediaPlayerMain));
            this.playlistBox = new System.Windows.Forms.ListBox();
            this.FilemenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mediaPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mediaFilesGridView = new System.Windows.Forms.DataGridView();
            this.btnCreatePlaylist = new System.Windows.Forms.Button();
            this.btnSelectMediaFiles = new System.Windows.Forms.Button();
            this.btnRenamePlaylist = new System.Windows.Forms.Button();
            this.btnSavePlaylist = new System.Windows.Forms.Button();
            this.btnDeletePlaylist = new System.Windows.Forms.Button();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAddImage = new System.Windows.Forms.Button();
            this.btnRemoveImage = new System.Windows.Forms.Button();
            this.btnEditImage = new System.Windows.Forms.Button();
            this.btnRemoveComment = new System.Windows.Forms.Button();
            this.btnEditComment = new System.Windows.Forms.Button();
            this.btnAddComment = new System.Windows.Forms.Button();
            this.FilemenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mediaFilesGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // playlistBox
            // 
            this.playlistBox.FormattingEnabled = true;
            this.playlistBox.ItemHeight = 15;
            this.playlistBox.Location = new System.Drawing.Point(12, 133);
            this.playlistBox.Name = "playlistBox";
            this.playlistBox.Size = new System.Drawing.Size(244, 259);
            this.playlistBox.TabIndex = 0;
            this.playlistBox.SelectedIndexChanged += new System.EventHandler(this.playlistBox_SelectedIndexChanged);
            // 
            // FilemenuStrip
            // 
            this.FilemenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.FilemenuStrip.Location = new System.Drawing.Point(0, 0);
            this.FilemenuStrip.Name = "FilemenuStrip";
            this.FilemenuStrip.Size = new System.Drawing.Size(1605, 24);
            this.FilemenuStrip.TabIndex = 1;
            this.FilemenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mediaPathToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // mediaPathToolStripMenuItem
            // 
            this.mediaPathToolStripMenuItem.Name = "mediaPathToolStripMenuItem";
            this.mediaPathToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.mediaPathToolStripMenuItem.Text = "Media Path";
            // 
            // mediaFilesGridView
            // 
            this.mediaFilesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mediaFilesGridView.Location = new System.Drawing.Point(386, 133);
            this.mediaFilesGridView.Name = "mediaFilesGridView";
            this.mediaFilesGridView.RowTemplate.Height = 25;
            this.mediaFilesGridView.Size = new System.Drawing.Size(1013, 259);
            this.mediaFilesGridView.TabIndex = 2;
            // 
            // btnCreatePlaylist
            // 
            this.btnCreatePlaylist.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnCreatePlaylist.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCreatePlaylist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreatePlaylist.Font = new System.Drawing.Font("Corbel", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCreatePlaylist.ForeColor = System.Drawing.Color.White;
            this.btnCreatePlaylist.Location = new System.Drawing.Point(262, 188);
            this.btnCreatePlaylist.Name = "btnCreatePlaylist";
            this.btnCreatePlaylist.Size = new System.Drawing.Size(118, 45);
            this.btnCreatePlaylist.TabIndex = 14;
            this.btnCreatePlaylist.Text = "Create Playlist";
            this.btnCreatePlaylist.UseVisualStyleBackColor = false;
            this.btnCreatePlaylist.Click += new System.EventHandler(this.btnCreatePlaylist_Click);
            // 
            // btnSelectMediaFiles
            // 
            this.btnSelectMediaFiles.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSelectMediaFiles.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSelectMediaFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectMediaFiles.Font = new System.Drawing.Font("Corbel", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSelectMediaFiles.ForeColor = System.Drawing.Color.White;
            this.btnSelectMediaFiles.Location = new System.Drawing.Point(262, 137);
            this.btnSelectMediaFiles.Name = "btnSelectMediaFiles";
            this.btnSelectMediaFiles.Size = new System.Drawing.Size(118, 45);
            this.btnSelectMediaFiles.TabIndex = 15;
            this.btnSelectMediaFiles.Text = "Select Media Files";
            this.btnSelectMediaFiles.UseVisualStyleBackColor = false;
            this.btnSelectMediaFiles.Click += new System.EventHandler(this.btnSelectMediaFiles_Click);
            // 
            // btnRenamePlaylist
            // 
            this.btnRenamePlaylist.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnRenamePlaylist.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnRenamePlaylist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRenamePlaylist.Font = new System.Drawing.Font("Corbel", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRenamePlaylist.ForeColor = System.Drawing.Color.White;
            this.btnRenamePlaylist.Location = new System.Drawing.Point(262, 239);
            this.btnRenamePlaylist.Name = "btnRenamePlaylist";
            this.btnRenamePlaylist.Size = new System.Drawing.Size(118, 45);
            this.btnRenamePlaylist.TabIndex = 16;
            this.btnRenamePlaylist.Text = "Rename Playlist";
            this.btnRenamePlaylist.UseVisualStyleBackColor = false;
            this.btnRenamePlaylist.Click += new System.EventHandler(this.btnRenamePlaylist_Click);
            // 
            // btnSavePlaylist
            // 
            this.btnSavePlaylist.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSavePlaylist.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSavePlaylist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSavePlaylist.Font = new System.Drawing.Font("Corbel", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSavePlaylist.ForeColor = System.Drawing.Color.White;
            this.btnSavePlaylist.Location = new System.Drawing.Point(262, 290);
            this.btnSavePlaylist.Name = "btnSavePlaylist";
            this.btnSavePlaylist.Size = new System.Drawing.Size(118, 45);
            this.btnSavePlaylist.TabIndex = 17;
            this.btnSavePlaylist.Text = "Save Playlist";
            this.btnSavePlaylist.UseVisualStyleBackColor = false;
            this.btnSavePlaylist.Click += new System.EventHandler(this.btnSavePlaylist_Click);
            // 
            // btnDeletePlaylist
            // 
            this.btnDeletePlaylist.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnDeletePlaylist.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDeletePlaylist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeletePlaylist.Font = new System.Drawing.Font("Corbel", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDeletePlaylist.ForeColor = System.Drawing.Color.White;
            this.btnDeletePlaylist.Location = new System.Drawing.Point(262, 341);
            this.btnDeletePlaylist.Name = "btnDeletePlaylist";
            this.btnDeletePlaylist.Size = new System.Drawing.Size(118, 45);
            this.btnDeletePlaylist.TabIndex = 19;
            this.btnDeletePlaylist.Text = "Delete Playlist";
            this.btnDeletePlaylist.UseVisualStyleBackColor = false;
            this.btnDeletePlaylist.Click += new System.EventHandler(this.btnDeletePlaylist_Click);
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnAddCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCategory.Font = new System.Drawing.Font("Corbel", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddCategory.ForeColor = System.Drawing.Color.White;
            this.btnAddCategory.Location = new System.Drawing.Point(12, 398);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(244, 31);
            this.btnAddCategory.TabIndex = 20;
            this.btnAddCategory.Text = "Add Category To Category Manager";
            this.btnAddCategory.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.Highlight;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Corbel", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(12, 435);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(244, 31);
            this.button6.TabIndex = 21;
            this.button6.Text = "Manage Media Files Categories";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.SystemColors.Highlight;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Corbel", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(12, 472);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(244, 31);
            this.button7.TabIndex = 22;
            this.button7.Text = "Save Categories";
            this.button7.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1605, 100);
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // btnAddImage
            // 
            this.btnAddImage.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnAddImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddImage.Font = new System.Drawing.Font("Corbel", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddImage.ForeColor = System.Drawing.Color.White;
            this.btnAddImage.Location = new System.Drawing.Point(386, 398);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(113, 31);
            this.btnAddImage.TabIndex = 24;
            this.btnAddImage.Text = "Add Image";
            this.btnAddImage.UseVisualStyleBackColor = false;
            // 
            // btnRemoveImage
            // 
            this.btnRemoveImage.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnRemoveImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveImage.Font = new System.Drawing.Font("Corbel", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRemoveImage.ForeColor = System.Drawing.Color.White;
            this.btnRemoveImage.Location = new System.Drawing.Point(386, 472);
            this.btnRemoveImage.Name = "btnRemoveImage";
            this.btnRemoveImage.Size = new System.Drawing.Size(113, 31);
            this.btnRemoveImage.TabIndex = 25;
            this.btnRemoveImage.Text = "Remove Image";
            this.btnRemoveImage.UseVisualStyleBackColor = false;
            // 
            // btnEditImage
            // 
            this.btnEditImage.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnEditImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditImage.Font = new System.Drawing.Font("Corbel", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEditImage.ForeColor = System.Drawing.Color.White;
            this.btnEditImage.Location = new System.Drawing.Point(386, 435);
            this.btnEditImage.Name = "btnEditImage";
            this.btnEditImage.Size = new System.Drawing.Size(113, 31);
            this.btnEditImage.TabIndex = 26;
            this.btnEditImage.Text = "Edit Image";
            this.btnEditImage.UseVisualStyleBackColor = false;
            // 
            // btnRemoveComment
            // 
            this.btnRemoveComment.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnRemoveComment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveComment.Font = new System.Drawing.Font("Corbel", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRemoveComment.ForeColor = System.Drawing.Color.White;
            this.btnRemoveComment.Location = new System.Drawing.Point(1278, 472);
            this.btnRemoveComment.Name = "btnRemoveComment";
            this.btnRemoveComment.Size = new System.Drawing.Size(121, 31);
            this.btnRemoveComment.TabIndex = 27;
            this.btnRemoveComment.Text = "Remove Comment";
            this.btnRemoveComment.UseVisualStyleBackColor = false;
            // 
            // btnEditComment
            // 
            this.btnEditComment.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnEditComment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditComment.Font = new System.Drawing.Font("Corbel", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEditComment.ForeColor = System.Drawing.Color.White;
            this.btnEditComment.Location = new System.Drawing.Point(1278, 435);
            this.btnEditComment.Name = "btnEditComment";
            this.btnEditComment.Size = new System.Drawing.Size(121, 31);
            this.btnEditComment.TabIndex = 28;
            this.btnEditComment.Text = "Edit Comment";
            this.btnEditComment.UseVisualStyleBackColor = false;
            // 
            // btnAddComment
            // 
            this.btnAddComment.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnAddComment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddComment.Font = new System.Drawing.Font("Corbel", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddComment.ForeColor = System.Drawing.Color.White;
            this.btnAddComment.Location = new System.Drawing.Point(1278, 398);
            this.btnAddComment.Name = "btnAddComment";
            this.btnAddComment.Size = new System.Drawing.Size(121, 31);
            this.btnAddComment.TabIndex = 29;
            this.btnAddComment.Text = "Add Comment";
            this.btnAddComment.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1605, 570);
            this.Controls.Add(this.btnAddComment);
            this.Controls.Add(this.btnEditComment);
            this.Controls.Add(this.btnRemoveComment);
            this.Controls.Add(this.btnEditImage);
            this.Controls.Add(this.btnRemoveImage);
            this.Controls.Add(this.btnAddImage);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.btnAddCategory);
            this.Controls.Add(this.btnDeletePlaylist);
            this.Controls.Add(this.btnSavePlaylist);
            this.Controls.Add(this.btnRenamePlaylist);
            this.Controls.Add(this.btnSelectMediaFiles);
            this.Controls.Add(this.btnCreatePlaylist);
            this.Controls.Add(this.mediaFilesGridView);
            this.Controls.Add(this.playlistBox);
            this.Controls.Add(this.FilemenuStrip);
            this.MainMenuStrip = this.FilemenuStrip;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FilemenuStrip.ResumeLayout(false);
            this.FilemenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mediaFilesGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox playlistBox;
        private MenuStrip FilemenuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem mediaPathToolStripMenuItem;
        private DataGridView mediaFilesGridView;
        private Button btnCreatePlaylist;
        private Button btnSelectMediaFiles;
        private Button btnRenamePlaylist;
        private Button btnSavePlaylist;
        private Button btnDeletePlaylist;
        private Button btnAddCategory;
        private Button button6;
        private Button button7;
        private PictureBox pictureBox1;
        private Button btnAddImage;
        private Button btnRemoveImage;
        private Button btnEditImage;
        private Button btnRemoveComment;
        private Button btnEditComment;
        private Button btnAddComment;
    }
}