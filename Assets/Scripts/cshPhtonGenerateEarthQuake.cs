using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;


public class cshPhtonGenerateEarthQuake : MonoBehaviourPun
{
    public float movementRange = 0.3f; // 이동 가능한 범위
    public Slider speedSlider; // Slider UI 요소를 가리키는 변수
    public float minSpeed = 1f; // 최소 속도
    public float maxSpeed = 10f; // 최대 속도
    private float currentSpeed; // 현재 속도
    private Vector3 targetPosition; // 목표 위치
    public GameObject destroyEffectPrefab;
    public Text program;
    private bool initSlider = false;
    private void Start()
    {
        currentSpeed = 0;
        SetRandomTargetPosition();
        UpdateProgramText(currentSpeed);
    }

    private void Update()
    {
		if (!initSlider&&speedSlider)
		{
            // Slider 값 변경 시 호출될 콜백 함수 설정
            speedSlider.onValueChanged.AddListener(OnSpeedChanged);
            initSlider = true;
        }
        Debug.Log(currentSpeed);
        if (photonView.IsMine)
        {
            PhotonView pv = GetComponent<PhotonView>();
            pv.RPC("SyncSliderValue", RpcTarget.All, currentSpeed);
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, currentSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            SetRandomTargetPosition();
        }
    }
    public void OnSpeedChanged(float value)
    {
        Debug.Log("speed Changed");
        currentSpeed = value;
            
        
        // 프로그램 텍스트 업데이트
        //UpdateProgramText(value);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Instantiate(destroyEffectPrefab, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
    }

    private void SetRandomTargetPosition()
    {
        float randomX = Random.Range(-movementRange, movementRange);
        float randomY = Random.Range(-movementRange, movementRange);
        float randomZ = Random.Range(-movementRange, movementRange);

        targetPosition = new Vector3(randomX, randomY, randomZ);
    }

    [PunRPC]
    private void SyncSliderValue(float value)
    {

          speedSlider.value = value;
        // 프로그램 텍스트 업데이트
        UpdateProgramText(value);
    }

    private void UpdateProgramText(float value)
    {
        if (value >= 11)
        {
            program.text = "Magnitude 11 : Everything was destroyed.";
        }
        else if (value >= 10)
        {
            program.text = "Magnitude 10 : Everything was destroyed.";
        }
        else if (value >= 9)
        {
            program.text = "Magnitude 9 : Everything was destroyed.";
        }
        else if (value >= 8)
        {
            program.text = "Magnitude 8 : Most buildings can be destroyed.";
        }
        else if (value >= 7)
        {
            program.text = "Magnitude 7 : You can go into a panic. Stay calm and go where you can avoid your head.";
        }
        else if (value >= 6)
        {
            program.text = "Magnitude 6 : It's hard to stand and it can damage strong buildings. Go where you can avoid your head while shaking.";
        }
        else if (value >= 5)
        {
            program.text = "Magnitude 5 : Buildings can also be cracked. Go where you can avoid your head while shaking.";
        }
        else if (value >= 4)
        {
            program.text = "Magnitude 4 : Doors, long doors, and things can shake. Go where you can avoid your head while shaking.";
        }
        else if (value >= 3)
        {
            program.text = "Magnitude 3 : It's the scale that sensitive people can feel. There is little damage, so please wait inside.";
        }
        else if (value >= 2)
        {
            program.text = "Magnitude 2 : There was a slight earthquake. It's safe, so please wait inside.";
        }
        else if (value >= 1)
        {
            program.text = "Magnitude 1 : It's safe, so please wait inside.";
        }
        else
        {
            program.text = "Magnitude 0 : It's a normal situation.";
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // 데이터를 전송
            stream.SendNext(speedSlider.value);
        }
        else
        {
            // 데이터를 받음
            float receivedValue = (float)stream.ReceiveNext();

            // 로컬 플레이어가 아닌 경우에만 값을 동기화
            if (!photonView.IsMine)
            {
                currentSpeed = receivedValue;
                speedSlider.value = receivedValue;

                // 프로그램 텍스트 업데이트
                UpdateProgramText(receivedValue);
            }
        }
    }
}
