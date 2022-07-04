Shader "Hidden/Custom/BatLightClip"
{
	HLSLINCLUDE

#include "Packages/com.unity.postprocessing/PostProcessing/Shaders/StdLib.hlsl"

		TEXTURE2D_SAMPLER2D(_MainTex, sampler_MainTex);
	float _Brightness; //bat
	float _Exponent; //bat
	float _Blend;
	float _SoftClip;

	float4 BatFrag(VaryingsDefault i) : SV_Target
	{
		float4 color = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord);

		if (_Exponent != 1)
		{
			float colorMag = sqrt(color.r * color.r + color.g * color.g + color.b * color.b);
			float newColorMag = pow(colorMag, _Exponent);
			float colorMult = newColorMag / colorMag;
			color = float4(colorMult * color.r, colorMult * color.g, colorMult * color.b, 1); //color = GammaToLinearSpace(color); linear space to gammma space or something inbetween (0.4545 is linear --> gamma?)
		}

		if (_Blend > 0) //can be set to 0 to ignore
		{
			//float luminance = dot(color.rgb, float3(0.2126729, 0.7151522, 0.0721750));
			float colorMag = sqrt(color.r * color.r + color.g * color.g + color.b * color.b);
			if (colorMag > _Blend)
			{
				float dividerRatio = colorMag / _Blend;
				color = float4(color.r / dividerRatio, color.g / dividerRatio, color.b / dividerRatio, 1);// color / dividerRatio;
			}
		}

		if (_Brightness != 1)
		{
			color = float4(_Brightness * color.r, _Brightness * color.g, _Brightness * color.b, 1); //bat
		}

		if (_SoftClip > 0)
		{
			float rgbMax = max(color.r, max(color.g, color.b));
			float rgbMaxNew = rgbMax / (rgbMax + 1);
			float colorMult = rgbMaxNew / rgbMax;
			color = float4(color.r * colorMult, color.g * colorMult, color.b * colorMult, 1);
		}


		return color;
	}

		ENDHLSL

		SubShader
	{
		Cull Off
			ZWrite Off
			ZTest Always

			Pass
		{
			HLSLPROGRAM
#pragma vertex VertDefault
#pragma fragment BatFrag
			ENDHLSL
		}
	}
}