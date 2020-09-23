using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GetColor
{
    // 聲明通訊委託
    public delegate void delegateSendMsg();

    public partial class ColorPicker : Form
    {
        private ScreenManager screenManager;
        private SolidBrush solid;
        private List<Color> colors;

        RGB RGBcolorSpace;
        CMYK CMYKcolorSpace;
        HSV HSVcolorSpace;
        HSL HSLcolorSpace;
        HEX HEXcolorSpace;

        #region 初始化
        public ColorPicker()
        {
            InitializeComponent();

            screenManager = new ScreenManager();
            solid = new SolidBrush(Color.White);
            colors = new List<Color>();

            // 設置listBox為手動繪製
            colorList.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox1.SelectedIndex = 0;

            RGBcolorSpace = new RGB();
            CMYKcolorSpace = new CMYK();
            HSVcolorSpace = new HSV();
            HSLcolorSpace = new HSL();
            HEXcolorSpace = new HEX();
        }
        #endregion

        #region 獲取鼠標附近畫面與中心顏色
        private void FPSAction(object sender, EventArgs e)
        {
            // 獲取鼠標附近的影像，並裁切成圓形
            int X = Cursor.Position.X;
            int Y = Cursor.Position.Y;
            int picBoxSize = cutScreen.Size.Width;
            int multiple = 5;
            int radius = (picBoxSize / multiple) / 2;
            Bitmap screen = getMouseImage(X, Y, radius, multiple);

            // 獲得鼠標指向得像素點顏色
            Color cursorColor = screen.GetPixel(screen.Width / 2, screen.Height / 2);
            pixelColor.BackColor = cursorColor;

            // 畫上十字線
            darwLineAndRound(screen, screen.Width, screen.Height);

            //對應選單色彩類型進行轉換
            ColorSpaceType colorSpace = null;
            switch (comboBox1.SelectedIndex)
            {
                case (int)ColorSpace.Type.RGB:
                    colorSpace = RGBcolorSpace;
                    break;
                case (int)ColorSpace.Type.CMYK:
                    colorSpace = CMYKcolorSpace;
                    break;
                case (int)ColorSpace.Type.HSV:
                    colorSpace = HSVcolorSpace;
                    break;
                case (int)ColorSpace.Type.HSL:
                    colorSpace = HSLcolorSpace;
                    break;
                case (int)ColorSpace.Type.HEX:
                    colorSpace = HEXcolorSpace;
                    break;
            }
            string colorFormat = colorSpace.getColorFormat(cursorColor);

            // 顯示鼠標附近畫面/色碼/座標
            cutScreen.Image = screen;
            colorCode.Text = colorFormat;
            CursorXY.Text = $"X={X}, Y={Y}";
        }
        #endregion

        #region 獲取鼠標附近畫面
        public Bitmap getMouseImage(int X, int Y, int radius, int multiple)
        {
            // 使左上角成為中心
            X -= radius;
            Y -= radius;

            // 初始化面並繪製新畫面
            screenManager.Clear(cutScreen.BackColor);
            BitmapRenderer  bitmapRenderer = screenManager.getScreen(X, Y,  radius*2, radius*2);
            // 放大
            bitmapRenderer = screenManager.EnlargeImage(bitmapRenderer, multiple);

            // 裁切成圓形
            bitmapRenderer = screenManager.CutImagetoRound(bitmapRenderer);

            Bitmap bitmap = bitmapRenderer.bitmap;
            
            return bitmap;
        }
        #endregion

        #region 繪製交叉線與圓
        public void darwLineAndRound(Bitmap bitmap, int width, int height)
        {
            // 繪製交叉線
            Pen pen = new Pen(Brushes.Red);
            Graphics g = Graphics.FromImage(bitmap);

            pen.Width = 2.5f;
            g.DrawLine(pen, width / 2, 0, width / 2, height);
            g.DrawLine(pen, 0, height / 2, width, height / 2);

            // 繪製圓框
            pen.Color = Color.Black;
            pen.Width = 6f;
            g.DrawEllipse(pen, 3, 3, width - 6, height - 6);
        }
        #endregion

        #region 紀錄顏色
        private void GetKey(object sender, KeyEventArgs e) => saveColor(e.KeyCode.ToString());

        private void saveColor(string key)
        {
            KeyShow.Text = $"你按下了{key}鍵";
            saveColor();
        }

        private void saveColor()
        {
            colorList.Items.Insert(0, colorCode.Text.Split('=')[1]);
            colors.Insert(0, pixelColor.BackColor);
        }
        #endregion

        #region 顏色listBox繪製
        private void colorList_DrawItem(object sender, DrawItemEventArgs e)
        {
            ListBox list = sender as ListBox;
            if (list == null || e.Index < 0) return;

            // 繪製選項底色
            solid.Color = colors[e.Index];
            e.Graphics.FillRectangle(solid, e.Bounds);

            // 繪製選項文字顏色
            solid.Color = Color.Black;
            e.Graphics.DrawString(list.Items[e.Index].ToString(), e.Font, solid, e.Bounds);

            e.DrawFocusRectangle();
        }
        #endregion

        #region 複製色碼至剪貼簿
        private void SelectListColor(object sender, EventArgs e)
        {
            // 複製至剪貼簿
            Clipboard.SetData(DataFormats.Text, (Object)colorList.SelectedItem.ToString());

            // 顯示複製提示
            toast toastForm = new toast();
            int X = this.Location.X + (int)((this.Width - toastForm.Width) / 2);
            int Y = this.Location.Y + this.Height - toastForm.Height * 2;
            toastForm.StartPosition = FormStartPosition.Manual;
            toastForm.Location = new Point(X, Y);
            toastForm.Show();
        }
        #endregion

        #region 清空listBox
        private void listClear_Click(object sender, EventArgs e)
        {
            colorList.Items.Clear();
            colors.Clear();
            // 切換焦點
            label1.Focus();
        }
        #endregion
    }
}
