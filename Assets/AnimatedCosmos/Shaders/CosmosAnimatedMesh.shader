﻿Shader "lit/Cosmos Animated Mesh"{
	Properties {
		[Hdr]_Color ("Color", Color) = (3, 5, 6, 3)
		[Header(Main Texture)]
		[NoScaleOffset]_MainTex ("", Cube) = "white" {}
		_Colorize ("Colorize", Range(0,2)) = 0.6
		_Glossiness("Roughness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0
		_Emission("Emission", float) = 0

		[Space(20)]
		[Toggle(ANIM_ON)]_AnimOn ("Animation", FLOAT) = 1
		[Space(20)]
		[Header(Detail 1)]
		[NoScaleOffset]_Detail1 ("", 2D) = "white" {}
		_D1I ("Intensity", Range(0,2)) = 1
		_D1Scale ("Scale", FLOAT) = 2
		_D1Distort ("Distortion", FLOAT) = 0.1
        _D1Speed ("Speed", FLOAT) = 5
		[Space(20)]
		[Header(Detail 2)]
		[NoScaleOffset]_Detail2 ("", 2D) = "white" {}
		_D2I ("Intensity", Range(0,2)) = 0.8
		_D2Scale ("Scale", FLOAT) = 5
		_D2Distort ("Distortion", FLOAT) = 0.1
        _D2Speed ("Speed", FLOAT) = 3
		[Space(20)]
		[Toggle(ROT_ON)]_RotOn ("Rotation Enabled", FLOAT) = 1
		_Rotation ("Rotation", VECTOR) = (0,0,0,0)

		[Space(20)]
        [Enum(UnityEngine.Rendering.CullMode)]_Culling ("Culling", FLOAT) = 0
	}

	SubShader {
		Tags { "Queue"="Geometry" "RenderType"="Geometry"}
        Cull [_Culling]

		Pass {
			
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma shader_feature __ ANIM_ON
			#pragma shader_feature __ ROT_ON

			#include "UnityCG.cginc"
			
			struct appdata_t {
				float4 vertex : POSITION;
				fixed3 normal : NORMAL;
                UNITY_VERTEX_INPUT_INSTANCE_ID //Insert
			};

			struct v2f {
				float4 vertex : POSITION;
				fixed3 normal : NORMAL;
				float3 texcoord : TEXCOORD0;
				#if !defined(ANIM_ON)
				float3 texcoord1 : TEXCOORD1;
				float3 texcoord2 : TEXCOORD2;
				#endif
                UNITY_VERTEX_OUTPUT_STEREO //Insert
			};

			float3 _Rotation;

			float2 rotate(float2 v, float a){
				float cs = cos(a);
				float sn = sin(a);
				return float2(
					v.x * cs - v.y * sn,
					v.x * sn + v.y * cs
				);
			}
			
			fixed4 _Color;
			samplerCUBE _MainTex;
			half _Colorize;
			sampler2D _Detail1;
			half _D1I;
			half _D1Scale;
			sampler2D _Detail2;
			half _D2I;
			half _D2Scale;

			#ifdef ANIM_ON
			half _D1Speed;
			half _D1Distort;
			half _D2Speed;
			half _D2Distort;
			#endif

			v2f vert (appdata_t v)
			{
				v2f o;
                
                UNITY_SETUP_INSTANCE_ID(v); //Insert
                UNITY_INITIALIZE_OUTPUT(v2f, o); //Insert
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o); //Insert
				
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.normal = v.normal;
				float3 texcoord = v.vertex.xyz;
				#ifdef ROT_ON
				texcoord.yz = rotate(texcoord.yz, _Rotation.x/57.29578);
				texcoord.zx = rotate(texcoord.zx, _Rotation.y/57.29578);
				texcoord.xy = rotate(texcoord.xy, _Rotation.z/57.29578);
				#endif
				o.texcoord = texcoord;
				#if !defined(ANIM_ON)
				o.texcoord1 = texcoord * _D1Scale;
				o.texcoord2 = texcoord * _D2Scale;
				#endif
				return o;
			}

			fixed4 triplanar(sampler2D tex, float3 coord, fixed3 normal, half scale){
				fixed4 c = 
				     tex2D(tex, coord.xy * scale) * abs(normal.z);
				c += tex2D(tex, coord.yz * scale) * abs(normal.x);
				c += tex2D(tex, coord.zx * scale) * abs(normal.y);
				return c/(abs(normal.x) + abs(normal.y) + abs(normal.z));
			}
			fixed4 triplanar(sampler2D tex, float3 coord, fixed3 normal){
				fixed4 c = 
				     tex2D(tex, coord.xy) * abs(normal.z);
				c += tex2D(tex, coord.yz) * abs(normal.x);
				c += tex2D(tex, coord.zx) * abs(normal.y);
				return c/(abs(normal.x) + abs(normal.y) + abs(normal.z));
			}

			fixed4 saturate(fixed4 col,half sat){
				return lerp(
					(col.r + col.g + col.b)/3,
					col, sat
				);
			}

			fixed4 frag (v2f i) : COLOR
			{
				fixed4 cosmos = texCUBE(_MainTex, i.texcoord);

				#ifdef ANIM_ON
				fixed3 distort = cosmos.xyz * 2 - 1;
				fixed blend = frac(_Time.x * _D1Speed);
				fixed detail1_0 = triplanar(_Detail1, i.texcoord + distort.xyz * _D1Distort * blend, i.normal, _D1Scale).r;
				fixed detail1_1 = triplanar(_Detail1, i.texcoord + distort.xyz * _D1Distort * frac(blend+0.5), i.normal, _D1Scale).r;
				fixed detail1 = lerp(detail1_0, detail1_1, abs(blend*2-1));

				blend = frac(_Time.x*_D2Speed);
				fixed detail2_0 = triplanar(_Detail2, i.texcoord + distort.xyz * _D2Distort * blend, i.normal, _D2Scale).r;
				fixed detail2_1 = triplanar(_Detail2, i.texcoord + distort.xyz * _D2Distort * frac(blend+0.5), i.normal, _D2Scale).r;
				fixed detail2 = lerp(detail2_0, detail2_1, abs(blend*2-1));
				#else
				fixed detail1 = triplanar(_Detail1, i.texcoord1, i.normal);
				fixed detail2 = triplanar(_Detail2, i.texcoord2, i.normal);
				#endif

				return fixed4(
					saturate(cosmos, _Colorize) * 
					_Color.rgb * 
					lerp(1, detail1, _D1I) *
					lerp(1, detail2, _D2I), 1);

			}
			ENDCG 
		}
	} 	
	Fallback Off
    CustomEditor "CosmosSkyEditor"
}

