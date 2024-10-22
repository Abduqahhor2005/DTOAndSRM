namespace DTOAndSRM.Service;

public interface IUserService
{
    IEnumerable<ReadUser> GetAllUsers();
    ReadUser? GetUserById(int id);
    bool CreateUser(CreateUser user);
    bool UpdateUser(UpdateUser user);
    bool DeleteUser(int id);
}