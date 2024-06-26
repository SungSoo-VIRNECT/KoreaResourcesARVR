using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnClick()
    {
        string str = gameObject.name;

        if (str == "ButtonCarPark")
        {
            GamePlay.m_Instance.ChangeLocation(true);
        }
        if (str == "ButtonJang")
        {
            GamePlay.m_Instance.ChangeLocation(false);
        }

        //
        if (str == "ButtonWaterLevel1")
        {
            GamePlay.m_Instance.ChangeWaterLevel(0);
        }
        if (str == "ButtonWaterLevel2")
        {
            GamePlay.m_Instance.ChangeWaterLevel(1);
        }
        if (str == "ButtonWaterLevel3")
        {
            GamePlay.m_Instance.ChangeWaterLevel(2);
        }
        if (str == "ButtonWaterLevel4")
        {
            GamePlay.m_Instance.ChangeWaterLevel(3);
        }

        //
        if (str == "ButtonShowInfo")
        {
            GamePlay.m_Instance.OnButtonShowInfo();
        }
        if (str == "ButtonCloseInfo")
        {
            GamePlay.m_Instance.OnButtonCloseInfo();
        }

        //gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
