// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'

Shader ".Clase/Diffuse Texture Ambient"
{
	Properties
	{
	_MainTex("Main Texture", 2D) = "white"{}
	_Color ("Base Color",Color) = (1,1,1,1)
	}

	SubShader
	{
	pass
	{
//		Tags{"LightMode" = "FowardBase"}
		CGPROGRAM
		#program vertex vert
		#program fragment frag
		#include "UnityCG.cginc"

		struct appdata
		{
		float4 vertex : POSITION;
		float3 normal: NORMAL;
		float2 uv : TEXCOORDO0;
		};

		struct v2f
		{

		float4 pos : SV_POSITION;
		float3 diffuse : COLOR;
		float2 uv : TEXCOORDO0;

		}
		v2f vert(appdata i)
		{
		v2f o;;
		float3 worldNormal = normalize(mul (float4(i.normal,0),unity_WorldToObject).xyz);
		float3 lightDir = normalize(_WorldSpaceLightPos0.xyz);
		float3 NdotL = saturate(dot(worldNormal,lightDir));
		float3 diffuseReflection = NdotL * _LightColor0.rgb + Unity_LIGHTMODEL_AMBIENT;

		o.pos = mul (UNITY_MATRIX_MVP,i.vertex);
		o.diffuse = float4 (diffuseReflection,1);
		o.uv = i.uv;
		return o;
		}

		float4 frag (v2f o) : COLOR
		{
		float4 tex = tex2D(_MainTex, O.uv);
		return tex * _Color * o.diffuse;
		}
		ENDCG

		}
	}
Fallback "Diffuse"
}