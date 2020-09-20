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
            this.FPS = new System.Windows.Forms.Timer(this.components);
            this.cutScreen = new System.Windows.Forms.PictureBox();
            this.pixelColor = new System.Windows.Forms.PictureBox();
            this.CursorXY = new System.Windows.Forms.Label();
            this.colorHEX = new System.Windows.Forms.Label();
            this.colorRGB = new System.Windows.Forms.Label();
            this.colorList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listClear = new System.Windows.Forms.Button();
            this.KeyShow = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cutScreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pixelColor)).BeginInit();
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
            this.pixelColor.Location = new System.Drawing.Point(224, 12);
            this.pixelColor.Name = "pixelColor";
            this.pixelColor.Size = new System.Drawing.Size(50, 50);
            this.pixelColor.TabIndex = 3;
            this.pixelColor.TabStop = false;
            // 
            // CursorXY
            // 
            this.CursorXY.AutoSize = true;
            this.CursorXY.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CursorXY.Location = new System.Drawing.Point(219, 69);
            this.CursorXY.Name = "CursorXY";
            this.CursorXY.Size = new System.Drawing.Size(118, 30);
            this.CursorXY.TabIndex = 4;
            this.CursorXY.Text = "X=0, Y=0";
            // 
            // colorHEX
            // 
            this.colorHEX.AutoSize = true;
            this.colorHEX.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.colorHEX.Location = new System.Drawing.Point(219, 125);
            this.colorHEX.Name = "colorHEX";
            this.colorHEX.Size = new System.Drawing.Size(92, 30);
            this.colorHEX.TabIndex = 5;
            this.colorHEX.Text = "HEX=#";
            // 
            // colorRGB
            // 
            this.colorRGB.AutoSize = true;
            this.colorRGB.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.colorRGB.Location = new System.Drawing.Point(219, 181);
            this.colorRGB.Name = "colorRGB";
            this.colorRGB.Size = new System.Drawing.Size(95, 30);
            this.colorRGB.TabIndex = 7;
            this.colorRGB.Text = "RGB=()";
            // 
            // colorList
            // 
            this.colorList.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.colorList.FormattingEnabled = true;
            this.colorList.ItemHeight = 29;
            this.colorList.Location = new System.Drawing.Point(478, 12);
            this.colorList.Name = "colorList";
            this.colorList.Size = new System.Drawing.Size(167, 120);
            this.colorList.TabIndex = 8;
            this.colorList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.colorList_DrawItem);
            this.colorList.SelectedIndexChanged += new System.EventHandler(this.SelectListColor);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(475, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "按任意建紀錄，選取複製";
            // 
            // listClear
            // 
            this.listClear.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.listClear.Location = new System.Drawing.Point(478, 182);
            this.listClear.Name = "listClear";
            this.listClear.Size = new System.Drawing.Size(167, 35);
            this.listClear.TabIndex = 10;
            this.listClear.Text = "清空列表";
            this.listClear.UseVisualStyleBackColor = true;
            this.listClear.Click += new System.EventHandler(this.listClear_Click);
            // 
            // KeyShow
            // 
            this.KeyShow.AutoSize = true;
            this.KeyShow.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.KeyShow.Location = new System.Drawing.Point(474, 136);
            this.KeyShow.Name = "KeyShow";
            this.KeyShow.Size = new System.Drawing.Size(114, 19);
            this.KeyShow.TabIndex = 11;
            this.KeyShow.Text = "你甚麼都沒按下";
            // 
            // ColorPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 228);
            this.Controls.Add(this.KeyShow);
            this.Controls.Add(this.listClear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.colorList);
            this.Controls.Add(this.colorRGB);
            this.Controls.Add(this.colorHEX);
            this.Controls.Add(this.CursorXY);
            this.Controls.Add(this.pixelColor);
            this.Controls.Add(this.cutScreen);
            this.KeyPreview = true;
            this.Name = "ColorPicker";
            this.Text = "拾色器";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GetKey);
            ((System.ComponentModel.ISupportInitialize)(this.cutScreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pixelColor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer FPS;
        private System.Windows.Forms.PictureBox cutScreen;
        private System.Windows.Forms.PictureBox pixelColor;
        private System.Windows.Forms.Label CursorXY;
        private System.Windows.Forms.Label colorHEX;
        private System.Windows.Forms.Label colorRGB;
        private System.Windows.Forms.ListBox colorList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button listClear;
        private System.Windows.Forms.Label KeyShow;
    }
}

