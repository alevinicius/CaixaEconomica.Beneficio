using System.Collections.Generic;

namespace CaixaEconomica.Beneficio.Dominio.Interfaces.Notification
{
    public interface INotificacaoDominio
    {
        bool Validado();
        bool TemAviso();
        IEnumerable<string> ErroMensagem { get; }
        IEnumerable<string> AvisoMensagem { get; }
        void AddErro(string mensagem);
        void AddAviso(string mensagem);
    }
}
