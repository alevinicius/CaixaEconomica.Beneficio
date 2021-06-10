using CaixaEconomica.Beneficio.Dominio.Notification;
using System.Collections.Generic;
using System.Linq;

namespace CaixaEconomica.Beneficio.Dominio.Entidades
{
    public class Pessoa: Entidade
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public int Idade { get; set; }
        public int QuantidadeFilhos { get; set; }
        /// <summary>
        /// 02 - Empregado
        /// 11 - Profissional Liberal
        /// </summary>       
        public int CodigoOcupacao { get; set; }

        //Relacionamento de 1(Pessoa) para Muitos(Endereco)
        // Backing Field
        private readonly HashSet<Endereco> _enderecos = new HashSet<Endereco>();
        public IEnumerable<Endereco> Enderecos => _enderecos.ToList().AsReadOnly();

        public Pessoa()
        {
            //Ficará assim até que seja configurada a injeção de dependencia
            SetNotificacao(new NotificacaoDominio());
        }

        public void AdicionarEndereco(Endereco endereco)
        {
            if (endereco == null)
            {
                NotificacaoDominio.AddErro("Erro: Endereco deve ser instanciado");
            }
            else
            {
                //Ficará assim até que seja configurada a injeção de dependencia
                endereco.SetNotificacao(NotificacaoDominio);
                endereco.Validar();
                if (endereco.EhValido())
                {
                    _enderecos.Add(endereco);
                }
                else
                {
                    NotificacaoDominio.AddErro("Endereço não foi adicionado porque não é válido");
                }
            }
        }

        //Relacionamento de 1(Pessoa) Para Muitos(BenefícioPessoa)
        private readonly HashSet<BeneficioPessoa> _beneficioPessoas = new HashSet<BeneficioPessoa>();


        public IEnumerable<BeneficioPessoa> BeneficioPessoas => _beneficioPessoas.ToList().AsReadOnly();
    }
}
