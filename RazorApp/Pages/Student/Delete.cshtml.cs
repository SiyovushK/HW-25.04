using System.ComponentModel.DataAnnotations;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages.Student;

public class Delete(IStudentService studentService) : PageModel
{
    [Required]
    [BindProperty(SupportsGet = true)]
    public int Id { get; set; }

    public List<string> Messages { get; set; } = [];

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            Messages = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            return Page();
        }

        var result = await studentService.DeleteStudent(Id);
        if (result.IsSuccess)
        {
            return Redirect("/student/get");
        }

        Messages.Add("Student couldn't be deleted");
        return Page();
    }
}