using Homework_8;
using static System.Console;

Employee employee = null;
bool flag = true;
string name = string.Empty;
int salary = 0;
while (flag)
{
    while (true)
    {
        Write("Введите имя сотрудника: ");
        name = ReadLine();
        if (string.IsNullOrEmpty(name))
            break;

        Write("Введите зарплату сотрудника: ");
        while (!int.TryParse(ReadLine(), out salary))
        {
            WriteLine("Введите целочисленное значение");
            Write("Введите зарплату сотрудника: ");
        }
        employee = AddEmployee(employee, name, salary);
    }
    WriteLine("Список сотрудников и их зарплаты в порядке возрастания зарплат:");
    InOrderTraversal(employee);
    while (true)
    {
        Write("Введите зарплату, которую хотите найти: ");
        while (!int.TryParse(ReadLine(), out salary))
        {
            WriteLine("Введите целочисленное значение");
            Write("Введите зарплату, которую хотите найти: ");
        }
        var employeeName = FindEmployeeBySalary(employee, salary);
        WriteLine(employeeName);

        int choise = 0;
        WriteLine("Введите 0 для начала программы или 1 для повторного поиска зарплаты:");
        while (!int.TryParse(ReadLine(), out choise))
        {
            WriteLine("Введите значение (0 или 1)");
            WriteLine("Введите 0 для начала программы или 1 для повторного поиска зарплаты:");
        }
        if (choise == 1)
            continue;
        else
        {
            break;
        }
    }
}

void InOrderTraversal(Employee? root)
{
    if (root != null)
    {
        InOrderTraversal(root.Left);
        WriteLine($"{root.Name} => {root.Salary}");
        InOrderTraversal(root.Right);
    }
}

Employee? AddEmployee(Employee? employee, string name, int salary)
{
    if (employee == null)
        employee = new Employee { Name = name, Salary = salary };
    else if (salary < employee.Salary)
        employee.Left = AddEmployee(employee.Left, name, salary);
    else
        employee.Right = AddEmployee(employee.Right, name, salary);

    return employee;
}

string FindEmployeeBySalary(Employee root, int salary)
{
    if (root == null)
    {
        return "такой сотрудник не найден";
    }

    if (salary == root.Salary)
    {
        return root.Name;
    }
    else if (salary < root.Salary)
    {
        return FindEmployeeBySalary(root.Left, salary);
    }
    else
    {
        return FindEmployeeBySalary(root.Right, salary);
    }
}