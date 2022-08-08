using System.Collections;
using System.Collections.Generic;
using SHIFT;
using UnityEngine;

public class NPCSystem : MonoBehaviour
{

    [SerializeField, Header("NPC ��ܸ��")]
    private dataNPC dataNPC;
    [SerializeField, Header("NPC ��v��")]
    private GameObject goCamera;

    private Animator aniTip;
    private string parTipFade = "Ĳ�o�H�J�H�X";
    private bool isInTrigger;
    private ThirdPersonController thirdPersoncontroller;
    private DialogueSystem dialogueSystem;

    private Animator ani;
    private string parDialogue = "�}�����";

    private void Awake()
    {
        aniTip = GameObject.Find("���ܩ���").GetComponent<Animator>();

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
            //   print("���Ue�}�l���");
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
