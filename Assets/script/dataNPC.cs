using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace SHIFT
{


    [CreateAssetMenu(menuName = "SHIFT/dataNPC", fileName = "Data NPC", order = 2)]
    public class dataNPC : ScriptableObject
    {
        [Header("NPC名稱")]
        public string nameNPC;
        [Header("所有對話"), NonReorderable]
        public DataDialoge[] dataDialoges;
    }

    [System.Serializable]
    public class DataDialoge
    {
        [Header("對話內容")]
        public string CONTENT;
        [Header("對話音效")]
        public AudioClip sound;


    }
}
