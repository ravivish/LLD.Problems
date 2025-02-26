
namespace LLD.Problems.DataStructures;

internal class DsImplBase
{
    #region LRU
    internal static void SetUpLRU()
    {
        var lruCache = new LRUCache<int, string>(3);

        lruCache.Put(1, "A");
        lruCache.Put(2, "B");
        lruCache.Put(3, "C");

        Console.WriteLine(lruCache.Get(1)); // Should print "A"

        lruCache.Put(4, "D"); // This should evict key 2 ("B")

        Console.WriteLine(lruCache.Get(2)); // Should print default (null or empty string)
        Console.WriteLine(lruCache.Get(3)); // Should print "C"
        Console.WriteLine(lruCache.Get(4)); // Should print "D"
    }
    #endregion

    #region Map
    internal static void SetUpMap()
    {
        #region Map Setup
        //CheckLoadFactorOfDictionary();

        var map = new Map<string, int>();
        for (int i = 1; i <= 30; i++)
        {
            map.Add($"Key{i}", i);
        }

        //map.RemoveKey("Key1");
        //map.RemoveKey("Key5");

        for (int i = 1; i <= 30; i++)
        {
            string key = $"Key{i}";
            Console.WriteLine("Key:{0}, Value:{1}",key, map.GetValue(key));
        }

        #endregion
    }


    static void CheckLoadFactorOfDictionary()
    {
        Console.WriteLine("C# Dictionary Load Factor");
        var dictionary = new Dictionary<int, string>();

        for (int i = 0; i < 100; i++)
        {
            dictionary.Add(i, $"Value {i}");
        }

        Console.WriteLine($"Count: {dictionary.Count}");
        Console.WriteLine($"Capacity: {GetCapacity(dictionary)}");
        Console.WriteLine($"Load Factor: {dictionary.Count / (float)GetCapacity(dictionary):F2}");

        static float GetCapacity(Dictionary<int, string> dictionary1)
        {
            var field = typeof(Dictionary<int, string>)
                            .GetField("_buckets", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var buckets = (int[])field?.GetValue(dictionary1);
            return buckets.Length;
        }
    }

    #endregion
}
