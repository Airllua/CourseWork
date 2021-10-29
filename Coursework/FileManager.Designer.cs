
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
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.ButtonSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.ButtonBack = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.УдалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ПереместитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.КопироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.переименоватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.ПечатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ВставитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.СоздатьПапкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.СоздатьТекстовыйДокументToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.документMicrosoftWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pptxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listView1 = new System.Windows.Forms.ListView();
            this.toolStrip2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(0, 30);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(318, 453);
            this.treeView1.TabIndex = 1;
            this.treeView1.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_CreateTreeInTree);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "directory.jpg");
            this.imageList1.Images.SetKeyName(1, "file.png");
            this.imageList1.Images.SetKeyName(2, "pngwing.com (1).png");
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
            this.imageList2.Images.SetKeyName(8, "ppt.png");
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ButtonSearch,
            this.toolStripTextBox1,
            this.ButtonBack});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(974, 27);
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
            this.ButtonSearch.Click += new System.EventHandler(this.ButtonSearchClick);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(565, 27);
            this.toolStripTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBox1_KeyDown);
            // 
            // ButtonBack
            // 
            this.ButtonBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonBack.Image = ((System.Drawing.Image)(resources.GetObject("ButtonBack.Image")));
            this.ButtonBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonBack.Name = "ButtonBack";
            this.ButtonBack.Size = new System.Drawing.Size(29, 24);
            this.ButtonBack.Text = "toolStripButton1";
            this.ButtonBack.Click += new System.EventHandler(this.ButtonBackClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.УдалитьToolStripMenuItem,
            this.ПереместитьToolStripMenuItem,
            this.КопироватьToolStripMenuItem,
            this.переименоватьToolStripMenuItem,
            this.ПечатьToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(191, 124);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // УдалитьToolStripMenuItem
            // 
            this.УдалитьToolStripMenuItem.Name = "УдалитьToolStripMenuItem";
            this.УдалитьToolStripMenuItem.Size = new System.Drawing.Size(190, 24);
            this.УдалитьToolStripMenuItem.Text = "Удалить";
            this.УдалитьToolStripMenuItem.Click += new System.EventHandler(this.УдалитьToolStripMenuItem_Click);
            // 
            // ПереместитьToolStripMenuItem
            // 
            this.ПереместитьToolStripMenuItem.Name = "ПереместитьToolStripMenuItem";
            this.ПереместитьToolStripMenuItem.Size = new System.Drawing.Size(190, 24);
            this.ПереместитьToolStripMenuItem.Text = "Переместить";
            this.ПереместитьToolStripMenuItem.Click += new System.EventHandler(this.ПереместитьToolStripMenuItem_Click);
            // 
            // КопироватьToolStripMenuItem
            // 
            this.КопироватьToolStripMenuItem.Name = "КопироватьToolStripMenuItem";
            this.КопироватьToolStripMenuItem.Size = new System.Drawing.Size(190, 24);
            this.КопироватьToolStripMenuItem.Text = "Копировать";
            this.КопироватьToolStripMenuItem.Click += new System.EventHandler(this.КопироватьToolStripMenuItem_Click);
            // 
            // переименоватьToolStripMenuItem
            // 
            this.переименоватьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox2});
            this.переименоватьToolStripMenuItem.Name = "переименоватьToolStripMenuItem";
            this.переименоватьToolStripMenuItem.Size = new System.Drawing.Size(190, 24);
            this.переименоватьToolStripMenuItem.Text = "Переименовать";
            this.переименоватьToolStripMenuItem.Click += new System.EventHandler(this.ПереименоватьToolStripMenuItem_Click);
            // 
            // toolStripTextBox2
            // 
            this.toolStripTextBox2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox2.Name = "toolStripTextBox2";
            this.toolStripTextBox2.Size = new System.Drawing.Size(100, 27);
            this.toolStripTextBox2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBox2_KeyUp);
            // 
            // ПечатьToolStripMenuItem
            // 
            this.ПечатьToolStripMenuItem.Name = "ПечатьToolStripMenuItem";
            this.ПечатьToolStripMenuItem.Size = new System.Drawing.Size(190, 24);
            this.ПечатьToolStripMenuItem.Text = "Печать";
            this.ПечатьToolStripMenuItem.Click += new System.EventHandler(this.ПечатьToolStripMenuItem_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ВставитьToolStripMenuItem,
            this.создатьФайлToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(211, 80);
            this.contextMenuStrip2.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip2_Opening);
            // 
            // ВставитьToolStripMenuItem
            // 
            this.ВставитьToolStripMenuItem.Name = "ВставитьToolStripMenuItem";
            this.ВставитьToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.ВставитьToolStripMenuItem.Text = "Вставить";
            this.ВставитьToolStripMenuItem.Click += new System.EventHandler(this.ВставитьToolStripMenuItem_Click);
            // 
            // создатьФайлToolStripMenuItem
            // 
            this.создатьФайлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.СоздатьПапкуToolStripMenuItem,
            this.СоздатьТекстовыйДокументToolStripMenuItem,
            this.документMicrosoftWordToolStripMenuItem,
            this.pptxToolStripMenuItem});
            this.создатьФайлToolStripMenuItem.Name = "создатьФайлToolStripMenuItem";
            this.создатьФайлToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.создатьФайлToolStripMenuItem.Text = "Создать";
            // 
            // СоздатьПапкуToolStripMenuItem
            // 
            this.СоздатьПапкуToolStripMenuItem.Name = "СоздатьПапкуToolStripMenuItem";
            this.СоздатьПапкуToolStripMenuItem.Size = new System.Drawing.Size(328, 26);
            this.СоздатьПапкуToolStripMenuItem.Text = "Папку";
            this.СоздатьПапкуToolStripMenuItem.Click += new System.EventHandler(this.СоздатьПапкуToolStripMenuItem_Click);
            // 
            // СоздатьТекстовыйДокументToolStripMenuItem
            // 
            this.СоздатьТекстовыйДокументToolStripMenuItem.Name = "СоздатьТекстовыйДокументToolStripMenuItem";
            this.СоздатьТекстовыйДокументToolStripMenuItem.Size = new System.Drawing.Size(328, 26);
            this.СоздатьТекстовыйДокументToolStripMenuItem.Text = "Текстовый документ";
            this.СоздатьТекстовыйДокументToolStripMenuItem.Click += new System.EventHandler(this.СоздатьТекстовыйДокументToolStripMenuItem_Click);
            // 
            // документMicrosoftWordToolStripMenuItem
            // 
            this.документMicrosoftWordToolStripMenuItem.Name = "документMicrosoftWordToolStripMenuItem";
            this.документMicrosoftWordToolStripMenuItem.Size = new System.Drawing.Size(328, 26);
            this.документMicrosoftWordToolStripMenuItem.Text = "Документ Microsoft Word";
            this.документMicrosoftWordToolStripMenuItem.Click += new System.EventHandler(this.СоздатьДокументWordMicrosoftWordToolStripMenuItem_Click);
            // 
            // pptxToolStripMenuItem
            // 
            this.pptxToolStripMenuItem.Name = "pptxToolStripMenuItem";
            this.pptxToolStripMenuItem.Size = new System.Drawing.Size(328, 26);
            this.pptxToolStripMenuItem.Text = "Презентация Microsoft PowerPoint";
            this.pptxToolStripMenuItem.Click += new System.EventHandler(this.СоздатьПрезинтациюPowerPointToolStripMenuItem_Click);
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
            this.listView1.Size = new System.Drawing.Size(658, 453);
            this.listView1.SmallImageList = this.imageList2;
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView1_KeyDown);
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            this.listView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDown);
            this.listView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseUp);
            // 
            // FileManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(974, 483);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.treeView1);
            this.MinimumSize = new System.Drawing.Size(924, 485);
            this.Name = "FileManager";
            this.Text = "Файловый менеджер";
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem УдалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ВставитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ПереместитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem КопироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьФайлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem СоздатьПапкуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem СоздатьТекстовыйДокументToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem переименоватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ПечатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox2;
        private System.Windows.Forms.ToolStripMenuItem документMicrosoftWordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pptxToolStripMenuItem;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ToolStripButton ButtonSearch;
        private System.Windows.Forms.ToolStripButton ButtonBack;
    }
}

