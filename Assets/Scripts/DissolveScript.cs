using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveScript : MonoBehaviour
{
    public float timer = 0.0f;
    public bool _dissolve = false;
    public Material mat;
    public float matFl = 0;


    public float dissolveTime = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        mat = this.gameObject.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.O))
        {
            _dissolve = true;
            timer = 0;
            mat.SetFloat("_dissolvePower", timer - 1);
        }
        
        if (_dissolve)
        {
            if (timer < 2)
            {
                timer += Time.deltaTime*(2/dissolveTime);
                mat.SetFloat("_dissolvePower", timer-1);
            }
            else
            {
                _dissolve = false;
               //this.gameObject.active = false;
            }
        }
    }
}
