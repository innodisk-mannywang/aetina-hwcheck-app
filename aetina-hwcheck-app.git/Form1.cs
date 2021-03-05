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
        private static string g_report = "";
        private IniFile m_Inifile;
        private const string STATUS_PASS = "PASS";
        private const string STATUS_FAILED = "FAILED";

        public Form1()
        {
            InitializeComponent();
        }

        private void writelog(string context)
        {
            using (StreamWriter sw = File.AppendText(g_report))
            {
                sw.WriteLine(context);
            }
        }

        private void showtotextbox(string context)
        {
            tbx_hw_info.AppendText(context + "\r\n");
            writelog(context);
        }

        private void gethwinfo()
        {
            string inifile = System.AppDomain.CurrentDomain.BaseDirectory + "config.ini";
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

                    //showtotextbox("---------------------SSD-----------------------------");
                    //showtotextbox("Caption: " + pdc["Caption"].Value);
                    //showtotextbox("CompressionMethod: " + pdc["CompressionMethod"].Value);
                    //showtotextbox("CreationClassName: " + pdc["CreationClassName"].Value);
                    //showtotextbox("Description: " + pdc["Description"].Value);
                    //showtotextbox("DeviceID: " + pdc["DeviceID"].Value);
                    //showtotextbox("ErrorDescription: " + pdc["ErrorDescription"].Value);
                    //showtotextbox("ErrorMethodology: " + pdc["ErrorMethodology"].Value);
                    //showtotextbox("FirmwareRevision: " + pdc["FirmwareRevision"].Value);
                    //showtotextbox("InterfaceType: " + pdc["InterfaceType"].Value);
                    //showtotextbox("Manufacturer: " + pdc["Manufacturer"].Value);
                    //showtotextbox("MediaType: " + pdc["MediaType"].Value);
                    //showtotextbox("Model: " + pdc["Model"].Value);
                    //showtotextbox("Name: " + pdc["Name"].Value);
                    //showtotextbox("PNPDeviceID: " + pdc["PNPDeviceID"].Value);
                    //showtotextbox("SerialNumber: " + pdc["SerialNumber"].Value);
                    //showtotextbox("Status: " + pdc["Status"].Value);
                    //showtotextbox("SystemCreationClassName: " + pdc["SystemCreationClassName"].Value);
                    //showtotextbox("SystemName: " + pdc["SystemName"].Value);
                    //UInt64 fsize = Convert.ToUInt64(pdc["Size"].Value) / (1024 * 1024 * 1024);
                    //showtotextbox("Size: " + fsize + " GB");
                    //showtotextbox("-----------------------------------------------------");
                }

                //Get DRAM information            
                mos.Query.QueryString = "SELECT * FROM Win32_PhysicalMemory";
                foreach (ManagementObject mo in mos.Get())
                {
                    PropertyDataCollection pdc = mo.Properties;

                    showtotextbox("---------------------RAM-----------------------------");
                    showtotextbox("BankLabel: " + pdc["BankLabel"].Value);
                    showtotextbox("Capacity: " + pdc["Capacity"].Value);
                    showtotextbox("Caption: " + pdc["Caption"].Value);
                    showtotextbox("CreationClassName: " + pdc["CreationClassName"].Value);
                    showtotextbox("DataWidth: " + pdc["DataWidth"].Value);
                    showtotextbox("Description: " + pdc["Description"].Value);
                    showtotextbox("DeviceLocator: " + pdc["DeviceLocator"].Value);
                    showtotextbox("FormFactor: " + pdc["FormFactor"].Value);
                    showtotextbox("HotSwappable: " + pdc["HotSwappable"].Value);
                    showtotextbox("InstallDate: " + pdc["InstallDate"].Value);
                    showtotextbox("InterleaveDataDepth: " + pdc["InterleaveDataDepth"].Value);
                    showtotextbox("InterleavePosition: " + pdc["InterleavePosition"].Value);
                    showtotextbox("Manufacturer: " + pdc["Manufacturer"].Value);
                    showtotextbox("MemoryType: " + pdc["MemoryType"].Value);
                    showtotextbox("Model: " + pdc["Model"].Value);
                    showtotextbox("Name: " + pdc["Name"].Value);
                    showtotextbox("OtherIdentifyingInfo: " + pdc["OtherIdentifyingInfo"].Value);
                    showtotextbox("PartNumber: " + pdc["PartNumber"].Value);
                    showtotextbox("PositionInRow: " + pdc["PositionInRow"].Value);
                    showtotextbox("PoweredOn: " + pdc["PoweredOn"].Value);
                    showtotextbox("Removable: " + pdc["Removable"].Value);
                    showtotextbox("Replaceable: " + pdc["Replaceable"].Value);
                    showtotextbox("SerialNumber: " + pdc["SerialNumber"].Value);
                    showtotextbox("SKU: " + pdc["SKU"].Value);
                    showtotextbox("Speed: " + pdc["Speed"].Value);
                    showtotextbox("Status: " + pdc["Status"].Value);
                    showtotextbox("Tag: " + pdc["Tag"].Value);
                    showtotextbox("TotalWidth: " + pdc["TotalWidth"].Value);
                    showtotextbox("TypeDetail: " + pdc["TypeDetail"].Value);
                    showtotextbox("Version: " + pdc["Version"].Value);
                    showtotextbox("-----------------------------------------------------");
                }

                //Get Video Card information
                mos.Query.QueryString = "SELECT * FROM Win32_PnPEntity";
                foreach (ManagementObject mo in mos.Get())
                {
                    PropertyDataCollection pdc = mo.Properties;

                    if (pdc["DeviceID"].Value.ToString().ToUpper().Contains("VEN_10DE&DEV_1EB8"))
                    {
                        showtotextbox("---------------------VideoCard-----------------------------");
                        showtotextbox("Caption: " + pdc["Caption"].Value);
                        showtotextbox("DeviceID: " + pdc["DeviceID"].Value);
                        showtotextbox("Description: " + pdc["Description"].Value);
                        showtotextbox("-----------------------------------------------------");
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                g_report = Directory.GetCurrentDirectory() + "\\report.txt";

                // This text is added only once to the file.
                if (!File.Exists(g_report))
                {
                    // Create a file to write to.
                    using (StreamWriter sw = File.CreateText(g_report))
                    {
                        //sw.WriteLine(DateTime.Now.ToString());
                    }
                }

                gethwinfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
