using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AudioSwitch.Properties;
using AudioSwitcher.AudioApi;
using AudioSwitcher.AudioApi.CoreAudio;
using Microsoft.Win32;

namespace AudioSwitch
{
    public partial class frmPrincipal : Form
    {
        private CoreAudioDevice DefaultAudioDevice;
        private CoreAudioController Controller;
        private int index;
        KeyboardHook hook = new KeyboardHook();
        public frmPrincipal()
        {
            Controller = new CoreAudioController();
            InitializeComponent();

            // register the event that is fired after the key press.
            hook.KeyPressed += new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);
            // register the control + alt + F12 combination as hot key.
            hook.RegisterHotKey(global::ModifierKeys.Control | global::ModifierKeys.Alt, Keys.F9);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            DefaultAudioDevice = Controller.GetDefaultDevice(AudioSwitcher.AudioApi.DeviceType.Playback, Role.Multimedia);
            txtActualDevice.Text = DefaultAudioDevice.FullName;

            ChargeDevicesList();

            chkStartAtStartUp.Checked = Settings.Default.StartWithWin;
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
        }


        private void ChargeDevicesList()
        {
            var List = Controller.GetPlaybackDevices();
            string[] fav = GetDeviceList();
            lstDevices.Items.Clear();
            foreach (CoreAudioDevice CAD in List)
            {
                if (CAD.State == DeviceState.Active)
                {
                    lstDevices.Items.Add(CAD, fav.Contains(CAD.Id.ToString()));
                }
            }

            lstDevices.DisplayMember = "FullName";
            lstDevices.ValueMember = "Id";
        }

        private void BtnChangeDevice_Click(object sender, EventArgs e)
        {
            ChangeDevice();
        }

        private void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            ChangeDevice();
        }

        private void ChangeDevice()
        {
            int c;
            CoreAudioDevice CAD;
            string[] fav = GetDeviceList();

            ChargeDevicesList();

            if (lstDevices.CheckedItems.Count == 0)
            {
                return;
            }

            if (lstDevices.CheckedItems.Count == 1)
            {
                CAD = (CoreAudioDevice)lstDevices.CheckedItems[0];
                if (!CAD.IsDefaultDevice)
                {
                    if (fav.Contains(CAD.Id.ToString()))
                    {
                        if (Controller.SetDefaultDevice(CAD))
                        {
                            DefaultAudioDevice = CAD;
                            txtActualDevice.Text = DefaultAudioDevice.FullName;
                            ShowNotification("Default device now is: " + DefaultAudioDevice.FullName);
                        }
                    }
                }
                return;
            }

            for (c = index; c < lstDevices.CheckedItems.Count; c++)
            {
                CAD = (CoreAudioDevice)lstDevices.CheckedItems[c];
                if (!CAD.IsDefaultDevice)
                {
                    if (fav.Contains(CAD.Id.ToString()))
                    {
                        if (Controller.SetDefaultDevice(CAD))
                        {
                            DefaultAudioDevice = CAD;
                            txtActualDevice.Text = DefaultAudioDevice.FullName;
                            index = c;
                            ShowNotification("Default device now is: " + DefaultAudioDevice.FullName);
                            return;
                        }
                    }

                }

                if (c + 1 == lstDevices.CheckedItems.Count)
                {
                    c = -1;
                }
            }
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            if (this.Height == 260)
            {
                this.Height = 480;
            }
            else
            {
                this.Height = 260;
            }
        }

        private void SaveDeviceList()
        {
            using (TextWriter tw = new StreamWriter(Application.StartupPath + "FavDevicesList.txt"))
            {

                foreach (CoreAudioDevice cad in lstDevices.CheckedItems)
                {
                    tw.WriteLine(cad.Id);
                }

            }
        }

        private string[] GetDeviceList()
        {
            if (File.Exists(Application.StartupPath + "FavDevicesList.txt"))
            {
                return File.ReadAllLines(Application.StartupPath + "FavDevicesList.txt");
            }
            return new string[] { "" };
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.StartWithWin = chkStartAtStartUp.Checked;
            Settings.Default.Save();
            SaveDeviceList();
        }

        private void SetStartup()
        {            
            RegistryKey rk = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (chkStartAtStartUp.Checked)
                rk.SetValue(Application.ProductName, Application.ExecutablePath);
            else
                rk.DeleteValue(Application.ProductName, false);

        }

        private void chkStartAtStartUp_CheckedChanged(object sender, EventArgs e)
        {
            SetStartup();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPrincipal_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                ntfAudioSwitch.Visible = true;
            }
        }

        private void ntfAudioSwitch_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            ntfAudioSwitch.Visible = false;
        }

        private void ShowNotification(string msg)
        {
            ntfAudioSwitch.BalloonTipText = msg;
            ntfAudioSwitch.BalloonTipTitle = "AudioSwitch";

            ntfAudioSwitch.ShowBalloonTip(5000);
        }

        private void BtnSaveFavList_Click(object sender, EventArgs e)
        {
            SaveDeviceList();
        }
    }
}
