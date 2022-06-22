using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    public enum Shape
    {
        Sine,
        Triangle,
        SawTooth,
        Square
    }

    public float frequency = 440.0f;
    public float amplitude = 0.5f;
    [Range(0.01f, 0.99f)] public float width;
    public Shape shape = Shape.Sine;
    float time;

    public Oscillator(float frequency, float amplitude)
    {
        this.frequency = frequency;
        this.amplitude = amplitude;
        time = 0;
    }

    public float Sample(float tick)
    {
        time = Mathf.Repeat(time + tick * frequency, 1f);
        switch (shape)
        { 
            case Shape.Sine:
                return Mathf.Sin(time * 2.0f * Mathf.PI) * amplitude;
            case Shape.Triangle:
                return (Mathf.PingPong(4.0f * time, 2.0f) - 1.0f) * amplitude;
            case Shape.SawTooth:
                return (2.0f * time - 1.0f) * amplitude;
            case Shape.Square:
                return (time < width? -1.0f : 1.0f) * amplitude;
        }
        return 0;
    }
}
