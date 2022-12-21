using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] int _life = 3;

    private void Update()
    {
        if(_life == 0)
        {
            GameObject.Destroy(gameObject);
        }
    }

    public void ReduceLife()
    {
        _life--;
    }
}
