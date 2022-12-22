using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    public Sprite[] SpritesCarrot;
    public GameObject ItemCarrot;
    public GameObject Canvas;

    float GrowTime = 2f;

    public void PickCarrot()
    {
        StartCoroutine("GrowCarrots");
    }

    IEnumerator GrowCarrots()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = SpritesCarrot[0];

        GameObject carrot = GameObject.Instantiate(ItemCarrot);
        carrot.transform.position = new Vector3(transform.position.x - .8f, transform.position.y, transform.position.z);

        yield return new WaitForSeconds(GrowTime);
        gameObject.GetComponent<SpriteRenderer>().sprite = SpritesCarrot[1];
    }

    public void ActivateCanvas(bool state)
    {
        Canvas.SetActive(state);
    }
}
