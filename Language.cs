using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomiaryGUI
{
    static class Language
    {
        static private Dictionary<string, string> diction = new Dictionary<string, string>();
        static private string currentLang = "EN";
        static public string Path = @""; 

        static public string Lang(string text_EN)
        {
            try
            {
                if(currentLang=="EN")return text_EN;

                return text_EN;
            }
            catch(Exception Ex)
            {
                System.Windows.MessageBox.Show(Ex.ToString());
                return text_EN;
            }
        }
        static public string CurrentLanguage
        {
            get
            {
                return currentLang;
            }
            set
            {
                if(currentLang != value)
                {
                    currentLang = value;
                    try
                    {

                    }
                    catch(Exception Ex)
                    {
                        System.Windows.MessageBox.Show(Ex.ToString());
                        currentLang = "EN";
                    }
                }
            }
        }
    }
}
