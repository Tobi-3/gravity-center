using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class OxygenSystem : MonoBehaviour
{
    [Header("Oxygen")]
    [SerializeField] private float _maxOxygen = 100f;
    [SerializeField] private float _oxygenDepletionRate = 1f;
    private float _currentOxygen;
    public float oxygenPercentage => _currentOxygen / _maxOxygen;

    [Header("Player References")]
    [SerializeField] private Player_Movement _playerInput;
    private float gravitationalImpact;


    public static UnityAction OnPlayerDied;
    public int Respawn;

    private void Start() {
        _currentOxygen = _maxOxygen;
    }

    private void Update() {
        
        if(_playerInput.GravityForce > 1){
            gravitationalImpact = _playerInput.GravityForce / 10f;
        }else {
            gravitationalImpact = 0f;
        }

        if(_playerInput.isMoving == false && _playerInput.isJumping == false){
           _oxygenDepletionRate = 1f + gravitationalImpact;
        }
        else if(_playerInput.isJumping){
            _oxygenDepletionRate = 2.0f + gravitationalImpact;
        }
        else if(_playerInput.isMoving){
            _oxygenDepletionRate = 1.5f + gravitationalImpact;
        }
    
         _currentOxygen -= (_oxygenDepletionRate * Time.deltaTime);

        if(_currentOxygen <= 0) {
            // OnPlayerDied?.Invoke();
            SceneManager.LoadScene(Respawn);
            _currentOxygen = 0f;
        }    
    }

    public void ReplenishOxygen(float oxygenAmount){
        _currentOxygen += oxygenAmount;

    if  (_currentOxygen > _maxOxygen)  _currentOxygen = _maxOxygen;


    }

}

