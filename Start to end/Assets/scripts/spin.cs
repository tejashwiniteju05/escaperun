
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin : MonoBehaviour
{
    // Start is called before the first frame update
    private void Update()
    {
        transform.Rotate(0, 0.8f, 0);
    }
}