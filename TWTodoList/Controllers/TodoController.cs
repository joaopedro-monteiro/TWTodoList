using Microsoft.AspNetCore.Mvc;
using TWTodoList.Contexts;
using TWTodoList.Models;
using TWTodoList.ViewModels;

namespace TWTodoList.Controllers;

public class TodoController : Controller
{
    private readonly AppDbContext _context;

    public TodoController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var todos = _context.Todos.OrderBy(x => x.Date).ToList();
        var viewModel = new ListTodoViewModel
        {
            Todos = todos
        };
        ViewData["Title"] = "Lista de Tarefas";
        return View(viewModel);
    }


    public IActionResult Delete(Guid id)
    {
        var todo = _context.Todos.Find(id);
        if (todo is null)
        {
            return NotFound();
        }
        _context.Remove(todo);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Create ()
    {
        ViewData["Title"] = "Criar Nova Tarefa";
        return View("Form");
    }

    [HttpPost]
    public IActionResult Create(FormTodoViewModel data)
    {
        var todo = new Todo(data.Title, data.Date);
        _context.Add(todo);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(Guid id)
    {
        ViewData["Title"] = "Editar a Tarefa";

        var todo = _context.Todos.Find(id);
        if (todo is null)
            return NotFound();

        var viewModel = new FormTodoViewModel { Title = todo.Title, Date = todo.Date };
        return View("Form", viewModel);
    }

    [HttpPost]
    public IActionResult Edit(Guid id, FormTodoViewModel viewModel)
    {
        var todo = _context.Todos.Find(id);

        todo.Title = viewModel.Title;
        todo.Date = viewModel.Date;

        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Complet(Guid id)
    {
        var todo = _context.Todos.Find(id);
        if (todo is null)
            return NotFound();

        if (todo.IsCompleted)        
            todo.IsCompleted = false;
        
        else      
            todo.IsCompleted = true;
        
        _context.Update(todo);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }
}
