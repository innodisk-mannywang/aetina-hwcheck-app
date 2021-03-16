using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aetina_hwcheck_app.git
{
    public partial class Form1 : Form
    {
        private IniFile m_Inifile;
        private const string STATUS_PASS = "PASS";
        private const string STATUS_FAILED = "FAILED";

        public Form1()
        {
            InitializeComponent();
        }        

        private void showtotextbox(string context)
        {
            tbx_hw_info.AppendText(context + "\r\n");            
        }

        private void gethwinfo()
        {
            string inifile = System.AppDomain.CurrentDomain.BaseDirectory + "config_for_aetina.ini";
            if (File.Exists(inifile))
            {
                m_Inifile = new IniFile(inifile);

                Config.SSD_COUNT = Convert.ToInt32(m_Inifile.IniReadValue("SSD", "COUNT"));
                Config.SSD_GBSIZE = Convert.ToInt32(m_Inifile.IniReadValue("SSD", "GBSIZE"));
                Config.SSD_MODEL = m_Inifile.IniReadValue("SSD", "MODEL");
                Config.DRAM_COUNT = Convert.ToInt32(m_Inifile.IniReadValue("DRAm", "COUNT"));
                Config.DRAM_PARTNUMBER = m_Inifile.IniReadValue("DRAM", "PARTNUMBER");
                Config.GPU_COUNT = Convert.ToInt32(m_Inifile.IniReadValue("GPU", "COUNT"));
                Config.GPU_VIDPID = m_Inifile.IniReadValue("GPU", "VIDPID");

                ManagementObjectSearcher mos = new ManagementObjectSearcher();

                //Get Storage information
                showtotextbox("---------------------SSD---------------------");
                int ssd_checked_number = 0;
                mos.Query.QueryString = "SELECT * FROM Win32_DiskDrive";
                foreach (ManagementObject mo in mos.Get())
                {
                    PropertyDataCollection pdc = mo.Properties;

                    if (pdc["Model"].Value.ToString().Contains(Config.SSD_MODEL) && Convert.ToUInt64(pdc["Size"].Value) / (1024 * 1024 * 1024) == (UInt64)Config.SSD_GBSIZE)
                        ssd_checked_number++;

                    if (ssd_checked_number == Config.SSD_COUNT)
                    {
                        SSD_STATUS.Text = STATUS_PASS;
                        SSD_STATUS.BackColor = Color.Green;
                    }
                    else
                    {
                        SSD_STATUS.Text = STATUS_FAILED;
                        SSD_STATUS.BackColor = Color.Red;
                    }
                    
                    showtotextbox("Model: " + pdc["Model"].Value);
                    UInt64 fsize = Convert.ToUInt64(pdc["Size"].Value) / (1024 * 1024 * 1024);
                    showtotextbox("Size: " + fsize + " GB");
                }
                showtotextbox("---------------------------------------------");

                //Get DRAM information
                showtotextbox("---------------------RAM---------------------");
                int ram_check_number = 0;
                mos.Query.QueryString = "SELECT * FROM Win32_PhysicalMemory";
                foreach (ManagementObject mo in mos.Get())
                {
                    PropertyDataCollection pdc = mo.Properties;

                    if (pdc["PARTNUMBER"].Value.ToString().Contains(Config.DRAM_PARTNUMBER))
                       ram_check_number++;

                    if (ram_check_number == Config.DRAM_COUNT)
                    {
                        RAM_STATUS.Text = STATUS_PASS;
                        RAM_STATUS.BackColor = Color.Green;
                    }
                    else
                    {
                        RAM_STATUS.Text = STATUS_FAILED;
                        RAM_STATUS.BackColor = Color.Red;
                    }
                    
                    showtotextbox("PartNumber: " + pdc["PartNumber"].Value);
                }
                showtotextbox("---------------------------------------------");

                //Get Video Card information
                showtotextbox("---------------------GPU---------------------");
                int GPU_COUNT = 0;
                mos.Query.QueryString = "SELECT * FROM Win32_PnPEntity";
                foreach (ManagementObject mo in mos.Get())
                {
                    PropertyDataCollection pdc = mo.Properties;

                    if (pdc["DeviceID"].Value.ToString().Contains(Config.GPU_VIDPID))
                        GPU_COUNT++;

                    if (GPU_COUNT == Config.GPU_COUNT)
                    {
                        GPU_STATUS.Text = STATUS_PASS;
                        GPU_STATUS.BackColor = Color.Green;
                    }
                    else
                    {
                        GPU_STATUS.Text = STATUS_FAILED;
                        GPU_STATUS.BackColor = Color.Red;
                    }
                    
                    if (pdc["Description"].Value != null && pdc["Description"].Value.ToString().Contains("Video Controller"))
                    {
                        showtotextbox("Description: " + pdc["Description"].Value);
                        showtotextbox("DeviceID: " + pdc["DeviceID"].Value);
                    }
                }
                showtotextbox("---------------------------------------------");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void tb_serialnumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    gethwinfo();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    string path = Directory.GetCurrentDirectory() + "\\" + tb_serialnumber.Text + ".txt";
                    // This text is added only once to the file.
                    if (!File.Exists(path))
                    {
                        // Create a file to write to.
                        using (StreamWriter sw = File.CreateText(path))
                        {
                            sw.Write(tbx_hw_info.Text);
                        }
                    }                    
                }
            }
        }
    }
}
