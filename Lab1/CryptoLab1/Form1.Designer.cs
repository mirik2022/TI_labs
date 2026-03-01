namespace CryptoLab1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            comboBoxAlgorithm = new ComboBox();
            comboBoxMode = new ComboBox();
            txtKey = new TextBox();
            txtInput = new TextBox();
            txtResult = new TextBox();
            btnLoadFile = new Button();
            btnSaveFile = new Button();
            btnExecute = new Button();
            openFileDialog = new OpenFileDialog();
            saveFileDialog = new SaveFileDialog();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            labelInput = new Label();
            labelResult = new Label();
            panelTop = new Panel();
            panelBottom = new Panel();
            panelCenter = new Panel();
            statusStrip = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            panelTop.SuspendLayout();
            panelCenter.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // comboBoxAlgorithm
            // 
            comboBoxAlgorithm.BackColor = Color.White;
            comboBoxAlgorithm.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAlgorithm.FlatStyle = FlatStyle.Flat;
            comboBoxAlgorithm.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            comboBoxAlgorithm.FormattingEnabled = true;
            comboBoxAlgorithm.Items.AddRange(new object[] { "Столбцовый метод", "Шифр Виженера" });
            comboBoxAlgorithm.Location = new Point(15, 44);
            comboBoxAlgorithm.Margin = new Padding(3, 4, 3, 4);
            comboBoxAlgorithm.Name = "comboBoxAlgorithm";
            comboBoxAlgorithm.Size = new Size(180, 31);
            comboBoxAlgorithm.TabIndex = 0;
            // 
            // comboBoxMode
            // 
            comboBoxMode.BackColor = Color.White;
            comboBoxMode.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMode.FlatStyle = FlatStyle.Flat;
            comboBoxMode.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            comboBoxMode.FormattingEnabled = true;
            comboBoxMode.Items.AddRange(new object[] { "Зашифровать", "Расшифровать" });
            comboBoxMode.Location = new Point(210, 44);
            comboBoxMode.Margin = new Padding(3, 4, 3, 4);
            comboBoxMode.Name = "comboBoxMode";
            comboBoxMode.Size = new Size(150, 31);
            comboBoxMode.TabIndex = 1;
            // 
            // txtKey
            // 
            txtKey.BackColor = Color.White;
            txtKey.BorderStyle = BorderStyle.FixedSingle;
            txtKey.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtKey.Location = new Point(390, 45);
            txtKey.Margin = new Padding(3, 4, 3, 4);
            txtKey.Name = "txtKey";
            txtKey.Size = new Size(200, 30);
            txtKey.TabIndex = 2;
            // 
            // txtInput
            // 
            txtInput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtInput.BackColor = Color.White;
            txtInput.BorderStyle = BorderStyle.FixedSingle;
            txtInput.Font = new Font("Consolas", 11F);
            txtInput.Location = new Point(15, 49);
            txtInput.Margin = new Padding(3, 4, 3, 4);
            txtInput.Multiline = true;
            txtInput.Name = "txtInput";
            txtInput.ScrollBars = ScrollBars.Vertical;
            txtInput.Size = new Size(433, 201);
            txtInput.TabIndex = 3;
            // 
            // txtResult
            // 
            txtResult.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtResult.BackColor = Color.FromArgb(240, 240, 240);
            txtResult.BorderStyle = BorderStyle.FixedSingle;
            txtResult.Font = new Font("Consolas", 11F);
            txtResult.Location = new Point(459, 49);
            txtResult.Margin = new Padding(3, 4, 3, 4);
            txtResult.Multiline = true;
            txtResult.Name = "txtResult";
            txtResult.ReadOnly = true;
            txtResult.ScrollBars = ScrollBars.Vertical;
            txtResult.Size = new Size(433, 201);
            txtResult.TabIndex = 13;
            // 
            // btnLoadFile
            // 
            btnLoadFile.BackColor = Color.Black;
            btnLoadFile.FlatAppearance.BorderSize = 0;
            btnLoadFile.FlatStyle = FlatStyle.Flat;
            btnLoadFile.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnLoadFile.ForeColor = Color.White;
            btnLoadFile.Location = new Point(18, 282);
            btnLoadFile.Margin = new Padding(3, 4, 3, 4);
            btnLoadFile.Name = "btnLoadFile";
            btnLoadFile.Size = new Size(180, 56);
            btnLoadFile.TabIndex = 4;
            btnLoadFile.Text = "Загрузить из файла";
            btnLoadFile.UseVisualStyleBackColor = false;
            btnLoadFile.Click += btnLoadFile_Click;
            // 
            // btnSaveFile
            // 
            btnSaveFile.BackColor = Color.Black;
            btnSaveFile.FlatAppearance.BorderSize = 0;
            btnSaveFile.FlatStyle = FlatStyle.Flat;
            btnSaveFile.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnSaveFile.ForeColor = Color.White;
            btnSaveFile.Location = new Point(222, 282);
            btnSaveFile.Margin = new Padding(3, 4, 3, 4);
            btnSaveFile.Name = "btnSaveFile";
            btnSaveFile.Size = new Size(180, 56);
            btnSaveFile.TabIndex = 5;
            btnSaveFile.Text = "Сохранить в файл";
            btnSaveFile.UseVisualStyleBackColor = false;
            btnSaveFile.Click += btnSaveFile_Click;
            // 
            // btnExecute
            // 
            btnExecute.BackColor = Color.Black;
            btnExecute.FlatAppearance.BorderSize = 0;
            btnExecute.FlatStyle = FlatStyle.Flat;
            btnExecute.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnExecute.ForeColor = Color.White;
            btnExecute.Location = new Point(620, 31);
            btnExecute.Margin = new Padding(3, 4, 3, 4);
            btnExecute.Name = "btnExecute";
            btnExecute.Size = new Size(200, 62);
            btnExecute.TabIndex = 6;
            btnExecute.Text = "ВЫПОЛНИТЬ";
            btnExecute.UseVisualStyleBackColor = false;
            btnExecute.Click += btnExecute_Click;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog";
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            // 
            // saveFileDialog
            // 
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.FromArgb(52, 73, 94);
            label1.Location = new Point(15, 19);
            label1.Name = "label1";
            label1.Size = new Size(77, 20);
            label1.TabIndex = 7;
            label1.Text = "Алгоритм";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.ForeColor = Color.FromArgb(52, 73, 94);
            label2.Location = new Point(210, 19);
            label2.Name = "label2";
            label2.Size = new Size(56, 20);
            label2.TabIndex = 8;
            label2.Text = "Режим";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.ForeColor = Color.FromArgb(52, 73, 94);
            label3.Location = new Point(390, 19);
            label3.Name = "label3";
            label3.Size = new Size(46, 20);
            label3.TabIndex = 9;
            label3.Text = "Ключ";
            // 
            // labelInput
            // 
            labelInput.AutoSize = true;
            labelInput.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelInput.ForeColor = Color.FromArgb(52, 73, 94);
            labelInput.Location = new Point(15, 25);
            labelInput.Name = "labelInput";
            labelInput.Size = new Size(121, 20);
            labelInput.TabIndex = 11;
            labelInput.Text = "Исходный текст:";
            // 
            // labelResult
            // 
            labelResult.AutoSize = true;
            labelResult.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelResult.ForeColor = Color.FromArgb(52, 73, 94);
            labelResult.Location = new Point(456, 25);
            labelResult.Name = "labelResult";
            labelResult.Size = new Size(78, 20);
            labelResult.TabIndex = 12;
            labelResult.Text = "Результат:";
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(236, 240, 241);
            panelTop.Controls.Add(label1);
            panelTop.Controls.Add(label3);
            panelTop.Controls.Add(comboBoxAlgorithm);
            panelTop.Controls.Add(label2);
            panelTop.Controls.Add(comboBoxMode);
            panelTop.Controls.Add(txtKey);
            panelTop.Controls.Add(btnExecute);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(3, 4, 3, 4);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(910, 125);
            panelTop.TabIndex = 11;
            // 
            // panelBottom
            // 
            panelBottom.BackColor = Color.FromArgb(236, 240, 241);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 655);
            panelBottom.Margin = new Padding(3, 4, 3, 4);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(910, 26);
            panelBottom.TabIndex = 12;
            // 
            // panelCenter
            // 
            panelCenter.BackColor = Color.White;
            panelCenter.Controls.Add(btnSaveFile);
            panelCenter.Controls.Add(btnLoadFile);
            panelCenter.Controls.Add(labelInput);
            panelCenter.Controls.Add(txtInput);
            panelCenter.Controls.Add(labelResult);
            panelCenter.Controls.Add(txtResult);
            panelCenter.Dock = DockStyle.Fill;
            panelCenter.Location = new Point(0, 125);
            panelCenter.Margin = new Padding(3, 4, 3, 4);
            panelCenter.Name = "panelCenter";
            panelCenter.Padding = new Padding(15);
            panelCenter.Size = new Size(910, 530);
            panelCenter.TabIndex = 13;
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel });
            statusStrip.Location = new Point(0, 681);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(910, 22);
            statusStrip.TabIndex = 14;
            statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Font = new Font("Segoe UI", 9F);
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(0, 16);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(910, 703);
            Controls.Add(panelCenter);
            Controls.Add(panelTop);
            Controls.Add(panelBottom);
            Controls.Add(statusStrip);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(800, 750);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Load += Form1_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelCenter.ResumeLayout(false);
            panelCenter.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxAlgorithm;
        private System.Windows.Forms.ComboBox comboBoxMode;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label labelInput;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.Button btnSaveFile;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
    }
}