using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door2 : MonoBehaviour
{
    public GameObject door_closed, door_opened;
    public AudioClip open, close;
    private AudioSource audioSource;
    public bool opened;

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Make sure your GameObject has an AudioSource component attached.
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera")){
            if (opened == false)
            {
                // intText.SetActive(true);
                if(Input.GetKeyDown(KeyCode.E))
                {
                    door_closed.SetActive(false);
                    door_opened.SetActive(true);
                    // intText.SetActive(false);
                    audioSource.clip = open;
                    audioSource.Play();
                    StartCoroutine(repeat());
                    opened = true;
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("MainCamera"))
        {
            // intText.SetActive(false);
        }
    }

    IEnumerator repeat()
    {
        yield return new WaitForSeconds(1.0f);
        opened = false;
        door_closed.SetActive(true);
        door_opened.SetActive(false);
        audioSource.clip = close;
        audioSource.Play();
    }
}
