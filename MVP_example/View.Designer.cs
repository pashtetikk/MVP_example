namespace MVP_example
{
    partial class View
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
            this.components = new System.ComponentModel.Container();
            this.fieldView = new System.Windows.Forms.PictureBox();
            this.modelTim = new System.Windows.Forms.Timer(this.components);
            this.viewTim = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fieldView)).BeginInit();
            this.SuspendLayout();
            // 
            // fieldView
            // 
            this.fieldView.BackColor = System.Drawing.Color.White;
            this.fieldView.Location = new System.Drawing.Point(131, 35);
            this.fieldView.Name = "fieldView";
            this.fieldView.Size = new System.Drawing.Size(503, 369);
            this.fieldView.TabIndex = 0;
            this.fieldView.TabStop = false;
            this.fieldView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.fieldView_MouseDown);
            this.fieldView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.fieldView_MouseMove);
            this.fieldView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.fieldView_MouseUp); 
            // 
            // modelTim
            // 
            this.modelTim.Enabled = true;
            this.modelTim.Interval = 10;
            this.modelTim.Tick += new System.EventHandler(this.modelTim_Tick);
            // 
            // viewTim
            // 
            this.viewTim.Enabled = true;
            this.viewTim.Interval = 20;
            this.viewTim.Tick += new System.EventHandler(this.viewTim_Tick);
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.fieldView);
            this.Name = "View";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.View_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.View_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.fieldView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox fieldView;
        private System.Windows.Forms.Timer modelTim;
        private System.Windows.Forms.Timer viewTim;
    }
}