using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScript : MonoBehaviour
{
    public static testScript test;
    // Start is called before the first frame update
    private void Awake()
    {
        test = this;
    }
    public int add(int a, int b)
    {
        return a + b;
    }
}
