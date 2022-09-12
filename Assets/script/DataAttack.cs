using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SHIFT
{
    [CreateAssetMenu(menuName = "SHIFT/Data Attack", fileName = "Data Attack", order = 1)]

    public class DataAttack : ScriptableObject
    {

        [Header("攻擊力"), Range(0, 1000)]
        public float attack;

        [Header("攻擊區域設定")]
        public Color attackAreaColor = new Color(1, 0, 0, 0.5f);
        public Vector3 attackAreaSize = Vector3.one;
        public Vector3 attackAreaOffset;
        [Header("攻擊目標圖層")]
        public LayerMask layerTarget;

        [Header("攻擊延遲時間"), Range(0, 3)]
        public float delatAttack = 1.5f;

        [Header("攻擊動畫檔")]
        public AnimationClip animationAttack;
        /// <summary>
        /// 等待攻擊結束:動畫的時間-攻擊延遲
        /// 怪物:4-1.5=2.5
        /// </summary>
        public float waitAttackEnd => animationAttack.length - delatAttack;
    }

}

