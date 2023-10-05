using UnityEngine;

public class EntryPersistance : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
