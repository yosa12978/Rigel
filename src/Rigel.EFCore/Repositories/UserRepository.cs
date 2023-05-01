using Rigel.EFCore.Data;

namespace Rigel.EFCore.Repositories
{
    public class UserRepository : BaseRepository<User, string>, IUserRepository
    {
        public UserRepository(DatabaseContext db) : base(db)
        {

        }

        public async Task<User?> FindByUsername(string username)
        {
            return await _db.users.FirstAsync(x => x.username == username);
        }

        public async Task<bool> IsUserExist(string username, string passwordHash)
        {
            return await _db.users.AnyAsync(x => x.username == username && x.password == passwordHash);
        }

        public async Task<bool> IsUsernameTaken(string username)
        {
            return await _db.users.AnyAsync(x => x.username == username);
        }

        public async Task<User?> FindUser(string username, string password) 
        {
            return await _db.users.FirstAsync(x => x.username == username && x.password == password);
        }
    }
}