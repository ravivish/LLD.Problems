## LRUCache Class ReadMe
### Overview
The LRUCache class is a custom implementation of a Least Recently Used (LRU) cache data structure. It allows you to store key-value pairs and provides efficient operations for adding, retrieving, and removing elements.

### Key Features
- Efficient Key-Value Storage: The LRUCache class uses a hash table to store key-value pairs and a linked list to maintain the order of access.
- Capacity Limit: The LRUCache class has a specified capacity, which determines the maximum number of key-value pairs that can be stored in the cache.
- Efficient Get Operation: The Get method retrieves the value associated with a given key. If the key is not found, it returns the default value for the specified type.
- Efficient Put Operation: The Put method adds or updates a key-value pair in the cache. If the cache is full, the least recently used item is removed to make space for the new item.
- Thread Safety: The LRUCache class is thread-safe, allowing for concurrent access to the data structure.

### Usage
To use the LRUCache class, create an instance of the class with the desired capacity:

```csharp
var cache = new LRUCache<int, string>(3);
```

You can then add key-value pairs to the cache using the Put method:
```csharp
cache.Put(1, "A");
cache.Put(2, "B");
cache.Put(3, "C");
```

To retrieve the value associated with a key, use the Get method:
```csharp
Console.WriteLine(cache.Get(1)); // Should print "A"
```

To remove a key-value pair from the cache, use the Put method with a different value for the same key:
```csharp
cache.Put(1, "X"); // This will remove the previous value associated with key 1
```

### Performance
The LRUCache class provides efficient performance for most operations. However, keep in mind that the performance may degrade if the cache is frequently filled to capacity.

### Thread Safety
The LRUCache class is thread-safe, allowing for concurrent access to the data structure. However, it is important to note that the Put and Get methods use locks to synchronize access to the cache. Therefore, performance may be impacted when multiple threads access the cache simultaneously.

