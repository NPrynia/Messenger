using BespokeFusion;
using MaterialDesignThemes.Wpf;
using Messager.ClassHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
using Messager.Window;

namespace Messager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AuthWindow 
    {
        bool isLogin = true;
        string pathPhoto;
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }

      

        private void topBorder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
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

      
       
        
        //LoginOrReg
        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string tabItem = ((sender as TabControl).SelectedItem as TabItem).Header as string;
            switch (tabItem)
            {
                case "Login":

                    btnLogin.Content = "Login";
                    isLogin = true;
                    break;

                case "Registration":
                    btnLogin.Content = "Registration";
                    isLogin = false;
                    break;

                default:
                    return;
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            List<User> allUser = ApiHelper.getAllUser();
            //validation
            if (ClassHelper.Validation.validationLogin(tbName.Text) == false)
            {
                MessageBox.Show("Некорректное имя");
                return;
            }
           
            //ifLogin
            if (isLogin == true)
            {
                //Search user in DB
                var user = allUser. Where(i => i.Name == tbName.Text && i.Password == pbPassword.Password).FirstOrDefault();
                if (user != null)
                {
                    user.IsOnline = true;
                    MessageBox.Show("Добро пожаловать");
                    MainWindow mainWindow = new MainWindow(user);
                    mainWindow.Show();
                    this.Close();

                }

                else
                {
                    MessageBox.Show("Пользователь не найден");
                }
            }
            //WhenCreateAccount
            else 
            {
                ClassHelper.User user = new ClassHelper.User();
                user.Name = tbName.Text;
                user.Password = pbPassword.Password;
                user.IsOnline = true;
                if (pathPhoto != null)
                {

                    user.ImageUser = File.ReadAllBytes(pathPhoto);
                }
                var userValid = allUser.Where(i => i.Name == tbName.Text).FirstOrDefault();

                if (ClassHelper.Validation.validationPassword(pbPassword.Password) == false)
                {
                    MessageBox.Show("Некорректный пароль");
                    return;
                }
                //Search user in DB
                if (userValid != null)
                {
                    MessageBox.Show("Пользователь с таким именем существует");
                    return;
                }
                //Put user in DB through query POST in api
                postUser(user);
                MainWindow mainWindow = new MainWindow(user);
                mainWindow.Show();
                this.Close();



            }


        }


        public void postUser(User user)
        {

            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://localhost:44317/api/User");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string postData = JsonConvert.SerializeObject(user);

                streamWriter.Write(postData);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
           
        }








    }
}
