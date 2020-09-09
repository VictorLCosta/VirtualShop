using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace VirtualShop.Libraries.Session
{
    public class Session
    {
        IHttpContextAccessor _context;

        public Session(IHttpContextAccessor context)
        {
            _context = context;
        }

        public void Create(string Key, string Valor) 
        {
            _context.HttpContext.Session.SetString(Key, Valor);
        }

        public string Read(string Key) 
        {
            return _context.HttpContext.Session.GetString(Key);
        }

        public void Update(string Key, string Valor) 
        {
            if (Exists(Key))
            {
                _context.HttpContext.Session.Remove(Key);
            }
            else 
            {
                _context.HttpContext.Session.SetString(Key, Valor);
            }

        }

        public void Delete(string Key) 
        {
            _context.HttpContext.Session.Remove(Key);
        }

        public bool Exists(string Key)
        {
            if(_context.HttpContext.Session.GetString(Key) == null)
            {
                return false;
            }

            return true;
            
        }

        public void RemoveAll()
        {
            _context.HttpContext.Session.Clear();
        }
    }
}
