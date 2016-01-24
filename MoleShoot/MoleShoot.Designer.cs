using System.Windows.Forms;
using MoleShoot.Objects;

namespace MoleShoot
{
    partial class MoleShoot
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MoleShoot));
            this.GameLoop = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // GameLoop
            // 
            this.GameLoop.Interval = 32;
            this.GameLoop.Tick += new System.EventHandler(this.GameLoop_Tick);
            // 
            // MoleShoot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(784, 411);
            this.DoubleBuffered = true;
            this.Name = "MoleShoot";
            this.Text = "MoleShoot";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoleShoot_MouseDown);
            this.MouseEnter += new System.EventHandler(this.MoleShoot_MouseEnter);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoleShoot_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion
        
        private Timer GameLoop;

    }
}