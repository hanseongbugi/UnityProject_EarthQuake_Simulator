using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class cshJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler{
    private Image imgBG;
    private Image imgJoystick;
    private Vector3 vInputVector;

    // Start is called before the first frame update
    void Start()
    {
        imgBG = GetComponent<Image>();
        imgJoystick = transform.GetChild(0).GetComponent<Image>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;

        //배경 영역에 터치가 발생할 때
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(imgBG.rectTransform, eventData.position, eventData.pressEventCamera, out pos))
        {
            //Debug.Log(imgBG.rectTransform.sizeDelta);
            //터치된 로컬 좌표값을 pos에 저장
            //배경 이미지의 size로 나누어 pos.x: -1~1, pos.y: -1~1 으로 변환
            pos.x = (pos.x / imgBG.rectTransform.sizeDelta.x);
            pos.y = (pos.y / imgBG.rectTransform.sizeDelta.y);

            vInputVector = new Vector3(pos.x, pos.y, 0);
            vInputVector = (vInputVector.magnitude > 1.0f) ? vInputVector.normalized : vInputVector;

            //Joystick Image 움직임
            imgJoystick.rectTransform.anchoredPosition = new Vector3(vInputVector.x * (imgBG.rectTransform.sizeDelta.x / 2),
                                                                    vInputVector.y * (imgBG.rectTransform.sizeDelta.y / 2));
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        vInputVector = Vector3.zero;
        imgJoystick.rectTransform.anchoredPosition = Vector3.zero;
    }
    //PlayerController 에서 입력 값을 넘겨주기 위한 함수
    public float GetHorizontalValue()
    {
        return vInputVector.x;
    }
    public float GetVerticalValue()
    {
        return vInputVector.y;
    }

    // Update is called once per frame
    void Update()
    {

    }

}
