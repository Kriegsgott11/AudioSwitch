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
using AudioSwitcher.AudioApi;
using AudioSwitcher.AudioApi.CoreAudio;


namespace AudioSwitch
{
    public partial class frmPrincipal : Form
    {
        private CoreAudioDevice DefaultAudioDevice;
        private CoreAudioController Controller;

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
            txtActualDevice.Text = DefaultAudioDevice.Name;

            ChargeDevicesList();

        }


        private void ChargeDevicesList()
        {
            var List = Controller.GetPlaybackDevices();
            string[] fav = GetDeviceList();

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

            var List = Controller.GetPlaybackDevices();
            string[] fav = GetDeviceList();

            foreach (CoreAudioDevice CAD in List)
            {
                if (CAD.State == DeviceState.Active && CAD.Name != txtActualDevice.Text)
                {

                    if (fav.Contains(CAD.Id.ToString()))
                    {
                        if (Controller.SetDefaultDevice(CAD))
                        {
                            DefaultAudioDevice = CAD;
                            txtActualDevice.Text = DefaultAudioDevice.Name;
                            return;
                        }
                    }

                }
            }
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {

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
            SaveDeviceList();
        }
    }
}
