using ASCOM.DeviceInterface;
using ASCOM.Utilities;
using ASCOM.DriverAccess;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Linq;

// simple windows form-based control panel for telescope mount
// can be used as template for more customized version
// uses ASCOM commands
// V1.0 - for Synscan system (no home or park through ASCOM)
// V2.0- adapted and made more general purpose for Paramount by checking to see
// V2.1 - mount has to be unparked before you can home it
// if the mount supports certain ASCOM commands
// V2.3 - finessed guide rate commands
// V3.0 - added observing conditions
// V3.1 - updated visuals on observing conditions
// V3.2 - fixed text colors
// v3.4 - added PM controls
// v3.5 - trying to get PM controls to work
// v3.6 - moving to DEC90 was problem with RA accuracy, now 85
// v4.0 - graph of environment data
// v4.3 - updated graph direction and added offset offset for sky temp

namespace MountControl
{
    public partial class ControlForm : Form
    {
        private bool mountconnected, weatherconnected;
        private Telescope mount;
        private ObservingConditions weather; // ASCOM weather
        private string mountId, weatherId;
        private double jogvalue = 1; // minutes of arc
        private double ra, dec, az, alt, PMstart, PMRA, ra_rate, dec_rate;
        private double longitude = 0.6162;  // default value for SWF
        private double latitude = 51.6387;   // default value for SWF
        private double elevation = 10.0;   // default value for SWF
        private double sidereal = 0.00416666666666667;   // sidereal rate deg/sec
        private double jogRA, jogDEC;  // jog values  RA is in hours, DEC is in degrees
        String path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ASCOM\\Mount";  // path for Settings.txt file
        // arrays to hold last three hours of data for charting
        private double[] chartvalues = new double[120];
        private double[] cloudvalues = new double[120];
        private double[] tempvalues = new double[120];
        private double[] humidvalues = new double[120];
        private double[] dewvalues = new double[120];
        private double[] skyvalues = new double[120];
        private double[] sqmvalues = new double[120];
        private double[] pressvalues = new double[120];
        private double[] rainvalues = new double[120];
        private int samplecount = 0;  // sampling value increments every 2 seconds
        private int charttype = 0;  //selection variable
        private string command; // holds string to set up meter

        public ControlForm()
        {
            InitializeComponent();
            mountId = null;
            weatherId = null;
            // initialise data and status fields
            statusbox.Text = "not connected";
            // read in, if it exists, the  settings file           
            if (File.Exists(path + "\\Settings.txt")) fileread();
            JogValIP.Text = jogvalue.ToString();
            mountconnected = false;
            weatherconnected = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // set up colors on form
            btnDisconnect.ForeColor = Color.Gray;
            btnDiscWeather.ForeColor = Color.Gray;
            btnHome.ForeColor = Color.Gray;
            btnHome2.ForeColor = Color.Gray;
            btnAbort.ForeColor = Color.Gray;
            btnPark.ForeColor = Color.Gray;
            btnUnpark.ForeColor = Color.Gray;
            btnTrackOn.ForeColor = Color.Gray;
            btnTrackOff.ForeColor = Color.Gray;
            btnUnpark.ForeColor = Color.Gray;
            btnNorth.ForeColor = Color.Gray;
            btnEast.ForeColor = Color.Gray;
            btnWest.ForeColor = Color.Gray;
            btnSouth.ForeColor = Color.Gray;
            btnInitialize.ForeColor = Color.Gray;
            btnAbort.BackColor = Color.DarkOrange;
            resetbtn.ForeColor = Color.Gray;
            if (mountId != null)
            {
                btnConnectSetup.ForeColor = Color.LightGray;
                btnConnectDup.ForeColor = Color.LightGray;
            }
            else
            {
                btnConnectSetup.ForeColor = Color.Gray;
                btnConnectDup.ForeColor = Color.Gray;
            }
            if (weatherId != null)
            {
                btnConnectWeather.ForeColor = Color.LightGray;
                btnConnWeather.ForeColor = Color.LightGray;
                //set up chart
                // need to move y-axis setting dependendent on series
                chart1.Series.Clear(); //remove default series
                chart1.Series.Add("Cloud"); //add series called Cloud
                chart1.Series.FindByName("Cloud").ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line; //Change chart type to line
                chart1.Series.FindByName("Cloud").Color = Color.Red; //Change series color to red
                chart1.Series["Cloud"].BorderWidth = 2;
                chart1.ChartAreas[0].AxisX.Minimum = 0;
                chart1.ChartAreas[0].AxisX.Maximum = 120; //(2 hours) - y-axis determined by source
            }
            else
            {
                btnConnectWeather.ForeColor = Color.Gray;
                btnConnWeather.ForeColor = Color.Gray;
            }
        }
        private void choose_mount(object sender, EventArgs e)
        {
            try
            {
                mountId = Telescope.Choose(mountId);
                this.filewrite();
                if (mountId != null)
                {
                    btnConnectSetup.ForeColor = Color.LightGray;
                    btnConnectDup.ForeColor = Color.LightGray;
                }
                else
                {
                    btnConnectSetup.ForeColor = Color.Gray;
                    btnConnectDup.ForeColor = Color.Gray;
                }
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("mount selection failed");
            }
        }

        private void choose_weather(object sender, EventArgs e)
        {
            try
            {
                weatherId = ObservingConditions.Choose(weatherId);
                this.filewrite();
                if (weatherId != null)
                {
                    btnConnWeather.ForeColor = Color.LightGray;
                }
                else
                {
                    btnConnWeather.ForeColor = Color.Gray;
                }

            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("weather selection failed");
            }
        }

        private void connect_mount(object sender, EventArgs e)
        {
            try
            {
                if (mountId != null)
                {
                    mount = new Telescope(mountId);
                    mount.Connected = true;
                    mountconnected = true;
                    statusbox.Text = "connected";
                    btnConnectSetup.BackColor = Color.DarkGreen;
                    btnConnectSetup.ForeColor = Color.LightGray;
                    btnConnectDup.BackColor = Color.DarkGreen;
                    btnConnectDup.ForeColor = Color.LightGray;
                    btnDisconnect.BackColor = Color.DarkRed;
                    btnDisconnect.ForeColor = Color.LightGray;
                    btnHome.ForeColor = Color.LightGray;
                    btnHome2.ForeColor = Color.LightGray;
                    btnAbort.ForeColor = Color.Black;
                    btnPark.ForeColor = Color.LightGray;
                    btnUnpark.ForeColor = Color.LightGray;
                    btnTrackOn.ForeColor = Color.LightGray;
                    btnTrackOff.ForeColor = Color.LightGray;
                    btnUnpark.ForeColor = Color.LightGray;
                    btnNorth.ForeColor = Color.LightGray;
                    btnEast.ForeColor = Color.LightGray;
                    btnWest.ForeColor = Color.LightGray;
                    btnSouth.ForeColor = Color.LightGray;
                    btnInitialize.ForeColor = Color.LightGray;
                    if (mount.Tracking == true)
                    {
                        btnTrackOn.ForeColor = Color.Gray;
                        btnTrackOff.ForeColor = Color.LightGray;
                    }
                    else
                    {
                        btnTrackOn.ForeColor = Color.LightGray;
                        btnTrackOff.ForeColor = Color.Gray;
                    }
                    btnInitialize.ForeColor = Color.Gray;
                    // update text boxes with values from mount
                    GuideRateIP.Value = (decimal)Math.Round(mount.GuideRateDeclination / sidereal, 2);
                    LongitudeIP.Text = Math.Round(mount.SiteLongitude,2).ToString();
                    LatitudeIP.Text = Math.Round(mount.SiteLatitude,2).ToString();
                    if (mountId == "ASCOM.HUBOI.Telescope")  // not implemented in Rainbow
                        ElevationIP.Text = "?";
                    else ElevationIP.Text = Math.Round(mount.SiteElevation,2).ToString();
                }
                else
                {
                    mountconnected = false;
                    statusbox.Text = "not connected";
                }
            }
            catch (ASCOM.ActionNotImplementedException)
            {
                System.Windows.Forms.MessageBox.Show("Not supported");
            }
            catch (ASCOM.NotConnectedException)
            {
                System.Windows.Forms.MessageBox.Show("Connection error");
            }
        }
        // update jog values
        private void jog(object sender, EventArgs e)
        {
            try
            {
                jogvalue = Convert.ToDouble(JogValIP.Value);
                jogDEC = jogvalue / 60.0;  // degrees
                jogRA = jogvalue / 900.0;   // hours;
            }
            catch
            {
                statusbox.Text = "comms error";
            }
        }
        private void disconnect_mount(object sender, EventArgs e)
        {
            try
            {
                if (mountconnected)
                {
                    mount.Connected = false;  // disconnect mount
                    mountconnected = false;
                    statusbox.Text = "not connected";
                    btnHome.ForeColor = Color.Gray;
                    btnHome2.ForeColor = Color.Gray;
                    btnAbort.ForeColor = Color.Gray;
                    btnPark.ForeColor = Color.Gray;
                    btnUnpark.ForeColor = Color.Gray;
                    btnTrackOn.ForeColor = Color.Gray;
                    btnTrackOff.ForeColor = Color.Gray;
                    btnUnpark.ForeColor = Color.Gray;
                    btnNorth.ForeColor = Color.Gray;
                    btnEast.ForeColor = Color.Gray;
                    btnWest.ForeColor = Color.Gray;
                    btnSouth.ForeColor = Color.Gray;
                    btnInitialize.ForeColor = Color.Gray;
                    btnAbort.BackColor = Color.DarkOrange;
                    btnConnectSetup.ForeColor = Color.LightGray;
                    btnConnectSetup.BackColor = Color.Black;
                    btnConnectDup.ForeColor = Color.LightGray;
                    btnConnectDup.BackColor = Color.Black;
                    btnDisconnect.ForeColor = Color.Gray;
                    btnDisconnect.BackColor = Color.Black;
                }
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Mount did not disconnect");
            }
        }

        // setup allows one to override settings from mount
        private void init_mount(object sender, EventArgs e)
        {
            try
            {
                if (mount.Connected)
                {
                    double guiderate;
                    if(mountId=="ASCOM.HUBOI.Telescope")
                    {
                        System.Windows.Forms.MessageBox.Show("mount does not support UTC update");
                        System.Windows.Forms.MessageBox.Show("mount does not support elevation update");
                        //mount.CommandString(":SL10:00:00#", true);  //test
                    }
                    else
                    {
                        mount.UTCDate = (System.DateTime.UtcNow);
                        System.Windows.Forms.MessageBox.Show("UTC time set");
                        mount.SiteElevation = Convert.ToDouble(ElevationIP.Text);
                        System.Windows.Forms.MessageBox.Show("elevation set");
                    }
                    guiderate = sidereal * (double)(GuideRateIP.Value) ;  // calculate guide rate

                    if (mount.CanSetGuideRates) mount.GuideRateDeclination = guiderate;
                    else System.Windows.Forms.MessageBox.Show("mount does not support guide rate");

                    guiderate = Math.Round(mount.GuideRateDeclination / sidereal, 3); // read back to confirm
                    System.Windows.Forms.MessageBox.Show("guide rate confirmed " + guiderate.ToString() + "x");
                    mount.SiteLongitude = Convert.ToDouble(LongitudeIP.Text);
                    mount.SiteLatitude = Convert.ToDouble(LatitudeIP.Text);
                    System.Windows.Forms.MessageBox.Show("location updated");
                    filewrite();
                }
                else statusbox.Text = "not required";
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("communication failure");
            }
        }
        private void park_mount(object sender, EventArgs e)
        {
            try
            {
                if (mount.CanPark && mountconnected)
                {
                    if (!mount.AtPark)
                    {
                        statusbox.Text = "parking";
                        mount.Park();
                    }
                    else statusbox.Text = "parked";
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("mount does not support Park");
                }
            }
            catch
            {
                statusbox.Text = "comms error";
            }
        }
        private void home_mount(object sender, EventArgs e)
        {
            try
            {
                if (mountconnected && mount.CanFindHome)
                {
                    if (!mount.AtHome)
                    {
                        statusbox.Text = "homing";
                        if (mount.AtPark) mount.Unpark();
                        mount.Tracking = false;
                        mount.FindHome();
                    }
                    else statusbox.Text = "parked?";
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("mount does not support home");
                }
            }
            catch
            {
                statusbox.Text = "comms error";
            }
        }
        private void track_on(object sender, EventArgs e)
        {
            try
            {
                if (mountconnected && mount.CanSetTracking)
                {
                    if (!mount.Tracking)
                    {
                        statusbox.Text = "tracking";
                        if (mount.AtPark) mount.Unpark();  // in the case that it is parked
                        mount.Tracking = true;
                        btnTrackOn.ForeColor = Color.Gray;
                        btnTrackOff.ForeColor = Color.LightGray;
                        btnTrackOn.BackColor = Color.DarkGreen;
                        btnTrackOn.ForeColor = Color.Black;
                    }
                }
            }
            catch
            {
                statusbox.Text = "comms error";
            }
        }
        private void track_off(object sender, EventArgs e)
        {
            try
            {
                if (mountconnected)
                {
                    if (mount.Tracking && mount.CanSetTracking)
                    {
                        statusbox.Text = "stopping";
                        mount.Tracking = false;
                        btnTrackOn.ForeColor = Color.LightGray;
                        btnTrackOff.ForeColor = Color.Gray;
                        btnTrackOn.BackColor = Color.Black;
                        btnTrackOn.ForeColor = Color.LightGray;
                    }
                    else statusbox.Text = "not tracking or parked";
                }
            }
            catch
            {
                statusbox.Text = "comms error";
            }
        }
        private void unpark(object sender, EventArgs e)
        {
            try
            {
                if (mountconnected && mount.CanPark)
                {
                    if (mount.AtPark)
                    {
                        mount.Unpark();
                        statusbox.Text = "Unparked";
                        btnPark.ForeColor = Color.LightGray;
                        btnUnpark.ForeColor = Color.Gray;
                        btnPark.BackColor = Color.Black;
                    }
                    else System.Windows.Forms.MessageBox.Show("mount not parked!");
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("mount does not support unpark");
                }
            }
            catch
            {
                statusbox.Text = "comms error";
            }
        }
        private void abort_mount(object sender, EventArgs e)
        {
            try
            {
                if (mountconnected)
                {
                    if (mount.Slewing) mount.AbortSlew();
                }
            }
            catch
            {
                statusbox.Text = "comms error";
            }
        }
        private void connect_weather(object sender, EventArgs e)
        {
            try
            {
                if (weatherId != null)
                {
                    weather = new ObservingConditions(weatherId);
                    weather.Connected = true;
                    weatherconnected = true;
                    humidtext.Text = "connected";
                    pressuretext.Text = "connected";
                    temptext.Text = "connected";
                    skytemptext.Text = "connected";
                    skyqtext.Text = "connected";
                    rainratetext.Text = "connected";
                    cloudtext.Text = "connected";
                    dewpointtext.Text = "connected";
                    btnConnectWeather.BackColor = Color.DarkGreen;
                    btnConnectWeather.ForeColor = Color.LightGray;
                    btnConnWeather.ForeColor = Color.LightGray;
                    btnConnWeather.BackColor = Color.DarkGreen;
                    btnDiscWeather.ForeColor = Color.LightGray;
                    btnDiscWeather.BackColor = Color.DarkRed;
                    humidtext.ForeColor = Color.LightGreen;
                    pressuretext.ForeColor = Color.LightGreen;
                    temptext.ForeColor = Color.LightGreen;
                    dewpointtext.ForeColor = Color.LightGreen;
                    skyqtext.ForeColor = Color.LightGreen;
                    skytemptext.ForeColor = Color.LightGreen;
                    cloudtext.ForeColor = Color.LightGreen;
                    rainratetext.ForeColor = Color.LightGreen;
                    resetbtn.BackColor = Color.OrangeRed;
                    resetbtn.ForeColor = Color.LightGray;
                    // default chart is SQM
                    charttype = 5;
                    btngraphsel.Text = "SQM";
                    chart1.ChartAreas[0].AxisY.Minimum = 5;
                    chart1.ChartAreas[0].AxisY.Maximum = 20;
                    refreshweather();
                }
                else
                {
                    weatherconnected = false;
                    humidtext.Text = "not connected";
                    pressuretext.Text = "not connected";
                    temptext.Text = "not connected";
                    cloudtext.Text = "not connected";
                    rainratetext.Text = "not connected";
                    skyqtext.Text = "not connected";
                    skytemptext.Text = "not connected";
                    dewpointtext.Text = "not connected";
                }
            }
            catch (Exception)
            {
                weather.Connected = false;
                weatherconnected = false;
                System.Windows.Forms.MessageBox.Show("Weather did not connect");
            }
        }
        private void refreshmount()
        {
            try
            {
                if (!mount.Slewing)
                {
                    ra = mount.RightAscension;
                    dec = mount.Declination;
                    alt = mount.Altitude;
                    az = mount.Azimuth;
                    ra_rate = mount.RightAscensionRate;
                    dec_rate = mount.DeclinationRate;
                    DECText.Text = Math.Round(dec, 2).ToString();
                    DEC2Text.Text = Math.Round(dec, 2).ToString();
                    RAText.Text = Math.Round(ra, 2).ToString();
                    RA2text.Text = Math.Round(ra, 2).ToString();
                    AltText.Text = Math.Round(alt, 2).ToString();
                    AzText.Text = Math.Round(az, 2).ToString();
                }
                if (mount.AtHome)
                {
                    statusbox.Text = "Homed";
                    btnHome.BackColor = Color.DarkGreen;
                    btnHome2.BackColor = Color.DarkGreen;
                    btnPark.ForeColor = Color.LightGray;
                    btnPark.BackColor = Color.Black;
                }
                else if (mount.AtPark)
                {
                    statusbox.Text = "Parked";
                    btnPark.BackColor = Color.DarkGreen;
                    btnPark.ForeColor = Color.Black;
                    btnUnpark.ForeColor = Color.LightGray;
                    btnTrackOn.ForeColor = Color.Gray;
                    btnTrackOn.BackColor = Color.Black;
                    btnHome.BackColor = Color.Black;
                    btnHome2.BackColor = Color.Black;
                }
                else if (mount.Slewing)
                {
                    statusbox.Text = "Slewing";
                    btnHome.BackColor = Color.Black;
                    btnHome2.BackColor = Color.Black;
                }

                else if (mount.Tracking)
                {
                    statusbox.Text = "Tracking";
                    btnTrackOn.ForeColor = Color.Black;
                    btnTrackOn.BackColor = Color.DarkGreen;
                    btnHome.BackColor = Color.Black;
                    btnHome2.BackColor = Color.Black;
                }
                else
                {
                    statusbox.Text = "Not Tracking";
                    btnUnpark.ForeColor = Color.LightGray;
                    btnTrackOn.ForeColor = Color.LightGray;
                    btnTrackOn.BackColor = Color.Black;
                }
            }
            catch
            {
                statusbox.Text = "comms error";
            }
        }
        // Polemaster moves to home and counterclockwise to select Polaris and another star
        private void PMStart(object sender, EventArgs e)
        {
            try
            {
                double RA;
                if (mount.Connected)                  
                {
                    if (mount.AtPark) mount.Unpark();
                    if (!mount.Slewing)
                    {
                        RA = mount.RightAscension;  
                        if (mount.SiteLatitude >= 0) // test for hemisphere
                        {
                            mount.SlewToCoordinates(RA, 85.0); // move off dec 90
                            if (RA >= 21.0) RA -= 24.0;
                            RA += 3.0; 
                            System.Windows.Forms.MessageBox.Show("slewing to RA " + Math.Round(RA, 2).ToString()+ " DEC 85");        
                            mount.SlewToCoordinates(RA, 85.0);
                            btnHome.BackColor = Color.Black;
                            btnHome2.BackColor = Color.Black;
                        }
                        else
                        {
                            mount.SlewToCoordinates(RA, -85.0); // move off dec 90
                            if (RA >= 21.0) RA -= 24.0;
                            RA += 3.0; 
                            System.Windows.Forms.MessageBox.Show("slewing to RA " + Math.Round(RA, 2).ToString() + " DEC 85");
                            mount.SlewToCoordinates(RA, -85.0);
                            btnHome.BackColor = Color.Black;
                            btnHome2.BackColor = Color.Black;
                        }
                        PMstart = RA;
                        PMRA = RA;
                    }
                }
                else System.Windows.Forms.MessageBox.Show("Mount not connected");
            }
            catch (Exception)
            {
                statusbox.AppendText(Environment.NewLine + "slew error");
            }
        }
        // polemaster 45 degree slew clockwise
        private void Plus3Ra(object sender, EventArgs e)
        {
            try
            {
                double RA,DEC;
                if (mountconnected && !mount.Slewing)
                {
                    RA = PMRA;
                    DEC = mount.Declination;
                    if (RA < 3.0) RA += 24.0;
                    RA -= 3.0;
                    PMRA = RA;
                    System.Windows.Forms.MessageBox.Show("slewing to RA " + Math.Round(RA, 2).ToString());
                    mount.SlewToCoordinates(RA, DEC);
                    btnHome.BackColor = Color.Black;
                    btnHome2.BackColor = Color.Black;
                }
            }
            catch (Exception)
            {
                statusbox.AppendText(Environment.NewLine + "slew error");
            }
        }
        private void resetsensor(object sender, EventArgs e)
        {
            // reset chart
            ReadProfile(); // get weather ascom profile for values
            samplecount = 0;          
            for (int i = 0; i < 120; i++) chartvalues[i] = 0;
            chart1.Series[0].Points.DataBindY(chartvalues);
            if (weather.Connected && weatherId == "ASCOM.NanoOC.ObservingConditions")
            {
                weather.CommandBlind(command, false);
                resetbtn.BackColor = Color.LightGreen;
            }
        }
        private void refreshweather()
        {
            try
            {
                if (weatherconnected)
                {
                    pressuretext.Text = Math.Round(weather.Pressure, 2).ToString() + " hPa";
                    temptext.Text = Math.Round(weather.Temperature, 2).ToString() + " °C";
                    humidtext.Text = Math.Round(weather.Humidity, 2).ToString() + " %";
                    dewpointtext.Text = Math.Round(weather.DewPoint, 2).ToString() + " °C";
                    cloudtext.Text = Math.Round(weather.CloudCover, 2).ToString() + " %";
                    skyqtext.Text = Math.Round(weather.SkyQuality, 2).ToString() + " ";
                    skytemptext.Text = Math.Round(weather.SkyTemperature, 2).ToString() + " °C";
                    rainratetext.Text = Math.Round(weather.RainRate, 2).ToString() + "mm/h";
                    // conditional text color to indicate problems
                    if (weather.RainRate > 0.2) rainratetext.ForeColor = Color.Red;
                    else rainratetext.ForeColor = Color.LightGreen;
                    if (weather.CloudCover > 60) cloudtext.ForeColor = Color.Red;
                    else if (weather.CloudCover > 30) cloudtext.ForeColor = Color.Yellow;
                    else cloudtext.ForeColor = Color.LightGreen;
                    if (weather.Humidity > 96) humidtext.ForeColor = Color.Red;
                    else humidtext.ForeColor = Color.LightGreen;
                    resetbtn.BackColor = Color.Black;
                    ChartDataUpdate();
                    ChartUpdate();
                }
            }
            catch (Exception)
            {
                statusbox.AppendText(Environment.NewLine + "weather error");
            }
        }
        // routine to change over the graph data source and axis and update
        private void graphselect(object sender, EventArgs e)
        {
            if ((string)btngraphsel.SelectedItem == "temp C")
            {
                charttype = 0;
                chart1.ChartAreas[0].AxisY.Minimum = -10;
                chart1.ChartAreas[0].AxisY.Maximum = +30;
            }
            if ((string)btngraphsel.SelectedItem == "humidity %")
            {
                charttype = 1;
                chart1.ChartAreas[0].AxisY.Minimum = 0;
                chart1.ChartAreas[0].AxisY.Maximum = 100;
            }
            if ((string)btngraphsel.SelectedItem == "dewpoint C")
            {
                charttype = 2;
                chart1.ChartAreas[0].AxisY.Minimum = -10;
                chart1.ChartAreas[0].AxisY.Maximum = +20;
            }
            if ((string)btngraphsel.SelectedItem == "sky temp C")
            {
                charttype = 3;
                chart1.ChartAreas[0].AxisY.Minimum = -20;
                chart1.ChartAreas[0].AxisY.Maximum = +20;
            }
            if ((string)btngraphsel.SelectedItem == "cloud cover %")
            {
                charttype = 4;
                chart1.ChartAreas[0].AxisY.Minimum = 0;
                chart1.ChartAreas[0].AxisY.Maximum = 100;
            }
            if ((string)btngraphsel.SelectedItem == "SQM")
            {
                charttype = 5;
                chart1.ChartAreas[0].AxisY.Minimum = 6;
                chart1.ChartAreas[0].AxisY.Maximum = 21;
            }
            if ((string)btngraphsel.SelectedItem == "pressure hPa")
            {
                charttype = 6;
                chart1.ChartAreas[0].AxisY.Minimum = 940;
                chart1.ChartAreas[0].AxisY.Maximum = 1040;
            }
            if ((string)btngraphsel.SelectedItem == "rain rate mm/h")
            {
                charttype = 7;
                chart1.ChartAreas[0].AxisY.Minimum = 0;
                chart1.ChartAreas[0].AxisY.Maximum = 5;
            }
            // update chart values
            ChartDataUpdate(); // update latest values and transpose
            // either copy non zero over, or use all values
            if (samplecount < 3600) //(every minute)
            {
                var arrayNZ = chartvalues.Select(x => x).Where(x => x != 0).ToArray(); // only do non-zero values at the beginning
                chart1.Series[0].Points.DataBindY(arrayNZ);
            }
            else chart1.Series[0].Points.DataBindY(chartvalues);
        }
        // ChartData updates 8 arrays of weather data, covering last 3 hours and 
        // copies one set over to the chart array, for display, accoriding to charttype
        private void ChartDataUpdate()
        {
            int index;
            samplecount += 1;
            if ((samplecount < 3600) && (samplecount % 30 == 0)) //(every minute)
            {
                index = ((int)((samplecount / 30.0) - (samplecount % 30)));
                tempvalues[index] = weather.Temperature;
                humidvalues[index] = weather.Humidity;
                dewvalues[index] = weather.DewPoint;
                cloudvalues[index] = weather.CloudCover;
                if (weather.SkyQuality > 21) sqmvalues[index] = 21; // limit or it does not get shown
                else if (weather.SkyQuality < 6) sqmvalues[index] = 6;
                else sqmvalues[index] = weather.SkyQuality;
                pressvalues[index] = weather.Pressure;
                if (weather.SkyTemperature > 20) skyvalues[index] = 20; // limit or it does not get shown
                else if (weather.SkyTemperature <-20) skyvalues[index] = -20; //limit or it does not get shown
                else skyvalues[index] = weather.SkyTemperature;
                if (weather.RainRate > 5) rainvalues[index] = 5;
                else if (weather.RainRate == 0) rainvalues[index] = 0.01;
                else rainvalues[index] = weather.RainRate; //limit or it does not get shown

            }
            if ((samplecount >= 3600) && (samplecount % 30 == 0))
            {
                for (int i = 0; i <119; i++)  // shift left
                {
                    tempvalues[i] = tempvalues[i + 1];
                    humidvalues[i] = humidvalues[i + 1];
                    dewvalues[i] = dewvalues[i + 1];
                    cloudvalues[i] = cloudvalues[i + 1];
                    sqmvalues[i] = sqmvalues[i + 1];
                    pressvalues[i] = pressvalues[i + 1];
                    skyvalues[i] = skyvalues[i + 1];
                    rainvalues[i] = rainvalues[i + 1];
                }
                // rhs value is current value
                tempvalues[119] = weather.Temperature;
                humidvalues[119] = weather.Humidity;
                dewvalues[119] = weather.DewPoint;
                cloudvalues[119] = weather.CloudCover;
                sqmvalues[119] = weather.SkyQuality;
                pressvalues[119] = weather.Pressure;
                skyvalues[119] = weather.SkyTemperature;
                rainvalues[119] = weather.RainRate;
            }
            switch(charttype) // copy applicable data into chart array
            {
                case 0:
                    for (int i = 0; i < 120; i++) chartvalues[i] = tempvalues[i];
                    break;
                case 1:
                    for (int i = 0; i < 120; i++) chartvalues[i] = humidvalues[i];
                    break;
                case 2:
                    for (int i = 0; i < 120; i++) chartvalues[i] = dewvalues[i];
                    break;
                case 3:
                    for (int i = 0; i < 120; i++) chartvalues[i] = skyvalues[i];
                    break;
                case 4:
                    for (int i = 0; i < 120; i++) chartvalues[i] = cloudvalues[i];
                    break;
                case 5:
                    for (int i = 0; i < 120; i++) chartvalues[i] = sqmvalues[i];
                    break;
                case 6:
                    for (int i = 0; i < 120; i++) chartvalues[i] = pressvalues[i];
                    break;             
                default:
                    for (int i = 0; i < 120; i++) chartvalues[i] = rainvalues[i];
                    break;
            }
        }
        // updates chart plot, according to the selected data source, does not display zero values.
        private void ChartUpdate()
        {
            if ((samplecount < 3600) && (samplecount % 30 == 0)) //(every minute)
            {
                var arrayNZ = chartvalues.Select(x => x).Where(x => x != 0).ToArray(); // only do non-zero values at the beginning
                chart1.Series[0].Points.DataBindY(arrayNZ);
            }
            if ((samplecount >= 3600) && (samplecount % 30 == 0)) chart1.Series[0].Points.DataBindY(chartvalues);
        }

        // routine to return mount back to polemaster starting point
        private void ReturnMount(object sender, EventArgs e)
        {
            try
            {
                double RA,DEC;
                if (mountconnected && !mount.Slewing)
                {
                    RA = PMstart;  // go back to start position, even if intermediate steps were skipped
                    if (RA >= 24.0) RA -= 24.0;
                    if (RA < 0.0) RA += 24;  // just to be sure
                    DEC = mount.Declination;
                    System.Windows.Forms.MessageBox.Show("slewing to RA " + Math.Round(RA, 2).ToString() );
                    mount.SlewToCoordinates(RA, DEC);
                    btnHome.BackColor = Color.Black;
                    btnHome2.BackColor = Color.Black;
                }
            }
            catch (Exception)
            {
                statusbox.AppendText(Environment.NewLine + "slew error");
            }
        }

        private void disconnect_weather(object sender, EventArgs e)
        {
            try
            {
                if (weatherconnected)
                {
                    weather.Connected = false;   //disconnect weather sensors
                    weatherconnected = false;
                    humidtext.Text = "not connected";
                    pressuretext.Text = "not connected";
                    temptext.Text = "not connected";
                    dewpointtext.Text = "not connected";
                    cloudtext.Text = "not connected";
                    skyqtext.Text = "not connected";
                    skytemptext.Text = "not connected";
                    rainratetext.Text = "not connected";
                    btnWeathChoose.ForeColor = Color.LightGray;
                    btnWeathChoose.BackColor = Color.Black;
                    btnConnectWeather.ForeColor = Color.LightGray;
                    btnConnectWeather.BackColor = Color.Black;
                    btnConnWeather.ForeColor = Color.LightGray;
                    btnConnWeather.BackColor = Color.Black;
                    btnDiscWeather.ForeColor = Color.Gray;
                    btnDiscWeather.BackColor = Color.Black;
                }
            }
            catch (Exception)
            {
                statusbox.AppendText(Environment.NewLine + "disconnect weather error");
            }
        }
        private void west(object sender, EventArgs e)
        {
            try
            {
                ra += jogRA;
                if (ra > 24) ra -= 24;  //manage wrap around
                if (ra < 0) ra += 24;
                mount.SlewToCoordinatesAsync(ra, dec);
            }
            catch
            {
                statusbox.Text = "comms error";
            }
        }
        private void east(object sender, EventArgs e)
        {
            try
            {
                ra -= jogRA;
                if (ra > 24) ra -=  24;  //manage wrap around
                if (ra < 0) ra +=  24;
                mount.SlewToCoordinatesAsync(ra, dec);
            }
            catch
            {
                statusbox.Text = "comms error";
            }
        }
        private void south(object sender, EventArgs e)
        {
            try
            {
                dec -= jogDEC;
                if ((dec < 90) && (dec > -90)) mount.SlewToCoordinatesAsync(ra, dec); //limit to legal value
            }
            catch
            {
                statusbox.Text = "comms error";
            }
        }
        private void north(object sender, EventArgs e)
        {
            try
            {
                dec += jogDEC;
                if ((dec < 90) && (dec > -90)) mount.SlewToCoordinatesAsync(ra, dec); //limit to legal value
            }
            catch
            {
                statusbox.Text = "comms error";
            }
        }
        private void status_updates(object sender, EventArgs e) // every 2 seconds
        {
            try
            {
            if (mountconnected) refreshmount();
            if (weatherconnected) refreshweather();
            }
            catch
            {
                statusbox.Text = "comms error";
            }
        }
        // filewrite() saves configuration variables to MyDocuments/ASCOM/Mount/settings.txt
        private void filewrite()
        {
            try
            {
                string[] configure = new string[7];
                configure[0] = mountId;
                configure[1] = latitude.ToString();
                configure[2] = longitude.ToString();
                configure[3] = elevation.ToString(); 
                //configure[4] = rate.ToString();  not used at present
                configure[5] = jogvalue.ToString();
                configure[6] = weatherId;
                if (!System.IO.Directory.Exists(path)) System.IO.Directory.CreateDirectory(path);
                File.WriteAllLines(path + "\\Settings.txt", configure);
            }
            catch (System.UnauthorizedAccessException e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
        }
        // fileread() reads configuration variables from MyDocuments/ASCOM/LifeRoof/domesettings.txt
        private void fileread()
        {
            try
            {
                string[] configure = new string[7];
                configure = File.ReadAllLines(path + "\\Settings.txt");
                mountId = configure[0];
                latitude = Convert.ToDouble(configure[1]);
                longitude = Convert.ToDouble(configure[2]);
                elevation = Convert.ToDouble(configure[3]); 
                //rate = Convert.ToDouble(configure[4]); not used at present
                jogvalue = Convert.ToDouble(configure[5]);
                weatherId = configure[6];
            }
            catch (System.UnauthorizedAccessException e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
        }
        internal void ReadProfile()  // read trim values from ASCOM profile for programming into device
        {
            using (Profile driverProfile = new Profile())
            {
                string gain,offset,highT,SQMAdjust,RainRatioThreshold,SkyUL, SkyLL, humidtrim,temptrim,pressuretrim,buzzer;
                driverProfile.DeviceType = "ObservingConditions";
                gain = driverProfile.GetValue(weatherId, "gain", string.Empty, "33"); // gain
                offset = driverProfile.GetValue(weatherId, "offset", string.Empty, "0");  // offset
                highT = driverProfile.GetValue(weatherId, "highT", string.Empty, "4");  // high temp offset
                SQMAdjust = driverProfile.GetValue(weatherId, "SQMAdjust", string.Empty, "0");
                RainRatioThreshold = driverProfile.GetValue(weatherId, "RainRatioThreshold", string.Empty, "1.5");
                SkyUL = driverProfile.GetValue(weatherId, "SkyUL", string.Empty, "10");
                SkyLL = driverProfile.GetValue(weatherId, "SkyLL", string.Empty, "-10");
                humidtrim = driverProfile.GetValue(weatherId, "humid trim", string.Empty, "0");
                temptrim = driverProfile.GetValue(weatherId, "temp trim", string.Empty, "0");
                pressuretrim = driverProfile.GetValue(weatherId, "pressure trim", string.Empty, "0");
                if (driverProfile.GetValue(weatherId, "buzzer enabled", string.Empty, "true")=="true") buzzer = "buzz on"; else buzzer = "buzz off" ;
                command = SQMAdjust + ',' + humidtrim + ',' + pressuretrim + ',' + temptrim + ',' + gain + ',' + offset + ',' + highT + ',' + SkyUL + ',' + SkyLL + ',' + RainRatioThreshold + ',' + "reset" + ',' + buzzer;
            }
        }
    }
}
