using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * Autores:
 * Diego Mora
 * Carlos Talavera
 * Tutor:
 * José Durán
 * 
 */

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
                        lblQuestion.Text = "¿Serás un creador famoso de videojuegos?";
                        break;
                    case 2:
                        lblQuestion.Text = "¿Aprenderás a tocar un instrumento musical?";
                        break;
                    case 3:
                        lblQuestion.Text = "¿Tendrás buena suerte en los próximos 7 años?";
                        break;
                    case 4:
                        lblQuestion.Text = "¿Encontrarás a tu pareja ideal en la universidad?";
                        break;
                    case 5:
                        lblQuestion.Text = "¿Serás súper popular en la UCA?";
                        break;
                    case 6:
                        lblQuestion.Text = "¿Tu novi@ te quiere?";
                        break;
                    case 7:
                        lblQuestion.Text = "¿Serás un maestro del Arduino?";
                        break;
                    case 8:
                        lblQuestion.Text = "¿Viajarás por el mundo en el 2024?";
                        break;
                    case 9:
                        lblQuestion.Text = "¿Serás un maestro de la Inteligencia Artificial?";
                        break;
                    case 10:
                        lblQuestion.Text = "¿Tendrás una computadora nueva en navidad?";
                        break;
                    case 11:
                        lblQuestion.Text = "¿Trabajarás en una empresa importante?";
                        break;
                    case 12:
                        lblQuestion.Text = "¿Aprenderás un nuevo idioma este año?";
                        break;
                    case 13:
                        lblQuestion.Text = "¿Aprenderé a volar con realidad virtual?";
                        break;
                    case 14:
                        lblQuestion.Text = "¿Te gusta alguien de tu grupo de clases?";
                        break;
                    case 15:
                        lblQuestion.Text = "¿Venderías a tu mascota por un millón?";
                        break;
                    case 16:
                        lblQuestion.Text = "¿Te gustaría vivir en otro planeta?";
                        break;
                    case 17:
                        lblQuestion.Text = "¿Aceptarías convertirte en un robot?";
                        break;
                    case 18:
                        lblQuestion.Text = "¿Te gustaría conversar con un extraterrestre?";
                        break;
                    case 19:
                        lblQuestion.Text = "¿Vivirías en la selva, alejado de la civilización?";
                        break;
                    case 20:
                        lblQuestion.Text = "¿Serías capaz de pasar tres días sin dormir?";
                        break;
                    case 21:
                        lblQuestion.Text = "¿Seré parte del equipo de fútbol de la UCA?";
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
