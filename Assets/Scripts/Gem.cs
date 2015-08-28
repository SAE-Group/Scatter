﻿using UnityEngine;
using System.Collections;

public class Gem : MonoBehaviour {
    private string searchTag = "Player";

    private bool pickedUp = false;

    private AudioSource audio;

    void Start(){
        audio = GetComponent<AudioSource>();
    }

    void Update() {
        if (!pickedUp)
            transform.Rotate(new Vector3(0, 0, 100 * Time.deltaTime));
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == searchTag && !pickedUp){
            PlayerController player = other.GetComponent<PlayerController>();

            if (player && player.Able())
                player.gemGet(transform);
            else
                return;

            pickedUp = true;

            audio.Play();

            transform.parent = other.transform.FindChild("char").transform.FindChild("Chibi_Pelvis").transform.FindChild("Chibi_Spine1").transform.FindChild("Chibi_Spine2").transform.FindChild("Chibi_Spine3").transform.FindChild("Chibi_Spine4").transform.FindChild("Chibi_Ribcage").transform;

            transform.rotation = transform.parent.rotation;
            transform.localRotation = Quaternion.Euler(0, 90, 0);

            transform.position = transform.parent.position;

            transform.localPosition = new Vector3(0, 1, 0);
        }
    }

    public void drop(){
        pickedUp = false;
    }
}