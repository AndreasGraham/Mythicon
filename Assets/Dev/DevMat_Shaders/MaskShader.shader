Shader "Custom/MaskShader" 
{
	Properties
	{
		_MainTex("Main texture", 2D) = "white"{}
		_Mask ("Mask Texture", 2D) = "white"{}
	}

	SubShader
	{
		Tags { "Queue"="Transparent" }
		Lighting On
		ZWrite off
		Blend SrcAlpha OneMinusSrcAlpha

		Pass
		{
			SetTexture [_Mask] {combine texture}
			SetTexture [_MainTex] {combine texture, previous}
		}
	}
}
