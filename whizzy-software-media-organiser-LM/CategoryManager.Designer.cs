namespace whizzy_software_media_organiser_LM
{
    partial class CategoryManager
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
            this.checkedCategoryBox = new System.Windows.Forms.CheckedListBox();
            this.btnAddCategories = new System.Windows.Forms.Button();
            this.btnDeleteCategories = new System.Windows.Forms.Button();
            this.btnRenameCategory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkedCategoryBox
            // 
            this.checkedCategoryBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkedCategoryBox.ForeColor = System.Drawing.SystemColors.Highlight;
            this.checkedCategoryBox.FormattingEnabled = true;
            this.checkedCategoryBox.Location = new System.Drawing.Point(32, 12);
            this.checkedCategoryBox.Name = "checkedCategoryBox";
            this.checkedCategoryBox.Size = new System.Drawing.Size(334, 292);
            this.checkedCategoryBox.TabIndex = 0;
            // 
            // btnAddCategories
            // 
            this.btnAddCategories.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnAddCategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCategories.Font = new System.Drawing.Font("Corbel", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddCategories.ForeColor = System.Drawing.Color.White;
            this.btnAddCategories.Location = new System.Drawing.Point(32, 310);
            this.btnAddCategories.Name = "btnAddCategories";
            this.btnAddCategories.Size = new System.Drawing.Size(101, 38);
            this.btnAddCategories.TabIndex = 3;
            this.btnAddCategories.Text = "Add Categories ";
            this.btnAddCategories.UseVisualStyleBackColor = false;
            this.btnAddCategories.Click += new System.EventHandler(this.btnAddCategories_Click);
            // 
            // btnDeleteCategories
            // 
            this.btnDeleteCategories.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnDeleteCategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteCategories.Font = new System.Drawing.Font("Corbel", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDeleteCategories.ForeColor = System.Drawing.Color.White;
            this.btnDeleteCategories.Location = new System.Drawing.Point(256, 310);
            this.btnDeleteCategories.Name = "btnDeleteCategories";
            this.btnDeleteCategories.Size = new System.Drawing.Size(110, 38);
            this.btnDeleteCategories.TabIndex = 4;
            this.btnDeleteCategories.Text = "Delete Categories ";
            this.btnDeleteCategories.UseVisualStyleBackColor = false;
            this.btnDeleteCategories.Click += new System.EventHandler(this.btnDeleteCategories_Click);
            // 
            // btnRenameCategory
            // 
            this.btnRenameCategory.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnRenameCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRenameCategory.Font = new System.Drawing.Font("Corbel", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRenameCategory.ForeColor = System.Drawing.Color.White;
            this.btnRenameCategory.Location = new System.Drawing.Point(139, 310);
            this.btnRenameCategory.Name = "btnRenameCategory";
            this.btnRenameCategory.Size = new System.Drawing.Size(111, 38);
            this.btnRenameCategory.TabIndex = 5;
            this.btnRenameCategory.Text = "Rename Category";
            this.btnRenameCategory.UseVisualStyleBackColor = false;
            this.btnRenameCategory.Click += new System.EventHandler(this.btnRenameCategory_Click);
            // 
            // CategoryManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 368);
            this.Controls.Add(this.btnRenameCategory);
            this.Controls.Add(this.btnDeleteCategories);
            this.Controls.Add(this.btnAddCategories);
            this.Controls.Add(this.checkedCategoryBox);
            this.Name = "CategoryManager";
            this.Text = "Category Manager";
            this.Load += new System.EventHandler(this.CategoryManager_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CheckedListBox checkedCategoryBox;
        private Button btnAddCategories;
        private Button btnDeleteCategories;
        private Button btnRenameCategory;
    }
}