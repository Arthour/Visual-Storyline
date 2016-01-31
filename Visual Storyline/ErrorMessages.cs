using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visual_Storyline
{
    class ErrorMessages
    {
        static int Language;
        public static string Message;
        public static string Title;

        public static void checkLanguage()
        {
            switch(CultureInfo.CurrentCulture.TwoLetterISOLanguageName)
            {
                case "en":
                default:
                    Language = 0;
                    break;
                case "de":
                    Language = 1;
                    break;
            }
        }

        public static string ErrorTitle()
        {
            checkLanguage();
            switch (Language)
            {
                case 0:
                    Title = "Error";
                    break;
                case 1:
                    Title = "Fehler";
                    break;
            }
            return Title;
        }

        public static string WarningTitle()
        {
            checkLanguage();
            switch (Language)
            {
                case 0:
                    Title = "Warning";
                    break;
                case 1:
                    Title = "Warnung";
                    break;
            }
            return Title;
        }

        public static string NameError()
        {
            checkLanguage();
            switch(Language)
            {
                case 0:
                    Message = "The chosen Name is not valid. Please make sure that it consists only of upper/lowercase letters, numbers an underscores.";
                    break;
                case 1:
                    Message = "Der gewählte Name ist nicht gültig. Bitte stellen Sie sicher, dass er nur aus Groß-/Kleinbuchstaben, Zahlen und Underscores besteht.";
                    break;
            }
            return Message;
        }

        public static string ArgumentError()
        {
            checkLanguage();
            switch (Language)
            {
                case 0:
                    Message = "The chosen Path is not valid. Please make sure that it is available and does not contain invalid characters.";
                    break;
                case 1:
                    Message = "Der gewählte Pfad ist nicht gültig. Bitte stellen Sie sicher, dass er verfügbar ist und keine ungültigen Zeichen enthält.";
                    break;
            }
            return Message;
        }

        public static string SecurityError()
        {
            checkLanguage();
            switch (Language)
            {
                case 0:
                    Message = "You do not have the required permissions for this path.";
                    break;
                case 1:
                    Message = "Sie verfügen nicht über die benötigten Berechtigungen für diesen Pfad.";
                    break;
            }
            return Message;
        }

        public static string NotSupportedError()
        {
            checkLanguage();
            switch (Language)
            {
                case 0:
                    Message = "The chosen Path contains invalid characters.";
                    break;
                case 1:
                    Message = "Der gewählte Pfad enthält ungültige Zeichen.";
                    break;
            }
            return Message;
        }

        public static string TooLongError()
        {
            checkLanguage();
            switch (Language)
            {
                case 0:
                    Message = "The chosen Path is too long.";
                    break;
                case 1:
                    Message = "Der gewählte Pfad ist zu lang.";
                    break;
            }
            return Message;
        }

        public static string IOError()
        {
            checkLanguage();
            switch (Language)
            {
                case 0:
                    Message = "The specified folder is a file or the network name is unknown.";
                    break;
                case 1:
                    Message = "Der angegebene Ordner ist eine Datei oder der Netzwerkname ist unbekannt.";
                    break;
            }
            return Message;
        }

        public static string UnauthorizedError()
        {
            checkLanguage();
            switch (Language)
            {
                case 0:
                    Message = "You do not have the required permissions for this path.";
                    break;
                case 1:
                    Message = "Sie verfügen nicht über die benötigten Berechtigungen für diesen Pfad.";
                    break;
            }
            return Message;
        }

        public static string FolderExistsWarning()
        {
            checkLanguage();
            switch (Language)
            {
                case 0:
                    Message = "There is already a folder at the specified path. If you continue the files in this folder will be deleted. Continue?";
                    break;
                case 1:
                    Message = "An dem angegeben Pfad befindet sich bereits ein Ordner mit diesem Namen. Wenn Sie fortfahren werden die Dateien in diesem Ordner gelöscht. Fortfahren?";
                    break;
            }
            return Message;
        }

        public static string SomethingWentWrongOptions()
        {
            checkLanguage();
            switch (Language)
            {
                case 0:
                    Message = "Something went wrong while loading these options. Resetting to default values.";
                    break;
                case 1:
                    Message = "Während dem Laden der Optionen ist etwas schiefgelaufen. Sie werden auf die Standardwerte zurückgesetzt.";
                    break;
            }
            return Message;
        }
    }
}
