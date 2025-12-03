namespace RenomeadorArquivos
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
            FolderBrowserDialog = new FolderBrowserDialog();
            txtCaminhoPasta = new TextBox();
            button1 = new Button();
            BtnRenomear = new Button();
            label1 = new Label();
            txtLog = new Label();
            SuspendLayout();
            // 
            // txtCaminhoPasta
            // 
            txtCaminhoPasta.Location = new Point(93, 44);
            txtCaminhoPasta.Name = "txtCaminhoPasta";
            txtCaminhoPasta.Size = new Size(672, 23);
            txtCaminhoPasta.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(12, 27);
            button1.Name = "button1";
            button1.Size = new Size(75, 40);
            button1.TabIndex = 1;
            button1.Text = "Escolher Pasta";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // BtnRenomear
            // 
            BtnRenomear.Location = new Point(650, 73);
            BtnRenomear.Name = "BtnRenomear";
            BtnRenomear.Size = new Size(115, 31);
            BtnRenomear.TabIndex = 1;
            BtnRenomear.Text = "Renomear";
            BtnRenomear.UseVisualStyleBackColor = true;
            BtnRenomear.Click += BtnRenomear_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(96, 26);
            label1.Name = "label1";
            label1.Size = new Size(103, 15);
            label1.TabIndex = 2;
            label1.Text = "Caminho da pasta";
            // 
            // txtLog
            // 
            txtLog.AutoSize = true;
            txtLog.Location = new Point(93, 89);
            txtLog.Name = "txtLog";
            txtLog.Size = new Size(42, 15);
            txtLog.TabIndex = 2;
            txtLog.Text = "Status:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 125);
            Controls.Add(txtLog);
            Controls.Add(label1);
            Controls.Add(BtnRenomear);
            Controls.Add(button1);
            Controls.Add(txtCaminhoPasta);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RENOMEADOR DE ARQUIVOS";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FolderBrowserDialog FolderBrowserDialog;
        private TextBox txtCaminhoPasta;
        private Button button1;
        private Button BtnRenomear;
        private Label label1;
        private Label txtLog;
    }
}
