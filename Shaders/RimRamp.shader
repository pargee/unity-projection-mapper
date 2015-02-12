Shader "Custom/SimpleRim" {
	Properties {
		_Color("Color", Color) = (1,1,1,1)
		_RimColor("Rim Color", Color) = (1,1,1,1)
		_RimPower("Rim Power", Range(0.5, 8)) = 2
		
	}
	
	SubShader {
		Tags {"RenderType"="Opaque"}
		CGPROGRAM
		#pragma surface surf CustomDiffuse

		half4 LightingCustomDiffuse(SurfaceOutput s, half3 lightDir, half atten) {
			half3 NdotL = dot(s.Normal, lightDir);
			half diff = NdotL * 0.5 + 0.5;
			
			half4 c;
			c.rgb = s.Albedo * _LightColor0.rgb;
			c.a = s.Alpha;
			return c;
		}
		
		struct Input{
			float3 viewDir;
		};
		float4 _Color;
		float4 _RimColor;
		float _RimPower;
		
		void surf (Input IN, inout SurfaceOutput o) {
			o.Albedo = _Color.rgb;
			
			half rim = 1.0 - saturate(dot(normalize(IN.viewDir), o.Normal));
			o.Emission = _RimColor.rgb * pow(rim, _RimPower);
			
		}
	
		ENDCG
	}

	Fallback "Diffuse"
}