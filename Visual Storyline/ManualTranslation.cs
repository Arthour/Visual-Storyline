using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visual_Storyline
{
    class ManualTranslation
    {
        static int Language;
        public static string Message;

        public static void checkLanguage()
        {
            switch (CultureInfo.CurrentCulture.TwoLetterISOLanguageName)
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

        public static string Month(int month)
        {
            checkLanguage();
            switch (Language)
            {
                case 0:
                    switch (month)
                    {
                        case 1:
                            Message = "January";
                            break;
                        case 2:
                            Message = "Febraury";
                            break;
                        case 3:
                            Message = "March";
                            break;
                        case 4:
                            Message = "April";
                            break;
                        case 5:
                            Message = "May";
                            break;
                        case 6:
                            Message = "June";
                            break;
                        case 7:
                            Message = "July";
                            break;
                        case 8:
                            Message = "August";
                            break;
                        case 9:
                            Message = "September";
                            break;
                        case 10:
                            Message = "October";
                            break;
                        case 11:
                            Message = "November";
                            break;
                        case 12:
                            Message = "December";
                            break;
                    }
                    break;
                case 1:
                    switch (month)
                    {
                        case 1:
                            Message = "Jänner";
                            break;
                        case 2:
                            Message = "Februar";
                            break;
                        case 3:
                            Message = "März";
                            break;
                        case 4:
                            Message = "April";
                            break;
                        case 5:
                            Message = "Mai";
                            break;
                        case 6:
                            Message = "Juni";
                            break;
                        case 7:
                            Message = "Juli";
                            break;
                        case 8:
                            Message = "August";
                            break;
                        case 9:
                            Message = "September";
                            break;
                        case 10:
                            Message = "Oktober";
                            break;
                        case 11:
                            Message = "November";
                            break;
                        case 12:
                            Message = "Dezember";
                            break;
                    }
                    break;
            }
            return Message;
        }

        public static string Day(int day)
        {
            checkLanguage();
            switch(Language)
            {
                case 0:
                    switch(day)
                    {
                        case 1:
                            Message = "Monday";
                            break;
                        case 2:
                            Message = "Tuesday";
                            break;
                        case 3:
                            Message = "Wednesday";
                            break;
                        case 4:
                            Message = "Thursday";
                            break;
                        case 5:
                            Message = "Friday";
                            break;
                        case 6:
                            Message = "Saturday";
                            break;
                        case 7:
                            Message = "Sunday";
                            break;
                    }
                    break;
                case 1:
                    switch(day)
                    {
                        case 1:
                            Message = "Montag";
                            break;
                        case 2:
                            Message = "Dienstag";
                            break;
                        case 3:
                            Message = "Mittwoch";
                            break;
                        case 4:
                            Message = "Donnerstag";
                            break;
                        case 5:
                            Message = "Freitag";
                            break;
                        case 6:
                            Message = "Samstag";
                            break;
                        case 7:
                            Message = "Sonntag";
                            break;
                    }
                    break;
            }
            return Message;
        }
    }
}
