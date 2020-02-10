using BackgWorker;
using ClientLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClietApp
{
    /// <summary>
    /// Main Form of the application.
    /// </summary>
    public partial class FrmMain : Form
    {
        /// <summary>
        /// True when the user wants to close the application.
        /// </summary>
        private bool closing = false;
        private ITransportMedium Medium = new SocketMedium();
        private WorkerThread worker;

        /// <summary>
        /// Used to count the reverse string commands.
        /// </summary>
        private int countReverseStringCommands = 0;

        public FrmMain()
        {
            InitializeComponent();

            worker = new WorkerThread(Done);
        }

        /// <summary>
        /// Called from different thread when an element's work is done.
        /// </summary>
        /// <param name="elem"></param>
        private void Done(IWorkElement elem)
        {
            if (closing) return;
            InvokeShowError(elem.Error);
            string res = elem.Error == null ? elem.Result : string.Empty;
            var textBox = (elem.ResultContainer as TextBox);
            textBox.Invoke((Action)delegate {
                textBox.Text = res;
            });
        }

        /// <summary>
        /// Show error: Call from the main thread.
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="showDialog"></param>
        public void ShowError(Exception ex, bool showDialog = true)
        {
            lblResultText.Text = ex.Message;
            lblResultText.ForeColor = Color.Red;
            if (showDialog)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// InvokeShowError: Call from worker thread.
        /// </summary>
        /// <param name="ex"></param>
        public void InvokeShowError(Exception ex)
        {
            lblResult.Invoke((Action)delegate {
                if (ex != null)
                {
                    lblResultText.Text = ex.Message;
                    lblResultText.ForeColor = Color.Red;
                }
                else
                {
                    lblResultText.Text = "-";
                    lblResultText.ForeColor = Color.Black;
                }
            });
        }

        public void ClearError()
        {
            lblResultText.Text = "-";
            lblResultText.ForeColor = Color.Black;
        }

        /// <summary>
        /// Command 1 Reverse String.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExecute1_Click(object sender, EventArgs e)
        {
            try
            {
                string param = tbString.Text;
                if (chbAddNum.Checked)
                {
                    param += " - " + countReverseStringCommands.ToString();
                    countReverseStringCommands++;
                }
                CommandReverseString crs = new CommandReverseString(Medium, param);
                crs.ResultContainer = tbResult1;
                RunCommandAsync(crs);
            }
            catch(Exception ex)
            {
                ShowError(ex);
            }
        }

        /// <summary>
        /// Async command execution.
        /// </summary>
        /// <param name="elem"></param>
        private void RunCommandAsync(IWorkElement elem)
        {
            (elem.ResultContainer as TextBox).Text = string.Empty;
            ClearError();
            worker.AddWork(elem);
        }

        /// <summary>
        /// Synchronous command execution.
        /// This is not used. It blocks the GUI.
        /// </summary>
        /// <param name="elem"></param>
        private void RunCommand(IWorkElement elem)
        {
            (elem.ResultContainer as TextBox).Text = string.Empty;
            ClearError();
            elem.Execute();

            if (elem.Error != null)
            {
                ShowError(elem.Error, showDialog: false);
            }
            else
            {
                (elem.ResultContainer as TextBox).Text = elem.Result;
            }
        }


        /// <summary>
        /// Custom methos used to reverse an UINT32.
        /// This is an example of passing an algorithm to be used by the command handler.
        /// </summary>
        /// <param name="hostOrder"></param>
        /// <returns></returns>
        private static uint ReverseUInt32(uint hostOrder)
        {
            byte[] hostBytes = BitConverter.GetBytes(hostOrder);
            Array.Reverse(hostBytes);
            uint res = BitConverter.ToUInt32(hostBytes, 0);
            return res;
        }

        /// <summary>
        /// Command 2: Reverse Integer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExecute2_Click(object sender, EventArgs e)
        {
            try
            {
                CommandReverseInteger crs = new CommandReverseInteger(Medium, ReverseUInt32);
                crs.ResultContainer = tbResult2;
                RunCommandAsync(crs);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        /// <summary>
        /// Command 3: Calculate PI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExecute3_Click(object sender, EventArgs e)
        {
            try
            {
                CommandCalculatePi ccp = new CommandCalculatePi(Medium, (int)nudNDecimalPlaces.Value);
                ccp.ResultContainer = tbResult3;
                RunCommandAsync(ccp); 
            }
            catch(Exception ex)
            {
                ShowError(ex);
            }
        }

        /// <summary>
        /// Command 4: Add Two Integers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExecute4_Click(object sender, EventArgs e)
        {
            try
            {
                CommandAddTwoIntegers cati = new CommandAddTwoIntegers(Medium, (ushort)nudVal1.Value, (ushort)nudVal2.Value);
                cati.ResultContainer = tbResult4;
                RunCommandAsync(cati);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        /// <summary>
        /// Connects the socket to the server.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                Medium = new SocketMedium();
                Medium.Connect(tbHost.Text, (int)nudPort.Value);
                if (Medium.Connected)
                {
                    MessageBox.Show("Connected to the server.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Connection failed to the server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Connection failed to the server: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// The user wants to exit the application.
        /// Signal the worker and wait for it's exit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Signal the worker to stop.
            closing = true;

            //This will block until the worker exits.
            worker.Stop();
        }

        /// <summary>
        /// Updates the progress bar periodically.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrProgressUpdater_Tick(object sender, EventArgs e)
        {
            pb1.Value = worker.GetQueueSize();
        }
    }
}
