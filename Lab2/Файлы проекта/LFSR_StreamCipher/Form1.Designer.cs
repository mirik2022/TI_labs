namespace LFSR_StreamCipher
{
    partial class Form1
    {
        /// Обязательная переменная конструктора.
        private System.ComponentModel.IContainer components = null;

        /// Освободить все используемые ресурсы.
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        private void InitializeComponent()
        {
            label2 = new Label();
            textBoxState = new TextBox();
            label3 = new Label();
            buttonSelectFile = new Button();
            textBoxFilePath = new TextBox();
            groupBox1 = new GroupBox();
            radioDecrypt = new RadioButton();
            radioEncrypt = new RadioButton();
            buttonProcess = new Button();
            groupBox2 = new GroupBox();
            textBoxKey = new TextBox();
            groupBox3 = new GroupBox();
            textBoxOriginal = new TextBox();
            groupBox4 = new GroupBox();
            textBoxEncrypted = new TextBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(384, 24);
            label2.TabIndex = 1;
            label2.Text = "Начальное состояние регистра (32 бита):";
            // 
            // textBoxState
            // 
            textBoxState.Font = new Font("Courier New", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxState.Location = new Point(410, 9);
            textBoxState.Margin = new Padding(3, 4, 3, 4);
            textBoxState.MaxLength = 32;
            textBoxState.Name = "textBoxState";
            textBoxState.Size = new Size(680, 34);
            textBoxState.TabIndex = 2;
            textBoxState.Text = "11001010101111001100110011110011";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(16, 64);
            label3.Name = "label3";
            label3.Size = new Size(155, 24);
            label3.TabIndex = 3;
            label3.Text = "Выберите файл:";
            // 
            // buttonSelectFile
            // 
            buttonSelectFile.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonSelectFile.Location = new Point(176, 58);
            buttonSelectFile.Margin = new Padding(3, 4, 3, 4);
            buttonSelectFile.Name = "buttonSelectFile";
            buttonSelectFile.Size = new Size(120, 44);
            buttonSelectFile.TabIndex = 4;
            buttonSelectFile.Text = "Обзор...";
            buttonSelectFile.UseVisualStyleBackColor = true;
            // 
            // textBoxFilePath
            // 
            textBoxFilePath.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxFilePath.Location = new Point(306, 60);
            textBoxFilePath.Margin = new Padding(3, 4, 3, 4);
            textBoxFilePath.Name = "textBoxFilePath";
            textBoxFilePath.ReadOnly = true;
            textBoxFilePath.Size = new Size(780, 26);
            textBoxFilePath.TabIndex = 5;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioDecrypt);
            groupBox1.Controls.Add(radioEncrypt);
            groupBox1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            groupBox1.Location = new Point(20, 120);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(250, 112);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Операция";
            // 
            // radioDecrypt
            // 
            radioDecrypt.AutoSize = true;
            radioDecrypt.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 204);
            radioDecrypt.Location = new Point(25, 71);
            radioDecrypt.Margin = new Padding(3, 4, 3, 4);
            radioDecrypt.Name = "radioDecrypt";
            radioDecrypt.Size = new Size(166, 28);
            radioDecrypt.TabIndex = 1;
            radioDecrypt.Text = "Расшифровать";
            radioDecrypt.UseVisualStyleBackColor = true;
            // 
            // radioEncrypt
            // 
            radioEncrypt.AutoSize = true;
            radioEncrypt.Checked = true;
            radioEncrypt.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 204);
            radioEncrypt.Location = new Point(25, 32);
            radioEncrypt.Margin = new Padding(3, 4, 3, 4);
            radioEncrypt.Name = "radioEncrypt";
            radioEncrypt.Size = new Size(157, 28);
            radioEncrypt.TabIndex = 0;
            radioEncrypt.TabStop = true;
            radioEncrypt.Text = "Зашифровать";
            radioEncrypt.UseVisualStyleBackColor = true;
            // 
            // buttonProcess
            // 
            buttonProcess.BackColor = Color.Gray;
            buttonProcess.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonProcess.Location = new Point(396, 152);
            buttonProcess.Margin = new Padding(3, 4, 3, 4);
            buttonProcess.Name = "buttonProcess";
            buttonProcess.Size = new Size(588, 48);
            buttonProcess.TabIndex = 7;
            buttonProcess.Text = "ВЫПОЛНИТЬ";
            buttonProcess.UseVisualStyleBackColor = false;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBoxKey);
            groupBox2.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 204);
            groupBox2.Location = new Point(20, 258);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(1066, 220);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Сгенерированный ключ";
            groupBox2.Enter += groupBox2_Enter;
            // 
            // textBoxKey
            // 
            textBoxKey.Font = new Font("Courier New", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxKey.Location = new Point(15, 40);
            textBoxKey.Margin = new Padding(3, 4, 3, 4);
            textBoxKey.Multiline = true;
            textBoxKey.Name = "textBoxKey";
            textBoxKey.ReadOnly = true;
            textBoxKey.ScrollBars = ScrollBars.Vertical;
            textBoxKey.Size = new Size(1035, 160);
            textBoxKey.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(textBoxOriginal);
            groupBox3.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 204);
            groupBox3.Location = new Point(24, 493);
            groupBox3.Margin = new Padding(3, 4, 3, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 4, 3, 4);
            groupBox3.Size = new Size(1066, 196);
            groupBox3.TabIndex = 9;
            groupBox3.TabStop = false;
            groupBox3.Text = "Исходный файл";
            // 
            // textBoxOriginal
            // 
            textBoxOriginal.Font = new Font("Courier New", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxOriginal.Location = new Point(15, 29);
            textBoxOriginal.Margin = new Padding(3, 4, 3, 4);
            textBoxOriginal.Multiline = true;
            textBoxOriginal.Name = "textBoxOriginal";
            textBoxOriginal.ReadOnly = true;
            textBoxOriginal.ScrollBars = ScrollBars.Vertical;
            textBoxOriginal.Size = new Size(1035, 159);
            textBoxOriginal.TabIndex = 0;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(textBoxEncrypted);
            groupBox4.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 204);
            groupBox4.Location = new Point(24, 692);
            groupBox4.Margin = new Padding(3, 4, 3, 4);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(3, 4, 3, 4);
            groupBox4.Size = new Size(1066, 216);
            groupBox4.TabIndex = 10;
            groupBox4.TabStop = false;
            groupBox4.Text = "Зашифрованный файл";
            // 
            // textBoxEncrypted
            // 
            textBoxEncrypted.Font = new Font("Courier New", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxEncrypted.Location = new Point(15, 39);
            textBoxEncrypted.Margin = new Padding(3, 4, 3, 4);
            textBoxEncrypted.Multiline = true;
            textBoxEncrypted.Name = "textBoxEncrypted";
            textBoxEncrypted.ReadOnly = true;
            textBoxEncrypted.ScrollBars = ScrollBars.Vertical;
            textBoxEncrypted.Size = new Size(1035, 165);
            textBoxEncrypted.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1120, 921);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(buttonProcess);
            Controls.Add(groupBox1);
            Controls.Add(textBoxFilePath);
            Controls.Add(buttonSelectFile);
            Controls.Add(label3);
            Controls.Add(textBoxState);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxState;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonSelectFile;
        private System.Windows.Forms.TextBox textBoxFilePath;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioDecrypt;
        private System.Windows.Forms.RadioButton radioEncrypt;
        private System.Windows.Forms.Button buttonProcess;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxKey;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBoxOriginal;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBoxEncrypted;
    }
}
