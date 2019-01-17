Shader "Tesca/Transparent/Unlit Alpha Cutoff" {
	Properties {
		_MainTex ("Base (RGB) Alpha (A)", 2D) = "white" {}
		_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
	}
	Category {
		Tags {"Queue"="Transparent" "RenderType"="Transparent"}
		SubShader {
			alphaTest greater [_Cutoff]
			Lighting Off
			Cull off
			ColorMaterial AmbientAndDiffuse
			Blend SrcAlpha OneMinusSrcAlpha
			Pass {
				SetTexture [_MainTex] {combine texture * primary}
			}
		}
	}
} 