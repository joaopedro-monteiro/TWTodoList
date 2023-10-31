using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TWTodoList.ViewModels;

public class CreateTodoViewModel
{
    [DisplayName("Título")]
    public string? Title { get; set; }

    [DisplayName("Data")]
    [DataType(DataType.Date)]
    public DateTime Date { get; set; }
}
