namespace PangyaFileCoreTest
{
    partial class AppMain
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnItemEditor = new System.Windows.Forms.Button();
            this.BtnPartEditor = new System.Windows.Forms.Button();
            this.BtnCharEditor = new System.Windows.Forms.Button();
            this.BtnGeneric = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnItemEditor);
            this.groupBox2.Controls.Add(this.BtnPartEditor);
            this.groupBox2.Controls.Add(this.BtnCharEditor);
            this.groupBox2.Location = new System.Drawing.Point(12, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(466, 292);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Testes Disponiveis ";
            // 
            // BtnItemEditor
            // 
            this.BtnItemEditor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BtnItemEditor.Location = new System.Drawing.Point(311, 32);
            this.BtnItemEditor.Name = "BtnItemEditor";
            this.BtnItemEditor.Size = new System.Drawing.Size(137, 63);
            this.BtnItemEditor.TabIndex = 2;
            this.BtnItemEditor.Text = "                 Item.Editor";
            this.BtnItemEditor.UseVisualStyleBackColor = true;
            this.BtnItemEditor.Click += new System.EventHandler(this.BtnItem_Click);
            // 
            // BtnPartEditor
            // 
            this.BtnPartEditor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BtnPartEditor.Location = new System.Drawing.Point(163, 32);
            this.BtnPartEditor.Name = "BtnPartEditor";
            this.BtnPartEditor.Size = new System.Drawing.Size(142, 63);
            this.BtnPartEditor.TabIndex = 1;
            this.BtnPartEditor.Text = "             Part.Editor";
            this.BtnPartEditor.UseVisualStyleBackColor = true;
            this.BtnPartEditor.Click += new System.EventHandler(this.BtnPart_Click);
            // 
            // BtnCharEditor
            // 
            this.BtnCharEditor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BtnCharEditor.Location = new System.Drawing.Point(16, 32);
            this.BtnCharEditor.Name = "BtnCharEditor";
            this.BtnCharEditor.Size = new System.Drawing.Size(141, 63);
            this.BtnCharEditor.TabIndex = 0;
            this.BtnCharEditor.Text = "             Character.Editor";
            this.BtnCharEditor.UseVisualStyleBackColor = true;
            this.BtnCharEditor.Click += new System.EventHandler(this.BtnChar_Click);
            // 
            // BtnGeneric
            // 
            this.BtnGeneric.Location = new System.Drawing.Point(0, 0);
            this.BtnGeneric.Name = "BtnGeneric";
            this.BtnGeneric.Size = new System.Drawing.Size(75, 23);
            this.BtnGeneric.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(65, 421);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 39);
            this.button1.TabIndex = 4;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(261, 421);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 39);
            this.button2.TabIndex = 8;
            this.button2.Text = "Credits";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // AppMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 485);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "AppMain";
            this.Text = "Pangya IFF Files";
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnCharEditor;
        private System.Windows.Forms.Button BtnPartEditor;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button BtnGeneric;
        private System.Windows.Forms.Button BtnItemEditor;
    }
}