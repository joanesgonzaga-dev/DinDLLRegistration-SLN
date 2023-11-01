using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using DinDLLRegistration;
namespace DinDLLRegistration_Tests
{
    public class DinDLLRegistrationTests
    {
        private string[] _arrayDeArquivosEsperados;
        public DinDLLRegistrationTests()
        {
            _arrayDeArquivosEsperados = new string[]
            {
               "br_Comissao.dll",
               "CartaoDinnamuS.dll",
               "DAO.dll",
               "DinnamuS_UI.dll",
               "FUNCOES_EXTRAS.dll",
               "Metodos_Auxiliares.dll",
               "MetodosEstoque.dll",
               "NFEGerarXML.dll",
               "VO_DinnamuS.dll",
               "Venda.dll",
               "BarCode32.ocx",
                "COMCTL32.ocx",
                "Crystl32.ocx",
                "FlatBtn6.ocx",
                "mscomct2.ocx"
            };
        }

        [Fact(DisplayName = "RetornaArrayDeDLLs")]
        public void RetornaArrayComListaDeNomesDeArquivosASeremRegistrados()
        {
            List<string> _arrayDeArquivos = DinDLLRegistration.Program.retornaDlls();

            Assert.NotEmpty(_arrayDeArquivos);
        }

        [Fact]
        public void VerificaSeArquivosEncontradosSaoValidos()
        {
            string[] _arquivosEncontrados = DinDLLRegistration.Program.RetornaDllsEcontradas(); 
            foreach (var item in _arquivosEncontrados)
            {
                Assert.Contains(item, _arrayDeArquivosEsperados);
            }
        }

        [Fact]
        public void ExecutaTesteDeRegistroDasDlls()
        {
            string[] _arquivosEncontrados = DinDLLRegistration.Program.RetornaDllsEcontradas();
            
            Assert.True(DinDLLRegistration.Program.RegistraDlls(_arquivosEncontrados));
        }
    }
}
