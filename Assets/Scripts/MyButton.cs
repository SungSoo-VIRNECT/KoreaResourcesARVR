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

        GamePlay.m_Instance.ClickProc(str);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
