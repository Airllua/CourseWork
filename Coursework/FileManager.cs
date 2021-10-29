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
        private string copiedFilePath = "";
        private string relocatableFilePath = "";
        private string selectedLocationPath = "";
        private string selectedItemToRename = "";

        public FileManager()
        {
            InitializeComponent();

            CreateTreeView();
            ChangDriverImage();
            CreateListView();
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
                    TreeNode tree = new TreeNode();

                    tree.Name = driver;

                    tree.Text = "Локальный диск " + driver;
                    treeView1.Nodes.Add(tree.Name, tree.Text, 2);

                    string[] directory = Directory.GetDirectories(@driver);

                    foreach (string folderPath in directory)
                    {
                        // Substring() - удаляет ненужные часть полного адреса
                        string fileNameInTree = folderPath.Substring(folderPath.LastIndexOf('\\') + 1);

                        (treeView1.Nodes[i]).Nodes.Add(folderPath, fileNameInTree, 0);
                    }
                }

                catch { }

                i++;
            }
        }

        private void CreateListView()
        {
            ColumnHeader columnName = new ColumnHeader();
            columnName.Text = "Имя";
            columnName.Width = 200;
            listView1.Columns.Add(columnName);

            ColumnHeader columnСhanged = new ColumnHeader();
            columnСhanged.Text = "Изменен";
            columnСhanged.Width = 130;
            listView1.Columns.Add(columnСhanged);

            ColumnHeader columnType = new ColumnHeader();
            columnType.Text = "Тип";
            columnType.Width = 70;
            listView1.Columns.Add(columnType);

            ColumnHeader columnSize = new ColumnHeader();
            columnSize.Text = "Размер";
            columnSize.Width = 70;
            listView1.Columns.Add(columnSize);
        }

        private void treeView1_CreateTreeInTree(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                int i = 0;

                foreach (TreeNode selectedTreeFile in e.Node.Nodes)
                {
                    string[] folders = Directory.GetDirectories(@selectedTreeFile.Name);

                    foreach (string folderPath in folders)
                    {
                        TreeNode tempTree = new TreeNode();

                        tempTree.Name = folderPath;

                        tempTree.Text = folderPath.Substring(folderPath.LastIndexOf('\\') + 1);

                        e.Node.Nodes[i].Nodes.Add(tempTree);
                    }

                    i++;
                }
            }

            catch { }
        }

        private void ChangDriverImage()
        {
            foreach (TreeNode tree in treeView1.Nodes)
            {
                if (tree.Name.Contains(":\\"))
                {
                    tree.SelectedImageIndex = 2;
                }
            }
        }



        // Заполнение ListView файлами и папками
        private void FillWithDirectories(string address)
        {
            try
            {
                ListViewItem listItem = new ListViewItem();
                FileInfo fileInfo = new FileInfo(@address);

                string[] files = Directory.GetFiles(@address);

                foreach (string filePath in files)
                {
                    string type = filePath.Substring(filePath.LastIndexOf('.') + 1);

                    int photoIndex = SelectionOfImage(type);

                    string ItemName = filePath.Substring(filePath.LastIndexOf('\\') + 1);

                    fileInfo = new FileInfo(filePath);

                    listItem = new ListViewItem(new string[] { ItemName, fileInfo.LastWriteTime.ToString(), "Файл", (fileInfo.Length / 1000).ToString() + " Кб" }, photoIndex);
                    listItem.Name = filePath;

                    listView1.Items.Add(listItem);
                }
            }

            catch { };
        }

        private void FillWithFolders(string address)
        {
            try
            {
                ListViewItem listItem = new ListViewItem();
                FileInfo folderInfo = new FileInfo(@address);

                string[] folders = Directory.GetDirectories(@address);

                foreach (string folderPath in folders)
                {
                    string ItemName = folderPath.Substring(folderPath.LastIndexOf('\\') + 1);

                    folderInfo = new FileInfo(@folderPath);

                    listItem = new ListViewItem(new string[] { ItemName, folderInfo.LastWriteTime.ToString(), "Папка", "" }, 0);
                    listItem.Name = folderPath;

                    listView1.Items.Add(listItem);
                }
            }

            catch { };
        }

        private int SelectionOfImage(string type)
        {
            int photoIndex;

            switch (type)
            {
                case "docx":
                    photoIndex = 2;
                    break;

                case "jpg":
                case "png":
                    photoIndex = 4;
                    break;

                case "txt":
                    photoIndex = 3;
                    break;

                case "pdf":
                    photoIndex = 6;
                    break;

                case "exe":
                    photoIndex = 5;
                    break;

                case "mp3":
                case "mp4":
                    photoIndex = 7;
                    break;

                case "pptx":
                    photoIndex = 8;
                    break;

                default:
                    photoIndex = 1;
                    break;
            }

            return photoIndex;
        }

        private void FillOrRefreshListView()
        {
            string currentAdress = toolStripTextBox1.Text;

            listView1.Items.Clear();

            FillWithFolders(currentAdress);
            FillWithDirectories(currentAdress);
        }

        private void FillOrRefreshListView(string selectedPath)
        {
            listView1.Items.Clear();

            FillWithFolders(selectedPath);
            FillWithDirectories(selectedPath);
        }


        // Работа элементов toolStrip
        private void ButtonBackClick(object sender, EventArgs e)
        {
            string tempPath = toolStripTextBox1.Text;

            if (tempPath[tempPath.Length - 1] == '\\'
            && tempPath[tempPath.Length - 2] == ':')
            {
                return;
            }

            if (tempPath[tempPath.Length - 1] == '\\')
            {
                do
                {
                    tempPath = tempPath.Remove(tempPath.Length - 1, 1);
                }
                while (tempPath[tempPath.Length - 1] != '\\');
            }
            else
            {
                while (tempPath[tempPath.Length - 1] != '\\')
                {
                    tempPath = tempPath.Remove(tempPath.Length - 1, 1);
                }
            }

            toolStripTextBox1.Text = tempPath;

            FillOrRefreshListView();
        }

        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
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
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string currentAdress = listView1.SelectedItems[0].Name;

            if (Directory.Exists(currentAdress))
            {
                toolStripTextBox1.Text = currentAdress;

                FillOrRefreshListView(listView1.SelectedItems[0].Name);
            }
            else
            {
                currentAdress = listView1.SelectedItems[0].Name;

                Process applicationStart = new Process();

                applicationStart.StartInfo.FileName = @currentAdress;
                applicationStart.Start();
            }
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            listView1.View = View.Details;

            string currentAdress = e.Node.Name;

            toolStripTextBox1.Text = currentAdress;

            FillOrRefreshListView(currentAdress);
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
            catch { };
        }

        private void RelocateFile()
        {
            try
            {
                selectedLocationPath = toolStripTextBox1.Text;

                if (Directory.Exists(relocatableFilePath))
                {
                    selectedLocationPath += relocatableFilePath.Substring(relocatableFilePath.LastIndexOf('\\'));

                    Directory.Move(relocatableFilePath, selectedLocationPath);
                }
                else
                {
                    File.Move(relocatableFilePath, selectedLocationPath);
                }

                relocatableFilePath = "";
            }

            catch
            {
                relocatableFilePath = "";
            };
        }

        private void CopyFile()
        {
            try
            {
                selectedLocationPath = toolStripTextBox1.Text;

                if (Directory.Exists(copiedFilePath))
                {
                    string createdNewDirectory = selectedLocationPath + copiedFilePath.Substring(copiedFilePath.LastIndexOf('\\'));

                    Directory.CreateDirectory(createdNewDirectory);

                    string[] files = Directory.GetFiles(copiedFilePath);

                    foreach (string name in files)
                    {
                        string fileName = Path.GetFileName(name);

                        string finalFile = Path.Combine(createdNewDirectory, fileName);

                        File.Copy(name, finalFile, true);
                    }
                }
                else
                {
                    selectedLocationPath += copiedFilePath.Substring(copiedFilePath.LastIndexOf('\\'));

                    File.Copy(copiedFilePath, selectedLocationPath, true);
                }

                copiedFilePath = "";
            }

            catch
            {
                copiedFilePath = "";
            };
        }

        private void ChangeName()
        {
            try
            {
                string type = "";

                if (File.Exists(selectedItemToRename))
                {
                    type = selectedItemToRename.Substring(selectedItemToRename.LastIndexOf('.'));
                }

                string tempPath = selectedItemToRename;

                if (tempPath[tempPath.Length - 1] == '\\')
                {
                    do
                    {
                        tempPath = tempPath.Remove(tempPath.Length - 1, 1);
                    }
                    while (tempPath[tempPath.Length - 1] != '\\');
                }
                else
                {
                    while (tempPath[tempPath.Length - 1] != '\\')
                    {
                        tempPath = tempPath.Remove(tempPath.Length - 1, 1);
                    }
                }

                Directory.Move(selectedItemToRename, Path.Combine(tempPath, toolStripTextBox2.Text + type));

                toolStripTextBox2.Text = "";

                FillOrRefreshListView();
            }
            catch { };
        }



        // Методы ContextMenu (ПКМ по файлу или папке ListView)
        private void listView1_MouseUp(object sender, MouseEventArgs e)
        {
            ListView senderListView = sender as ListView;

            if (e.Button == MouseButtons.Right)
            {
                if (senderListView.SelectedItems.Count > 0)
                {
                    contextMenuStrip1.Show(senderListView, e.Location);
                }
                else
                {
                    contextMenuStrip2.Show(senderListView, e.Location);
                }
            }
        }

        private void УдалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteFile(listView1.SelectedItems[0].Name);

            FillOrRefreshListView();
        }

        private void ПереместитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copiedFilePath = "";

            relocatableFilePath = listView1.SelectedItems[0].Name;
        }

        private void КопироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            relocatableFilePath = "";

            copiedFilePath = listView1.SelectedItems[0].Name;
        }

        private void ВставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (relocatableFilePath != "")
            {
                RelocateFile();
            }
            if (copiedFilePath != "")
            {
                CopyFile();
            }

            FillOrRefreshListView();
        }

        private void ПечатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();

            printDocument.DocumentName = listView1.SelectedItems[0].Name;

            printDocument.Print();
        }

        private void ПереименоватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedItemToRename = listView1.SelectedItems[0].Name;
        }




        // Методы ContextMenu1 (ПКМ по пустому место ListView)
        private void СоздатьТекстовыйДокументToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.Create(toolStripTextBox1.Text + "\\Новый текстовый документ.txt").Close();

            FillOrRefreshListView();
        }

        private void СоздатьДокументWordMicrosoftWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.Create(toolStripTextBox1.Text + "\\Документ Microsoft Word.docx").Close();

            FillOrRefreshListView();
        }

        private void СоздатьПрезинтациюPowerPointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.Create(toolStripTextBox1.Text + "\\Презентация Microsoft PowerPoint.pptx").Close();

            FillOrRefreshListView();
        }

        private void СоздатьПапкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(toolStripTextBox1.Text + "\\Новая папка");

            FillOrRefreshListView();
        }



        // Проверка нажатых кнопок
        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    DeleteFile(listView1.SelectedItems[0].Name);
                }
            }

            catch { };

            FillOrRefreshListView();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (listView1.SelectedItems[0].Name.Contains(".txt") == true ||
                listView1.SelectedItems[0].Name.Contains(".docx") == true)
            {
                ПечатьToolStripMenuItem.Enabled = true;
            }
            else
            {
                ПечатьToolStripMenuItem.Enabled = false;
            }
        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {
            if (copiedFilePath == "" && relocatableFilePath == "")
            {
                ВставитьToolStripMenuItem.Enabled = false;
            }
            else
            {
                ВставитьToolStripMenuItem.Enabled = true;
            }
        }

        private void toolStripTextBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                ChangeName();
            }
        }

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (toolStripTextBox2.Text != "")
            {
                ChangeName();
            }
        }
    }
}
