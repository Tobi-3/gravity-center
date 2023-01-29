using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAudio : MonoBehaviour
{
    [Header("Audios")]
    [SerializeField] private AudioSource src;
    [SerializeField] private AudioClip jump, pickup, powerup, death, oxygenRefill;

    [Header("Player References")]
    [SerializeField] private Player_Movement _playerInput;
    [SerializeField] private PlayerInventory _playerInventory;

    [Header("Oxygen Refernces")]
    [SerializeField] private OxygenSystem _oxygenSystem;
    [SerializeField] private OxygenRefill _oxygenRefill;
    //private bool hasPlayed;

    void Update(){
        jumpSound();
        pickupPart();
        pickupPowerUp();
        refilling();
    }

    private void jumpSound(){
        if(Input.GetButtonDown("Jump") && _playerInput.JumpCount < _playerInput.NumberOfJumps){
            src.clip = jump;
            src.Play();
        }
    }

    private void pickupPart(){
        if(_playerInventory.partPickedUp){
            src.clip = pickup;
            src.Play();
            _playerInventory.partPickedUp = false;
        }
    }

    private void pickupPowerUp(){
        if(_playerInventory.powerUpPickedUp){
            src.clip = powerup;
            src.Play();
            _playerInventory.powerUpPickedUp = false;
        }
    }

    private void refilling(){
        if(_oxygenRefill.refillig){          
            src.clip = oxygenRefill;
            if(!src.isPlaying){
                src.Play();
            }
        }
    }
}
