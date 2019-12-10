using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class synthesiser : MonoBehaviour
{

    float SAMPLERATE = 44100.0f;
    float[] samples;
    public AudioClip aNote, bNote, cNote, dNote, eNote, fNote, gNote;
    float frequency;
    float amplitude = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        CreateANote();
        CreateBNote();
        CreateCNote();
        CreateDNote();
        CreateENote();
        CreateFNote();
        CreateGNote();
    }

    void CreateANote()
    {
        samples = new float[44100];
        frequency = 440.0f * (Mathf.Pow(Mathf.Pow(2.0f, (1.0f / 12.0f)), 0.0f));

        for (int i = 0; i < SAMPLERATE; i++)
        {
            samples[i] = amplitude * Mathf.Sin((i / SAMPLERATE) * frequency * (2.0f * Mathf.PI));
        }
        aNote = AudioClip.Create("noteA", samples.Length, 1, Mathf.RoundToInt(SAMPLERATE), false);
        aNote.SetData(samples, 0);
    }
    void CreateBNote()
    {
        samples = new float[44100];
        frequency = 493.883f * (Mathf.Pow(Mathf.Pow(2.0f, (1.0f / 12.0f)), 0.0f));

        for (int i = 0; i < SAMPLERATE; i++)
        {
            samples[i] = amplitude * Mathf.Sin((i / SAMPLERATE) * frequency * (2.0f * Mathf.PI));
        }
        bNote = AudioClip.Create("noteB", samples.Length, 1, Mathf.RoundToInt(SAMPLERATE), false);
        bNote.SetData(samples, 0);
    }
    void CreateCNote()
    {
        samples = new float[44100];
        frequency = 523.251f * (Mathf.Pow(Mathf.Pow(2.0f, (1.0f / 12.0f)), 0.0f));

        for (int i = 0; i < SAMPLERATE; i++)
        {
            samples[i] = amplitude * Mathf.Sin((i / SAMPLERATE) * frequency * (2.0f * Mathf.PI));
        }
        cNote = AudioClip.Create("noteC", samples.Length, 1, Mathf.RoundToInt(SAMPLERATE), false);
        cNote.SetData(samples, 0);
    }
    void CreateDNote()
    {
        samples = new float[44100];
        frequency = 587.330f * (Mathf.Pow(Mathf.Pow(2.0f, (1.0f / 12.0f)), 0.0f));

        for (int i = 0; i < SAMPLERATE; i++)
        {
            samples[i] = amplitude * Mathf.Sin((i / SAMPLERATE) * frequency * (2.0f * Mathf.PI));
        }
        dNote = AudioClip.Create("noteD", samples.Length, 1, Mathf.RoundToInt(SAMPLERATE), false);
        dNote.SetData(samples, 0);
    }
    void CreateENote()
    {
        samples = new float[44100];
        frequency = 659.255f * (Mathf.Pow(Mathf.Pow(2.0f, (1.0f / 12.0f)), 0.0f));

        for (int i = 0; i < SAMPLERATE; i++)
        {
            samples[i] = amplitude * Mathf.Sin((i / SAMPLERATE) * frequency * (2.0f * Mathf.PI));
        }
        eNote = AudioClip.Create("noteE", samples.Length, 1, Mathf.RoundToInt(SAMPLERATE), false);
        eNote.SetData(samples, 0);
    }
    void CreateFNote()
    {
        samples = new float[44100];
        frequency = 698.456f * (Mathf.Pow(Mathf.Pow(2.0f, (1.0f / 12.0f)), 0.0f));

        for (int i = 0; i < SAMPLERATE; i++)
        {
            samples[i] = amplitude * Mathf.Sin((i / SAMPLERATE) * frequency * (2.0f * Mathf.PI));
        }
        fNote = AudioClip.Create("noteF", samples.Length, 1, Mathf.RoundToInt(SAMPLERATE), false);
        fNote.SetData(samples, 0);
    }
    void CreateGNote()
    {
        samples = new float[44100];
        frequency = 783.991f * (Mathf.Pow(Mathf.Pow(2.0f, (1.0f / 12.0f)), 0.0f));

        for (int i = 0; i < SAMPLERATE; i++)
        {
            samples[i] = amplitude * Mathf.Sin((i / SAMPLERATE) * frequency * (2.0f * Mathf.PI));
        }
        gNote = AudioClip.Create("noteG", samples.Length, 1, Mathf.RoundToInt(SAMPLERATE), false);
        gNote.SetData(samples, 0);
    }
}
