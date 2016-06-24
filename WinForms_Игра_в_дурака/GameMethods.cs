using System;
using System.Collections.Generic;
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
    public class GameMethods
    {
        /// <summary>
        /// Колода карт
        /// </summary>
        private List<Card> listCard;
        /// <summary>
        /// Карты игрока
        /// </summary>
        private List<Card> myCards;
        /// <summary>
        /// Карты компьютера
        /// </summary>
        private List<Card> compCards;
        private List<Card> kozir; //Козырь
        private List<Card> gameStol;// Игровое поле
        private List<Card> otboj; // Карты отбоя
        private Random rand;
        private int mast; // масть козыря
        [NonSerialized]
        public Control pictureBox1; //Элемент управления (зеленый фон)
        private List<int> compNumCardOtboj; // Для логики компа
        private int numHod; // Очередь хода для сериализации
        public int NumHod
        {
            get {return numHod;}
            set { numHod = value;}
        }
        public int GameStolCount
        {
            get { return gameStol.Count;}
        }

        public int GetListCount
        {
            get { return listCard.Count ;}
        }

        public int GetOtbojCount
        {
            get { return otboj.Count; }
        }
        public int GetKozirCount
        {
            get { return kozir.Count; }
        }
        public int GetMYCount
        {
            get { return myCards.Count; }
        }
        public int GetCompCount
        {
            get { return compCards.Count; }
        }
        public GameMethods() { }
        public GameMethods(Control pictureBox1)
        {
            IniziliasirtCardscs.MyIniziliasir();
            rand = new Random();
            myCards = new List<Card>();
            compCards = new List<Card>();
            listCard = new List<Card>(36);
            kozir = new List<Card>(1); // Козырь
            gameStol = new List<Card>();
            otboj = new List<Card>(); // Формирование списка карт отбоя
            this.pictureBox1 = pictureBox1;
            compNumCardOtboj = new List<int>();
        }

        public void OtbojMethod()
        {
            foreach (Card temp in gameStol)
            {
                otboj.Add(temp);
            }
            gameStol.Clear();
        }

        /// <summary>
        /// Новая игра
        /// </summary>
        public void NewGame()
        {
            myCards.Clear();
            gameStol.Clear();
            compCards.Clear();
            kozir.Clear();
            otboj.Clear();
            listCard.Clear();
            CreatListCard();
            pictureBox1.Refresh(); // Очистка ирового поля
            TakeCards(); 
            TakeKozir();
            PokazCard();
        }

        public void ZabirayuCards()
        {
            foreach (Card prt in gameStol)
            {
                myCards.Add(prt);
            }
            gameStol.Clear();
        }
        /// <summary>
        /// Игроки берут карты
        /// </summary>
        public void TakeCards()
        {
            int i = 0;
            while (listCard.Count > 0 || kozir.Count > 0)
            {
                i = (i + 2) % 2;
                if (i == 0 && myCards.Count < 6)
                {
                    try
                    {
                        // Если в колоде нет карт
                        if (listCard.Count == 0) throw new Exception(" ");
                        else
                        {
                            int nKnum;
                            if (listCard.Count == 1) nKnum = 0;
                            else nKnum = rand.Next(0, listCard.Count() - 1);
                            myCards.Add(listCard[nKnum]);
                            listCard.RemoveAt(nKnum);
                        }
                    }
                    // Если в колоде нет карт
                    catch (Exception)
                    {
                        try
                        {
                            if (kozir.Count == 0) return;//throw new Exception(" ");
                            else
                            {
                                myCards.Add(kozir[0]);
                                kozir.Clear();
                            }
                        }
                        // Если в колоде нет карт и нет козырной карты
                        catch (Exception)
                        {
                            continue;
                        }
                    }
                }
                // Компьютер берёт из колоды 6 карт
                // прверка сколько карт на руках у Компьютера
                else if (i == 1 && compCards.Count < 6)
                {
                    try
                    {
                        // Если в колоде нет карт
                        if (listCard.Count == 0) throw new Exception(" ");
                        else
                        {
                            int nKnum;
                            if (listCard.Count == 1) nKnum = 0;
                            else nKnum = rand.Next(0, listCard.Count() - 1);
                            compCards.Add(listCard[nKnum]);
                            listCard.RemoveAt(nKnum);
                        }
                    }
                    // Если в колоде нет карт
                    catch (Exception)
                    {
                        try
                        {
                            if (kozir.Count == 0) return;//throw new Exception(" ");
                            else
                            {
                                compCards.Add(kozir[0]);
                                kozir.Clear();
                            }
                        }
                        // Если в колоде нет карт и нет козырной карты
                        catch (Exception)
                        {
                            continue;
                        }
                    }
                }
                i++;
                if (myCards.Count >= 6 && compCards.Count >= 6) return;
                if (listCard.Count == 0 && kozir.Count == 0) return;
            }
            return;
        }
        /// <summary>
        /// Высвечивается козырь
        /// </summary>
        public void TakeKozir()
        {
            int nKnum = rand.Next(0, listCard.Count());
            kozir.Add(listCard[nKnum]);
            mast = kozir[0].Suit;
            listCard.RemoveAt(nKnum);
        }

        /// <summary>
        /// Показ колоды карт
        /// </summary>
        private void ShowListCard()
        {
            if (listCard.Count == 0) return;
            for (int i = 0; i < listCard.Count; i++)
            {
                listCard[i].DrawDeck(pictureBox1.CreateGraphics(), 10, 180);
            }
        }

        
        /// <summary>
        /// Показ карт игрока
        /// </summary>
        private void ShowmyCard()
        {
            for (int i = 0; i < myCards.Count; i++)
            {
                myCards[i].DrawFace(pictureBox1.CreateGraphics(), 100 + i * 80, 300);
            }
        }

        /// <summary>
        /// Показ карт компьютера
        /// </summary>
        private void ShowcompCard()
        {
            for (int i = 0; i < compCards.Count; i++)
            {
                //compCards[i].DrawFace(pictureBox1.CreateGraphics(), 100 + i * 80, 50);
                compCards[i].DrawDeck(pictureBox1.CreateGraphics(), 100 + i * 80, 50);//Тыльная сторона карт
            }
        }

        /// <summary>
        /// Показ карт игрового поля (стола)
        /// </summary>
        public void ShowGameStolCard()
        {
            if (gameStol.Count == 0) return;
            for (int i = 0; i < gameStol.Count; i++)
            {
                gameStol[i].DrawFace(pictureBox1.CreateGraphics(), 200 + i * 10, 180);
            }
        }
        /// <summary>
        /// Показ козыря
        /// </summary>
        public void ShowKozir()
        {
            if (kozir.Count == 0) return;
            kozir[0].DrawFace(pictureBox1.CreateGraphics(), 20, 150);
        }

        public void ShowOtboj()
        {
            for (int i = 0; i < otboj.Count; i++)
            {
                //otboj[i].DrawFace(pictureBox1.CreateGraphics(), 500 + i * 10, 150+i*5);
                otboj[i].DrawDeck(pictureBox1.CreateGraphics(), 500 + i * 10, 150 + i * 5);//Тыльная сторона карт
            }
        }
        /// <summary>
        /// Показ всего, что назодится на игровом поле
        /// </summary>
        public void PokazCard()
        {
            pictureBox1.Refresh();// Перерисовка
            ShowGameStolCard(); // Показ карт игрового поля (стола)
            ShowListCard(); // Показ колоды
            ShowmyCard(); // Показ карт игрока
            ShowcompCard(); // Показ карт компьютера
            ShowKozir();
            ShowOtboj();
        }

        /// <summary>
        /// Формирование колоды карт
        /// </summary>
        private void CreatListCard()
        {
            if (listCard.Count == 0)
            {
                int i, k, CardId, suit, face;
                //Создаем колоду из 36 карт
                for (k = 0; k <= 3; k++)
                {
                    for (i = 1; i <= 9; i++)
                    {
                        if ((i - 1 + k * 9) % 9 == 0)
                        {
                            CardId = ((i - 1) * 4 + k);
                            face = 14;//Номинал карты
                        }
                        else
                        {
                            CardId = (i + 4 - 1) * 4 + k;
                            face = i + 4;
                        }
                        suit = k;
                        listCard.Add(new Card(CardId, 1, suit, face));
                    }
                }
            }
            else return;
        }

        /// <summary>
        /// Игрок выбирает карту для хода
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int SelectCard(int x, int y)
        {
            int k = 0;// номер карты
            // Координаты щулчка клавиши мыши*
            for (int i = 0; i < myCards.Count; i++)
            {
                if ((x > 100 + 80 * i && x < 130 + 80 * i + 70) && (y > 300 && y < 300 + 100))
                {
                   k = i;
                }
            }
            return k;
        }

        /// <summary>
        /// Ходит игрок 
        /// </summary>
        /// <param name="nNumGamer"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool HodUser_1(int nNumGamer,int x,int y)
        {
	        int j=0;
	        int numcard=0; // номер карты, которой ходит игрок 1
	        numcard = SelectCard(x,y);
	        // Если игрок подкинул неверно карту
	        if (nNumGamer==0 && gameStol.Count!=0)
	        {
                try
		        {
			        for (int i=0; i<gameStol.Count;i++)
                    {
                        if (myCards[numcard].Face != gameStol[i].Face)
                        {
                            j++;
                            continue;
                        }
                        else break;
                    }
                    if (j == gameStol.Count) throw new Exception("");
                }
                catch (Exception)
                {
                    MessageBox.Show("Вы походили неверной картой!", "Сообщение");
			        PokazCard();
			        return false;
                }
            }
            // Если игрок 1 отбтвается 
            else if (nNumGamer == 1 && gameStol.Count != 0)
            {
                Card K;
                Card F;
                K = gameStol[gameStol.Count - 1];
                F = myCards[numcard];
		        if(K.Face < F.Face  && F.Suit == K.Suit||F.Suit == mast)
                {
                    gameStol.Add(myCards[numcard]);
                    myCards.RemoveAt(numcard);
			        return true;
                }
		    // Если игрок 1 отбтвается неверной картой
                else if (K.Face > F.Face || F.Suit != K.Suit)
                {
                    MessageBox.Show("Вы бьете неверной картой!");
                    PokazCard();
			       return false;
                }
            }
            gameStol.Add(myCards[numcard]);
	        myCards.RemoveAt(numcard);
	        return true;
        }

        /// <summary>
        /// Автоматич логика ходов компьютера
        /// Компьютер подбрасывает карты
        /// </summary>
        /// <returns></returns>
        public bool LogicKomp()
        {
            if (gameStol.Count == 0)
            {
                int nKnum = rand.Next(0, compCards.Count);
                gameStol.Add(compCards[nKnum]);
                compCards.RemoveAt(nKnum);
                PokazCard();
                return true;
            }
            else if (gameStol.Count > 0)
            {
                int temp = 0;
                for (int i = 0; i < compCards.Count; i++)
                {
                    for (int j = 0; j < gameStol.Count; j++)
                    {
                        // Проверка всех карт, имеющихся в наличии у компьютера, 
                        // чтобы подбросить карту противнику.
                        if (compCards[i].Face != gameStol[j].Face)
                        {
                            temp++;
                            if (temp == compCards.Count + gameStol.Count)
                            {
                                for (int k = 0; k < gameStol.Count; k++)
                                {
                                    otboj.Add(gameStol[k]);
                                }
                                gameStol.Clear();
                                return false;
                            }
                            continue;
                        }
                        else
                        {
                            gameStol.Add(compCards[i]);
                            compCards.RemoveAt(i);
                            PokazCard();
                            return true;
                        }
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Логика хода компьютера (отбивается)
        /// </summary>
        /// <returns></returns>
        public bool LogicCard()
        {
            // Игрок 2 бьет карту
            Card F;
            Card K = gameStol[gameStol.Count-1];
            for (int i = 0; i < compCards.Count; i++)
            {
                // Проверка всех карт, имеющихся в наличии у компьютера, 
                // чтобы "побить" карту противника (игрока 1)        
                F = compCards[i];
                if (K.Suit == mast)
                {
                    if (F.Suit == K.Suit && F.Face > K.Face)
                    {
                        compNumCardOtboj.Add(i);// Комп собирает номера карт, пригодных для хода
                    }
                }
                else 
                {
                    if (F.Face > K.Face && F.Suit == K.Suit || F.Suit == mast)//kozir[0].Suit)
                    {
                        compNumCardOtboj.Add(i); // Комп собирает номера карт, пригодных для хода
                    }
                }
            }

            if (compNumCardOtboj.Count > 0)
            {
                // Из выбранных карт комп выбирает единственную (случайную) для хода
                //MessageBox.Show(compNumCardOtboj.Count.ToString());
                int i = rand.Next(0, compNumCardOtboj.Count);
                gameStol.Add(compCards[compNumCardOtboj[i]]);
                compCards.RemoveAt(compNumCardOtboj[i]);
                compNumCardOtboj.Clear();
                return true;
            }
            // Если игроку 2 нечем бить карту противника (игрока 1), 
            // то он забирает карту себе
            if (gameStol.Count != 0)
            {
                PokazCard();
            }
            for (int j = 0; j < gameStol.Count; j++)
            {
                compCards.Add(gameStol[j]);
            }
            gameStol.Clear();
            return false;
        }
    }
}
