using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class Launcher : MonoBehaviourPunCallbacks
{
    public GameObject waitingUI;
    public GameObject loginUI;
    public InputField userName;
    public InputField roomNumber;
    
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings(); // 连接到Photon服务器
    }

    public override void OnConnectedToMaster()
    {
        waitingUI.SetActive(false);
        loginUI.SetActive(true);
    }

    public void loginBtn()
    {
        if (userName.text.Length <2 && roomNumber.text.Length < 2)
            return;
        
        PhotonNetwork.NickName = userName.text; //用户名传输到网络

        RoomOptions options = new RoomOptions { MaxPlayers = 4 };
        PhotonNetwork.JoinOrCreateRoom(roomNumber.text, options, default);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(1);
    }
}
