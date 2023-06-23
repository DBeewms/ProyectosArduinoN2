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
        string texto = "La esfera dice:";
        string _puerto = "COM8";

        private void Start()
        {
            try
            {
                if (!active)
                {
                    serialPort1.Open();
                    active = true;
                    timer1.Enabled = true;
                    timer1.Interval =500;
                    timer1.Start();
                }
                else
                {
                    serialPort1.Close();
                    active = false;
                    timer1.Enabled = false;
                    timer1.Stop();
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
            serialPort1.PortName = _puerto; 
            Start();
        }

       

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                string[] datos = serialPort1.ReadLine().Split('-');
                texto = datos[0];
               // label1.Text = tam.ToString();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                //Evaluate();
                lblAnswer.Text = texto;
                this.Text = this.texto;
                
            }
            catch (Exception ex) {
                label1.Text = ex.Message;
            }
        }

        //private void Evaluate()
        //{
        //    int op = int.Parse(texto);
        //   // label1.Text = op.ToString();
        //    switch (op)
        //    {
        //        case 0:
        //            lblAnswer.Text = "Si";
        //        break;
        //        case 1:
        //            lblAnswer.Text = "Muy probable";
        //        break;
        //        case 2:
        //            lblAnswer.Text = "Ciertamente";
        //        break;
        //        case 3:
        //            lblAnswer.Text = "Parece bien";
        //        break;
        //        case 4:
        //            lblAnswer.Text = "No es seguro";
        //        break;
        //        case 5:
        //            lblAnswer.Text = "Intenta de nuevo";
        //        break;
        //        case 6:
        //            lblAnswer.Text = "Es incierto";
        //        break;
        //        case 7:
        //            lblAnswer.Text = "No";
        //        break;

        //    }

        //}

       

        private void btnPuerto_Click(object sender, EventArgs e)
        {
            _puerto = txtPuerto.Text.ToUpper();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void lblAnswer_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                int min = 1, max = 21;
                Random rnd = new Random();
                int question = rnd.Next(min,max+1);
                switch (question)
                {
                    case 1:
                        lblQuestion.Text = "¿Ingresaré a la UCA?";
                        break;
                    case 2:
                        lblQuestion.Text = "¿Aprenderé a programar?";
                        break;
                    case 3:
                        lblQuestion.Text = "¿Aprenderé acerca de hardware?";
                        break;
                    case 4:
                        lblQuestion.Text = "¿Mi novi@ me quiere?";
                        break;
                    case 5:
                        lblQuestion.Text = "¿Tendré un buen trabajo?";
                        break;
                    case 6:
                        lblQuestion.Text = "¿Seré un buen estudiante?";
                        break;
                    case 7:
                        lblQuestion.Text = "¿Aprobaré mis materias?";
                        break;
                    case 8:
                        lblQuestion.Text = "¿Aprobaré la prueba de aptitud?";
                        break;
                    case 9:
                        lblQuestion.Text = "¿Tendré una buena computadora?";
                        break;
                    case 10:
                        lblQuestion.Text = "¿Tendré tiempo para ir al gym?";
                        break;
                    case 11:
                        lblQuestion.Text = "¿Seré popular en la UCA?";
                        break;
                    case 12:
                        lblQuestion.Text = "¿Seré lo mejor para el mundo?";
                        break;
                    case 13:
                        lblQuestion.Text = "¿Aprobare Cálculo 1 en el primer semestre?";
                        break;
                    case 14:
                        lblQuestion.Text = "¿Aprenderé Arduino?";
                        break;
                    case 15:
                        lblQuestion.Text = "¿Aprenderé lenguaje C/C + +?";
                        break;
                    case 16:
                        lblQuestion.Text = "¿Aprenderé a armar una computadora?";
                        break;
                    case 17:
                        lblQuestion.Text = "¿Crearé juegos?";
                        break;
                    case 18:
                        lblQuestion.Text = "¿Crearé aplicaciones web?";
                        break;
                    case 19:
                        lblQuestion.Text = "¿Crearé aplicaciones móviles?";
                        break;
                    case 20:
                        lblQuestion.Text = "¿Tendré buena suerte en este año?";
                        break;
                    case 21:
                        lblQuestion.Text = "¿Tendré novi@?";
                        break;
                    default:
                        lblQuestion.Text = "Hacer pregunta...";
                        break;
                }
            }
            catch(Exception ex) { }
            
        }
    }
}
