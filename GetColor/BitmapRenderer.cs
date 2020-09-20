using System.Drawing;

namespace GetColor
{
    public class BitmapRenderer
    {
        private Bitmap _bitmap;
        private Rectangle bitmapRect;
        private Graphics bitmapPainter;

        public Bitmap bitmap { get => _bitmap; }
        public Rectangle rect { get => bitmapRect; }
        public Graphics graphics { get => bitmapPainter; }
        public int Width { get => bitmap.Width; }
        public int Height { get => bitmap.Height; }

        #region 初始化與釋放
        public BitmapRenderer()
        {
            newPicture(1, 1);
        }

        public BitmapRenderer(int Width, int Height)
        {
            newPicture(Width, Height);
        }

        ~BitmapRenderer()
        {
            bitmapPainter.Dispose();
        }
        #endregion

        #region 重設畫面大小
        void newPicture(int Width, int Height)
        {
            if (bitmapPainter != null) bitmapPainter.Dispose();
            _bitmap = new Bitmap(Width, Height);
            bitmapRect = new Rectangle(0, 0, Width, Height);
            bitmapPainter = Graphics.FromImage(_bitmap);
        }
        #endregion

    }
}
