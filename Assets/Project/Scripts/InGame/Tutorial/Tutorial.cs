using UnityEngine;
using System.Collections;
using System.Text;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {

    [SerializeField]
    public Text m_Talk;
    private int _talkNum = 0;

    private bool _TalkEnd = true;
    

    StringBuilder _Builder;
    private int m_EndIndex;

    private string[] _talk =
    {
        "정령들이 공격해 오는군. 내 뒤로 숨거라.",
        "으윽, 허리가. 미안하지만 자네가 좀 처리해주겠나? 내가 어떻게 해야 할지 알려주겠네.",
        "이걸로 정령에게 다가가서 공격하게나.",
        "잘했네. 이동키는 상대방의 공격을 피할 때도 쓸 수 있으니 꼭 기억해두게나.",
        "그리고 양손에는 각각 서로 다른 무기를 써서 더 많은 공격을 할 수 있네.",
        "자네 혼자 싸우기엔 무리인 것 같구나.",
        "자네도 주술사니 정령은 다룰 줄 알겠지?"
    };

	// Use this for initialization
	void Start () {
        m_EndIndex = 1;
        _Builder = new StringBuilder();
        _Builder.Remove(0, _Builder.Length);

        _TalkEnd = false;

        _Builder.Append(_talk[_talkNum]);
        StartCoroutine(Illust());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator Illust()
    {
        while(m_EndIndex < _Builder.Length)
        {
            m_Talk.text = _Builder.ToString(0, m_EndIndex);
            m_EndIndex++;

            if(_TalkEnd == true)
            {
                if(m_EndIndex != _Builder.Length)
                {
                    Debug.Log("Nob");
                    m_EndIndex = _Builder.Length;
                    _TalkEnd = false;
                    m_Talk.text = _Builder.ToString(0, m_EndIndex);

                    yield break;
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
