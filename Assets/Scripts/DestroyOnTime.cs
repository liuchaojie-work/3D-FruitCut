using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 按照时间销毁
/// </summary>
public class DestroyOnTime : MonoBehaviour
{
    public float desTime = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Dead", desTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Dead()
    {
        Destroy(gameObject);
    }
    
}
