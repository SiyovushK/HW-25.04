using System.ComponentModel.DataAnnotations;
using Domain.DTOs.StudentDTOs;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages.Student;

public class Get(IStudentService studentService) : PageModel
{
    [Required]
    [BindProperty]
    public List<GetStudentDTO> getStudentDTO { get; set; } = [];
    public List<string> Messages { get; set; } = [];

    public async Task OnGetAsync()
    {
        var result = await studentService.GetAllStudents();
        if (!ModelState.IsValid)
        {
            Messages.Add("Something went wrong");
            return;
        }

        getStudentDTO = result.Data!;
    }
}