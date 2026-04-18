namespace RabinCryptoSys
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            label1 = new Label();
            textBoxP = new TextBox();
            label2 = new Label();
            textBoxQ = new TextBox();
            label3 = new Label();
            textBoxB = new TextBox();
            label4 = new Label();
            textBoxN = new TextBox();
            buttonGenerate = new Button();
            buttonCheck = new Button();
            label5 = new Label();
            buttonSelectFile = new Button();
            textBoxFilePath = new TextBox();
            groupBox1 = new GroupBox();
            radioDecrypt = new RadioButton();
            radioEncrypt = new RadioButton();
            buttonProcess = new Button();
            groupBox2 = new GroupBox();
            textBoxOriginal = new TextBox();
            groupBox3 = new GroupBox();
            textBoxEncrypted = new TextBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 11F);
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(26, 24);
            label1.TabIndex = 0;
            label1.Text = "p:";
            // 
            // textBoxP
            // 
            textBoxP.Font = new Font("Courier New", 11F);
            textBoxP.Location = new Point(50, 13);
            textBoxP.Name = "textBoxP";
            textBoxP.Size = new Size(100, 28);
            textBoxP.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 11F);
            label2.Location = new Point(170, 15);
            label2.Name = "label2";
            label2.Size = new Size(26, 24);
            label2.TabIndex = 2;
            label2.Text = "q:";
            // 
            // textBoxQ
            // 
            textBoxQ.Font = new Font("Courier New", 11F);
            textBoxQ.Location = new Point(200, 13);
            textBoxQ.Name = "textBoxQ";
            textBoxQ.Size = new Size(100, 28);
            textBoxQ.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 11F);
            label3.Location = new Point(320, 15);
            label3.Name = "label3";
            label3.Size = new Size(26, 24);
            label3.TabIndex = 4;
            label3.Text = "b:";
            // 
            // textBoxB
            // 
            textBoxB.Font = new Font("Courier New", 11F);
            textBoxB.Location = new Point(350, 13);
            textBoxB.Name = "textBoxB";
            textBoxB.Size = new Size(100, 28);
            textBoxB.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 11F);
            label4.Location = new Point(470, 15);
            label4.Name = "label4";
            label4.Size = new Size(26, 24);
            label4.TabIndex = 6;
            label4.Text = "n:";
            // 
            // textBoxN
            // 
            textBoxN.Font = new Font("Courier New", 11F);
            textBoxN.Location = new Point(500, 13);
            textBoxN.Name = "textBoxN";
            textBoxN.ReadOnly = true;
            textBoxN.Size = new Size(150, 28);
            textBoxN.TabIndex = 7;
            // 
            // buttonGenerate
            // 
            buttonGenerate.Font = new Font("Microsoft Sans Serif", 10F);
            buttonGenerate.Location = new Point(670, 10);
            buttonGenerate.Name = "buttonGenerate";
            buttonGenerate.Size = new Size(130, 32);
            buttonGenerate.TabIndex = 8;
            buttonGenerate.Text = "Сгенерировать";
            buttonGenerate.UseVisualStyleBackColor = true;
            // 
            // buttonCheck
            // 
            buttonCheck.Font = new Font("Microsoft Sans Serif", 10F);
            buttonCheck.Location = new Point(810, 10);
            buttonCheck.Name = "buttonCheck";
            buttonCheck.Size = new Size(120, 32);
            buttonCheck.TabIndex = 9;
            buttonCheck.Text = "Проверить";
            buttonCheck.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 11F);
            label5.Location = new Point(12, 60);
            label5.Name = "label5";
            label5.Size = new Size(155, 24);
            label5.TabIndex = 10;
            label5.Text = "Выберите файл:";
            // 
            // buttonSelectFile
            // 
            buttonSelectFile.Font = new Font("Microsoft Sans Serif", 10F);
            buttonSelectFile.Location = new Point(170, 55);
            buttonSelectFile.Name = "buttonSelectFile";
            buttonSelectFile.Size = new Size(120, 36);
            buttonSelectFile.TabIndex = 11;
            buttonSelectFile.Text = "Обзор...";
            buttonSelectFile.UseVisualStyleBackColor = true;
            // 
            // textBoxFilePath
            // 
            textBoxFilePath.Font = new Font("Microsoft Sans Serif", 10F);
            textBoxFilePath.Location = new Point(300, 60);
            textBoxFilePath.Name = "textBoxFilePath";
            textBoxFilePath.ReadOnly = true;
            textBoxFilePath.Size = new Size(630, 26);
            textBoxFilePath.TabIndex = 12;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioDecrypt);
            groupBox1.Controls.Add(radioEncrypt);
            groupBox1.Font = new Font("Microsoft Sans Serif", 10F);
            groupBox1.Location = new Point(12, 105);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(250, 95);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "Операция";
            // 
            // radioDecrypt
            // 
            radioDecrypt.AutoSize = true;
            radioDecrypt.Font = new Font("Microsoft Sans Serif", 11F);
            radioDecrypt.Location = new Point(20, 55);
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
            radioEncrypt.Font = new Font("Microsoft Sans Serif", 11F);
            radioEncrypt.Location = new Point(20, 25);
            radioEncrypt.Name = "radioEncrypt";
            radioEncrypt.Size = new Size(157, 28);
            radioEncrypt.TabIndex = 0;
            radioEncrypt.TabStop = true;
            radioEncrypt.Text = "Зашифровать";
            radioEncrypt.UseVisualStyleBackColor = true;
            // 
            // buttonProcess
            // 
            buttonProcess.BackColor = Color.LightGray;
            buttonProcess.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            buttonProcess.Location = new Point(280, 120);
            buttonProcess.Name = "buttonProcess";
            buttonProcess.Size = new Size(650, 50);
            buttonProcess.TabIndex = 14;
            buttonProcess.Text = "ВЫПОЛНИТЬ";
            buttonProcess.UseVisualStyleBackColor = false;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBoxOriginal);
            groupBox2.Font = new Font("Microsoft Sans Serif", 11F);
            groupBox2.Location = new Point(12, 210);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(920, 257);
            groupBox2.TabIndex = 15;
            groupBox2.TabStop = false;
            groupBox2.Text = "Исходный файл (байты)";
            // 
            // textBoxOriginal
            // 
            textBoxOriginal.Font = new Font("Courier New", 10F);
            textBoxOriginal.Location = new Point(15, 25);
            textBoxOriginal.Multiline = true;
            textBoxOriginal.Name = "textBoxOriginal";
            textBoxOriginal.ReadOnly = true;
            textBoxOriginal.ScrollBars = ScrollBars.Vertical;
            textBoxOriginal.Size = new Size(890, 226);
            textBoxOriginal.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(textBoxEncrypted);
            groupBox3.Font = new Font("Microsoft Sans Serif", 11F);
            groupBox3.Location = new Point(12, 473);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(920, 267);
            groupBox3.TabIndex = 16;
            groupBox3.TabStop = false;
            groupBox3.Text = "Зашифрованный файл (десятичные числа)";
            // 
            // textBoxEncrypted
            // 
            textBoxEncrypted.Font = new Font("Courier New", 10F);
            textBoxEncrypted.Location = new Point(15, 27);
            textBoxEncrypted.Multiline = true;
            textBoxEncrypted.Name = "textBoxEncrypted";
            textBoxEncrypted.ReadOnly = true;
            textBoxEncrypted.ScrollBars = ScrollBars.Vertical;
            textBoxEncrypted.Size = new Size(890, 234);
            textBoxEncrypted.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(950, 751);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(buttonProcess);
            Controls.Add(groupBox1);
            Controls.Add(textBoxFilePath);
            Controls.Add(buttonSelectFile);
            Controls.Add(label5);
            Controls.Add(buttonCheck);
            Controls.Add(buttonGenerate);
            Controls.Add(textBoxN);
            Controls.Add(label4);
            Controls.Add(textBoxB);
            Controls.Add(label3);
            Controls.Add(textBoxQ);
            Controls.Add(label2);
            Controls.Add(textBoxP);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Криптосистема Рабина";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private TextBox textBoxP;
        private Label label2;
        private TextBox textBoxQ;
        private Label label3;
        private TextBox textBoxB;
        private Label label4;
        private TextBox textBoxN;
        private Button buttonGenerate;
        private Button buttonCheck;
        private Label label5;
        private Button buttonSelectFile;
        private TextBox textBoxFilePath;
        private GroupBox groupBox1;
        private RadioButton radioDecrypt;
        private RadioButton radioEncrypt;
        private Button buttonProcess;
        private GroupBox groupBox2;
        private TextBox textBoxOriginal;
        private GroupBox groupBox3;
        private TextBox textBoxEncrypted;
    }
}