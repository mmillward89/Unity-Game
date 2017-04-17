using UnityEngine;
using System.Collections;

public class DestroyObject : MonoBehaviour
{

    void OnTriggerExit2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
}
