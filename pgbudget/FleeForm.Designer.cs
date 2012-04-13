namespace pgbudget
{
    partial class FleeForm
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
            this.textBoxF = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCal = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxR = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxRNCal = new System.Windows.Forms.TextBox();
            this.buttonNCal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxF
            // 
            this.textBoxF.Location = new System.Drawing.Point(85, 25);
            this.textBoxF.Name = "textBoxF";
            this.textBoxF.Size = new System.Drawing.Size(183, 21);
            this.textBoxF.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "公式：";
            // 
            // buttonCal
            // 
            this.buttonCal.Location = new System.Drawing.Point(288, 50);
            this.buttonCal.Name = "buttonCal";
            this.buttonCal.Size = new System.Drawing.Size(124, 23);
            this.buttonCal.TabIndex = 2;
            this.buttonCal.Text = "计算(Flee)";
            this.buttonCal.UseVisualStyleBackColor = true;
            this.buttonCal.Click += new System.EventHandler(this.buttonCal_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "结果：";
            // 
            // textBoxR
            // 
            this.textBoxR.Location = new System.Drawing.Point(85, 52);
            this.textBoxR.Name = "textBoxR";
            this.textBoxR.Size = new System.Drawing.Size(183, 21);
            this.textBoxR.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "结果：";
            // 
            // textBoxRNCal
            // 
            this.textBoxRNCal.Location = new System.Drawing.Point(85, 81);
            this.textBoxRNCal.Name = "textBoxRNCal";
            this.textBoxRNCal.Size = new System.Drawing.Size(183, 21);
            this.textBoxRNCal.TabIndex = 6;
            // 
            // buttonNCal
            // 
            this.buttonNCal.Location = new System.Drawing.Point(288, 79);
            this.buttonNCal.Name = "buttonNCal";
            this.buttonNCal.Size = new System.Drawing.Size(124, 23);
            this.buttonNCal.TabIndex = 5;
            this.buttonNCal.Text = "计算(NCal)";
            this.buttonNCal.UseVisualStyleBackColor = true;
            this.buttonNCal.Click += new System.EventHandler(this.buttonNCal_Click);
            // 
            // FleeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 320);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxRNCal);
            this.Controls.Add(this.buttonNCal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxR);
            this.Controls.Add(this.buttonCal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxF);
            this.Name = "FleeForm";
            this.Text = "FleeForm";
            this.Load += new System.EventHandler(this.FleeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxR;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxRNCal;
        private System.Windows.Forms.Button buttonNCal;
    }
}