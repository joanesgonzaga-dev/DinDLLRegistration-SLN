# DinDllRegistration - Registro de DLLs e OCX
Aplicativo de Console para registro de DLLs e OCX da aplicação desktop DinnamuS Automação

## Tecnologias empregadas:
* .Net Framework 4.5
* C# 7

## Projeto Console, suas classes e métodos
Toda a lógica do aplicativo fica na classe estática Program
| Classe          | Método                       | Objetivo                                                                                                                    |
|---------------- |------------------------------|-----------------------------------------------------------------------------------------------------------------------------|
| Program         | main                         | Ponto de entrada da aplicação console                                                                                        |
| Program         | RetornaDLLs                  | Retorna array com os nomes dos arquivos (.dll e .ocx) padrão a serem registrados para correto funcionamento da aplicação    |
| Program         | RetornaDllsEncontradas       | Chamada o método RetornaDlls, do qual recebe um array com os nomes dos arquivos a serem procurados e retorna os encontrados no diretório atual                                                    |
| Program         | RegistraDlls                 | Executa um Process para o executável "C:\Windows\System32\regsvr32.exe" e registra as Dlls e Ocx     |

## Projeto de teste do xUnit, suas classes e métodos
| Classe               | Método de teste                               | Resultado esperado do teste
|----------------------|-----------------------------------------------|--------------------------------------------------------------------------------------------------------------------------------------------|
| DinDLLRegistrationTests | RetornaArrayComListaDeNomesDeArquivosASeremRegistrados         | Ao executar, deve retornar um array de string não vazio  |
| DinDLLRegistrationTests | VerificaSeArquivosEncontradosSaoValidos                     | Ao executar, deve retornar True caso todos os arquivos encontrados existam no array padrão                      |
| DinDLLRegistrationTests | ExecutaTesteDeRegistroDasDlls                 | Ao passar, deve retornar True para a execução bem sucedida do comando "C:\Windows\System32\regsvr32.exe"        |
