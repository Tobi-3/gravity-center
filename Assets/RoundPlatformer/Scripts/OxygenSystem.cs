using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class OxygenSystem : MonoBehaviour
{
    [Header("Oxygen")]
    [SerializeField] private float _maxOxygen = 100f;
    [SerializeField] private float _oxygenDepletionRate = 1f;
    private float _currentOxygen;
    public float oxygenPercentage => _currentOxygen / _maxOxygen;

    [Header("Player References")]
    [SerializeField] private Player_Movement _playerInput;
    
    public static UnityAction OnPlayerDied;

    private void Start() {
        _currentOxygen = _maxOxygen;
    }

    private void Update() {
        
        if(_playerInput.isMoving == false && _playerInput.isJumping == false){
           _oxygenDepletionRate = 1f;
        }
        else if(_playerInput.isJumping){
            _oxygenDepletionRate = 2.0f;
        }
        else if(_playerInput.isMoving){
            _oxygenDepletionRate = 1.5f;
        }        
         _currentOxygen -= _oxygenDepletionRate * Time.deltaTime;

        if(_currentOxygen <= 0) {
            OnPlayerDied?.Invoke();
            _currentOxygen = 0f;
        }    
    }

    public void ReplenishOxygen(float oxygenAmount){
        _currentOxygen += oxygenAmount;

    if  (_currentOxygen > _maxOxygen)  _currentOxygen = _maxOxygen;


    }

}

