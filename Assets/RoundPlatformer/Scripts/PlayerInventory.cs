using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfParts{ get; private set; }
    public bool partPickedUp;
    public bool powerUpPickedUp;
    public int WinScene;
    public int NrPartsNeeded;

    public UnityEvent<PlayerInventory> OnPartsCollected;

    public void PartsCollected()
    {
        NumberOfParts++;
        OnPartsCollected.Invoke(this);
        partPickedUp = true;
        if(NumberOfParts == NrPartsNeeded){
            SceneManager.LoadScene(WinScene);
        }
    }

}
