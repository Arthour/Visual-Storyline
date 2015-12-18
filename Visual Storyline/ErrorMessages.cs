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
    }
}
