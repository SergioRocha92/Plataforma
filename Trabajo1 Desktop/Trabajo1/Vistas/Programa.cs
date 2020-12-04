using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabajo1.ffmpeg;

namespace Trabajo1.Vistas
{
    public partial class Programa : Form
    {

        private OpenFileDialog ventana;
        private string ruta;
        public Programa()
        {
            InitializeComponent();
        }

        private void Programa_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ventana = new OpenFileDialog();
            ventana.InitialDirectory = "C:\\Users\\Sergio\\Desktop";
            ventana.ShowDialog();
            ruta = ventana.FileName;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Codigo para abrir y leer el archivo
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Ffmpeg.Enviarcmd($"ffmpeg -i {ruta} -c copy -an C:\\Users\\Sergio\\Desktop\\song_sinaudio.mp4");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var checkedButton = groupBox1.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);
            Ffmpeg.Enviarcmd($"ffmpeg -i {ruta} C:\\Users\\Sergio\\Desktop\\video nuevo{checkedButton.Text}");
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // var checkedButton = groupBox1.Controls.OfType<RadioButton>()
             //                         .FirstOrDefault(r => r.Checked);
          //  Ffmpeg.Enviarcmd($"ffmpeg -i {ruta} -vf scale={checkedButton.Text} C:\\Users\\Sergio\\Desktop\\resolucioncambiada.mp4 
        }
    }
}

//* comandos ffmeg
 //* Extraer audio como mp3 o aac
//-acodec mp3, especificamos que utilice el codec para transcodifique a mp3

//ffmpeg -i video_entrada.mp4 -vn -acodec mp3 audio_salida.mp3
//–acodec aac, especificamos que utilice el codec para transcodifique a aac

//Extraer audio de un trozo del vídeo
//ffmpeg -i video_entrada.avi -ss 30 -to 60 -vn -acodec mp3 audio_salida.mp3
//-ss 30 -to 60, especifiamos que extraermos el audio, solo del segundo 30 a 60.