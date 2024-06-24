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

        //gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
