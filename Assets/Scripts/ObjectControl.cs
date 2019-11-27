using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 物体控制脚本
/// </summary>
public class ObjectControl : MonoBehaviour
{
    /// <summary>
    /// 一半水果
    /// </summary>
    public GameObject aHalfFruit;
    /// <summary>
    /// 特效
    /// </summary>
    public GameObject splash;

    public GameObject splashFlat;

    private bool isDead = false;

    public AudioClip audioClip;
    /// <summary>
    /// 被切割时调用
    /// </summary>
    public void OnCut()
    {
        //防止重复调用
        if(isDead)
        {
            return;
        }

        if(gameObject.name.Contains("Bomb"))
        {
            Instantiate(splash, transform.position, Quaternion.identity);
            //若是炸弹，扣分
            UIScore.Instance.ChangeScore(-20);
        }
        else
        {
            //生成被切割的水果
            for (int i = 0; i < 2; i++)
            {
                GameObject go = Instantiate<GameObject>(aHalfFruit, transform.position, Random.rotation);
                go.GetComponent<Rigidbody>().AddForce(Random.onUnitSphere * 5.0f, ForceMode.Impulse);
            }

            //生成特效
            Instantiate(splash, transform.position, Quaternion.identity);
            Instantiate(splashFlat, transform.position, Quaternion.identity);

            //若水果，加分
            UIScore.Instance.ChangeScore(10);
        }

        AudioSource.PlayClipAtPoint(audioClip, transform.position);
        //销毁自身
        Destroy(gameObject);

        isDead = true;
    }
}
