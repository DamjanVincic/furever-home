using FureverHome.Services;
using FureverHome.ViewModels;
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
using System.Windows.Shapes;
using System;
using System.Linq;
using System.Windows.Media;
using GalaSoft.MvvmLight;
using FureverHome.Models;

namespace FureverHome.Views
{
    /// <summary>
    /// Interaction logic for CommentsListing.xaml
    /// </summary>
    public partial class CommentsListing : Window
    {
        private readonly ICommentService _commentService = ServiceProvider.GetRequiredService<ICommentService>();
        public CommentsListing(int postId)
        {
            InitializeComponent();
            DataContext = new CommentListingViewModel(_commentService,postId);
        }
    }
}
