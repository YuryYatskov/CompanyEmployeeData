namespace UserDataAccounting.Web.Models;

public class CompanyModel
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}

public record GetCompanyByIdResponse(CompanyModel Company);