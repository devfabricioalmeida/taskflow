using Microsoft.AspNetCore.Mvc;
using TaskFlow.GerenciamentoTarefas.Domain.Tarefas;
using TaskFlow.GerencimentoTarefas.API.Extensions;
using TaskFlow.GerencimentoTarefas.API.Models.Inputs;
using TaskFlow.GerencimentoTarefas.API.Models.Mappings;
using TaskFlow.GerencimentoTarefas.API.Models.Views;
using TaskFlow.GerencimentoTarefas.Infrastructure.DbContexts;

namespace TaskFlow.GerencimentoTarefas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly GerenciamentoTarefasContext _context;

        public TarefasController(GerenciamentoTarefasContext contex)
        {
            _context = contex;
        }

        [HttpPost("registrar")]
        public IActionResult Registrar(TarefaInputModel input)
        {

            var responsavel = new Responsavel();
            responsavel.Nome = "FABRICIO";
            _context.Resposaveis.Add(responsavel);


            var tarefa = new Tarefa(input.Titulo, input.Descricao);
            tarefa.AtribuirResponsavel(responsavel);

            _context.Tarefas.Add(tarefa);

            _context.SaveChanges();

            var viewModel = tarefa.ParaViewModel();



            return Ok(viewModel);
        }


    }
}
