using System.Drawing;
using System.Windows.Forms;


namespace GetColor
{
    class ScreenManager
    {
        private BitmapRenderer screen;
        private BitmapRenderer enlargeScreen;
        private BitmapRenderer roundScreen;

        #region 初始化與釋放
        public ScreenManager()
        {
            screen = new BitmapRenderer();
            enlargeScreen = new BitmapRenderer();
            roundScreen = new BitmapRenderer();
        }

        ~ScreenManager()
        {
            screen = null;
            enlargeScreen = null;
            roundScreen = null;
        }
        #endregion

        #region 獲得指定範圍畫面
        public BitmapRenderer getScreen()
        {
            // 獲得螢幕長寬
            int Width = Screen.PrimaryScreen.Bounds.Width;
            int Height = Screen.PrimaryScreen.Bounds.Height;

            return getScreen(0, 0, Width, Height);
        }

        public BitmapRenderer getScreen(int X, int Y, int Width, int Height)
        {
            if (Width != screen.Width ||
                Height != screen.Height)
                screen = new BitmapRenderer(Width, Height);

            // 獲得螢幕部分畫面
            screen.graphics.CopyFromScreen(X, Y, 0, 0, screen.bitmap.Size);

            return screen;
        }
        #endregion

        #region 裁切成圓形
        public BitmapRenderer CutImagetoRound(BitmapRenderer image)
        {
            if (image == null) return null;

            if (image.Width != roundScreen.Width ||
                image.Height != roundScreen.Height)
                roundScreen = new BitmapRenderer(image.Width, image.Height);

            // 將畫面作為筆刷繪製圓形
            using (TextureBrush texture = new TextureBrush(image.bitmap))
            {
                roundScreen.graphics.FillEllipse(texture, roundScreen.rect);
            }

            return roundScreen;
        }
        #endregion

        #region 放大影像
        public BitmapRenderer EnlargeImage(BitmapRenderer image, int multiple)
        {
            if (image == null || multiple < 1) return null;

            if (enlargeScreen.Width / image.Width != multiple ||
                enlargeScreen.Height / image.Height != multiple)
            {
                int Width = image.Width * multiple;
                int Height = image.Height * multiple;
                enlargeScreen = new BitmapRenderer(Width, Height);
            }

            // 放大
            enlargeScreen.graphics.DrawImage(image.bitmap, enlargeScreen.rect, image.rect, GraphicsUnit.Pixel);

            return enlargeScreen;
        }
        #endregion

        #region 清除繪畫
        public void Clear(Color color) => screen.graphics.Clear(color);
        #endregion

    }

}
