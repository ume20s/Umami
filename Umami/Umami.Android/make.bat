msbuild Umami.Android.csproj  -t:SignAndroidPackage -p:Configuration=Release -p:AndroidKeyStore=True -p:AndroidSigningKeyStore=F:\Xamarin\Umami\Release\Version2\Umami.keystore -p:AndroidSigningStorePass=nextdays7 -p:AndroidSigningKeyAlias=Umami -p:AndroidSigningKeyPass=nextdays7
pause
