using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterOrLavaScript : MonoBehaviour
{
    public Sprite enemySprite;
    public Sprite normalSprite;
    public float changeTime = 4f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TagSwitcherCoroutine());
    }

    IEnumerator TagSwitcherCoroutine()
    {
        while (true)
        {
            gameObject.tag = "enemy";
            GetComponent<SpriteRenderer>().sprite = enemySprite;
            yield return new WaitForSeconds(changeTime);

            gameObject.tag = "untagged";
            GetComponent<SpriteRenderer>().sprite = normalSprite;
            yield return new WaitForSeconds(changeTime);
        }
    }
}
