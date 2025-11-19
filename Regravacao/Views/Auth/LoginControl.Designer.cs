namespace Regravacao.Views
{
    partial class LoginControl
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            PanelTop = new Panel();
            pictureBox1 = new PictureBox();
            pictureBox4 = new PictureBox();
            label7 = new Label();
            panel3 = new Panel();
            lblStatus = new Label();
            groupBox1 = new GroupBox();
            TxbSenha = new TextBox();
            groupBox3 = new GroupBox();
            TxbEmail = new TextBox();
            BtnSolicitarAcesso = new Button();
            BtnCancelarLogin = new Button();
            BtnEntrarLogin = new Button();
            panel2 = new Panel();
            PanelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            panel3.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // PanelTop
            // 
            PanelTop.BackColor = Color.FromArgb(64, 64, 64);
            PanelTop.Controls.Add(pictureBox1);
            PanelTop.Controls.Add(pictureBox4);
            PanelTop.Controls.Add(label7);
            PanelTop.Dock = DockStyle.Top;
            PanelTop.Location = new Point(0, 0);
            PanelTop.Name = "PanelTop";
            PanelTop.Size = new Size(541, 100);
            PanelTop.TabIndex = 93;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Properties.Resources.ENGSOFT_LOGO_NOVA2;
            pictureBox1.ImeMode = ImeMode.NoControl;
            pictureBox1.Location = new Point(19, 16);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(221, 68);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.Transparent;
            pictureBox4.Image = Properties.Resources.user_80px;
            pictureBox4.ImeMode = ImeMode.NoControl;
            pictureBox4.Location = new Point(390, 29);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(42, 36);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 15;
            pictureBox4.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label7.ForeColor = SystemColors.ControlLightLight;
            label7.ImeMode = ImeMode.NoControl;
            label7.Location = new Point(427, 28);
            label7.Name = "label7";
            label7.Size = new Size(89, 37);
            label7.TabIndex = 13;
            label7.Text = "Login";
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            panel3.BackColor = Color.LightGray;
            panel3.Controls.Add(lblStatus);
            panel3.Controls.Add(groupBox1);
            panel3.Controls.Add(groupBox3);
            panel3.Controls.Add(BtnSolicitarAcesso);
            panel3.Controls.Add(BtnCancelarLogin);
            panel3.Controls.Add(BtnEntrarLogin);
            panel3.Location = new Point(2, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(541, 459);
            panel3.TabIndex = 92;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(46, 359);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 15);
            lblStatus.TabIndex = 3;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(TxbSenha);
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            groupBox1.Location = new Point(46, 269);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(446, 78);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Senha";
            // 
            // TxbSenha
            // 
            TxbSenha.BorderStyle = BorderStyle.None;
            TxbSenha.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            TxbSenha.Location = new Point(21, 30);
            TxbSenha.Name = "TxbSenha";
            TxbSenha.PasswordChar = '*';
            TxbSenha.Size = new Size(400, 25);
            TxbSenha.TabIndex = 1;
            // 
            // groupBox3
            // 
            groupBox3.BackColor = Color.Transparent;
            groupBox3.Controls.Add(TxbEmail);
            groupBox3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            groupBox3.Location = new Point(46, 153);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(446, 78);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "Email";
            // 
            // TxbEmail
            // 
            TxbEmail.BorderStyle = BorderStyle.None;
            TxbEmail.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            TxbEmail.Location = new Point(21, 30);
            TxbEmail.Name = "TxbEmail";
            TxbEmail.Size = new Size(400, 25);
            TxbEmail.TabIndex = 0;
            // 
            // BtnSolicitarAcesso
            // 
            BtnSolicitarAcesso.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnSolicitarAcesso.BackColor = Color.Transparent;
            BtnSolicitarAcesso.FlatAppearance.BorderSize = 0;
            BtnSolicitarAcesso.FlatStyle = FlatStyle.Flat;
            BtnSolicitarAcesso.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            BtnSolicitarAcesso.ForeColor = Color.Transparent;
            BtnSolicitarAcesso.Image = Properties.Resources.Quest_48px;
            BtnSolicitarAcesso.ImeMode = ImeMode.NoControl;
            BtnSolicitarAcesso.Location = new Point(446, 396);
            BtnSolicitarAcesso.Name = "BtnSolicitarAcesso";
            BtnSolicitarAcesso.Size = new Size(48, 43);
            BtnSolicitarAcesso.TabIndex = 1;
            BtnSolicitarAcesso.UseVisualStyleBackColor = false;
            BtnSolicitarAcesso.Click += BtnSolicitarAcesso_Click;
            // 
            // BtnCancelarLogin
            // 
            BtnCancelarLogin.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnCancelarLogin.BackColor = Color.DarkGray;
            BtnCancelarLogin.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            BtnCancelarLogin.ForeColor = SystemColors.ButtonHighlight;
            BtnCancelarLogin.ImeMode = ImeMode.NoControl;
            BtnCancelarLogin.Location = new Point(340, 396);
            BtnCancelarLogin.Name = "BtnCancelarLogin";
            BtnCancelarLogin.Size = new Size(100, 43);
            BtnCancelarLogin.TabIndex = 2;
            BtnCancelarLogin.Text = "CANCELAR";
            BtnCancelarLogin.UseVisualStyleBackColor = false;
            BtnCancelarLogin.Click += BtnCancelarLogin_Click;
            // 
            // BtnEntrarLogin
            // 
            BtnEntrarLogin.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnEntrarLogin.BackColor = Color.DarkSlateGray;
            BtnEntrarLogin.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            BtnEntrarLogin.ForeColor = SystemColors.ButtonHighlight;
            BtnEntrarLogin.ImeMode = ImeMode.NoControl;
            BtnEntrarLogin.Location = new Point(197, 397);
            BtnEntrarLogin.Name = "BtnEntrarLogin";
            BtnEntrarLogin.Size = new Size(137, 43);
            BtnEntrarLogin.TabIndex = 2;
            BtnEntrarLogin.Text = "ENTRAR";
            BtnEntrarLogin.UseVisualStyleBackColor = false;
            BtnEntrarLogin.Click += BtnEntrarLogin_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(48, 48, 48);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 459);
            panel2.Name = "panel2";
            panel2.Size = new Size(541, 10);
            panel2.TabIndex = 91;
            // 
            // LoginControl
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.ActiveCaptionText;
            Controls.Add(PanelTop);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Name = "LoginControl";
            Size = new Size(541, 469);
            PanelTop.ResumeLayout(false);
            PanelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelTop;
        private PictureBox pictureBox4;
        private Label label7;
        private Panel panel3;
        private Button BtnEntrarLogin;
        private Panel panel2;
        private GroupBox groupBox3;
        private PictureBox pictureBox1;
        private GroupBox groupBox1;
        private TextBox TxbSenha;
        private TextBox TxbEmail;
        private Button BtnSolicitarAcesso;
        private Button BtnCancelarLogin;
        private Label lblStatus;
    }
}
