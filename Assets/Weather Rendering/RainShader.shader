Shader "Custom/RainShader" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_TileAmount("Tile Amount", float) = 1.0
		_RainSpeed("Rain Speed", float) = 1.0
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
	}

	SubShader {
		Tags { "Queue"="Transparent-1" "IgnoreProjector"="True" "RenderType"="Transparent"}
		
		
		Cull Off
		CGPROGRAM
		#pragma surface surf Standard alpha
		#pragma target 3.0

		sampler2D _MainTex;
		float _TileAmount;
		float _RainSpeed;

		struct Input {
			float2 uv_MainTex;
		};

		fixed4 _Color;

		void surf (Input IN, inout SurfaceOutputStandard o) {
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex*_TileAmount + float2(0.0, 1.0) * _RainSpeed * _Time.y) * _Color;
			if(c.a == 0)
				discard;

			o.Alpha = c.a;
			o.Albedo = c.rgb;
		}
		ENDCG
	} 
	FallBack "Transparent/Diffuse"
}
