using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinDLLRegistration
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Executando...");
            Console.WriteLine("".PadLeft(90, '-'));

            if (RetornaDllsEcontradas().Length > 0)
            {
                Console.WriteLine("Lista de DLLs e OCX Encontradas:".PadLeft(45));

                foreach (var dll in RetornaDllsEcontradas())
                {
                    Console.WriteLine(dll);
                }

                Console.WriteLine("".PadLeft(90, '-'));
                Console.WriteLine("Iniciando registro:");

                if (RegistraDlls(RetornaDllsEcontradas()))
                {
                    Console.WriteLine("Lista de DLLs e OCX registrada com sucesso!");
                    Console.WriteLine("".PadLeft(90, '-'));
                }
            }

            else
            {
                Console.WriteLine("Nenhuma DLL/OCX foi encontrada".PadLeft(45));
                Console.WriteLine();
            }

            Console.Write("Pressione uma tecla para finalizar...");
            Console.ReadKey();
        }

        public static string[] RetornaDllsEcontradas()
        {
            List<string> arquivosDll = retornaDlls();
            DirectoryInfo diretorio = new DirectoryInfo(Environment.CurrentDirectory);
            int total = 0;
            List<string> lista = new List<string>();

            foreach (var file in diretorio.GetFiles())
            {
                foreach (var dll in arquivosDll)
                {
                    if (file.Name.ToLower().Equals(dll.ToLower()))
                    {
                        lista.Add(file.Name);
                        total += 1;
                    }
                }
            };

            string[] arrayDlls = new string[total];

            for (int i = 0; i < lista.Count; i++)
            {
                arrayDlls[i] = lista.ElementAt(i);
            }

            return arrayDlls;
        }

        public static bool RegistraDlls(string[] DLLsParaRegsitro)
        {
            try
            {
                Process myProcess = new Process();
                myProcess.StartInfo.FileName = @"C:\Windows\System32\regsvr32.exe";
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.StartInfo.UseShellExecute = true;
                string nomes = "/s";
                for (int i = 0; i < DLLsParaRegsitro.Length; i++)
                {
                    nomes += " " + DLLsParaRegsitro[i].ToString();
                }

                myProcess.StartInfo.Arguments = nomes;

                return myProcess.Start();
            }

            catch (Exception ex)
            {
                Console.WriteLine("<<< Ocorreu um erro!  >>>: " + ex.Message);
                Console.WriteLine("".PadLeft(90, '-'));
                return false;
            }
        }

        public static List<string> retornaDlls()
        {
            List<string> dlls = new List<string>();
            string[] arrayDlls = new string[]
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

            for (int i = 0; i < arrayDlls.Length; i++)
            {
                dlls.Add(arrayDlls[i]);
            }

            return dlls;
        }
    }
}
