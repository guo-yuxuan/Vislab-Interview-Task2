using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Unity.Mathematics;
using Photon.Realtime;
using UnityEngine.UI;


public class UserManager : MonoBehaviourPunCallbacks
{
    public Transform content;
    public GameObject readyBtn;
    public GameObject recordBtn;
    public Text roomNumber;

    
    private void Awake()
    {
        roomNumber.text = PhotonNetwork.CurrentRoom.Name;
    }
    
    //实例化用户
    public void UserActive()
    {
        GameObject newUser = PhotonNetwork.Instantiate("userAvatar", content.position, quaternion.identity);
        photonView.RPC("SetParentForUser", RpcTarget.AllBuffered, newUser.GetComponent<PhotonView>().ViewID);
        readyBtn.SetActive(false);
        recordBtn.SetActive(true);
        
    }

    public void LeaveMeeting()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LoadLevel(0);
    }
    
    [PunRPC]
    void SetParentForUser(int viewId)
    {
        PhotonView photonView = PhotonView.Find(viewId);
        if (photonView != null)
        {
            photonView.transform.SetParent(content, false);
        }
    }
    
    
    
}