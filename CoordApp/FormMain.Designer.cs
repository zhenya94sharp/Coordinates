
namespace CoordApp
{
    partial class FormMain
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
            this.buttonLoadPoints = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxAdress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.maskedTextBoxFrequency = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // buttonLoadPoints
            // 
            this.buttonLoadPoints.Location = new System.Drawing.Point(188, 133);
            this.buttonLoadPoints.Name = "buttonLoadPoints";
            this.buttonLoadPoints.Size = new System.Drawing.Size(137, 33);
            this.buttonLoadPoints.TabIndex = 0;
            this.buttonLoadPoints.Text = "Загрузить точки";
            this.buttonLoadPoints.UseVisualStyleBackColor = true;
            this.buttonLoadPoints.Click += new System.EventHandler(this.buttonLoadPoints_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Введите адрес";
            // 
            // textBoxAdress
            // 
            this.textBoxAdress.Location = new System.Drawing.Point(16, 54);
            this.textBoxAdress.Multiline = true;
            this.textBoxAdress.Name = "textBoxAdress";
            this.textBoxAdress.Size = new System.Drawing.Size(294, 23);
            this.textBoxAdress.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 311);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Укажите частоту точек";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(188, 376);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(137, 33);
            this.buttonSave.TabIndex = 9;
            this.buttonSave.Text = "Сохранить файл";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // maskedTextBoxFrequency
            // 
            this.maskedTextBoxFrequency.Location = new System.Drawing.Point(16, 340);
            this.maskedTextBoxFrequency.Mask = "000";
            this.maskedTextBoxFrequency.Name = "maskedTextBoxFrequency";
            this.maskedTextBoxFrequency.Size = new System.Drawing.Size(100, 23);
            this.maskedTextBoxFrequency.TabIndex = 10;
            this.maskedTextBoxFrequency.ValidatingType = typeof(int);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 421);
            this.Controls.Add(this.maskedTextBoxFrequency);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxAdress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonLoadPoints);
            this.Name = "FormMain";
            this.Text = "CordApp";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLoadPoints;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSave;
        public System.Windows.Forms.TextBox textBoxAdress;
        public System.Windows.Forms.SaveFileDialog saveFileDialog;
        public System.Windows.Forms.MaskedTextBox maskedTextBoxFrequency;
    }
}

