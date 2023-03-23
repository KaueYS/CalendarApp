using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace IWantApp.Endpoints.Employee;

public class EmployeePost
{
    public static string Template => "/employees";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };

    public static Delegate handle => Action;

    public static IResult Action(EmployeeRequest employeeRequest, UserManager<IdentityUser> userManager)
    {
        var user = new IdentityUser
        {
            UserName = employeeRequest.Email,
            Email = employeeRequest.Email
        };
        var result = userManager.CreateAsync(user, employeeRequest.Password).Result;
        if (!result.Succeeded)
            return Results.BadRequest(result.Errors.First());

        var userClaims = new List<Claim>
        {
            new Claim("Employee", employeeRequest.EmployeeCode),
            new Claim("Name", employeeRequest.Name)

        };
        var claimResult = userManager.AddClaimsAsync(user, userClaims).Result;
        if (claimResult.Succeeded)
            return Results.BadRequest();

        return Results.Created($"/employess/{user.Id}", user.Id);
    }
}


