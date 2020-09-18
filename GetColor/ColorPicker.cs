using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Reflection;

namespace GetColor
{ 
    public partial class ColorPicker : Form
    {
        private ScreenManager screenManager;
        private SolidBrush solid;

        #region 初始化
        public ColorPicker()
        {
            InitializeComponent();
            screenManager = new ScreenManager();
            solid = new SolidBrush(Color.White);

            // 設置listBox為手動繪製
            colorList.DrawMode = DrawMode.OwnerDrawFixed;
        }
        #endregion

        #region 獲取鼠標附近畫面與中心顏色
        private void FPSAction(object sender, EventArgs e)
        {
            // 獲取鼠標附近的影像，並裁切成圓形
            int X = Cursor.Position.X;
            int Y = Cursor.Position.Y;
            cutScreen.Image = screenManager.getRoundImage(X, Y, cutScreen.BackColor);

            // 獲得鼠標指向得像素點顏色
            Bitmap screen = screenManager.screen;
            Color cursorColor = screen.GetPixel(screen.Width / 2, screen.Height / 2);
            pixelColor.BackColor = cursorColor;

            // 顯示色碼與座標
            colorHEX.Text = $"HEX={ColorTranslator.ToHtml(cursorColor)}";
            colorRGB.Text = $"RGB=({cursorColor.R}, {cursorColor.B}, {cursorColor.G})";
            CursorXY.Text = $"X={Cursor.Position.X}, Y={Cursor.Position.Y}";

        }
        #endregion

        #region 紀錄顏色
        private void GetKey(object sender, KeyEventArgs e)
        {
            colorList.Items.Add(colorHEX.Text.Split('=')[1]);
        }
        #endregion

        #region 顏色listBox繪製
        private void colorList_DrawItem(object sender, DrawItemEventArgs e)
        {
            ListBox list = sender as ListBox;
            if (list == null || e.Index < 0) return;

            // 繪製選項底色
            solid.Color = ColorTranslator.FromHtml(list.Items[e.Index].ToString());
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
        } 
        #endregion
    }
}
