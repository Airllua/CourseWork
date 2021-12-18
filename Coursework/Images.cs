namespace CourseWork
{
    public class ImageIndices
    {
        public const int folderIndex = 0;
        public const int fileIndex = 1;
        public const int docxIndex = 2;
        public const int txtIndex = 3;
        public const int photoIndex = 4;
        public const int exeIndex = 5;
        public const int pdfIndex = 6;
        public const int mpIndex = 7;
        public const int pptxIndex = 8;
        public const int accdbIndex = 10;

        public const int folderIndexForTreeView = 0;
        public const int driverIndexForTreeView = 9;

        public const int downloadsIndex = 0;
        public const int documentsIndex = 1;
        public const int musicIndex = 2;
        public const int videoIndex = 3;
        public const int pictureIndex = 4;
    }

    public class ImageSelection
    {
        public static int findAppropriateImage(string fileType)
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
    }
}
