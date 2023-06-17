using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class cshGameManager : MonoBehaviourPun // ������ ���� ���� ���� �� ���� UI�� �����ϴ� ���� �Ŵ��� ��ũ��Ʈ
{
    public static cshGameManager instance // �ܺο��� �̱��� ������Ʈ�� �����ö� ����� ������Ƽ
    {
        get
        {
            // ���� �̱��� ������ ���� ������Ʈ�� �Ҵ���� �ʾҴٸ�
            if (m_instance == null)
            {
                // ������ GameManager ������Ʈ�� ã�� �Ҵ�
                m_instance = FindObjectOfType<cshGameManager>();
            }

            // �̱��� ������Ʈ�� ��ȯ
            return m_instance;
        }
    }

    private static cshGameManager m_instance; // �̱����� �Ҵ�� static ����

    public GameObject PlayerPrefab; // ������ VR �÷��̾� ĳ����
    public GameObject SpawnPosPrefab; // ������ VR �÷��̾� ĳ������ ��ġ
    public cshPhtonGenerateEarthQuake generateEarthQuake;
    private void Awake()
    {
        // ���� �̱��� ������Ʈ�� �� �ٸ� GameManager ������Ʈ�� �ִٸ�
        if (instance != this)
        {
            // �ڽ��� �ı�
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // ������ ���� ��ġ ����
        Vector3 randomSpawnPos = SpawnPosPrefab.transform.position;//Random.insideUnitSphere * 5f;
        // ��Ʈ��ũ���� ��� Ŭ���̾�Ʈ���� ���� ����  
        // �ش� ���� ������Ʈ�� �ֵ����� ���� �޼��带 ���� ������ Ŭ���̾�Ʈ�� ����
        GameObject player = PhotonNetwork.Instantiate(PlayerPrefab.name, randomSpawnPos, Quaternion.identity);
        generateEarthQuake.speedSlider = player.GetComponentInChildren<Slider>();
        generateEarthQuake.program = player.GetComponentInChildren<Text>();
    }

}
