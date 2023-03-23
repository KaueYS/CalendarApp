
using Dapper;
using IWantApp.Infra.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

namespace IWantApp.Endpoints.Employee;

public class EmployeeGetAll
{
    public static string Template => "/employees";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };

    public static Delegate handle => Action;

    public static IResult Action(int? page, int? rows, IConfiguration configuration)
    {
        var db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        var employees = db.Query<EmployeeResponse>(@"select Email, ClaimValue as Name
        from AspNetUserClaims c inner join AspNetUsers u on c.UserId = u.Id and claimType = 'Name'");

        return Results.Ok(employees);
    }


}


