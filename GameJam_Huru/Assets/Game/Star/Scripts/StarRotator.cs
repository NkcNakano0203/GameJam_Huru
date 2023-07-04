using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StarRotator : MonoBehaviour
{
    [SerializeField]
    Vector3 axis = Vector3.zero;
    [SerializeField]
    Transform trans;

    float speed = 0;
    bool isActive = false;

    private void Update()
    {
        if (!isActive) return;
        // y軸を軸にして5度、x軸を軸にして5度、回転させるQuaternionを作成（変数をrotとする）
        Quaternion rot = Quaternion.Euler(axis.x * speed, axis.y * speed, axis.z * speed);
        // 現在の自信の回転の情報を取得する。
        Quaternion q = trans.rotation;
        // 合成して、自身に設定
        trans.rotation = q * rot;
    }

    public void Init(float value)
    {
        speed = value;
        isActive = true;
    }

    public void Term()
    {
        isActive = false;
        speed = 0;
    }
}