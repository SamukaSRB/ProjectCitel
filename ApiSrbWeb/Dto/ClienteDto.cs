namespace ApiSrbWeb.Dto
{
    public class ClientDto
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }

        public string ClientAddress { get; set; }

        public string ClientPostalCode { get; set; }

        public string ClientCity { get; set; }

        public string ClientState { get; set; }

        public string ClientPhone { get; set; }

        public string ClientEmail { get; set; }

        public int SupplierId { get; set; }

    }
}
