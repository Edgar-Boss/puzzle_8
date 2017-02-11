using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication3
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        int[,] completo = new int[3, 3];
        private void button_Click(object sender, RoutedEventArgs e)
        {

            int[,] tablero = new int[3, 3];
            int[,] candidato = new int[3, 3];
            //int[,,] visitados = new int[50, 3, 3];
            int H = 0,haux=0;//marca errores
            int index = -1;
            string cad = "";

            //inicializar valores de tablero inicial 
            tablero[0, 0] = int.Parse(I00.Text);
            tablero[0, 1] = int.Parse(I01.Text);
            tablero[0, 2] = int.Parse(I02.Text);
            tablero[1, 0] = int.Parse(I10.Text);
            tablero[1, 1] = int.Parse(I11.Text);
            tablero[1, 2] = int.Parse(I12.Text);
            tablero[2, 0] = int.Parse(I20.Text);
            tablero[2, 1] = int.Parse(I21.Text);
            tablero[2, 2] = int.Parse(I22.Text);
            //inicializar valores de tablero completo
            int contador = 1;
            for (int k = 0; k < 3; k++)
            {
                for (int j = 0; j < 3; j++)
                {

                    completo[k, j] = contador;
                    contador++;
                }
            }

            completo[2, 2] = 0;
            ///////////////////////////////////////////////
            index = -1;

            bool mverror = false;
            for(int t=0;t<2;t++)
            {

                for (int k = 0; k < 2; k++)
                {//buscar en x
                    haux = 0;


                    
                    try
                    {
                        mover_x(tablero, index);
                    }
                    catch (Exception ex)
                    {
                        mverror = true;
                    }

                    haux = Compara_competo(tablero);

                    if (haux > H)
                    {
                        Copia_matriz(candidato, tablero);
                        H = haux;
                    }
                    
                    index = index * -1;

                    if (mverror == false)
                        mover_x(tablero, index);

                    mverror = false;

                }
                for (int k = 0; k < 2; k++)
                {//buscar en y
                    haux = 0;

                    try
                    {
                        mover_y(tablero, index);
                    }
                    catch (Exception)
                    {
                        mverror = true;
                    }

                    
                    haux = Compara_competo(tablero);

                    if (haux > H)
                    {
                        Copia_matriz(candidato, tablero);
                        H = haux;
                    }

                    index = index * -1;

                    if (mverror == false)
                        mover_y(tablero, index);

                    mverror = false;
                    


                }






                Copia_matriz(tablero, candidato);


            }





            cad = "";
            for (int m = 0; m < 3; m++)
            {

                for (int j = 0; j < 3; j++)
                {
                    cad +=tablero[m, j].ToString();
                    cad += ",";

                }
                cad += Environment.NewLine;

            }


            prueba.Text = cad;


















        }





        public void mover_x(int[,] tablero,int index)
        {

            int[,] pos0 = new int[1, 2];

            busca_pos0(tablero, pos0);

            tablero[pos0[0, 0], pos0[0, 1]] = tablero[pos0[0, 0]+index, pos0[0, 1]];
            tablero[pos0[0, 0]+index, pos0[0, 1]] = 0;



        }


        public void mover_y(int[,] tablero, int index)
        {

            int[,] pos0 = new int[1, 2];
            busca_pos0(tablero, pos0);

            tablero[pos0[0, 0], pos0[0, 1]] = tablero[pos0[0, 0] , pos0[0, 1]+index];
            tablero[pos0[0, 0] , pos0[0, 1]+index] = 0;
        }

        public void busca_pos0(int[,] tablero,int[,] pos0)
        {

            for (int k = 0; k < 3; k++)//buscar 0 (espacio)
            {

                for (int j = 0; j < 3; j++)
                {

                    if (tablero[k, j] == 0)
                    {
                        pos0[0, 0] = k;
                        pos0[0, 1] = j;
                    }

                }


            }

        }

        public int Compara_competo(int[,] tablero)
        {
            int haux=0;

            for (int k = 0; k < 3; k++)
            {
                for (int j = 0; j < 3; j++)
                {

                    if (tablero[k, j] == completo[k, j])
                        haux++;



                }
            }

            return haux;
        }

        public void Copia_matriz(int [,] candidato,int[,] tablero)
        {

            for (int k = 0; k < 3; k++)
            {
                for (int j = 0; j < 3; j++)
                {

                    candidato[k, j] = tablero[k, j];



                }
            }
        }

        

    }
}
