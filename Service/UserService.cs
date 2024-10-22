namespace DTOAndSRM.Service;

public class UserService(DataContext context) : IUserService
{
    public IEnumerable<ReadUser> GetAllUsers()
    {
        var users = (from u in context.Users
            where u.IsDeleted == false
            select new ReadUser()
            {
                Id = u.Id,
                Name = u.Name,
                Age = u.Age,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber
            }).AsEnumerable();
        return users;
    }

    public ReadUser? GetUserById(int id)
    {
        var user = (from u in context.Users
            where u.IsDeleted == false
            select new ReadUser()
            {
                Id = u.Id,
                Name = u.Name,
                Age = u.Age,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber
            }).FirstOrDefault(x=>x.Id==id);
        return user;
    }

    public bool CreateUser(CreateUser user)
    {
        bool existUser = context.Users.Any(x =>
            x.Name.ToLower() == user.Name.ToLower() && x.IsDeleted == false);
        if (existUser) return false;
        context.Users.Add(new()
        {
            Id = context.Users.Max(x => x.Id) + 1,
            Name = user.Name,
            Age = user.Age,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber
        });
        return true;
    }

    public bool UpdateUser(UpdateUser user)
    {
        User? existingUser = context.Users.FirstOrDefault(x => x.IsDeleted == false && x.Id == user.Id);
        if (existingUser is null) return false;

        existingUser.Name = user.Name;
        existingUser.Age = user.Age;
        existingUser.Email = user.Email;
        existingUser.PhoneNumber = user.PhoneNumber;
        existingUser.UpdatedAt = DateTime.UtcNow;
        return true;
    }

    public bool DeleteUser(int id)
    {
        User? existingUser = context.Users.FirstOrDefault(x => x.Id == id);
        if (existingUser is null) return false;
        existingUser.IsDeleted = true;
        existingUser.DeletedAt = DateTime.UtcNow;
        existingUser.UpdatedAt = DateTime.UtcNow;
        return true;
    }
}