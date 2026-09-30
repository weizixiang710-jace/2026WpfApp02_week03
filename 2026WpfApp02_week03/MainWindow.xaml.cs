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
        Dictionary<string, int> drinks = new Dictionary<string, int>()
        {
            { "紅茶大杯", 60 },
            { "紅茶小杯", 40 },
            { "綠茶大杯", 60 },
            { "綠茶小杯", 40 },
            { "可樂大杯", 50 },
            { "可樂小杯", 30 }
        };

        // 2. 顧客選購結果字典 (Key: 品項名稱, Value: 購買數量)
        Dictionary<string, int> orders = new Dictionary<string, int>();

        string typeMessage = "未選擇"; // 內用/外帶
        string resultMessage = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        // 內用 / 外帶 RadioButton 切換事件 handler
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null && rb.IsChecked == true)
            {
                typeMessage = rb.Content.ToString();
            }
        }

        // 按下「訂購」按鈕事件處理
       
        private void OrderButton_Click_1(object sender, RoutedEventArgs e)
        {
            orders.Clear();
            resultMessage = "";

            // 自動掃描品項區塊裡所有的 StackPanel (每個品項行)
            foreach (UIElement child in StackPanel_Drinks.Children)
            {
                if (child is StackPanel itemPanel)
                {
                    CheckBox cb = null;
                    Slider slider = null;

                    // 尋找品項列中的 CheckBox 與 Slider
                    foreach (UIElement subChild in itemPanel.Children)
                    {
                        if (subChild is CheckBox c) cb = c;
                        if (subChild is Slider s) slider = s;
                    }

                    // 如果 CheckBox 有勾選，且數量大於 0
                    if (cb != null && cb.IsChecked == true && slider != null && slider.Value > 0)
                    {
                        string drinkName = cb.Content.ToString();
                        int quantity = (int)slider.Value;

                        if (drinks.ContainsKey(drinkName))
                        {
                            orders.Add(drinkName, quantity);
                        }
                    }
                }
            }

            // 開始計算總金額與產生結果字串
            double total = 0.0;
            
            resultMessage += "訂購清單如下：\n";

            int index = 1;
            foreach (var item in orders)
            {
                string drinkName = item.Key;
                int price = drinks[drinkName];
                int quantity = item.Value;

                int subTotal = price * quantity;
                total += subTotal;

                resultMessage += $"{index}. {drinkName}：{price}元 X {quantity}杯 = {subTotal}元\n";
                index++;
            }

            resultMessage += "-------------------------------\n";
            resultMessage += $"總計金額：{total}元\n";

            // 折扣計算邏輯
            double sellPrice = total;
            string discountMessage = "沒有折扣";

            if (total >= 500)
            {
                discountMessage = "滿500元打8折";
                sellPrice = total * 0.8;
            }
            else if (total >= 300)
            {
                discountMessage = "滿300元打85折";
                sellPrice = total * 0.85;
            }
            else if (total >= 200)
            {
                discountMessage = "滿200元打9折";
                sellPrice = total * 0.9;
            }

            resultMessage += $"折扣優惠：{discountMessage}\n";
            resultMessage += $"實付金額：{(int)Math.Round(sellPrice)}元";

            // 將結果顯示在 TextBlock 上
            txtReceipt.Text = resultMessage;

        }
    }
}