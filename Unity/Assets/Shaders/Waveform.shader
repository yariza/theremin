Shader "Custom/Waveform"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		[HDR]
		_Color ("Color", Color) = (1, 0, 0, 1)
		_LineThickness ("Line Thickness", Range(.001, .25)) = .01
		_Frequency ("Frequency", Float) = 1
	}
	SubShader
	{
		Tags { "Queue" = "Transparent" "RenderType"="Transparent"}
		LOD 100

		Blend SrcAlpha OneMinusSrcAlpha
		Cull Off

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};


			sampler2D _MainTex;
			float4 _MainTex_ST;
			
			float _LineThickness;
			float _Frequency;
			float _Displacement;

			float4 _Color;

			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				float wave = sin(_Displacement + i.uv.x*_Frequency);

				// clamp to the edges

				wave *= 1. - 4.*(i.uv.x - .5)*(i.uv.x - .5);

				// set the line in center with thickness

				wave += 1;
				wave *= (.5 - _LineThickness);
				wave += _LineThickness;

				float eps = i.uv.y - wave;

				float alpha = saturate(1. - (abs(eps)*2. / _LineThickness));

				fixed4 col = float4(_Color.rgb * alpha, alpha);

				return col;
			}
			ENDCG
		}
	}
}
