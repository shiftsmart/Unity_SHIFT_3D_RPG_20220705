using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SHIFT
{
    /// <summary>
    /// ��q���
    /// </summary>

    [CreateAssetMenu(menuName ="SHIFT/Data Heath",fileName ="Data Health")]
    public class DataHealth : ScriptableObject
    {

        [Header("��q"), Range(0, 10000)]
        public float hp;
        [HideInInspector]
        public float hpMax => hp;
        [Header("�O�_�����_��")]
        public bool isDropProp;
        [HideInInspector, Header("�_���w�s��")]
        public GameObject goProp;
        [HideInInspector, Header("�_���������v"), Range(0f, 1f)]
        public float propProbability;

    }
    [CustomEditor(typeof(DataHealth))]
    public class DataHealthEditor : Editor {
        SerializedProperty spIsDropProp;
        SerializedProperty spGoProp;
        SerializedProperty spPropPropbability;

        private void OnEnable()
        {
            spIsDropProp = serializedObject.FindProperty(nameof(DataHealth.isDropProp));
            spGoProp = serializedObject.FindProperty(nameof(DataHealth.goProp));
            spPropPropbability = serializedObject.FindProperty(nameof(DataHealth.propProbability));
        }
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            serializedObject.Update();
            if (spIsDropProp.boolValue) {
                EditorGUILayout.PropertyField(spGoProp);
                EditorGUILayout.PropertyField(spPropPropbability);

            }
            serializedObject.ApplyModifiedProperties();
        }



    }
}

