using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSkill : MonoBehaviour
{
    [SerializeField] public Transform skillTransform;
    [SerializeField] private float spinSpeed;
    private float temp = 0;
   

    void Update()
    {
        skillTransform.position = transform.position;
        temp += Time.deltaTime;
        skillTransform.rotation = Quaternion.Euler(0, 0, - temp * spinSpeed);
    }
}
