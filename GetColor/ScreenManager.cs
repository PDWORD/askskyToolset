using System.Drawing;

namespace GetColor
{
    class ScreenManager
    {
        // 原圖/放大/裁切圓形 存放影像
        private Bitmap _screen;
        private Bitmap enlargeScreen;
        private Bitmap roundScreen;

        // 原圖/放大/裁切圓形 起始點與長寬
        private Rectangle screenRect;
        private Rectangle enlargeScreenRect;
        private Rectangle roundScreenRect;

        // 原圖/放大/裁切圓形 繪製器
        private Graphics screenPainter;
        private Graphics enlargeScreenPainter;
        private Graphics roundScreenPainter;

        private Pen pen;
        private const int radius = 10;

        public Bitmap screen { get => _screen; }


        #region 初始化與釋放
        public ScreenManager(int width = radius * 2, int height = radius * 2, int multiple = 10)
        {
            screenRect = new Rectangle(0, 0, width, height);
            enlargeScreenRect = new Rectangle(0, 0, width * multiple, height * multiple);
            roundScreenRect = new Rectangle(0, 0, width * multiple, height * multiple);

            _screen = new Bitmap(screenRect.Width, screenRect.Height);
            enlargeScreen = new Bitmap(enlargeScreenRect.Width, enlargeScreenRect.Height);
            roundScreen = new Bitmap(roundScreenRect.Width, roundScreenRect.Height);

            screenPainter = Graphics.FromImage(_screen);
            enlargeScreenPainter = Graphics.FromImage(enlargeScreen);
            roundScreenPainter = Graphics.FromImage(roundScreen);

            pen = new Pen(Brushes.Red);
            pen.Width = 2.5f;
        } 
        

        ~ScreenManager()
        {
            screenPainter.Dispose();
            enlargeScreenPainter.Dispose();
            roundScreenPainter.Dispose();
        }
        #endregion

        #region 繪製交叉線
        public void darwLine(ref Bitmap Bitmap, int width, int height)
        {
            Graphics g = Graphics.FromImage(Bitmap);

            // 繪製交叉線
            pen.Color = Color.Red;
            pen.Width = 2.5f;
            g.DrawLine(pen, width / 2, 0, width / 2, height);
            g.DrawLine(pen, 0, height / 2, width, height / 2);

            // 繪製圓框
            pen.Color = Color.Black;
            pen.Width = 6f;
            g.DrawEllipse(pen, 3, 3, width - 6, height - 6);
        }
        #endregion

        #region 獲取鼠標附近畫面
        public Bitmap getRoundImage(int X, int Y, Color BackColor)
        {
            X -= radius;
            Y -= radius;

            // 初始化面並繪製新畫面
            screenPainter.Clear(BackColor);
            screenPainter.CopyFromScreen(X, Y, 0, 0, _screen.Size);
            // 放大
            enlargeScreenPainter.DrawImage(_screen, enlargeScreenRect, screenRect, GraphicsUnit.Pixel);

            // 將畫面作為筆刷繪製圓形
            using (TextureBrush texture = new TextureBrush(enlargeScreen))
            {
                roundScreenPainter.FillEllipse(texture, roundScreenRect);
            }

            darwLine(ref roundScreen, roundScreenRect.Width, roundScreenRect.Height);

            return roundScreen;
        } 
        #endregion
    }
}
