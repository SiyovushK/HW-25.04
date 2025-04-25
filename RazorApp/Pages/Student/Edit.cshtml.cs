using Domain.DTOs.StudentDTOs;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages.Student;

public class Edit(IStudentService studentService) : PageModel
{
    [BindProperty]
    public GetStudentDTO updateStudent { get; set; } = new();
    public List<string> Messages { get; set; } = [];

    public async Task<IActionResult> OnGetAsync(int Id)
    {
        var response = await studentService.GetStudentById(Id);
        if (!response.IsSuccess)
        {
            return StatusCode(response.StatusCode, response.Message!);
        }

        updateStudent = new GetStudentDTO()
        {
            StudentId = response.Data!.StudentId,
            FirstName = response.Data.FirstName,
            LastName = response.Data.LastName,
            BirthDate = response.Data.BirthDate
        };

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            Messages = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            return Page();
        }

        updateStudent.BirthDate = updateStudent.BirthDate.ToUniversalTime();
        var result = await studentService.UpdateStudent(updateStudent.StudentId, updateStudent);
        if (result.IsSuccess)
        {
            return Redirect("/student/get");
        }

        Messages.Add("Student couldn't be updated");
        return Page();
    }
}