﻿using KaraEducationManagermentSystem.ViewModel.Component;
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

namespace KaraEducationManagermentSystem.View.Component
{
    /// <summary>
    /// Interaction logic for SubjectsManagerComponent.xaml
    /// </summary>
    public partial class SubjectsManagerComponent : UserControl
    {
        public SubjectsManagerComponent()
        {
            InitializeComponent();
            try
            {
                this.DataContext = new SubjectsManagerComponentViewModel();
            }
            catch
            {


            }
        }
    }
}
