using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightHouseRotator : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 3.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }
}
