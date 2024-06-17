using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour
{
    public Image m_PanelDetails = null;
    public Image[] m_DetailImages;
    bool m_bDetailExpanded = false;

    public Button[] m_DetailExpandButtons = null;

    public Button[] m_LevelButtons = null;

    int m_SelectedWaterLevel = 0;

    public static GamePlay m_Instance = null;

    void Awake()
    {
        m_Instance = this;    
    }

    // Start is called before the first frame update
    void Start()
    {
        SetSelectedWaterLevel(0);
        //
        for (int c = 0; c < m_DetailImages.Length; c++)
        {
            //OnDetailExpand(c);
        }
    }

    public void SetSelectedWaterLevel(int level)
    {
        m_SelectedWaterLevel = level;
        //
        Color selectColor = Color.white;
        selectColor.a = 0.2f;

        for (int c = 0; c < m_LevelButtons.Length; c++)
        {
            Image image = m_LevelButtons[c].GetComponent<Image>();
            if (c == level)
            {
                image.color = Color.white;
            }
            else
            {
                image.color = selectColor;
            }
        }
        //
        for (int c = 0; c < m_DetailExpandButtons.Length; c++)
        {
            if (c == level)
            {
                m_DetailExpandButtons[c].gameObject.SetActive(true);
            }
            else
            {
                m_DetailExpandButtons[c].gameObject.SetActive(false);
            }
        }
        //
        for (int c = 0; c < m_DetailImages.Length; c++)
        {
            if (c == level)
            {
                m_DetailImages[c].gameObject.SetActive(true);
            }
            else
            {
                m_DetailImages[c].gameObject.SetActive(false);
            }
        }
    }

    public void OnButtonWaterLevel(int n)
    {
        SetSelectedWaterLevel(n);
    }

    public void OnButtonDetailExpand()
    {
        m_bDetailExpanded = !m_bDetailExpanded;
        //
        if (m_bDetailExpanded)
        {

        }
    }

    void OnDetailExpand(int n)
    {
        for (int c = 0; c < m_DetailImages.Length; c++)
        {
            if (c == n)
            {
                m_DetailImages[c].gameObject.SetActive(true);
            }
            else
            {
                m_DetailImages[c].gameObject.SetActive(false);
            }
        }
    }

    void OnDetailContract(int n)
    {
        foreach (Image image in m_DetailImages)
        {
            image.gameObject.SetActive(false);
        }
    }

    public void OnButtonDetail(int n)
    {

    }

    public void ShowPanelDetails()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
