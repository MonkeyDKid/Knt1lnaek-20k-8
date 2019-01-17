Shader "Tesca/Simple/Diffuse Double Sided" {
	Properties {
		_MainTex ("Base (RGB) Alpha (A)", 2D) = "white" {}
	}
	Category {		
		SubShader {
			Cull off
			ColorMaterial AmbientAndDiffuse
			Blend SrcAlpha OneMinusSrcAlpha
			Pass {
				SetTexture [_MainTex] {combine texture * primary}
			}
		}
	}
} 