using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestCurso.Services
{
    public class MeuServico : IMeuServico
    {
        string IMeuServico.saldacao(string saldacao)
        {
            return $"Bem vindo {saldacao} - {DateTime.Now.ToString("dd-MM-yyyy hh:mm")}";
        }
    }
}
