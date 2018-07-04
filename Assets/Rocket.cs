using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//binding spacebar to 'boost'


public class Rocket : MonoBehaviour {

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


        //keep update short and simple
        ProcessInput();
	}
    //private means we can only call that private function from within code
    private void ProcessInput()
    {
        HandleSpaceKey();
        HandleDirectionalKeys();

    }


    /*Handle specific key inputs*/
    void HandleSpaceKey() {
        if (Input.GetKey(KeyCode.Space))//can thrust while rotating
        {
            //Vector3 refers to 'position: x y z'
            //up refers to 'y' axis
            rigidBody.AddRelativeForce(Vector3.up);

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

    void HandleDirectionalKeys() {
        //left or right pressed?
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward);
        }
    }
    //rotation = rcsThrust * Time.deltaTime;
}
