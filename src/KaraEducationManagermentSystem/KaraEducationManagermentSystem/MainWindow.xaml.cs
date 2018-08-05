using CommonNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KaraEducationManagermentSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Global.SetLanguageDictionary(this, LanguageEnum.Vi);
            SetLanguageForAllSub();
        }

        private void ChangeLanguage_Click(object sender, RoutedEventArgs e)
        {
            switch(Global.SystemLanguage)
            {
                case LanguageEnum.Vi:
                    Global.SetLanguageDictionary(this, LanguageEnum.En);
                    break;
                case LanguageEnum.En:
                    Global.SetLanguageDictionary(this, LanguageEnum.Vi);
                    break;
            }
            SetLanguageForAllSub();
        }

        void SetLanguageForAllSub()
        {
            schoolTab.SetLanguageForComponent();

            subjectTab.SetLanguageForComponent();

            classTab.SetLanguageForComponent();
        }

    }


}
