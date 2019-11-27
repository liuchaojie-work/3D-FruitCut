using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIScore : MonoBehaviour
{
    /// <summary>
    /// 单例对象
    /// </summary>
    public static UIScore Instance = null;
    private void Awake()
    {
        Instance = this;
    }
    [SerializeField]
    private Text txt_score;

    /// <summary>
    /// 当前分数
    /// </summary>
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// 改变分数
    /// </summary>
    /// <param name="score"></param>
    public void ChangeScore(int score)
    {
        //若分数小于0，游戏结束
        this.score += score;
        if (this.score <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Over");
            return; 
        }
        txt_score.text = this.score.ToString();
 
    }
}
