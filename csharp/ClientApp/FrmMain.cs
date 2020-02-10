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
        public FrmMain()
        {
            InitializeComponent();
        }

        public void ShowError(Exception ex)
        {
            lblResultText.Text = ex.Message;
            lblResultText.ForeColor = Color.Red;
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
                tbResult1.Text = string.Empty;
                ClearError();
                using (CommandReverseString crs = new CommandReverseString())
                {
                    crs.Connect(tbHost.Text, (int)nudPort.Value);
                    tbResult1.Text = crs.Execute(tbString.Text);
                }
            }
            catch(Exception ex)
            {
                ShowError(ex);
            }
        }

        private void btnExecute2_Click(object sender, EventArgs e)
        {
            try
            {
                tbResult2.Text = string.Empty;
                ClearError();
                using (CommandReverseInteger crs = new CommandReverseInteger())
                {
                    crs.Connect(tbHost.Text, (int)nudPort.Value);
                    tbResult2.Text = crs.Execute();
                }
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
                tbResult3.Text = string.Empty;
                ClearError();
                using (CommandCalculatePi ccp = new CommandCalculatePi())
                {
                    ccp.Connect(tbHost.Text, (int)nudPort.Value);
                    tbResult3.Text = ccp.Execute((int)nudNDecimalPlaces.Value);
                }
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
                tbResult4.Text = string.Empty;
                ClearError();
                using (CommandAddTwoIntegers ccp = new CommandAddTwoIntegers())
                {
                    ccp.Connect(tbHost.Text, (int)nudPort.Value);
                    tbResult4.Text = ccp.Execute((ushort)nudVal1.Value, (ushort)nudVal2.Value).ToString();
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                sock.Connect(tbHost.Text, (int)nudPort.Value);
                if (sock.Connected)
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
    }
}
