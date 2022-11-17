using MVCAlunos.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAlunos.ViewModel
{
      
    public class LAlunosViewModel
    {
        public enum EnumeradorSexo
        {
            Masculino = 0,
            Feminino = 1
        }

        public int MATRICULA { get; set; }
        public string NOME { get; set; }
        public string CPF { get; set; }

        [DataType(DataType.Date)]

        public DateTime NASCIMENTO { get; set; }
        public EnumeradorSexo SEXO { get; set; }

        public static List<LAlunosViewModel> ListarTabela(DataTable dt)
        {
            List<LAlunosViewModel> lista = new();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LAlunosViewModel alunos = new()
                {
                    MATRICULA = (int)dt.Rows[i]["MATRICULA"],
                    NOME = dt.Rows[i]["NOME"].ToString(),
                    CPF = dt.Rows[i]["CPF"].ToString(),
                    NASCIMENTO = (DateTime)dt.Rows[i]["NASCIMENTO"],
                    SEXO = (EnumeradorSexo)(int)dt.Rows[i]["SEXO"],

                };
                lista.Add(alunos);
            }

            return lista;
        }
    }
}
