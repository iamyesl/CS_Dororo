using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostEffects_MultiPass_Selecting : MonoBehaviour
{
    Shader myShader;        // image effect shader 
    Material myMaterial;

    public bool DepthEffect;
    public float depth = 1f;

    public bool OverlayEffect;
    public Texture2D OverlayTexture;
    public float OverlayOpacity = 1.0f;

    public bool BlendEffect;
    public Texture2D BlendTexture;
    public float BlendOpacity = 1.0f;

    public bool Color;
    public float brightness = 1.0f;
    public float saturation = 1.0f;
    public float contrast = 1.0f;



    void Start()
    {
        myShader = Shader.Find("My/PostEffects/MultiPass");    // image effect shader file must have been created
        myMaterial = new Material(myShader);
    }

    private void OnDisable()
    {
        /*if (myMaterial)
        {
            DestroyImmediate(myMaterial);
        }*/
    }

    private void Update()
    {
        if (OverlayEffect)
        {
            OverlayOpacity = Mathf.Clamp(OverlayOpacity, 0.0f, 1.0f);
        }
        else if (BlendEffect)
        {
            BlendOpacity = Mathf.Clamp(BlendOpacity, 0.0f, 1.0f);
        }
        else if (Color)
        {
            brightness = Mathf.Clamp(brightness, 0.0f, 3.0f);
            saturation = Mathf.Clamp(saturation, 0.0f, 3.0f);
            contrast = Mathf.Clamp(contrast, 0.0f, 3.0f);
        }
    }


    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (DepthEffect) 
        {
            myMaterial.SetFloat("_Depth", depth);
            Graphics.Blit(source, destination, myMaterial, 0);
        }
        else if (OverlayEffect)
        {
            myMaterial.SetTexture("_BlendTex", OverlayTexture);
            myMaterial.SetFloat("_Opacity", OverlayOpacity);
            Graphics.Blit(source, destination, myMaterial, 1);
        }
        else if (BlendEffect)
        {
            myMaterial.SetTexture("_BlendTex", BlendTexture);
            myMaterial.SetFloat("_Opacity", BlendOpacity);
            Graphics.Blit(source, destination, myMaterial, 2);
        }
        else if (Color)
        {
            myMaterial.SetFloat("_Brightness", brightness);
            myMaterial.SetFloat("_Saturation", saturation);
            myMaterial.SetFloat("_Contrast", contrast);
            Graphics.Blit(source, destination, myMaterial, 3);
        }
        else
        {
            Graphics.Blit(source, destination);
        }
    }
}
