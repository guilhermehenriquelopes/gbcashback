using System.Threading.Tasks;
using GBCashback.DTO;

namespace GBCashback.Services.Interface
{
    public interface IApiBoticarioService
    {
        Task<AcumuladoDTO> Acumulado(string cpf);
    }
}