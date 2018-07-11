using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//binding spacebar to 'boost'


public class Rocket : MonoBehaviour {
   [SerializeField] float rcsThrust = 100f;
    [SerializeField]float mainThrust = 100f;
    Rigidbody rigidBody;

    AudioSource m_myAudioSource;
    bool m_Play;

    bool m_ToggleChange;
	// Use this for initialization
	void Start () {
        //grab rigidBody and init
        rigidBody = GetComponent<Rigidbody>();
        m_myAudioSource = GetComponent<AudioSource>();
        //i dont want booster sound to play at start
        m_Play = false;
    }
	
	// Update is called once per frame
	void Update () {
        Thrust();
        Steer();
      
	}
    //private means we can only call that private function from within code

    void OnCollisionEnter(Collision collision) {
        switch (collision.gameObject.tag) {
            case "Friendly":
                {
                    print("OK");        //TODO REMOVE
                    break;
                }
            case "Dead":
                {
                    print("Dead");      //TODO REMOVE
                    break;
                }
            case "Fuel":
                {

                    print("Fuel");      //TODO REMOVE
                    break;
                }
            default:
                {
                    break;
                }
                //do nothing
           
        }
    }


    /*Handle specific key inputs*/
   private void Thrust() {
        float mainSpeed = Time.deltaTime * mainThrust;
        if (Input.GetKey(KeyCode.Space))//can thrust while rotating
        {
            //Vector3 refers to 'position: x y z'
            //up refers to 'y' axis
            rigidBody.AddRelativeForce(Vector3.up* mainThrust);

            //if the audio isn't already playing, play the audio
            if (!m_myAudioSource.isPlaying)
            {
                m_myAudioSource.Play();
            }

        }
        else
        {
            m_myAudioSource.Stop();
        }
    }

  private  void Steer() {
        //take manual control of rotation once steering is triggered
        rigidBody.freezeRotation = true;


        
        float rotationSpeed = Time.deltaTime * rcsThrust;
        //left or right pressed?
        if (Input.GetKey(KeyCode.A))
        {
            
            transform.Rotate(Vector3.forward * rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotationSpeed);
        }
        rigidBody.freezeRotation = false;
    }
    //rotation = rcsThrust * Time.deltaTime;
}
