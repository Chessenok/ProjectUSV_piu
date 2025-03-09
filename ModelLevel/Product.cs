namespace ProjectUSV_piu
{

    public class Product
    {
        public string ProducerCompany { get; private set; }
        public string Description { get; private set; }
        public int Price { get; protected set; }


        public Product(string producerCompany, string description, int price)
        {
            ProducerCompany = producerCompany;
            Description = description;
            Price = price;
        }
    }
}