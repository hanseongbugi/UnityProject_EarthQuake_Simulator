using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;       // Photon �� ���� ����� ���� ���̺귯���� Unity���� ������Ʈ�� ��� ����
using Photon.Realtime;  // Realtime Network ���� ���� c# ���̺귯��
using UnityEngine.UI;

public class cshLobbyManager : MonoBehaviourPunCallbacks // PUN �����Ҷ� override ����� �ڵ� �ۼ��ؾߵ�
{
    private string gameVersion = "1"; // ���� �������� ��Ī�ϱ� ���� string ��� ���ڻӸ� �ƴ� �ٸ� �͵� ��� ����

    public Text connectionInfoText;
    public Button joinButton;

    private void Start()
    {
        // ���ӿ� �ʿ��� ����(���� ����) ����
        PhotonNetwork.GameVersion = gameVersion;
        // ������ ������ ������ ���� ���� �õ�
        PhotonNetwork.ConnectUsingSettings();

        // Room ���� ��ư ��� ��Ȱ��ȭ
        joinButton.interactable = false;
        // ���� �õ� ������ �ؽ�Ʈ�� ǥ��
        connectionInfoText.text = "Master ������ ���� ��...";
    }

    public override void OnConnectedToMaster()
    {
        joinButton.interactable = true;
        connectionInfoText.text = "�¶���: Master ������ �����";
        //base.OnConnectedToMaster();
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        joinButton.interactable = false;
        connectionInfoText.text = "��������: Master ������ ������� ����\n���� ��õ� ��...";

        PhotonNetwork.ConnectUsingSettings();
        //base.OnDisconnected(cause);
    }

    public void Connect()
    {
        // �ߺ� ���� �õ��� ���� ���� ���� ��ư ��� ��Ȱ��ȭ
        joinButton.interactable = false;

        // Master ������ ���� ���̶��
        if (PhotonNetwork.IsConnected)
        {
            connectionInfoText.text = "Room�� ����...";
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            connectionInfoText.text = "��������: Master ������ ������� ����\n���� ��õ� ��...";
            PhotonNetwork.ConnectUsingSettings();
        }

    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        connectionInfoText.text = "�� ���� ����, ���ο� �� ����...";

        // ���ο� ���� ����� (���� Name, ���� �ɼ� ����)
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 4 });

        //base.OnJoinRandomFailed(returnCode, message);
    }

    public override void OnJoinedRoom()
    {
        connectionInfoText.text = "�� ���� ����";
        // ��� �� �����ڰ� Main ���� �ε��ϰ� ��
        // Unity ���� �����ϴ� SceneMangaer.LoadScene() �� ���� ���� ��� ���� ������Ʈ�� ���� �� ��Ʈ��ũ ���� ������ ���� ����
        PhotonNetwork.LoadLevel("ChoiceScene");

        //base.OnJoinedRoom();
    }

}