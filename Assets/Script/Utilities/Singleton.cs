using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError(typeof(T).ToString() + " has no instance");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this as T;
        // 或者 _instance = (T)this;
        Init();
        // 一旦加载实例，即进指定的行初始化
        // 如果没有被重写，那不执行任何操作
    }

    public virtual void Init()
    {

    }
}

