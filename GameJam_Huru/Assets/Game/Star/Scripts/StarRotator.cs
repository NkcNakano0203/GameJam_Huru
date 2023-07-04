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
        // y�������ɂ���5�x�Ax�������ɂ���5�x�A��]������Quaternion���쐬�i�ϐ���rot�Ƃ���j
        Quaternion rot = Quaternion.Euler(axis.x * speed, axis.y * speed, axis.z * speed);
        // ���݂̎��M�̉�]�̏����擾����B
        Quaternion q = trans.rotation;
        // �������āA���g�ɐݒ�
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