using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities : MonoBehaviour
{
    public static int[] getRangeExclusive(int start, int end) {
        int[] output;
        if  (start < end) {
            output = new int[end - start - 1];
            for(int i = start + 1; i < end; i ++) {
                output[i - start - 1] = i;
            }
        } else {
            output = new int[start - end - 1];
            for(int i = end + 1; i < start; i ++) {
                output[i - end - 1] = i;
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
