namespace ConsoleApp1.models
{
    public class Client
    {
        public int customerNr { get; private set; }
        public int balance { get; private set; }
        public string telephoneNr { get; private set; }


        private Client()
        {

        }

        public static Client of(int customerNr,
            int balance,
            string telephoneNr)
        {
            Client client = new Client();
            client.customerNr = customerNr;
            client.balance = balance;
            client.telephoneNr = telephoneNr;

            return client;
        }

        public static Client dummyData()
        {
            Client client = new Client();
            client.customerNr = 5;
            client.balance = 24;
            client.telephoneNr = "+48123456789";
            return client;

        }
    }

}
