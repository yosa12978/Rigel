namespace Rigel.Helpers.Interfaces
{
    public interface IPasswordHelper
    {
        string Hash(string password);
        bool Compare(string p1, string p2);
        string NewSalt(int length);
    }
}