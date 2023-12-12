using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Voice.Unity;
using UnityEngine.UI;

public class VoiceManager : MonoBehaviour
{
    public Recorder recorder; // 引用Photon Voice的Recorder组件
    public Button micToggleButton; // 引用控制麦克风的按钮
    public GameObject micOnTip;//麦克风打开文字
    public GameObject micOffTip;//麦克风关闭文字

    private void Start()
    {
        // 确保Recorder组件已经链接
        if (recorder == null)
        {
            Debug.LogError("Recorder component is not assigned!");
            return;
        }

        // 添加按钮的点击事件监听
        micToggleButton.onClick.AddListener(ToggleMicrophone);
    }
    
    //控制用户麦克风
    private void ToggleMicrophone()
    {
        if (recorder.TransmitEnabled)
        {
            recorder.TransmitEnabled = false;
            micOnTip.SetActive(false);
            micOffTip.SetActive(true);
        }
        else
        {
            recorder.TransmitEnabled = true;
            micOffTip.SetActive(false);
            micOnTip.SetActive(true);
        }
    }
}
