using UnityEngine;
using System.Collections;
using System.Text;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Tutorial : MonoBehaviour , IPointerClickHandler {

    [SerializeField]
    public Text m_Talk;
    private int _talkNum = 0;

    

    StringBuilder _Builder;
    private int m_EndIndex;

    [SerializeField]
    GameObject m_TouchDown;
    
    private bool _TalkEnd = false;
    private string[] _talk =
    {
        "으윽, 허리가. 미안하지만 자네가 좀 처리해주겠나? 내가 어떻게 해야 할지 알려주겠네.\n정령에게 다가가서 공격하게나.", // str 0
        "잘했네. 이동키는 상대방의 공격을 피할 때도 쓸 수 있으니 꼭 기억해두게나.", //str 1
        "자네도 주술사니 주술로 직접 싸워보는 것은 어떤가? 우선은 내가 아는 주술을 알려주겠네.",
        "바발루 : 어려서 그런지 배우는 게 빠르군.",
        "바발루 : 저 탑에서 계속 나오고 있는 것 같네.\n아마 저 탑을 부수면 더 이상 밖으로 나오지 못할게야.",
        "자, 이 정도면 내일 아침까지는 괜찮을 것 같군. 어서 쉬고 내일 함께 정글을 빠져나가세나."
    };

    void Awake()
    {
        _Builder = new StringBuilder();
        _talkNum = -1;
    }

    void OnEnable()
    {
        _talkNum++;
        m_EndIndex = 1;
        _Builder.Remove(0, _Builder.Length);
        _Builder.Append(_talk[_talkNum]);
        StartCoroutine(DrawText());
    }

    void OnDisable()
    {
        m_TouchDown.SetActive(false);
    }

	// Use this for initialization
	void Start () {
        
	}
	
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(_TalkEnd);

        if(_TalkEnd)
        {
            if(_talkNum == 1 || _talkNum == 3)
            {
                _talkNum++;
                m_EndIndex = 1;
                _Builder.Remove(0, _Builder.Length);
                _Builder.Append(_talk[_talkNum]);
                StartCoroutine(DrawText());
                m_TouchDown.SetActive(false);
            }
            else
            {
                this.gameObject.SetActive(false);
            }
        }
        else
        {
            
            StopAllCoroutines();
            m_Talk.text = _talk[_talkNum];
            m_TouchDown.SetActive(true);
            StartCoroutine(DelayTalkEnd());
            
        }
    }

    IEnumerator DrawText()
    {
        _TalkEnd = false;
        while(m_EndIndex < _Builder.Length)
        {
            m_Talk.text = _Builder.ToString(0, m_EndIndex);
            m_EndIndex++;
            if(m_Talk.text[m_Talk.text.Length-1] == ' ')
            {
                yield return null;
            }

           

            if(m_EndIndex == _Builder.Length)
            {
                m_EndIndex = _Builder.Length;
                m_Talk.text = _Builder.ToString(0, m_EndIndex);
                m_TouchDown.SetActive(true);
                _TalkEnd = true;
                yield break;
            }


            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator DelayTalkEnd()
    {
        yield return new WaitForSeconds(0.1f);
        _TalkEnd = true;
        yield return null;
    }
}
