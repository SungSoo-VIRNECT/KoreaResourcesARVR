using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour
{
    public GameObject m_OVRCameraRig = null;
    public GameObject m_Cylinder = null;
    public GameObject m_Canvas = null;

    public GameObject m_WaterPlane = null;

    public GameObject m_ButtonPanels = null;
    public GameObject m_InfoPanels = null;

    public GameObject[] m_ButtonLevels;
    public GameObject[] m_Infos;

    public GameObject m_ButtonShowInfo = null;
    public GameObject m_ButtonCloseInfo = null;

    public Sprite[] m_SpriteButtonOn;
    public Sprite[] m_SpriteButtonOff;

    public GameObject m_ButtonLocationCarPark = null;
    public GameObject m_ButtonLocationJang = null;
    public Image m_ImageCarParkOn;
    public Image m_ImageCarParkText;
    public Image m_ImageJangOn;
    public Image m_ImageJangText;

    float m_SmoothTime = 1.5f;
    Vector3 m_Velocity = Vector3.zero;

    Color m_HideColor = new Color(1, 1, 1, 0);

    int m_WaterLevel = 0;

    Vector3 m_WaterPosition = new Vector3(1.6f, 0, 4.6f);

    Vector3 m_RainEffectPosition = Vector3.zero;

    public GameObject m_RainEffect = null;

    Quaternion m_QtH = Quaternion.identity;
    Quaternion m_QtV = Quaternion.identity;

    public static GamePlay m_Instance = null;

    void Awake()
    {
        m_Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        ChangeLocation(true);
        ChangeWaterLevel(0, true);
        OnButtonCloseInfo();
    }

    void ResetWaterPosition()
    {
        float y = -4;
        if (m_WaterLevel == 1) y = -3;
        if (m_WaterLevel == 2) y = -2;
        if (m_WaterLevel == 3) y = -1;

        m_WaterPosition.y = y;
        //
        m_RainEffectPosition.y = y;
    }

    public void ChangeWaterLevel(int n, bool bResetNow = false)
    {
        m_WaterLevel = n;
        //
        for (int a = 0; a < m_ButtonLevels.Length; a++)
        {
            Image image = m_ButtonLevels[a].GetComponent<Image>();
            if (n == a)
            {
                image.sprite = m_SpriteButtonOn[a];
                m_Infos[a].SetActive(true);
            }
            else
            {
                image.sprite = m_SpriteButtonOff[a];
                m_Infos[a].SetActive(false);
            }
        }

        //
        ResetWaterPosition();
        //
        if (bResetNow)
        {
            m_WaterPlane.transform.position = m_WaterPosition;
            m_RainEffect.transform.position = m_RainEffectPosition;
        }
    }

    public void ChangeLocation(bool bCarPark)
    {
        if (bCarPark)
        {
            m_OVRCameraRig.transform.localRotation = Quaternion.identity;
            m_Cylinder.transform.localRotation = Quaternion.identity;

            //
            m_ImageCarParkOn.color = Color.white;
            m_ImageJangOn.color = m_HideColor;
            //
            m_QtV = Quaternion.identity;
            m_QtH = Quaternion.identity;
        }
        else
        {
            Quaternion qt = Quaternion.Euler(0, 160, 0);
            m_OVRCameraRig.transform.localRotation = qt;
            m_Cylinder.transform.localRotation = Quaternion.Euler(0, 180, 0);

            //
            m_ImageCarParkOn.color = m_HideColor;
            m_ImageJangOn.color = Color.white;
            //
            m_QtV = Quaternion.identity;
            m_QtH = qt;
        }
    }

    public void OnButtonShowInfo()
    {
        m_ButtonShowInfo.SetActive(false);
        m_InfoPanels.SetActive(true);
    }

    public void OnButtonCloseInfo()
    {
        m_ButtonShowInfo.SetActive(true);
        m_InfoPanels.SetActive(false);
    }

    public void ClickProc(string str)
    {
        //string str = gameObject.name;

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

    void WaterPositionProc()
    {
        m_WaterPlane.transform.position = Vector3.SmoothDamp(m_WaterPlane.transform.position, m_WaterPosition, ref m_Velocity, m_SmoothTime);
        //
        Vector3 pos = new Vector3(m_RainEffectPosition.x, m_WaterPlane.transform.position.y, m_RainEffectPosition.z);
        m_RainEffect.transform.position = pos;
    }

    void CameraRotate()
    {
        Vector2 delta = UnityEngine.InputSystem.Mouse.current.delta.ReadValue();
        //Debug.Log("delta= " + delta);
        Quaternion qt = Quaternion.Euler(0, delta.x * 0.2f, 0);
        m_QtH = qt * m_QtH;

        qt = Quaternion.Euler(delta.y * -0.2f, 0, 0);
        m_QtV = qt * m_QtV;
        m_OVRCameraRig.transform.rotation = m_QtH * m_QtV;
    }

    void GetKeyProc()
    {
        string s = "";
        if (UnityEngine.InputSystem.Keyboard.current.digit1Key.wasPressedThisFrame) s = "ButtonWaterLevel1";
        if (UnityEngine.InputSystem.Keyboard.current.digit2Key.wasPressedThisFrame) s = "ButtonWaterLevel2";
        if (UnityEngine.InputSystem.Keyboard.current.digit3Key.wasPressedThisFrame) s = "ButtonWaterLevel3";
        if (UnityEngine.InputSystem.Keyboard.current.digit4Key.wasPressedThisFrame) s = "ButtonWaterLevel4";

        if (UnityEngine.InputSystem.Keyboard.current.digit5Key.wasPressedThisFrame) s = "ButtonCarPark";
        if (UnityEngine.InputSystem.Keyboard.current.digit6Key.wasPressedThisFrame) s = "ButtonJang";

        if (UnityEngine.InputSystem.Keyboard.current.digit7Key.wasPressedThisFrame) s = "ButtonShowInfo";
        if (UnityEngine.InputSystem.Keyboard.current.digit8Key.wasPressedThisFrame) s = "ButtonCloseInfo";

        //
        if (string.IsNullOrEmpty(s) == false)
        {
            ClickProc(s);
        }
    }

    // Update is called once per frame
    void Update()
    {
        WaterPositionProc();
#if UNITY_EDITOR
        CameraRotate();
        GetKeyProc();
#endif
    }
}
