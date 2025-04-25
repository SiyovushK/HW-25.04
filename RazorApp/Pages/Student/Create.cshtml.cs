using System.ComponentModel.DataAnnotations;
using Domain.DTOs.StudentDTOs;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages.Student;

public class Create(IStudentService studentService) : PageModel
{
    [Required]
    [BindProperty]
    public CreateStudentDTO createStudentDto { get; set; }
    [BindProperty]
    public List<string> Messages { get; set; } = [];

    public async Task<IActionResult> OnPost()
    {
        if (!ModelState.IsValid)
        {
            Messages = ModelState.Values.SelectMany(m => m.Errors).Select(x => x.ErrorMessage).ToList();
            return Page();
        }

        createStudentDto.BirthDate = createStudentDto.BirthDate.ToUniversalTime();

        var response = await studentService.CreateStudent(createStudentDto);
        if (response.IsSuccess)
        {
            return Redirect("/student/get");
        }

        Messages.Add(response.Message!);
        return Page();
    }
}