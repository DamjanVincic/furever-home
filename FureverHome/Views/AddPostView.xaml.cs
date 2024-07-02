﻿using System;
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
using System.Windows.Shapes;
using FureverHome.Models;
using FureverHome.ViewModels;

namespace FureverHome.Views
{
    /// <summary>
    /// Interaction logic for AddPostView.xaml
    /// </summary>
    public partial class AddPostView : Window
    {

        public AddPostView()
        {
            InitializeComponent();
            DataContext = new AddPostViewModel(this);
        }
    }
}
