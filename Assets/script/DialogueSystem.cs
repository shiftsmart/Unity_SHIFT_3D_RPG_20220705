using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections;
using SHIFT;

[RequireComponent(typeof(AudioSource))]
public class DialogueSystem : MonoBehaviour
{
    #region ���
    [SerializeField, Header("�e����ܨt��")]
    private CanvasGroup groupDialogue;
    [SerializeField, Header("���ܪ̦W��")]
    private TextMeshProUGUI textname;
    [SerializeField, Header("��ܤ��e")]
    private TextMeshProUGUI textContent;

    private AudioSource aud;

    [SerializeField, Header("�H�J���j")]
    private float intervalFadIn = 0.1f;
    [SerializeField, Header("���r���j")]
    private float intervalType = 0.05f;


    public dataNPC datanpc;

    [SerializeField, Header("�T����")]
    private GameObject goTriangle;
    #endregion

    public bool isDialogue;

    //�e��ñ�W �L�Ǧ^�P�L�Ѽ�
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
        callback(); //����^�I�禡
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
