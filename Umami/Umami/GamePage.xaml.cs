using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Umami
{
    // 効果音再生のためのインターフェースの作成
    public interface ISoundEffect
    {
        void SoundPlay(int c);
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GamePage : ContentPage
    {
        private ExImage _image;

        // 乱数発生用変数
        System.Random r = new System.Random();

        // 効果音再生のためのインターフェースの実装
        ISoundEffect soundEffect = DependencyService.Get<ISoundEffect>();

        public GamePage()
        {
            // おおもとの初期化
            InitializeComponent();

            // イメージの配置
            Grid grid;
            grid = g;
            _image = new ExImage();
            _image.Source = ImageSource.FromResource("Umami.image.gacchan.jpg");
            grid.Children.Add(_image, 1, 1);

            // タッチイベントの実装
            _image.Down += (sender, a) => {
                int rnum;  // 乱数
                int koe;   // 声番号（0:うまみ 1:そそそ 2:うまそそそ）

                // 乱数で音声を変える
                rnum = r.Next(0, 100);
                if(rnum < 70) {
                    koe = 0;
                } else if(rnum < 90) {
                    koe = 1;
                } else {
                    koe = 2;
                }

                // 発声
                using (soundEffect as IDisposable)
                {
                    soundEffect.SoundPlay(koe);
                }
            };

        }
    }
}