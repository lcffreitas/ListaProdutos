namespace ListaProdutos.API.ViewModel
{
    public class ProductViewModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Category { get; set; }
    }
}
