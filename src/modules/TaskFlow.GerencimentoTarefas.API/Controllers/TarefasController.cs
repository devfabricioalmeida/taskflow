using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskFlow.GerenciamentoTarefas.Domain.Repositories;
using TaskFlow.GerenciamentoTarefas.Domain.Tarefas;
using TaskFlow.GerencimentoTarefas.API.Extensions;
using TaskFlow.GerencimentoTarefas.API.Models.Inputs;
using TaskFlow.GerencimentoTarefas.API.Models.Mappings;
using TaskFlow.GerencimentoTarefas.API.Models.Views;
using TaskFlow.GerencimentoTarefas.Infrastructure.DbContexts;
using TaskFlow.GerencimentoTarefas.Infrastructure.Repositories;

namespace TaskFlow.GerencimentoTarefas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
    

        public TarefasController(ITarefaRepository tarefaReposity)
        {
            _tarefaReposity = tarefaReposity;
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar(TarefaInputModel input)
        {

         

        

            return Ok(viewModel);
        }


    }
}
