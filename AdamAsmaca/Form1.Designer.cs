namespace AdamAsmaca
{
    partial class MainWindow
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
            textBox = new TextBox();
            textBox2 = new TextBox();
            tryBtn = new Button();
            pictureBox1 = new PictureBox();
            retryButton = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // textBox
            // 
            textBox.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 162);
            textBox.Location = new Point(35, 121);
            textBox.Name = "textBox";
            textBox.ReadOnly = true;
            textBox.Size = new Size(450, 47);
            textBox.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(35, 271);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(272, 27);
            textBox2.TabIndex = 1;
            // 
            // tryBtn
            // 
            tryBtn.Location = new Point(380, 271);
            tryBtn.Name = "tryBtn";
            tryBtn.Size = new Size(105, 27);
            tryBtn.TabIndex = 2;
            tryBtn.Text = "Dene!";
            tryBtn.UseVisualStyleBackColor = true;
            tryBtn.Click += tryBtn_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Bos;
            pictureBox1.InitialImage = Properties.Resources.Bos;
            pictureBox1.Location = new Point(567, 45);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(185, 370);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // retryButton
            // 
            retryButton.Location = new Point(380, 329);
            retryButton.Name = "retryButton";
            retryButton.Size = new Size(105, 27);
            retryButton.TabIndex = 4;
            retryButton.Text = "Tekrar";
            retryButton.UseVisualStyleBackColor = true;
            retryButton.Click += retryButton_Click;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(retryButton);
            Controls.Add(pictureBox1);
            Controls.Add(tryBtn);
            Controls.Add(textBox2);
            Controls.Add(textBox);
            Name = "MainWindow";
            Text = "Adam Asmaca";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button startButton;
        private TextBox textBox;
        private TextBox textBox2;
        private Button tryBtn;
        private PictureBox pictureBox1;
        private Button retryButton;
    }
}
