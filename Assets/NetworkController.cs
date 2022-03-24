using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkController : MonoBehaviourPunCallbacks
{
    public GameObject player;
    // Start is called before the first frame update
    void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // connect to the photon server
    public override void OnConnectedToMaster()
    {
        Debug.Log("We are now connected to the " + PhotonNetwork.CloudRegion + " server!");
        OnClickConnectToRoom();
    }


    // happens when we disconnect
    public override void OnDisconnected(DisconnectCause cause)
    {
        base.OnDisconnected(cause);
        Debug.Log(cause);
    }

    // Joins a random room and makes host
    public void OnClickConnectToRoom()
    {
        PhotonNetwork.JoinRandomRoom();

    }

    // if cant join a random room then run this
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        base.OnJoinRandomFailed(returnCode, message);
        // create a new room to join
        PhotonNetwork.CreateRoom("test room1", new RoomOptions { MaxPlayers = 20 });
    }

    // run if we cant create the room
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
        Debug.Log(message);
    }

    // run when we join the room and create the player instance.
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("Master: " + PhotonNetwork.IsMasterClient + " Room Name:" + PhotonNetwork.CurrentRoom.Name);
        Debug.Log("player should be instantiated 1");
       PhotonNetwork.Instantiate(player.gameObject.name, player.transform.position, player.transform.rotation);


    }

    // when the player enters the room run this.
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        

    }

}
