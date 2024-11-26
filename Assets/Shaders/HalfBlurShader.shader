Shader "Custom/StrongHalfBlurShader"
{
  Properties
  {
      _MainTex ("Texture", 2D) = "white" {}
      _BlurSize ("Blur Size", Float) = 1.0
  }
  SubShader
  {
      Tags { "RenderType"="Opaque" }
      LOD 100

      Pass
      {
          CGPROGRAM
          #pragma vertex vert
          #pragma fragment frag
          #include "UnityCG.cginc"

          struct appdata_t
          {
              float4 vertex : POSITION;
              float2 uv : TEXCOORD0;
          };

          struct v2f
          {
              float2 uv : TEXCOORD0;
              float4 vertex : SV_POSITION;
          };

          sampler2D _MainTex;
          float4 _MainTex_ST;
          float _BlurSize;

          v2f vert (appdata_t v)
          {
              v2f o;
              o.vertex = UnityObjectToClipPos(v.vertex);
              o.uv = TRANSFORM_TEX(v.uv, _MainTex);
              return o;
          }

          float4 frag (v2f i) : SV_Target
          {
              float2 uv = i.uv;
              float4 col = tex2D(_MainTex, uv);

              // Sol yarýyý bulanýklaþtýr
              if (uv.x < 0.9)
              {
                  float4 blurCol = float4(0,0,0,0);
                  float2 offset = float2(_BlurSize/_ScreenParams.x, _BlurSize/_ScreenParams.y);

                  // Örnekleme döngülerini artýrarak bulanýklaþtýrma gücünü artýrýn
                  for (int x = -5; x <= 5; x++)
                  {
                      for (int y = -5; y <= 5; y++)
                      {
                          blurCol += tex2D(_MainTex, uv + float2(x, y) * offset);
                      }
                  }

                  col = blurCol / 121.0; // Toplam örnekleme sayýsýna bölün
              }

              return col;
          }
          ENDCG
      }
  }
}