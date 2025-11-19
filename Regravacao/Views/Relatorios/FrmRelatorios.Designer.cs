namespace Regravacao.Views
{
    partial class FrmRelatorios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRelatorios));
            PanelTop = new Panel();
            pictureBox4 = new PictureBox();
            label7 = new Label();
            panel3 = new Panel();
            BtnExportarRelatorioExcel = new Button();
            BtnExportarRelatorioPDF = new Button();
            BtnCancelarRelatorio = new Button();
            BtnImprimirRelatorio = new Button();
            groupBox1 = new GroupBox();
            DTPDataFinalRelatorio = new DateTimePicker();
            label12 = new Label();
            CbxMaterialRelatorio = new ComboBox();
            DTPDataInicialRelatorio = new DateTimePicker();
            CbxPorDataRelatorio = new ComboBox();
            CbxMotivoPrincipalRelatorio = new ComboBox();
            CbxConferenteRelatorio = new ComboBox();
            CbxFinalizadorRelatorio = new ComboBox();
            CbxSolicitanteRelatorio = new ComboBox();
            label10 = new Label();
            label3 = new Label();
            label9 = new Label();
            label11 = new Label();
            label2 = new Label();
            label8 = new Label();
            label1 = new Label();
            label6 = new Label();
            label26 = new Label();
            groupBox4 = new GroupBox();
            label5 = new Label();
            label4 = new Label();
            RbMaisCaro = new RadioButton();
            RbMaisAntigo = new RadioButton();
            RbMaisBarato = new RadioButton();
            RbMaisRecente = new RadioButton();
            GroupBuscarReqRelatorio = new GroupBox();
            BtnLimparCampoBuscar = new Button();
            BtnAcionarCampoBuscar = new Button();
            TxbBuscarRelatorio = new TextBox();
            groupBox2 = new GroupBox();
            PbcPrintRelatorio = new PictureBox();
            groupBox3 = new GroupBox();
            DGVInfoGeraisGravacoes = new DataGridView();
            PanelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            panel3.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox4.SuspendLayout();
            GroupBuscarReqRelatorio.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PbcPrintRelatorio).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGVInfoGeraisGravacoes).BeginInit();
            SuspendLayout();
            // 
            // PanelTop
            // 
            PanelTop.BackColor = Color.FromArgb(44, 44, 44);
            PanelTop.Controls.Add(pictureBox4);
            PanelTop.Controls.Add(label7);
            PanelTop.Dock = DockStyle.Top;
            PanelTop.Location = new Point(0, 0);
            PanelTop.Name = "PanelTop";
            PanelTop.Size = new Size(1451, 70);
            PanelTop.TabIndex = 89;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.FromArgb(44, 44, 44);
            pictureBox4.Image = Properties.Resources.edit_property_40px;
            pictureBox4.ImeMode = ImeMode.NoControl;
            pictureBox4.Location = new Point(14, 16);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(42, 36);
            pictureBox4.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox4.TabIndex = 15;
            pictureBox4.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label7.ForeColor = SystemColors.ControlLightLight;
            label7.ImeMode = ImeMode.NoControl;
            label7.Location = new Point(61, 16);
            label7.Name = "label7";
            label7.Size = new Size(379, 32);
            label7.TabIndex = 13;
            label7.Text = "Relatório de Clichês Regravados";
            // 
            // panel3
            // 
            panel3.BackColor = Color.LightGray;
            panel3.Controls.Add(BtnExportarRelatorioExcel);
            panel3.Controls.Add(BtnExportarRelatorioPDF);
            panel3.Controls.Add(BtnCancelarRelatorio);
            panel3.Controls.Add(BtnImprimirRelatorio);
            panel3.Controls.Add(groupBox1);
            panel3.Controls.Add(groupBox4);
            panel3.Controls.Add(GroupBuscarReqRelatorio);
            panel3.Controls.Add(groupBox2);
            panel3.Controls.Add(groupBox3);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1451, 1061);
            panel3.TabIndex = 88;
            // 
            // BtnExportarRelatorioExcel
            // 
            BtnExportarRelatorioExcel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BtnExportarRelatorioExcel.BackColor = Color.SeaGreen;
            BtnExportarRelatorioExcel.ForeColor = SystemColors.ButtonHighlight;
            BtnExportarRelatorioExcel.Image = Properties.Resources.microsoft_excel_24px;
            BtnExportarRelatorioExcel.ImeMode = ImeMode.NoControl;
            BtnExportarRelatorioExcel.Location = new Point(364, 1008);
            BtnExportarRelatorioExcel.Name = "BtnExportarRelatorioExcel";
            BtnExportarRelatorioExcel.Size = new Size(44, 41);
            BtnExportarRelatorioExcel.TabIndex = 3;
            BtnExportarRelatorioExcel.UseVisualStyleBackColor = false;
            // 
            // BtnExportarRelatorioPDF
            // 
            BtnExportarRelatorioPDF.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BtnExportarRelatorioPDF.BackColor = Color.Firebrick;
            BtnExportarRelatorioPDF.ForeColor = SystemColors.ButtonHighlight;
            BtnExportarRelatorioPDF.Image = Properties.Resources.pdf_30pxe;
            BtnExportarRelatorioPDF.ImeMode = ImeMode.NoControl;
            BtnExportarRelatorioPDF.Location = new Point(314, 1008);
            BtnExportarRelatorioPDF.Name = "BtnExportarRelatorioPDF";
            BtnExportarRelatorioPDF.Size = new Size(44, 41);
            BtnExportarRelatorioPDF.TabIndex = 3;
            BtnExportarRelatorioPDF.UseVisualStyleBackColor = false;
            // 
            // BtnCancelarRelatorio
            // 
            BtnCancelarRelatorio.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnCancelarRelatorio.BackColor = Color.Silver;
            BtnCancelarRelatorio.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            BtnCancelarRelatorio.ForeColor = SystemColors.ActiveCaptionText;
            BtnCancelarRelatorio.ImeMode = ImeMode.NoControl;
            BtnCancelarRelatorio.Location = new Point(1354, 1008);
            BtnCancelarRelatorio.Name = "BtnCancelarRelatorio";
            BtnCancelarRelatorio.Size = new Size(82, 41);
            BtnCancelarRelatorio.TabIndex = 5;
            BtnCancelarRelatorio.Text = "CANCELAR";
            BtnCancelarRelatorio.UseVisualStyleBackColor = false;
            BtnCancelarRelatorio.Click += BtnCancelarRelatorio_Click;
            // 
            // BtnImprimirRelatorio
            // 
            BtnImprimirRelatorio.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnImprimirRelatorio.BackColor = Color.DarkSlateGray;
            BtnImprimirRelatorio.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            BtnImprimirRelatorio.ForeColor = SystemColors.ButtonHighlight;
            BtnImprimirRelatorio.ImeMode = ImeMode.NoControl;
            BtnImprimirRelatorio.Location = new Point(1168, 1008);
            BtnImprimirRelatorio.Name = "BtnImprimirRelatorio";
            BtnImprimirRelatorio.Size = new Size(180, 41);
            BtnImprimirRelatorio.TabIndex = 4;
            BtnImprimirRelatorio.Text = "IMPRIMIR";
            BtnImprimirRelatorio.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(DTPDataFinalRelatorio);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(CbxMaterialRelatorio);
            groupBox1.Controls.Add(DTPDataInicialRelatorio);
            groupBox1.Controls.Add(CbxPorDataRelatorio);
            groupBox1.Controls.Add(CbxMotivoPrincipalRelatorio);
            groupBox1.Controls.Add(CbxConferenteRelatorio);
            groupBox1.Controls.Add(CbxFinalizadorRelatorio);
            groupBox1.Controls.Add(CbxSolicitanteRelatorio);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label26);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox1.Location = new Point(12, 189);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(295, 457);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "FILTRAR RESULTADO";
            // 
            // DTPDataFinalRelatorio
            // 
            DTPDataFinalRelatorio.AllowDrop = true;
            DTPDataFinalRelatorio.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            DTPDataFinalRelatorio.CalendarTitleBackColor = SystemColors.ControlText;
            DTPDataFinalRelatorio.CalendarTitleForeColor = SystemColors.AppWorkspace;
            DTPDataFinalRelatorio.Font = new Font("Segoe UI", 11F);
            DTPDataFinalRelatorio.Format = DateTimePickerFormat.Short;
            DTPDataFinalRelatorio.Location = new Point(163, 416);
            DTPDataFinalRelatorio.Name = "DTPDataFinalRelatorio";
            DTPDataFinalRelatorio.Size = new Size(117, 27);
            DTPDataFinalRelatorio.TabIndex = 3;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label12.ForeColor = Color.FromArgb(64, 64, 64);
            label12.Location = new Point(22, 203);
            label12.Name = "label12";
            label12.Size = new Size(50, 13);
            label12.TabIndex = 1;
            label12.Text = "Material";
            // 
            // CbxMaterialRelatorio
            // 
            CbxMaterialRelatorio.Font = new Font("Segoe UI", 12F);
            CbxMaterialRelatorio.FormattingEnabled = true;
            CbxMaterialRelatorio.Location = new Point(14, 220);
            CbxMaterialRelatorio.Name = "CbxMaterialRelatorio";
            CbxMaterialRelatorio.Size = new Size(267, 29);
            CbxMaterialRelatorio.TabIndex = 1;
            // 
            // DTPDataInicialRelatorio
            // 
            DTPDataInicialRelatorio.AllowDrop = true;
            DTPDataInicialRelatorio.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            DTPDataInicialRelatorio.CalendarTitleBackColor = SystemColors.ControlText;
            DTPDataInicialRelatorio.CalendarTitleForeColor = SystemColors.AppWorkspace;
            DTPDataInicialRelatorio.Font = new Font("Segoe UI", 11F);
            DTPDataInicialRelatorio.Format = DateTimePickerFormat.Short;
            DTPDataInicialRelatorio.Location = new Point(15, 416);
            DTPDataInicialRelatorio.Name = "DTPDataInicialRelatorio";
            DTPDataInicialRelatorio.Size = new Size(117, 27);
            DTPDataInicialRelatorio.TabIndex = 3;
            // 
            // CbxPorDataRelatorio
            // 
            CbxPorDataRelatorio.Font = new Font("Segoe UI", 12F);
            CbxPorDataRelatorio.FormattingEnabled = true;
            CbxPorDataRelatorio.Location = new Point(14, 356);
            CbxPorDataRelatorio.Name = "CbxPorDataRelatorio";
            CbxPorDataRelatorio.Size = new Size(267, 29);
            CbxPorDataRelatorio.TabIndex = 2;
            // 
            // CbxMotivoPrincipalRelatorio
            // 
            CbxMotivoPrincipalRelatorio.Font = new Font("Segoe UI", 12F);
            CbxMotivoPrincipalRelatorio.FormattingEnabled = true;
            CbxMotivoPrincipalRelatorio.Location = new Point(14, 280);
            CbxMotivoPrincipalRelatorio.Name = "CbxMotivoPrincipalRelatorio";
            CbxMotivoPrincipalRelatorio.Size = new Size(267, 29);
            CbxMotivoPrincipalRelatorio.TabIndex = 1;
            // 
            // CbxConferenteRelatorio
            // 
            CbxConferenteRelatorio.Font = new Font("Segoe UI", 12F);
            CbxConferenteRelatorio.FormattingEnabled = true;
            CbxConferenteRelatorio.Location = new Point(11, 160);
            CbxConferenteRelatorio.Name = "CbxConferenteRelatorio";
            CbxConferenteRelatorio.Size = new Size(267, 29);
            CbxConferenteRelatorio.TabIndex = 1;
            // 
            // CbxFinalizadorRelatorio
            // 
            CbxFinalizadorRelatorio.Font = new Font("Segoe UI", 12F);
            CbxFinalizadorRelatorio.FormattingEnabled = true;
            CbxFinalizadorRelatorio.Location = new Point(14, 100);
            CbxFinalizadorRelatorio.Name = "CbxFinalizadorRelatorio";
            CbxFinalizadorRelatorio.Size = new Size(267, 29);
            CbxFinalizadorRelatorio.TabIndex = 1;
            // 
            // CbxSolicitanteRelatorio
            // 
            CbxSolicitanteRelatorio.Font = new Font("Segoe UI", 12F);
            CbxSolicitanteRelatorio.FormattingEnabled = true;
            CbxSolicitanteRelatorio.Location = new Point(14, 40);
            CbxSolicitanteRelatorio.Name = "CbxSolicitanteRelatorio";
            CbxSolicitanteRelatorio.Size = new Size(267, 29);
            CbxSolicitanteRelatorio.TabIndex = 0;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label10.ForeColor = Color.FromArgb(64, 64, 64);
            label10.Location = new Point(166, 396);
            label10.Name = "label10";
            label10.Size = new Size(59, 13);
            label10.TabIndex = 113;
            label10.Text = "Data Final";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(64, 64, 64);
            label3.Location = new Point(19, 396);
            label3.Name = "label3";
            label3.Size = new Size(64, 13);
            label3.TabIndex = 113;
            label3.Text = "Data Inicial";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label9.ForeColor = Color.FromArgb(64, 64, 64);
            label9.Location = new Point(22, 263);
            label9.Name = "label9";
            label9.Size = new Size(93, 13);
            label9.TabIndex = 1;
            label9.Text = "Motivo Principal";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label11.ForeColor = Color.Silver;
            label11.Location = new Point(15, 317);
            label11.Name = "label11";
            label11.Size = new Size(267, 13);
            label11.TabIndex = 3;
            label11.Text = "____________________________________________________";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(64, 64, 64);
            label2.Location = new Point(22, 339);
            label2.Name = "label2";
            label2.Size = new Size(52, 13);
            label2.TabIndex = 3;
            label2.Text = "Por Data";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label8.ForeColor = Color.FromArgb(64, 64, 64);
            label8.Location = new Point(22, 143);
            label8.Name = "label8";
            label8.Size = new Size(65, 13);
            label8.TabIndex = 1;
            label8.Text = "Conferente";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(64, 64, 64);
            label1.Location = new Point(22, 83);
            label1.Name = "label1";
            label1.Size = new Size(64, 13);
            label1.TabIndex = 1;
            label1.Text = "Finalizador";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(64, 64, 64);
            label6.Location = new Point(144, 430);
            label6.Name = "label6";
            label6.Size = new Size(13, 13);
            label6.TabIndex = 113;
            label6.Text = "a";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label26.ForeColor = Color.FromArgb(64, 64, 64);
            label26.Location = new Point(22, 23);
            label26.Name = "label26";
            label26.Size = new Size(61, 13);
            label26.TabIndex = 113;
            label26.Text = "Solicitante";
            // 
            // groupBox4
            // 
            groupBox4.BackColor = Color.Transparent;
            groupBox4.Controls.Add(label5);
            groupBox4.Controls.Add(label4);
            groupBox4.Controls.Add(RbMaisCaro);
            groupBox4.Controls.Add(RbMaisAntigo);
            groupBox4.Controls.Add(RbMaisBarato);
            groupBox4.Controls.Add(RbMaisRecente);
            groupBox4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox4.Location = new Point(17, 669);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(276, 83);
            groupBox4.TabIndex = 2;
            groupBox4.TabStop = false;
            groupBox4.Text = "ORGANIZAR POR:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(133, 48);
            label5.Name = "label5";
            label5.Size = new Size(11, 15);
            label5.TabIndex = 3;
            label5.Text = "|";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(133, 24);
            label4.Name = "label4";
            label4.Size = new Size(11, 15);
            label4.TabIndex = 2;
            label4.Text = "|";
            // 
            // RbMaisCaro
            // 
            RbMaisCaro.AutoSize = true;
            RbMaisCaro.Location = new Point(171, 48);
            RbMaisCaro.Name = "RbMaisCaro";
            RbMaisCaro.Size = new Size(78, 19);
            RbMaisCaro.TabIndex = 9;
            RbMaisCaro.Text = "Mais Caro";
            RbMaisCaro.UseVisualStyleBackColor = true;
            // 
            // RbMaisAntigo
            // 
            RbMaisAntigo.AutoSize = true;
            RbMaisAntigo.Location = new Point(9, 50);
            RbMaisAntigo.Name = "RbMaisAntigo";
            RbMaisAntigo.Size = new Size(90, 19);
            RbMaisAntigo.TabIndex = 1;
            RbMaisAntigo.Text = "Mais Antigo";
            RbMaisAntigo.UseVisualStyleBackColor = true;
            // 
            // RbMaisBarato
            // 
            RbMaisBarato.AutoSize = true;
            RbMaisBarato.Location = new Point(171, 23);
            RbMaisBarato.Name = "RbMaisBarato";
            RbMaisBarato.Size = new Size(90, 19);
            RbMaisBarato.TabIndex = 8;
            RbMaisBarato.Text = "Mais Barato";
            RbMaisBarato.UseVisualStyleBackColor = true;
            // 
            // RbMaisRecente
            // 
            RbMaisRecente.AutoSize = true;
            RbMaisRecente.Checked = true;
            RbMaisRecente.Location = new Point(9, 25);
            RbMaisRecente.Name = "RbMaisRecente";
            RbMaisRecente.Size = new Size(100, 19);
            RbMaisRecente.TabIndex = 0;
            RbMaisRecente.TabStop = true;
            RbMaisRecente.Text = "Mais Recente";
            RbMaisRecente.UseVisualStyleBackColor = true;
            // 
            // GroupBuscarReqRelatorio
            // 
            GroupBuscarReqRelatorio.BackColor = Color.Transparent;
            GroupBuscarReqRelatorio.Controls.Add(BtnLimparCampoBuscar);
            GroupBuscarReqRelatorio.Controls.Add(BtnAcionarCampoBuscar);
            GroupBuscarReqRelatorio.Controls.Add(TxbBuscarRelatorio);
            GroupBuscarReqRelatorio.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            GroupBuscarReqRelatorio.Location = new Point(14, 89);
            GroupBuscarReqRelatorio.Name = "GroupBuscarReqRelatorio";
            GroupBuscarReqRelatorio.Size = new Size(293, 83);
            GroupBuscarReqRelatorio.TabIndex = 0;
            GroupBuscarReqRelatorio.TabStop = false;
            GroupBuscarReqRelatorio.Text = "BUSCAR REQUERIMENTO";
            // 
            // BtnLimparCampoBuscar
            // 
            BtnLimparCampoBuscar.BackColor = Color.SlateGray;
            BtnLimparCampoBuscar.BackgroundImage = Properties.Resources.clear_symbol_24px;
            BtnLimparCampoBuscar.BackgroundImageLayout = ImageLayout.Center;
            BtnLimparCampoBuscar.ImeMode = ImeMode.NoControl;
            BtnLimparCampoBuscar.Location = new Point(248, 35);
            BtnLimparCampoBuscar.Name = "BtnLimparCampoBuscar";
            BtnLimparCampoBuscar.Size = new Size(31, 31);
            BtnLimparCampoBuscar.TabIndex = 2;
            BtnLimparCampoBuscar.UseVisualStyleBackColor = false;
            BtnLimparCampoBuscar.Visible = false;
            BtnLimparCampoBuscar.Click += BtnLimparCampoBuscar_Click;
            // 
            // BtnAcionarCampoBuscar
            // 
            BtnAcionarCampoBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnAcionarCampoBuscar.BackColor = Color.DarkCyan;
            BtnAcionarCampoBuscar.BackgroundImage = Properties.Resources.search24px;
            BtnAcionarCampoBuscar.BackgroundImageLayout = ImageLayout.Center;
            BtnAcionarCampoBuscar.ImeMode = ImeMode.NoControl;
            BtnAcionarCampoBuscar.Location = new Point(248, 36);
            BtnAcionarCampoBuscar.Name = "BtnAcionarCampoBuscar";
            BtnAcionarCampoBuscar.Size = new Size(31, 31);
            BtnAcionarCampoBuscar.TabIndex = 1;
            BtnAcionarCampoBuscar.UseVisualStyleBackColor = false;
            // 
            // TxbBuscarRelatorio
            // 
            TxbBuscarRelatorio.CharacterCasing = CharacterCasing.Upper;
            TxbBuscarRelatorio.Font = new Font("Segoe UI", 12F);
            TxbBuscarRelatorio.HideSelection = false;
            TxbBuscarRelatorio.Location = new Point(11, 37);
            TxbBuscarRelatorio.Name = "TxbBuscarRelatorio";
            TxbBuscarRelatorio.Size = new Size(231, 29);
            TxbBuscarRelatorio.TabIndex = 0;
            TxbBuscarRelatorio.TextChanged += TxbBuscarRelatorio_TextChanged;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.Transparent;
            groupBox2.Controls.Add(PbcPrintRelatorio);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox2.Location = new Point(14, 784);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(293, 218);
            groupBox2.TabIndex = 105;
            groupBox2.TabStop = false;
            groupBox2.Text = "PRINT DA ARTE";
            // 
            // PbcPrintRelatorio
            // 
            PbcPrintRelatorio.BackColor = Color.Silver;
            PbcPrintRelatorio.Dock = DockStyle.Fill;
            PbcPrintRelatorio.Image = Properties.Resources.no_imagem;
            PbcPrintRelatorio.InitialImage = Properties.Resources.no_imagem;
            PbcPrintRelatorio.Location = new Point(3, 19);
            PbcPrintRelatorio.Name = "PbcPrintRelatorio";
            PbcPrintRelatorio.Size = new Size(287, 196);
            PbcPrintRelatorio.SizeMode = PictureBoxSizeMode.StretchImage;
            PbcPrintRelatorio.TabIndex = 0;
            PbcPrintRelatorio.TabStop = false;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.BackColor = Color.Transparent;
            groupBox3.Controls.Add(DGVInfoGeraisGravacoes);
            groupBox3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox3.Location = new Point(313, 86);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1126, 916);
            groupBox3.TabIndex = 105;
            groupBox3.TabStop = false;
            groupBox3.Text = "INFORMAÇÕES GERAIS DAS REGRAVAÇÕES";
            // 
            // DGVInfoGeraisGravacoes
            // 
            DGVInfoGeraisGravacoes.AllowUserToAddRows = false;
            DGVInfoGeraisGravacoes.AllowUserToDeleteRows = false;
            DGVInfoGeraisGravacoes.AllowUserToOrderColumns = true;
            DGVInfoGeraisGravacoes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DGVInfoGeraisGravacoes.BackgroundColor = SystemColors.ButtonFace;
            DGVInfoGeraisGravacoes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVInfoGeraisGravacoes.Dock = DockStyle.Fill;
            DGVInfoGeraisGravacoes.Location = new Point(3, 19);
            DGVInfoGeraisGravacoes.MultiSelect = false;
            DGVInfoGeraisGravacoes.Name = "DGVInfoGeraisGravacoes";
            DGVInfoGeraisGravacoes.ReadOnly = true;
            DGVInfoGeraisGravacoes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGVInfoGeraisGravacoes.Size = new Size(1120, 894);
            DGVInfoGeraisGravacoes.TabIndex = 0;
            // 
            // FrmRelatorios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1451, 1061);
            Controls.Add(PanelTop);
            Controls.Add(panel3);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Name = "FrmRelatorios";
            SizeGripStyle = SizeGripStyle.Show;
            WindowState = FormWindowState.Maximized;
            PanelTop.ResumeLayout(false);
            PanelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            panel3.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            GroupBuscarReqRelatorio.ResumeLayout(false);
            GroupBuscarReqRelatorio.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PbcPrintRelatorio).EndInit();
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DGVInfoGeraisGravacoes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelTop;
        private PictureBox pictureBox4;
        private Label label7;
        private Panel panel3;
        private Button BtnImprimirRelatorio;
        private GroupBox GroupBuscarReqRelatorio;
        private Button BtnAcionarCampoBuscar;
        private TextBox TxbBuscarRelatorio;
        private GroupBox groupBox3;
        private GroupBox groupBox1;
        private DateTimePicker DTPDataInicialRelatorio;
        private ComboBox CbxSolicitanteRelatorio;
        private GroupBox groupBox2;
        private Button BtnExportarRelatorioPDF;
        private ComboBox CbxPorDataRelatorio;
        private ComboBox CbxFinalizadorRelatorio;
        private Label label2;
        private Label label1;
        private Label label26;
        private Label label3;
        private DataGridView DGVInfoGeraisGravacoes;
        private Button BtnCancelarRelatorio;
        private GroupBox groupBox4;
        private RadioButton RbMaisAntigo;
        private RadioButton RbMaisRecente;
        private RadioButton RbMaisCaro;
        private RadioButton RbMaisBarato;
        private Label label5;
        private Label label4;
        private PictureBox PbcPrintRelatorio;
        private DateTimePicker DTPDataFinalRelatorio;
        private Label label6;
        private Button BtnExportarRelatorioExcel;
        private ComboBox CbxConferenteRelatorio;
        private Label label8;
        private ComboBox CbxMotivoPrincipalRelatorio;
        private Label label9;
        private Button BtnLimparCampoBuscar;
        private Label label10;
        private Label label11;
        private Label label12;
        private ComboBox CbxMaterialRelatorio;
    }
}