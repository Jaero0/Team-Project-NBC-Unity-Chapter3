using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSkill : MonoBehaviour
{
    [SerializeField] private Transform skillTransform;
    [SerializeField] private float spinSpeed;
    private float temp = 0;
   

    void Update()
    {
        temp += Time.deltaTime;
        skillTransform.rotation = Quaternion.Euler(0, 0, - temp * spinSpeed);
    }
}
