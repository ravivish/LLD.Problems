namespace LLD.Problems.DataStructures;

public class MapNode<K, V>
{
    internal K Key;
    internal V Value;
    internal MapNode<K, V> next;
    public MapNode(K key, V value)
    {
        this.Key = key;
        this.Value = value;
    }

}

internal class Map<K,V>
{
    private List<MapNode<K, V>> bucket;
    int size;
    int numBucket;
    public Map()
    {
        //numBucket = 20;
        numBucket = 5;//To see the output of Rehashing
        bucket = new List<MapNode<K, V>>();
        for (int i = 0; i < numBucket; i++)
        {
            bucket.Add(null);
        }
    }

    private int GetBucketIndex(K key)
    {
        int hashcode = key.GetHashCode();
        return Math.Abs(hashcode % numBucket);
    }

    public void Add(K key, V value)
    {
        int bucketIndex = GetBucketIndex(key);
        MapNode<K, V> head = bucket[bucketIndex];
        while (head != null)
        {
            if (head.Key.Equals(key))
            {
                head.Value = value;
                return;
            }
            head = head.next;
        }
        MapNode<K, V> newNode = new MapNode<K, V>(key, value);
        newNode.next = bucket[bucketIndex];
        bucket[bucketIndex] = newNode;
        size++;

        double loadFactor = GetLoadFactor();
        if (loadFactor > 0.72)
        {
            Rehash();
        }
    }

    private double GetLoadFactor()
    {
        return (1.00 * size) / numBucket;
    }

    private void Rehash()
    {
        Console.WriteLine("Rehashing: bucket:{0}, size:{1}",numBucket,size);

        var temp = bucket;

        bucket = new List<MapNode<K, V>>();
        numBucket = numBucket * 2;
        size = 0;
        for (int i = 0; i < numBucket; i++)
        {
            bucket.Add(null);
        }
        for (int i = 0; i < temp.Count; i++)
        {
            MapNode<K, V> head = temp[i];
            while (head != null)
            {
                Add(head.Key, head.Value);
                head = head.next;
            }
        }
    }

    public V GetValue(K key)
    {
        int bucketIndex = GetBucketIndex(key);
        MapNode<K, V> head = bucket[bucketIndex];
        while (head != null)
        {
            if (head.Key.Equals(key))
            {
                return head.Value;
            }
            head = head.next;
        }
        return default(V);// V can be primitve type also, so can not return null
    }

    public V RemoveKey(K key)
    {
        int bucketIndex = GetBucketIndex(key);
        MapNode<K, V> head = bucket[bucketIndex];
        MapNode<K, V> prev = null;
        while (head != null)
        {
            if (head.Key.Equals(key))
            {
                if (prev == null)
                {
                    bucket[bucketIndex] = head.next;
                }
                else
                {
                    prev.next = head.next;
                }
                size--;
                return head.Value;
            }
            prev = head;
            head = head.next;
        }
        return default(V);// V can be primitve type also, so can not return null
    }
    public int Count { get { return size; } }
}
