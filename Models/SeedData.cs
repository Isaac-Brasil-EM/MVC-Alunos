using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVCAlunos.Data;
using System;
using System.Linq;

namespace MVCAlunos.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MVCAlunosContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MVCAlunosContext>>()))
            {
                // Look for any movies.
                if (context.Aluno.Any())
                {
                    return;   // DB has been seeded
                }

                context.Aluno.AddRange(
                    new Aluno
                    {
                        Nome = "Aluno Seed Padrão 1",
                        Cpf = "12345678900",
                        Nascimento = DateTime.Parse("1989-2-12"),
                        Sexo = EnumeradorSexo.Masculino
                    },
                    new Aluno
                    {
                        Nome = "Aluno Seed Padrão 2",
                        Cpf = "12345678911",
                        Nascimento = DateTime.Parse("2000-2-12"),
                        Sexo = EnumeradorSexo.Feminino
                    },
                     new Aluno
                    {
                        Nome = "Aluno Seed Padrão 3",
                        Cpf = "12345678933",
                        Nascimento = DateTime.Parse("2000-3-29"),
                        Sexo = EnumeradorSexo.Feminino
                     }
                );
                context.SaveChanges();
            }
        }
    }
}
