using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CommonNS
{
    public enum LanguageEnum
    {
        En,
        Vi, 
    }
    public class Global
    {
        public static LanguageEnum SystemLanguage;

        static ResourceDictionary enDic = null;
       static  ResourceDictionary vnDic = null;

        public static void SetLanguageDictionary(Window window, LanguageEnum target = LanguageEnum.En)
        {
            SystemLanguage = target;
            if(enDic == null)
            {
                enDic = new ResourceDictionary();
                enDic.Source = new Uri("\\Resources\\StringResources.xaml", UriKind.Relative);
            }

            if (vnDic == null)
            {
                vnDic = new ResourceDictionary();
                vnDic.Source = new Uri("\\Resources\\StringResources.Vi.xaml", UriKind.Relative);
            }

            switch (SystemLanguage)
            {
                case LanguageEnum.En:
                    window.Resources.MergedDictionaries.Remove(vnDic);
                    window.Resources.MergedDictionaries.Add(enDic);
                    break;
                case LanguageEnum.Vi:
                    window.Resources.MergedDictionaries.Remove(enDic);
                    window.Resources.MergedDictionaries.Add(vnDic);
                    break;
                default:
                    break;
            }

        }

        public static void SetLanguageForComponent(UserControl item)
        {
            if (enDic == null)
            {
                enDic = new ResourceDictionary();
                enDic.Source = new Uri("\\Resources\\StringResources.xaml", UriKind.Relative);
            }

            if (vnDic == null)
            {
                vnDic = new ResourceDictionary();
                vnDic.Source = new Uri("\\Resources\\StringResources.Vi.xaml", UriKind.Relative);
            }

            switch (SystemLanguage)
            {
                case LanguageEnum.En:
                    item.Resources.MergedDictionaries.Remove(vnDic);
                    item.Resources.MergedDictionaries.Add(enDic);
                    break;
                case LanguageEnum.Vi:
                    item.Resources.MergedDictionaries.Remove(enDic);
                    item.Resources.MergedDictionaries.Add(vnDic);
                    break;
                default:
                    break;
            }
        }
    }
}
