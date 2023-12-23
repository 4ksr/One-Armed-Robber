using System;
using System.Windows.Forms;
using Memory;

namespace TryhackingGame
{
    public partial class MainLoader : Form
    {
        private readonly Mem meme = new Mem();
        private readonly string ammoAddress = "OAR-Win64-Shipping.exe+0x04C16EA0,0,20,598,228,20,2BC";
        bool ammo = false;
        public MainLoader()
        {
            InitializeComponent();

            int processId = meme.GetProcIdFromName("OAR-Win64-Shipping");
           // int processId = 32548;
            if (processId > 0)
            {
                try
                {
                    meme.OpenProcess(processId);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Process not found. Make sure the game is running and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ammo == false)
            {

            }
            if (ammo == true) 
            {
                try
                {
                    meme.WriteMemory(ammoAddress, "int", "1337");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    timer1.Stop(); // Stop the timer to prevent further attempts
                }
            }
            
        }

        private void Ammobox_CheckedChanged(object sender, EventArgs e)
        {
            if (ammo == true)
            {
                ammo = false;
            }
            else //(ammo == false) 
            {
                ammo = true;
                //MessageBox.Show("Startd");
                timer1.Start();
            }
            
        }
        
    }
}
