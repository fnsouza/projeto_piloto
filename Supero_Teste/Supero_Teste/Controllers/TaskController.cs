using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/task")]
    public class TaskController : Controller
    {
        private readonly TaskAppService taskAppService;

        public TaskController(TaskAppService taskAppService)
        {
            this.taskAppService = taskAppService;
        }

        /// <summary>
        /// Busca uma tarefa pelo Id
        /// </summary>
        /// <param name="id">Tarefa Id</param>
        /// <returns>Informações da tarefa</returns>
        [Authorize]
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(TaskResponse), 200)]
        public IActionResult GetTask(int id)
        {
            var task = taskAppService.GetById(id);

            return task == null ? NotFound() : (IActionResult)Ok(task); 
        }

        /// <summary>
        /// Adiciona uma nova tarefa
        /// </summary>
        /// <param name="task">Informações da tarefa</param>
        [Authorize]
        [HttpPost]
        [Route("add")]
        public IActionResult Add(TaskRequest task)
        {
            taskAppService.Add(task);

            return NoContent();
        }

        /// <summary>
        /// Atualiza uma tarefa
        /// </summary>
        /// <param name="taskRequest">Informações da tarefa</param>
        /// <returns>Tarefa atualizada</returns>
        [Authorize]
        [HttpPut]
        [Route("update")]
        public IActionResult Update(TaskRequest taskRequest)
        {
            var task = taskAppService.Update(taskRequest);

            return task == null ? NotFound() : (IActionResult)Ok(task);
        }

        /// <summary>
        /// Apaga uma tarefa
        /// </summary>
        /// <param name="id">Tarefa Id</param>
        [Authorize]
        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete(int id)
        {
            var deleted = taskAppService.Delete(id);

            return deleted ? (IActionResult)NoContent() : NotFound();
        }
    }
}