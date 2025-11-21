namespace Regravacao.Views
{
    partial class FrmConfiguracoes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfiguracoes));
            PanelTop = new Panel();
            pictureBox4 = new PictureBox();
            label7 = new Label();
            Btn_maximizar = new PictureBox();
            Btn_minimizar = new PictureBox();
            BtnRestaurarJanela = new PictureBox();
            panel3 = new Panel();
            BtnCancelarConfiguracoes = new Button();
            BtnSalvarConfiguracoes = new Button();
            groupBox3 = new GroupBox();
            TxbMaoObraEOutros = new TextBox();
            label8 = new Label();
            TxbMargem = new TextBox();
            TxbFatorCusto = new TextBox();
            label22 = new Label();
            label46 = new Label();
            panel2 = new Panel();
            PanelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Btn_maximizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Btn_minimizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BtnRestaurarJanela).BeginInit();
            panel3.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // PanelTop
            // 
            PanelTop.BackColor = Color.FromArgb(64, 64, 64);
            PanelTop.Controls.Add(pictureBox4);
            PanelTop.Controls.Add(label7);
            PanelTop.Controls.Add(Btn_maximizar);
            PanelTop.Controls.Add(Btn_minimizar);
            PanelTop.Controls.Add(BtnRestaurarJanela);
            PanelTop.Dock = DockStyle.Top;
            PanelTop.Location = new Point(0, 0);
            PanelTop.Name = "PanelTop";
            PanelTop.Size = new Size(1026, 70);
            PanelTop.TabIndex = 90;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.Transparent;
            pictureBox4.Image = Properties.Resources.administrative_tools_40pxfg;
            pictureBox4.ImeMode = ImeMode.NoControl;
            pictureBox4.Location = new Point(14, 14);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(42, 36);
            pictureBox4.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox4.TabIndex = 15;
            pictureBox4.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label7.ForeColor = SystemColors.ControlLightLight;
            label7.ImeMode = ImeMode.NoControl;
            label7.Location = new Point(62, 14);
            label7.Name = "label7";
            label7.Size = new Size(201, 37);
            label7.TabIndex = 13;
            label7.Text = "Configurações";
            // 
            // Btn_maximizar
            // 
            Btn_maximizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Btn_maximizar.ImeMode = ImeMode.NoControl;
            Btn_maximizar.Location = new Point(4052, 23);
            Btn_maximizar.Name = "Btn_maximizar";
            Btn_maximizar.Size = new Size(37, 34);
            Btn_maximizar.SizeMode = PictureBoxSizeMode.Zoom;
            Btn_maximizar.TabIndex = 12;
            Btn_maximizar.TabStop = false;
            Btn_maximizar.Visible = false;
            // 
            // Btn_minimizar
            // 
            Btn_minimizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Btn_minimizar.Image = (Image)resources.GetObject("Btn_minimizar.Image");
            Btn_minimizar.ImeMode = ImeMode.NoControl;
            Btn_minimizar.Location = new Point(4011, 25);
            Btn_minimizar.Name = "Btn_minimizar";
            Btn_minimizar.Size = new Size(35, 30);
            Btn_minimizar.SizeMode = PictureBoxSizeMode.Zoom;
            Btn_minimizar.TabIndex = 12;
            Btn_minimizar.TabStop = false;
            Btn_minimizar.Visible = false;
            // 
            // BtnRestaurarJanela
            // 
            BtnRestaurarJanela.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnRestaurarJanela.ImeMode = ImeMode.NoControl;
            BtnRestaurarJanela.Location = new Point(4052, 23);
            BtnRestaurarJanela.Name = "BtnRestaurarJanela";
            BtnRestaurarJanela.Size = new Size(37, 34);
            BtnRestaurarJanela.SizeMode = PictureBoxSizeMode.Zoom;
            BtnRestaurarJanela.TabIndex = 12;
            BtnRestaurarJanela.TabStop = false;
            BtnRestaurarJanela.Visible = false;
            // 
            // panel3
            // 
            panel3.BackColor = Color.LightGray;
            panel3.Controls.Add(BtnCancelarConfiguracoes);
            panel3.Controls.Add(BtnSalvarConfiguracoes);
            panel3.Controls.Add(groupBox3);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1026, 642);
            panel3.TabIndex = 89;
            // 
            // BtnCancelarConfiguracoes
            // 
            BtnCancelarConfiguracoes.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnCancelarConfiguracoes.ImeMode = ImeMode.NoControl;
            BtnCancelarConfiguracoes.Location = new Point(915, 575);
            BtnCancelarConfiguracoes.Name = "BtnCancelarConfiguracoes";
            BtnCancelarConfiguracoes.Size = new Size(87, 52);
            BtnCancelarConfiguracoes.TabIndex = 2;
            BtnCancelarConfiguracoes.Text = "CANCELAR";
            BtnCancelarConfiguracoes.UseVisualStyleBackColor = true;
            BtnCancelarConfiguracoes.Click += BtnCancelarConfiguracoes_Click;
            // 
            // BtnSalvarConfiguracoes
            // 
            BtnSalvarConfiguracoes.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnSalvarConfiguracoes.BackColor = Color.DarkSlateGray;
            BtnSalvarConfiguracoes.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            BtnSalvarConfiguracoes.ForeColor = SystemColors.ButtonHighlight;
            BtnSalvarConfiguracoes.ImeMode = ImeMode.NoControl;
            BtnSalvarConfiguracoes.Location = new Point(759, 575);
            BtnSalvarConfiguracoes.Name = "BtnSalvarConfiguracoes";
            BtnSalvarConfiguracoes.Size = new Size(137, 52);
            BtnSalvarConfiguracoes.TabIndex = 1;
            BtnSalvarConfiguracoes.Text = "SALVAR";
            BtnSalvarConfiguracoes.UseVisualStyleBackColor = false;
            BtnSalvarConfiguracoes.Click += BtnSalvarConfiguracoes_Click;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.BackColor = Color.Transparent;
            groupBox3.Controls.Add(TxbMaoObraEOutros);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(TxbMargem);
            groupBox3.Controls.Add(TxbFatorCusto);
            groupBox3.Controls.Add(label22);
            groupBox3.Controls.Add(label46);
            groupBox3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            groupBox3.Location = new Point(14, 105);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(999, 464);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "Informe os dados padrões para calcular o custo do clichê.";
            // 
            // TxbMaoObraEOutros
            // 
            TxbMaoObraEOutros.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            TxbMaoObraEOutros.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            TxbMaoObraEOutros.Location = new Point(560, 331);
            TxbMaoObraEOutros.Name = "TxbMaoObraEOutros";
            TxbMaoObraEOutros.PlaceholderText = "R$";
            TxbMaoObraEOutros.Size = new Size(285, 32);
            TxbMaoObraEOutros.TabIndex = 2;
            TxbMaoObraEOutros.TextAlign = HorizontalAlignment.Center;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label8.Location = new Point(83, 335);
            label8.Name = "label8";
            label8.Size = new Size(442, 21);
            label8.TabIndex = 90;
            label8.Text = "MÃO DE OBRA / HORA MÁQUINA / CUSTOS ACESSÓRIOS ";
            // 
            // TxbMargem
            // 
            TxbMargem.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            TxbMargem.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            TxbMargem.Location = new Point(560, 115);
            TxbMargem.Name = "TxbMargem";
            TxbMargem.PlaceholderText = "cm";
            TxbMargem.Size = new Size(285, 32);
            TxbMargem.TabIndex = 0;
            TxbMargem.TextAlign = HorizontalAlignment.Center;
            // 
            // TxbFatorCusto
            // 
            TxbFatorCusto.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            TxbFatorCusto.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            TxbFatorCusto.Location = new Point(560, 223);
            TxbFatorCusto.Name = "TxbFatorCusto";
            TxbFatorCusto.PlaceholderText = "R$";
            TxbFatorCusto.Size = new Size(285, 32);
            TxbFatorCusto.TabIndex = 1;
            TxbFatorCusto.TextAlign = HorizontalAlignment.Center;
            // 
            // label22
            // 
            label22.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label22.AutoSize = true;
            label22.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label22.Location = new Point(172, 119);
            label22.Name = "label22";
            label22.Size = new Size(353, 21);
            label22.TabIndex = 87;
            label22.Text = "MARGEM TOTAL DE CORTE DO CLICHÊ EM CM";
            label22.TextAlign = ContentAlignment.TopRight;
            // 
            // label46
            // 
            label46.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label46.AutoSize = true;
            label46.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label46.Location = new Point(315, 227);
            label46.Name = "label46";
            label46.Size = new Size(210, 21);
            label46.TabIndex = 88;
            label46.Text = "CUSTO DO CM² DO CLICHÊ";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(48, 48, 48);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 642);
            panel2.Name = "panel2";
            panel2.Size = new Size(1026, 10);
            panel2.TabIndex = 88;
            // 
            // FrmConfiguracoes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1026, 652);
            Controls.Add(PanelTop);
            Controls.Add(panel3);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FrmConfiguracoes";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterParent;
            TopMost = true;
            PanelTop.ResumeLayout(false);
            PanelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)Btn_maximizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)Btn_minimizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)BtnRestaurarJanela).EndInit();
            panel3.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelTop;
        private PictureBox pictureBox4;
        private Label label7;
        private PictureBox Btn_maximizar;
        private PictureBox Btn_minimizar;
        private PictureBox BtnRestaurarJanela;
        private Panel panel3;
        private Button BtnCancelarConfiguracoes;
        private Button BtnSalvarConfiguracoes;
        private GroupBox groupBox3;
        private Panel panel2;
        private TextBox TxbMaoObraEOutros;
        private Label label8;
        private TextBox TxbMargem;
        private TextBox TxbFatorCusto;
        private Label label22;
        private Label label46;
    }
}