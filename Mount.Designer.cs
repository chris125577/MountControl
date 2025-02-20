namespace MountControl
{
    partial class ControlForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlForm));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            this.btnChooser = new System.Windows.Forms.Button();
            this.btnPark = new System.Windows.Forms.Button();
            this.btnUnpark = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnInitialize = new System.Windows.Forms.Button();
            this.AltText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AzText = new System.Windows.Forms.TextBox();
            this.btnAbort = new System.Windows.Forms.Button();
            this.btnNorth = new System.Windows.Forms.Button();
            this.btnSouth = new System.Windows.Forms.Button();
            this.btnWest = new System.Windows.Forms.Button();
            this.btnEast = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.RAText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.DECText = new System.Windows.Forms.TextBox();
            this.statusbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.statustimer = new System.Windows.Forms.Timer(this.components);
            this.GuideRateRA = new System.Windows.Forms.NumericUpDown();
            this.JogValIP = new System.Windows.Forms.NumericUpDown();
            this.btnTrackOn = new System.Windows.Forms.Button();
            this.btnTrackOff = new System.Windows.Forms.Button();
            this.LatitudeIP = new System.Windows.Forms.TextBox();
            this.LongitudeIP = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Application = new System.Windows.Forms.TabControl();
            this.Control = new System.Windows.Forms.TabPage();
            this.IndPark = new System.Windows.Forms.Button();
            this.IndHome = new System.Windows.Forms.Button();
            this.IndTrack = new System.Windows.Forms.Button();
            this.IndSlew = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnConnectDup = new System.Windows.Forms.Button();
            this.PA = new System.Windows.Forms.TabPage();
            this.label26 = new System.Windows.Forms.Label();
            this.PAstatus = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.DEC2Text = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.RA2text = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.minus3 = new System.Windows.Forms.Button();
            this.plus3 = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.environ = new System.Windows.Forms.TabPage();
            this.btnWeathChoose = new System.Windows.Forms.Button();
            this.rain = new System.Windows.Forms.Label();
            this.rainratetext = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.skytemptext = new System.Windows.Forms.TextBox();
            this.btnDiscWeather = new System.Windows.Forms.Button();
            this.btnConnectWeather = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.skyqtext = new System.Windows.Forms.TextBox();
            this.cloud = new System.Windows.Forms.Label();
            this.cloudtext = new System.Windows.Forms.TextBox();
            this.dew = new System.Windows.Forms.Label();
            this.dewpointtext = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.humidtext = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.pressuretext = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.temptext = new System.Windows.Forms.TextBox();
            this.graphs = new System.Windows.Forms.TabPage();
            this.resetbtn = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.btngraphsel = new System.Windows.Forms.ComboBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.setup = new System.Windows.Forms.TabPage();
            this.dupbtnDisconnect = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.slewrate = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.GuideRateDEC = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.btnConnectSetup = new System.Windows.Forms.Button();
            this.elevate = new System.Windows.Forms.Label();
            this.ElevationIP = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.GuideRateRA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.JogValIP)).BeginInit();
            this.Application.SuspendLayout();
            this.Control.SuspendLayout();
            this.PA.SuspendLayout();
            this.environ.SuspendLayout();
            this.graphs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.setup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GuideRateDEC)).BeginInit();
            this.SuspendLayout();
            // 
            // btnChooser
            // 
            this.btnChooser.BackColor = System.Drawing.Color.Black;
            this.btnChooser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChooser.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnChooser.Location = new System.Drawing.Point(21, 12);
            this.btnChooser.Name = "btnChooser";
            this.btnChooser.Size = new System.Drawing.Size(64, 23);
            this.btnChooser.TabIndex = 1;
            this.btnChooser.Text = "chooser";
            this.btnChooser.UseVisualStyleBackColor = false;
            this.btnChooser.Click += new System.EventHandler(this.choose_mount);
            // 
            // btnPark
            // 
            this.btnPark.BackColor = System.Drawing.Color.Black;
            this.btnPark.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPark.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnPark.Location = new System.Drawing.Point(8, 17);
            this.btnPark.Name = "btnPark";
            this.btnPark.Size = new System.Drawing.Size(57, 23);
            this.btnPark.TabIndex = 3;
            this.btnPark.Text = "park";
            this.btnPark.UseVisualStyleBackColor = false;
            this.btnPark.Click += new System.EventHandler(this.park_mount);
            // 
            // btnUnpark
            // 
            this.btnUnpark.BackColor = System.Drawing.Color.Black;
            this.btnUnpark.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnpark.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnUnpark.Location = new System.Drawing.Point(74, 17);
            this.btnUnpark.Name = "btnUnpark";
            this.btnUnpark.Size = new System.Drawing.Size(57, 23);
            this.btnUnpark.TabIndex = 4;
            this.btnUnpark.Text = "unpark";
            this.btnUnpark.UseVisualStyleBackColor = false;
            this.btnUnpark.Click += new System.EventHandler(this.unpark);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.BackColor = System.Drawing.Color.Black;
            this.btnDisconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisconnect.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDisconnect.Location = new System.Drawing.Point(99, 75);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(80, 23);
            this.btnDisconnect.TabIndex = 5;
            this.btnDisconnect.Text = "disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = false;
            this.btnDisconnect.Click += new System.EventHandler(this.disconnect_mount);
            // 
            // btnInitialize
            // 
            this.btnInitialize.BackColor = System.Drawing.Color.Black;
            this.btnInitialize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInitialize.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnInitialize.Location = new System.Drawing.Point(94, 229);
            this.btnInitialize.Name = "btnInitialize";
            this.btnInitialize.Size = new System.Drawing.Size(77, 23);
            this.btnInitialize.TabIndex = 6;
            this.btnInitialize.Text = "init. mount";
            this.btnInitialize.UseVisualStyleBackColor = false;
            this.btnInitialize.Click += new System.EventHandler(this.init_mount);
            // 
            // AltText
            // 
            this.AltText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.AltText.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.AltText.Location = new System.Drawing.Point(68, 202);
            this.AltText.Name = "AltText";
            this.AltText.Size = new System.Drawing.Size(76, 20);
            this.AltText.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(20, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "altitude";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(20, 232);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "azimuth";
            // 
            // AzText
            // 
            this.AzText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.AzText.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.AzText.Location = new System.Drawing.Point(68, 229);
            this.AzText.Name = "AzText";
            this.AzText.Size = new System.Drawing.Size(76, 20);
            this.AzText.TabIndex = 9;
            // 
            // btnAbort
            // 
            this.btnAbort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAbort.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAbort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbort.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAbort.Location = new System.Drawing.Point(202, 17);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(57, 23);
            this.btnAbort.TabIndex = 11;
            this.btnAbort.Text = "ABORT";
            this.btnAbort.UseVisualStyleBackColor = false;
            this.btnAbort.Click += new System.EventHandler(this.abort_mount);
            // 
            // btnNorth
            // 
            this.btnNorth.BackColor = System.Drawing.Color.Black;
            this.btnNorth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNorth.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnNorth.Location = new System.Drawing.Point(202, 224);
            this.btnNorth.Name = "btnNorth";
            this.btnNorth.Size = new System.Drawing.Size(25, 25);
            this.btnNorth.TabIndex = 14;
            this.btnNorth.Text = "N";
            this.btnNorth.UseVisualStyleBackColor = false;
            this.btnNorth.Click += new System.EventHandler(this.north);
            // 
            // btnSouth
            // 
            this.btnSouth.BackColor = System.Drawing.Color.Black;
            this.btnSouth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSouth.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSouth.Location = new System.Drawing.Point(202, 277);
            this.btnSouth.Name = "btnSouth";
            this.btnSouth.Size = new System.Drawing.Size(25, 25);
            this.btnSouth.TabIndex = 15;
            this.btnSouth.Text = "S";
            this.btnSouth.UseVisualStyleBackColor = false;
            this.btnSouth.Click += new System.EventHandler(this.south);
            // 
            // btnWest
            // 
            this.btnWest.BackColor = System.Drawing.Color.Black;
            this.btnWest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWest.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnWest.Location = new System.Drawing.Point(175, 250);
            this.btnWest.Name = "btnWest";
            this.btnWest.Size = new System.Drawing.Size(25, 25);
            this.btnWest.TabIndex = 16;
            this.btnWest.Text = "W";
            this.btnWest.UseVisualStyleBackColor = false;
            this.btnWest.Click += new System.EventHandler(this.west);
            // 
            // btnEast
            // 
            this.btnEast.BackColor = System.Drawing.Color.Black;
            this.btnEast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEast.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEast.Location = new System.Drawing.Point(229, 250);
            this.btnEast.Name = "btnEast";
            this.btnEast.Size = new System.Drawing.Size(25, 25);
            this.btnEast.TabIndex = 17;
            this.btnEast.Text = "E";
            this.btnEast.UseVisualStyleBackColor = false;
            this.btnEast.Click += new System.EventHandler(this.east);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(40, 259);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "RA";
            // 
            // RAText
            // 
            this.RAText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.RAText.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.RAText.Location = new System.Drawing.Point(68, 256);
            this.RAText.Name = "RAText";
            this.RAText.Size = new System.Drawing.Size(76, 20);
            this.RAText.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(33, 286);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "DEC";
            // 
            // DECText
            // 
            this.DECText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.DECText.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.DECText.Location = new System.Drawing.Point(68, 283);
            this.DECText.Name = "DECText";
            this.DECText.Size = new System.Drawing.Size(76, 20);
            this.DECText.TabIndex = 20;
            // 
            // statusbox
            // 
            this.statusbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.statusbox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.statusbox.Location = new System.Drawing.Point(53, 114);
            this.statusbox.Name = "statusbox";
            this.statusbox.Size = new System.Drawing.Size(213, 20);
            this.statusbox.TabIndex = 22;
            this.statusbox.WordWrap = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(11, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "status";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(159, 196);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "jog (min)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(38, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "RA rate 0.25-1.0x";
            // 
            // statustimer
            // 
            this.statustimer.Enabled = true;
            this.statustimer.Interval = 1000;
            this.statustimer.Tick += new System.EventHandler(this.status_updates);
            // 
            // GuideRateRA
            // 
            this.GuideRateRA.BackColor = System.Drawing.Color.Black;
            this.GuideRateRA.DecimalPlaces = 2;
            this.GuideRateRA.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.GuideRateRA.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.GuideRateRA.Location = new System.Drawing.Point(135, 61);
            this.GuideRateRA.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.GuideRateRA.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.GuideRateRA.Name = "GuideRateRA";
            this.GuideRateRA.Size = new System.Drawing.Size(64, 20);
            this.GuideRateRA.TabIndex = 27;
            this.GuideRateRA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.GuideRateRA.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // JogValIP
            // 
            this.JogValIP.BackColor = System.Drawing.Color.Black;
            this.JogValIP.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.JogValIP.Location = new System.Drawing.Point(211, 194);
            this.JogValIP.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.JogValIP.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.JogValIP.Name = "JogValIP";
            this.JogValIP.Size = new System.Drawing.Size(48, 20);
            this.JogValIP.TabIndex = 28;
            this.JogValIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.JogValIP.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.JogValIP.ValueChanged += new System.EventHandler(this.jog);
            // 
            // btnTrackOn
            // 
            this.btnTrackOn.BackColor = System.Drawing.Color.Black;
            this.btnTrackOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrackOn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnTrackOn.Location = new System.Drawing.Point(8, 46);
            this.btnTrackOn.Name = "btnTrackOn";
            this.btnTrackOn.Size = new System.Drawing.Size(80, 23);
            this.btnTrackOn.TabIndex = 29;
            this.btnTrackOn.Text = "tracking on";
            this.btnTrackOn.UseVisualStyleBackColor = false;
            this.btnTrackOn.Click += new System.EventHandler(this.track_on);
            // 
            // btnTrackOff
            // 
            this.btnTrackOff.BackColor = System.Drawing.Color.Black;
            this.btnTrackOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrackOff.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnTrackOff.Location = new System.Drawing.Point(99, 46);
            this.btnTrackOff.Name = "btnTrackOff";
            this.btnTrackOff.Size = new System.Drawing.Size(80, 23);
            this.btnTrackOff.TabIndex = 30;
            this.btnTrackOff.Text = "tracking off";
            this.btnTrackOff.UseVisualStyleBackColor = false;
            this.btnTrackOff.Click += new System.EventHandler(this.track_off);
            // 
            // LatitudeIP
            // 
            this.LatitudeIP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LatitudeIP.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LatitudeIP.Location = new System.Drawing.Point(71, 140);
            this.LatitudeIP.Name = "LatitudeIP";
            this.LatitudeIP.Size = new System.Drawing.Size(64, 20);
            this.LatitudeIP.TabIndex = 31;
            this.LatitudeIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LongitudeIP
            // 
            this.LongitudeIP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LongitudeIP.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LongitudeIP.Location = new System.Drawing.Point(201, 140);
            this.LongitudeIP.Name = "LongitudeIP";
            this.LongitudeIP.Size = new System.Drawing.Size(64, 20);
            this.LongitudeIP.TabIndex = 32;
            this.LongitudeIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Location = new System.Drawing.Point(25, 143);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "latitude";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label9.Location = new System.Drawing.Point(144, 143);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 34;
            this.label9.Text = "longitude";
            // 
            // Application
            // 
            this.Application.Controls.Add(this.Control);
            this.Application.Controls.Add(this.PA);
            this.Application.Controls.Add(this.environ);
            this.Application.Controls.Add(this.graphs);
            this.Application.Controls.Add(this.setup);
            this.Application.Location = new System.Drawing.Point(0, 1);
            this.Application.Name = "Application";
            this.Application.SelectedIndex = 0;
            this.Application.Size = new System.Drawing.Size(288, 337);
            this.Application.TabIndex = 35;
            // 
            // Control
            // 
            this.Control.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.Control.Controls.Add(this.IndPark);
            this.Control.Controls.Add(this.IndHome);
            this.Control.Controls.Add(this.IndTrack);
            this.Control.Controls.Add(this.IndSlew);
            this.Control.Controls.Add(this.btnHome);
            this.Control.Controls.Add(this.btnConnectDup);
            this.Control.Controls.Add(this.JogValIP);
            this.Control.Controls.Add(this.btnTrackOff);
            this.Control.Controls.Add(this.label6);
            this.Control.Controls.Add(this.btnDisconnect);
            this.Control.Controls.Add(this.label3);
            this.Control.Controls.Add(this.btnTrackOn);
            this.Control.Controls.Add(this.statusbox);
            this.Control.Controls.Add(this.btnPark);
            this.Control.Controls.Add(this.label5);
            this.Control.Controls.Add(this.btnUnpark);
            this.Control.Controls.Add(this.DECText);
            this.Control.Controls.Add(this.label4);
            this.Control.Controls.Add(this.btnAbort);
            this.Control.Controls.Add(this.RAText);
            this.Control.Controls.Add(this.btnNorth);
            this.Control.Controls.Add(this.btnEast);
            this.Control.Controls.Add(this.AltText);
            this.Control.Controls.Add(this.btnWest);
            this.Control.Controls.Add(this.label1);
            this.Control.Controls.Add(this.btnSouth);
            this.Control.Controls.Add(this.AzText);
            this.Control.Controls.Add(this.label2);
            this.Control.Location = new System.Drawing.Point(4, 22);
            this.Control.Name = "Control";
            this.Control.Padding = new System.Windows.Forms.Padding(3);
            this.Control.Size = new System.Drawing.Size(280, 311);
            this.Control.TabIndex = 0;
            this.Control.Text = "Mount";
            // 
            // IndPark
            // 
            this.IndPark.BackColor = System.Drawing.Color.Black;
            this.IndPark.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IndPark.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.IndPark.Location = new System.Drawing.Point(206, 140);
            this.IndPark.Name = "IndPark";
            this.IndPark.Size = new System.Drawing.Size(60, 25);
            this.IndPark.TabIndex = 38;
            this.IndPark.Text = "parked";
            this.IndPark.UseVisualStyleBackColor = false;
            // 
            // IndHome
            // 
            this.IndHome.BackColor = System.Drawing.Color.Black;
            this.IndHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IndHome.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.IndHome.Location = new System.Drawing.Point(140, 140);
            this.IndHome.Name = "IndHome";
            this.IndHome.Size = new System.Drawing.Size(60, 25);
            this.IndHome.TabIndex = 37;
            this.IndHome.Text = "homed";
            this.IndHome.UseVisualStyleBackColor = false;
            // 
            // IndTrack
            // 
            this.IndTrack.BackColor = System.Drawing.Color.Black;
            this.IndTrack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IndTrack.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.IndTrack.Location = new System.Drawing.Point(74, 140);
            this.IndTrack.Name = "IndTrack";
            this.IndTrack.Size = new System.Drawing.Size(60, 25);
            this.IndTrack.TabIndex = 36;
            this.IndTrack.Text = "tracking";
            this.IndTrack.UseVisualStyleBackColor = false;
            // 
            // IndSlew
            // 
            this.IndSlew.BackColor = System.Drawing.Color.Black;
            this.IndSlew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IndSlew.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.IndSlew.Location = new System.Drawing.Point(8, 140);
            this.IndSlew.Name = "IndSlew";
            this.IndSlew.Size = new System.Drawing.Size(60, 25);
            this.IndSlew.TabIndex = 35;
            this.IndSlew.Text = "slewing";
            this.IndSlew.UseVisualStyleBackColor = false;
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.Black;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnHome.Location = new System.Drawing.Point(139, 17);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(57, 23);
            this.btnHome.TabIndex = 34;
            this.btnHome.Text = "home";
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.home_mount);
            // 
            // btnConnectDup
            // 
            this.btnConnectDup.BackColor = System.Drawing.Color.Black;
            this.btnConnectDup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnectDup.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnConnectDup.Location = new System.Drawing.Point(8, 75);
            this.btnConnectDup.Name = "btnConnectDup";
            this.btnConnectDup.Size = new System.Drawing.Size(80, 23);
            this.btnConnectDup.TabIndex = 31;
            this.btnConnectDup.Text = "connect";
            this.btnConnectDup.UseVisualStyleBackColor = false;
            this.btnConnectDup.Click += new System.EventHandler(this.connect_mount);
            // 
            // PA
            // 
            this.PA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PA.Controls.Add(this.label26);
            this.PA.Controls.Add(this.PAstatus);
            this.PA.Controls.Add(this.label19);
            this.PA.Controls.Add(this.label23);
            this.PA.Controls.Add(this.DEC2Text);
            this.PA.Controls.Add(this.label24);
            this.PA.Controls.Add(this.RA2text);
            this.PA.Controls.Add(this.label21);
            this.PA.Controls.Add(this.minus3);
            this.PA.Controls.Add(this.plus3);
            this.PA.Controls.Add(this.label17);
            this.PA.Location = new System.Drawing.Point(4, 22);
            this.PA.Name = "PA";
            this.PA.Padding = new System.Windows.Forms.Padding(3);
            this.PA.Size = new System.Drawing.Size(280, 311);
            this.PA.TabIndex = 3;
            this.PA.Text = "Pol. Algn.";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label26.Location = new System.Drawing.Point(29, 257);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(67, 13);
            this.label26.TabIndex = 60;
            this.label26.Text = "mount status";
            // 
            // PAstatus
            // 
            this.PAstatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PAstatus.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.PAstatus.Location = new System.Drawing.Point(102, 254);
            this.PAstatus.Name = "PAstatus";
            this.PAstatus.Size = new System.Drawing.Size(160, 20);
            this.PAstatus.TabIndex = 59;
            this.PAstatus.WordWrap = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Yellow;
            this.label19.Location = new System.Drawing.Point(8, 13);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(244, 51);
            this.label19.TabIndex = 58;
            this.label19.Text = "PoleMaster/SharpCap Utility\r\n\r\nSET MOUNT LIMITS BEFORE USING";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label23.Location = new System.Drawing.Point(142, 170);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(29, 13);
            this.label23.TabIndex = 57;
            this.label23.Text = "DEC";
            // 
            // DEC2Text
            // 
            this.DEC2Text.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.DEC2Text.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.DEC2Text.Location = new System.Drawing.Point(177, 167);
            this.DEC2Text.Name = "DEC2Text";
            this.DEC2Text.Size = new System.Drawing.Size(59, 20);
            this.DEC2Text.TabIndex = 56;
            this.DEC2Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label24.Location = new System.Drawing.Point(149, 140);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(22, 13);
            this.label24.TabIndex = 55;
            this.label24.Text = "RA";
            // 
            // RA2text
            // 
            this.RA2text.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.RA2text.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.RA2text.Location = new System.Drawing.Point(177, 137);
            this.RA2text.Name = "RA2text";
            this.RA2text.Size = new System.Drawing.Size(59, 20);
            this.RA2text.TabIndex = 54;
            this.RA2text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label21.Location = new System.Drawing.Point(27, 186);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(82, 13);
            this.label21.TabIndex = 50;
            this.label21.Text = "2) rotate 45 deg";
            this.label21.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // minus3
            // 
            this.minus3.Location = new System.Drawing.Point(30, 202);
            this.minus3.Name = "minus3";
            this.minus3.Size = new System.Drawing.Size(60, 30);
            this.minus3.TabIndex = 46;
            this.minus3.Text = "Next";
            this.minus3.UseVisualStyleBackColor = true;
            this.minus3.Click += new System.EventHandler(this.Plus3Ra);
            // 
            // plus3
            // 
            this.plus3.Location = new System.Drawing.Point(30, 133);
            this.plus3.Name = "plus3";
            this.plus3.Size = new System.Drawing.Size(60, 30);
            this.plus3.TabIndex = 45;
            this.plus3.Text = "Start";
            this.toolTip1.SetToolTip(this.plus3, resources.GetString("plus3.ToolTip"));
            this.plus3.UseVisualStyleBackColor = true;
            this.plus3.Click += new System.EventHandler(this.PMStart);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label17.Location = new System.Drawing.Point(27, 117);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(116, 13);
            this.label17.TabIndex = 44;
            this.label17.Text = "1) goto starting position";
            this.label17.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // environ
            // 
            this.environ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.environ.Controls.Add(this.btnWeathChoose);
            this.environ.Controls.Add(this.rain);
            this.environ.Controls.Add(this.rainratetext);
            this.environ.Controls.Add(this.label16);
            this.environ.Controls.Add(this.skytemptext);
            this.environ.Controls.Add(this.btnDiscWeather);
            this.environ.Controls.Add(this.btnConnectWeather);
            this.environ.Controls.Add(this.label18);
            this.environ.Controls.Add(this.skyqtext);
            this.environ.Controls.Add(this.cloud);
            this.environ.Controls.Add(this.cloudtext);
            this.environ.Controls.Add(this.dew);
            this.environ.Controls.Add(this.dewpointtext);
            this.environ.Controls.Add(this.label15);
            this.environ.Controls.Add(this.humidtext);
            this.environ.Controls.Add(this.label14);
            this.environ.Controls.Add(this.pressuretext);
            this.environ.Controls.Add(this.label13);
            this.environ.Controls.Add(this.temptext);
            this.environ.Location = new System.Drawing.Point(4, 22);
            this.environ.Name = "environ";
            this.environ.Padding = new System.Windows.Forms.Padding(3);
            this.environ.Size = new System.Drawing.Size(280, 311);
            this.environ.TabIndex = 2;
            this.environ.Text = "Weather";
            // 
            // btnWeathChoose
            // 
            this.btnWeathChoose.BackColor = System.Drawing.Color.Black;
            this.btnWeathChoose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWeathChoose.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnWeathChoose.Location = new System.Drawing.Point(162, 15);
            this.btnWeathChoose.Name = "btnWeathChoose";
            this.btnWeathChoose.Size = new System.Drawing.Size(64, 23);
            this.btnWeathChoose.TabIndex = 52;
            this.btnWeathChoose.Text = "chooser";
            this.btnWeathChoose.UseVisualStyleBackColor = false;
            this.btnWeathChoose.Click += new System.EventHandler(this.choose_weather);
            // 
            // rain
            // 
            this.rain.AutoSize = true;
            this.rain.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rain.Location = new System.Drawing.Point(148, 198);
            this.rain.Name = "rain";
            this.rain.Size = new System.Drawing.Size(45, 13);
            this.rain.TabIndex = 51;
            this.rain.Text = "rain rate";
            // 
            // rainratetext
            // 
            this.rainratetext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rainratetext.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rainratetext.Location = new System.Drawing.Point(200, 195);
            this.rainratetext.Name = "rainratetext";
            this.rainratetext.Size = new System.Drawing.Size(69, 20);
            this.rainratetext.TabIndex = 50;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label16.Location = new System.Drawing.Point(155, 168);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(33, 13);
            this.label16.TabIndex = 49;
            this.label16.Text = "sky C";
            // 
            // skytemptext
            // 
            this.skytemptext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.skytemptext.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.skytemptext.Location = new System.Drawing.Point(200, 165);
            this.skytemptext.Name = "skytemptext";
            this.skytemptext.Size = new System.Drawing.Size(69, 20);
            this.skytemptext.TabIndex = 48;
            // 
            // btnDiscWeather
            // 
            this.btnDiscWeather.BackColor = System.Drawing.Color.Black;
            this.btnDiscWeather.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDiscWeather.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDiscWeather.Location = new System.Drawing.Point(67, 55);
            this.btnDiscWeather.Name = "btnDiscWeather";
            this.btnDiscWeather.Size = new System.Drawing.Size(69, 23);
            this.btnDiscWeather.TabIndex = 47;
            this.btnDiscWeather.Text = "disconnect";
            this.btnDiscWeather.UseVisualStyleBackColor = false;
            this.btnDiscWeather.Click += new System.EventHandler(this.disconnect_weather);
            // 
            // btnConnectWeather
            // 
            this.btnConnectWeather.BackColor = System.Drawing.Color.Black;
            this.btnConnectWeather.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnectWeather.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnConnectWeather.Location = new System.Drawing.Point(66, 15);
            this.btnConnectWeather.Name = "btnConnectWeather";
            this.btnConnectWeather.Size = new System.Drawing.Size(70, 23);
            this.btnConnectWeather.TabIndex = 46;
            this.btnConnectWeather.Text = "connect";
            this.btnConnectWeather.UseVisualStyleBackColor = false;
            this.btnConnectWeather.Click += new System.EventHandler(this.connect_weather);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label18.Location = new System.Drawing.Point(159, 138);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(31, 13);
            this.label18.TabIndex = 45;
            this.label18.Text = "SQM";
            // 
            // skyqtext
            // 
            this.skyqtext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.skyqtext.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.skyqtext.Location = new System.Drawing.Point(200, 135);
            this.skyqtext.Name = "skyqtext";
            this.skyqtext.Size = new System.Drawing.Size(69, 20);
            this.skyqtext.TabIndex = 44;
            // 
            // cloud
            // 
            this.cloud.AutoSize = true;
            this.cloud.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cloud.Location = new System.Drawing.Point(157, 108);
            this.cloud.Name = "cloud";
            this.cloud.Size = new System.Drawing.Size(33, 13);
            this.cloud.TabIndex = 43;
            this.cloud.Text = "cloud";
            // 
            // cloudtext
            // 
            this.cloudtext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cloudtext.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cloudtext.Location = new System.Drawing.Point(200, 105);
            this.cloudtext.Name = "cloudtext";
            this.cloudtext.Size = new System.Drawing.Size(69, 20);
            this.cloudtext.TabIndex = 42;
            // 
            // dew
            // 
            this.dew.AutoSize = true;
            this.dew.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.dew.Location = new System.Drawing.Point(5, 198);
            this.dew.Name = "dew";
            this.dew.Size = new System.Drawing.Size(53, 13);
            this.dew.TabIndex = 41;
            this.dew.Text = "dew point";
            // 
            // dewpointtext
            // 
            this.dewpointtext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dewpointtext.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.dewpointtext.Location = new System.Drawing.Point(66, 195);
            this.dewpointtext.Name = "dewpointtext";
            this.dewpointtext.Size = new System.Drawing.Size(70, 20);
            this.dewpointtext.TabIndex = 40;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label15.Location = new System.Drawing.Point(11, 168);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(45, 13);
            this.label15.TabIndex = 39;
            this.label15.Text = "humidity";
            // 
            // humidtext
            // 
            this.humidtext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.humidtext.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.humidtext.Location = new System.Drawing.Point(66, 165);
            this.humidtext.Name = "humidtext";
            this.humidtext.Size = new System.Drawing.Size(70, 20);
            this.humidtext.TabIndex = 38;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label14.Location = new System.Drawing.Point(11, 138);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 13);
            this.label14.TabIndex = 37;
            this.label14.Text = "pressure";
            // 
            // pressuretext
            // 
            this.pressuretext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pressuretext.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.pressuretext.Location = new System.Drawing.Point(66, 135);
            this.pressuretext.Name = "pressuretext";
            this.pressuretext.Size = new System.Drawing.Size(70, 20);
            this.pressuretext.TabIndex = 36;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label13.Location = new System.Drawing.Point(28, 108);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(30, 13);
            this.label13.TabIndex = 35;
            this.label13.Text = "temp";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // temptext
            // 
            this.temptext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.temptext.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.temptext.Location = new System.Drawing.Point(66, 105);
            this.temptext.Name = "temptext";
            this.temptext.Size = new System.Drawing.Size(70, 20);
            this.temptext.TabIndex = 34;
            // 
            // graphs
            // 
            this.graphs.Controls.Add(this.resetbtn);
            this.graphs.Controls.Add(this.label10);
            this.graphs.Controls.Add(this.btngraphsel);
            this.graphs.Controls.Add(this.chart1);
            this.graphs.Location = new System.Drawing.Point(4, 22);
            this.graphs.Name = "graphs";
            this.graphs.Padding = new System.Windows.Forms.Padding(3);
            this.graphs.Size = new System.Drawing.Size(280, 311);
            this.graphs.TabIndex = 4;
            this.graphs.Text = "Graphs";
            this.graphs.UseVisualStyleBackColor = true;
            // 
            // resetbtn
            // 
            this.resetbtn.ForeColor = System.Drawing.Color.Black;
            this.resetbtn.Location = new System.Drawing.Point(151, 288);
            this.resetbtn.Name = "resetbtn";
            this.resetbtn.Size = new System.Drawing.Size(93, 23);
            this.resetbtn.TabIndex = 45;
            this.resetbtn.Text = "clear chart";
            this.resetbtn.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "graph source";
            // 
            // btngraphsel
            // 
            this.btngraphsel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.btngraphsel.FormattingEnabled = true;
            this.btngraphsel.Items.AddRange(new object[] {
            "temp C",
            "humidity %",
            "dewpoint C",
            "sky temp C",
            "cloud cover %",
            "SQM",
            "pressure hPa",
            "rain rate mm/h"});
            this.btngraphsel.Location = new System.Drawing.Point(93, 6);
            this.btngraphsel.Name = "btngraphsel";
            this.btngraphsel.Size = new System.Drawing.Size(102, 21);
            this.btngraphsel.TabIndex = 1;
            this.btngraphsel.SelectedIndexChanged += new System.EventHandler(this.graphselect);
            this.btngraphsel.Click += new System.EventHandler(this.graphselect);
            // 
            // chart1
            // 
            chartArea1.AxisX.LineWidth = 2;
            chartArea1.AxisX.MajorGrid.Interval = 0D;
            chartArea1.AxisX.MajorTickMark.Interval = 0D;
            chartArea1.AxisY.LineWidth = 2;
            chartArea1.AxisY.ScrollBar.Enabled = false;
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            chartArea1.Name = "CloudCover";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Location = new System.Drawing.Point(0, 33);
            this.chart1.Name = "chart1";
            series1.ChartArea = "CloudCover";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.IsVisibleInLegend = false;
            series1.Name = "cloud";
            series1.Points.Add(dataPoint1);
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(280, 270);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.graphselect);
            this.chart1.DoubleClick += new System.EventHandler(this.graphselect);
            this.chart1.MouseCaptureChanged += new System.EventHandler(this.graphselect);
            // 
            // setup
            // 
            this.setup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.setup.Controls.Add(this.dupbtnDisconnect);
            this.setup.Controls.Add(this.label22);
            this.setup.Controls.Add(this.slewrate);
            this.setup.Controls.Add(this.label20);
            this.setup.Controls.Add(this.GuideRateDEC);
            this.setup.Controls.Add(this.label11);
            this.setup.Controls.Add(this.btnConnectSetup);
            this.setup.Controls.Add(this.elevate);
            this.setup.Controls.Add(this.ElevationIP);
            this.setup.Controls.Add(this.btnInitialize);
            this.setup.Controls.Add(this.label9);
            this.setup.Controls.Add(this.btnChooser);
            this.setup.Controls.Add(this.label8);
            this.setup.Controls.Add(this.label7);
            this.setup.Controls.Add(this.LongitudeIP);
            this.setup.Controls.Add(this.GuideRateRA);
            this.setup.Controls.Add(this.LatitudeIP);
            this.setup.Location = new System.Drawing.Point(4, 22);
            this.setup.Name = "setup";
            this.setup.Padding = new System.Windows.Forms.Padding(3);
            this.setup.Size = new System.Drawing.Size(280, 311);
            this.setup.TabIndex = 1;
            this.setup.Text = "Mount Setup";
            // 
            // dupbtnDisconnect
            // 
            this.dupbtnDisconnect.BackColor = System.Drawing.Color.Black;
            this.dupbtnDisconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dupbtnDisconnect.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.dupbtnDisconnect.Location = new System.Drawing.Point(192, 12);
            this.dupbtnDisconnect.Name = "dupbtnDisconnect";
            this.dupbtnDisconnect.Size = new System.Drawing.Size(73, 23);
            this.dupbtnDisconnect.TabIndex = 49;
            this.dupbtnDisconnect.Text = "disconnect";
            this.dupbtnDisconnect.UseVisualStyleBackColor = false;
            this.dupbtnDisconnect.Click += new System.EventHandler(this.disconnect_mount);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label22.Location = new System.Drawing.Point(146, 177);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(49, 13);
            this.label22.TabIndex = 48;
            this.label22.Text = "slew rate";
            // 
            // slewrate
            // 
            this.slewrate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.slewrate.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.slewrate.Location = new System.Drawing.Point(201, 174);
            this.slewrate.Name = "slewrate";
            this.slewrate.Size = new System.Drawing.Size(64, 20);
            this.slewrate.TabIndex = 47;
            this.slewrate.Text = "WIP";
            this.slewrate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.slewrate.TextChanged += new System.EventHandler(this.slewrate_TextChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label20.Location = new System.Drawing.Point(38, 94);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(97, 13);
            this.label20.TabIndex = 45;
            this.label20.Text = "DEC rate 0.25-1.0x";
            // 
            // GuideRateDEC
            // 
            this.GuideRateDEC.BackColor = System.Drawing.Color.Black;
            this.GuideRateDEC.DecimalPlaces = 2;
            this.GuideRateDEC.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.GuideRateDEC.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.GuideRateDEC.Location = new System.Drawing.Point(136, 92);
            this.GuideRateDEC.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.GuideRateDEC.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.GuideRateDEC.Name = "GuideRateDEC";
            this.GuideRateDEC.Size = new System.Drawing.Size(64, 20);
            this.GuideRateDEC.TabIndex = 46;
            this.GuideRateDEC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.GuideRateDEC.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Gold;
            this.label11.Location = new System.Drawing.Point(30, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(0, 16);
            this.label11.TabIndex = 38;
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnConnectSetup
            // 
            this.btnConnectSetup.BackColor = System.Drawing.Color.Black;
            this.btnConnectSetup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnectSetup.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnConnectSetup.Location = new System.Drawing.Point(107, 12);
            this.btnConnectSetup.Name = "btnConnectSetup";
            this.btnConnectSetup.Size = new System.Drawing.Size(64, 23);
            this.btnConnectSetup.TabIndex = 37;
            this.btnConnectSetup.Text = "connect";
            this.btnConnectSetup.UseVisualStyleBackColor = false;
            this.btnConnectSetup.Click += new System.EventHandler(this.connect_mount);
            // 
            // elevate
            // 
            this.elevate.AutoSize = true;
            this.elevate.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.elevate.Location = new System.Drawing.Point(18, 177);
            this.elevate.Name = "elevate";
            this.elevate.Size = new System.Drawing.Size(50, 13);
            this.elevate.TabIndex = 36;
            this.elevate.Text = "elevation";
            // 
            // ElevationIP
            // 
            this.ElevationIP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ElevationIP.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ElevationIP.Location = new System.Drawing.Point(71, 174);
            this.ElevationIP.Name = "ElevationIP";
            this.ElevationIP.Size = new System.Drawing.Size(64, 20);
            this.ElevationIP.TabIndex = 35;
            this.ElevationIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 341);
            this.Controls.Add(this.Application);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(305, 380);
            this.MinimumSize = new System.Drawing.Size(305, 340);
            this.Name = "ControlForm";
            this.Text = "Warp Utility v.5.1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GuideRateRA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.JogValIP)).EndInit();
            this.Application.ResumeLayout(false);
            this.Control.ResumeLayout(false);
            this.Control.PerformLayout();
            this.PA.ResumeLayout(false);
            this.PA.PerformLayout();
            this.environ.ResumeLayout(false);
            this.environ.PerformLayout();
            this.graphs.ResumeLayout(false);
            this.graphs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.setup.ResumeLayout(false);
            this.setup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GuideRateDEC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnChooser;
        private System.Windows.Forms.Button btnPark;
        private System.Windows.Forms.Button btnUnpark;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnInitialize;
        private System.Windows.Forms.TextBox AltText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox AzText;
        private System.Windows.Forms.Button btnAbort;
        private System.Windows.Forms.Button btnNorth;
        private System.Windows.Forms.Button btnSouth;
        private System.Windows.Forms.Button btnWest;
        private System.Windows.Forms.Button btnEast;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox RAText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox DECText;
        private System.Windows.Forms.TextBox statusbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer statustimer;
        private System.Windows.Forms.NumericUpDown GuideRateRA;
        private System.Windows.Forms.NumericUpDown JogValIP;
        private System.Windows.Forms.Button btnTrackOn;
        private System.Windows.Forms.Button btnTrackOff;
        private System.Windows.Forms.TextBox LatitudeIP;
        private System.Windows.Forms.TextBox LongitudeIP;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabControl Application;
        private System.Windows.Forms.TabPage Control;
        private System.Windows.Forms.TabPage setup;
        private System.Windows.Forms.Label elevate;
        private System.Windows.Forms.TextBox ElevationIP;
        private System.Windows.Forms.Button btnConnectDup;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnConnectSetup;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabPage environ;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox temptext;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox skyqtext;
        private System.Windows.Forms.Label cloud;
        private System.Windows.Forms.TextBox cloudtext;
        private System.Windows.Forms.Label dew;
        private System.Windows.Forms.TextBox dewpointtext;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox humidtext;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox pressuretext;
        private System.Windows.Forms.Button btnDiscWeather;
        private System.Windows.Forms.Button btnConnectWeather;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox skytemptext;
        private System.Windows.Forms.Label rain;
        private System.Windows.Forms.TextBox rainratetext;
        private System.Windows.Forms.TabPage PA;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button minus3;
        private System.Windows.Forms.Button plus3;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox DEC2Text;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox RA2text;
        private System.Windows.Forms.TabPage graphs;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox btngraphsel;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.NumericUpDown GuideRateDEC;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox slewrate;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox PAstatus;
        private System.Windows.Forms.Button IndPark;
        private System.Windows.Forms.Button IndHome;
        private System.Windows.Forms.Button IndTrack;
        private System.Windows.Forms.Button IndSlew;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button resetbtn;
        private System.Windows.Forms.Button btnWeathChoose;
        private System.Windows.Forms.Button dupbtnDisconnect;
    }
}

