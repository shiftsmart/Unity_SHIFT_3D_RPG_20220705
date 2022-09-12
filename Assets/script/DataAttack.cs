using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SHIFT
{
    [CreateAssetMenu(menuName = "SHIFT/Data Attack", fileName = "Data Attack", order = 1)]

    public class DataAttack : ScriptableObject
    {

        [Header("�����O"), Range(0, 1000)]
        public float attack;

        [Header("�����ϰ�]�w")]
        public Color attackAreaColor = new Color(1, 0, 0, 0.5f);
        public Vector3 attackAreaSize = Vector3.one;
        public Vector3 attackAreaOffset;
        [Header("�����ؼйϼh")]
        public LayerMask layerTarget;

        [Header("��������ɶ�"), Range(0, 3)]
        public float delatAttack = 1.5f;

        [Header("�����ʵe��")]
        public AnimationClip animationAttack;
        /// <summary>
        /// ���ݧ�������:�ʵe���ɶ�-��������
        /// �Ǫ�:4-1.5=2.5
        /// </summary>
        public float waitAttackEnd => animationAttack.length - delatAttack;
    }

}

