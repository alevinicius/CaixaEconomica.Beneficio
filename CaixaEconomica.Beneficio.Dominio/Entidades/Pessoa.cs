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
        public void AdicionarEndereco(Endereco endereco)
        {
            if (endereco != null)
            {
                _enderecos.Add(endereco);
            }
        }

        //Relacionamento de 1(Pessoa) Para Muitos(BenefícioPessoa)
        private readonly HashSet<BeneficioPessoa> _beneficioPessoas = new HashSet<BeneficioPessoa>();
        public IEnumerable<BeneficioPessoa> BeneficioPessoas => _beneficioPessoas.ToList().AsReadOnly();
    }
}
