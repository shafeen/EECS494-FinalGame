Shader "Custom/glow" {

    Properties {

        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ( "Main Texture", 2D) = "white" {}
    }

    SubShader {

        Tags { "Queue"="Transparent" }

        ZTest LEqual
        
        ZWrite On

        Cull Off
        
        LOD 100

//       Blend SrcAlpha OneMinusSrcAlpha     // Alpha blending
//		Blend One One                       // Additive
//		Blend DstColor One          // Soft Additive
//		Blend DstColor Zero                 // Multiplicative
//		Blend DstColor SrcColor             // 2x Multiplicative
		Blend OneMinusSrcAlpha One

 		Pass {

			CGPROGRAM

			//#pragma surface surf Lambert 
			#pragma fragmentoption ARB_precision_hint_fastest
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			//Uniforms
			uniform sampler2D _MainTex;
			uniform float4 _MainTex_ST;
			uniform float4 _Color;
			uniform float Blend_Level;

			 
			 struct VertexInput {
			 	float4 vertex : POSITION;
			 	float4 texcoord  : TEXCOORD0;
			 };
			 
			 struct FragmentInput {
			 	float4 pos : SV_POSITION;
			 	half2 uv : TEXCOORD0;
			 	half uv2 : TEXCOORD1;
			 };

//			struct Input {
//			    float3 viewDir;
//			    float3 worldNormal;
//			};

			 
//			void surf (Input IN, inout SurfaceOutput o) {
//
//			    o.Alpha = _Color.a * pow(abs(dot(normalize(IN.viewDir),
//
//			    normalize(IN.worldNormal))),4.0);
//
//			    o.Emission = _Color.rgb * o.Alpha;
//
//			}

			FragmentInput vert( VertexInput i ) {
				FragmentInput o;
				o.pos = mul( UNITY_MATRIX_MVP, i.vertex );
				o.uv = TRANSFORM_TEX( i.texcoord, _MainTex );
				//o.uv2 = TRANSFORM_TEX( i.texcoord, _MainTex );
				
				return o;
			}

			half4 frag( FragmentInput i ) : COLOR {
				fixed4 mainTexColor = tex2D( _MainTex, i.uv );
				
				return mainTexColor * _Color;
			}

        ENDCG

    	} 

	}

    FallBack "Diffuse"

}