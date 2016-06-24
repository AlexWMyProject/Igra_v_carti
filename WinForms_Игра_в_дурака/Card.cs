using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Windows.Forms.Design;

namespace WinForms_Игра_в_дурака
{
    /// <summary>
    /// Class wrapper to Cards.dll http://www.pinvoke.net/default.aspx/cards/CardsWrapper.html
    /// </summary>
    [Serializable]
    public class Card : IniziliasirtCardscs
    {
        #region fields
        private int CardId;// номер выводимой крты
        private int BackId;// номер тыльной стороны
        private int suit;// масть карты
        private int face; // номинал карты
        #endregion

        #region Constructor
        public Card(int CardId, int BackId, int suit, int face)
        {
            this.BackId = BackId;
            this.CardId = CardId;
            this.suit = suit;//масть карты
            this.face = face;// номинал карты
        }
        #endregion
        public int Face
        {
            get { return face; }
        }
        public int Suit
        {
            get { return suit;}
        }
        #region Public Static Members
        /// <summary>
        /// Рисует карту в заданном месте
        /// </summary>
        /// <param name="g"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void DrawFace(Graphics g, int x, int y)
        {
            try
            {
                cdtDraw(g.GetHdc(), x, y, CardId, 0, 9);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Невозможно показать карту" + ex.Message);
            }
        }
        /// <summary>
        /// Рисует тыльную сторону карты
        /// </summary>
        /// <param name="g"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void DrawDeck(Graphics g, int x, int y)
        {
            try
            {
                cdtDraw(g.GetHdc(), x, y, 53 + BackId, 1, 9);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Невозможно показать обратную сторону карты" + ex.Message);
            }
        }
        #endregion
    }
}
