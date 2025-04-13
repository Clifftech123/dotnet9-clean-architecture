using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TodoAPI.Controllers
{

    public class BaseApiController : ControllerBase
    {
        protected IMediator mediator => HttpContext.RequestServices.GetRequiredService<IMediator>();
    }
}
