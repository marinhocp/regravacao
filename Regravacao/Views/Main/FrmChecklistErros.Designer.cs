namespace Regravacao.Views
{
    partial class FrmChecklistErros
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChecklistErros));
            PanelTop = new Panel();
            pictureBox4 = new PictureBox();
            label7 = new Label();
            BtnRestaurarJanela = new PictureBox();
            panel3 = new Panel();
            BtnCancelarErro = new Button();
            BtnOkErro = new Button();
            groupBox1 = new GroupBox();
            BtnLimparCampoBuscarErro = new Button();
            TxbBuscarErro = new TextBox();
            groupBox3 = new GroupBox();
            CxbListErros = new CheckedListBox();
            panel2 = new Panel();
            BtnLimparCheckbox = new Button();
            PanelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BtnRestaurarJanela).BeginInit();
            panel3.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // PanelTop
            // 
            PanelTop.BackColor = Color.FromArgb(255, 64, 46);
            PanelTop.Controls.Add(pictureBox4);
            PanelTop.Controls.Add(label7);
            PanelTop.Controls.Add(BtnRestaurarJanela);
            resources.ApplyResources(PanelTop, "PanelTop");
            PanelTop.Name = "PanelTop";
            PanelTop.MouseDown += PanelTop_MouseDown;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.Tomato;
            pictureBox4.Image = Properties.Resources.search24px;
            resources.ApplyResources(pictureBox4, "pictureBox4");
            pictureBox4.Name = "pictureBox4";
            pictureBox4.TabStop = false;
            // 
            // label7
            // 
            resources.ApplyResources(label7, "label7");
            label7.ForeColor = SystemColors.ControlLightLight;
            label7.Name = "label7";
            // 
            // BtnRestaurarJanela
            // 
            resources.ApplyResources(BtnRestaurarJanela, "BtnRestaurarJanela");
            BtnRestaurarJanela.Name = "BtnRestaurarJanela";
            BtnRestaurarJanela.TabStop = false;
            // 
            // panel3
            // 
            panel3.BackColor = Color.LightGray;
            panel3.Controls.Add(BtnLimparCheckbox);
            panel3.Controls.Add(BtnCancelarErro);
            panel3.Controls.Add(BtnOkErro);
            panel3.Controls.Add(groupBox1);
            panel3.Controls.Add(groupBox3);
            resources.ApplyResources(panel3, "panel3");
            panel3.Name = "panel3";
            // 
            // BtnCancelarErro
            // 
            resources.ApplyResources(BtnCancelarErro, "BtnCancelarErro");
            BtnCancelarErro.Name = "BtnCancelarErro";
            BtnCancelarErro.UseVisualStyleBackColor = true;
            BtnCancelarErro.Click += button4_Click;
            // 
            // BtnOkErro
            // 
            resources.ApplyResources(BtnOkErro, "BtnOkErro");
            BtnOkErro.BackColor = Color.DarkSlateGray;
            BtnOkErro.ForeColor = SystemColors.ButtonHighlight;
            BtnOkErro.Name = "BtnOkErro";
            BtnOkErro.UseVisualStyleBackColor = false;
            BtnOkErro.Click += BtnOkErro_Click;
            // 
            // groupBox1
            // 
            resources.ApplyResources(groupBox1, "groupBox1");
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(BtnLimparCampoBuscarErro);
            groupBox1.Controls.Add(TxbBuscarErro);
            groupBox1.Name = "groupBox1";
            groupBox1.TabStop = false;
            // 
            // BtnLimparCampoBuscarErro
            // 
            resources.ApplyResources(BtnLimparCampoBuscarErro, "BtnLimparCampoBuscarErro");
            BtnLimparCampoBuscarErro.BackColor = Color.DimGray;
            BtnLimparCampoBuscarErro.Image = Properties.Resources.clear_symbol_24px;
            BtnLimparCampoBuscarErro.Name = "BtnLimparCampoBuscarErro";
            BtnLimparCampoBuscarErro.UseVisualStyleBackColor = false;
            BtnLimparCampoBuscarErro.Click += BtnLimparCampoBuscar_Click;
            // 
            // TxbBuscarErro
            // 
            resources.ApplyResources(TxbBuscarErro, "TxbBuscarErro");
            TxbBuscarErro.CharacterCasing = CharacterCasing.Upper;
            TxbBuscarErro.HideSelection = false;
            TxbBuscarErro.Name = "TxbBuscarErro";
            // 
            // groupBox3
            // 
            resources.ApplyResources(groupBox3, "groupBox3");
            groupBox3.BackColor = Color.Transparent;
            groupBox3.Controls.Add(CxbListErros);
            groupBox3.Name = "groupBox3";
            groupBox3.TabStop = false;
            // 
            // CxbListErros
            // 
            resources.ApplyResources(CxbListErros, "CxbListErros");
            CxbListErros.BackColor = Color.LightGray;
            CxbListErros.BorderStyle = BorderStyle.None;
            CxbListErros.CheckOnClick = true;
            CxbListErros.FormattingEnabled = true;
            CxbListErros.MultiColumn = true;
            CxbListErros.Name = "CxbListErros";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(48, 48, 48);
            resources.ApplyResources(panel2, "panel2");
            panel2.Name = "panel2";
            // 
            // BtnLimparCheckbox
            // 
            resources.ApplyResources(BtnLimparCheckbox, "BtnLimparCheckbox");
            BtnLimparCheckbox.BackColor = Color.Gainsboro;
            BtnLimparCheckbox.FlatAppearance.BorderSize = 0;
            BtnLimparCheckbox.Image = Properties.Resources.borracha1_32x32;
            BtnLimparCheckbox.Name = "BtnLimparCheckbox";
            BtnLimparCheckbox.UseVisualStyleBackColor = false;
            BtnLimparCheckbox.Click += BtnLimparCheckbox_Click;
            // 
            // FrmChecklistErros
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            ControlBox = false;
            Controls.Add(PanelTop);
            Controls.Add(panel3);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            KeyPreview = true;
            MinimizeBox = false;
            Name = "FrmChecklistErros";
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Show;
            TopMost = true;
            Load += FrmChecklistErros_Load;
            PanelTop.ResumeLayout(false);
            PanelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)BtnRestaurarJanela).EndInit();
            panel3.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelTop;
        private Label label7;
        private PictureBox BtnRestaurarJanela;
        private Panel panel3;
        private GroupBox groupBox3;
        private Panel panel2;
        private GroupBox groupBox1;
        private PictureBox pictureBox4;
        private TextBox TxbBuscarErro;
        private Button BtnOkErro;
        private Button BtnCancelarErro;
        private Button BtnLimparCampoBuscarErro;
        private CheckedListBox CxbListErros;
        private Button BtnLimparCheckbox;
    }
}