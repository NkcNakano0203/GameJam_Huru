using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarFactory : MonoBehaviour
{
    [SerializeField]
    Star[] star;

    float t;

    void Start()
    {

    }

    void Update()
    {
        t += Time.deltaTime;
        if (t <= 2) return;
        for (int i = 0; i < star.Length; i++)
        {
            if (!star[i].gameObject.activeSelf) continue;
            star[i].gameObject.SetActive(true);
            //star[i].transform.position=
            star[i].Init();            
        }
    }
}
