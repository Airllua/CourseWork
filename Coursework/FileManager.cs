using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class FileManager : Form
    {
        private string copiedFilePath = TextConstants.stringEmptyValue;
        private string relocatableFilePath = TextConstants.stringEmptyValue;
        private string selectedItemToRename = TextConstants.stringEmptyValue;
        private string currentSearchBarPath = TextConstants.stringEmptyValue;

        public FileManager()
        {
            InitializeComponent();

            CreateTreeView();
            CreateListView1();
            CreateListView2();

            currentSearchBarPath = SearchBar.Text;
        }


        // Создание TreeView и ListView

        private void CreateTreeView()
        {
            string[] drivers = Environment.GetLogicalDrives();

            int i = 0;

            foreach (string driver in drivers)
            {
                try
                {
                    string driverText = "Локальный диск " + driver;

                    treeView1.Nodes.Add(driver, driverText, ImageIndices.driverIndexForTreeView);

                    string[] directories = Directory.GetDirectories(@driver);

                    foreach (string folderPath in directories)
                    {
                        // Substring() - удаляет ненужные часть полного адреса
                        string folderNameInTree = folderPath.Substring(folderPath.LastIndexOf(TextConstants.backslash) + 1);

                        treeView1.Nodes[i].Nodes.Add(folderPath, folderNameInTree, ImageIndices.folderIndexForTreeView);
                    }

                    string[] files = Directory.GetFiles(@driver);

                    foreach (string filePath in files)
                    {
                        string fileNameInTree = filePath.Substring(filePath.LastIndexOf(TextConstants.backslash) + 1);

                        string fileType = filePath.Substring(filePath.LastIndexOf('.') + 1);

                        int photoIndex = ImageSelection.findAppropriateImage(fileType);

                        treeView1.Nodes[i].Nodes.Add(filePath, fileNameInTree, photoIndex);
                    }

                }
                catch { }

                i++;
            }
        }

        private void CreateListView1()
        {
            ColumnHeader columnName = new ColumnHeader();

            ColumnHeader columnСhanged = new ColumnHeader();

            ColumnHeader columnType = new ColumnHeader();

            ColumnHeader columnSize = new ColumnHeader();

            columnName.Text = "Имя";
            columnName.Width = 200;
            
            columnСhanged.Text = "Изменен";
            columnСhanged.Width = 130;
            
            columnType.Text = "Тип";
            columnType.Width = 70;
            
            columnSize.Text = "Размер";
            columnSize.Width = 73;

            listView1.Columns.Add(columnName);

            listView1.Columns.Add(columnСhanged);

            listView1.Columns.Add(columnType);

            listView1.Columns.Add(columnSize);
        }

        private void CreateListView2()
        {
            ColumnHeader columnName = new ColumnHeader();

            columnName.Text = "Этот компьютер";
            columnName.Width = 235;

            listView2.Columns.Add(columnName);

            listView2.View = View.Details;


            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            userName = userName.Substring(userName.LastIndexOf(TextConstants.backslash) + 1);


            ListViewItem listItemDownloads = new ListViewItem();

            ListViewItem listItemDocuments = new ListViewItem();

            ListViewItem listItemMusic = new ListViewItem();

            ListViewItem listItemVideos = new ListViewItem();

            ListViewItem listItemPictures = new ListViewItem();


            listItemDownloads.Name = "C:\\Users\\" + userName + "\\Downloads";
            listItemDownloads.Text = "Загрузки";
            listItemDownloads.ImageIndex = ImageIndices.downloadsIndex;

            listItemDocuments.Name = "C:\\Users\\" + userName + "\\Documents";
            listItemDocuments.Text = "Документы";
            listItemDocuments.ImageIndex = ImageIndices.documentsIndex;

            listItemMusic.Name = "C:\\Users\\" + userName + "\\Music";
            listItemMusic.Text = "Музыка";
            listItemMusic.ImageIndex = ImageIndices.musicIndex;

            listItemVideos.Name = "C:\\Users\\" + userName + "\\Videos";
            listItemVideos.Text = "Видео";
            listItemVideos.ImageIndex = ImageIndices.videoIndex;

            listItemPictures.Name = "C:\\Users\\" + userName + "\\Pictures";
            listItemPictures.Text = "Изображения";
            listItemPictures.ImageIndex = ImageIndices.pictureIndex;


            listView2.Items.Add(listItemDownloads);

            listView2.Items.Add(listItemDocuments);

            listView2.Items.Add(listItemMusic);

            listView2.Items.Add(listItemVideos);

            listView2.Items.Add(listItemPictures);
        }

        private void TreeView1_CreateTreeInTree(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                int i = 0;

                foreach (TreeNode selectedTreeFile in e.Node.Nodes)
                {
                    string[] folders = Directory.GetDirectories(@selectedTreeFile.Name);

                    foreach (string folderPath in folders)
                    {
                        string folderNameInTree = folderPath.Substring(folderPath.LastIndexOf(TextConstants.backslash) + 1);

                        e.Node.Nodes[i].Nodes.Add(folderPath, folderNameInTree);
                    }

                    string[] files = Directory.GetFiles(@selectedTreeFile.Name);

                    foreach (string filePath in files)
                    {
                        string fileNameInTree = filePath.Substring(filePath.LastIndexOf(TextConstants.backslash) + 1);

                        string fileType = filePath.Substring(filePath.LastIndexOf('.') + 1);

                        int photoIndex = ImageSelection.findAppropriateImage(fileType);

                        e.Node.Nodes[i].Nodes.Add(filePath, fileNameInTree, photoIndex);
                    }

                    i++;
                }
            }
            catch { }
        }

        private void ChangTreeViewImage(TreeViewEventArgs e)
        {
            if (File.Exists(e.Node.Name))
            {
                string fileType = e.Node.Name.Substring(e.Node.Name.LastIndexOf('.') + 1);

                int photoIndex = ImageSelection.findAppropriateImage(fileType);

                e.Node.SelectedImageIndex = photoIndex;
            }
            else if (e.Node.Name == "C:\\" || e.Node.Name == "D:\\")
            {
                e.Node.SelectedImageIndex = ImageIndices.driverIndexForTreeView;
            }
        }



        // Заполнение ListView файлами и папками

        private void FillWithFiles(string path)
        {
            try
            {
                ListViewItem listItem = new ListViewItem();

                FileInfo fileInfo = new FileInfo(path);

                string[] files = Directory.GetFiles(path);

                foreach (string filePath in files)
                {
                    string fileType = filePath.Substring(filePath.LastIndexOf('.') + 1);

                    int photoIndex = ImageSelection.findAppropriateImage(fileType);

                    string ItemName = filePath.Substring(filePath.LastIndexOf(TextConstants.backslash) + 1);

                    fileInfo = new FileInfo(filePath);

                    listItem = new ListViewItem(new string[] { ItemName, fileInfo.LastWriteTime.ToString(), 
                               "Файл", (fileInfo.Length / 1000).ToString() + " Кб" }, photoIndex);
                    listItem.Name = filePath;

                    listView1.Items.Add(listItem);
                }
            }
            catch { };
        }

        private void FillWithFolders(string path)
        {
            try
            {
                ListViewItem listItem = new ListViewItem();

                FileInfo folderInfo = new FileInfo(path);

                string[] folders = Directory.GetDirectories(path);

                foreach (string folderPath in folders)
                {
                    string ItemName = folderPath.Substring(folderPath.LastIndexOf(TextConstants.backslash) + 1);

                    folderInfo = new FileInfo(@folderPath);

                    listItem = new ListViewItem(new string[] { ItemName, folderInfo.LastWriteTime.ToString(),
                               "Папка", TextConstants.stringEmptyValue }, ImageIndices.folderIndex);
                    listItem.Name = folderPath;

                    listView1.Items.Add(listItem);
                }

                currentSearchBarPath = SearchBar.Text;
            }
            catch (DirectoryNotFoundException)
            {
                SearchBar.Text = currentSearchBarPath;

                FillOrRefreshListView();

                MessageBox.Show(TextConstants.pathEror, TextConstants.error,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException)
            {
                SearchBar.Text = currentSearchBarPath;

                FillOrRefreshListView();

                MessageBox.Show(TextConstants.accesError, TextConstants.error,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                SearchBar.Text = currentSearchBarPath;

                FillOrRefreshListView();

                MessageBox.Show(TextConstants.error, TextConstants.error,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
        }

        private void FillOrRefreshListView()
        {
            listView1.Items.Clear();

            FillWithFolders(SearchBar.Text);
            FillWithFiles(SearchBar.Text);
        }


        // Работа элементов toolStrip

        private void ButtonBackClick(object sender, EventArgs e)
        {
            string tempPath = SearchBar.Text;

            if (tempPath[tempPath.Length - 1] == Convert.ToChar(TextConstants.backslash)
            && tempPath[tempPath.Length - 2] == ':')
            {
                return;
            }

            tempPath = TextChanges.RemovingUnnecessaryInPath(tempPath);

            SearchBar.Text = tempPath;

            FillOrRefreshListView();
        }

        private void ToolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                FillOrRefreshListView();
            }
        }

        private void ButtonSearchClick(object sender, EventArgs e)
        {
            FillOrRefreshListView();
        }



        // Переход по пути, после выбора папки из TreeView или ListView

        private void ListView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string currentPath = listView1.SelectedItems[0].Name;

            if (Directory.Exists(currentPath))
            {
                SearchBar.Text = currentPath;

                FillOrRefreshListView();
            }
            else
            {
                currentPath = listView1.SelectedItems[0].Name;

                Process applicationStart = new Process();

                applicationStart.StartInfo.FileName = currentPath;
                applicationStart.Start();
            }
        }

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ChangTreeViewImage(e);

            listView1.View = View.Details;

            string currentPath = e.Node.Name;

            if (Directory.Exists(currentPath))
            {
                SearchBar.Text = currentPath;

                FillOrRefreshListView();
            }
        }

        private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string currentPath = treeView1.SelectedNode.Name;

            if (File.Exists(currentPath))
            {
                Process applicationStart = new Process();

                applicationStart.StartInfo.FileName = currentPath;
                applicationStart.Start();
            }
        }

        private void listView2_MouseClick(object sender, MouseEventArgs e)
        {
            string currentPath = listView2.SelectedItems[0].Name;

            SearchBar.Text = currentPath;

            FillOrRefreshListView();
        }

        private void ListView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    RMBOnfile.Show(listView1, e.Location);
                }
                else
                {
                    RMBOnEmptySpace.Show(listView1, e.Location);
                }
            }
        }

        // Изменения в TreeView после изменений в ListView

        private void AddInTreeViewAfterCreat(string filePath, int imageIndex)
        {
            TreeNode[] detectedItem = new TreeNode[1];

            detectedItem = treeView1.Nodes.Find(SearchBar.Text, true);

            string fileName = filePath.Substring(filePath.LastIndexOf(TextConstants.backslash) + 1);

            detectedItem[0].Nodes.Add(filePath, fileName, imageIndex);
        }

        public void DeleteInTreeViewAfterDelet(string pathOfDeleteFile)
        {
            try
            {
                TreeNode[] deletItem = new TreeNode[0];

                deletItem = treeView1.Nodes.Find(pathOfDeleteFile, true);

                treeView1.Nodes.Remove(deletItem[0]);
            }
            catch { };
        }

        public void RenameInTreeViewAndListView()
        {
            string changeInTreeView = WorkWithFile.ChangeName(selectedItemToRename, TextBoxToRename.Text);

            if (changeInTreeView != TextConstants.stringEmptyValue)
            {
                DeleteInTreeViewAfterDelet(listView1.SelectedItems[0].Name);

                FillOrRefreshListView();

                TextBoxToRename.Text = TextConstants.stringEmptyValue;

                string fileType = changeInTreeView.Substring(changeInTreeView.LastIndexOf('.') + 1);

                int photoIndex = ImageSelection.findAppropriateImage(fileType);

                if (Directory.Exists(changeInTreeView))
                {
                    photoIndex = ImageIndices.folderIndex;
                }

                AddInTreeViewAfterCreat(changeInTreeView, photoIndex);
            }
        }

        // Методы ContextMenu (ПКМ по файлу или папке ListView)

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WorkWithFile.DeleteFile(listView1.SelectedItems[0].Name);

            DeleteInTreeViewAfterDelet(listView1.SelectedItems[0].Name);

            FillOrRefreshListView();
        }

        private void MoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copiedFilePath = TextConstants.stringEmptyValue;
            relocatableFilePath = listView1.SelectedItems[0].Name;
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            relocatableFilePath = TextConstants.stringEmptyValue;
            copiedFilePath = listView1.SelectedItems[0].Name;
        }

        private void InsertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (relocatableFilePath != TextConstants.stringEmptyValue)
            {
                WorkWithFile.RelocateFile(SearchBar.Text, relocatableFilePath);

                DeleteInTreeViewAfterDelet(relocatableFilePath);

                string fileType = relocatableFilePath.Substring(relocatableFilePath.LastIndexOf('.') + 1);

                int photoIndex = ImageSelection.findAppropriateImage(fileType);

                AddInTreeViewAfterCreat(relocatableFilePath, photoIndex);

                relocatableFilePath = TextConstants.stringEmptyValue;
            }
            if (copiedFilePath != TextConstants.stringEmptyValue)
            {
                WorkWithFile.CopyFile(SearchBar.Text, copiedFilePath);

                string fileType = copiedFilePath.Substring(copiedFilePath.LastIndexOf('.') + 1);

                int photoIndex = ImageSelection.findAppropriateImage(fileType);

                AddInTreeViewAfterCreat(copiedFilePath, photoIndex);

                copiedFilePath = TextConstants.stringEmptyValue;
            }

            FillOrRefreshListView();
        }

        private void PrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();

            printDocument.DocumentName = listView1.SelectedItems[0].Name;
            printDocument.Print();
        }

        private void RenameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedItemToRename = listView1.SelectedItems[0].Name;
        }



        // Методы ContextMenu1 (ПКМ по пустому место ListView)

        private void CreateTextDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fileName = SearchBar.Text + TextConstants.newTextDocument;

            File.Create(fileName).Close();

            FillOrRefreshListView();

            AddInTreeViewAfterCreat(fileName, ImageIndices.txtIndex);
        }

        private void CreateDocumentMicrosoftWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fileName = SearchBar.Text + TextConstants.newDocumentWord;

            File.Create(fileName).Close();

            FillOrRefreshListView();

            AddInTreeViewAfterCreat(fileName, ImageIndices.docxIndex);
        }

        private void CreatePresentationPowerPointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fileName = SearchBar.Text + TextConstants.newPresentationPowerPoint;

            File.Create(fileName).Close();

            FillOrRefreshListView();

            AddInTreeViewAfterCreat(fileName, ImageIndices.pptxIndex);
        }

        private void CreateFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string folderPath = SearchBar.Text + TextConstants.newFolder;

            Directory.CreateDirectory(folderPath);

            FillOrRefreshListView();

            AddInTreeViewAfterCreat(folderPath, ImageIndices.folderIndex);
        }


        // Проверка нажатых кнопок

        private void ListView1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                
                //if (e.KeyData == (Keys.Control | Keys.C))
                //{
                //    relocatableFilePath = TextConstants.stringEmptyValue;
                //    copiedFilePath = listView1.SelectedItems[0].Name;
                //}
                //else if (e.KeyData == (Keys.Control | Keys.V))
                //{
                //    WorkWithFile.CopyFile(SearchBar.Text, copiedFilePath);

                //    string fileType = copiedFilePath.Substring(copiedFilePath.LastIndexOf('.') + 1);

                //    int photoIndex = ImageSelection.findAppropriateImage(fileType);

                //    AddInTreeViewAfterCreat(copiedFilePath, photoIndex);

                //    copiedFilePath = TextConstants.stringEmptyValue;
                //}
                if (e.KeyCode == Keys.Delete)
                {
                    WorkWithFile.DeleteFile(listView1.SelectedItems[0].Name);

                    DeleteInTreeViewAfterDelet(listView1.SelectedItems[0].Name);
                }
            }
            catch { };

            FillOrRefreshListView();
        }

        private void MenuRMBOnfile_Opening(object sender, CancelEventArgs e)
        {
            if (listView1.SelectedItems[0].Name.Contains(".txt") == true ||
                listView1.SelectedItems[0].Name.Contains(".docx") == true)
            {
                PrintToolStripMenuItem.Enabled = true;
            }
            else
            {
                PrintToolStripMenuItem.Enabled = false;
            }
        }

        private void MenuRMBOnEmptySpace_Opening(object sender, CancelEventArgs e)
        {
            if (copiedFilePath == TextConstants.stringEmptyValue &&
                relocatableFilePath == TextConstants.stringEmptyValue)
            {
                InsertToolStripMenuItem.Enabled = false;
            }
            else
            {
                InsertToolStripMenuItem.Enabled = true;
            }
        }

        private void ToolStripTextBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                RenameInTreeViewAndListView();
            }
        }

        private void ListView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (TextBoxToRename.Text != TextConstants.stringEmptyValue)
            {
                RenameInTreeViewAndListView();
            }
        }

        public void InformationAboutProgram_Click(object sender, EventArgs e)
        {
            MessageBox.Show(TextConstants.informationAboutProgramm, "Информация о программе", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
