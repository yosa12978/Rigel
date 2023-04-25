using Rigel.EFCore.Data;

namespace Rigel.EFCore.Repositories
{
    public class UserRepository : BaseRepository<User, string>, IUserRepository
    {
        public UserRepository(DatabaseContext db) : base(db)
        {

        }

        public Task<bool> IsUserExist(string username, string passwordHash)
        {
            return _db.users.AnyAsync(x => x.username == username && x.password == passwordHash);
        }

        public Task<bool> IsUsernameTaken(string username)
        {
            return _db.users.AnyAsync(x => x.username == username);
        }
    }
}