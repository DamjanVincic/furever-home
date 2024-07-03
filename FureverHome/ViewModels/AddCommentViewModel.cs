using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using FureverHome.Models;
using FureverHome.Services;
using GalaSoft.MvvmLight.Command;
using static System.Net.Mime.MediaTypeNames;

namespace FureverHome.ViewModels
{
    public class AddCommentViewModel : INotifyPropertyChanged
    {
        private readonly CommentService _commentService = ServiceProvider.GetRequiredService<CommentService>();
        private string _commentText;
        private int _postId;
        private int _userId;

        public string CommentText
        {
            get => _commentText;
            set
            {
                if (_commentText != value)
                {
                    _commentText = value;
                    OnPropertyChanged();
                    ((RelayCommand)AddCommentCommand).RaiseCanExecuteChanged();
                }
            }
        }

        public ICommand AddCommentCommand { get; }

        public AddCommentViewModel(int postId, int userId)
        {
            _postId = postId;
            _userId = userId;
            AddCommentCommand = new RelayCommand(AddComment, CanAddComment);
        }

        private async void AddComment()
        {
            if (CanAddComment())
            {
                _commentService.Add(CommentText,_userId,_postId);
                MessageBox.Show("Comment added successfully.", "Success", MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
        }

        private bool CanAddComment()
        {
            return !string.IsNullOrWhiteSpace(CommentText);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}