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
    public partial class toast : Form
    {
        public toast()
        {
            InitializeComponent();
        }

        #region 窗口消失與淡化
        private void toast_Load(object sender, EventArgs e)
        {
            Timer CloseTimer = new Timer();
            Timer FadeTimer = new Timer();

            CloseTimer.Tick += delegate { this.Close(); };
            FadeTimer.Tick += delegate { this.Opacity -= 0.1f; };

            // 設定秒數
            CloseTimer.Interval = (int)TimeSpan.FromSeconds(0.5f).TotalMilliseconds;
            FadeTimer.Interval = (int)TimeSpan.FromSeconds(0.1f).TotalMilliseconds;

            CloseTimer.Start();
            FadeTimer.Start();
        } 
        #endregion
    }
}
