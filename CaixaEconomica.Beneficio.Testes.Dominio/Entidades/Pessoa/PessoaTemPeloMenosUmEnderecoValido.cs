using CaixaEconomica.Beneficio.Dominio.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CaixaEconomica.Beneficio.Testes.Dominio.Entidades.Pessoa
{
    [TestClass]
    public class PessoaTemPeloMenosUmEnderecoValido
    {
        private CaixaEconomica.Beneficio.Dominio.Entidades.Pessoa pessoa;
        private Endereco endereco;

        [TestInitialize]
        public void Init()
        {
            pessoa = new Beneficio.Dominio.Entidades.Pessoa();
            endereco = new Endereco();
            pessoa.AdicionarEndereco(endereco);
        }

        [TestMethod]
        public void PessoaTemEnderecoValido()
        {
            Assert.IsTrue(pessoa.Enderecos.Any());
        }
    }
}
