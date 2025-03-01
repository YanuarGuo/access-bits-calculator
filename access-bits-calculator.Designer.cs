namespace access_bits_calculator
{
    partial class AccessBitsCalculator
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
            tcAccessBits = new TabControl();
            tpBlock0 = new TabPage();
            tpBlock1 = new TabPage();
            tpBlock2 = new TabPage();
            tpST = new TabPage();
            label1 = new Label();
            tbAB0 = new TextBox();
            tbAB1 = new TextBox();
            tbAB2 = new TextBox();
            tbAB3 = new TextBox();
            bCalcAccBits = new Button();
            label2 = new Label();
            label3 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            tcAccessBits.SuspendLayout();
            SuspendLayout();
            // 
            // tcAccessBits
            // 
            tcAccessBits.Controls.Add(tpBlock0);
            tcAccessBits.Controls.Add(tpBlock1);
            tcAccessBits.Controls.Add(tpBlock2);
            tcAccessBits.Controls.Add(tpST);
            tcAccessBits.Location = new Point(57, 17);
            tcAccessBits.Name = "tcAccessBits";
            tcAccessBits.SelectedIndex = 0;
            tcAccessBits.Size = new Size(415, 260);
            tcAccessBits.TabIndex = 0;
            // 
            // tpBlock0
            // 
            tpBlock0.Location = new Point(4, 24);
            tpBlock0.Name = "tpBlock0";
            tpBlock0.Padding = new Padding(3);
            tpBlock0.Size = new Size(407, 232);
            tpBlock0.TabIndex = 0;
            tpBlock0.Text = "Data Block 0";
            tpBlock0.UseVisualStyleBackColor = true;
            // 
            // tpBlock1
            // 
            tpBlock1.Location = new Point(4, 24);
            tpBlock1.Name = "tpBlock1";
            tpBlock1.Padding = new Padding(3);
            tpBlock1.Size = new Size(407, 232);
            tpBlock1.TabIndex = 1;
            tpBlock1.Text = "Data Block 1";
            tpBlock1.UseVisualStyleBackColor = true;
            // 
            // tpBlock2
            // 
            tpBlock2.Location = new Point(4, 24);
            tpBlock2.Name = "tpBlock2";
            tpBlock2.Padding = new Padding(3);
            tpBlock2.Size = new Size(407, 232);
            tpBlock2.TabIndex = 2;
            tpBlock2.Text = "Data Block 2";
            tpBlock2.UseVisualStyleBackColor = true;
            // 
            // tpST
            // 
            tpST.Location = new Point(4, 24);
            tpST.Name = "tpST";
            tpST.Padding = new Padding(3);
            tpST.Size = new Size(407, 232);
            tpST.TabIndex = 3;
            tpST.Text = "Sector Trailer";
            tpST.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(58, 286);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 1;
            label1.Text = "Access Bits";
            // 
            // tbAB0
            // 
            tbAB0.Location = new Point(129, 283);
            tbAB0.MaxLength = 2;
            tbAB0.Name = "tbAB0";
            tbAB0.Size = new Size(31, 23);
            tbAB0.TabIndex = 2;
            // 
            // tbAB1
            // 
            tbAB1.Location = new Point(166, 283);
            tbAB1.MaxLength = 2;
            tbAB1.Name = "tbAB1";
            tbAB1.Size = new Size(31, 23);
            tbAB1.TabIndex = 3;
            // 
            // tbAB2
            // 
            tbAB2.Location = new Point(203, 283);
            tbAB2.MaxLength = 2;
            tbAB2.Name = "tbAB2";
            tbAB2.Size = new Size(31, 23);
            tbAB2.TabIndex = 4;
            // 
            // tbAB3
            // 
            tbAB3.Location = new Point(240, 283);
            tbAB3.MaxLength = 2;
            tbAB3.Name = "tbAB3";
            tbAB3.Size = new Size(31, 23);
            tbAB3.TabIndex = 5;
            // 
            // bCalcAccBits
            // 
            bCalcAccBits.Location = new Point(386, 279);
            bCalcAccBits.Name = "bCalcAccBits";
            bCalcAccBits.Size = new Size(82, 23);
            bCalcAccBits.TabIndex = 6;
            bCalcAccBits.Text = "Confirm";
            bCalcAccBits.UseVisualStyleBackColor = true;
            bCalcAccBits.Click += bCalcAccBits_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 74);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 0;
            label2.Text = "0 0 0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 99);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 7;
            label3.Text = "0 1 0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(21, 250);
            label5.Name = "label5";
            label5.Size = new Size(31, 15);
            label5.TabIndex = 9;
            label5.Text = "1 1 1";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(21, 224);
            label6.Name = "label6";
            label6.Size = new Size(31, 15);
            label6.TabIndex = 10;
            label6.Text = "1 0 1";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(21, 197);
            label7.Name = "label7";
            label7.Size = new Size(31, 15);
            label7.TabIndex = 11;
            label7.Text = "0 1 1";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(21, 173);
            label8.Name = "label8";
            label8.Size = new Size(31, 15);
            label8.TabIndex = 12;
            label8.Text = "0 0 1";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(21, 149);
            label9.Name = "label9";
            label9.Size = new Size(31, 15);
            label9.TabIndex = 13;
            label9.Text = "1 1 0";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(21, 125);
            label10.Name = "label10";
            label10.Size = new Size(31, 15);
            label10.TabIndex = 14;
            label10.Text = "1 0 0";
            // 
            // AccessBitsCalculator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(496, 340);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(bCalcAccBits);
            Controls.Add(tbAB3);
            Controls.Add(tbAB2);
            Controls.Add(tbAB1);
            Controls.Add(tbAB0);
            Controls.Add(label1);
            Controls.Add(tcAccessBits);
            Name = "AccessBitsCalculator";
            Text = "Form1";
            tcAccessBits.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tcAccessBits;
        private TabPage tpBlock0;
        private TabPage tpBlock1;
        private TabPage tpBlock2;
        private TabPage tpST;
        private Label label1;
        private TextBox tbAB0;
        private TextBox tbAB1;
        private TextBox tbAB2;
        private TextBox tbAB3;
        private Button bCalcAccBits;
        private Label label2;
        private Label label3;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
    }
}
