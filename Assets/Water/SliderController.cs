using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderController : MonoBehaviour
{
    public Material m_Wave;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnAmplitudeChanged(System.Single val)
    {
        Debug.Log("New Amplitude: " + val);
        m_Wave.SetFloat("_WaveAmplitude", val);
    }
    public void OnAmountChanged(System.Single val)
    {
        Debug.Log("New Amount: " + val);
        m_Wave.SetFloat("_WaveAmount", val);
    }
    public void OnSpeedChanged(System.Single val)
    {
        Debug.Log("New Speed: " + val);
        m_Wave.SetFloat("_Speed", val);
    }
    public void OnWhitecapChanged(System.Single val)
    {
        Debug.Log("New Whitecap Height: " + val);
        m_Wave.SetFloat("_WhiteCapHeight", 1-val);
    }
}
