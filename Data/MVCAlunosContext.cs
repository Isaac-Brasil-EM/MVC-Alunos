using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCAlunos.Models;

namespace MVCAlunos.Data
{
    public class MVCAlunosContext : DbContext
    {
        public MVCAlunosContext (DbContextOptions<MVCAlunosContext> options)
            : base(options)
        {
        }

        public DbSet<MVCAlunos.Models.Aluno> Aluno { get; set; } = default!;
    }
}
