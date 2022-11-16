using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class MpConnection : MonoBehaviourPunCallbacks
{
    public Text connectionLog;
    public Player mySelf;
    public static string  nickName;
    public TMP_InputField PlayerNick;
    public TMP_InputField Room;

    public static string room;
    public int lockTyping;
    public Transform[] Spawn;



    //--------------------------------------------------------
    void Start()
    {
        
       
       
    }

    //--------------------------------------------------------
    public override void OnConnectedToMaster()
    {
        connectionLog.text += "Conectado ao servidor!\n";
        connectionLog.text += "Entrando no lobby...\n";


        PhotonNetwork.JoinLobby();
        StartCoroutine(Play());
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
        //connectionLog.text += "Entrei na SALA: PUCC!\n";
        //Debug.Log(PhotonNetwork.CurrentRoom.PlayerCount);
        Vector3 pos = Spawn[PhotonNetwork.CurrentRoom.PlayerCount - 1].position;
       
        string prefabNane = "Player";
       
       if( PhotonNetwork.CurrentRoom.PlayerCount > 1)
        {
            
            prefabNane = "Player";

        }
        GameObject player = PhotonNetwork.Instantiate(prefabNane, pos, Quaternion.identity);

        mySelf = player.GetComponent<Player>();

    }

    //--------------------------------------------------------



    //--------------------------------------------------------
    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        connectionLog.text += "Player: " + newPlayer.NickName + " entrou na SALA\n";

    }

    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        connectionLog.text += "Player: " + otherPlayer.NickName + " saiu da SALA\n";
    }

    public void enterValues()
    {
        if (lockTyping == 0)
        {
            lockTyping = 1;
            nickName = PlayerNick.text;
            room = Room.text;
            PlayerNick.interactable = false;
            Room.interactable = false;
            PhotonNetwork.LocalPlayer.NickName = nickName;
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public IEnumerator Play() 
    {
       // PhotonNetwork.JoinLobby();
        SceneManager.LoadScene(1);
        yield return new WaitForSeconds(1);

    }
}
