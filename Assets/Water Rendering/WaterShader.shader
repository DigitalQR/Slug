Shader "Custom/WaterShader" {
	Properties{
		_Colour("Colour", Color) = (1,1,1,1)
		_WaveMagnitude("Wave Magnitude", float) = 1
		_WaveSpeed("Wave Speed", float) = 0.1
		_WaveDirection("Wave Direction", Vector) = (0,1,0,0)

		_SpecularFactor("Specular Factor", range(0,1)) = 1
		_Glossiness("Glossiness", float) = 1

		_BumpMap("Bump Map", 2D) = "white" {}
		_NormalMap("Normal Map", 2D) = "white" {}
		_Cube("Reflection Map", Cube) = "" {}

	}
	SubShader{
		Tags{ "Queue" = "Transparent" "RenderType" = "Transparent" }
		
		Cull Off
		CGPROGRAM
		#pragma surface SurfaceFunction Lambert alpha vertex:VertexFunction
		
			sampler2D _BumpMap;
			sampler2D _NormalMap;
			samplerCUBE _Cube;

			float _WaveSpeed;
			float _WaveMagnitude;
			float4 _WaveDirection;

			half _SpecularFactor;
			float _Glossiness;

			void VertexFunction(inout appdata_full v)
			{				
				v.texcoord += _Time.y * _WaveDirection * _WaveSpeed;

				fixed3 bump = tex2Dlod(_BumpMap, v.texcoord);

				v.vertex.xyz += v.normal * bump.x * _WaveMagnitude;
			}

			fixed4 _Colour;

			struct Input {
				float2 uv_BumpMap;
				float3 worldRefl;
				INTERNAL_DATA
			};

			void SurfaceFunction(Input inp, inout SurfaceOutput output)
			{
				fixed4 texture_colour = tex2D(_BumpMap, inp.uv_BumpMap);

				output.Albedo = texture_colour.rgb * _Colour.rgb * 0.5;
				output.Normal = tex2D(_NormalMap, inp.uv_BumpMap);
				output.Alpha = 0.6;
				output.Emission = texCUBE(_Cube, WorldReflectionVector (inp, output.Normal)).rgb * 0.5;
				output.Specular = _SpecularFactor;
				output.Gloss = _Glossiness;
			}

		ENDCG
	}
	Fallback "Diffuse"
}
