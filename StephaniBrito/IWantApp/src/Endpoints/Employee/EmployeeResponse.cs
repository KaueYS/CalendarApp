namespace IWantApp.Endpoints.Employee
{
    public class EmployeeResponse
    {
        //public EmployeeResponse(string nome, string email)
        //{
        //    Nome = nome;
        //    Email = email;
        //}

        //public string Nome { get; }
        //public string Email { get; }

        public record EmployeeRequest(string Email,string Name);
       


    }
}
