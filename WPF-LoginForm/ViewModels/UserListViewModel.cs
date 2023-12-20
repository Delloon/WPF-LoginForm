using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_LoginForm.Models;
using WPF_LoginForm.Repositories;
using WPF_LoginForm.Views;

namespace WPF_LoginForm.ViewModels
{
    public class UserListViewModel : ViewModelBase
    {
        private ObservableCollection<object> _users;
        private object _selectedUser;

        private ICommand _translateToEditUserCommand;

        public ObservableCollection<object> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                OnPropertyChanged(nameof(Users));
            }
        }

        public object SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));
            }
        }

        public ICommand DeleteUserCommand { get; }

        public UserListViewModel()
        {
            LoadData();
            DeleteUserCommand = new ViewModelCommand(DeleteUser);
            TranslateToEditUserCommand = new ViewModelCommand(ExecuteTranslateToEditUserCommand);
        }

        private void LoadData()
        {
            var userRepository = new UserRepository();
            var fullUserModels = userRepository.GetByAll();

            Users = new ObservableCollection<object>(
                fullUserModels.Select(u => new
                {
                    Логин = u.Username,
                    Фамилия = u.LastName,
                    Имя = u.Name,
                    Отчество = u.MiddleName,
                }));
        }

        private void ExecuteTranslateToEditUserCommand(object obj)
        {
            EditView editView = new EditView();
            editView.Show();
        }
        public ICommand TranslateToEditUserCommand
        {
            get
            {
                return _translateToEditUserCommand ?? (_translateToEditUserCommand = new ViewModelCommand(ExecuteTranslateToEditUserCommand));
            }
            set
            {
                _translateToEditUserCommand = value;
                OnPropertyChanged(nameof(TranslateToEditUserCommand));
            }
        }


        private void DeleteUser(object parameter)
        {
            var selectedUser = (dynamic)parameter;
            var username = selectedUser.Логин;

            var userRepository = new UserRepository();
            userRepository.RemoveByUsername(username);

            LoadData();  // Обновляем данные после удаления пользователя
        }
    }
}
