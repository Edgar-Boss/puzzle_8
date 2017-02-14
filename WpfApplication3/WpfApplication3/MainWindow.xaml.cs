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

            int[,,] tablero = new int[10,3, 3];
            int[,,] candidato = new int[10,3, 3];
            int indtab=0,indcad=0;
            int[,,] visitados = new int[500, 3, 3];
            int indvis = 0;
            int H = 0,haux=0;//marca errores
            int index = -1;
            string cad = "";
            bool rep = false;
            TextBox[] V = new TextBox[2000];//textbox donde se mostraran las vertices


            //inicializar valores de tablero inicial 
            visitados[0, 0, 0]= tablero[indtab,0, 0] = int.Parse(I00.Text);
            visitados[0, 0, 1] = tablero[indtab,0, 1] = int.Parse(I01.Text);
            visitados[0, 0, 2] = tablero[indtab, 0, 2] = int.Parse(I02.Text);
            visitados[0, 1, 0] = tablero[indtab, 1, 0] = int.Parse(I10.Text);
            visitados[0, 1, 1] = tablero[indtab, 1, 1] = int.Parse(I11.Text);
            visitados[0, 1, 2] = tablero[indtab, 1, 2] = int.Parse(I12.Text);
            visitados[0, 2, 0] = tablero[indtab, 2, 0] = int.Parse(I20.Text);
            visitados[0, 2, 1] = tablero[indtab, 2, 1] = int.Parse(I21.Text);
            visitados[0, 2, 2] = tablero[indtab, 2, 2] = int.Parse(I22.Text);
            indvis++;
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
            

            index = -1;

            bool mverror = false;


            int lv = -100;
            int lh = -250;
            int contv = 0;
            
            while (H < 9)
            //for (int t = 0; t < 742; t++)
            {




                for (int r = 0; r <= indtab; r++)
                {

                  //  MessageBox.Show(r.ToString());
                    

                H = 0;
                for (int k = 0; k < 2; k++)
                {//buscar en x
                    haux = 0;

                    try
                    {

                       


                        mover_x(tablero, index, indtab);//mueve en eje 
                       


                        rep = Busca_en_vistados(tablero, visitados, indvis, indtab);//busca que no este repetido

                        if (rep == false)
                        {

                                try
                                {
                                    Copia_vist(visitados, tablero, indvis, indtab);//guarda a visitados
                                    indvis++;
                                    haux = Compara_competo(tablero, indtab);//busca cuantos aciertos tiene el nuevo movimiento


                                    if (haux > H)//si es mayor al aterior entra
                                    {
                                        indcad = 0;
                                        Copia_matriz(candidato, tablero, indtab, indcad);//copia el nuevo movimiento a candidato 
                                        H = haux;// guarda en H para seguir comparando

                                    }
                                    else if (haux == H)
                                    {
                                        indcad++;
                                        Copia_matriz(candidato, tablero, indtab, indcad);

                                    }
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("Excepcion x");
                                }
                           


                        }




                    }
                    catch (Exception ex)
                    {
                        mverror = true;
                    }

                    index = index * -1;




                    if (mverror == false)
                    {

                        mover_x(tablero, index, indtab);

                    }


                    mverror = false;

                }


                for (int k = 0; k < 2; k++)
                {//buscar en y
                    haux = 0;

                    try
                    {


                        mover_y(tablero, index, indtab);//mueve en eje y

                        rep = Busca_en_vistados(tablero, visitados, indvis, indtab);


                        if (rep == false)
                        {
                                try
                                {
                                    Copia_vist(visitados, tablero, indvis, indtab);//guarda a visitados
                                    indvis++;
                                    haux = Compara_competo(tablero, indtab);

                                    if (haux > H)
                                    {
                                        indcad = 0;
                                        Copia_matriz(candidato, tablero, indtab, indcad);
                                        H = haux;
                                    }
                                    else if (haux == H)
                                    {
                                        indcad++;
                                        Copia_matriz(candidato, tablero, indtab, indcad);

                                    }
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("excepcion");
                                }
                            
                        }



                    }
                    catch (Exception ex)
                    {
                        mverror = true;
                    }



                    index = index * -1;

                    if (mverror == false)
                        mover_y(tablero, index, indtab);

                    mverror = false;



                }


            }


                





                

                for (int m= 0; m < 3; m++)
                {
                    lv = -100;   
                    for (int j = 0; j < 3; j++)
                    {


                        
                        V[contv] = new TextBox();

                        V[contv].Text = tablero[indtab, m, j].ToString();
                        V[contv].Height = 19;
                        V[contv].Width = 26;
                        V[contv].Margin = new Thickness(lv, 54, 0, 0);
                        stak.Children.Add(V[contv]);
                        lv += 50;
                        contv++;
                        
                    }
                    
                    lh += 38;
                }
                MessageBox.Show(lh.ToString());
                //lh += 70;




                indtab = indcad;
                cand_tab(candidato, indcad, tablero, indtab);
               
                cad = "";
                for (int m = 0; m < 3; m++)
                {

                    for (int j = 0; j < 3; j++)
                    {
                        cad += tablero[indtab, m, j].ToString();
                        cad += ",";

                    }

                    cad += Environment.NewLine;


                }

                cad += "==";
                cad += Environment.NewLine;
                cad += Environment.NewLine;
                prueba.Text = cad;







            }



            

             

           

         








        }


        public void cand_tab(int[,,] cand , int indcand,int[,,] tablero,int indtab )
        {
            for (int j=0;j<=indcand;j++)
            {
                for (int k=0;k<3;k++)
                {
                    for (int l=0;l<3;l++)
                    {
                        tablero[j, k, l] = cand[j, k, l];
                    }

                }
            }

        }
        public void mover_x(int[,,] tablero,int index,int indtab)
        {

            int[,] pos0 = new int[1, 2];

            busca_pos0(tablero, pos0,indtab);

            tablero[indtab, pos0[0, 0], pos0[0, 1]] = tablero[indtab, pos0[0, 0]+index, pos0[0, 1]];
            tablero[indtab, pos0[0, 0]+index, pos0[0, 1]] = 0;



        }


        public void mover_y(int[,,] tablero, int index,int indtab)
        {

            int[,] pos0 = new int[1, 2];
            busca_pos0(tablero, pos0,indtab);

            tablero[indtab, pos0[0, 0], pos0[0, 1]] = tablero[indtab, pos0[0, 0] , pos0[0, 1]+index];
            tablero[indtab, pos0[0, 0] , pos0[0, 1]+index] = 0;
        }

        public void busca_pos0(int[,,] tablero,int[,] pos0,int indtab)
        {

            for (int k = 0; k < 3; k++)//buscar 0 (espacio)
            {

                for (int j = 0; j < 3; j++)
                {

                    if (tablero[indtab, k, j] == 0)
                    {
                        pos0[0, 0] = k;
                        pos0[0, 1] = j;
                    }

                }


            }

        }

        public int Compara_competo(int[,,] tablero, int indtab)
        {
            int haux=0;

            for (int k = 0; k < 3; k++)
            {
                for (int j = 0; j < 3; j++)
                {

                    if (tablero[indtab,k, j] == completo[k, j])
                        haux++;



                }
            }

            return haux;
        }

        public void Copia_matriz(int [,,] candidato,int[,,] tablero,int indtab,int indcand)
        {

            

            for (int k = 0; k < 3; k++)
            {
                for (int j = 0; j < 3; j++)
                {

                    candidato[indcand,k, j] = tablero[indtab,k, j];

                }
            }
        }


        public void Copia_vist(int[,,] visitados, int[,,] tablero,int index,int indtab) 
        {

            for (int k = 0; k < 3; k++)
            {
                for (int j = 0; j < 3; j++)
                {

                    visitados[index, k, j] = tablero[indtab,k, j];



                }
            }
        }

        public bool Busca_en_vistados(int[,,] Tablero, int[,,] visitados, int indvisit,int indtab)
        {

            int contador = 0;
            bool rep = false;
            for (int k = 0; k <= indvisit; k++)
            {
                contador = 0;

                for (int j = 0; j < 3; j++)
                {
                    for (int l = 0; l < 3; l++)
                    {


                        if (Tablero[indtab,j, l] == visitados[k, j, l])
                        {

                            contador++;
                        }
                    }
                }
                
                if (contador >= 8)
                {
                    rep = true;
                    break;
                }



            }

            return rep;
        }

    }


}






