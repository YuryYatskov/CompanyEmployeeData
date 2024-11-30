# CompanyEmployeeData
User data accounting.

Replace this with appsettings.json

  "ConnectionStrings": {
    "Database": "Server=RB3\\SQL1;Database=UserDataAccountingDb;User Id=sa;Password=qw1234567890;Encrypt=False;TrustServerCertificate=True"

with

  "ConnectionStrings": {
    "Database": "Server=localhost;Database=UserDataAccountingDb;User Id=sa;Password=qw1234567890;Encrypt=False;TrustServerCertificate=True" .

Then in "Tools \ NuGet Package Manager \ Package Manager Console" select "Default project"
this is it "DataAccounting.Infrastructure" and execute the "Update-Database".
