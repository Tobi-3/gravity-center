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

    public static UnityAction OnPlayerDied;
    public int Respawn;

    private void Start() {
        _currentOxygen = _maxOxygen;
    }

    private void Update() {
        _currentOxygen -= _oxygenDepletionRate * Time.deltaTime;

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

