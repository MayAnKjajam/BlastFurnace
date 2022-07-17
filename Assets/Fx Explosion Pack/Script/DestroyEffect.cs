using UnityEngine;
using System.Collections;

public class DestroyEffect : MonoBehaviour {

    private void OnEnable()
    {
        Destroy(this.gameObject, 5f);
    }
}
