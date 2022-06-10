using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.UI;

public class BrainSCript : MonoBehaviour
{
    public GameObject brainAudio;
    public GameObject brainAudioSight;

    //[SerializeField] private Slider slider;
    public Slider slider;

    [Range(0, 2500)]
    public int spawnAudioSight;

    public int spawnAudio;

    public VisualEffect hearingVFX;
    public VisualEffect SightVFX;
    public VisualEffect hearingAndSightVFX;


    private void Start()
    {
        Application.targetFrameRate = 120;
    }

    void Update()
    {
        spawnAudio = 2500 - spawnAudioSight;

        brainAudioSight.GetComponent<VisualEffect>().SetInt("Spawn Rate Hearing Sight", spawnAudioSight);
        brainAudio.GetComponent<VisualEffect>().SetInt("Spawn Rate Hearing", spawnAudio);

        if(spawnAudioSight > 0)
        {
            hearingVFX.Play();
            hearingAndSightVFX.Play();
            SightVFX.Play();
        }
    }

    public void ToggleBrainActivity(VisualEffect vfxObject, bool toggleButtonState)
    {
        if(toggleButtonState)
            vfxObject.GetComponent<VisualEffect>().Play();
        else vfxObject.GetComponent<VisualEffect>().Stop();
    }

    public void SliderValueChanged()
    {
        spawnAudioSight = (int)slider.value;
    }
}
