using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarroAleatorioDestroy : MonoBehaviour
{
    private void OnBecameInvisible()
    {

        Destroy(this);
    }
}
