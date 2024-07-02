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
using FureverHome.ViewModels;
using FureverHome.Models;

namespace FureverHome.Views
{
    /// <summary>
    /// Interaction logic for PostCard.xaml
    /// </summary>
    public partial class PostCard : UserControl
    {
        public PostCard()
        {
            InitializeComponent();
        }

        public PostCard(Post post)
        {
            InitializeComponent();
            DataContext = new PostViewModel(post);
        }
    }

}
