Shader "Custom/Water shader" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_waveSpeed ("Wave Speed", float) = 0.1
		_waveMagnitude ("Wave Magnitude", float) = 2

		_bumpMap ("Bump Map", 2D) = "gray" {}
		_normalMap ("Normal Map", 2D) = "gray" {}
		_dudvMap ("DuDv Map", 2D) = "gray" {}
	}

	SubShader {
		Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
		LOD 200

		Cull Off
		CGPROGRAM

		#pragma surface fragmentFunction Standard fullforwardshadows alpha vertex:vertexFunction
		#pragma target 3.0

		sampler2D _dudvMap;
		sampler2D _bumpMap;
		sampler2D _normalMap;
		float _waveSpeed;
		float _waveMagnitude;

		void vertexFunction (inout appdata_full v) {
			fixed4 uv = v.texcoord + _Time * float4(1,0,0,0) * _waveSpeed;

			float4 bump = tex2Dlod(_bumpMap, uv);
			float displacement = bump * _waveMagnitude;

			v.vertex.xyz += v.normal * displacement;
			v.normal = tex2Dlod(_normalMap, uv).rgb;
		}


		struct Input {
			float2 uv_MainTex;
		};

		sampler2D _MainTex;
		fixed4 _Color;

		void fragmentFunction(Input IN, inout SurfaceOutputStandard o) {
			float2 uv = IN.uv_MainTex;

			fixed4 c = tex2D (_bumpMap, uv);
			o.Albedo = c;
			//o.Smoothness = 0.3;
			o.Alpha = 1;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
