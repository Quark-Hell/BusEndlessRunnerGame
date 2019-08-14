﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MetersPassed : MonoBehaviour
{
    public Text score;
    public int multiplier = 4;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        score.text = $"{(int)(multiplier * Time.time - startTime)} m";
    }
}
