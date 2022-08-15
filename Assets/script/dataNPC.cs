using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace SHIFT
{


    [CreateAssetMenu(menuName = "SHIFT/dataNPC", fileName = "Data NPC", order = 2)]
    public class dataNPC : ScriptableObject
    {
        [Header("NPC�W��")]
        public string nameNPC;
        [Header("�Ҧ����"), NonReorderable]
        public DataDialoge[] dataDialoges;
    }

    [System.Serializable]
    public class DataDialoge
    {
        [Header("��ܤ��e")]
        public string CONTENT;
        [Header("��ܭ���")]
        public AudioClip sound;


    }
}
