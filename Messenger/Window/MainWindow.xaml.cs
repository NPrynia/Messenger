using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
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
using System.Windows.Shapes;
using System.Windows.Threading;
using Messager.ClassHelper;
using Newtonsoft.Json;
using ServiceStack;
using System.Linq;
using Messager.ClassHelper;

namespace Messager.Window 
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        string pathPhoto;
        string pathPhotoMessage;

        List<User> oldUserList;
        List<User> newUserList;
        List<Message> newMessageList;
        List<Message> oldMessageList;
        User surrentUser;
        StackPanel stackPanel = new StackPanel();
        int SelectedIDUser;
        public MainWindow(User user)
        {
            InitializeComponent();
            List<User> allUser = ApiHelper.getAllUser();
            user = allUser.Where(i => i.Name == user.Name && i.Password == user.Password).FirstOrDefault();
            surrentUser = user;
            tbName.Text = user.Name;
            if (user.ImageUser != null)
            {
                using (MemoryStream stream = new MemoryStream(user.ImageUser))
                {
                    Image i = new Image();
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                    bitmapImage.StreamSource = stream;
                    bitmapImage.EndInit();
                    i.Source = bitmapImage;
                    photoImage.ImageSource = i.Source;
                    photoIcon.Visibility = Visibility.Hidden;
                }
            }

            lvUser.ItemsSource = oldUserList;
            refreshUserAndMessage();
        }

        public MainWindow()
        {
            InitializeComponent();
            surrentUser = ApiHelper.getAllUser().Where(i => i.ID == 1).FirstOrDefault();
            lvUser.ItemsSource = oldUserList;
            refreshUserAndMessage();
        }




        public async void refreshUserAndMessage()
        {

            while (true)
            {
                await Task.Run(() => refreshEveryListView());
                await Task.Run(() => Thread.Sleep(500));
            }
        }



        private void pickImage_Click(object sender, RoutedEventArgs e)
        {

            Microsoft.Win32.OpenFileDialog openFile = new Microsoft.Win32.OpenFileDialog();
            if (openFile.ShowDialog() == true)
            {
                Image i = new Image();
                i.Source = new BitmapImage(new Uri(openFile.FileName));
                pathPhoto = openFile.FileName;
                photoIcon.Visibility = Visibility.Hidden;
                photoImage.ImageSource = i.Source;

            }
        }

        public void refreshEveryListView()
        {
            try
            {
                
                newUserList = ApiHelper.getAllUser();
                newUserList.RemoveAll(r => r.ID == surrentUser.ID);
                if (JsonConvert.SerializeObject(newUserList) != JsonConvert.SerializeObject(oldUserList))
                {
                    Dispatcher.Invoke((Action)(() =>
                    {
                        lvUser.ItemsSource = newUserList;
                    }));
                    oldUserList = newUserList;
                }

                newMessageList = ApiHelper.getMessage(surrentUser.ID, SelectedIDUser);
                if (JsonConvert.SerializeObject(newMessageList) != JsonConvert.SerializeObject(oldMessageList))
                {
                    Dispatcher.Invoke((Action)(() =>
                    {
                        lvMessage.ItemsSource = newMessageList;
                    }));
                    oldMessageList = newMessageList;
                }
            }
            catch
            {

            }


        }








        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (ClassHelper.Validation.validationLogin(tbName.Text) == false)
            {
                MessageBox.Show("Некорректное имя");
                return;
            }

            if (ClassHelper.Validation.validationPassword(pbPassword.Password) == false)
            {
                MessageBox.Show("Некорректный пароль");
                return;
            }
            //Search user in DB
            List<User> allUser = ApiHelper.getAllUser();
            var userValid = allUser.Where(i => i.Name == tbName.Text ).FirstOrDefault();

            if (userValid != null)
            {
                MessageBox.Show("Пользователь с таким именем существует");
                return;
            }

            surrentUser.Name = tbName.Text;
            surrentUser.Password = pbPassword.Password;
            surrentUser.IsOnline = true;
            if (pathPhoto != null)
            {

                surrentUser.ImageUser = File.ReadAllBytes(pathPhoto);
            }
            putUser();

        }


        public void putUser()
        {
            using (var client = new WebClient())
            {
                var dataString = JsonConvert.SerializeObject(surrentUser);
                client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                client.UploadString(new Uri("https://localhost:44317/api/User"), "PUT", dataString);
            }

        }


        private void spAlignment_Loaded(object sender, RoutedEventArgs e)
        {
            stackPanel = sender as StackPanel;


            if ((stackPanel.Tag).ToString() == (surrentUser.ID).ToString())
            {
                stackPanel.HorizontalAlignment = HorizontalAlignment.Right;
            }
            else
            {
                stackPanel.HorizontalAlignment = HorizontalAlignment.Left;
            }


        }



        private void lvUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvUser.SelectedItem is User)
            {
                var user = lvUser.SelectedItem as User;
                SelectedIDUser = user.ID;
            }
        }

        private async void btnSentMessage_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(() => sentMessage());
        }
        public async void sentMessage()
        {
            Message message = new ClassHelper.Message();
            Dispatcher.Invoke((Action)(() =>
            {
                message.Message1 = tbInput.Text;
                message.IDUserSent = surrentUser.ID;
                message.IDUserGet = SelectedIDUser;
                message.TimeSent = DateTime.Now;
            }));
           
            if (pathPhotoMessage != null)
            {

                message.Image = File.ReadAllBytes(pathPhotoMessage);
            }

            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://localhost:44317/api/Message");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string postData = JsonConvert.SerializeObject(message);

                streamWriter.Write(postData);
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
            Dispatcher.Invoke((Action)(() =>
            {
                tbInput.Text = null;
                sentImg.Source = null;
            }));

            pathPhotoMessage = null;

        }

        private void btnSentImg_Click(object sender, RoutedEventArgs e)
        {
            if (lvUser.SelectedIndex == 0)
            {
                MessageBox.Show("Выберите чат");
            }
            else 
            {
                Microsoft.Win32.OpenFileDialog openFile = new Microsoft.Win32.OpenFileDialog();
                if (openFile.ShowDialog() == true)
                {
                    Image i = new Image();
                    i.Source = new BitmapImage(new Uri(openFile.FileName));
                    pathPhotoMessage = openFile.FileName;
                    sentImg.Source = i.Source;
                }
            }
           
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            using (var client = new WebClient())
            {
                surrentUser.IsOnline = false;
                var dataString = JsonConvert.SerializeObject(surrentUser);
                client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                client.UploadString(new Uri("https://localhost:44317/api/User"), "PUT", dataString);
            }
        }
    }
}
