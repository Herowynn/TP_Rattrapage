using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    int _life = 5;
    public GameObject Canvas;

    public void ReduceLife()
    {
        _life--;

        if (_life == 0)
        {
            gameObject.GetComponent<Animator>().SetTrigger("Die");
            StartCoroutine("Death");
        }
        else
            gameObject.GetComponent<Animator>().SetTrigger("Hurt");
    }

    public void ActivateCanvas(bool state)
    {
        Canvas.SetActive(state);
    }


    IEnumerator Death()
    {
        yield return new WaitForSeconds(.83f);
        GameObject.Destroy(gameObject);
    }
}
