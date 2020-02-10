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
    public partial class FrmMain : Form
    {
        private bool closing = false;
        private ITransportMedium Medium = new SocketMedium();
        private Worker worker;
        private int count = 0;

        public FrmMain()
        {
            InitializeComponent();

            worker = new Worker(Done);
        }

        private void Done(IWorkElement elem)
        {
            if (closing) return;
            InvShowError(elem.Error);
            string res = elem.Error == null ? elem.Result : string.Empty;
            if (elem.Error != null)
            {
                var x = (elem.ResultContainer as TextBox);
                x.Invoke((Action)delegate {
                    x.Text = res;
                });
            }
            else
            {
                var x = (elem.ResultContainer as TextBox);
                x.Invoke((Action)delegate {
                    x.Text = res;
                });
            }
        }

        public void ShowError(Exception ex, bool showDialog = true)
        {
            lblResultText.Text = ex.Message;
            lblResultText.ForeColor = Color.Red;
            if (showDialog)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void InvShowError(Exception ex)
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

        private void btnExecute1_Click(object sender, EventArgs e)
        {
            try
            {
                count++;
                string param = tbString.Text;
                if (chbAddNum.Checked)
                {
                    param += " - " + count.ToString();
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

        private void RunCommandAsync(IWorkElement elem)
        {
            (elem.ResultContainer as TextBox).Text = string.Empty;
            ClearError();
            worker.AddWork(elem);
        }

        private void RunCommandSync(IWorkElement elem)
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

        private static uint ReverseUInt32(uint hostOrder)
        {
            byte[] hostBytes = BitConverter.GetBytes(hostOrder);
            Array.Reverse(hostBytes);
            uint res = BitConverter.ToUInt32(hostBytes, 0);
            return res;
        }

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

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            closing = true;
            worker.Stop();
        }

        private void tmrProgressUpdater_Tick(object sender, EventArgs e)
        {
            pb1.Value = worker.GetQueueSize();
        }
    }
}
