using DataAccounting.Domain.Models;

namespace DataAccounting.Infrastructure.Data.Extensions;

internal class InitialData
{
    public static IEnumerable<Company> Companys =>
        [
            Company.Create("Liam",
                "Cognitive biases are tendencies to think in a certain way that can lead to systematic deviations from the standard of rationality or sound judgment (or common sense). They are often studied in psychology and behavioral economics.\r\n\r\nAlthough the existence of such biases has been confirmed by reproducible research, scientists still argue about how to classify and explain biases. Some biases are the result of rules for processing information in the brain, such as mental \"pathways.\" These rules are called heuristics and are used by the brain to make decisions or form judgments. Biases in judgments or decisions can also arise from motivations, such as when beliefs are distorted by wishful thinking. Some biases have a range of cognitive (\"cold\") or motivational (\"hot\") explanations. Both effects can be present at the same time.\r\n\r\nThere is also some debate about whether some biases are purely irrational or whether they may have a positive effect on attitudes or behavior. For example, when people first meet, they often ask each other straightforward questions. This may seem biased because the goal is to confirm pre-existing beliefs about the other person. This example of confirmation bias is cited by some scholars as an example of social skills, namely the ability to connect with another person.\r\n\r\nMost research on biases is conducted in humans. However, some animal studies have been published. For example, hyperbolic discounting has also been observed in rats, pigeons, and monkeys.[7]")
        ];

    public static IEnumerable<Department> Departments =>
        [
            Department.Create("Sales"),
            Department.Create("Marketing"),
            Department.Create("Accounts"),
            Department.Create("Administration"),
            Department.Create("Admin"),
            Department.Create("Education"),
            Department.Create("IT"),
            Department.Create("Human Resources")
        ];

    public static IEnumerable<Job> Jobs =>
        [
            Job.Create("SA Rep"),
            Job.Create("Clerk"),
            Job.Create("IT Admin"),
            Job.Create("HR Clerk"),
            Job.Create("AD Asst"),
            Job.Create("HR Dir"),
            Job.Create("EX Dir"),
            Job.Create("SA Dir")
        ];

    public static IEnumerable<Employee> Employees =>
        [
            Employee.Create("Smith Getz", "Old Town, Barcelona, ​​Spain", "380000000001", new DateTime (1980, 01, 29)),
            Employee.Create("Martin Devis", "Sant Martí, 08019 Barcelona, ​​Spain", "380000000002", new DateTime (1985, 02, 23)),
            Employee.Create("Chris King", "142 Rue Hassiba Ben Bouali, Sidi M'Hamed 16014, Algeria", "380000000003", new DateTime (1990, 03, 10)),
            Employee.Create("John Kochhar", "14-30 Broadway, Astoria, NY 11106, United States", "380000000004", new DateTime (1991, 04, 03)),
            Employee.Create("Diana Anikin", "1781 Van Dyke St, Detroit, MI 48214, United States", "380000000005", new DateTime (1992, 05, 05)),
            Employee.Create("Ouve Batiuk", "19-13 Tykhaya St, Kyiv, 02000", "380000000006", new DateTime (1993, 06, 07)),
            Employee.Create("Jennifer Galatsan", "13 Vaclav Havel Blvd, Kyiv, 02000", "380000000007", new DateTime (1995, 07, 13)),
            Employee.Create("Bob Dyak", "51 Volodymyr Ivasyuk Ave, Kyiv, Kyiv Oblast, 04213", "380000000008", new DateTime (2000, 01, 01)),
            Employee.Create("Ravi Izotova", "24/7 Instytutska St, 22, Kyiv, 01021", "380000000009", new DateTime (2001, 12, 22)),
        ];

    public static IEnumerable<Wage> Wages =>
        [
            Wage.Create(1, 1, 1, new DateTime(2020, 12, 01), 4000),
            Wage.Create(2, 2, 2, new DateTime(2021, 11, 01), 2500),
            Wage.Create(3, 3, 3, new DateTime(2018, 01, 01), 4200),
            Wage.Create(4, 4, 4, new DateTime(2020, 02, 01), 2500),
            Wage.Create(5, 5, 5, new DateTime(2019, 03, 01), 5000),
            Wage.Create(6, 6, 6, new DateTime(2017, 04, 01), 3000),
            Wage.Create(7, 7, 7, new DateTime(2019, 05, 01), 6500),
            Wage.Create(8, 8, 8, new DateTime(2020, 06, 01), 8000),
            Wage.Create(5, 5, 9, new DateTime(2021, 07, 01), 6500),
            Wage.Create(6, 6, 1, new DateTime(2022, 09, 01), 3200),
            Wage.Create(7, 7, 2, new DateTime(2023, 10, 01), 5200),
            Wage.Create(8, 8, 3, new DateTime(2024, 11, 01), 6700),
            Wage.Create(1, 1, 1, new DateTime(2021, 05, 01), 5000),
            Wage.Create(4, 4, 4, new DateTime(2021, 05, 01), 4400),
            Wage.Create(7, 7, 7, new DateTime(2022, 06, 01), 6900),
            Wage.Create(8, 8, 8, new DateTime(2021, 07, 01), 9000),
            Wage.Create(8, 8, 3, new DateTime(2024, 12, 01), 7100),
            Wage.Create(1, 1, 1, new DateTime(2022, 04, 01), 5000),
            Wage.Create(4, 4, 4, new DateTime(2022, 08, 01), 4900),
            Wage.Create(8, 8, 8, new DateTime(2023, 10, 01), 9500),
        ];
}
