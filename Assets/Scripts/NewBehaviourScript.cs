using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private float time = 0.0f;
    private Material mat;

    public float disTime = 1;
    // Start is called before the first frame update
    void Start()
    {
        time = 0.0f;
        mat = this.gameObject.GetComponent<Renderer>().material;
    }

    private bool _dis = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            time = 0.0f;
            _dis = true;
        }

        if (_dis)
        {
            if (time < 2)
            {
                time += Time.deltaTime * (2 / disTime);
                mat.SetFloat("_dissolvePower", time-1);
            }
            else
            {
                time = 0.0f;
                _dis = false;
            }
            
        }
    }
}
