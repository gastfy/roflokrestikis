using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isStarted = false;
        bool isEnd = false;
        int moves;
        bool Xmove = true;
        int XWINS = 0;
        int OWINS = 0;
        int DRAWS = 0;
        public MainWindow()
        {
            InitializeComponent(); //я забил на потоки и решил сделать все втупую потому что от потоков у меня ломался код поэтому без рофлофичи которую я хотел добавить (9(((
        }
        private void check() {
            if (b1.Content == "X" && b2.Content == "X" && b3.Content == "X" || b4.Content == "X" && b5.Content == "X" && b6.Content == "X" || b7.Content == "X" && b8.Content == "X" && b9.Content == "X")//горизонтальный чек
            {
                MessageBox.Show("Крестики выиграли!!");
                XWINS += 1;
                KLabel.Content = XWINS;
                isEnd = true;
            }
            else if (b1.Content == "X" && b4.Content == "X" && b7.Content == "X" || b2.Content == "X" && b5.Content == "X" && b8.Content == "X" || b3.Content == "X" && b6.Content == "X" && b9.Content == "X")//вертикальный чек
            {
                MessageBox.Show("Крестики выиграли!!");
                XWINS += 1;
                KLabel.Content = XWINS;
                isEnd = true;
            }
            else if (b1.Content == "X" && b5.Content == "X" && b9.Content == "X" || b3.Content == "X" && b5.Content == "X" && b7.Content == "X")
            {
                MessageBox.Show("Крестики выиграли!!");
                XWINS += 1;
                KLabel.Content = XWINS;
                isEnd = true;
            }
            else if (b1.Content == "O" && b2.Content == "O" && b3.Content == "O" || b4.Content == "O" && b5.Content == "O" && b6.Content == "O" || b7.Content == "O" && b8.Content == "O" && b9.Content == "O")//горизонтальный чек
            {
                MessageBox.Show("Нолики выиграли!!");
                OWINS += 1;
                NLabel.Content = OWINS;
                isEnd = true;
            }
            else if (b1.Content == "O" && b4.Content == "O" && b7.Content == "O" || b2.Content == "O" && b5.Content == "O" && b8.Content == "O" || b3.Content == "O" && b6.Content == "O" && b9.Content == "O")//вертикальный чек
            {
                MessageBox.Show("Нолики выиграли!!");
                OWINS += 1;
                NLabel.Content = OWINS;
                isEnd = true;
            }
            else if (b1.Content == "O" && b5.Content == "O" && b9.Content == "O" || b3.Content == "O" && b5.Content == "O" && b7.Content == "O")
            {
                MessageBox.Show("Нолики выиграли!!");
                OWINS += 1;
                NLabel.Content = OWINS;
                isEnd = true;
            }
            else if (b1.Content != "" && b2.Content != "" && b3.Content != "" && b4.Content != "" && b5.Content != "" && b6.Content != "" && b7.Content != "" && b8.Content != "" && b9.Content != "" && !isEnd)
            {
                MessageBox.Show("Ничья!!");
                DRAWS += 1;
                NicLabel.Content = DRAWS;
                isEnd = true;
            }
            if (isEnd)
            {
                if (Xmove) { Xmove = false; }
                else { Xmove = true; }
                whoIs.Content = "";
                isEnd = false;
                isStarted = false;
                b1.Content = "";
                b2.Content = "";
                b3.Content = "";
                b4.Content = "";
                b5.Content = "";
                b6.Content = "";
                b7.Content = "";
                b8.Content = "";
                b9.Content = "";
                moves = 0;
            }
        }

        private void RoboMove(bool iscan)
        {
            List<Button> btns = new List<Button>();
            btns.Add(b1);
            btns.Add(b2);
            btns.Add(b3);
            btns.Add(b4);
            btns.Add(b5);
            btns.Add(b6);
            btns.Add(b7);
            btns.Add(b8);
            btns.Add(b9);
            if (moves < 5 && iscan)
            {
                Random rnd = new Random();
                int choose = rnd.Next(0, 8);
                while (true)
                {
                    if (btns[choose].Content == "X" || btns[choose].Content == "O")
                    {
                        choose = rnd.Next(0, 8);
                    }
                    else
                    {
                        if (Xmove)
                        {
                            btns[choose].Content = "O";
                            break;
                        }
                        else
                        {
                            btns[choose].Content = "X";
                            break;
                        }
                    }
                }
            }
        }
        private void B_Click(object sender, RoutedEventArgs e)
        {
            List<Button> btns = new List<Button>();
            btns.Add(b1);
            btns.Add(b2);
            btns.Add(b3);
            btns.Add(b4);
            btns.Add(b5);
            btns.Add(b6);
            btns.Add(b7);
            btns.Add(b8);
            btns.Add(b9);


            if (isStarted)
            {
                bool iscan;
                if ((sender as Button).Content != "")
                {
                    whoIs.Content = "Вы не можете туда сходить!\nПопробуйте еще раз!";
                    iscan = false;
                }
                else
                {
                    if (Xmove)
                    {
                        (sender as Button).Content = "X";
                        iscan = true;
                        moves += 1;
                        whoIs.Content = "";
                    }
                    else
                    {
                        (sender as Button).Content = "O";
                        iscan = true;
                        moves += 1;
                        whoIs.Content = "";
                    }
                }
                RoboMove(iscan);
                check();
            }
            else
            {
                whoIs.Content = "Вы не начали игру!";
            }

        }
        private void Start_end(object sender, RoutedEventArgs e)
        {
            List<Button> btns = new List<Button>();
            btns.Add(b1);
            btns.Add(b2);
            btns.Add(b3);
            btns.Add(b4);
            btns.Add(b5);
            btns.Add(b6);
            btns.Add(b7);
            btns.Add(b8);
            btns.Add(b9);
            if (e.OriginalSource == startgame)
            {
                if (isStarted)
                {
                    whoIs.Content = "Игра уже начата емае";
                }
                else
                {
                    whoIs.Content = "";
                    isStarted = true;
                    if (!Xmove)
                    {
                        Random rnd = new Random();
                        int choose = rnd.Next(0, 8);
                        while (true)
                        {
                            if (btns[choose].Content == "X" || btns[choose].Content == "O")
                            {
                                choose = rnd.Next(0, 8);
                            }
                            else
                            {
                                btns[choose].Content = "X";
                                break;
                            }
                        }
                    }

                }
            }
            else if (e.OriginalSource == end_button)
            {

                if (isStarted)
                {
                    if (Xmove) { Xmove = false; }
                    else { Xmove = true; }
                    whoIs.Content = "";
                    isStarted = false;
                    isEnd = false;
                    moves = 0;
                    b1.Content = "";
                    b2.Content = "";
                    b3.Content = "";
                    b4.Content = "";
                    b5.Content = "";
                    b6.Content = "";
                    b7.Content = "";
                    b8.Content = "";
                    b9.Content = "";
                    MessageBox.Show("Ну ты и bruh. Че сдался то?");

                }
                else
                {
                    whoIs.Content = "Игра еще не начата!";
                }
            }
        }

    }
}
/*
 * глупый и тупой
 * глупый и тупой
 * завтра буду не такой                                         кста альбом ахиренный
 * глупый и тупой
 * глупый и тупой
 * завтра буду не такооййй...
 */
