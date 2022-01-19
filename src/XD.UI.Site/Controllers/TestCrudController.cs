using Microsoft.AspNetCore.Mvc;
using XD.UI.Site.Data;
using XD.UI.Site.Models;

namespace XD.UI.Site.Controllers
{
	public class TestCrudController : Controller
	{
		private readonly MeuDbContext _contexto;
		public TestCrudController(MeuDbContext contexto)
		{
			_contexto = contexto;
		}

		public IActionResult Index()
		{
			
			var aluno = new Aluno
			{
				Nome = "Eduardo",
				DataNascimento = DateTime.Now,
				Email = "domingues-pc@hotmail.com"
			};

			_contexto.Alunos.Add(aluno);
			_contexto.SaveChanges();
									
			var aluno2 = _contexto.Alunos.Find(aluno.Id);
			var aluno3 = _contexto.Alunos.FirstOrDefault(a => a.Email == "domingues-pc@hotmail.com");
			var aluno4 = _contexto.Alunos.Where(a => a.Email == "domingues-pc@hotmail.com");

			aluno.Nome = "João";
			_contexto.Alunos.Update(aluno);
            _contexto.SaveChanges();

			_contexto.Alunos.Remove(aluno);
			_contexto.SaveChanges();

			return View();
		}
	}
}