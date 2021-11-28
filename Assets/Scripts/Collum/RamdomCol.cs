using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamdomCol : MonoBehaviour
{
    [SerializeField]
    GameObject collum;


    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn) ,1.5f,1.5f );
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }
    void Update()
    {
    }
    void Spawn()
    {
        GameObject pipes = Instantiate(collum, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(-1.4f,2.8f); 
    }
}
