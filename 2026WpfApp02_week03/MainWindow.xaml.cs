using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _2026WpfApp02_week03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        private void BtnBuy_Click(object sender, RoutedEventArgs e)
        {
            string result = "";

            // 1. 伯爵紅茶 大杯 ($100)
            if (int.TryParse(bigBlackTea.Text, out int qty1) && qty1 > 0)
            {
                int subtotal = qty1 * 100;
                result += $"伯爵紅茶 大杯 {qty1}杯 ${subtotal}\n";
            }

            // 2. 伯爵紅茶 小杯 ($80)
            if (int.TryParse(smallBlackTea.Text, out int qty2) && qty2 > 0)
            {
                int subtotal = qty2 * 80;
                result += $"伯爵紅茶 小杯 {qty2}杯 ${subtotal}\n";
            }

            // 3. 午後奶茶 大杯 ($120)
            if (int.TryParse(bigmalkTea.Text, out int qty3) && qty3 > 0)
            {
                int subtotal = qty3 * 120;
                result += $"午後奶茶 大杯 {qty3}杯 ${subtotal}\n";
            }

            // 4. 午後奶茶 小杯 ($80)
            if (int.TryParse(SmallmalkTea.Text, out int qty4) && qty4 > 0)
            {
                int subtotal = qty4 * 80;
                result += $"午後奶茶 小杯 {qty4}杯 ${subtotal}\n";
            }

            // 若完全沒輸入數量，顯示提示文字
            if (string.IsNullOrEmpty(result))
            {
                result = "未選擇商品";
            }

            // 顯示結果到 TextBlock
            txtReceipt.Text = result;
        }

        // TextBox 文字變更時觸發（可視需要保留預留事件）
        private void Quantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            // 目前邏輯寫在按下 BUY NOW 按鈕時顯示
        }

    }
}