Shader ".Clase/Toon Diffuse"
{
	Properties
	{
		_MainTex("Main Texture", 2D) = "white" {}
		_Color ("Base Color", Color) = (1,1,1,1)
		_LightSteps("Light Steps", int) = 1
	}

	SubShader
	{
		pass
		{
			Tags { "LightMode" = "ForwardBase" }
			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float4 pos :  SV_POSITION;
				float3 normal : NORMAL;
				float2 uv : TEXCOORD0;
			};

			//si el valor de la variable viene de afuera, se definen con uniform
			//si el valor de la variable se define cuando se de fine la variable, va sin uniform
			uniform float4 _LightColor0;
			float4 _Color;
			sampler2D _MainTex;
			int _LightSteps;

			float Posterize(float v, float steps)
			{
				return ceil(v*steps)/steps;
			}

			v2f vert (appdata i)
			{
				v2f o;

				o.pos = mul(UNITY_MATRIX_MVP,i.vertex);
				o.normal = mul(unity_ObjectToWorld,float4(i.normal,0)).xyz;
				o.uv = i.uv;

				return o;
			}

			float4 frag (v2f o) : COLOR
			{
				float3 worldNormal = normalize(o.normal);
				float3 lightDir = normalize(_WorldSpaceLightPos0.xyz);

				//---diffuse---
				float NdotL = saturate(dot(worldNormal,lightDir));
				float3 diffuseReflection = NdotL * _LightColor0.rgb ;
				diffuseReflection = Posterize(diffuseReflection,_LightSteps) + UNITY_LIGHTMODEL_AMBIENT;
				///------------

				float4 tex = tex2D(_MainTex, o.uv);
				return tex * _Color * float4(diffuseReflection,1);
			}

			ENDCG
		}
	}
	Fallback "Diffuse"
}