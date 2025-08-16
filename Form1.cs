using libdebug;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json; // Added for JSON serialization

namespace ELFInjector
{
    public partial class Form1 : Form
    {
        private PS4DBG ps4;
        private Process[] processes;
        private bool isConnected = false;
        private const string SettingsFileName = "settings.json";

        public Form1()
        {
            InitializeComponent();
            sendPayloadButton.Click += new EventHandler(sendPayloadButton_Click);
            connectButton.Click += new EventHandler(connectButton_Click);
            injectElfButton.Click += new EventHandler(injectElfButton_Click);
            refreshButton.Click += new EventHandler(refreshButton_Click);
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSettings();

            processListLabel.Enabled = false;
            processListComboBox.Enabled = false;
            injectElfButton.Enabled = false;
            refreshButton.Enabled = false;
        }

        #region Settings Logic

        /// <summary>
        /// A class to hold the application settings.
        /// </summary>
        public class AppSettings
        {
            public string PayloadIp { get; set; }
            public string ElfIp { get; set; }
            public string Port { get; set; }
        }

        /// <summary>
        /// Loads settings from the settings.json file.
        /// </summary>
        private void LoadSettings()
        {
            try
            {
                if (File.Exists(SettingsFileName))
                {
                    string json = File.ReadAllText(SettingsFileName);
                    var settings = JsonConvert.DeserializeObject<AppSettings>(json);

                    if (settings != null)
                    {
                        payloadIp.Text = settings.PayloadIp;
                        ps4Ip.Text = settings.ElfIp;
                        payloadPort.Text = settings.Port;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not load settings: {ex.Message}", "Settings Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Saves the current settings to the settings.json file.
        /// </summary>
        private void SaveSettings()
        {
            try
            {
                var settings = new AppSettings
                {
                    PayloadIp = payloadIp.Text,
                    ElfIp = ps4Ip.Text,
                    Port = payloadPort.Text
                };

                string json = JsonConvert.SerializeObject(settings, Formatting.Indented);
                File.WriteAllText(SettingsFileName, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not save settings: {ex.Message}", "Settings Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// This event handler is called just before the form closes.
        /// </summary>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save the settings when the application is closing
            SaveSettings();
        }

        #endregion

        #region ELF Injection Logic

        private async void connectButton_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                DisconnectAndResetUI();
                label1.Text = "Status: Disconnected";
                label1.ForeColor = Color.White;
                return;
            }

            if (string.IsNullOrWhiteSpace(ps4Ip.Text))
            {
                MessageBox.Show("Please enter the PS4 IP for ELF Injection.", "Missing IP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            label1.Text = "Status: Connecting...";
            label1.ForeColor = Color.White;
            ps4 = new PS4DBG(ps4Ip.Text);

            try
            {
                await Task.Run(() => ps4.Connect());

                isConnected = true;
                ps4.Notify(222, "ELF Injector Connected!");
                label1.Text = "Status: Connected!";
                label1.ForeColor = Color.Green;

                connectButton.Text = "Disconnect";
                ps4Ip.Enabled = false;
                processListLabel.Enabled = true;
                processListComboBox.Enabled = true;
                injectElfButton.Enabled = true;
                refreshButton.Enabled = true;

                await GetProcesses();
            }
            catch (Exception ex)
            {
                label1.Text = "Status: Connection Failed";
                label1.ForeColor = Color.Red;
                MessageBox.Show($"Failed to connect: {ex.Message}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void refreshButton_Click(object sender, EventArgs e)
        {
            label1.Text = "Status: Refreshing...";
            label1.ForeColor = Color.White;
            await GetProcesses();
        }

        private async Task GetProcesses()
        {
            if (ps4 == null || !isConnected) return;

            try
            {
                processListComboBox.Items.Clear();
                ProcessList processList = await Task.Run(() => ps4.GetProcessList());
                processes = processList.processes;

                if (processes != null)
                {
                    foreach (var process in processes)
                    {
                        processListComboBox.Items.Add(process.name);
                    }
                }

                label1.Text = "Status: Connected";
                label1.ForeColor = Color.Green;
                if (processListComboBox.Items.Count > 0)
                {
                    processListComboBox.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                label1.Text = "Status: Failed to get Processes.";
                label1.ForeColor = Color.Red;
                MessageBox.Show($"Could not retrieve Process List: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void injectElfButton_Click(object sender, EventArgs e)
        {
            if (processListComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a process from the list first.", "No Process Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ps4 == null || processes == null || !isConnected)
            {
                MessageBox.Show("Connection or process list is not available. Please try connecting again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string selectedProcessName = processListComboBox.SelectedItem.ToString();

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select ELF File to Inject";
                openFileDialog.Filter = "ELF Files (*.elf)|*.elf|All files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string elfPath = openFileDialog.FileName;

                    try
                    {
                        var processToInject = processes.FirstOrDefault(p => p.name == selectedProcessName);
                        if (processToInject == null)
                        {
                            MessageBox.Show("Could not find the selected process. You may need to reconnect.", "Process Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        label1.Text = "Status: Injecting ELF...";
                        label1.ForeColor = Color.White;

                        byte[] elfBytes = File.ReadAllBytes(elfPath);
                        await Task.Run(() => ps4.LoadElf(processToInject.pid, elfBytes));

                        ps4.Notify(222, $"ELF Injected into {selectedProcessName}!");
                        MessageBox.Show($"Successfully injected '{Path.GetFileName(elfPath)}' into {selectedProcessName}.", "Injection Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DisconnectAndResetUI();
                        label1.Text = "Status: Injected & Disconnected";
                        label1.ForeColor = Color.Cyan;
                    }
                    catch (Exception ex)
                    {
                        label1.Text = "Status: ELF Injection Failed.";
                        label1.ForeColor = Color.Red;
                        MessageBox.Show($"Failed to inject ELF: {ex.Message}", "Injection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void DisconnectAndResetUI()
        {
            ps4?.Disconnect();
            isConnected = false;
            ps4 = null;

            connectButton.Text = "Connect";
            ps4Ip.Enabled = true;
            processListComboBox.Items.Clear();
            processListComboBox.Enabled = false;
            injectElfButton.Enabled = false;
            processListLabel.Enabled = false;
            refreshButton.Enabled = false;
        }


        private void helpLabel_Click(object sender, EventArgs e)
        {
        }

        #endregion

        #region Payload Sender Logic

        private void sendPayloadButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(payloadIp.Text))
            {
                MessageBox.Show("Please enter a PS4 IP.", "Missing IP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(payloadPort.Text, out int port) || port < 1 || port > 65535)
            {
                MessageBox.Show("Please enter a valid port number (ex: 9090).", "Invalid Port", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select Payload File";
                openFileDialog.Filter = "Payload Files (*.bin;*.elf)|*.bin;*.elf|All files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string payloadFilePath = openFileDialog.FileName;
                    InjectPayload(payloadIp.Text, port, payloadFilePath);
                }
            }
        }

        private void InjectPayload(string ip, int port, string payloadPath)
        {
            payloadStatusLabel.Text = "Status: Sending...";
            Application.DoEvents();

            Socket socket = null;
            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.SendTimeout = 5000;
                socket.Connect(ip, port);
                socket.SendFile(payloadPath);

                payloadStatusLabel.Text = "Status: Sent";
                MessageBox.Show($"Payload '{Path.GetFileName(payloadPath)}' was sent successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SocketException ex) when (ex.SocketErrorCode == SocketError.TimedOut)
            {
                payloadStatusLabel.Text = "Status: Timeout";
                MessageBox.Show("Check the IP, the Payload failed to send", "Timeout", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                payloadStatusLabel.Text = "Status: Error";
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (socket?.Connected ?? false)
                {
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                }
            }
        }

        #endregion
    }
}
