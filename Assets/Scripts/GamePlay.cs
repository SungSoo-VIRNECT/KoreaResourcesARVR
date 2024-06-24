using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour
{
    public GameObject m_OVRCameraRig = null;
    public GameObject m_Cylinder = null;
    public GameObject m_Canvas = null;

    public static GamePlay m_Instance = null;

    void Awake()
    {
        m_Instance = this;    
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ChangeWaterLevel(int n)
    {

    }

    public void ChangeLocation(bool bCarPark)
    {
        if (bCarPark)
        {
            m_OVRCameraRig.transform.localRotation = Quaternion.identity;
            m_Cylinder.transform.localRotation = Quaternion.identity;
        }
        else
        {
            m_OVRCameraRig.transform.localRotation = Quaternion.Euler(0, 160, 0);
            m_Cylinder.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
