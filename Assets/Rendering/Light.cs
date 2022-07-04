using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[System.Serializable]
[PostProcess(typeof(BatLightClipRenderer), PostProcessEvent.AfterStack, "BatCustom/BatLightClipDropdownDescription")]
public sealed class BatLightClipSettings : PostProcessEffectSettings
{
	[Range(0f, 5f), Tooltip("Brightness")] //bat
	public FloatParameter brightness = new FloatParameter { value = 1f }; //bat

	[Range(0f, 3f), Tooltip("Exponent")] //bat
	public FloatParameter exponent = new FloatParameter { value = 1f }; //bat

	[Range(0f, 5f), Tooltip("Light Clip Intensity")]
	public FloatParameter blend = new FloatParameter { value = 0f };

	[Range(0f, 2f), Tooltip("Soft Clip")]
	public FloatParameter softClip = new FloatParameter { value = 0f }; //New 2021_03_01
}

public sealed class BatLightClipRenderer : PostProcessEffectRenderer<BatLightClipSettings>
{
	public override void Render(PostProcessRenderContext postProcessRenderContext)
	{
		PropertySheet propertySheet = postProcessRenderContext.propertySheets.Get(Shader.Find("Hidden/Custom/BatLightClip"));
		propertySheet.properties.SetFloat("_Brightness", settings.brightness);
		propertySheet.properties.SetFloat("_Exponent", settings.exponent);
		propertySheet.properties.SetFloat("_Blend", settings.blend);
		propertySheet.properties.SetFloat("_SoftClip", settings.softClip);
		postProcessRenderContext.command.BlitFullscreenTriangle(postProcessRenderContext.source, postProcessRenderContext.destination, propertySheet, 0);
	}
}