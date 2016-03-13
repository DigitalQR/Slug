using UnityEngine;
using System.Collections;

public class OnCollisionMakeChild : MonoBehaviour {

    void OnCollisionEnter(Collision col)
    {
        col.gameObject.transform.SetParent(transform);
    }

    void OnCollisionExit(Collision col)
    {
        col.gameObject.transform.SetParent(null);
    }
}
