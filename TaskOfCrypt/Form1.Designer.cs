namespace TaskOfCrypt
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBoxBaseText = new System.Windows.Forms.TextBox();
            this.textBoxKey = new System.Windows.Forms.TextBox();
            this.buttonGenerateCryptAlhabet = new System.Windows.Forms.Button();
            this.textBoxCryptText = new System.Windows.Forms.TextBox();
            this.buttonCrypt = new System.Windows.Forms.Button();
            this.buttonDecrypt = new System.Windows.Forms.Button();
            this.radioButtonMonoAlphabet = new System.Windows.Forms.RadioButton();
            this.radioButtonPermutationMethod = new System.Windows.Forms.RadioButton();
            this.radioButtonMethodOfDivide = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // textBoxBaseText
            // 
            this.textBoxBaseText.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxBaseText.Location = new System.Drawing.Point(0, 37);
            this.textBoxBaseText.MinimumSize = new System.Drawing.Size(600, 0);
            this.textBoxBaseText.Multiline = true;
            this.textBoxBaseText.Name = "textBoxBaseText";
            this.textBoxBaseText.Size = new System.Drawing.Size(669, 165);
            this.textBoxBaseText.TabIndex = 0;
            this.textBoxBaseText.Text = resources.GetString("textBoxBaseText.Text");
            // 
            // textBoxKey
            // 
            this.textBoxKey.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxKey.Location = new System.Drawing.Point(12, 224);
            this.textBoxKey.MinimumSize = new System.Drawing.Size(300, 0);
            this.textBoxKey.Multiline = true;
            this.textBoxKey.Name = "textBoxKey";
            this.textBoxKey.Size = new System.Drawing.Size(300, 70);
            this.textBoxKey.TabIndex = 1;
            this.textBoxKey.Text = "Без предисловий, сей же час Позвольте познакомить вас:";
            // 
            // buttonGenerateCryptAlhabet
            // 
            this.buttonGenerateCryptAlhabet.Enabled = false;
            this.buttonGenerateCryptAlhabet.Location = new System.Drawing.Point(318, 313);
            this.buttonGenerateCryptAlhabet.Name = "buttonGenerateCryptAlhabet";
            this.buttonGenerateCryptAlhabet.Size = new System.Drawing.Size(113, 43);
            this.buttonGenerateCryptAlhabet.TabIndex = 2;
            this.buttonGenerateCryptAlhabet.Text = "Генерация крипто-алфавита";
            this.buttonGenerateCryptAlhabet.UseVisualStyleBackColor = true;
            this.buttonGenerateCryptAlhabet.Visible = false;
            this.buttonGenerateCryptAlhabet.Click += new System.EventHandler(this.buttonGenerateCryptAlhabet_Click);
            // 
            // textBoxCryptText
            // 
            this.textBoxCryptText.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxCryptText.Location = new System.Drawing.Point(0, 362);
            this.textBoxCryptText.MinimumSize = new System.Drawing.Size(600, 0);
            this.textBoxCryptText.Multiline = true;
            this.textBoxCryptText.Name = "textBoxCryptText";
            this.textBoxCryptText.Size = new System.Drawing.Size(669, 165);
            this.textBoxCryptText.TabIndex = 4;
            // 
            // buttonCrypt
            // 
            this.buttonCrypt.Location = new System.Drawing.Point(437, 313);
            this.buttonCrypt.Name = "buttonCrypt";
            this.buttonCrypt.Size = new System.Drawing.Size(113, 43);
            this.buttonCrypt.TabIndex = 5;
            this.buttonCrypt.Text = "Зашифровать";
            this.buttonCrypt.UseVisualStyleBackColor = true;
            this.buttonCrypt.Click += new System.EventHandler(this.buttonCrypt_Click);
            // 
            // buttonDecrypt
            // 
            this.buttonDecrypt.Location = new System.Drawing.Point(556, 313);
            this.buttonDecrypt.Name = "buttonDecrypt";
            this.buttonDecrypt.Size = new System.Drawing.Size(113, 43);
            this.buttonDecrypt.TabIndex = 6;
            this.buttonDecrypt.Text = "Расшифровать";
            this.buttonDecrypt.UseVisualStyleBackColor = true;
            this.buttonDecrypt.Click += new System.EventHandler(this.buttonDecrypt_Click);
            // 
            // radioButtonMonoAlphabet
            // 
            this.radioButtonMonoAlphabet.AutoSize = true;
            this.radioButtonMonoAlphabet.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButtonMonoAlphabet.Location = new System.Drawing.Point(12, 12);
            this.radioButtonMonoAlphabet.Name = "radioButtonMonoAlphabet";
            this.radioButtonMonoAlphabet.Size = new System.Drawing.Size(164, 19);
            this.radioButtonMonoAlphabet.TabIndex = 7;
            this.radioButtonMonoAlphabet.TabStop = true;
            this.radioButtonMonoAlphabet.Text = "Моноалфавитная замена";
            this.radioButtonMonoAlphabet.UseVisualStyleBackColor = true;
            // 
            // radioButtonPermutationMethod
            // 
            this.radioButtonPermutationMethod.AutoSize = true;
            this.radioButtonPermutationMethod.Location = new System.Drawing.Point(182, 12);
            this.radioButtonPermutationMethod.Name = "radioButtonPermutationMethod";
            this.radioButtonPermutationMethod.Size = new System.Drawing.Size(139, 19);
            this.radioButtonPermutationMethod.TabIndex = 8;
            this.radioButtonPermutationMethod.TabStop = true;
            this.radioButtonPermutationMethod.Text = "Метод перестановки";
            this.radioButtonPermutationMethod.UseVisualStyleBackColor = true;
            // 
            // radioButtonMethodOfDivide
            // 
            this.radioButtonMethodOfDivide.AutoSize = true;
            this.radioButtonMethodOfDivide.Location = new System.Drawing.Point(327, 12);
            this.radioButtonMethodOfDivide.Name = "radioButtonMethodOfDivide";
            this.radioButtonMethodOfDivide.Size = new System.Drawing.Size(123, 19);
            this.radioButtonMethodOfDivide.TabIndex = 9;
            this.radioButtonMethodOfDivide.TabStop = true;
            this.radioButtonMethodOfDivide.Text = "Метод дробления";
            this.radioButtonMethodOfDivide.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 551);
            this.Controls.Add(this.radioButtonMethodOfDivide);
            this.Controls.Add(this.radioButtonPermutationMethod);
            this.Controls.Add(this.radioButtonMonoAlphabet);
            this.Controls.Add(this.buttonDecrypt);
            this.Controls.Add(this.buttonCrypt);
            this.Controls.Add(this.textBoxCryptText);
            this.Controls.Add(this.buttonGenerateCryptAlhabet);
            this.Controls.Add(this.textBoxKey);
            this.Controls.Add(this.textBoxBaseText);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBoxBaseText;
        private TextBox textBoxKey;
        private Button buttonGenerateCryptAlhabet;
        private TextBox textBoxCryptText;
        private Button buttonCrypt;
        private Button buttonDecrypt;
        private RadioButton radioButtonMonoAlphabet;
        private RadioButton radioButtonPermutationMethod;
        private RadioButton radioButtonMethodOfDivide;
    }
}