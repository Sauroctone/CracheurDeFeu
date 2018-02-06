using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarrelRegenBehaviour : MonoBehaviour {

    public float regenTimer;

    public SpriteRenderer spriteRend;
    public BoxCollider2D barrelCol;
    public Image loader;
    public AlcoholManager alcoholMan;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" && alcoholMan.alcoholCount < 100)
        {
            alcoholMan.alcoholCount += alcoholMan.bottleValue;
            barrelCol.enabled = false;
            spriteRend.enabled = false;
            StartCoroutine(Regen());
        }
    }

    IEnumerator Regen()
    {
        float timer = 0;

        while (timer < regenTimer)
        {
            loader.fillAmount = timer / regenTimer; 
            timer += Time.deltaTime;
            yield return null;
        }

        barrelCol.enabled = true;
        spriteRend.enabled = true;
        loader.fillAmount = 0;
    }
}
