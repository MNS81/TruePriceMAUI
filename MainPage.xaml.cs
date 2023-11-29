namespace TruePriceMAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage() => InitializeComponent();
        List<double> fullPrice = new List<double>();
        List<double> price = new List<double>();
        List<double> weight = new List<double>();
        void OnCalculate(object sender, EventArgs e)
        {
            try
            {
                double thisPrice = double.Parse(PriceInput.Text);
                double thisWeight = double.Parse(WeightInput.Text);
                double thisFullPrice = Math.Round(thisPrice / thisWeight * 1000, 2);
                fullPrice.Add(thisFullPrice);
                price.Add(thisPrice);
                weight.Add(thisWeight);
                int index = GetBestResult();
                DisplayAlert($"Цена за кг.\t{thisFullPrice} руб.", $"Лучший выбор:\t{price[index]} р. за {weight[index]} гр.", "Чудненько");
                PriceInput.Text = String.Empty;
                WeightInput.Text = String.Empty;
                ResetButton.Text = "Галя!!! У нас отмена";
            }
            catch (Exception)
            {
                DisplayAlert("Ошибка!", "Ой! Что-то пошло не так...", "OK");
            }
        }
        void OnPriceList(object sender, EventArgs e)
        {
            if (fullPrice.Count != 0)
            {
                int index = GetBestResult();
                string listWiew = "";
                for (int i = 0; i < fullPrice.Count; i++)
                    listWiew += $"Поз.{i + 1}:\tЦена: {price[i]} р.\tВес: {weight[i]} гр.\n";
                DisplayAlert($"Лучший выбор:\t{price[index]} р. за {weight[index]} гр.", listWiew, "Чудненько");
            }
            else
                DisplayAlert($"Ошибка!", "Список пока пустой", "Вернусь позже");
        }
        void OnReset(object sender, EventArgs e)
        {
            PriceInput.Text = String.Empty;
            WeightInput.Text = String.Empty;
            fullPrice.Clear();
            price.Clear();
            weight.Clear();
            ResetButton.Text = "Данные очищены";
        }
        int GetBestResult()
        {
            double minValue = double.MaxValue;
            int index = 0;
            for (int i = 0; i < fullPrice.Count; i++)
                if (minValue > fullPrice[i])
                {
                    minValue = fullPrice[i];
                    index = i;
                }
            return index;
        }
    }
}
