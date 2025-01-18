namespace Ola.Banking.Core
{
    public class Account
    {
        public string Currency { get; set; }

        public string Type { get; set; }

        public string Iban { get; set; }

        public string Name { get; set; }

        public decimal Balance { get; set; }

        public override string ToString()
        {
            return $"{Iban} {Name} {Type} {Balance:F} {Currency}";
        }
    }
}