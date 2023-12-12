using Photon.Pun;
using Photon.Voice.Unity;
using UnityEngine;
using UnityEngine.UI;

public class User : MonoBehaviourPun
{
    public Text name;
    public Speaker speaker; // 引用Speaker组件
    public Slider volumeSlider; // 引用UI中的滑块
    public GameObject slider;
    private AudioSource audioSource;
    
    
    private void Awake()
    {
        if (photonView.IsMine)
        {
            //显示用户名
            name.text = PhotonNetwork.NickName;
            slider.SetActive(false);
        }
            
        else
            name.text = photonView.Owner.NickName;
    }
    
    private void Start()
    {
        if (speaker == null || volumeSlider == null)
            return;
        
        // 获取与Speaker关联的AudioSource组件
        audioSource = speaker.GetComponent<AudioSource>();
        
   
        if (audioSource == null)
            return;
        
        // 设置滑块的初始值为AudioSource的当前音量
        volumeSlider.value = audioSource.volume;

        volumeSlider.onValueChanged.AddListener(HandleVolumeChange);
    }
    
    private void HandleVolumeChange(float volume)
    {
        // 调整音量
        if (audioSource != null)
        {
            audioSource.volume = volume;
        }
    }
    
}
