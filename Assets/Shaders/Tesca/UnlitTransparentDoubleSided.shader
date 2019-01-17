Shader "Tesca/Transparent/Unlit Double Sided" {
	Properties {
		_MainTex ("Base (RGB) Alpha (A)", 2D) = "white" {}
	}
	Category {
		Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
		SubShader {
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