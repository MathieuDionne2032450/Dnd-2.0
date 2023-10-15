using Api_DnD.Data;
using Api_DnD.Model;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace Api_DnD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KeyGenerator
    {
       
        /*
        //public async Task<ActionResult<IEnumerable<Key>>> GetAllKey()
        //{

        //    //return await _context.key.Select<>.ToListAsync();
        //}
        */

        private readonly DNDContext _context;

        public KeyGenerator(DNDContext context)
        {
            _context = context;
        }

        internal static readonly char[] chars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();

        [HttpGet("/GenererUniqueKey")]
        public async Task<Key> GenererUniqueKey()
        {
            bool verif = false;
            Key key;

            do
            {
                key = GenerateKeys();
                if(await _context.Key.FindAsync(key.ApiKey) == null)
                {
                    verif= true;
                }
            } while (verif == false);

            _context.Key.Add(key);
            await _context.SaveChangesAsync();

            return key;
            
        }

        static Key GenerateKeys()
        {
            int size = 32;
            byte[] data = new byte[4 * size];
            using (var crypto = RandomNumberGenerator.Create())
            {
                crypto.GetBytes(data);
            }
            StringBuilder result = new StringBuilder(size);
            for (int i = 0; i < size; i++)
            {
                var rnd = BitConverter.ToUInt32(data, i * 4);
                var idx = rnd % chars.Length;

                result.Append(chars[idx]);
            }
            return new Key(result.ToString(),Key.KEY_ROLE_USER);
        }

        [HttpGet("/VerifKey/{key}")]
        public async Task<string> VerifKey(string key)
        {
            Key existingKey = await _context.Key.FindAsync(key);
            
            if(existingKey != null)
            {
                return existingKey.Role;
            }

            return "null";
        }
    }
}
