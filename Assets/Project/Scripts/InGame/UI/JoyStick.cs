using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoyStick : MonoBehaviour ,IDragHandler,IPointerUpHandler,IPointerDownHandler{

    public Image m_JoystickBG;
    public Image m_Stick;

    private Vector3 inputVector;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        }

    // 터치가 드래그(Drag) 했을때 호출 되는 함수
    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 Pos;

        // 터치된 로컬 좌표값을 Pos에 할당하고 Joystick_Pad 직사각형의 sizedelta 값으로 나누어
        // Pos.X는 0~1, Pos.Y는 0~1 사이의 값으로 만듭니다.
        // Joystick_Stick을 기준으로 좌우로 움직였을때 Pos.X는 -1~1 사이, 상하라면 Pos.Y를 -1~1의 값으로 변환하기 위해
        // Pos.x * 2 + 1, Pos.y * 2 - 1 처리를 합니다.
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(m_JoystickBG.rectTransform, ped.position, ped.pressEventCamera, out Pos))
        {
            Pos.x = (Pos.x / m_JoystickBG.rectTransform.sizeDelta.x);
            Pos.y = (Pos.y / m_JoystickBG.rectTransform.sizeDelta.y);

            inputVector = new Vector3(Pos.x * 2 + 1, Pos.y * 2 - 1, 0);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

            // 조이스틱이 움직인다면..
            // joystick_Stick의 이미지를 터치한 좌표값으로 움직여준다.
            m_Stick.rectTransform.anchoredPosition = new Vector3(inputVector.x * (m_Stick.rectTransform.sizeDelta.x / 2),
                 inputVector.y * (m_Stick.rectTransform.sizeDelta.y / 2));
        }
    }

    // 터치를 하고 있을 대 발생하는 함수
    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }

    // 터치에서 손을 땠을때 발생하는 함수
    public virtual void OnPointerUp(PointerEventData ped)
    {
        inputVector = Vector3.zero;
        m_Stick.rectTransform.anchoredPosition = Vector3.zero;
    }

    // Player 스크립트에서 inputVector.x 값을 받기 위해 사용될 함수
    public float GetHorizontalValue()
    {
        return inputVector.x;
    }

    // Player 스크립트에서 inputVector.y 값을 받기 위해 사용될 함수
    public float GetVerticalValue()
    {
        return inputVector.y;
    }

    public void InitInputVector()
    {
        inputVector = Vector3.zero;
        m_Stick.rectTransform.anchoredPosition = Vector2.zero;
    }



}
