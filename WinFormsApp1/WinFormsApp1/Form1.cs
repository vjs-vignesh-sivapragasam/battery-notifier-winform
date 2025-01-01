using System;
using System.Media;
using System.Windows.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private NotifyIcon trayIcon;
        private ContextMenuStrip trayMenu;
        private bool isHidingToTray = false; // Prevent recursive calls


        public Form1()
        {
            InitializeComponent();
            SetupTimer();
            SetupWaterReminderTimer();
            BatteryDescription();
            InitializeTrayIcon();
            ShowInTaskbar = false;

        }

        private void InitializeTrayIcon()
        {
            // Initialize context menu for tray icon
            trayMenu = new ContextMenuStrip();
            trayMenu.Items.Add("Show", null, (s, e) => RestoreForm());
            trayMenu.Items.Add("Exit", null, (s, e) => Application.Exit());

            // Initialize tray icon
            trayIcon = new NotifyIcon
            {
                Icon = SystemIcons.Information,
                ContextMenuStrip = trayMenu,
                Visible = true,
                Text = "Battery Notifier"
            };

            trayIcon.DoubleClick += (s, e) => RestoreForm();
        }

        private void RestoreForm()
        {
            Show();
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MINIMIZE = 0xF020;

            if (m.Msg == WM_SYSCOMMAND && (m.WParam.ToInt32() & 0xFFF0) == SC_MINIMIZE)
            {
                // Minimize to tray instead of taskbar
                Hide();
                ShowInTaskbar = false;
                return;
            }

            base.WndProc(ref m);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            trayIcon.Visible = false; // Remove tray icon on exit
            batteryCheckTimer?.Stop();
            waterReminderTimer?.Stop();
        }

        private void BatteryDescription()
        {
            lblDescription.Text = "Battery Notifier alerts you when your laptop's battery ";
            lblDescription.Text += "\n" + "reaches 90% with a notification and sound reminder";
            lblDescription.Text += "\n" + "";
        }
        private void SetupTimer()
        {
            batteryCheckTimer = new System.Windows.Forms.Timer();
            batteryCheckTimer.Interval = 10000; // Check every 10 seconds
            batteryCheckTimer.Tick += BatteryCheckTimer_Tick;
            batteryCheckTimer.Start();
        }

        private void BatteryCheckTimer_Tick(object sender, EventArgs e)
        {
            var powerStatus = SystemInformation.PowerStatus;
            float batteryPercentage = powerStatus.BatteryLifePercent * 100;

            if (powerStatus.PowerLineStatus == PowerLineStatus.Online && batteryPercentage >= 90)
            {
                ShowNotification("The Battery has sufficient charge", "Please unplug the charger.");
            }
            else if (powerStatus.PowerLineStatus == PowerLineStatus.Offline && batteryPercentage < 20)
            {
                ShowNotification("Your battery is about to die.", "Please Plug-in charger & save more battery life");
            }
            else if (powerStatus.PowerLineStatus == PowerLineStatus.Online && batteryPercentage == 20)
            {
                ShowNotification("Hello", "Thanks for Saving me");
            }
        }

        private void ShowNotification(string title, string message)
        {
            NotifyIcon notifyIcon = new NotifyIcon
            {
                Icon = SystemIcons.Information,
                Visible = true,
                BalloonTipTitle = title,
                BalloonTipText = message
            };

            PlayNotificationSound(); // Play the sound
            notifyIcon.ShowBalloonTip(5000);
        }

        private void PlayNotificationSound()
        {
            try
            {
                // Specify a custom WAV file or use SystemSounds
                //string soundFilePath = "mixkit-bell-notification-933.wav"; // Replace with your file path
                string soundFilePath = Path.Combine(Application.StartupPath, "mixkit-bell-notification-933.wav");

                if (System.IO.File.Exists(soundFilePath))
                {
                    SoundPlayer soundPlayer = new SoundPlayer(soundFilePath);
                    soundPlayer.Play();
                }
                else
                {
                    // Fallback to system sound if custom file is not found
                    SystemSounds.Exclamation.Play();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error playing sound: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        private void SetupWaterReminderTimer()
        {
            waterReminderTimer = new System.Windows.Forms.Timer();
            waterReminderTimer.Interval = 3600000; // 1 hour in milliseconds
            waterReminderTimer.Tick += WaterReminderTimer_Tick;
            waterReminderTimer.Start();
        }

        private void WaterReminderTimer_Tick(object sender, EventArgs e)
        {
            ShowNotification("Hydration Reminder", "It's time to drink water and stay hydrated!");
        }

    }
}
