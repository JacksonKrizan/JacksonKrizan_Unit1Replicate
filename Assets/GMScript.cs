using UnityEngine;
using System.Collection.Generic;
using System.Collection;

public class GMScript : MonoBehaviour
{

    public GameObject bomb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(bomb);
        }
    }


}
