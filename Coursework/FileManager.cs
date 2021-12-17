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
        private string selectedLocationPath = TextConstants.stringEmptyValue;
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

                        int photoIndex = SelectionOfImage(fileType);

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

                        int photoIndex = SelectionOfImage(fileType);

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

                int photoIndex = SelectionOfImage(fileType);

                e.Node.SelectedImageIndex = photoIndex;
            }
            else if (e.Node.Name == "C:\\" || e.Node.Name == "D:\\")
            {
                e.Node.SelectedImageIndex = ImageIndices.driverIndexForTreeView;
            }
        }



        // Заполнение ListView файлами и папками

        private void FillWithDirectories(string path)
        {
            try
            {
                ListViewItem listItem = new ListViewItem();

                FileInfo fileInfo = new FileInfo(path);

                string[] files = Directory.GetFiles(path);

                foreach (string filePath in files)
                {
                    string fileType = filePath.Substring(filePath.LastIndexOf('.') + 1);

                    int photoIndex = SelectionOfImage(fileType);

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
            };
        }

        private int SelectionOfImage(string fileType)
        {
            int photoIndex;

            switch (fileType)
            {
                case "docx":
                    photoIndex = ImageIndices.docxIndex;
                    break;

                case "jpg":
                case "png":
                case "PNG":
                    photoIndex = ImageIndices.photoIndex;
                    break;

                case "txt":
                    photoIndex = ImageIndices.txtIndex;
                    break;

                case "pdf":
                    photoIndex = ImageIndices.pdfIndex;
                    break;

                case "exe":
                    photoIndex = ImageIndices.exeIndex;
                    break;

                case "mp3":
                case "mp4":
                    photoIndex = ImageIndices.mpIndex;
                    break;

                case "pptx":
                    photoIndex = ImageIndices.pptxIndex;
                    break;

                case "accdb":
                    photoIndex = ImageIndices.accdbIndex;
                    break;

                default:
                    photoIndex = ImageIndices.fileIndex;
                    break;
            }

            return photoIndex;
        }

        private void FillOrRefreshListView()
        {
            string currentPath = SearchBar.Text;

            listView1.Items.Clear();

            FillWithFolders(currentPath);
            FillWithDirectories(currentPath);
        }


        // Работа элементов toolStrip

        private string RemovingUnnecessaryInPath(string tempString)
        {
            if (tempString[tempString.Length - 1] == Convert.ToChar(TextConstants.backslash))
            {
                do
                {
                    tempString = tempString.Remove(tempString.Length - 1, 1);
                }
                while (tempString[tempString.Length - 1] != Convert.ToChar(TextConstants.backslash));
            }
            else
            {
                while (tempString[tempString.Length - 1] != Convert.ToChar(TextConstants.backslash))
                {
                    tempString = tempString.Remove(tempString.Length - 1, 1);
                }
            }

            return tempString;
        }
        private void ButtonBackClick(object sender, EventArgs e)
        {
            string tempPath = SearchBar.Text;

            if (tempPath[tempPath.Length - 1] == Convert.ToChar(TextConstants.backslash)
            && tempPath[tempPath.Length - 2] == ':')
            {
                return;
            }

            tempPath = RemovingUnnecessaryInPath(tempPath);

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

        // Операции с файлами и папками

        private void DeleteFile(string deletePath)
        {
            try
            {
                if (Directory.Exists(deletePath))
                {
                    Directory.Delete(deletePath, true);
                }
                else
                {
                    File.Delete(deletePath);
                }
            }
            catch 
            {
                MessageBox.Show(TextConstants.errorCause, TextConstants.error, 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
        }

        private void RelocateFile()
        {
            try
            {
                selectedLocationPath = SearchBar.Text;

                if (Directory.Exists(relocatableFilePath))
                {
                    selectedLocationPath += relocatableFilePath.Substring(relocatableFilePath.LastIndexOf(TextConstants.backslash));

                    Directory.Move(relocatableFilePath, selectedLocationPath);
                }
                else
                {
                    File.Move(relocatableFilePath, selectedLocationPath + 
                        relocatableFilePath.Substring(relocatableFilePath.LastIndexOf(TextConstants.backslash)));
                }
            }
            catch
            {
                MessageBox.Show(TextConstants.errorCause, TextConstants.error,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            };

            relocatableFilePath = TextConstants.stringEmptyValue;
        }


        void CopyDirectory(string pathFromDirectory, string pathToDirectory)
        {
            Directory.CreateDirectory(pathToDirectory);

            foreach (string filePath in Directory.GetFiles(pathFromDirectory))
            {
                string correctFinalPath = pathToDirectory + TextConstants.backslash + Path.GetFileName(filePath);

                File.Copy(filePath, correctFinalPath);
            }

            foreach (string folderPath in Directory.GetDirectories(pathFromDirectory))
            {
                CopyDirectory(folderPath, pathToDirectory + TextConstants.backslash + Path.GetFileName(folderPath));
            }
        }


        private void CopyFile()
        { 
            try
            {
                selectedLocationPath = SearchBar.Text;

                if (Directory.Exists(copiedFilePath))
                {
                    string createdNewDirectory = selectedLocationPath + 
                        copiedFilePath.Substring(copiedFilePath.LastIndexOf(TextConstants.backslash));

                    Directory.CreateDirectory(createdNewDirectory);

                    CopyDirectory(copiedFilePath, createdNewDirectory);
                }
                else
                {
                    selectedLocationPath += copiedFilePath.Substring(copiedFilePath.LastIndexOf(TextConstants.backslash));

                    File.Copy(copiedFilePath, selectedLocationPath, true);
                }
            }
            catch
            {
                MessageBox.Show(TextConstants.errorCause, TextConstants.error, 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            };

            copiedFilePath = TextConstants.stringEmptyValue;
        }

        private void ChangeName()
        {
            try
            {
                string fileType = TextConstants.stringEmptyValue;

                if (File.Exists(selectedItemToRename))
                {
                    fileType = selectedItemToRename.Substring(selectedItemToRename.LastIndexOf('.'));
                }

                string tempPath = selectedItemToRename;

                tempPath = RemovingUnnecessaryInPath(tempPath);

                Directory.Move(selectedItemToRename, Path.Combine(tempPath, TextBoxToRename.Text + fileType));

                FillOrRefreshListView();
            }
            catch 
            {
                 MessageBox.Show(TextConstants.errorCause, TextConstants.error,
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            };

            TextBoxToRename.Text = TextConstants.stringEmptyValue;
        }



        // Методы ContextMenu (ПКМ по файлу или папке ListView)

        private void ListView1_MouseUp(object sender, MouseEventArgs e)
        {
            ListView senderListView = sender as ListView;

            if (e.Button == MouseButtons.Right)
            {
                if (senderListView.SelectedItems.Count > 0)
                {
                    RMBOnfile.Show(senderListView, e.Location);
                }
                else
                {
                    RMBOnEmptySpace.Show(senderListView, e.Location);
                }
            }
        }

        private void DeleteInTreeViewAfterDelet()
        {
            try
            {
                TreeNode[] deletItem = new TreeNode[0];

                deletItem = treeView1.Nodes.Find(listView1.SelectedItems[0].Name, true);

                treeView1.Nodes.Remove(deletItem[0]);
            }
            catch { };
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteFile(listView1.SelectedItems[0].Name);

            DeleteInTreeViewAfterDelet();

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
                RelocateFile();
            }
            if (copiedFilePath != TextConstants.stringEmptyValue)
            {
                CopyFile();
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

        private void AddInTreeViewAfterCreat(string filePath, int imageIndex)
        {
            TreeNode[] detectedItem = new TreeNode[1];

            detectedItem = treeView1.Nodes.Find(SearchBar.Text, true);

            string fileName = filePath.Substring(filePath.LastIndexOf(TextConstants.backslash) + 1);

            detectedItem[0].Nodes.Add(filePath, fileName, imageIndex);
        }



        // Проверка нажатых кнопок

        private void ListView1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    DeleteFile(listView1.SelectedItems[0].Name);

                    DeleteInTreeViewAfterDelet();
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
                ChangeName();
            }
        }

        private void ListView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (TextBoxToRename.Text != TextConstants.stringEmptyValue)
            {
                ChangeName();
            }
        }

        public void InformationAboutProgram_Click(object sender, EventArgs e)
        {
            MessageBox.Show(TextConstants.informationAboutProgramm, "Информация о программе", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
