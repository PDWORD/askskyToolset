﻿namespace getProcessFilePath
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ProcesstreeView = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // ProcesstreeView
            // 
            this.ProcesstreeView.Font = new System.Drawing.Font("等距更纱黑体 T TC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ProcesstreeView.Location = new System.Drawing.Point(12, 12);
            this.ProcesstreeView.Name = "ProcesstreeView";
            this.ProcesstreeView.Size = new System.Drawing.Size(776, 426);
            this.ProcesstreeView.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ProcesstreeView);
            this.Name = "MainForm";
            this.Text = "getProcessFilePath";
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.TreeView ProcesstreeView;
    }
}

