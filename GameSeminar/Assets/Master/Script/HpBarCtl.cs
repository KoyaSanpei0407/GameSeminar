using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarCtl : MonoBehaviour
{
    Slider slider;

    float m_Hp = 10;
    // Start is called before the first frame update
    void Start()
    {
        slider = GameObject.Find("Slider").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        m_Hp -= 0.01f;
        if (m_Hp < 0)
        {
            m_Hp = 10;
        }
        slider.value = m_Hp;
    }
}
