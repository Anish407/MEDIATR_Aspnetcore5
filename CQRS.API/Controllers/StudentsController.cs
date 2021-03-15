using CQRS.Services.Students.Commands;
using CQRS.Services.Students.Notifications;
using CQRS.Services.Students.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CQRS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator mediator;

        public StudentsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(mediator.Send(new StudentQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(mediator.Send(new StudentByIdQuery { Id=id }));
        }


        [HttpPost()]
        public async Task<IActionResult> Post([FromBody]AddStudentCommand studentCommand)
        {
            return Ok(mediator.Send(studentCommand));
        }

        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] LogDetailsNotification notification)
        {
            return Ok(mediator.Publish(notification));
        }
    }
}
