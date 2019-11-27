using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 产生 水果 炸弹
/// </summary>
public class Spawner : MonoBehaviour
{
    [Header("水果的预设")]
    public GameObject[] fruits;

    [Header("炸弹的预设")]
    public GameObject bomb;

    public AudioSource audioSource;

    /// <summary>
    /// 产生时间
    /// </summary>
    float spawnerTimer = 1.0f;

    bool isPlaying = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isPlaying)
        {
            return;
        }
        
            spawnerTimer -= Time.deltaTime;
            if(0 >= spawnerTimer)
            {
                //到时间就开始产生水果,产生多个水果
                int fruitCount = Random.Range(1, 5);
                for(int i = 0; i < fruitCount; i++)
                    OnSpwaner(true);
                spawnerTimer = 1.0f;

                //随机产生炸弹
                int bombNum = Random.Range(0, 100);
                if(bombNum > 70)
                {
                    OnSpwaner(false);
                }
            }
        
    }
    /// <summary>
    /// 临时存储当前水果的z坐标
    /// </summary>
    private int tempZ = 0;

    /// <summary>
    /// 产生水果 炸弹 ,也能控制销毁
    /// </summary>
    private void OnSpwaner(bool isFruit)
    {
        //播放音乐
        audioSource.Play();
        // x范围： -8.4 - 8.4
        // y范围： transform.position.y

        //坐标范围
        float x = Random.Range(-8.4f, 8.4f);
        float y = transform.position.y;
        float z = tempZ;
        
        //使水果不再一个平面上
        tempZ -= 2;
        if(tempZ <= -10)
        {
            tempZ = 0;
        }
        //实例化水果
        int fruitIndex = Random.Range(0, fruits.Length);
        GameObject go;
        if(isFruit)
        {
            go = Instantiate<GameObject>(fruits[fruitIndex], new Vector3(x, y, z), Random.rotation);
        }
        else
        {
            go = Instantiate<GameObject>(bomb, new Vector3(x, y, z), Random.rotation);
        }
            

        //水果速度
        Vector3 velocity = new Vector3(-x * Random.Range(0.2f, 0.8f), - Physics.gravity.y * Random.Range(0.8f, 1.5f), 0);
        Rigidbody rigidbody = go.transform.GetComponent<Rigidbody>();
        rigidbody.velocity = velocity;
    }

    /// <summary>
    /// 有物体碰撞时调用
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }
}
