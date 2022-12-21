using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] int _life = 3;
    public Sprite TreeTrunk;
    public GameObject Branch;

    public void ReduceLife()
    {
        _life--;

        if (_life == 0)
        {
            enabled = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = TreeTrunk;

            System.Random rand = new System.Random();

            GameObject branch1 = GameObject.Instantiate(Branch);
            branch1.transform.position = new Vector3(gameObject.transform.position.x + .8f, gameObject.transform.position.y + .5f, gameObject.transform.position.z);

            GameObject branch2 = GameObject.Instantiate(Branch);
            branch2.transform.position = new Vector3(gameObject.transform.position.x - .7f, gameObject.transform.position.y - .6f, gameObject.transform.position.z);

            GameObject branch3 = GameObject.Instantiate(Branch);
            branch3.transform.position = new Vector3(gameObject.transform.position.x - .8f, gameObject.transform.position.y + .7f, gameObject.transform.position.z);
        }
    }
}
