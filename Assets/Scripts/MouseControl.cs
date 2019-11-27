using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 实现切水果功能
/// </summary>
public class MouseControl : MonoBehaviour
{
    /// <summary>
    /// 直线渲染器
    /// </summary>
    [SerializeField]
    private LineRenderer lineRenderer;

    /// <summary>
    /// 挥刀音效
    /// </summary>
    [SerializeField]
    private AudioSource audioSource;

    /// <summary>
    /// 是否是第一次鼠标按下
    /// </summary>
    private bool isFirMouseDown = false;

    /// <summary>
    /// 是否鼠标一直按下
    /// </summary>
    private bool isKeepMouseDwon = false;


    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            isFirMouseDown = true;
            isKeepMouseDwon = true;

            audioSource.Play();
        }

        if(Input.GetMouseButtonUp(0))
        {
            isKeepMouseDwon = false;
        }

        OnDrawLine();
        isFirMouseDown = false;
    }

    /// <summary>
    /// 保存的所有坐标
    /// </summary>
    private Vector3[] positions = new Vector3[10];

    /// <summary>
    /// 当前保存坐标的数量
    /// </summary>
    private int posCount = 0;

    /// <summary>
    /// 代表这一帧鼠标的位置
    /// </summary>
    private Vector3 head;

    /// <summary>
    /// 代表上一帧数鼠标的位置
    /// </summary>
    private Vector3 last;

    /// <summary>
    /// 控制画线
    /// </summary>
    private void OnDrawLine()
    {
        if(isFirMouseDown)
        {
            
            posCount = 0;
            head = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            last = head;
        }

        if(isKeepMouseDwon)
        {
            head = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if(Vector3.Distance(head, last) > 0.01f)
            {
                //若距离较远，则保存到数组内
                SavePosition(head);
                posCount++;
                //发射一条射线
                OnRayCast(head);
            }
            last = head;
        }
        else
        {
            positions = new Vector3[10];
        }
        ChangePositions(positions);
    }

    /// <summary>
    /// 发射射线
    /// </summary>
    /// <param name="worldPos"></param>
    private void OnRayCast(Vector3 worldPos)
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);

        Ray ray = Camera.main.ScreenPointToRay(screenPos);
        RaycastHit[] hits = Physics.RaycastAll(ray);
        
        for(int i = 0; i < hits.Length; i++)
        {
            //Debug.Log(hits[i].collider.name);
            //Destroy(hits[i].collider.gameObject);
            hits[i].collider.gameObject.SendMessage("OnCut", SendMessageOptions.DontRequireReceiver);
        }
    }
    /// <summary>
    /// 保存坐标点
    /// </summary>
    /// <param name="pos"></param>
    private void SavePosition(Vector3 pos)
    {
        pos.z = 1;
        if(posCount <= 9)
        {
            for(int i = posCount; i < 10; i++)
            {
                positions[i] = pos;
            }
        }
        else
        {
            for(int i = 0; i < 9; i++)
            {
                positions[i] = positions[i + 1]; 
            }
            positions[9] = pos;
        }
    }
    /// <summary>
    /// 修改直线渲染器的坐标
    /// </summary>
    /// <param name="positions"></param>
    private void ChangePositions(Vector3[] positions)
    {
        lineRenderer.SetPositions(positions);
    }
}
