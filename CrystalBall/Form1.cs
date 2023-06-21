using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrystalBall
{
    public partial class Form1 : Form
    {
        bool active = false;
        string texto = "0";

        private void Start()
        {
            try
            {
                if (!active)
                {
                    serialPort1.Open();
                    active = true;
                    timer1.Enabled = true;
                    timer1.Interval = 50;
                    timer1.Start();
                }
                else
                {
                    serialPort1.Close();
                    active = false;
                    timer1.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            serialPort1.PortName = "COM6";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lblMsn_Click(object sender, EventArgs e)
        {

        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                string[] datos = serialPort1.ReadLine().Split('-');
                texto = datos[0];
            }
            catch (Exception ex) { }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                lblAnswer.Text = texto;
                Evaluate();
            }
            catch (Exception ex) { }
        }

        private void Evaluate()
        {
            int op = int.Parse(texto);
            switch (op)
            {
                case 0:
                    lblAnswer.Text = "Si";
                break;
                case 1:
                    lblAnswer.Text = "Es probable";
                break;
                case 2:
                    lblAnswer.Text = "Ciertamente";
                break;
                case 3:
                    lblAnswer.Text = "Buenas perspectivas";
                break;
                case 4:
                    lblAnswer.Text = "No es seguro";
                break;
                case 5:
                    lblAnswer.Text = "Pregunta de nuevo";
                break;
                case 6:
                    lblAnswer.Text = "Ni idea";
                break;
                case 7:
                    lblAnswer.Text = "No";
                break;

            }

        }
    }
}
