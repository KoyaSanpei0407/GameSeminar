using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarCtl : MonoBehaviour
{
    public GameObject player;
    Slider slider;
    public float Y_pos = -0.5f;
    float m_Hp = 10;
    // Start is called before the first frame update
    void Start()
    {
        slider = GameObject.Find("Slider").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = player.transform.position;
        pos.y = pos.y + Y_pos;
        transform.position = pos;

        slider.value = m_Hp;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag== "bullet")
        {
            m_Hp -= 1;
        }
    }
}
