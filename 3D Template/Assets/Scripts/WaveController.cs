using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    public List <WaveData> waveData;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < waveData[1].enemyCount; ++i)
        {
            Instantiate(waveData[0].enemyPrefab);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
