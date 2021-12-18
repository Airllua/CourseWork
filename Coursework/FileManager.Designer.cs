namespace CourseWork
{
    partial class FileManager
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileManager));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.ButtonSearch = new System.Windows.Forms.ToolStripButton();
            this.SearchBar = new System.Windows.Forms.ToolStripTextBox();
            this.ButtonBack = new System.Windows.Forms.ToolStripButton();
            this.InformationAboutProgramm = new System.Windows.Forms.ToolStripButton();
            this.RMBOnfile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RenameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TextBoxToRename = new System.Windows.Forms.ToolStripTextBox();
            this.PrintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RMBOnEmptySpace = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.InsertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateTextDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateDocumentMicrosoftWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreatePresentationPowerPointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listView1 = new System.Windows.Forms.ListView();
            this.listView2 = new System.Windows.Forms.ListView();
            this.toolStrip2.SuspendLayout();
            this.RMBOnfile.SuspendLayout();
            this.RMBOnEmptySpace.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList2;
            this.treeView1.Location = new System.Drawing.Point(0, 180);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(318, 258);
            this.treeView1.TabIndex = 1;
            this.treeView1.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.TreeView1_CreateTreeInTree);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView1_AfterSelect);
            this.treeView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDoubleClick);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "directory.jpg");
            this.imageList2.Images.SetKeyName(1, "file.png");
            this.imageList2.Images.SetKeyName(2, "1.png");
            this.imageList2.Images.SetKeyName(3, "2.png");
            this.imageList2.Images.SetKeyName(4, "3.png");
            this.imageList2.Images.SetKeyName(5, "4.jpg");
            this.imageList2.Images.SetKeyName(6, "6.png");
            this.imageList2.Images.SetKeyName(7, "7.png");
            this.imageList2.Images.SetKeyName(8, "ppt-1517.png");
            this.imageList2.Images.SetKeyName(9, "disk.png");
            this.imageList2.Images.SetKeyName(10, "accdb.png");
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "download.png");
            this.imageList1.Images.SetKeyName(1, "document.png");
            this.imageList1.Images.SetKeyName(2, "music.png");
            this.imageList1.Images.SetKeyName(3, "video.png");
            this.imageList1.Images.SetKeyName(4, "picture.png");
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ButtonSearch,
            this.SearchBar,
            this.ButtonBack,
            this.InformationAboutProgramm});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(973, 27);
            this.toolStrip2.TabIndex = 3;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // ButtonSearch
            // 
            this.ButtonSearch.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ButtonSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonSearch.Image = ((System.Drawing.Image)(resources.GetObject("ButtonSearch.Image")));
            this.ButtonSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonSearch.Name = "ButtonSearch";
            this.ButtonSearch.Size = new System.Drawing.Size(29, 24);
            this.ButtonSearch.Text = "Поиск";
            this.ButtonSearch.Click += new System.EventHandler(this.ButtonSearchClick);
            // 
            // SearchBar
            // 
            this.SearchBar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SearchBar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.SearchBar.Name = "SearchBar";
            this.SearchBar.Size = new System.Drawing.Size(565, 27);
            this.SearchBar.Text = "Поисковая страка";
            this.SearchBar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ToolStripTextBox1_KeyDown);
            // 
            // ButtonBack
            // 
            this.ButtonBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonBack.Image = ((System.Drawing.Image)(resources.GetObject("ButtonBack.Image")));
            this.ButtonBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonBack.Name = "ButtonBack";
            this.ButtonBack.Size = new System.Drawing.Size(29, 24);
            this.ButtonBack.Text = "Выход из вложенной папки";
            this.ButtonBack.Click += new System.EventHandler(this.ButtonBackClick);
            // 
            // InformationAboutProgramm
            // 
            this.InformationAboutProgramm.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.InformationAboutProgramm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.InformationAboutProgramm.Image = ((System.Drawing.Image)(resources.GetObject("InformationAboutProgramm.Image")));
            this.InformationAboutProgramm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.InformationAboutProgramm.Name = "InformationAboutProgramm";
            this.InformationAboutProgramm.Size = new System.Drawing.Size(29, 24);
            this.InformationAboutProgramm.Text = "Информация о программе";
            this.InformationAboutProgramm.Click += new System.EventHandler(this.InformationAboutProgram_Click);
            // 
            // RMBOnfile
            // 
            this.RMBOnfile.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.RMBOnfile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeleteToolStripMenuItem,
            this.MoveToolStripMenuItem,
            this.CopyToolStripMenuItem,
            this.RenameToolStripMenuItem,
            this.PrintToolStripMenuItem});
            this.RMBOnfile.Name = "RMBOnfile";
            this.RMBOnfile.Size = new System.Drawing.Size(195, 134);
            this.RMBOnfile.Opening += new System.ComponentModel.CancelEventHandler(this.MenuRMBOnfile_Opening);
            // 
            // DeleteToolStripMenuItem
            // 
            this.DeleteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("DeleteToolStripMenuItem.Image")));
            this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            this.DeleteToolStripMenuItem.Size = new System.Drawing.Size(194, 26);
            this.DeleteToolStripMenuItem.Text = "Удалить";
            this.DeleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // MoveToolStripMenuItem
            // 
            this.MoveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("MoveToolStripMenuItem.Image")));
            this.MoveToolStripMenuItem.Name = "MoveToolStripMenuItem";
            this.MoveToolStripMenuItem.Size = new System.Drawing.Size(194, 26);
            this.MoveToolStripMenuItem.Text = "Переместить";
            this.MoveToolStripMenuItem.Click += new System.EventHandler(this.MoveToolStripMenuItem_Click);
            // 
            // CopyToolStripMenuItem
            // 
            this.CopyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("CopyToolStripMenuItem.Image")));
            this.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem";
            this.CopyToolStripMenuItem.Size = new System.Drawing.Size(194, 26);
            this.CopyToolStripMenuItem.Text = "Копировать";
            this.CopyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
            // 
            // RenameToolStripMenuItem
            // 
            this.RenameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TextBoxToRename});
            this.RenameToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("RenameToolStripMenuItem.Image")));
            this.RenameToolStripMenuItem.Name = "RenameToolStripMenuItem";
            this.RenameToolStripMenuItem.Size = new System.Drawing.Size(194, 26);
            this.RenameToolStripMenuItem.Text = "Переименовать";
            this.RenameToolStripMenuItem.Click += new System.EventHandler(this.RenameToolStripMenuItem_Click);
            // 
            // TextBoxToRename
            // 
            this.TextBoxToRename.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TextBoxToRename.Name = "TextBoxToRename";
            this.TextBoxToRename.Size = new System.Drawing.Size(100, 27);
            this.TextBoxToRename.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ToolStripTextBox2_KeyUp);
            // 
            // PrintToolStripMenuItem
            // 
            this.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem";
            this.PrintToolStripMenuItem.Size = new System.Drawing.Size(194, 26);
            this.PrintToolStripMenuItem.Text = "Печать";
            this.PrintToolStripMenuItem.Click += new System.EventHandler(this.PrintToolStripMenuItem_Click);
            // 
            // RMBOnEmptySpace
            // 
            this.RMBOnEmptySpace.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.RMBOnEmptySpace.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InsertToolStripMenuItem,
            this.создатьФайлToolStripMenuItem});
            this.RMBOnEmptySpace.Name = "RMBOnEmptySpace";
            this.RMBOnEmptySpace.Size = new System.Drawing.Size(144, 56);
            this.RMBOnEmptySpace.Opening += new System.ComponentModel.CancelEventHandler(this.MenuRMBOnEmptySpace_Opening);
            // 
            // InsertToolStripMenuItem
            // 
            this.InsertToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("InsertToolStripMenuItem.Image")));
            this.InsertToolStripMenuItem.Name = "InsertToolStripMenuItem";
            this.InsertToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.InsertToolStripMenuItem.Text = "Вставить";
            this.InsertToolStripMenuItem.Click += new System.EventHandler(this.InsertToolStripMenuItem_Click);
            // 
            // создатьФайлToolStripMenuItem
            // 
            this.создатьФайлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateFolderToolStripMenuItem,
            this.CreateTextDocumentToolStripMenuItem,
            this.CreateDocumentMicrosoftWordToolStripMenuItem,
            this.CreatePresentationPowerPointToolStripMenuItem});
            this.создатьФайлToolStripMenuItem.Name = "создатьФайлToolStripMenuItem";
            this.создатьФайлToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.создатьФайлToolStripMenuItem.Text = "Создать";
            // 
            // CreateFolderToolStripMenuItem
            // 
            this.CreateFolderToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("CreateFolderToolStripMenuItem.Image")));
            this.CreateFolderToolStripMenuItem.Name = "CreateFolderToolStripMenuItem";
            this.CreateFolderToolStripMenuItem.Size = new System.Drawing.Size(328, 26);
            this.CreateFolderToolStripMenuItem.Text = "Папку";
            this.CreateFolderToolStripMenuItem.Click += new System.EventHandler(this.CreateFolderToolStripMenuItem_Click);
            // 
            // CreateTextDocumentToolStripMenuItem
            // 
            this.CreateTextDocumentToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("CreateTextDocumentToolStripMenuItem.Image")));
            this.CreateTextDocumentToolStripMenuItem.Name = "CreateTextDocumentToolStripMenuItem";
            this.CreateTextDocumentToolStripMenuItem.Size = new System.Drawing.Size(328, 26);
            this.CreateTextDocumentToolStripMenuItem.Text = "Текстовый документ";
            this.CreateTextDocumentToolStripMenuItem.Click += new System.EventHandler(this.CreateTextDocumentToolStripMenuItem_Click);
            // 
            // CreateDocumentMicrosoftWordToolStripMenuItem
            // 
            this.CreateDocumentMicrosoftWordToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("CreateDocumentMicrosoftWordToolStripMenuItem.Image")));
            this.CreateDocumentMicrosoftWordToolStripMenuItem.Name = "CreateDocumentMicrosoftWordToolStripMenuItem";
            this.CreateDocumentMicrosoftWordToolStripMenuItem.Size = new System.Drawing.Size(328, 26);
            this.CreateDocumentMicrosoftWordToolStripMenuItem.Text = "Документ Microsoft Word";
            this.CreateDocumentMicrosoftWordToolStripMenuItem.Click += new System.EventHandler(this.CreateDocumentMicrosoftWordToolStripMenuItem_Click);
            // 
            // CreatePresentationPowerPointToolStripMenuItem
            // 
            this.CreatePresentationPowerPointToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("CreatePresentationPowerPointToolStripMenuItem.Image")));
            this.CreatePresentationPowerPointToolStripMenuItem.Name = "CreatePresentationPowerPointToolStripMenuItem";
            this.CreatePresentationPowerPointToolStripMenuItem.Size = new System.Drawing.Size(328, 26);
            this.CreatePresentationPowerPointToolStripMenuItem.Text = "Презентация Microsoft PowerPoint";
            this.CreatePresentationPowerPointToolStripMenuItem.Click += new System.EventHandler(this.CreatePresentationPowerPointToolStripMenuItem_Click);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listView1.HideSelection = false;
            this.listView1.LargeImageList = this.imageList2;
            this.listView1.Location = new System.Drawing.Point(316, 30);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(657, 408);
            this.listView1.SmallImageList = this.imageList2;
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListView1_KeyDown);
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListView1_MouseDoubleClick);
            this.listView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ListView1_MouseDown);
            this.listView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ListView1_MouseUp);
            // 
            // listView2
            // 
            this.listView2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(0, 30);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(318, 155);
            this.listView2.SmallImageList = this.imageList1;
            this.listView2.TabIndex = 4;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView2_MouseClick);
            // 
            // FileManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(973, 438);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.treeView1);
            this.MinimumSize = new System.Drawing.Size(991, 485);
            this.Name = "FileManager";
            this.Text = "Файловый менеджер";
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.RMBOnfile.ResumeLayout(false);
            this.RMBOnEmptySpace.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripTextBox SearchBar;
        private System.Windows.Forms.ContextMenuStrip RMBOnfile;
        private System.Windows.Forms.ContextMenuStrip RMBOnEmptySpace;
        private System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem InsertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MoveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CopyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьФайлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CreateFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CreateTextDocumentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RenameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PrintToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox TextBoxToRename;
        private System.Windows.Forms.ToolStripMenuItem CreateDocumentMicrosoftWordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CreatePresentationPowerPointToolStripMenuItem;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ToolStripButton ButtonSearch;
        private System.Windows.Forms.ToolStripButton ButtonBack;
        private System.Windows.Forms.ToolStripButton InformationAboutProgramm;
        private System.Windows.Forms.ListView listView2;
    }
}