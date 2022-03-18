using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Management : MonoBehaviourPunCallbacks
{
   
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();//Server'a ba�lan�yor
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Server'a ba�land�");
        PhotonNetwork.JoinLobby();//lobiye giri� yapmam�z� sa�l�yor

        base.OnConnectedToMaster();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Lobiye girildi");

        PhotonNetwork.JoinOrCreateRoom("oda", new RoomOptions { MaxPlayers = 2, IsOpen = true, IsVisible = true }, TypedLobby.Default); //Odaya kat�lmam�z� sa�l�yor e�er kat�lmak istedi�imiz oda yoksa olu�turuyor

        //PhotonNetwork.JoinRandomRoom(); //bu fonksiyon da rastgele bir odaya girmeye �al���yor

        base.OnJoinedLobby();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Odaya girildi");

        GameObject nesne = PhotonNetwork.Instantiate("Square", Vector3.zero, Quaternion.identity, 0, null);
        nesne.GetComponent<PhotonView>().Owner.NickName = "Selehattin"; //owner deki nickname i
        base.OnJoinedRoom();
    }

    public override void OnLeftLobby()
    {
        Debug.Log("Lobiden ��k�ld�");
        base.OnLeftLobby();
    }

    public override void OnLeftRoom()
    {
        Debug.Log("Odadan ��k�ld�");
        base.OnLeftLobby();
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.LogError("Odaya girilemedi");
        base.OnJoinRoomFailed(returnCode, message);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.LogError("Herhangi bir odaya girilemedi");
        base.OnJoinRoomFailed(returnCode, message);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.LogError("Oda Kurulamad�");
        base.OnJoinRoomFailed(returnCode, message);
    }


    void Update()
    {
        
    }
}
