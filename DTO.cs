namespace DTOAndSRM;

public readonly record struct ReadUser(int Id, string Name,int Age, string Email, string PhoneNumber);

public readonly record struct CreateUser(string Name,int Age, string Email, string PhoneNumber);

public readonly record struct UpdateUser(int Id,string Name,int Age, string Email, string PhoneNumber);