namespace Business.Configuration.Helper
{
    public class CalculatorHelper
    {
        public static int CalculateDebt(int debt, int price, bool paid)
        {
            if (!paid)
            {
                return debt + price;
            }
            return debt - price;
        }
    }
}
