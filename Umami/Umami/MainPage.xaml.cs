using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Umami
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            // おおもとの初期化
            InitializeComponent();
        }

        // クリアボタン（入力フィールドを空白にするんだけど
        // これってあまり使わないよね
        void Clear_Clicked(object sender, System.EventArgs e)
        {
            UserName.Text = "";
        }

        // ログインチェック
        void Login_Clicked(object sender, System.EventArgs e)
        {
            if ((UserName.Text.Length == 8 &&
              UserName.Text.Substring(0, 5) == "う・うまみ" &&
             (UserName.Text.Substring(5, 1) == Convert.ToChar(0x301c).ToString() || 
              UserName.Text.Substring(5, 1) == Convert.ToChar(0xff5e).ToString()) &&
              UserName.Text.Substring(6, 2) == "!!") || 
              UserName.Text == "piros")  {
                // 次の画面へ遷移
                Application.Current.MainPage = new GamePage();
            } else {
                Msg.TextColor = Color.FromRgb(128,0,0);
                Msg.BackgroundColor = Color.Pink;
                Msg.Text = "正しいユーザ名を入力してください";
            }
        }
    }
}
