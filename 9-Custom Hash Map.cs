/*Implement a Custom Hash Map
Problem: Design and implement a basic hash map class with operations for insertion, deletion, and retrieval.
Hint: Use an array of linked lists to handle collisions using separate chaining.

*/
using System;
using System.Collections.Generic;


class MyHashMap
{
    private const int SIZE = 1000;
    private LinkedList<KeyValuePair<int, int>>[] map;


    public MyHashMap()
    {
        map = new LinkedList<KeyValuePair<int, int>>[SIZE];
    }


    private int GetHash(int key)
    {
        return key % SIZE;
    }


    public void Put(int key, int value)
    {
        int index = GetHash(key);
        if (map[index] == null)
            map[index] = new LinkedList<KeyValuePair<int, int>>();


        foreach (var pair in map[index])
        {
            if (pair.Key == key)
            {
                map[index].Remove(pair);
                break;
            }
        }


        map[index].AddLast(new KeyValuePair<int, int>(key, value));
    }


    public int Get(int key)
    {
        int index = GetHash(key);
        if (map[index] != null)
        {
            foreach (var pair in map[index])
            {
                if (pair.Key == key)
                    return pair.Value;
            }
        }
        return -1; // Not found
    }


    public void Remove(int key)
    {
        int index = GetHash(key);
        if (map[index] != null)
        {
            foreach (var pair in map[index])
            {
                if (pair.Key == key)
                {
                    map[index].Remove(pair);
                    break;
                }
            }
        }
    }


    static void Main()
    {
        MyHashMap hashMap = new MyHashMap();
        hashMap.Put(1, 10);
        hashMap.Put(2, 20);
        Console.WriteLine(hashMap.Get(1)); // Output: 10
        hashMap.Remove(1);
        Console.WriteLine(hashMap.Get(1)); // Output: -1
    }
}



