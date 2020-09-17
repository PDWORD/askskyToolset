using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace askskyToolset
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region 文字轉圖片功能
        private void button1_Click(object sender, EventArgs e)
        {
            // 獲得要轉成圖片的字串/字體/大小/顏色
            string text = textBox1.Text;
            Font font = fontDialog1.Font;
            SolidBrush drawBrush = new SolidBrush(fontDialog1.Color);

            // 獲得圖像所需所需大小
            Bitmap bitmap = new Bitmap(1, 1);
            Graphics graphics = Graphics.FromImage(bitmap);
            SizeF sizeF = graphics.MeasureString(text, font);

            //重設Bitmap大小
            int width = (int)(sizeF.Width + 1);
            int height = (int)(sizeF.Height + 1);
            Rectangle rect = new Rectangle(0, 0, width, height);
            bitmap.Dispose();
            bitmap = new Bitmap(width, height);
            graphics = Graphics.FromImage(bitmap);

            // 繪製文字
            graphics.DrawString(text, font, drawBrush, rect);
            pictureBox1.Image = bitmap;
        }
        #endregion

        #region 另存圖片
        private void button2_Click(object sender, EventArgs e)
        {
            // 設定可處存的圖片類型
            var imageFormat = new ImageFormat[] { ImageFormat.Png, ImageFormat.Jpeg, ImageFormat.Bmp };

            // 初始另存新檔
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = textBox1.Text;
            saveFileDialog.Filter = "PNG files (*.png)|*.png|JPEG files (*.jpeg)|*.jpeg|BMP files (*.jpeg)|*.bmp";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap bitmap = new Bitmap(pictureBox1.Image);
                bitmap.Save(saveFileDialog.FileName, imageFormat[saveFileDialog.FilterIndex - 1]);

            }
        }
        #endregion

        #region 獲得字型
        private void button3_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowColor = true;
            fontDialog1.ShowDialog();
        } 
        #endregion
    }
}
