using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCapsule : MonoBehaviour
{
    public float gotObjDestroyDelay;
    private bool touchObj;

    private Collider myCollider; 
    private Rigidbody myRigidbody;

    public AudioSource capsule2Source;
    private List<GameObject> objList = new List<GameObject>(); 



    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<Collider>();
        myRigidbody = GetComponent<Rigidbody>();
        capsule2Source = GetComponent<AudioSource>();
        //touchObj = false;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other) // 1
    {
        if (other.CompareTag("Wrist") && !touchObj) // 2
        {
            DestroyAll(); 
        }
    }

    public void DestroyAll()
    {
        capsule2Source.Play();
        myRigidbody.isKinematic = false; // 1
        myCollider.isTrigger = false; // 2
        Destroy(gameObject, gotObjDestroyDelay); // 3       
    }
}
