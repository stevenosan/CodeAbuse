using System.Collections.Generic;

namespace CodeAbuse.Callbacks
{
    public delegate string CacheAction(int key);

    public class CacheWithCallback
    {
        private readonly Dictionary<int, string> _cache = new Dictionary<int, string>();

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
            if (!Contains(key))
            {
                Add(key, action(key));
            }

            string value;

            _cache.TryGetValue(key, out value);

            return value;
        }
    }

    public class GoodCallbacksExample
    {
        public void NewWayToCall()
        {
            var key = 123;
            var cache = new CacheWithCallback();

            var value = cache.Get(key, LoadValue);
        }

        private string LoadValue(int key)
        {
            return "Glip glop";
        }
    }
}