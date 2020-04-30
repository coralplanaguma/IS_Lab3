using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public float gotObjDestroyDelay;
    private bool touchObj;

    private Collider myCollider; 
    private Rigidbody myRigidbody;

    public AudioSource coinSource;

    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<Collider>();
        myRigidbody = GetComponent<Rigidbody>();
        coinSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void HitObj()
    {
        touchObj = true; 
        coinSource.Play();

        gameObject.transform.localScale += new Vector3(83, 5, 83);

        var rend = gameObject.GetComponent<Renderer>();
        rend.material.SetColor("_Color", Color.green);

        Destroy(gameObject, gotObjDestroyDelay); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wrist") && !touchObj)
        {
            HitObj(); 
        }
    }
}
