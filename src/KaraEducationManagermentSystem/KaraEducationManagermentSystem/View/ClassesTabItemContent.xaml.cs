﻿using CommonNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace KaraEducationManagermentSystem.View
{
    /// <summary>
    /// Interaction logic for ClassesTabItemContent.xaml
    /// </summary>
    public partial class ClassesTabItemContent : UserControl
    {
        public ClassesTabItemContent()
        {
            InitializeComponent();
        }

        internal void SetLanguageForComponent()
        {
            Global.SetLanguageForComponent(this);
        }
    }
}
