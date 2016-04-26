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
            public bool Contains(int key)
            {
                //check to see if it contains a key
                return true;
            }

            public void Add(int key, string value)
            {
                //add the cache to the value
            }

            public string Get(int key, CacheAction action)
            {
                action(key);
                return "what's up my GlipGlops";
            }
        }

        private string LoadValue(int key)
        {
            return "Glip glop";
        }
        public void abusedProcedure()
        {
            var key = 123;
            var cache = new Cache();

            var value = cache.Get(key);
            if (value == null)
            {
                value = LoadValue(key);
                cache.Add(key, value);
            }
        }
    }
}
