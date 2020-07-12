using UnityEngine;

public class Lighter : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Foot"))
        {
            other.GetComponent<DuckFoot>().GotBurnt();
            other.GetComponent<DuckFoot>().FootUsed();
        }
    }
}