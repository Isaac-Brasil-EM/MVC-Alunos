using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCAlunos.Data;
using MVCAlunos.Data.Banco;
using MVCAlunos.Data.DAL;
using MVCAlunos.Models;
using MVCAlunos.ViewModel;

namespace MVCAlunos.Controllers
{
    public class AlunosController : Controller
    {
        /*private readonly MVCAlunosContext _context;
        private readonly IHttpClientFactory _httpClientFactory;*/

        // public AlunosController(//MVCAlunosContext context, IHttpClientFactory httpClientFactory//
        // )
        //{
        /* _context = context;
         _httpClientFactory = httpClientFactory;
*/
        //}

        // GET: Alunos

        /* public async Task<IActionResult> Index(string searchString)
         {
             var alunos = from a in _context.Aluno
                          select a;

             if (!String.IsNullOrEmpty(searchString))
             {
                 alunos = alunos.Where(s => s.Nome!.Contains(searchString));
             }

             return View(await alunos.ToListAsync());
         }*/
        public IActionResult Index()
        {
            DAL CONNECTAR = new();
            var dt = CONNECTAR.RetDataTable("select * from TBALUNO");
            List<LAlunosViewModel> Listar_alunos = LAlunosViewModel.ListarTabela(dt);
            ViewBag.Alunos = Listar_alunos;
            return View();
        }
        public IActionResult ListagemAlunos()
        {
            Banco conexao = new();

            List<LAlunosViewModel> listaAlunos = new List<LAlunosViewModel>();

            if (conexao.bconexao)
            {
                var dt = conexao.RetornoTabela("select * from TBALUNO");
                LAlunosViewModel tratarAlunos = new();
                listaAlunos = LAlunosViewModel.ListarTabela(dt);
                //listaAlunos = tratarAlunos.ListarTabela(dt);

            }
            ViewBag.Alunos = listaAlunos;
            return View();
        }

        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }

        // GET: Alunos/Details/5
        /*public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Aluno == null)
            {
                return NotFound();
            }

            var aluno = await _context.Aluno
                .FirstOrDefaultAsync(m => m.Matricula == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }*/

        // GET: Alunos/Create
        public IActionResult Create()
        {


            return View();
        }

        // POST: Alunos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /*  [HttpPost]
          [ValidateAntiForgeryToken]
          public async Task<IActionResult> Create([Bind("Matricula,Nome,Cpf,Nascimento,Sexo")] Aluno aluno)
          {
              if (ModelState.IsValid)
              {
                  _context.Add(aluno);
                  await _context.SaveChangesAsync();
                  return RedirectToAction(nameof(Index));
              }
              return View(aluno);
          }
  */
        // GET: Alunos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            DAL CONNECTAR = new();
            var dt = CONNECTAR.RetDataTable($"SELECT * FROM TBALUNO WHERE TBALUNO.MATRICULA = {id}");
            List<LAlunosViewModel> Listar_alunos = LAlunosViewModel.ListarTabela(dt);

            ViewBag.Alunos = Listar_alunos;
            return View();
        }



        // GET: Alunos/AddorEdit/
        /* public IActionResult AddOrEdit(int? id)
         {
             Aluno aluno = new();
             return View(aluno);
         }*/


        // POST: Alunos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        /* public async Task<IActionResult> Edit(int id, [Bind("Matricula,Nome,Cpf,Nascimento,Sexo")] Aluno aluno)
         {
             if (id != aluno.Matricula)
             {
                 return NotFound();
             }

             if (ModelState.IsValid)
             {
                 try
                 {
                     _context.Update(aluno);
                     await _context.SaveChangesAsync();
                 }
                 catch (DbUpdateConcurrencyException)
                 {
                     if (!AlunoExists(aluno.Matricula))
                     {
                         return NotFound();
                     }
                     else
                     {
                         throw;
                     }
                 }
                 return RedirectToAction(nameof(Index));
             }
             return View(aluno);
         }*/

        public IActionResult AddOrEdit(int id, [Bind("Matricula,Nome,Cpf,Nascimento,Sexo")] Aluno aluno)
        {

            if (ModelState.IsValid)
            {

            }
            return View();
        }

        // GET: Alunos/Delete/5
        /* public async Task<IActionResult> Delete(int? id)
         {
             if (id == null || _context.Aluno == null)
             {
                 return NotFound();
             }

             var aluno = await _context.Aluno
                 .FirstOrDefaultAsync(m => m.Matricula == id);
             if (aluno == null)
             {
                 return NotFound();
             }

             return View(aluno);
         }*/
       /* public IActionResult Delete(int? id)
        {
            DAL CONNECTAR = new();
            var dt = CONNECTAR.RetDataTable("SELECT * FROM TBALUNO");
            List<LAlunosViewModel> Listar_alunos = LAlunosViewModel.ListarTabela(dt);
            ViewBag.Alunos = Listar_alunos;
            return View();
        }*/

        // POST: Alunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        /* public async Task<IActionResult> DeleteConfirmed(int id)
         {
             if (_context.Aluno == null)
             {
                 return Problem("Entity set 'MVCAlunosContext.Aluno'  is null.");
             }
             var aluno = await _context.Aluno.FindAsync(id);
             if (aluno != null)
             {
                 _context.Aluno.Remove(aluno);
             }

             await _context.SaveChangesAsync();
             return RedirectToAction(nameof(Index));
         }*/

        public IActionResult DeleteConfirmed(int id)
        {
            return RedirectToAction(nameof(Index));
        }

        /* private bool AlunoExists(int id)
         {
           return _context.Aluno.Any(e => e.Matricula == id);
         }*/

        public void Delete(object sender, EventArgs e)
        {
            string sql_Delete = "delete from TBALUNO WHERE MATRICULA = @MATRICULA"; //tenta fazer o insert no banco try { //abre a conexão com o banco de dados this.conexao_FB.abre_Conexao(); //cria uma nova instancia para FbDataAdapter passando como //parâmetro a string com o comando SQL e a conexão com o banco de dados this.adapt = new FbDataAdapter(sql_Delete, this.conexao_FB.get_Conexao()); //limpa os parâmetros caso exista algum this.adapt.SelectCommand.Parameters.Clear(); // informa para o FbDataAdapter quais são os conteudos de cada parâmetro this.adapt.SelectCommand.Parameters.Add("@nome", tx_nome_cliente.Text); // executa o FbDataAdapter com o comando ExecuteNonQuery e retorna o total de linhas afetadas int numero = this.adapt.SelectCommand.ExecuteNonQuery(); //mensagem MessageBox.Show("Clientes Excluídos: " + numero.ToString(), "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information); } // caso de algum erro catch (Exception er) { // mensagem de erro MessageBox.Show("Erro ao fazer exclusão: " + er.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error); } //fecha a conexao com o banco de dados finally { this.conexao_FB.fecha_Conexao(); } }

            try
            {
                DAL CONNECTAR = new();
                CONNECTAR.DelDataTable(sql_Delete);

            }
            catch (Exception er)
            {

                throw er;

            }
            
        }
    }
}