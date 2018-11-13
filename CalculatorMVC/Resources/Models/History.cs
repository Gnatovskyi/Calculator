namespace CalculatorMVC.Resources.Models
{
    class History
    {
        public int ID { get; set; }
        public string Equation { get; set; }
        public string Result { get; set; }
        public override string ToString()
        {
            return $"{Equation} = {Result}";
        }
    }
}