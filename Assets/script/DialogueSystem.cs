using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections;
using SHIFT;

[RequireComponent(typeof(AudioSource))]
public class DialogueSystem : MonoBehaviour
{
    #region 資料
    [SerializeField, Header("畫布對話系統")]
    private CanvasGroup groupDialogue;
    [SerializeField, Header("說話者名稱")]
    private TextMeshProUGUI textname;
    [SerializeField, Header("對話內容")]
    private TextMeshProUGUI textContent;

    private AudioSource aud;

    [SerializeField, Header("淡入間隔")]
    private float intervalFadIn = 0.1f;
    [SerializeField, Header("打字間隔")]
    private float intervalType = 0.05f;


    public dataNPC datanpc;

    [SerializeField, Header("三角形")]
    private GameObject goTriangle;
    #endregion

    public bool isDialogue;

    //委派簽名 無傳回與無參數
    public delegate void DelegateFinishDialogue();

    private void Awake()
    {
        aud = GetComponent<AudioSource>();
        // StartCoroutine(FadeIn());
        //textname.text = datanpc.nameNPC;
        //textContent.text = "";
        //  StartCoroutine(  StartDialogue());
    }


    public IEnumerator StartDialogue(dataNPC _dataNPC, DelegateFinishDialogue callback)
    {
        isDialogue = true;

        datanpc = _dataNPC;

        textname.text = datanpc.nameNPC;
        textContent.text = "";
        yield return StartCoroutine(Fade());

        for (int i = 0; i < datanpc.dataDialoges.Length; i++)
        {

            yield return StartCoroutine(TypeEffect(i));

            while (!Input.GetKeyDown(KeyCode.E))
            {
                yield return null;

            }

        }


        StartCoroutine(Fade(false));
        isDialogue = false;
        callback(); //執行回呼函式
    }
    private IEnumerator Fade(bool fadeIn = true)
    {
        for (int i = 0; i <= 10; i++)
        {

            float increase = fadeIn ? 0.1f : -0.1f;
            groupDialogue.alpha += increase;

            yield return new WaitForSeconds(intervalFadIn);

        }
        // StartCoroutine(TypeEffect());
    }
    private IEnumerator TypeEffect(int indexDialogue)
    {
        textContent.text = "";
        aud.PlayOneShot(datanpc.dataDialoges[indexDialogue].sound);

        string content = datanpc.dataDialoges[indexDialogue].CONTENT;


        for (int i = 0; i < content.Length; i++)
        {
            textContent.text += content[i];

            yield return new WaitForSeconds(intervalType);
        }
        goTriangle.SetActive(true);
    }
}
