using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIOver : MonoBehaviour
{
    /// <summary>
    /// 返回菜单按钮
    /// </summary>
    private Button btnReturnMenu;

    // Start is called before the first frame update
    void Start()
    {
        GetComponents();
        btnReturnMenu.onClick.AddListener(OnReturnMenuClick);
    }

    private void OnDestroy()
    {
        btnReturnMenu.onClick.RemoveListener(OnReturnMenuClick);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void GetComponents()
    {
        btnReturnMenu = transform.Find("BtnReturnMenu").GetComponent<Button>();
    }

    void OnReturnMenuClick()
    {
        SceneManager.LoadScene("Start");
    }
}
