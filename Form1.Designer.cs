using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TallerMasResorte
{
    partial class SpringMassForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Title title5 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Title title6 = new System.Windows.Forms.DataVisualization.Charting.Title();

            this.gbFixed = new System.Windows.Forms.GroupBox();
            this.lblM1 = new System.Windows.Forms.Label();
            this.txtM1 = new System.Windows.Forms.TextBox();
            this.lblM2 = new System.Windows.Forms.Label();
            this.txtM2 = new System.Windows.Forms.TextBox();
            this.lblM3 = new System.Windows.Forms.Label();
            this.txtM3 = new System.Windows.Forms.TextBox();
            this.lblK1 = new System.Windows.Forms.Label();
            this.txtK1 = new System.Windows.Forms.TextBox();
            this.lblK2 = new System.Windows.Forms.Label();
            this.txtK2 = new System.Windows.Forms.TextBox();
            this.lblK3 = new System.Windows.Forms.Label();
            this.txtK3 = new System.Windows.Forms.TextBox();
            this.lblK4 = new System.Windows.Forms.Label();
            this.txtK4 = new System.Windows.Forms.TextBox();
            this.lblC1 = new System.Windows.Forms.Label();
            this.txtC1 = new System.Windows.Forms.TextBox();
            this.lblC2 = new System.Windows.Forms.Label();
            this.txtC2 = new System.Windows.Forms.TextBox();
            this.lblC3 = new System.Windows.Forms.Label();
            this.txtC3 = new System.Windows.Forms.TextBox();
            this.lblC4 = new System.Windows.Forms.Label();
            this.txtC4 = new System.Windows.Forms.TextBox();

            this.gbRanges = new System.Windows.Forms.GroupBox();
            this.lblHeaderVar = new System.Windows.Forms.Label();
            this.lblHeaderMin = new System.Windows.Forms.Label();
            this.lblHeaderMax = new System.Windows.Forms.Label();
            this.lblHeaderStep = new System.Windows.Forms.Label();
            this.cbVaryK = new System.Windows.Forms.ComboBox();
            this.txtKMin = new System.Windows.Forms.TextBox();
            this.txtKMax = new System.Windows.Forms.TextBox();
            this.txtKStep = new System.Windows.Forms.TextBox();
            this.cbVaryC = new System.Windows.Forms.ComboBox();
            this.txtCMin = new System.Windows.Forms.TextBox();
            this.txtCMax = new System.Windows.Forms.TextBox();
            this.txtCStep = new System.Windows.Forms.TextBox();
            this.cbVaryM = new System.Windows.Forms.ComboBox();
            this.txtMMin = new System.Windows.Forms.TextBox();
            this.txtMMax = new System.Windows.Forms.TextBox();
            this.txtMStep = new System.Windows.Forms.TextBox();

            this.gbSoftware = new System.Windows.Forms.GroupBox();
            this.lblOctave = new System.Windows.Forms.Label();
            this.txtOctavePath = new System.Windows.Forms.TextBox();
            this.lblElements = new System.Windows.Forms.Label();
            this.txtElements = new System.Windows.Forms.TextBox();
            this.lblScale = new System.Windows.Forms.Label();
            this.txtScaleFactor = new System.Windows.Forms.TextBox();

            this.btnSimulate = new System.Windows.Forms.Button();
            this.progressBarSim = new System.Windows.Forms.ProgressBar();
            this.lblSimStatus = new System.Windows.Forms.Label();

            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.trackBarTime = new System.Windows.Forms.TrackBar();
            this.btnPlayPause = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblTime = new System.Windows.Forms.Label();
            this.cbAnimType = new System.Windows.Forms.ComboBox();

            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.tabResults = new System.Windows.Forms.TabPage();
            this.lblResultsSummary = new System.Windows.Forms.Label();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.chartStep = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartImpulse = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabMath = new System.Windows.Forms.TabPage();
            this.rtbMath = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);

            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTime)).BeginInit();
            this.mainTabControl.SuspendLayout();
            this.tabResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartImpulse)).BeginInit();
            this.tabMath.SuspendLayout();
            this.SuspendLayout();

            // 
            // gbFixed
            // 
            this.gbFixed.Controls.Add(this.lblM1);
            this.gbFixed.Controls.Add(this.txtM1);
            this.gbFixed.Controls.Add(this.lblM2);
            this.gbFixed.Controls.Add(this.txtM2);
            this.gbFixed.Controls.Add(this.lblM3);
            this.gbFixed.Controls.Add(this.txtM3);
            this.gbFixed.Controls.Add(this.lblK1);
            this.gbFixed.Controls.Add(this.txtK1);
            this.gbFixed.Controls.Add(this.lblK2);
            this.gbFixed.Controls.Add(this.txtK2);
            this.gbFixed.Controls.Add(this.lblK3);
            this.gbFixed.Controls.Add(this.txtK3);
            this.gbFixed.Controls.Add(this.lblK4);
            this.gbFixed.Controls.Add(this.txtK4);
            this.gbFixed.Controls.Add(this.lblC1);
            this.gbFixed.Controls.Add(this.txtC1);
            this.gbFixed.Controls.Add(this.lblC2);
            this.gbFixed.Controls.Add(this.txtC2);
            this.gbFixed.Controls.Add(this.lblC3);
            this.gbFixed.Controls.Add(this.txtC3);
            this.gbFixed.Controls.Add(this.lblC4);
            this.gbFixed.Controls.Add(this.txtC4);
            this.gbFixed.Location = new System.Drawing.Point(12, 12);
            this.gbFixed.Name = "gbFixed";
            this.gbFixed.Size = new System.Drawing.Size(300, 240);
            this.gbFixed.TabIndex = 0;
            this.gbFixed.TabStop = false;
            this.gbFixed.Text = "Constantes Fijas";
            this.gbFixed.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);

            // lblM1
            this.lblM1.AutoSize = true;
            this.lblM1.Location = new System.Drawing.Point(10, 30);
            this.lblM1.Name = "lblM1";
            this.lblM1.Size = new System.Drawing.Size(28, 15);
            this.lblM1.Text = "m1:";
            // txtM1
            this.txtM1.Location = new System.Drawing.Point(45, 27);
            this.txtM1.Name = "txtM1";
            this.txtM1.Size = new System.Drawing.Size(45, 23);
            this.txtM1.Text = "10";
            this.txtM1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // lblM2
            this.lblM2.AutoSize = true;
            this.lblM2.Location = new System.Drawing.Point(105, 30);
            this.lblM2.Name = "lblM2";
            this.lblM2.Size = new System.Drawing.Size(30, 15);
            this.lblM2.Text = "m2:";
            // txtM2
            this.txtM2.Location = new System.Drawing.Point(140, 27);
            this.txtM2.Name = "txtM2";
            this.txtM2.Size = new System.Drawing.Size(45, 23);
            this.txtM2.Text = "15";
            this.txtM2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // lblM3
            this.lblM3.AutoSize = true;
            this.lblM3.Location = new System.Drawing.Point(200, 30);
            this.lblM3.Name = "lblM3";
            this.lblM3.Size = new System.Drawing.Size(30, 15);
            this.lblM3.Text = "m3:";
            // txtM3
            this.txtM3.Location = new System.Drawing.Point(235, 27);
            this.txtM3.Name = "txtM3";
            this.txtM3.Size = new System.Drawing.Size(45, 23);
            this.txtM3.Text = "10";
            this.txtM3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // lblK1
            this.lblK1.AutoSize = true;
            this.lblK1.Location = new System.Drawing.Point(10, 80);
            this.lblK1.Name = "lblK1";
            this.lblK1.Size = new System.Drawing.Size(23, 15);
            this.lblK1.Text = "k1:";
            // txtK1
            this.txtK1.Location = new System.Drawing.Point(45, 77);
            this.txtK1.Name = "txtK1";
            this.txtK1.Size = new System.Drawing.Size(45, 23);
            this.txtK1.Text = "100";
            this.txtK1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // lblK2
            this.lblK2.AutoSize = true;
            this.lblK2.Location = new System.Drawing.Point(105, 80);
            this.lblK2.Name = "lblK2";
            this.lblK2.Size = new System.Drawing.Size(25, 15);
            this.lblK2.Text = "k2:";
            // txtK2
            this.txtK2.Location = new System.Drawing.Point(140, 77);
            this.txtK2.Name = "txtK2";
            this.txtK2.Size = new System.Drawing.Size(45, 23);
            this.txtK2.Text = "120";
            this.txtK2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // lblK3
            this.lblK3.AutoSize = true;
            this.lblK3.Location = new System.Drawing.Point(200, 80);
            this.lblK3.Name = "lblK3";
            this.lblK3.Size = new System.Drawing.Size(25, 15);
            this.lblK3.Text = "k3:";
            // txtK3
            this.txtK3.Location = new System.Drawing.Point(235, 77);
            this.txtK3.Name = "txtK3";
            this.txtK3.Size = new System.Drawing.Size(45, 23);
            this.txtK3.Text = "100";
            this.txtK3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // lblK4
            this.lblK4.AutoSize = true;
            this.lblK4.Location = new System.Drawing.Point(10, 130);
            this.lblK4.Name = "lblK4";
            this.lblK4.Size = new System.Drawing.Size(25, 15);
            this.lblK4.Text = "k4:";
            // txtK4
            this.txtK4.Location = new System.Drawing.Point(45, 127);
            this.txtK4.Name = "txtK4";
            this.txtK4.Size = new System.Drawing.Size(45, 23);
            this.txtK4.Text = "80";
            this.txtK4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // lblC1
            this.lblC1.AutoSize = true;
            this.lblC1.Location = new System.Drawing.Point(105, 130);
            this.lblC1.Name = "lblC1";
            this.lblC1.Size = new System.Drawing.Size(23, 15);
            this.lblC1.Text = "c1:";
            // txtC1
            this.txtC1.Location = new System.Drawing.Point(140, 127);
            this.txtC1.Name = "txtC1";
            this.txtC1.Size = new System.Drawing.Size(45, 23);
            this.txtC1.Text = "2.0";
            this.txtC1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // lblC2
            this.lblC2.AutoSize = true;
            this.lblC2.Location = new System.Drawing.Point(200, 130);
            this.lblC2.Name = "lblC2";
            this.lblC2.Size = new System.Drawing.Size(25, 15);
            this.lblC2.Text = "c2:";
            // txtC2
            this.txtC2.Location = new System.Drawing.Point(235, 127);
            this.txtC2.Name = "txtC2";
            this.txtC2.Size = new System.Drawing.Size(45, 23);
            this.txtC2.Text = "3.0";
            this.txtC2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // lblC3
            this.lblC3.AutoSize = true;
            this.lblC3.Location = new System.Drawing.Point(10, 180);
            this.lblC3.Name = "lblC3";
            this.lblC3.Size = new System.Drawing.Size(25, 15);
            this.lblC3.Text = "c3:";
            // txtC3
            this.txtC3.Location = new System.Drawing.Point(45, 177);
            this.txtC3.Name = "txtC3";
            this.txtC3.Size = new System.Drawing.Size(45, 23);
            this.txtC3.Text = "2.0";
            this.txtC3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // lblC4
            this.lblC4.AutoSize = true;
            this.lblC4.Location = new System.Drawing.Point(105, 180);
            this.lblC4.Name = "lblC4";
            this.lblC4.Size = new System.Drawing.Size(25, 15);
            this.lblC4.Text = "c4:";
            // txtC4
            this.txtC4.Location = new System.Drawing.Point(140, 177);
            this.txtC4.Name = "txtC4";
            this.txtC4.Size = new System.Drawing.Size(45, 23);
            this.txtC4.Text = "1.5";
            this.txtC4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // 
            // gbRanges
            // 
            this.gbRanges.Controls.Add(this.lblHeaderVar);
            this.gbRanges.Controls.Add(this.lblHeaderMin);
            this.gbRanges.Controls.Add(this.lblHeaderMax);
            this.gbRanges.Controls.Add(this.lblHeaderStep);
            this.gbRanges.Controls.Add(this.cbVaryK);
            this.gbRanges.Controls.Add(this.txtKMin);
            this.gbRanges.Controls.Add(this.txtKMax);
            this.gbRanges.Controls.Add(this.txtKStep);
            this.gbRanges.Controls.Add(this.cbVaryC);
            this.gbRanges.Controls.Add(this.txtCMin);
            this.gbRanges.Controls.Add(this.txtCMax);
            this.gbRanges.Controls.Add(this.txtCStep);
            this.gbRanges.Controls.Add(this.cbVaryM);
            this.gbRanges.Controls.Add(this.txtMMin);
            this.gbRanges.Controls.Add(this.txtMMax);
            this.gbRanges.Controls.Add(this.txtMStep);
            this.gbRanges.Location = new System.Drawing.Point(12, 260);
            this.gbRanges.Name = "gbRanges";
            this.gbRanges.Size = new System.Drawing.Size(300, 220);
            this.gbRanges.TabIndex = 1;
            this.gbRanges.TabStop = false;
            this.gbRanges.Text = "Configuración de Rangos";
            this.gbRanges.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);

            // lblHeaderVar
            this.lblHeaderVar.AutoSize = true;
            this.lblHeaderVar.Location = new System.Drawing.Point(10, 25);
            this.lblHeaderVar.Name = "lblHeaderVar";
            this.lblHeaderVar.Size = new System.Drawing.Size(53, 15);
            this.lblHeaderVar.Text = "Variable";

            // lblHeaderMin
            this.lblHeaderMin.AutoSize = true;
            this.lblHeaderMin.Location = new System.Drawing.Point(95, 25);
            this.lblHeaderMin.Name = "lblHeaderMin";
            this.lblHeaderMin.Size = new System.Drawing.Size(28, 15);
            this.lblHeaderMin.Text = "Mín";

            // lblHeaderMax
            this.lblHeaderMax.AutoSize = true;
            this.lblHeaderMax.Location = new System.Drawing.Point(160, 25);
            this.lblHeaderMax.Name = "lblHeaderMax";
            this.lblHeaderMax.Size = new System.Drawing.Size(29, 15);
            this.lblHeaderMax.Text = "Máx";

            // lblHeaderStep
            this.lblHeaderStep.AutoSize = true;
            this.lblHeaderStep.Location = new System.Drawing.Point(225, 25);
            this.lblHeaderStep.Name = "lblHeaderStep";
            this.lblHeaderStep.Size = new System.Drawing.Size(32, 15);
            this.lblHeaderStep.Text = "Paso";

            // cbVaryK
            this.cbVaryK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVaryK.FormattingEnabled = true;
            this.cbVaryK.Items.AddRange(new object[] { "k1", "k2", "k3", "k4" });
            this.cbVaryK.Location = new System.Drawing.Point(10, 48);
            this.cbVaryK.Name = "cbVaryK";
            this.cbVaryK.Size = new System.Drawing.Size(75, 23);
            this.cbVaryK.TabIndex = 0;

            // txtKMin
            this.txtKMin.Location = new System.Drawing.Point(95, 48);
            this.txtKMin.Name = "txtKMin";
            this.txtKMin.Size = new System.Drawing.Size(50, 23);
            this.txtKMin.Text = "80";
            this.txtKMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // txtKMax
            this.txtKMax.Location = new System.Drawing.Point(160, 48);
            this.txtKMax.Name = "txtKMax";
            this.txtKMax.Size = new System.Drawing.Size(50, 23);
            this.txtKMax.Text = "120";
            this.txtKMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // txtKStep
            this.txtKStep.Location = new System.Drawing.Point(225, 48);
            this.txtKStep.Name = "txtKStep";
            this.txtKStep.Size = new System.Drawing.Size(50, 23);
            this.txtKStep.Text = "20";
            this.txtKStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // cbVaryC
            this.cbVaryC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVaryC.FormattingEnabled = true;
            this.cbVaryC.Items.AddRange(new object[] { "c1", "c2", "c3", "c4" });
            this.cbVaryC.Location = new System.Drawing.Point(10, 103);
            this.cbVaryC.Name = "cbVaryC";
            this.cbVaryC.Size = new System.Drawing.Size(75, 23);
            this.cbVaryC.TabIndex = 4;

            // txtCMin
            this.txtCMin.Location = new System.Drawing.Point(95, 103);
            this.txtCMin.Name = "txtCMin";
            this.txtCMin.Size = new System.Drawing.Size(50, 23);
            this.txtCMin.Text = "1.0";
            this.txtCMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // txtCMax
            this.txtCMax.Location = new System.Drawing.Point(160, 103);
            this.txtCMax.Name = "txtCMax";
            this.txtCMax.Size = new System.Drawing.Size(50, 23);
            this.txtCMax.Text = "5.0";
            this.txtCMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // txtCStep
            this.txtCStep.Location = new System.Drawing.Point(225, 103);
            this.txtCStep.Name = "txtCStep";
            this.txtCStep.Size = new System.Drawing.Size(50, 23);
            this.txtCStep.Text = "2.0";
            this.txtCStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // cbVaryM
            this.cbVaryM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVaryM.FormattingEnabled = true;
            this.cbVaryM.Items.AddRange(new object[] { "m1", "m2", "m3" });
            this.cbVaryM.Location = new System.Drawing.Point(10, 158);
            this.cbVaryM.Name = "cbVaryM";
            this.cbVaryM.Size = new System.Drawing.Size(75, 23);
            this.cbVaryM.TabIndex = 8;

            // txtMMin
            this.txtMMin.Location = new System.Drawing.Point(95, 158);
            this.txtMMin.Name = "txtMMin";
            this.txtMMin.Size = new System.Drawing.Size(50, 23);
            this.txtMMin.Text = "5.0";
            this.txtMMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // txtMMax
            this.txtMMax.Location = new System.Drawing.Point(160, 158);
            this.txtMMax.Name = "txtMMax";
            this.txtMMax.Size = new System.Drawing.Size(50, 23);
            this.txtMMax.Text = "15.0";
            this.txtMMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // txtMStep
            this.txtMStep.Location = new System.Drawing.Point(225, 158);
            this.txtMStep.Name = "txtMStep";
            this.txtMStep.Size = new System.Drawing.Size(50, 23);
            this.txtMStep.Text = "5.0";
            this.txtMStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // 
            // gbSoftware
            // 
            this.gbSoftware.Controls.Add(this.lblOctave);
            this.gbSoftware.Controls.Add(this.txtOctavePath);
            this.gbSoftware.Controls.Add(this.lblElements);
            this.gbSoftware.Controls.Add(this.txtElements);
            this.gbSoftware.Controls.Add(this.lblScale);
            this.gbSoftware.Controls.Add(this.txtScaleFactor);
            this.gbSoftware.Location = new System.Drawing.Point(12, 490);
            this.gbSoftware.Name = "gbSoftware";
            this.gbSoftware.Size = new System.Drawing.Size(300, 160);
            this.gbSoftware.TabIndex = 2;
            this.gbSoftware.TabStop = false;
            this.gbSoftware.Text = "Configuración del Entorno";
            this.gbSoftware.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);

            // lblOctave
            this.lblOctave.AutoSize = true;
            this.lblOctave.Location = new System.Drawing.Point(10, 22);
            this.lblOctave.Name = "lblOctave";
            this.lblOctave.Size = new System.Drawing.Size(79, 15);
            this.lblOctave.Text = "Ruta Octave:";

            // txtOctavePath
            this.txtOctavePath.Location = new System.Drawing.Point(10, 42);
            this.txtOctavePath.Name = "txtOctavePath";
            this.txtOctavePath.Size = new System.Drawing.Size(280, 23);
            this.txtOctavePath.Text = "C:\\Program Files\\GNU Octave\\Octave-11.1.0\\mingw64\\bin\\octave-cli.exe";

            // lblElements
            this.lblElements.AutoSize = true;
            this.lblElements.Location = new System.Drawing.Point(10, 80);
            this.lblElements.Name = "lblElements";
            this.lblElements.Size = new System.Drawing.Size(73, 15);
            this.lblElements.Text = "Puntos Sim:";

            // txtElements
            this.txtElements.Location = new System.Drawing.Point(10, 100);
            this.txtElements.Name = "txtElements";
            this.txtElements.Size = new System.Drawing.Size(130, 23);
            this.txtElements.Text = "200";
            this.txtElements.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // lblScale
            this.lblScale.AutoSize = true;
            this.lblScale.Location = new System.Drawing.Point(160, 80);
            this.lblScale.Name = "lblScale";
            this.lblScale.Size = new System.Drawing.Size(80, 15);
            this.lblScale.Text = "Factor Escala:";

            // txtScaleFactor
            this.txtScaleFactor.Location = new System.Drawing.Point(160, 100);
            this.txtScaleFactor.Name = "txtScaleFactor";
            this.txtScaleFactor.Size = new System.Drawing.Size(130, 23);
            this.txtScaleFactor.Text = "120";
            this.txtScaleFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // 
            // btnSimulate
            // 
            this.btnSimulate.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.btnSimulate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSimulate.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSimulate.ForeColor = System.Drawing.Color.White;
            this.btnSimulate.Location = new System.Drawing.Point(12, 665);
            this.btnSimulate.Name = "btnSimulate";
            this.btnSimulate.Size = new System.Drawing.Size(300, 45);
            this.btnSimulate.TabIndex = 3;
            this.btnSimulate.Text = "Iniciar Simulación";
            this.btnSimulate.UseVisualStyleBackColor = false;

            // 
            // progressBarSim
            // 
            this.progressBarSim.Location = new System.Drawing.Point(12, 720);
            this.progressBarSim.Name = "progressBarSim";
            this.progressBarSim.Size = new System.Drawing.Size(300, 15);
            this.progressBarSim.TabIndex = 4;
            this.progressBarSim.Visible = false;

            // 
            // lblSimStatus
            // 
            this.lblSimStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblSimStatus.ForeColor = System.Drawing.Color.DimGray;
            this.lblSimStatus.Location = new System.Drawing.Point(12, 740);
            this.lblSimStatus.Name = "lblSimStatus";
            this.lblSimStatus.Size = new System.Drawing.Size(300, 50);
            this.lblSimStatus.TabIndex = 5;
            this.lblSimStatus.Text = "Simulación combinatoria completada con éxito";

            // 
            // picCanvas
            // 
            this.picCanvas.BackColor = System.Drawing.Color.White;
            this.picCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCanvas.Location = new System.Drawing.Point(330, 12);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(500, 710);
            this.picCanvas.TabIndex = 6;
            this.picCanvas.TabStop = false;

            // 
            // trackBarTime
            // 
            this.trackBarTime.Location = new System.Drawing.Point(330, 728);
            this.trackBarTime.Name = "trackBarTime";
            this.trackBarTime.Size = new System.Drawing.Size(500, 45);
            this.trackBarTime.TabIndex = 7;
            this.trackBarTime.TickStyle = System.Windows.Forms.TickStyle.None;

            // 
            // btnPlayPause
            // 
            this.btnPlayPause.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnPlayPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayPause.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnPlayPause.ForeColor = System.Drawing.Color.White;
            this.btnPlayPause.Location = new System.Drawing.Point(330, 775);
            this.btnPlayPause.Name = "btnPlayPause";
            this.btnPlayPause.Size = new System.Drawing.Size(100, 36);
            this.btnPlayPause.TabIndex = 8;
            this.btnPlayPause.Text = "Iniciar";
            this.btnPlayPause.UseVisualStyleBackColor = false;

            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(230, 126, 34);
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(440, 775);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 36);
            this.btnReset.TabIndex = 9;
            this.btnReset.Text = "Reiniciar";
            this.btnReset.UseVisualStyleBackColor = false;

            // 
            // lblTime
            // 
            this.lblTime.BackColor = System.Drawing.Color.White;
            this.lblTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTime.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTime.Location = new System.Drawing.Point(550, 775);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(160, 36);
            this.lblTime.TabIndex = 10;
            this.lblTime.Text = "Tiempo: 0,00 s /\n20,00 s";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // cbAnimType
            // 
            this.cbAnimType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAnimType.FormattingEnabled = true;
            this.cbAnimType.Items.AddRange(new object[] { "Paso", "Impulso" });
            this.cbAnimType.Location = new System.Drawing.Point(720, 775);
            this.cbAnimType.Name = "cbAnimType";
            this.cbAnimType.Size = new System.Drawing.Size(110, 23);
            this.cbAnimType.TabIndex = 11;

            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.tabResults);
            this.mainTabControl.Controls.Add(this.tabMath);
            this.mainTabControl.Location = new System.Drawing.Point(845, 12);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(730, 850);
            this.mainTabControl.TabIndex = 12;

            // 
            // tabResults
            // 
            this.tabResults.Controls.Add(this.lblResultsSummary);
            this.tabResults.Controls.Add(this.dgvResults);
            this.tabResults.Controls.Add(this.chartStep);
            this.tabResults.Controls.Add(this.chartImpulse);
            this.tabResults.Location = new System.Drawing.Point(4, 24);
            this.tabResults.Name = "tabResults";
            this.tabResults.Padding = new System.Windows.Forms.Padding(3);
            this.tabResults.Size = new System.Drawing.Size(722, 822);
            this.tabResults.TabIndex = 0;
            this.tabResults.Text = "Dashboard & Iteraciones";
            this.tabResults.UseVisualStyleBackColor = true;

            // 
            // lblResultsSummary
            // 
            this.lblResultsSummary.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblResultsSummary.Location = new System.Drawing.Point(10, 10);
            this.lblResultsSummary.Name = "lblResultsSummary";
            this.lblResultsSummary.Size = new System.Drawing.Size(700, 25);
            this.lblResultsSummary.TabIndex = 0;
            this.lblResultsSummary.Text = "Simulaciones ejecutadas: 0. Seleccione una fila para cargar sus gráficas y animación.";

            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvResults.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvResults.Location = new System.Drawing.Point(10, 40);
            this.dgvResults.MultiSelect = false;
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.RowHeadersVisible = false;
            this.dgvResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResults.Size = new System.Drawing.Size(702, 310);
            this.dgvResults.TabIndex = 1;

            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Iteración";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;

            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Resorte";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;

            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Amortigu";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;

            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Masa";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;

            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Picos Paso";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;

            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Picos Impulso";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;

            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Duración Paso";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;

            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Duración Impulso";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;

            // 
            // chartStep
            // 
            chartArea5.AxisX.LabelStyle.Format = "0.0";
            chartArea5.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea5.AxisX.Title = "Tiempo (s)";
            chartArea5.AxisX.TitleFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            chartArea5.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea5.AxisY.Title = "Desplazamiento (y)";
            chartArea5.AxisY.TitleFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            chartArea5.Name = "MainArea";
            this.chartStep.ChartAreas.Add(chartArea5);
            legend5.Alignment = System.Drawing.StringAlignment.Center;
            legend5.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend5.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            legend5.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
            legend5.Name = "Legend1";
            this.chartStep.Legends.Add(legend5);
            this.chartStep.Location = new System.Drawing.Point(10, 360);
            this.chartStep.Name = "chartStep";
            this.chartStep.Size = new System.Drawing.Size(346, 450);
            this.chartStep.TabIndex = 2;
            title5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            title5.Name = "Title1";
            title5.Text = "Respuesta al Paso";
            this.chartStep.Titles.Add(title5);

            // 
            // chartImpulse
            // 
            chartArea6.AxisX.LabelStyle.Format = "0.0";
            chartArea6.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea6.AxisX.Title = "Tiempo (s)";
            chartArea6.AxisX.TitleFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            chartArea6.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea6.AxisY.Title = "Desplazamiento (y)";
            chartArea6.AxisY.TitleFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            chartArea6.Name = "MainArea";
            this.chartImpulse.ChartAreas.Add(chartArea6);
            legend6.Alignment = System.Drawing.StringAlignment.Center;
            legend6.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend6.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            legend6.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
            legend6.Name = "Legend1";
            this.chartImpulse.Legends.Add(legend6);
            this.chartImpulse.Location = new System.Drawing.Point(366, 360);
            this.chartImpulse.Name = "chartImpulse";
            this.chartImpulse.Size = new System.Drawing.Size(346, 450);
            this.chartImpulse.TabIndex = 3;
            title6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            title6.Name = "Title1";
            title6.Text = "Respuesta al Impulso";
            this.chartImpulse.Titles.Add(title6);

            // 
            // tabMath
            // 
            this.tabMath.Controls.Add(this.rtbMath);
            this.tabMath.Location = new System.Drawing.Point(4, 24);
            this.tabMath.Name = "tabMath";
            this.tabMath.Padding = new System.Windows.Forms.Padding(3);
            this.tabMath.Size = new System.Drawing.Size(722, 822);
            this.tabMath.TabIndex = 1;
            this.tabMath.Text = "Deducción Matemática";
            this.tabMath.UseVisualStyleBackColor = true;

            // 
            // rtbMath
            // 
            this.rtbMath.BackColor = System.Drawing.Color.White;
            this.rtbMath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbMath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbMath.Font = new System.Drawing.Font("Consolas", 10F);
            this.rtbMath.Location = new System.Drawing.Point(3, 3);
            this.rtbMath.Name = "rtbMath";
            this.rtbMath.ReadOnly = true;
            this.rtbMath.Size = new System.Drawing.Size(716, 816);
            this.rtbMath.TabIndex = 0;
            this.rtbMath.Text = "";

            // 
            // timer1
            // 
            this.timer1.Interval = 50;

            // Event connections
            this.btnSimulate.Click += new System.EventHandler(this.btnSimulate_Click);
            this.dgvResults.SelectionChanged += new System.EventHandler(this.dgvResults_SelectionChanged);
            this.btnPlayPause.Click += new System.EventHandler(this.btnPlayPause_Click);
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            this.trackBarTime.Scroll += new System.EventHandler(this.trackBarTime_Scroll);
            this.cbAnimType.SelectedIndexChanged += new System.EventHandler(this.cbAnimType_SelectedIndexChanged);
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.picCanvas_Paint);

            // 
            // SpringMassForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1590, 875);
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.cbAnimType);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnPlayPause);
            this.Controls.Add(this.trackBarTime);
            this.Controls.Add(this.picCanvas);
            this.Controls.Add(this.lblSimStatus);
            this.Controls.Add(this.progressBarSim);
            this.Controls.Add(this.btnSimulate);
            this.Controls.Add(this.gbSoftware);
            this.Controls.Add(this.gbRanges);
            this.Controls.Add(this.gbFixed);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SpringMassForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simulador Físico Multimasa (3 Masas - 4 Resortes - 4 Amortiguadores)";
            this.Load += new System.EventHandler(this.SpringMassForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTime)).EndInit();
            this.mainTabControl.ResumeLayout(false);
            this.tabResults.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartImpulse)).EndInit();
            this.tabMath.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        // Variables Declaradas en el Diseñador (Estilo tradicional)
        private System.Windows.Forms.GroupBox gbFixed;
        private System.Windows.Forms.GroupBox gbRanges;
        private System.Windows.Forms.GroupBox gbSoftware;

        private System.Windows.Forms.TextBox txtM1;
        private System.Windows.Forms.TextBox txtM2;
        private System.Windows.Forms.TextBox txtM3;
        private System.Windows.Forms.TextBox txtK1;
        private System.Windows.Forms.TextBox txtK2;
        private System.Windows.Forms.TextBox txtK3;
        private System.Windows.Forms.TextBox txtK4;
        private System.Windows.Forms.TextBox txtC1;
        private System.Windows.Forms.TextBox txtC2;
        private System.Windows.Forms.TextBox txtC3;
        private System.Windows.Forms.TextBox txtC4;

        private System.Windows.Forms.ComboBox cbVaryK;
        private System.Windows.Forms.ComboBox cbVaryC;
        private System.Windows.Forms.ComboBox cbVaryM;
        private System.Windows.Forms.TextBox txtKMin;
        private System.Windows.Forms.TextBox txtKMax;
        private System.Windows.Forms.TextBox txtKStep;
        private System.Windows.Forms.TextBox txtCMin;
        private System.Windows.Forms.TextBox txtCMax;
        private System.Windows.Forms.TextBox txtCStep;
        private System.Windows.Forms.TextBox txtMMin;
        private System.Windows.Forms.TextBox txtMMax;
        private System.Windows.Forms.TextBox txtMStep;

        private System.Windows.Forms.TextBox txtOctavePath;
        private System.Windows.Forms.TextBox txtElements;
        private System.Windows.Forms.TextBox txtScaleFactor;
        private System.Windows.Forms.Button btnSimulate;
        private System.Windows.Forms.ProgressBar progressBarSim;
        private System.Windows.Forms.Label lblSimStatus;

        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.TrackBar trackBarTime;
        private System.Windows.Forms.Button btnPlayPause;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.ComboBox cbAnimType;

        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage tabResults;
        private System.Windows.Forms.TabPage tabMath;
        private System.Windows.Forms.Label lblResultsSummary;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartStep;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartImpulse;
        private System.Windows.Forms.RichTextBox rtbMath;
        private System.Windows.Forms.Timer timer1;

        private System.Windows.Forms.Label lblM1;
        private System.Windows.Forms.Label lblM2;
        private System.Windows.Forms.Label lblM3;
        private System.Windows.Forms.Label lblK1;
        private System.Windows.Forms.Label lblK2;
        private System.Windows.Forms.Label lblK3;
        private System.Windows.Forms.Label lblK4;
        private System.Windows.Forms.Label lblC1;
        private System.Windows.Forms.Label lblC2;
        private System.Windows.Forms.Label lblC3;
        private System.Windows.Forms.Label lblC4;
        private System.Windows.Forms.Label lblHeaderVar;
        private System.Windows.Forms.Label lblHeaderMin;
        private System.Windows.Forms.Label lblHeaderMax;
        private System.Windows.Forms.Label lblHeaderStep;
        private System.Windows.Forms.Label lblOctave;
        private System.Windows.Forms.Label lblElements;
        private System.Windows.Forms.Label lblScale;

        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
    }
}
