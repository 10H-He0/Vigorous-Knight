using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Poll
{
    public static Object_Poll instance;
    public Dictionary<string, Queue<GameObject>> objectpool = new Dictionary<string, Queue<GameObject>>();
    public GameObject pool;

    public static Object_Poll Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Object_Poll();
            }
            return instance;
        }
    }

    public GameObject getObject(GameObject prefeb)
    {
        GameObject _object;
        if (!objectpool.ContainsKey(prefeb.name) || objectpool[prefeb.name].Count == 0)
        {
            _object = GameObject.Instantiate(prefeb);
            pushObject(_object);
            if (pool == null)
            {
                pool = new GameObject("ObjectPool");
            }
            GameObject child = GameObject.Find(prefeb.name);
            if (!child)
            {
                child = new GameObject(prefeb.name);
                child.transform.SetParent(pool.transform);
            }
            _object.transform.SetParent(child.transform);
        }
        _object = objectpool[prefeb.name].Dequeue();
        _object.SetActive(true);
        return _object;
    }

    public void pushObject(GameObject prefeb)
    {
        string _name = prefeb.name.Replace("(Clone)", string.Empty);
        if (!objectpool.ContainsKey(_name))
        {
            objectpool.Add(_name, new Queue<GameObject>());
        }
        objectpool[_name].Enqueue(prefeb);
        prefeb.SetActive(false);
    }
}
