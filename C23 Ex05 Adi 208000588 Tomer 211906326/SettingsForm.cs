using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace BullsEyeApp
{
    public class SettingsForm : Form
    {
        private readonly Button r_ButtonChancesCounter;
        private readonly Button r_ButtonStart;
        private int m_chancesCounter = 4;
        private const int k_FormWidth = 300;
        private const int k_FormHeight = 200;

        public SettingsForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "BullsEye";
            this.Size = new Size(k_FormWidth, k_FormHeight);
            r_ButtonChancesCounter = new Button();
            r_ButtonStart = new Button();
            initControls();
        }

        private void initControls()
        {
            //r_ButtonChancesCounter.Enabled = true;
            //r_ButtonStart.Enabled = true;
            r_ButtonChancesCounter.Text = string.Format("Number of chances: {0}", m_chancesCounter);
            r_ButtonStart.Text = "Start";
            r_ButtonChancesCounter.AutoSize = true;
            Controls.Add(r_ButtonChancesCounter);
            Controls.Add(r_ButtonStart);
            r_ButtonStart.Top = ClientSize.Height - 16 - r_ButtonStart.Height;
            r_ButtonStart.Left = ClientSize.Width - 16 - r_ButtonStart.Width;
            r_ButtonChancesCounter.Top = 16;
            r_ButtonChancesCounter.Left = (ClientSize.Width - r_ButtonChancesCounter.Width) / 2;
            //r_ButtonChancesCounter.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            r_ButtonChancesCounter.Click += buttonChancesCounter_Click;
            r_ButtonStart.Click += buttonStart_Click;
        }

        public int NumberOfChances
        {
            get { return m_chancesCounter; }
        }

        private void buttonChancesCounter_Click(object sender, EventArgs e)
        {
            m_chancesCounter = m_chancesCounter < 10 ? m_chancesCounter + 1 : 4;
            r_ButtonChancesCounter.Text = string.Format("Number of chances: {0}", m_chancesCounter);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
