using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections; 
using SHIFT;

[RequireComponent(typeof(AudioSource))]
public class DialogueSystem : MonoBehaviour
{
    [SerializeField, Header("畫布對話系統")]
    private CanvasGroup groupDialogue;
    [SerializeField, Header("說話者名稱")]
    private TextMeshProUGUI textname;
    [SerializeField, Header("對話內容")]
    private TextMeshProUGUI textContent;

    private AudioSource aud;

    public dataNPC datanpc;

    [SerializeField, Header("三角形")]
    private GameObject goTriangle;

    private void Awake()
    {
        aud = GetComponent<AudioSource>();
        StartCoroutine(FadeIn());
        textname.text = datanpc.nameNPC;
        textContent.text = "";
    }
 
    private IEnumerator FadeIn()
    {
        for (int i = 0; i <= 10; i++)
        {
            groupDialogue.alpha += 0.1f;

            yield return new WaitForSeconds(0.1f);

        }
        StartCoroutine(TypeEffect());
    }
       private IEnumerator TypeEffect()
    {
        aud.PlayOneShot(datanpc.dataDialoges[0].sound);

        string content = datanpc.dataDialoges[0].CONTENT;


        for (int i = 0; i <=content.Length; i++)
        {
            textContent.text += content[i];

            yield return new WaitForSeconds(0.05f);
        }
        goTriangle.SetActive(true);
    }
}
