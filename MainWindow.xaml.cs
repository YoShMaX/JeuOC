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

namespace NombreMystereWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int randomed;
        int NbEssais;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            NouvellePartie();
        }

        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            int PickedNum = PickANumber();

            if (PickedNum > 0)
            {

                if (PickedNum != randomed)
                {
                    PickedNum = TryAgain(PickedNum);

                }
                else
                {
                    YouWin();
                }
            }
        }

        private void btnNouvellePartie_Click(object sender, RoutedEventArgs e)
        {
            NouvellePartie();
        }


        void YouWin()
        {
            textBlockInfo.Text = "Bravo, tu as gagné !!!";
        }

       
        int PickANumber()
        {
            string picked = textBoxEssai.Text;

            // Vérifier la validité de la saisie avec TryParse
            int PickedNum;
            bool isNumeric = int.TryParse(picked, out PickedNum);
            if (isNumeric == false)
            {
                textBlockInfo.Text = "Oups! Je n'ai pas compris, veuillez saisir un nombre entre 1 et 20 :";
            }
            else
            {
                textBlockInfo.Text = string.Empty;
            }

            return PickedNum;
        }

        void NouvellePartie()
        {
            randomed = GenereNombreAleatoire();
            textBlockInfo.Text = string.Empty;
            textBoxEssai.Text = string.Empty;
            NbEssais = 0;
            UpdateTry();
        }

        void UpdateTry()
        {
            textBlockNbEssai.Text = "Nombre d'essais : " + NbEssais;

        }

        int GenereNombreAleatoire()
        {
            return new Random().Next(1, 21);
        }

        int TryAgain(int PickedNum)
        {
            //On aide l’utilisateur : on lui indique si c’est plus ou moins
            if (PickedNum > randomed)
            {
                textBlockInfo.Text = "C'est moins";
            }
            else
            {
                textBlockInfo.Text = "C'est plus";
            }
            NbEssais = NbEssais + 1;
            UpdateTry();

            return PickedNum;
        }

    }
}
