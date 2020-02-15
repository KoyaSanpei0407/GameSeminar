using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBomb : MonoBehaviour
{
    public GameObject obj; public float span = 5f; private float currentTime = 0f; public float span_set = 2;
    // 2秒固定用      
    bool instantMode = false;
    void Start()
    {
    }
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > span)
        {
            if (!instantMode)
            {
                instantMode = true;
                StartCoroutine("instant");
            }
            currentTime = 0f;
        }
    }
    private IEnumerator instant()
    {
        float x = Random.Range(-8.0f, 8.0f);
        // 出現         
        float y = Random.Range(-4.0f, 4.0f);
        // 　　範囲         
        yield return new WaitForSeconds(1 * Time.deltaTime);
        Instantiate(obj, new Vector2(x, y), Quaternion.identity);
        instantMode = false;
        if (span > span_set)
        {
            span -= 0.5f;
        }
    }

}
