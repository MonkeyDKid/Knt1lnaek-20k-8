Shader "Tesca/Simple/Unlit Double Sided Color" {
	Properties {
		_MainTex ("Base (RGB) Alpha (A)", 2D) = "white" {}
		_Color ("Main Color", Color) = (1,1,1,1)
	}
	Category {		
		SubShader {
			Lighting Off
			Cull off
			ColorMaterial AmbientAndDiffuse
			Blend SrcAlpha OneMinusSrcAlpha
			Pass {
				SetTexture [_MainTex] {
				constantColor [_Color]
				Combine texture * constant, texture * constant 
				}
			}
		}
	}
} 