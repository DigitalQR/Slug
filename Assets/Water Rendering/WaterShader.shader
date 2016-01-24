Shader "Custom/WaterShader" {
	Properties{
		_Colour("Colour", Color) = (1,1,1,1)
		_WaveMagnitude("Wave Magnitude", float) = 1
		_WaveSpeed("Wave Speed", float) = 0.1
		_WaveDirection("Wave Direction", Vector) = (0,1,0,0)

		_BumpMap("Bump Map", 2D) = "white" {}
		_Cube("Reflection Map", Cube) = "" {}

	}
	SubShader{
		Tags{ "Queue" = "Transparent" "RenderType" = "Transparent" }
		LOD 300

		Cull Off
		CGPROGRAM
		#pragma surface SurfaceFunction Standard fullforwardshadows alpha vertex:VertexFunction
		#pragma target 3.0
		
			sampler2D _MainTexture;
			sampler2D _BumpMap;

			float _WaveSpeed;
			float _WaveMagnitude;
			float4 _WaveDirection;

			void VertexFunction(inout appdata_base v)
			{				
				v.texcoord += _Time.y * _WaveDirection * _WaveSpeed;



				fixed3 bump = tex2Dlod(_BumpMap, v.texcoord);

				v.vertex.xyz += v.normal * bump.x * _WaveMagnitude;
				v.normal = bump;
			}

			fixed4 _Colour;

			struct Input {
				float2 uv_BumpMap;
			};

			void SurfaceFunction(Input inp, inout SurfaceOutputStandard output)
			{
				fixed4 colour = tex2D(_BumpMap, inp.uv_BumpMap) * _Colour;
				output.Albedo = colour.rgb * 2;
				output.Alpha = 0.6;
			}

		ENDCG
	}
}
