using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAbuse.Callbacks
{
    class BadCallBacks
    {
        public class Cache
        {
            private Dictionary<int, string> _cache = new Dictionary<int, string>();
            
            public bool Contains(int key)
            {
                return _cache.ContainsKey(key);
            }

            public void Add(int key, string value)
            {
                _cache.Add(key, value);
            }

            public string Get(int key)
            {
                string value = "";
                if (_cache.TryGetValue(key, value))
                {
                       return value;
                }
                throw new Exception("That key doesn't exist yet fool! Check Contains() first next time!");
            }
        }

        public void NormalProcedure()
        {
            var cache = new Cache();
            var value = "";
            var key = 5;

            if (cache.Contains(key))
            {
                value = cache.Get(key);
            }
            else
            {
                value = LoadValue(key);
                cache.Add(key, value);
            }
        }

        public void AbusedProcedure()
        {
            var cache = new Cache();
            var key = 123;
            
            var value = cache.Get(key);

            if (value == null)
            {
                value = LoadValue(key);
                cache.Add(key, value);
            }
        }
        
        private string LoadValue(int key)
        {
            return "Glip glop";
        }
    }
}
