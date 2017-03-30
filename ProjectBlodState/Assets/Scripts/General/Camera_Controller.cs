using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camera_Controller : MonoBehaviour
{
    public Camera cam;

    private float distance;
    public float sensitivityDistance = 50;
    public float damping;
    public float minFOV;
    public float maxFOV;


    private bool theRadio = false;
    private int songOn = 0;
    public Text StatusText;



    private static int seedGeneratorSeed = 1337;
    private static Random.State seedGenerator;
    int ATPlay;
    int LastNum1;
    int LastNum2;
    int LastNum3;


    public AudioSource[] sounds;
    public AudioSource Radio1;
    public AudioSource Radio2;
    public AudioSource Radio3;
    public AudioSource Radio4;
    public AudioSource Radio5;
    public AudioSource Radio6;
    public AudioSource Radio7;
    public AudioSource Radio8;
    public AudioSource Radio9;
    public AudioSource Music1;
    public AudioSource Music2;
    public AudioSource Music3;

    public AudioSource PlayingNow;

    public float rotateSpeed;
    public float moveSpeed;
    private float moveDistance;
    private float dist;

    private void RotateHorizontal(char type)
    {
        float dir = 1;
        if(type == 'R')
        {
            dir = -1;
        }
        transform.Rotate(0, dir * rotateSpeed, 0);
    }

    private void PlayMusic()
    {
        switch (songOn)
        {
            case 1:
                PlayingNow = Music2;
                break;
            case 2:
                PlayingNow = Music3;
                break;
            case 3:
                PlayingNow = Music1;
                break;
        }

        songOn++;
        if (songOn == 4)
        {
            songOn = 1;
        }
        PlayingNow.Play();

    }



    private void PlayRadio()
    {

        while (ATPlay == LastNum1 || ATPlay == LastNum2 || ATPlay == LastNum3)
        {
            ATPlay = Random.Range(1, 10);
        }


        LastNum3 = LastNum2;
        LastNum2 = LastNum1;
        LastNum1 = ATPlay;

        switch (ATPlay)
        {
            case 1:
                PlayingNow = Radio1;
                break;
            case 2:
                PlayingNow = Radio2;
                break;
            case 3:
                PlayingNow = Radio3;
                break;
            case 4:
                PlayingNow = Radio4;
                break;
            case 5:
                PlayingNow = Radio5;
                break;
            case 6:
                PlayingNow = Radio6;
                break;
            case 7:
                PlayingNow = Radio7;
                break;
            case 8:
                PlayingNow = Radio8;
                break;
            case 9:
                PlayingNow = Radio9;
                break;
        }
        PlayingNow.Play();

    }


    public void UpdateStatus()
    {
        StatusText.text = "Status: "+ Gameplay_Handler.Status;
    } 



    private void Start()
    {

        Random.InitState(seedGeneratorSeed);
        seedGenerator = Random.state;
        Random.state = seedGenerator;

        sounds = GetComponents<AudioSource>();
        Radio1 = sounds[0];
        Radio2 = sounds[1];
        Radio3 = sounds[2];
        Radio4 = sounds[3];
        Radio5 = sounds[4];
        Radio6 = sounds[5];
        Radio7 = sounds[6];
        Radio8 = sounds[7];
        Radio9 = sounds[8];
        Music1 = sounds[9];
        Music2 = sounds[10];
        Music3 = sounds[11];

        //Radio1.Play();


        PlayingNow = Music2;



        distance = cam.fieldOfView;
        UpdateStatus();
    }

    private void FixedUpdate()
    {
        UpdateStatus();
        if (!PlayingNow.isPlaying)
        {
            if (!theRadio)
            {
                PlayingNow.Stop();
                PlayMusic();
            }
            if (theRadio)
            {
                PlayingNow.Stop();
                PlayRadio();
            }
        }


        //zoom in and out
        distance -= Input.GetAxis("Mouse ScrollWheel") * sensitivityDistance;
        distance = Mathf.Clamp(distance, minFOV, maxFOV);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, distance, Time.deltaTime * damping);

        if (Input.GetKey(KeyCode.Q))
        {
            //rotate left
            RotateHorizontal('L');
        }
        else if (Input.GetKey(KeyCode.E))
        {
            //rotate right
            RotateHorizontal('R');
        }

        if (Input.GetKey(KeyCode.W))
        {
            //move forward
            transform.Translate(Vector3.forward * moveSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            //move back
            transform.Translate(Vector3.back * moveSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            //move Left
            transform.Translate(Vector3.left * moveSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            //move Right
            transform.Translate(Vector3.right * moveSpeed);
        }

        if (Input.GetKey(KeyCode.M))
        {
            theRadio = true;
            PlayingNow.Stop();
        }
    }
	
}
