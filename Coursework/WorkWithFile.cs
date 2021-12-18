using System.Windows.Forms;
using System.IO;

namespace CourseWork
{
    public class WorkWithFile
    {
        public static void DeleteFile(string deletePath)
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

        public static void RelocateFile(string selectedLocationPath, string relocatableFilePath)
        {
            try
            {
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
        }

        private static void CopyDirectory(string pathFromDirectory, string pathToDirectory)
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

        public static void CopyFile(string selectedLocationPath, string copiedFilePath)
        {
            try
            {
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
        }

        public static string ChangeName(string selectedItemToRename, string newName)
        {
            try
            {
                string fileType = TextConstants.stringEmptyValue;

                if (File.Exists(selectedItemToRename))
                {
                    fileType = selectedItemToRename.Substring(selectedItemToRename.LastIndexOf('.'));
                }

                string tempPath = selectedItemToRename;

                tempPath = TextChanges.RemovingUnnecessaryInPath(tempPath);

                Directory.Move(selectedItemToRename, Path.Combine(tempPath, newName + fileType));

                return Path.Combine(tempPath, newName + fileType);
            }
            catch
            {
                MessageBox.Show(TextConstants.errorCause, TextConstants.error,
                MessageBoxButtons.OK, MessageBoxIcon.Error);

                return TextConstants.stringEmptyValue;
            };
        }
    }
}
