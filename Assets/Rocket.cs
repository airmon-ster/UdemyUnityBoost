﻿using UnityEngine;

public class Rocket : MonoBehaviour
{

    [SerializeField] float rcsThrust = 50f;
    [SerializeField] float mainThrust = 20f;
    Rigidbody rigidBody;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Thrust();
        Rotate();
    }

    void OnCollisionEnter(Collision collision){
        switch(collision.gameObject.tag){
            case "Friendly":
                // nothing
            break;
            case "Fuel":
                print("fuel");
            break;
            default:
                print("killed");
            break;
        }
    }

   private void Thrust() {
        if (Input.GetKey(KeyCode.Space)){
            rigidBody.AddRelativeForce(Vector3.up * mainThrust);
            if (!audioSource.isPlaying){
            audioSource.Play();
            }
        } else {
            audioSource.Stop();
        }
    }
    private void Rotate(){
        rigidBody.freezeRotation = true; // take manual control of rotation

        
        float rotationThisFrame = rcsThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.A)){
            
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }
        else if (Input.GetKey(KeyCode.D)){
            transform.Rotate(-Vector3.forward * rotationThisFrame);
        }
        rigidBody.freezeRotation = false; // resume control
    }
 
}
