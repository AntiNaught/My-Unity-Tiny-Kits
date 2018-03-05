Shader "Mask Progress"
{
	Properties
	{
		_Foreground("Foreground",2D)="white"{}
		_Background("Background",2D)="white"{}
		_Value("Value",Range(0,1)) = 0.5
	}
	SubShader{
		Blend SrcAlpha OneMinusSrcAlpha
		pass
		{
			CGPROGRAM
			#pragma vertex vert 
			#pragma fragment frag 
			#include "UnityCG.cginc"

			sampler2D _Foreground;
			float4 _Foreground_ST;
			sampler2D _Background;
			float4 _Background_ST;
			float _Value;

			struct a2v
			{
				float4 vertex : POSITION ;
				float4 color:COLOR;
				float2 texcoord:TEXCOORD;
			};

			struct v2f
			{
				float4 vertex:SV_POSITION;
				fixed4 color:COLOR;
				half2 texcoord:TEXCOORD0;
				float4 worldPosition:TEXCOORD1;
			};

			v2f vert(a2v v)
			{
				v2f o;
				o.worldPosition = v.vertex;
				o.color = v.color;
				o.texcoord = v.texcoord;
				o.vertex = UnityObjectToClipPos(v.vertex);
				return o;
			}

			fixed4 frag(v2f i):SV_TARGET 
			{
				half4 color = (tex2D(_Foreground,i.texcoord))*i.color;
				color.w = ceil(_Value - i.texcoord.x);
				// color = ;// ceil(i.texcoord.x - _Value);
				return color;
			}

			ENDCG
		}
	}	
}