using UnityEngine;

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
        if(Input.GetButtonDown("Jump"))
        {
            DestroyObject(bomb);
        }
    }
    void DestroyObject(GameObject bomb)
    {
        Destroy(bomb);
    }

}
