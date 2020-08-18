using GBCashback.DTO;

namespace GBCashback.Services.Interface
{
    public interface IApiBoticarioService
    {
        AcumuladoDTO Acumulado(string cpf);
    }
}