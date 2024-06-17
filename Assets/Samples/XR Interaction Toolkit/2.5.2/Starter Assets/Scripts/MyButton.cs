using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnClick()
    {
        string s = gameObject.name;

        if (s == "ButtonWaterLevel0")
        {
            GamePlay.m_Instance.OnButtonWaterLevel(0);
        }
        if (s == "ButtonWaterLevel1")
        {
            GamePlay.m_Instance.OnButtonWaterLevel(1);
        }
        if (s == "ButtonWaterLevel2")
        {
            GamePlay.m_Instance.OnButtonWaterLevel(2);
        }
        if (s == "ButtonWaterLevel3")
        {
            GamePlay.m_Instance.OnButtonWaterLevel(3);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
