using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using TodoApp.Contexts;
using TodoApp.Models.Dtos;
using TodoApp.Models.Entities.Concretes;

namespace TodoApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoController : ControllerBase
{
    private AppDbContext _appDbContext;


    public TodoController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    [HttpGet("GetAll")]
    public  IActionResult GetAll()
    {
        return Ok("Hershey okaydir");
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> AddTodoItem([FromBody] AddTodoItemDTO addtodoitemDTO)
    {

        var newItem = new TodoItem()
        {
            Title= addtodoitemDTO.Title,
            Description= addtodoitemDTO.Description,
            ExpireTime = addtodoitemDTO.ExpireTime,
            UserId=addtodoitemDTO.UserId.ToString(),
        };

        await _appDbContext.Set<TodoItem>().AddAsync(newItem);
        await _appDbContext.SaveChangesAsync();
        return Ok();
    }

}
