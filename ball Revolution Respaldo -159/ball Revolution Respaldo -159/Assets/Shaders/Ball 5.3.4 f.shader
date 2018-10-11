// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader ".Clase/Toon Fresnel Old Versions"
{
	Properties
	{
		_MainTex("Main Texture", 2D) = "black" {}
		_Color ("Base Color", Color) = (1,1,1,1)
		_FresnelAlpha("Fresnel Alpha", range(0.0,1.0)) = 1
		_FresnelPower("Fresnel Power", float) = 1
		_FresnelSteps("Fresnel Steps", int) = 1
	}

	SubShader
	{
		pass
		{
//			Tags { "LightMode" = "ForwardBase" }
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
				float3 worldPos : NORMAL1;
				float3 normal : NORMAL;
				float2 uv : TEXCOORD0;
			};

			//si el valor de la variable viene de afuera, se definen con uniform
			//si el valor de la variable se define cuando se de fine la variable, va sin uniform
			uniform float4 _LightColor0;
			float4 _Color;
			sampler2D _MainTex;
			float _FresnelAlpha;
			float _FresnelPower;
			int _FresnelSteps;

			float Posterize(float v, int steps)
			{
				return round(v*steps)/steps;
			}


			v2f vert (appdata i)
			{
				v2f o;
				o.pos = mul(UNITY_MATRIX_MVP,i.vertex);
				o.worldPos = mul(unity_ObjectToWorld,i.vertex);
				o.normal = mul(unity_ObjectToWorld,float4(i.normal,0)).xyz;
				o.uv = i.uv;
				return o;
			}

			float4 frag (v2f o) : COLOR
			{
				float3 worldNormal = normalize(o.normal);
				float3 lightDir = normalize(_WorldSpaceLightPos0.xyz);
				float3 viewDir = normalize(_WorldSpaceCameraPos.xyz + o.worldPos);

//				//---diffuse---
				float NdotL = saturate(dot(worldNormal,lightDir));
				float3 diffuseReflection = NdotL * _LightColor0.rgb + UNITY_LIGHTMODEL_AMBIENT;
				//------------

				//---fresnel---
				float fresnel = 1 - saturate(dot(viewDir,worldNormal));
				fresnel = pow(fresnel,_FresnelPower) * _FresnelAlpha;
				fresnel = Posterize(fresnel,_FresnelSteps); //toon
				//-------------

				float4 tex = tex2D(_MainTex, o.uv);
				return tex * _Color * float4(diffuseReflection,1) + fresnel;
			}

			ENDCG
		}
	}
	Fallback "Diffuse"
}