//using ASCOM.Com;
using ASCOM.Com.DriverAccess;
using ASCOM.Utilities.Interfaces;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Linq;
using ASCOM.Common;


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
// v4.4 - added tracking on after polemaster actions, also trying out move axis alternative
// v4.5 - added some delays to homing and tracking to accommodate Onstep mounts.
// v4.7 - added double homing for Onstep mounts, in case it is trying to home over 90 degrees.
// v5.0 - small modifications and improvements to special case documentation- stable version
// v5.1 - mostly cosmetic changes to the tab and button layouts

namespace MountControl
{
    public partial class ControlForm : Form
    {
        private bool mountconnected, weatherconnected;
        private bool tempsense, hpasense, rhsense, cloudsense, sqsense, dewsense, rainsense, irsense;
        private Telescope mount;
        private ObservingConditions weather; // ASCOM weather
        private ASCOM.Utilities.Chooser mountchoice, weatherchoice;
        private string mountId, weatherId;
        private double jogvalue = 1; // minutes of arc
        private double ra, dec, az, alt;
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
        private bool mountcantrack, mountcanpark, mountcanhome;

        public ControlForm()
        {
            InitializeComponent();
            mountId = null;
            weatherId = null;
            rainsense = true;
            tempsense = true;
            dewsense = true;
            rhsense = true;
            cloudsense = true;
            hpasense = true;

            // initialise data and status fields
            statusbox.Text = " not connected";
            PAstatus.Text = " not connected";
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
            IndHome.ForeColor = Color.White;
            IndPark.ForeColor = Color.White;
            IndSlew.ForeColor = Color.White;
            IndTrack.ForeColor = Color.White;    
            IndHome.BackColor = Color.Black;
            IndPark.BackColor = Color.Black;
            IndSlew.BackColor= Color.Black;
            IndTrack.BackColor = Color.Black;

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
            }
        }
        private void choose_mount(object sender, EventArgs e)
        {
            try
            {
                mountchoice = new ASCOM.Utilities.Chooser();
                mountchoice.DeviceType = "Telescope";
                mountId = mountchoice.Choose(mountId);
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
                weatherchoice = new ASCOM.Utilities.Chooser(); 
                weatherchoice.DeviceType = "ObservingConditions";
                weatherId = weatherchoice.Choose(weatherId);
                this.filewrite();
                if (weatherId != null)
                {
                    btnConnectWeather.ForeColor = Color.LightGray;
                }
                else
                {
                    btnConnectWeather.ForeColor = Color.Gray;
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
                    mount.Connect();
                    //mount.Connected = true;
                    mountconnected = true;
                    statusbox.Text = " connected";
                    PAstatus.Text = " connected";
                    btnConnectSetup.BackColor = Color.DarkGreen;
                    btnConnectSetup.ForeColor = Color.LightGray;
                    btnConnectDup.BackColor = Color.DarkGreen;
                    btnConnectDup.ForeColor = Color.LightGray;
                    btnDisconnect.BackColor = Color.DarkRed;
                    btnDisconnect.ForeColor = Color.LightGray;
                    dupbtnDisconnect.BackColor = Color.DarkRed;
                    dupbtnDisconnect.ForeColor = Color.LightGray;
                    btnHome.ForeColor = Color.LightGray;
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
                    btnInitialize.ForeColor = Color.Gray;
                    // update text boxes with values from mount
                    GuideRateRA.Value = (decimal)Math.Round(mount.GuideRateDeclination / sidereal, 2);
                    GuideRateDEC.Value = (decimal)Math.Round(mount.GuideRateDeclination / sidereal, 2);
                    LongitudeIP.Text = Math.Round(mount.SiteLongitude,4).ToString();
                    LatitudeIP.Text = Math.Round(mount.SiteLatitude,4).ToString();
                    ElevationIP.Text = Math.Round(mount.SiteElevation,2).ToString();
                    mountcanhome = mount.CanFindHome;
                    mountcanpark = mount.CanPark;
                    mountcantrack = mount.CanSetTracking;
                    mount.UTCDate = (System.DateTime.UtcNow); // see if this works here
                }
                else
                {
                    statusbox.Text = " not connected";
                    PAstatus.Text = " not connected";
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
                statusbox.Text = " jog error";
            }
        }
        private void disconnect_mount(object sender, EventArgs e)
        {
            try
            {
                if (mountconnected)
                {
                    //mount.Connected = false;  // disconnect mount (synchronously)
                    mount.Disconnect();
                    mountconnected = false;
                    statusbox.Text = " not connected";
                    PAstatus.Text = " not connected";
                    btnHome.ForeColor = Color.Gray;
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
                    dupbtnDisconnect.BackColor = Color.Black;
                    dupbtnDisconnect.ForeColor = Color.Gray;
                    IndHome.ForeColor = Color.Gray;
                    IndPark.ForeColor = Color.Gray;
                    IndSlew.ForeColor = Color.Gray;
                    IndTrack.ForeColor = Color.Gray;
                    IndHome.BackColor = Color.Black;
                    IndPark.BackColor = Color.Black;
                    IndSlew.BackColor = Color.Black;
                    IndTrack.BackColor = Color.Black;
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
                    double guiderateRA, guiderateDEC;
                    mount.UTCDate = (System.DateTime.UtcNow);
                    mount.SiteElevation = Convert.ToDouble(ElevationIP.Text);
                    guiderateRA = sidereal * (double)(GuideRateRA.Value) ;  // calculate guide rate
                    guiderateDEC = sidereal* (double)(GuideRateDEC.Value) ;

                    if (mount.CanSetGuideRates)
                    {
                        mount.GuideRateDeclination = guiderateDEC;
                        mount.GuideRateRightAscension = guiderateRA;
                    }
                    else System.Windows.Forms.MessageBox.Show("mount does not support guide rate");

                    guiderateDEC = Math.Round(mount.GuideRateDeclination / sidereal, 3); // read back to confirm
                    guiderateRA = Math.Round(mount.GuideRateRightAscension / sidereal, 3);
                    mount.SiteLongitude = Convert.ToDouble(LongitudeIP.Text);
                    mount.SiteLatitude = Convert.ToDouble(LatitudeIP.Text);
                    // read back data and display
                    GuideRateRA.Value = (decimal)guiderateRA;
                    GuideRateDEC.Value = (decimal)guiderateDEC;
                    ElevationIP.Text = mount.SiteElevation.ToString();
                    LongitudeIP.Text=mount.SiteLatitude.ToString();
                    LatitudeIP.Text = mount.SiteLatitude.ToString();
                    filewrite();
                }
                else statusbox.Text = " not required";
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
                if (mountcanpark && mountconnected)
                {
                    if (!mount.AtPark)
                    {
                        statusbox.Text = " parking";
                        PAstatus.Text = " parking";
                        if (mount.AtHome)
                        {
                            mount.Tracking = true;
                            Thread.Sleep(2000);
                        }
                        mount.Park();
                    }
                    else
                    {
                        statusbox.Text = " parked";
                        PAstatus.Text = " parked";
                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("mount does not support Park");
                }
            }
            catch
            {
                statusbox.Text = " park error";
            }
        }
        // home mount has been optimized for the WD20 mount, which does not like homing over more than 90 degrees or when it is not tracking
        private void home_mount(object sender, EventArgs e)
        {
            try
            {
                if (mountconnected && mountcanhome)
                {
                    int i;
                    if (mount.AtPark)
                    {
                        mount.Unpark();
                        Thread.Sleep(500);
                    }
                    mount.Tracking = true;
                    if (mountId.Contains("OnStep")) // WD20 (onstep) specific step
                    {
                        statusbox.Text = " homing";
                        PAstatus.Text = " homing";
                        Thread.Sleep(2000);
                        mount.FindHome();
                        i = 0;
                        while (!mount.AtHome && i < 60)
                        {
                            Thread.Sleep(1000);
                            i++;
                        }
                        mount.Tracking = true;
                        Thread.Sleep(2000);
                    }
                    mount.FindHome();
                    i = 0;
                    while (!mount.AtHome && i < 60)
                    {
                        Thread.Sleep(1000);
                        i++;
                    }
                    // async request alternative for V4 methods
                    /*mount.FindHome();  
                    statusbox.Text = " homing";
                    PAstatus.Text = " homing";
                    i = 0;
                    while (mount.Slewing && i <60)
                    {
                        Thread.Sleep(1000);
                        i++
                    }
                    */
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("mount does not support home");
                }
            }
            catch
            {
                statusbox.Text = " home error";
            }
        }
        private void track_on(object sender, EventArgs e)
        {
            try
            {
                if (mountconnected && mountcantrack && !mount.AtPark)
                {
                    if (!mount.Tracking)
                    {
                        statusbox.Text = " tracking";
                        PAstatus.Text = " tracking";
                        //if (mount.AtPark) mount.Unpark();  // in the case that it is parked
                        mount.Tracking = true;
                    }
                }
            }
            catch
            {
                statusbox.Text = " track error";
            }
        }
        private void track_off(object sender, EventArgs e)
        {
            try
            {
                if (mountconnected)
                {
                    if (mount.Tracking && mountcantrack)
                    {
                        statusbox.Text = " stopped";
                        PAstatus.Text = " stopped";
                        mount.Tracking = false;
                    }
                    else statusbox.Text = " not tracking or parked";
                }
            }
            catch
            {
                statusbox.Text = " track error";
            }
        }
        private void unpark(object sender, EventArgs e)
        {
            try
            {
                if (mountconnected && mountcanpark)
                {
                    if (mount.AtPark)
                    {
                        mount.Unpark();
                        statusbox.Text = " unparked";
                        PAstatus.Text = " unparked";
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
                statusbox.Text = " unpark error";
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
                statusbox.Text = " abort error";
            }
        }
        private void connect_weather(object sender, EventArgs e)
        {
            try
            {
                if (weatherId != null)
                {
                    weather = new ObservingConditions(weatherId);
                    weather.Connect();   // asynch method
                    weatherconnected = true;
                    try { pressuretext.Text = Math.Round(weather.Pressure, 2).ToString() + " hPa"; } catch { hpasense = false; }
                    try { temptext.Text = Math.Round(weather.Temperature, 2).ToString() + " °C"; } catch { tempsense = false; }
                    try { humidtext.Text = Math.Round(weather.Humidity, 2).ToString() + " %"; } catch { rhsense = false; }
                    try { dewpointtext.Text = Math.Round(weather.DewPoint, 2).ToString() + " °C"; } catch { dewsense = false; }
                    try { cloudtext.Text = Math.Round(weather.CloudCover, 2).ToString() + " %"; } catch { cloudsense = false; }
                    try { skyqtext.Text = Math.Round(weather.SkyQuality, 2).ToString() + " "; } catch { sqsense = false; }
                    try { skytemptext.Text = Math.Round(weather.SkyTemperature, 2).ToString() + " °C"; } catch { irsense = false; }
                    try { rainratetext.Text = Math.Round(weather.RainRate, 2).ToString() + "mm/h"; } catch { rainsense = false; }
                    if(!rhsense) humidtext.Text = " N/A";
                    if(!hpasense) pressuretext.Text = " N/A";
                    if (!tempsense) temptext.Text = " N/A";
                    if (!irsense) skytemptext.Text = " N/A";
                    if (!sqsense) skyqtext.Text = " N/A";
                    if (!rainsense) rainratetext.Text = " N/A";
                    if (!cloudsense) cloudtext.Text =  " N/A";
                    if (!dewsense) dewpointtext.Text = " N/A";
                    btnConnectWeather.BackColor = Color.DarkGreen;
                    btnConnectWeather.ForeColor = Color.LightGray;
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
                    // default chart is temp
                    charttype = 0;
                    btngraphsel.Text = "temp C";
                    chart1.ChartAreas[0].AxisY.Minimum = -5;
                    chart1.ChartAreas[0].AxisY.Maximum = 25;
                }

                else
                {
                    weatherconnected = false;
                    humidtext.Text = " no connect";
                    pressuretext.Text = " no connect";
                    temptext.Text = " no connect";
                    cloudtext.Text = " no connect";
                    rainratetext.Text = " no connect";
                    skyqtext.Text = " no connect";
                    skytemptext.Text = " no connect";
                    dewpointtext.Text = " no connect";
                }
            }
            catch
            {
                // weather.Connected = false;  // old method
                weather.Disconnect();  // new asynch method
                weatherconnected = false;
                System.Windows.Forms.MessageBox.Show("Weather did not connect");
            }            
        }
        private void refreshmount()
        {
            try
            {
                if (mountconnected)
                {
                    if (mount.AtPark)
                    {
                        statusbox.Text = " parked";
                        PAstatus.Text = " parked";
                        IndPark.BackColor = Color.DarkGreen;
                    }
                    else IndPark.BackColor = Color.Black;

                    if (mount.AtHome)
                    {
                        statusbox.Text = " homed";
                        PAstatus.Text = " homed"; ;
                        IndHome.BackColor = Color.DarkGreen;
                    }
                    else IndHome.BackColor = Color.Black;

                    if (mount.Slewing)
                    {
                        IndSlew.BackColor = Color.DarkGreen;
                        statusbox.Text = " slewing";
                        PAstatus.Text = " slewing";
                    }
                    else IndSlew.BackColor = Color.Black;
                    if (mount.Tracking)
                    {
                        statusbox.Text = " tracking";
                        PAstatus.Text = " tracking"; ;

                        IndTrack.BackColor = Color.DarkGreen;
                    }
                    else IndTrack.BackColor = Color.Black;
                    ra = mount.RightAscension;
                    dec = mount.Declination;
                    alt = mount.Altitude;
                    az = mount.Azimuth;
                    DECText.Text = Math.Round(dec, 4).ToString();
                    DEC2Text.Text = Math.Round(dec, 4).ToString();
                    RAText.Text = Math.Round(ra, 4).ToString();
                    RA2text.Text = Math.Round(ra, 4).ToString();
                    AltText.Text = Math.Round(alt, 4).ToString();
                    AzText.Text = Math.Round(az, 4).ToString();
                }
            }

            catch
            {
                statusbox.Text = " mount error";
            }
        }
        // Polemaster moves to home and counterclockwise to select Polaris and another star
        private void PMStart(object sender, EventArgs e)
        {
            try
            {
                int i;
                if (mountconnected)                  
                {
                    statusbox.Text = " homing";
                    PAstatus.Text = " homing";
                    if (mount.AtPark)
                    {
                    mount.Unpark();
                    PAstatus.Text = " unparking";
                    statusbox.Text = " unparking";
                    Thread.Sleep(500);
                    }
                    mount.Tracking = true;
                    if (mountId.Contains("OnStep")) // WD20 (OnStep) specific additional homing for >90 degrees
                    {
                        Thread.Sleep(2000);
                        PAstatus.Text = " homing";
                        statusbox.Text = " homing";
                        mount.FindHome();
                        i = 0;
                        while (!mount.AtHome && i < 60)
                        {
                            Thread.Sleep(1000);
                            i++;
                        }
                        mount.Tracking = true;
                        Thread.Sleep(2000);
                    }
                    mount.FindHome(); // home or second home, to be sure for WD mount
                    mount.Tracking = true;                                    
                    PAstatus.Text = " homing";
                    statusbox.Text = " homing";
                    i = 0;
                    while (!mount.AtHome && i < 60)
                    {
                        Thread.Sleep(1000);
                        i++;
                    }
                    PAstatus.Text = " slewing";
                    statusbox.Text = " slewing";
                    mount.MoveAxis(0, -3);
                    Thread.Sleep(15000);
                    mount.MoveAxis(0, 0);
                    mount.Tracking = true;
                    PAstatus.Text = " tracking";
                    statusbox.Text = " tracking";
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
                if (mountconnected && !mount.Slewing && !mount.AtPark)
                {
                    PAstatus.Text = " slewing";
                    statusbox.Text = " slewing";
                    mount.MoveAxis(0,3);  // 3 degrees/sec
                    Thread.Sleep(15000);
                    mount.MoveAxis(0, 0);
                    mount.Tracking = true;
                    PAstatus.Text = " tracking";
                    statusbox.Text = " tracking";
                }
            }
            catch (Exception)
            {
                statusbox.AppendText(Environment.NewLine + "slew error");
            }
        }
        private void resetparams(object sender, EventArgs e)
        {
            // reset chart
            ReadProfile();  // get ASCOM profile
            samplecount = 0;          
            for (int i = 0; i < 120; i++) chartvalues[i] = 0;
            chart1.Series[0].Points.DataBindY(chartvalues);

            // resend params to Arduino
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
                    if (hpasense) pressuretext.Text = Math.Round(weather.Pressure, 2).ToString() + " hPa";
                    if (tempsense) temptext.Text = Math.Round(weather.Temperature, 2).ToString() + " °C";
                    if (rhsense) humidtext.Text = Math.Round(weather.Humidity, 2).ToString() + " %";
                    if (dewsense) dewpointtext.Text = Math.Round(weather.DewPoint, 2).ToString() + " °C";
                    if (cloudsense) cloudtext.Text = Math.Round(weather.CloudCover, 2).ToString() + " %";
                    if (sqsense) skyqtext.Text = Math.Round(weather.SkyQuality, 2).ToString() + " ";
                    if (irsense) skytemptext.Text = Math.Round(weather.SkyTemperature, 2).ToString() + " °C";
                    if (rainsense) rainratetext.Text = Math.Round(weather.RainRate, 2).ToString() + "mm/h";
                    // conditional text color to indicate problems
                    if (rainsense) 
                    { if (weather.RainRate > 0.2) rainratetext.ForeColor = Color.Red; 
                    else rainratetext.ForeColor = Color.LightGreen;
                    }
                }
                if (cloudsense)
                { if (weather.CloudCover > 60) cloudtext.ForeColor = Color.Red;
                    else if (weather.CloudCover > 30) cloudtext.ForeColor = Color.Yellow;
                    else cloudtext.ForeColor = Color.LightGreen;
                }
                if (rhsense)
                { if (weather.Humidity > 96) humidtext.ForeColor = Color.Red;
                    else humidtext.ForeColor = Color.LightGreen;
                }
                resetbtn.BackColor = Color.Black;
                ChartDataUpdate();
                ChartUpdate();
                }
            catch (NotImplementedException)   { }
           
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
                if (tempsense) tempvalues[index] = weather.Temperature;
                if (rhsense) humidvalues[index] = weather.Humidity;
                if (dewsense) dewvalues[index] = weather.DewPoint;
                if (hpasense) pressvalues[index] = weather.Pressure;
                if (cloudsense) cloudvalues[index] = weather.CloudCover;
                if (sqsense)
                {
                    if (weather.SkyQuality > 21) sqmvalues[index] = 21; // limit or it does not get shown
                    else if (weather.SkyQuality < 6) sqmvalues[index] = 6;
                    else sqmvalues[index] = weather.SkyQuality;
                }
                if (irsense)
                {
                    if (weather.SkyTemperature > 20) skyvalues[index] = 20; // limit or it does not get shown
                    else if (weather.SkyTemperature < -20) skyvalues[index] = -20; //limit or it does not get shown
                    else skyvalues[index] = weather.SkyTemperature;
                }
                if (rainsense)
                {
                    if (weather.RainRate > 5) rainvalues[index] = 5;
                    else if (weather.RainRate == 0) rainvalues[index] = 0.01;
                    else rainvalues[index] = weather.RainRate; //limit or it does not get shown
                }

            }
            if ((samplecount >= 3600) && (samplecount % 30 == 0))
            {
                for (int i = 0; i < 119; i++)  // shift left
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
                if (tempsense) tempvalues[119] = weather.Temperature;
                if (rhsense) humidvalues[119] = weather.Humidity;
                if (dewsense) dewvalues[119] = weather.DewPoint;
                if (cloudsense) cloudvalues[119] = weather.CloudCover;
                if (sqsense) sqmvalues[119] = weather.SkyQuality;
                if (hpasense) pressvalues[119] = weather.Pressure;
                if (irsense) skyvalues[119] = weather.SkyTemperature;
                if (rainsense) rainvalues[119] = weather.RainRate;
            }
            switch (charttype) // copy applicable data into chart array
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

        private void disconnect_weather(object sender, EventArgs e)
        {
            try
            {
                if (weatherconnected)
                {
                    //weather.Connected = false;   //disconnect weather sensors Ascom6
                    weather.Disconnect(); // Ascom 7
                    weatherconnected = false;
                    humidtext.Text = " not connected";
                    pressuretext.Text = " not connected";
                    temptext.Text = " not connected";
                    dewpointtext.Text = " not connected";
                    cloudtext.Text = " not connected";
                    skyqtext.Text = " not connected";
                    skytemptext.Text = " not connected";
                    rainratetext.Text = " not connected";
                    btnWeathChoose.ForeColor = Color.LightGray;
                    btnWeathChoose.BackColor = Color.Black;
                    btnConnectWeather.ForeColor = Color.LightGray;
                    btnConnectWeather.BackColor = Color.Black;
                    btnDiscWeather.ForeColor = Color.Gray;
                    btnDiscWeather.BackColor = Color.Black;
                }
            }
            catch (Exception)
            {
                statusbox.AppendText(Environment.NewLine + "disconnect weather error");
            }
        }

        private void slewrate_TextChanged(object sender, EventArgs e)
        {
            statusbox.Text = " not yet implemented";
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
                statusbox.Text = " west error";
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
                statusbox.Text = " east error";
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
                statusbox.Text = " south error";
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
                statusbox.Text = " north error";
            }
        }
        private void status_updates(object sender, EventArgs e) // every 2 seconds
        {

                if (mountconnected) refreshmount();
                if (weatherconnected) refreshweather();       
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
        // fileread() reads configuration variables from MyDocuments/ASCOM/Mount/settings.txt
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
            using (ASCOM.Utilities.Profile driverProfile = new ASCOM.Utilities.Profile())
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
