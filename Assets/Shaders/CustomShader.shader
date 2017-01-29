// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Custom/CustomShader"
{
    Properties
    {
        _MainTex ("Diffuse Texture", 2D) = "white" {}
        _Source ("Source", Vector) = (0.0, 0.0, 0.0)
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
 
            float4 frag(VertexOutput input) : COLOR
            {
//            	float4 gl_FragColor;
//            	
//            	float2 pos = mul(UNITY_MATRIX_VP, input.pos).xy;
//            	float3 ss = mul(UNITY_MATRIX_VP, _Source).xyz;
//			 
//			    float2 p = float2(pos.x - ss.x, (pos.y - ss.y));
//			    float len = length(p);
//			 
//			    gl_FragColor = tex2D( _MainTex, input.uv );
//
//			    if(len>ss.z) gl_FragColor = 1. - gl_FragColor;
//
//			    return gl_FragColor;

                float4 diffuseColor = tex2D(_MainTex, input.uv);
                diffuseColor.rgb *= diffuseColor.a;
                return diffuseColor;
            }
 
            ENDCG
        }
    }
}