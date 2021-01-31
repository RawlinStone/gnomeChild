using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Component
{
    private static T instance;
    public static T Instance { get { return instance; } }

    [Tooltip("Singleton Property")]
    [SerializeField]
    private bool isPersistent = true;

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = GetComponent<T>();
            if (isPersistent)
            {
                DontDestroyOnLoad(gameObject);
            }
        }
        else
            Destroy(gameObject);
        //To add code in Awake for classes that inherit this, we say
        //protected override void Awake() { base.Awake() } and add the extras
    }

    private void OnDestroy()
    {
        if (instance == GetComponent<T>())
            instance = null;
    }
}
