using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MVCAlunos.Models
{
    public class AlunoMatriculaViewModel
    {
        public List<Aluno>? Alunos { get; set; }
        public SelectList? Matriculas { get; set; }
        public string? AlunoMatricula { get; set; }
        public string? SearchString { get; set; }
    }
}