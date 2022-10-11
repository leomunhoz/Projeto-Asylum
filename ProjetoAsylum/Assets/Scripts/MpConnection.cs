using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Photon.Pun;
using Photon.Realtime;

public class MpConnection : MonoBehaviourPunCallbacks
{
    public Text connectionLog;
    public Player mySelf;
    


    //--------------------------------------------------------
    void Start()
    {
        PhotonNetwork.LocalPlayer.NickName = System.Environment.UserName;
        connectionLog.text = "Conectando... como: " + PhotonNetwork.LocalPlayer.NickName + "\n";
        PhotonNetwork.ConnectUsingSettings();
    }

    //--------------------------------------------------------
    public override void OnConnectedToMaster()
    {
        connectionLog.text += "Conectado ao servidor!\n";
        connectionLog.text += "Entrando no lobby...\n";
        PhotonNetwork.JoinLobby();
    }

    //--------------------------------------------------------
    public override void OnJoinedLobby()
    {
        connectionLog.text += "Entrou no lobby!\n";

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 5;

        connectionLog.text += "Entrando na SALA: PUCC\n";
        PhotonNetwork.JoinOrCreateRoom("PUCC", roomOptions, null);
    }

    //--------------------------------------------------------
    public override void OnJoinedRoom()
    {
        connectionLog.text += "Entrei na SALA: PUCC!\n";

        Vector3 pos = Random.insideUnitSphere;
        pos.y = 1;

        GameObject player = PhotonNetwork.Instantiate("Player", pos, Quaternion.identity);
       
        mySelf = player.GetComponent<Player>();
       
    }

    //--------------------------------------------------------
  
    

    //--------------------------------------------------------
    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        connectionLog.text += "Player: " + newPlayer.NickName + " entrou na SALA: PUCC!\n";
       
    }

    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        connectionLog.text += "Player: " + otherPlayer.NickName + " saiu da SALA: PUCC!\n";
    }
}
