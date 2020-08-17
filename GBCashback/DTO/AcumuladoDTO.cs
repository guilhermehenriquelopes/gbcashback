namespace GBCashback.DTO
{
    public class AcumuladoDTO
    {
        public string CPF { get; set; }
        public decimal Credit { get; set; }
    }

    public class AcumuladoResponse
    {
        public int statusCode { get; set; }
        public AcumuladoResponseBody body { get; set; } = new AcumuladoResponseBody();

    }
    public class AcumuladoResponseBody
    {
        public decimal credit { get; set; }
    }
}