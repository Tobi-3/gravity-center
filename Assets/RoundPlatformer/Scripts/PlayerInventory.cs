using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfParts{ get; private set; }

    public UnityEvent<PlayerInventory> OnPartsCollected;

    public void PartsCollected()
    {
        NumberOfParts++;
        OnPartsCollected.Invoke(this);
    }

}
