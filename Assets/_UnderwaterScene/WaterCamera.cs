using UnityEngine;

namespace UnityStandardAssets.Characters.FirstPerson
{
    public class WaterCamera : MonoBehaviour
    {
        public Material Wobble;
        public Color underwaterColor;

        [Header("Shaders"), Space]
        public Shader overlay;

        [HideInInspector] public bool effectActive;

        private void Update()
        {
            Wobble.shader = overlay;
        }

        private void OnRenderImage(RenderTexture source, RenderTexture destination)
        {
            Wobble.SetColor("_Color", underwaterColor);
            Graphics.Blit(source, destination, Wobble);
        }
    }
}
