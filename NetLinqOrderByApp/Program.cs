using ExampleClassLibrary;

var users = new List<User>()
{
    new("Sam", 35),
    new("Bobby", 31),
    new("Timophey", 29),
    new("Joe", 42),
    new("Leopold", 35),

    new("Sammy", 41),
    new("Bob", 19),
    new("Tim", 35),
    new("Joseph", 24),
    new("Leo", 30),
};

var usersSortAgeO = from u in users
                    orderby u.Age descending
                    select u;

var usersSortNameO = from u in users
                    orderby u.Name descending
                    select u;

var usersSortAgeM = users.OrderBy(u => u.Age);
var usersSortNameM = users.OrderBy(u => u.Name);

var usersSortAgeDescM = users.OrderByDescending(u => u.Age);
var usersSortNameDescM = users.OrderByDescending(u => u.Name);

//foreach (var user in usersSortNameO)
//    Console.WriteLine($"Name {user.Name} age {user.Age}");


var usersSortNameAgeO = from u in users
                    orderby u.Name, u.Age
                    select u;

var usersSortAgeNameO = from u in users
                        orderby u.Age descending,
                                u.Name
                        select u;

var usersSortNameAgeM = users.OrderBy(u => u.Name).ThenByDescending(u => u.Age);


//foreach (var user in usersSortNameAgeM)
//    Console.WriteLine($"Name {user.Name} age {user.Age}");


var usersSortNameLength = users.OrderBy(
        u => u,
        new StrLengthCompare()
    );

foreach (var user in usersSortNameLength)
    Console.WriteLine($"Name {user.Name} age {user.Age}");

class StrLengthCompare : IComparer<User>
{
    public int Compare(User? x, User? y)
    {
        int xl = x?.Name?.Length ?? 0;
        int yl = y?.Name?.Length ?? 0;
        return xl - yl;
    }
}