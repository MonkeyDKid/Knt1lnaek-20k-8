Shader "Tesca/Simple/Unlit Double Sided" {
	Properties {
		_MainTex ("Base (RGB) Alpha (A)", 2D) = "white" {}
	}
	Category {		
		SubShader {
			Lighting off
			Cull off
			ColorMaterial AmbientAndDiffuse
			Blend SrcAlpha OneMinusSrcAlpha
			Pass {
				SetTexture [_MainTex] {combine texture * primary}
			}
		}
	}
} 