using System.Text;
using Rigel.Helpers.Interfaces;

namespace Rigel.Helpers.Impl
{
    public class IdGenerator : IIdGenerator
    {
        private object instance = new object();
        public string NewId()
        {
            lock (instance)
            {
                Thread.Sleep(1);
                long ticks = DateTime.Now.Ticks;
                return this.ToBase62(ticks);
            }
        }

        private string ToBase62(long input)
        {
            string alphabet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            long nbase = (long)alphabet.Length;
            string res = "";
            while(input > 0)
            {
                res = alphabet[(int)(input%nbase)] + res;
                input /= nbase;
            }
            return res;
        }
    }
}