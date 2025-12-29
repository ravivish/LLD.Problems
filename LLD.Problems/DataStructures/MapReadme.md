# Map Class ReadMe

## Overview
The Map class is a custom implementation of a hash map data structure. It is designed to store key-value pairs and provide efficient operations for adding, retrieving, and removing elements.

### Key Features
Efficient Key-Value Storage: The Map class uses a hash function to map keys to buckets, allowing for fast lookup times.
Load Factor Control: The Map class automatically rehashes when the load factor exceeds a certain threshold, ensuring optimal performance.
Thread Safety: The Map class is thread-safe, allowing for concurrent access to the data structure.
### Usage
To use the Map class, create an instance of the class with the desired capacity:

```csharp
var map = new Map<string, int>();
```
You can then add key-value pairs to the map using the Add method:
```csharp
map.Add("Key1", 1);
map.Add("Key2", 2);
```
To retrieve the value associated with a key, use the GetValue method:
```csharp
int value = map.GetValue("Key1");
```
To remove a key-value pair from the map, use the RemoveKey method:
```csharp
map.RemoveKey("Key2");
```

### Performance
The Map class provides efficient performance for most operations. However, keep in mind that the performance may degrade if the load factor exceeds a certain threshold. In such cases, the Map class automatically rehashes to improve performance.

### Thread Safety
The Map class is thread-safe, allowing for concurrent access to the data structure. However, it is important to note that the Map class uses a lock to synchronize access to the data structure. Therefore, performance may be impacted when multiple threads access the data structure simultaneously.