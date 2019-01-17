Shader "Custom/CurvedXUnitychan"
{
	Properties
	{
		_Color("Main Color", Color) = (1, 1, 1, 1)
		_ShadowColor("Shadow Color", Color) = (0.8, 0.8, 1, 1)
		_SpecularPower("Specular Power", Float) = 20
		_EdgeThickness("Outline Thickness", Float) = 1

		_MainTex("Diffuse", 2D) = "white" {}
		_FalloffSampler("Falloff Control", 2D) = "white" {}
		_RimLightSampler("RimLight Control", 2D) = "white" {}
		_SpecularReflectionSampler("Specular / Reflection Mask", 2D) = "white" {}
		_EnvMapSampler("Environment Map", 2D) = "" {}
		_NormalMapSampler("Normal Map", 2D) = "" {}

		_QOffset("Offset", Vector) = (0,0,0,0)
		_Dist("Distance", Float) = 100.0
	}

		SubShader
	{
		Tags
	{
		"RenderType" = "Opaque"
		"Queue" = "Geometry"
		"LightMode" = "ForwardBase"
	}

		Pass
	{
		Cull Off
		ZTest LEqual
		CGPROGRAM
#pragma multi_compile_fwdbase
#pragma vertex vert
#pragma fragment frag
#include "UnityCG.cginc"
#include "AutoLight.cginc"
#include "CharaMain.cg"
		ENDCG
	}

		Pass
	{
		Cull Front
		ZTest Less
		CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#include "UnityCG.cginc"
#include "CharaOutline.cg"
		ENDCG
	}

			Pass
		{
			CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#include "UnityCG.cginc"
			sampler2D _MainTex;
		float4 _QOffset;
		float _Dist;

		struct v2f {
			float4 pos : SV_POSITION;
			float4 uv : TEXCOORD0;
		};

		v2f vert(appdata_base v)
		{
			v2f o;
			float4 vPos = mul(UNITY_MATRIX_MV, v.vertex);
			float zOff = vPos.z / _Dist;
			vPos += _QOffset*zOff*zOff;
			o.pos = mul(UNITY_MATRIX_P, vPos);
			o.uv = mul(UNITY_MATRIX_TEXTURE0, v.texcoord);
			return o;
		}

		half4 frag(v2f i) : COLOR
		{
			half4 col = tex2D(_MainTex, i.uv.xy);
			return col;
		}
			ENDCG
		}

	}

		FallBack "Transparent/Cutout/Diffuse"
}
