// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Custom/CustomShader"
{
    Properties
    {
        _MainTex ("Diffuse Texture", 2D) = "white" {}
        _Source ("Source", Vector) = (0.0, 0.0, 0.0)
        _Color("Color", Vector) = (1,0,0,1)
    }
    SubShader
    {
    	Cull Off
        AlphaTest NotEqual 0.0
        Blend One OneMinusSrcAlpha
        Pass
        {
            Tags { "LightMode" = "ForwardBase" }
 
            CGPROGRAM
 
            #pragma vertex vert
            #pragma fragment frag
 
            #include "UnityCG.cginc"
 
            // User-specified properties
            uniform sampler2D _MainTex;
            uniform float3 _Source;
            uniform float4 _Color;
 
            struct VertexInput
            {
                float4 vertex : POSITION;
                float4 uv : TEXCOORD0;
            };
 
            struct VertexOutput
            {
                float4 pos : POSITION;
                float2 uv : TEXCOORD0;
            };
 
            VertexOutput vert(VertexInput input) 
            {
                VertexOutput output;
                output.pos = mul(UNITY_MATRIX_MVP, input.vertex);
                output.uv = float2(input.uv.xy);
                return output;
            }

            float rand(float2 co){
			    return frac(sin(dot(co.xy ,float2(12.9898,78.233))) * 43758.5453);
			}
 
            float4 frag(VertexOutput input) : COLOR
            {
            	float r1 = 0.005;
			    float r2 = r1*2.;
			    float s1 = 1.-r1*2.;
			    float s2 = 1.-r2*2.;

        		float4 outColor;
//
//            	float4 screenPos = mul(unity_WorldToObject, float4(_Source, 0));
//
//            	float xx = input.pos.x;
//			    float yy = input.pos.y;
//			 
//			    float2 p = float2(xx - screenPos.x, (yy - screenPos.y));
//			    float len = length(p);
//			 
//			    float ran = 2000*rand(float2(_SinTime.w+xx,_SinTime.x+sin(yy)));
//
//			    float ux = input.uv.x;
//		    	float uy = input.uv.y;
//		       	float3 newcoordx = float3(ux,ux*s1+r1,ux*s2+r2);
//		        float3 newcoordy = float3(uy,uy*s1+r1,uy*s2+r2);
//				outColor = float4(0,0,0,1);
//		 
//		        outColor.r = tex2D( _MainTex, float2(newcoordx.r, newcoordy.r)).r;
//		        outColor.g = tex2D( _MainTex, float2(newcoordx.g, newcoordy.g)).g;
//		        outColor.b = tex2D( _MainTex, float2(newcoordx.b, newcoordy.b)).b; 
//
//			    if(len+ran>2030) {
//			    	outColor.rgb += _Color.rgb * _Color.a;
//			    }


			    outColor = tex2D( _MainTex, input.uv);
			    outColor.rgb *= outColor.a;

			    return outColor;
//            	

            	
//
//            	float yy = input.uv.y;
//			    float xx = input.uv.x;// + sin(rand(float2(screenPos.y,_SinTime.x))) * 0.004;
//
//            	float2 p = float2(xx - screenPos.x, (yy - screenPos.y)*9./16.);
//			    float len = length(p);
//			 
//			    float ran = rand(float2(_SinTime.x+xx,yy));
//			 
//			    if(ran>0.1) outColor = float4(0.,0.,0.,0.);
//			    else outColor = tex2D( _MainTex, float2(xx,yy) );
//
//			    outColor.rgb *= outColor.a;
//
//			    return outColor;
            }
 
            ENDCG
        }
    }
}