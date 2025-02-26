using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLD.Problems.DataStructures
{
    public class LRUCache<TKey, TValue>
    {
        private readonly int _capacity;
        private readonly Dictionary<TKey, LinkedListNode<KeyValuePair<TKey, TValue>>> _cache;
        private readonly LinkedList<KeyValuePair<TKey, TValue>> _order;

        public LRUCache(int capacity)
        {
            _capacity = capacity;
            _cache = new Dictionary<TKey, LinkedListNode<KeyValuePair<TKey, TValue>>>(capacity);
            _order = new LinkedList<KeyValuePair<TKey, TValue>>();
        }

        public TValue Get(TKey key)
        {
            if (!_cache.ContainsKey(key))
            {
                return default(TValue); // Return default value if not found
            }

            // Move the accessed item to the front (most recent)
            var node = _cache[key];
            _order.Remove(node);
            _order.AddFirst(node);
            return node.Value.Value;
        }

        public void Put(TKey key, TValue value)
        {
            if (_cache.ContainsKey(key))
            {
                // Remove the old node if the key already exists
                var node = _cache[key];
                _order.Remove(node);
                _cache.Remove(key);
            }

            if (_cache.Count >= _capacity)
            {
                // Remove the least recently used item (from the back)
                var lastNode = _order.Last;
                _order.RemoveLast();
                _cache.Remove(lastNode.Value.Key);
            }

            // Add the new item at the front (most recent)
            var newNode = new LinkedListNode<KeyValuePair<TKey, TValue>>(new KeyValuePair<TKey, TValue>(key, value));
            _order.AddFirst(newNode);
            _cache[key] = newNode;
        }
    }
}
