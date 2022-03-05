using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities : MonoBehaviour
{
    public static int[] findRange(int start, int end) {
        int[] output;
        if  (start < end) {
            output = new int[end - start];
            for(int i = start; i < end; i ++) {
                output[i - start] = i;
            }
        } else {
            output = new int[start - end];
            for(int i = end; i < start; i ++) {
                output[i - end] = i;
            }
        }
        return output;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
