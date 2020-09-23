namespace GetColor
{
    partial class ColorPicker
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorPicker));
            this.FPS = new System.Windows.Forms.Timer(this.components);
            this.cutScreen = new System.Windows.Forms.PictureBox();
            this.pixelColor = new System.Windows.Forms.PictureBox();
            this.CursorXY = new System.Windows.Forms.Label();
            this.colorCode = new System.Windows.Forms.Label();
            this.colorList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listClear = new System.Windows.Forms.Button();
            this.KeyShow = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.cutScreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pixelColor)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // FPS
            // 
            this.FPS.Enabled = true;
            this.FPS.Tick += new System.EventHandler(this.FPSAction);
            // 
            // cutScreen
            // 
            this.cutScreen.Location = new System.Drawing.Point(12, 12);
            this.cutScreen.Name = "cutScreen";
            this.cutScreen.Size = new System.Drawing.Size(200, 200);
            this.cutScreen.TabIndex = 2;
            this.cutScreen.TabStop = false;
            // 
            // pixelColor
            // 
            this.pixelColor.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pixelColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pixelColor.Location = new System.Drawing.Point(0, 0);
            this.pixelColor.Name = "pixelColor";
            this.pixelColor.Size = new System.Drawing.Size(50, 50);
            this.pixelColor.TabIndex = 3;
            this.pixelColor.TabStop = false;
            // 
            // CursorXY
            // 
            this.CursorXY.AutoSize = true;
            this.CursorXY.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CursorXY.Location = new System.Drawing.Point(3, 61);
            this.CursorXY.Name = "CursorXY";
            this.CursorXY.Size = new System.Drawing.Size(118, 30);
            this.CursorXY.TabIndex = 4;
            this.CursorXY.Text = "X=0, Y=0";
            // 
            // colorCode
            // 
            this.colorCode.AutoSize = true;
            this.colorCode.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.colorCode.Location = new System.Drawing.Point(0, 104);
            this.colorCode.Name = "colorCode";
            this.colorCode.Size = new System.Drawing.Size(92, 30);
            this.colorCode.TabIndex = 5;
            this.colorCode.Text = "HEX=#";
            // 
            // colorList
            // 
            this.colorList.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.colorList.FormattingEnabled = true;
            this.colorList.ItemHeight = 29;
            this.colorList.Location = new System.Drawing.Point(15, 0);
            this.colorList.Name = "colorList";
            this.colorList.Size = new System.Drawing.Size(170, 149);
            this.colorList.TabIndex = 8;
            this.colorList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.colorList_DrawItem);
            this.colorList.SelectedIndexChanged += new System.EventHandler(this.SelectListColor);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(5, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "按任意鍵紀錄，選取複製";
            // 
            // listClear
            // 
            this.listClear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.listClear.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.listClear.Location = new System.Drawing.Point(15, 162);
            this.listClear.Name = "listClear";
            this.listClear.Size = new System.Drawing.Size(170, 35);
            this.listClear.TabIndex = 10;
            this.listClear.TabStop = false;
            this.listClear.Text = "清空列表";
            this.listClear.UseVisualStyleBackColor = true;
            this.listClear.Click += new System.EventHandler(this.listClear_Click);
            // 
            // KeyShow
            // 
            this.KeyShow.AutoSize = true;
            this.KeyShow.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.KeyShow.Location = new System.Drawing.Point(4, 172);
            this.KeyShow.Name = "KeyShow";
            this.KeyShow.Size = new System.Drawing.Size(152, 25);
            this.KeyShow.TabIndex = 11;
            this.KeyShow.Text = "你甚麼都沒按下";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "RGB",
            "CMYK",
            "HSV",
            "HSL",
            "HEX"});
            this.comboBox1.Location = new System.Drawing.Point(72, 9);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(150, 33);
            this.comboBox1.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.colorList);
            this.panel1.Controls.Add(this.listClear);
            this.panel1.Location = new System.Drawing.Point(520, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 200);
            this.panel1.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pixelColor);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.KeyShow);
            this.panel2.Controls.Add(this.CursorXY);
            this.panel2.Controls.Add(this.colorCode);
            this.panel2.Location = new System.Drawing.Point(239, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(275, 200);
            this.panel2.TabIndex = 14;
            // 
            // ColorPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 228);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cutScreen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "ColorPicker";
            this.Text = "拾色器";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GetKey);
            ((System.ComponentModel.ISupportInitialize)(this.cutScreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pixelColor)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer FPS;
        private System.Windows.Forms.PictureBox cutScreen;
        private System.Windows.Forms.PictureBox pixelColor;
        private System.Windows.Forms.Label CursorXY;
        private System.Windows.Forms.Label colorCode;
        private System.Windows.Forms.ListBox colorList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button listClear;
        private System.Windows.Forms.Label KeyShow;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}

