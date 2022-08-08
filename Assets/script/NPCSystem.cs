using System.Collections;
using System.Collections.Generic;
using SHIFT;
using UnityEngine;

public class NPCSystem : MonoBehaviour
{

    [SerializeField, Header("NPC 對話資料")]
    private dataNPC dataNPC;
    [SerializeField, Header("NPC 攝影機")]
    private GameObject goCamera;

    private Animator aniTip;
    private string parTipFade = "觸發淡入淡出";
    private bool isInTrigger;
    private ThirdPersonController thirdPersoncontroller;
    private DialogueSystem dialogueSystem;

    private Animator ani;
    private string parDialogue = "開關對話";

    private void Awake()
    {
        aniTip = GameObject.Find("提示底圖").GetComponent<Animator>();

        thirdPersoncontroller = FindObjectOfType<ThirdPersonController>();
        dialogueSystem = FindObjectOfType<DialogueSystem>();
        ani = GetComponent<Animator>();
    }
    private void Update()
    {
        InputKeyAndStartDialogue();


    }
    private void OnTriggerEnter(Collider other)
    {
        CheckPlayerAndAnimation(other.name, true);

    }
    private void OnTriggerExit(Collider other)
    {
        CheckPlayerAndAnimation(other.name, false);
    }


    private void CheckPlayerAndAnimation(string nameHit, bool _isIntrigger)
    {
        if (nameHit == "pico")
        {

            isInTrigger = _isIntrigger;
            aniTip.SetTrigger(parTipFade);
        }


    }

    private void InputKeyAndStartDialogue()
    {

        if (dialogueSystem.isDialogue) return;
        if (isInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            //   print("按下e開始對話");
            goCamera.SetActive(true);
            aniTip.SetTrigger(parTipFade);
            thirdPersoncontroller.enabled = false;
            ani.SetBool(parDialogue,true);
            StartCoroutine(dialogueSystem.StartDialogue(dataNPC, ResetControllerAndCloseCamera));
        }

    }
    private void ResetControllerAndCloseCamera()
    {
        goCamera.SetActive(false);
        thirdPersoncontroller.enabled = true;
        aniTip.SetTrigger(parTipFade);
        ani.SetBool(parDialogue,false);
    }


}
