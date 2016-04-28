using System;
using System.Collections.Generic;

namespace CodeAbuse.Callbacks
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
            string value;
            if (!_cache.TryGetValue(key, out value))
            {
                throw new Exception("That key doesn't exist yet fool! Check Contains() first next time!");
            }
            return value;
        }
    }

    class BadCallbacksExample
    {
        public void ExpectedProcedure()
        {
            var cache = new Cache();
            string value;
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
            
            // This will throw an exception because we didn't check if the key exists first
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
