using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Launcher_ : MonoBehaviourPunCallbacks
{
    [SerializeField] private PhotonView playerPrefab;
    [SerializeField] private PhotonView cameraPrefab;

    private void Awake()
    {
    }

    void Start()
    {
        if (SceneController.Instance)
            SceneController.Instance.isForcedToLoad = true;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Conectado con exito al servidor");
        PhotonNetwork.JoinRandomOrCreateRoom();
    }

    public override void OnJoinedRoom()
    {
        if (SceneController.Instance)
            SceneController.Instance.isForcedToLoad = false;
        Debug.Log("Ingreso exitoso a sala");
        var player = PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(0, .5f, 0), Quaternion.identity);
        if (!cameraPrefab)
            return;
        var camera = PhotonNetwork.Instantiate(cameraPrefab.name, new Vector3(0, 0, 0), Quaternion.identity);
        camera.GetComponent<MenteBacata.ScivoloCharacterControllerDemo.OrbitingCamera>().target = player.transform;
    }
}
