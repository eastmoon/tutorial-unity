using UnityEngine;
using System.Collections;

public class HelloWorldScript : MonoBehaviour
{
    // Member variable
    private bool isUpdate;

    // Use this for initialzation system.
    void Awake()
    {
        Debug.Log("Application Awake Behaviour");
    }

    // Use this for initialization game object.
    void Start ()
    {
        Debug.Log("Application Start Behaviour");

        this.isUpdate = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (!this.isUpdate)
        {
            this.isUpdate = true;
            Debug.Log("Application Update Behaviour");
        }
    }
}
