using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAbuse.Callbacks
{
    class GoodCallBacks
    {
        public delegate string CacheAction(int key);

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

            public string Get(int key, CacheAction action)
            {
                if (!Contains(key)) {
                    Add(key, action(key))
                }
                
                string value = "";
                
                _cache.TryGetValue(key, value);
                
                return value;
            }
        }

        public void NewWayToCall()
        {
            var key = 123;
            var cache = new Cache();

            var value = cache.Get(key, LoadValue);
        }
        
        private string LoadValue(int key)
        {
            return "Glip glop";
        }
    }
}
