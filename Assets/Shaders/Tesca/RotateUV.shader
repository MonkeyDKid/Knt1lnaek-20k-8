Shader "Tesca/Animated/UVRotation"
{
	Properties{
		_MainTex("Base (RGB) Trans (A)", 2D) = "white" {}
	_AlphaMap("Gradient Transparency Map", 2D) = "white" {}
	_GlowColor("Glow Color", Color) = (1.0, 1.0, 1.0, 1.0)
		_ScrollXSpeed("X Scroll Speed", Float) = 2
		_ScrollYSpeed("Y Scroll Speed", Float) = 2
		_RotationSpeed("Rotation Speed", Float) = 2.0
	}

		SubShader{
		Tags{ "IgnoreProjector" = "True" }
		Blend SrcAlpha OneMinusSrcAlpha

		CGPROGRAM
#pragma surface surf Standard vertex:vert keepalpha

		sampler2D _MainTex;
	sampler2D _AlphaMap;
	float4 _Color;
	fixed4    _GlowColor;
	fixed _ScrollXSpeed;
	fixed _ScrollYSpeed;
	float _RotationSpeed;

	struct Input {
		float2 uv_MainTex;
		float2 uv3_AlphaMap; // using uv3 aka texcoord2
	};


	//rotation code begins here; rotates the alphamap
	void vert(inout appdata_full v) {
		float s = sin(_RotationSpeed * _Time);
		float c = cos(_RotationSpeed * _Time);

		float2x2 rotationMatrix = float2x2(c, -s, s, c);

		v.texcoord2.xy = mul(v.texcoord.xy - 0.5, rotationMatrix) + 0.5; // grab texcoord and overwrite texcoord2 instead of using texcoord1 at all
	}
	//rotation code ends here        

	void surf(Input IN, inout SurfaceOutputStandard o) {

		fixed2 scrolledUV = IN.uv3_AlphaMap;
		fixed xScrollValue = frac(_ScrollXSpeed*_Time.y);
		fixed yScrollValue = frac(_ScrollYSpeed*_Time.y);

		scrolledUV += fixed2(xScrollValue,yScrollValue);

		half4 c = tex2D(_MainTex, IN.uv_MainTex) * _GlowColor.a;
		o.Albedo = tex2D(_AlphaMap, scrolledUV).rgb;
		if (c.a<0.01) discard;
		o.Alpha = c.a * tex2D(_AlphaMap, scrolledUV).a;

	}
	ENDCG
	}
}
