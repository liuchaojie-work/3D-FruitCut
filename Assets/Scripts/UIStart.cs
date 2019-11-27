using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIStart : MonoBehaviour
{
    /// <summary>
    /// 开始游戏按钮
    /// </summary>
    private Button btnPlay;

    /// <summary>
    /// 声音按钮
    /// </summary>
    private Button btnSound;

    /// <summary>
    /// 播放声音组件
    /// </summary>
    private AudioSource audioSourceBgm;

    private Image imgSound;
    /// <summary>
    /// 声音图片数组
    /// </summary>
    public Sprite[] soundSprites;

    // Start is called before the first frame update
    void Start()
    {
        GetComponents();
        //注册监听
        btnPlay.onClick.AddListener(OnPlayClick);
        btnSound.onClick.AddListener(OnSoundClick);
    }

    private void OnDestroy()
    {
        //移除监听
        btnPlay.onClick.RemoveListener(OnPlayClick);
        btnSound.onClick.RemoveListener(OnSoundClick);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 寻找组件 
    /// </summary>
    private void GetComponents()
    {
        btnPlay = transform.Find("BtnPlay").GetComponent<Button>();
        btnSound = transform.Find("BtnSound").GetComponent<Button>();
        audioSourceBgm = transform.Find("BtnSound").GetComponent<AudioSource>();
        imgSound = transform.Find("BtnSound").GetComponent<Image>();
    }

    /// <summary>
    /// 开始按钮按下的点击事件
    /// </summary>
    void OnPlayClick()
    {
        SceneManager.LoadScene("Play", LoadSceneMode.Single);
    }

    /// <summary>
    /// 当声音按钮点击时调用
    /// </summary>
    void OnSoundClick()
    {
        if(audioSourceBgm.isPlaying)
        {
            //若正在播放，则暂停
            audioSourceBgm.Pause();
            imgSound.sprite = soundSprites[1];
        }
        else
        {
            //若未播放，则播放
            audioSourceBgm.Play();
            imgSound.sprite = soundSprites[0];
        }
    }
}
