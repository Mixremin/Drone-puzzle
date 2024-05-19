using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using System;

namespace PostProcessing.ASCII
{
    [Serializable]
    [VolumeComponentMenuForRenderPipeline("Post-processing/Custom/ASCIIOverlay", typeof(HDRenderPipeline))]
    public sealed class ASCIIOverlay : CustomPostProcessVolumeComponent, IPostProcessComponent
    {
        [Tooltip("Controls the intensity of the effect.")]
        public ClampedFloatParameter intensity = new ClampedFloatParameter(0f, 0f, 1f);

        public ClampedFloatParameter gamma = new ClampedFloatParameter(1f, 0f, 10f);

        public BoolParameter fastCalculation = new BoolParameter(false);

        public Vector2Parameter symbolPixelSize = new Vector2Parameter(new Vector2(8f, 16f));

        public IntParameter symbolAmount = new IntParameter(10);

        public BoolParameter keepOriginalColor = new BoolParameter(false);

        public ColorParameter symbolColor = new ColorParameter(Color.white);

        public ColorParameter backgroundColor = new ColorParameter(Color.black);

        public TextureParameter symbolTexture = new TextureParameter(null);

        Material m_Material;

        public bool IsActive() => m_Material != null && intensity.value > 0f && symbolAmount.value > 1 &&
                                  symbolTexture.value != null;

        // Do not forget to add this post process in the Custom Post Process Orders list (Project Settings > Graphics > HDRP Settings).
        public override CustomPostProcessInjectionPoint injectionPoint =>
            CustomPostProcessInjectionPoint.AfterPostProcess;

        const string kShaderName = "Shader Graphs/ASCIIOverlay";

        public override void Setup()
        {
            if (Shader.Find(kShaderName) != null)
                m_Material = new Material(Shader.Find(kShaderName));
            else
                Debug.LogError(
                    $"Unable to find shader '{kShaderName}'. Post Process Volume ASCIIOverlay is unable to load.");
        }

        public override void Render(CommandBuffer cmd, HDCamera camera, RTHandle source, RTHandle destination)
        {
            if (m_Material == null)
                return;

            m_Material.SetFloat("_Intensity", intensity.value);
            m_Material.SetFloat("_Gamma", gamma.value);
            m_Material.SetVector("_SymbolPixelSize", symbolPixelSize.value);
            m_Material.SetInt("_SymbolAmouont", symbolAmount.value);
            m_Material.SetInt("_KeepOriginalColor", keepOriginalColor.value ? 1 : 0);
            m_Material.SetInt("_FastCalculation", fastCalculation.value ? 1 : 0);
            m_Material.SetColor("_SymbolColor", symbolColor.value);
            m_Material.SetColor("_BackgroundColor", backgroundColor.value);
            m_Material.SetTexture("_MainTex", source);
            m_Material.SetTexture("_SymbolTex", symbolTexture.value);
            HDUtils.DrawFullScreen(cmd, m_Material, destination, shaderPassId: 0);
        }

        public override void Cleanup()
        {
            CoreUtils.Destroy(m_Material);
        }
    }
}