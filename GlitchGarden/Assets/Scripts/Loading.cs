using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Loading : MonoBehaviour
{
    [SerializeField] AudioClip loadingSound;
    [SerializeField] [Range(0, 1)] float loadingSoundVolume = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource.PlayClipAtPoint(loadingSound, Camera.main.transform.position, loadingSoundVolume);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
