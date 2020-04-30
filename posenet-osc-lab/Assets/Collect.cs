using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public float runSpeed;
    public float gotObjDestroyDelay;
    private bool touchObj;

    private Collider sphCollider;
    private Rigidbody sphRigidbody;

    public AudioSource sphereSource;

    // Start is called before the first frame update
    void Start()
    {
        sphCollider = GetComponent<Collider>();
        sphRigidbody = GetComponent<Rigidbody>();
        sphereSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * runSpeed * Time.deltaTime);
    }

    private void HitObj()
    {
        touchObj = true; 
        runSpeed = 0; 
        Destroy(gameObject, gotObjDestroyDelay); 
        sphereSource.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wrist") && !touchObj)
        {
            HitObj(); 
        }
    }
}
