using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Windows.Forms.Design;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;

namespace WinForms_Игра_в_дурака
{
    [Serializable]
    public partial class Form1 : Form
    {
        private int nKolich =0;
        private Timer vTimer = new Timer();// создаем таймер
        private GameMethods gameMethods; // Класс в котором собраны все основные методы игры
        /// <summary>
        /// Счетчик очередности хода: 0 - ходит игрок, 1 - ходит компьютер
        /// </summary>
        private int nNumGamer;
        public Form1()
        {
            InitializeComponent();
            //определяем обработчик события для таймера
            vTimer.Interval = 2000;
            vTimer.Tick += new EventHandler(ShowTimer);
            nNumGamer = 0;
        }
        /// <summary>
        /// Играет комп
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowTimer(object sender, EventArgs e)
        {
            nNumGamer = (nNumGamer + 2) % 2;
            // Ходит игрок, комп отбивается
            if (nNumGamer == 0)
            {
                try
                {
                    if (gameMethods.LogicCard())
                    {
                        gameMethods.PokazCard();
                    }
                    else 
                    {
                        OtbojForm1();
                        vTimer.Stop();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("GGGGGGGOOOPPP" + ex.Message);
                }
            }
            // Ходит комп, игрок отбивается
            else
            {
                try
                {
                    if (gameMethods.GetMYCount == 0)
                    {
                        if (gameMethods.GetKozirCount == 0)
                        {
                            MessageBox.Show("Игра закончена!");
                            vTimer.Stop();
                            return;
                        }
                        nNumGamer++; // передача хода игроку
                        OtbojForm1();
                        vTimer.Stop();
                    }
                    bool temp = gameMethods.LogicKomp();
                    if (temp)
                    {
                        gameMethods.PokazCard();
                    }
                    if (!temp)
                    {
                        nNumGamer++; // передача хода игроку
                        OtbojForm1();
                        vTimer.Stop();
                    }
                }
                catch (Exception es)
                {
                    MessageBox.Show("Нарушена логика когда комп атакует" + es.Message);
                }
            }
            vTimer.Stop();
        }
        // Новая игра
        private void button1_Click(object sender, EventArgs e)
        {
            gameMethods = new GameMethods(pictureBox1);
            gameMethods.NewGame();
            nKolich = gameMethods.GetListCount + gameMethods.GetKozirCount;
            label1.Text = String.Format("Кол-во карт в колоде: " + nKolich.ToString());
            label2.Text = String.Format("Кол-во карт в отбое: " + gameMethods.GetOtbojCount.ToString());
        }

        /// <summary>
        /// Событие при загрузке формы Form1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
           // gameMethods = new GameMethods(pictureBox1);
        }

        /// <summary>
        /// Выбор карты путем клика по ней мыщью, карта перемещается на игровое поле
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            nNumGamer = (nNumGamer + 2) % 2;
            try
            {
                if (nNumGamer == 0 && gameMethods.GetCompCount == 0) // У компа кончились карты
                {
                    MessageBox.Show("Нажмите отбой");
                    return;
                }
                bool temp = gameMethods.HodUser_1(nNumGamer, e.X, e.Y);
                if (temp)
                {
                    if (nNumGamer == 0) //Если игрок 1 атакует, то компьютер "думает" 2 сек, чтобы отбиться
                    {
                        gameMethods.PokazCard();
                        //Игрок 2 (компьютер) бьёт карту игрока 1
                        vTimer.Start();
                    }
                    else if (nNumGamer == 1) //Если игрок 1 отбивается, то компьютер "думает" 2 сек, чтобы подбросить карту
                    {
                        if (gameMethods.GameStolCount == 0) return;
                        gameMethods.PokazCard();
                        //Comp атакует
                        vTimer.Start();// Игрок 2 "думает" 2 секунды, чтобы подбросить карту
                    }
                }
                else if (!temp) return;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Индекс FFF/ " + ex.Message);
            }
        }
        /// <summary>
        /// Перерисовка игрового поля после изменения размеров формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            gameMethods.PokazCard();
        }
        /// <summary>
        /// Кнопка "Отбой"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OtbojButton2_Click(object sender, EventArgs e)
        {
            if (nNumGamer == 0) // Кнопка действует только когда ходит игрок
            {
                OtbojForm1();
                nNumGamer++; // Передача хода компьютеру
                vTimer.Start();
            }
            else return;
        }

        private void OtbojForm1()
        {
            gameMethods.OtbojMethod();
            gameMethods.TakeCards();
            gameMethods.PokazCard();
            nKolich = gameMethods.GetListCount + gameMethods.GetKozirCount;
            label1.Text = String.Format("Кол-во карт в колоде: " + nKolich.ToString());
            label2.Text = String.Format("Кол-во карт в отбое: " + gameMethods.GetOtbojCount.ToString());
        }
        /// <summary>
        /// Кнопка "Забираю"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZabirayuButton_Click(object sender, EventArgs e)
        {
            if (nNumGamer == 1)// Кнопка действует только когда ходит comp
            {
                gameMethods.ZabirayuCards();
                gameMethods.TakeCards();
                gameMethods.PokazCard();
                nKolich = gameMethods.GetListCount + gameMethods.GetKozirCount;
                label1.Text = String.Format("Кол-во карт в колоде: " + nKolich.ToString());
                label2.Text = String.Format("Кол-во карт в отбое: " + gameMethods.GetOtbojCount.ToString());
                vTimer.Start();
            }
            else return;
        }
        /// <summary>
        /// Новая игра. Контекстное меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewGameContextMenu_Click(object sender, EventArgs e)
        {
            gameMethods.NewGame();
            nKolich = gameMethods.GetListCount + gameMethods.GetKozirCount;
            label1.Text = String.Format("Кол-во карт в колоде: " + nKolich.ToString());
            label2.Text = String.Format("Кол-во карт в отбое: " + gameMethods.GetOtbojCount.ToString());
        }
        /// <summary>
        /// Забираю. Контекстное меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZabirayuContextMenu_Click(object sender, EventArgs e)
        {
            if (nNumGamer == 1)// Кнопка действует только когда ходит comp
            {
                gameMethods.ZabirayuCards();
                gameMethods.TakeCards();
                gameMethods.PokazCard();
                nKolich = gameMethods.GetListCount + gameMethods.GetKozirCount;
                label1.Text = String.Format("Кол-во карт в колоде: " + nKolich.ToString());
                label2.Text = String.Format("Кол-во карт в отбое: " + gameMethods.GetOtbojCount.ToString());
                vTimer.Start();
            }
            else return;
        }
        /// <summary>
        /// Отбой. Контекстное меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OtbojContextMenu_Click(object sender, EventArgs e)
        {
            if (nNumGamer == 0) // Кнопка действует только когда ходит игрок
            {
                OtbojForm1();
                nNumGamer++; // Передача хода компьютеру
                vTimer.Start();
            }
            else return;
        }
        /// <summary>
        /// Меню "Прервать игру"
        /// Сериализация в Xml файл (сохранение данных класса GameMethods)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SerialisableXMLMenu_Click(object sender, EventArgs e)
        {
            gameMethods.NumHod = nNumGamer;
            FileStream FS = new FileStream(@"..\\..\\GameFile.dat", FileMode.Create, FileAccess.ReadWrite);
            BinaryFormatter BF = new BinaryFormatter();
            BF.Serialize(FS, gameMethods);
            FS.Close();
            this.Close(); //Form1 закрывается
        }
        /// <summary>
        /// Продолжить игру
        /// Десериалзация
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeSerialisMenu_Click(object sender, EventArgs e)
        {
            try
            {
                BinaryFormatter BF = new BinaryFormatter();//Перематываем в начало файла курсор по файлу
                using (Stream reader = new FileStream(@"..\\..\\GameFile.dat", FileMode.Open))
                {
                    // Call the Deserialize method to restore the object's state.
                    GameMethods gameMethods1;
                    gameMethods1 = (GameMethods)BF.Deserialize(reader);
                    gameMethods = gameMethods1;
                    nNumGamer = gameMethods.NumHod;
                    gameMethods.PokazCard();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Перерисовка окна при использовании прокрутки Scroll
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Scroll(object sender, ScrollEventArgs e)
        {
            gameMethods.PokazCard();
        }
    }
}
