using System;

namespace CourseWork
{
    public class TextConstants
    {
        public const string backslash = "\\";

        public const string errorCause = "Отказано в доступе";
        public const string error = "Ошибка";
        public const string pathEror = "Адрес не найден";
        public const string accesError = "Отказано в доступе";

        public const string newTextDocument = "\\Новый текстовый документ.txt";
        public const string newDocumentWord = "\\Документ Microsoft Word.docx";
        public const string newPresentationPowerPoint = "\\Презентация Microsoft PowerPoint.pptx";
        public const string newFolder = "\\Новая папка";

        public const string stringEmptyValue = "";

        public const string informationAboutProgramm = "Файловый менеджер - v1.1\nПрограмма сделана Якимцевым Никитой\nПОИТ-2, группа 2";
    }

    public class TextChanges
    {
        public static string RemovingUnnecessaryInPath(string tempString)
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
    }
}
