using CityPulse.Data.Models;
using CityPulse.Services.Common;
using CityPulse.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static CityPulse.Common.EntityValidations;

public class CommentsController(ICommentsService commentsService) : Controller
{
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Comment comment)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrWhiteSpace(comment.Description) || userId == null)
        {
            return RedirectToAction("Details", "Reports", new { area = "", id = comment.ReportId });
        }
        comment.UserId = userId;
        await commentsService.AddComment(comment);
        comment.Description = string.Empty;
        return RedirectToAction("Details", "Reports", new { area = "", id = comment.ReportId });
    }

    [HttpGet]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create()
    {
        return View(new Comment());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        await commentsService.DeleteComment(id);
        return RedirectToAction("Details", "Reports", new { area = "", id = id });
    }
}