using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Trigger boss music
//Written by Tapani Kronkvist
public class bossSceneMusic : MonoBehaviour
{
    public List<GameObject> musicTracks;
    [SerializeField] GameObject firstTrack;
    [SerializeField] GameObject secondTrack;
    // Start is called before the first frame update
    void Start()
    {
        firstTrack = Instantiate(musicTracks[0],transform.position,Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && secondTrack == null)
        {
            Destroy(firstTrack);
            secondTrack = Instantiate(musicTracks[1], transform.position, Quaternion.identity);
        }

        Camera.main.orthographicSize *= 2;
    }

}
