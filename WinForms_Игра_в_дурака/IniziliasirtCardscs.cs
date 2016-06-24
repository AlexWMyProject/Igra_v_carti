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
    [Serializable]
    public class IniziliasirtCardscs
    {
        #region API Declares
        /// <summary>
        /// Инициализация файла "cards.dll"
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        [DllImport("Cards32.dll")]
        private static extern bool cdtInit([In] ref int width, [In] ref int height);
        /// <summary>
        /// Экспортируемый метод из библиотеки "cards.dll"
        /// </summary>
        [DllImport("Cards32.dll")]
        public static extern void cdtTerm();
        /// <summary>
        /// Экспортируемый метод из библиотеки "cards.dll"
        /// </summary>
        /// <param name="hDC"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        /// <param name="ecsCard"></param>
        /// <param name="ectDraw"></param>
        /// <param name="clr"></param>
        /// <returns></returns>
        [DllImport("Cards32.dll")]
        private static extern int cdtDrawExt(IntPtr hDC, int x, int y, int dx, int dy,
            int ecsCard, int ectDraw, int clr);
        /// <summary>
        /// метод файла "cards.dll" (атрибут  [DllImport("cards.dll")])
        /// </summary>
        /// <param name="hDC"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="ecsCard"></param>
        /// <param name="ectDraw"></param>
        /// <param name="clr"></param>
        /// <returns></returns>
        [DllImport("Cards32.dll")]
        public static extern int cdtDraw(IntPtr hDC, int x, int y, int ecsCard,
            int ectDraw, int clr);
        /// <summary>
        /// метод файла "cards.dll" (атрибут  [DllImport("cards.dll")])
        /// </summary>
        /// <param name="hDC"></param>
        /// <param name="ecbCardBack"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="iState"></param>
        /// <returns></returns>
        [DllImport("Cards32.dll")]
        private static extern int cdtAnimate(IntPtr hDC, int ecbCardBack, int x, int y, int iState);
        #endregion

        #region fields
        private static int _standardWidth;
        private static int _standardHeight;
        #endregion

        #region Constructor
        static IniziliasirtCardscs()
        {

        }
        #endregion

        public static void MyIniziliasir()
        {
            try
            {
                _standardHeight = 0; _standardWidth = 0;
                bool ret = IniziliasirtCardscs.cdtInit(ref _standardWidth, ref _standardHeight);
                if (!ret)
                    throw new ApplicationException("Can't load cards.dll !");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не найден файл cards.dll" + ex.Message);
            }
            // free up library when process exits
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);
        }

        private static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            cdtTerm();
        }
    }
}
