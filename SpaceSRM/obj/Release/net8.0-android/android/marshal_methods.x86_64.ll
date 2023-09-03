; ModuleID = 'marshal_methods.x86_64.ll'
source_filename = "marshal_methods.x86_64.ll"
target datalayout = "e-m:e-p270:32:32-p271:32:32-p272:64:64-i64:64-f80:128-n8:16:32:64-S128"
target triple = "x86_64-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [205 x ptr] zeroinitializer, align 16

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [410 x i64] [
	i64 98382396393917666, ; 0: Microsoft.Extensions.Primitives.dll => 0x15d8644ad360ce2 => 52
	i64 120698629574877762, ; 1: Mono.Android => 0x1accec39cafe242 => 204
	i64 131669012237370309, ; 2: Microsoft.Maui.Essentials.dll => 0x1d3c844de55c3c5 => 65
	i64 196720943101637631, ; 3: System.Linq.Expressions.dll => 0x2bae4a7cd73f3ff => 140
	i64 210515253464952879, ; 4: Xamarin.AndroidX.Collection.dll => 0x2ebe681f694702f => 85
	i64 232391251801502327, ; 5: Xamarin.AndroidX.SavedState.dll => 0x3399e9cbc897277 => 102
	i64 435118502366263740, ; 6: Xamarin.AndroidX.Security.SecurityCrypto.dll => 0x609d9f8f8bdb9bc => 103
	i64 560278790331054453, ; 7: System.Reflection.Primitives => 0x7c6829760de3975 => 163
	i64 670564002081277297, ; 8: Microsoft.Identity.Client.dll => 0x94e526837380571 => 53
	i64 750875890346172408, ; 9: System.Threading.Thread => 0xa6ba5a4da7d1ff8 => 190
	i64 799765834175365804, ; 10: System.ComponentModel.dll => 0xb1956c9f18442ac => 123
	i64 805302231655005164, ; 11: hu\Microsoft.Maui.Controls.resources.dll => 0xb2d021ceea03bec => 12
	i64 872800313462103108, ; 12: Xamarin.AndroidX.DrawerLayout => 0xc1ccf42c3c21c44 => 90
	i64 937459790420187032, ; 13: Microsoft.SqlServer.Server.dll => 0xd0286b667351798 => 67
	i64 1010599046655515943, ; 14: System.Reflection.Primitives.dll => 0xe065e7a82401d27 => 163
	i64 1060858978308751610, ; 15: Azure.Core.dll => 0xeb8ed9ebee080fa => 35
	i64 1120440138749646132, ; 16: Xamarin.Google.Android.Material.dll => 0xf8c9a5eae431534 => 108
	i64 1268860745194512059, ; 17: System.Drawing.dll => 0x119be62002c19ebb => 133
	i64 1369545283391376210, ; 18: Xamarin.AndroidX.Navigation.Fragment.dll => 0x13019a2dd85acb52 => 98
	i64 1404195534211153682, ; 19: System.IO.FileSystem.Watcher.dll => 0x137cb4660bd87f12 => 137
	i64 1476839205573959279, ; 20: System.Net.Primitives.dll => 0x147ec96ece9b1e6f => 148
	i64 1486715745332614827, ; 21: Microsoft.Maui.Controls.dll => 0x14a1e017ea87d6ab => 62
	i64 1513467482682125403, ; 22: Mono.Android.Runtime => 0x1500eaa8245f6c5b => 203
	i64 1537168428375924959, ; 23: System.Threading.Thread.dll => 0x15551e8a954ae0df => 190
	i64 1587344118459183377, ; 24: LiveChartsCore => 0x16076110cd10b111 => 40
	i64 1624659445732251991, ; 25: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0x168bf32877da9957 => 82
	i64 1628611045998245443, ; 26: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0x1699fd1e1a00b643 => 95
	i64 1731380447121279447, ; 27: Newtonsoft.Json => 0x18071957e9b889d7 => 68
	i64 1735388228521408345, ; 28: System.Net.Mail.dll => 0x181556663c69b759 => 145
	i64 1743969030606105336, ; 29: System.Memory.dll => 0x1833d297e88f2af8 => 142
	i64 1767386781656293639, ; 30: System.Private.Uri.dll => 0x188704e9f5582107 => 158
	i64 1795316252682057001, ; 31: Xamarin.AndroidX.AppCompat.dll => 0x18ea3e9eac997529 => 81
	i64 1825687700144851180, ; 32: System.Runtime.InteropServices.RuntimeInformation.dll => 0x1956254a55ef08ec => 165
	i64 1835311033149317475, ; 33: es\Microsoft.Maui.Controls.resources => 0x197855a927386163 => 6
	i64 1836611346387731153, ; 34: Xamarin.AndroidX.SavedState => 0x197cf449ebe482d1 => 102
	i64 1865037103900624886, ; 35: Microsoft.Bcl.AsyncInterfaces => 0x19e1f15d56eb87f6 => 43
	i64 1875417405349196092, ; 36: System.Drawing.Primitives => 0x1a06d2319b6c713c => 132
	i64 1881198190668717030, ; 37: tr\Microsoft.Maui.Controls.resources => 0x1a1b5bc992ea9be6 => 28
	i64 1897575647115118287, ; 38: Xamarin.AndroidX.Security.SecurityCrypto => 0x1a558aff4cba86cf => 103
	i64 1920760634179481754, ; 39: Microsoft.Maui.Controls.Xaml => 0x1aa7e99ec2d2709a => 63
	i64 1972385128188460614, ; 40: System.Security.Cryptography.Algorithms => 0x1b5f51d2edefbe46 => 175
	i64 1981742497975770890, ; 41: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x1b80904d5c241f0a => 94
	i64 2040001226662520565, ; 42: System.Threading.Tasks.Extensions.dll => 0x1c4f8a4ea894a6f5 => 188
	i64 2102659300918482391, ; 43: System.Drawing.Primitives.dll => 0x1d2e257e6aead5d7 => 132
	i64 2133195048986300728, ; 44: Newtonsoft.Json.dll => 0x1d9aa1984b735138 => 68
	i64 2165725771938924357, ; 45: Xamarin.AndroidX.Browser => 0x1e0e341d75540745 => 83
	i64 2188974421706709258, ; 46: SkiaSharp.HarfBuzz.dll => 0x1e60cca38c3e990a => 70
	i64 2262844636196693701, ; 47: Xamarin.AndroidX.DrawerLayout.dll => 0x1f673d352266e6c5 => 90
	i64 2287834202362508563, ; 48: System.Collections.Concurrent => 0x1fc00515e8ce7513 => 115
	i64 2315304989185124968, ; 49: System.IO.FileSystem.dll => 0x20219d9ee311aa68 => 138
	i64 2316229908869312383, ; 50: Microsoft.IdentityModel.Protocols.OpenIdConnect => 0x2024e6d4884a6f7f => 59
	i64 2329709569556905518, ; 51: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x2054ca829b447e2e => 93
	i64 2335503487726329082, ; 52: System.Text.Encodings.Web => 0x2069600c4d9d1cfa => 184
	i64 2470498323731680442, ; 53: Xamarin.AndroidX.CoordinatorLayout => 0x2248f922dc398cba => 86
	i64 2497223385847772520, ; 54: System.Runtime => 0x22a7eb7046413568 => 173
	i64 2547086958574651984, ; 55: Xamarin.AndroidX.Activity.dll => 0x2359121801df4a50 => 80
	i64 2554797818648757682, ; 56: System.Runtime.Caching.dll => 0x23747714858085b2 => 78
	i64 2602673633151553063, ; 57: th\Microsoft.Maui.Controls.resources => 0x241e8de13a460e27 => 27
	i64 2612152650457191105, ; 58: Microsoft.IdentityModel.Tokens.dll => 0x24403afeed9892c1 => 60
	i64 2632269733008246987, ; 59: System.Net.NameResolution => 0x2487b36034f808cb => 146
	i64 2656907746661064104, ; 60: Microsoft.Extensions.DependencyInjection => 0x24df3b84c8b75da8 => 47
	i64 2662981627730767622, ; 61: cs\Microsoft.Maui.Controls.resources => 0x24f4cfae6c48af06 => 2
	i64 2789714023057451704, ; 62: Microsoft.IdentityModel.JsonWebTokens.dll => 0x26b70e1f9943eab8 => 56
	i64 2851879596360956261, ; 63: System.Configuration.ConfigurationManager => 0x2793e9620b477965 => 75
	i64 2895129759130297543, ; 64: fi\Microsoft.Maui.Controls.resources => 0x282d912d479fa4c7 => 7
	i64 3017704767998173186, ; 65: Xamarin.Google.Android.Material => 0x29e10a7f7d88a002 => 108
	i64 3106852385031680087, ; 66: System.Runtime.Serialization.Xml => 0x2b1dc1c88b637057 => 172
	i64 3110390492489056344, ; 67: System.Security.Cryptography.Csp.dll => 0x2b2a53ac61900058 => 177
	i64 3254037935674351285, ; 68: SkiaSharp.Views.Maui.Controls.Compatibility.dll => 0x2d28aa430983deb5 => 73
	i64 3289520064315143713, ; 69: Xamarin.AndroidX.Lifecycle.Common => 0x2da6b911e3063621 => 92
	i64 3311221304742556517, ; 70: System.Numerics.Vectors.dll => 0x2df3d23ba9e2b365 => 155
	i64 3325875462027654285, ; 71: System.Runtime.Numerics => 0x2e27e21c8958b48d => 168
	i64 3328853167529574890, ; 72: System.Net.Sockets.dll => 0x2e327651a008c1ea => 152
	i64 3344514922410554693, ; 73: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x2e6a1a9a18463545 => 111
	i64 3402534845034375023, ; 74: System.IdentityModel.Tokens.Jwt.dll => 0x2f383b6a0629a76f => 76
	i64 3414639567687375782, ; 75: SkiaSharp.Views.Maui.Controls => 0x2f633c9863ffdba6 => 72
	i64 3429672777697402584, ; 76: Microsoft.Maui.Essentials => 0x2f98a5385a7b1ed8 => 65
	i64 3446944858302542142, ; 77: LiveChartsCore.dll => 0x2fd60215ff7b713e => 40
	i64 3461602852075779363, ; 78: SkiaSharp.HarfBuzz => 0x300a15741f74b523 => 70
	i64 3494946837667399002, ; 79: Microsoft.Extensions.Configuration => 0x30808ba1c00a455a => 45
	i64 3522470458906976663, ; 80: Xamarin.AndroidX.SwipeRefreshLayout => 0x30e2543832f52197 => 104
	i64 3551103847008531295, ; 81: System.Private.CoreLib.dll => 0x31480e226177735f => 201
	i64 3567343442040498961, ; 82: pt\Microsoft.Maui.Controls.resources => 0x3181bff5bea4ab11 => 22
	i64 3571415421602489686, ; 83: System.Runtime.dll => 0x319037675df7e556 => 173
	i64 3638003163729360188, ; 84: Microsoft.Extensions.Configuration.Abstractions => 0x327cc89a39d5f53c => 46
	i64 3647754201059316852, ; 85: System.Xml.ReaderWriter => 0x329f6d1e86145474 => 196
	i64 3655542548057982301, ; 86: Microsoft.Extensions.Configuration.dll => 0x32bb18945e52855d => 45
	i64 3716579019761409177, ; 87: netstandard.dll => 0x3393f0ed5c8c5c99 => 200
	i64 3727469159507183293, ; 88: Xamarin.AndroidX.RecyclerView => 0x33baa1739ba646bd => 101
	i64 3869221888984012293, ; 89: Microsoft.Extensions.Logging.dll => 0x35b23cceda0ed605 => 49
	i64 3890352374528606784, ; 90: Microsoft.Maui.Controls.Xaml.dll => 0x35fd4edf66e00240 => 63
	i64 3919223565570527920, ; 91: System.Security.Cryptography.Encoding => 0x3663e111652bd2b0 => 178
	i64 3933965368022646939, ; 92: System.Net.Requests => 0x369840a8bfadc09b => 149
	i64 3966267475168208030, ; 93: System.Memory => 0x370b03412596249e => 142
	i64 4009997192427317104, ; 94: System.Runtime.Serialization.Primitives => 0x37a65f335cf1a770 => 171
	i64 4070326265757318011, ; 95: da\Microsoft.Maui.Controls.resources.dll => 0x387cb42c56683b7b => 3
	i64 4073500526318903918, ; 96: System.Private.Xml.dll => 0x3887fb25779ae26e => 160
	i64 4073631083018132676, ; 97: Microsoft.Maui.Controls.Compatibility.dll => 0x388871e311491cc4 => 61
	i64 4120493066591692148, ; 98: zh-Hant\Microsoft.Maui.Controls.resources => 0x392eee9cdda86574 => 33
	i64 4154383907710350974, ; 99: System.ComponentModel => 0x39a7562737acb67e => 123
	i64 4167269041631776580, ; 100: System.Threading.ThreadPool => 0x39d51d1d3df1cf44 => 191
	i64 4168469861834746866, ; 101: System.Security.Claims.dll => 0x39d96140fb94ebf2 => 174
	i64 4187479170553454871, ; 102: System.Linq.Expressions => 0x3a1cea1e912fa117 => 140
	i64 4205801962323029395, ; 103: System.ComponentModel.TypeConverter => 0x3a5e0299f7e7ad93 => 122
	i64 4360412976914417659, ; 104: tr\Microsoft.Maui.Controls.resources.dll => 0x3c834c8002fcc7fb => 28
	i64 4373617458794931033, ; 105: System.IO.Pipes.dll => 0x3cb235e806eb2359 => 139
	i64 4402521634687213654, ; 106: SpaceSRM => 0x3d18e619e780e056 => 112
	i64 4477672992252076438, ; 107: System.Web.HttpUtility.dll => 0x3e23e3dcdb8ba196 => 194
	i64 4672453897036726049, ; 108: System.IO.FileSystem.Watcher => 0x40d7e4104a437f21 => 137
	i64 4716677666592453464, ; 109: System.Xml.XmlSerializer => 0x417501590542f358 => 198
	i64 4743821336939966868, ; 110: System.ComponentModel.Annotations => 0x41d5705f4239b194 => 120
	i64 4794310189461587505, ; 111: Xamarin.AndroidX.Activity => 0x4288cfb749e4c631 => 80
	i64 4795410492532947900, ; 112: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0x428cb86f8f9b7bbc => 104
	i64 4809057822547766521, ; 113: System.Drawing => 0x42bd349c3145ecf9 => 133
	i64 4814660307502931973, ; 114: System.Net.NameResolution.dll => 0x42d11c0a5ee2a005 => 146
	i64 4853321196694829351, ; 115: System.Runtime.Loader.dll => 0x435a75ea15de7927 => 167
	i64 4871824391508510238, ; 116: nb\Microsoft.Maui.Controls.resources.dll => 0x439c3278d7f2c61e => 18
	i64 4953714692329509532, ; 117: sv\Microsoft.Maui.Controls.resources.dll => 0x44bf21444aef129c => 26
	i64 5103417709280584325, ; 118: System.Collections.Specialized => 0x46d2fb5e161b6285 => 118
	i64 5182934613077526976, ; 119: System.Collections.Specialized.dll => 0x47ed7b91fa9009c0 => 118
	i64 5278787618751394462, ; 120: System.Net.WebClient.dll => 0x4942055efc68329e => 153
	i64 5290786973231294105, ; 121: System.Runtime.Loader => 0x496ca6b869b72699 => 167
	i64 5423376490970181369, ; 122: System.Runtime.InteropServices.RuntimeInformation => 0x4b43b42f2b7b6ef9 => 165
	i64 5446034149219586269, ; 123: System.Diagnostics.Debug => 0x4b94333452e150dd => 126
	i64 5471532531798518949, ; 124: sv\Microsoft.Maui.Controls.resources => 0x4beec9d926d82ca5 => 26
	i64 5522859530602327440, ; 125: uk\Microsoft.Maui.Controls.resources => 0x4ca5237b51eead90 => 29
	i64 5570799893513421663, ; 126: System.IO.Compression.Brotli => 0x4d4f74fcdfa6c35f => 135
	i64 5573260873512690141, ; 127: System.Security.Cryptography.dll => 0x4d58333c6e4ea1dd => 181
	i64 5650097808083101034, ; 128: System.Security.Cryptography.Algorithms.dll => 0x4e692e055d01a56a => 175
	i64 5692067934154308417, ; 129: Xamarin.AndroidX.ViewPager2.dll => 0x4efe49a0d4a8bb41 => 106
	i64 5979151488806146654, ; 130: System.Formats.Asn1 => 0x52fa3699a489d25e => 134
	i64 5984759512290286505, ; 131: System.Security.Cryptography.Primitives => 0x530e23115c33dba9 => 179
	i64 6200764641006662125, ; 132: ro\Microsoft.Maui.Controls.resources => 0x560d8a96830131ed => 23
	i64 6222399776351216807, ; 133: System.Text.Json.dll => 0x565a67a0ffe264a7 => 185
	i64 6251069312384999852, ; 134: System.Transactions.Local => 0x56c0426b870da1ac => 193
	i64 6278736998281604212, ; 135: System.Private.DataContractSerialization => 0x57228e08a4ad6c74 => 157
	i64 6284145129771520194, ; 136: System.Reflection.Emit.ILGeneration => 0x5735c4b3610850c2 => 161
	i64 6300676701234028427, ; 137: es\Microsoft.Maui.Controls.resources.dll => 0x57708013cda25f8b => 6
	i64 6357457916754632952, ; 138: _Microsoft.Android.Resource.Designer => 0x583a3a4ac2a7a0f8 => 34
	i64 6401687960814735282, ; 139: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0x58d75d486341cfb2 => 93
	i64 6471714727257221498, ; 140: fi\Microsoft.Maui.Controls.resources.dll => 0x59d026417dd4a97a => 7
	i64 6478287442656530074, ; 141: hr\Microsoft.Maui.Controls.resources => 0x59e7801b0c6a8e9a => 11
	i64 6504860066809920875, ; 142: Xamarin.AndroidX.Browser.dll => 0x5a45e7c43bd43d6b => 83
	i64 6548213210057960872, ; 143: Xamarin.AndroidX.CustomView.dll => 0x5adfed387b066da8 => 89
	i64 6557084851308642443, ; 144: Xamarin.AndroidX.Window.dll => 0x5aff71ee6c58c08b => 107
	i64 6560151584539558821, ; 145: Microsoft.Extensions.Options => 0x5b0a571be53243a5 => 51
	i64 6617685658146568858, ; 146: System.Text.Encoding.CodePages => 0x5bd6be0b4905fa9a => 182
	i64 6671798237668743565, ; 147: SkiaSharp => 0x5c96fd260152998d => 69
	i64 6743165466166707109, ; 148: nl\Microsoft.Maui.Controls.resources => 0x5d948943c08c43a5 => 19
	i64 6786606130239981554, ; 149: System.Diagnostics.TraceSource => 0x5e2ede51877147f2 => 130
	i64 6814185388980153342, ; 150: System.Xml.XDocument.dll => 0x5e90d98217d1abfe => 197
	i64 6876862101832370452, ; 151: System.Xml.Linq => 0x5f6f85a57d108914 => 195
	i64 6894844156784520562, ; 152: System.Numerics.Vectors => 0x5faf683aead1ad72 => 155
	i64 7083547580668757502, ; 153: System.Private.Xml.Linq.dll => 0x624dd0fe8f56c5fe => 159
	i64 7112547816752919026, ; 154: System.IO.FileSystem => 0x62b4d88e3189b1f2 => 138
	i64 7234284632499269838, ; 155: LiveChartsCore.SkiaSharpView => 0x6465578b5c2fb0ce => 41
	i64 7270811800166795866, ; 156: System.Linq => 0x64e71ccf51a90a5a => 141
	i64 7314237870106916923, ; 157: SkiaSharp.Views.Maui.Core.dll => 0x65816497226eb83b => 74
	i64 7316205155833392065, ; 158: Microsoft.Win32.Primitives => 0x658861d38954abc1 => 114
	i64 7348123982286201829, ; 159: System.Memory.Data.dll => 0x65f9c7d471b2a3e5 => 77
	i64 7377312882064240630, ; 160: System.ComponentModel.TypeConverter.dll => 0x66617afac45a2ff6 => 122
	i64 7488575175965059935, ; 161: System.Xml.Linq.dll => 0x67ecc3724534ab5f => 195
	i64 7489048572193775167, ; 162: System.ObjectModel => 0x67ee71ff6b419e3f => 156
	i64 7496222613193209122, ; 163: System.IdentityModel.Tokens.Jwt => 0x6807eec000a1b522 => 76
	i64 7592577537120840276, ; 164: System.Diagnostics.Process => 0x695e410af5b2aa54 => 128
	i64 7654504624184590948, ; 165: System.Net.Http => 0x6a3a4366801b8264 => 144
	i64 7694700312542370399, ; 166: System.Net.Mail => 0x6ac9112a7e2cda5f => 145
	i64 7714652370974252055, ; 167: System.Private.CoreLib => 0x6b0ff375198b9c17 => 201
	i64 7723873813026311384, ; 168: SkiaSharp.Views.Maui.Controls.dll => 0x6b30b64f63600cd8 => 72
	i64 7735176074855944702, ; 169: Microsoft.CSharp => 0x6b58dda848e391fe => 113
	i64 7735352534559001595, ; 170: Xamarin.Kotlin.StdLib.dll => 0x6b597e2582ce8bfb => 110
	i64 7742555799473854801, ; 171: it\Microsoft.Maui.Controls.resources.dll => 0x6b73157a51479951 => 14
	i64 7836164640616011524, ; 172: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x6cbfa6390d64d704 => 82
	i64 7927939710195668715, ; 173: SkiaSharp.Views.Android.dll => 0x6e05b32992ed16eb => 71
	i64 7975724199463739455, ; 174: sk\Microsoft.Maui.Controls.resources.dll => 0x6eaf76e6f785e03f => 25
	i64 8064050204834738623, ; 175: System.Collections.dll => 0x6fe942efa61731bf => 119
	i64 8083354569033831015, ; 176: Xamarin.AndroidX.Lifecycle.Common.dll => 0x702dd82730cad267 => 92
	i64 8085230611270010360, ; 177: System.Net.Http.Json.dll => 0x703482674fdd05f8 => 143
	i64 8087206902342787202, ; 178: System.Diagnostics.DiagnosticSource => 0x703b87d46f3aa082 => 127
	i64 8108129031893776750, ; 179: ko\Microsoft.Maui.Controls.resources.dll => 0x7085dc65530f796e => 16
	i64 8167236081217502503, ; 180: Java.Interop.dll => 0x7157d9f1a9b8fd27 => 202
	i64 8185542183669246576, ; 181: System.Collections => 0x7198e33f4794aa70 => 119
	i64 8234598844743906698, ; 182: Microsoft.Identity.Client.Extensions.Msal.dll => 0x72472c0540cd758a => 54
	i64 8246048515196606205, ; 183: Microsoft.Maui.Graphics.dll => 0x726fd96f64ee56fd => 66
	i64 8264926008854159966, ; 184: System.Diagnostics.Process.dll => 0x72b2ea6a64a3a25e => 128
	i64 8290740647658429042, ; 185: System.Runtime.Extensions => 0x730ea0b15c929a72 => 164
	i64 8368701292315763008, ; 186: System.Security.Cryptography => 0x7423997c6fd56140 => 181
	i64 8386351099740279196, ; 187: zh-HK\Microsoft.Maui.Controls.resources.dll => 0x74624de475b9d19c => 31
	i64 8400357532724379117, ; 188: Xamarin.AndroidX.Navigation.UI.dll => 0x749410ab44503ded => 100
	i64 8410671156615598628, ; 189: System.Reflection.Emit.Lightweight.dll => 0x74b8b4daf4b25224 => 162
	i64 8513291706828295435, ; 190: Microsoft.SqlServer.Server => 0x762549b3b6c78d0b => 67
	i64 8518412311883997971, ; 191: System.Collections.Immutable => 0x76377add7c28e313 => 116
	i64 8563666267364444763, ; 192: System.Private.Uri => 0x76d841191140ca5b => 158
	i64 8599632406834268464, ; 193: CommunityToolkit.Maui => 0x7758081c784b4930 => 37
	i64 8626175481042262068, ; 194: Java.Interop => 0x77b654e585b55834 => 202
	i64 8638972117149407195, ; 195: Microsoft.CSharp.dll => 0x77e3cb5e8b31d7db => 113
	i64 8639588376636138208, ; 196: Xamarin.AndroidX.Navigation.Runtime => 0x77e5fbdaa2fda2e0 => 99
	i64 8677882282824630478, ; 197: pt-BR\Microsoft.Maui.Controls.resources => 0x786e07f5766b00ce => 21
	i64 8725526185868997716, ; 198: System.Diagnostics.DiagnosticSource.dll => 0x79174bd613173454 => 127
	i64 8835398868208121913, ; 199: SpaceSRM.dll => 0x7a9da4756c6ef839 => 112
	i64 8941376889969657626, ; 200: System.Xml.XDocument => 0x7c1626e87187471a => 197
	i64 8954753533646919997, ; 201: System.Runtime.Serialization.Json => 0x7c45ace50032d93d => 170
	i64 8955323522379913726, ; 202: Microsoft.Identity.Client => 0x7c47b34bd82799fe => 53
	i64 9045785047181495996, ; 203: zh-HK\Microsoft.Maui.Controls.resources => 0x7d891592e3cb0ebc => 31
	i64 9052662452269567435, ; 204: Microsoft.IdentityModel.Protocols => 0x7da184898b0b4dcb => 58
	i64 9138683372487561558, ; 205: System.Security.Cryptography.Csp => 0x7ed3201bc3e3d156 => 177
	i64 9312692141327339315, ; 206: Xamarin.AndroidX.ViewPager2 => 0x813d54296a634f33 => 106
	i64 9324707631942237306, ; 207: Xamarin.AndroidX.AppCompat => 0x8168042fd44a7c7a => 81
	i64 9363564275759486853, ; 208: el\Microsoft.Maui.Controls.resources.dll => 0x81f21019382e9785 => 5
	i64 9427266486299436557, ; 209: Microsoft.IdentityModel.Logging.dll => 0x82d460ebe6d2a60d => 57
	i64 9551379474083066910, ; 210: uk\Microsoft.Maui.Controls.resources.dll => 0x848d5106bbadb41e => 29
	i64 9575902398040817096, ; 211: Xamarin.Google.Crypto.Tink.Android.dll => 0x84e4707ee708bdc8 => 109
	i64 9659729154652888475, ; 212: System.Text.RegularExpressions => 0x860e407c9991dd9b => 186
	i64 9667360217193089419, ; 213: System.Diagnostics.StackTrace => 0x86295ce5cd89898b => 129
	i64 9678050649315576968, ; 214: Xamarin.AndroidX.CoordinatorLayout.dll => 0x864f57c9feb18c88 => 86
	i64 9702891218465930390, ; 215: System.Collections.NonGeneric.dll => 0x86a79827b2eb3c96 => 117
	i64 9773637193738963987, ; 216: ca\Microsoft.Maui.Controls.resources.dll => 0x87a2ef3ea85b4c13 => 1
	i64 9808709177481450983, ; 217: Mono.Android.dll => 0x881f890734e555e7 => 204
	i64 9819168441846169364, ; 218: Microsoft.IdentityModel.Protocols.dll => 0x8844b1ac75f77f14 => 58
	i64 9956195530459977388, ; 219: Microsoft.Maui => 0x8a2b8315b36616ac => 64
	i64 10038780035334861115, ; 220: System.Net.Http.dll => 0x8b50e941206af13b => 144
	i64 10051358222726253779, ; 221: System.Private.Xml => 0x8b7d990c97ccccd3 => 160
	i64 10092835686693276772, ; 222: Microsoft.Maui.Controls => 0x8c10f49539bd0c64 => 62
	i64 10143853363526200146, ; 223: da\Microsoft.Maui.Controls.resources => 0x8cc634e3c2a16b52 => 3
	i64 10209869394718195525, ; 224: nl\Microsoft.Maui.Controls.resources.dll => 0x8db0be1ecb4f7f45 => 19
	i64 10229024438826829339, ; 225: Xamarin.AndroidX.CustomView => 0x8df4cb880b10061b => 89
	i64 10236703004850800690, ; 226: System.Net.ServicePoint.dll => 0x8e101325834e4832 => 151
	i64 10245369515835430794, ; 227: System.Reflection.Emit.Lightweight => 0x8e2edd4ad7fc978a => 162
	i64 10364469296367737616, ; 228: System.Reflection.Emit.ILGeneration.dll => 0x8fd5fde967711b10 => 161
	i64 10406448008575299332, ; 229: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x906b2153fcb3af04 => 111
	i64 10430153318873392755, ; 230: Xamarin.AndroidX.Core => 0x90bf592ea44f6673 => 87
	i64 10447083246144586668, ; 231: Microsoft.Bcl.AsyncInterfaces.dll => 0x90fb7edc816203ac => 43
	i64 10506226065143327199, ; 232: ca\Microsoft.Maui.Controls.resources => 0x91cd9cf11ed169df => 1
	i64 10546663366131771576, ; 233: System.Runtime.Serialization.Json.dll => 0x925d4673efe8e8b8 => 170
	i64 10670374202010151210, ; 234: Microsoft.Win32.Primitives.dll => 0x9414c8cd7b4ea92a => 114
	i64 10714184849103829812, ; 235: System.Runtime.Extensions.dll => 0x94b06e5aa4b4bb34 => 164
	i64 10761706286639228993, ; 236: zh-Hant\Microsoft.Maui.Controls.resources.dll => 0x955942d988382841 => 33
	i64 10773380159644291260, ; 237: LiveChartsCore.SkiaSharpView.Maui.dll => 0x9582bc2ce5d6d0bc => 42
	i64 10785150219063592792, ; 238: System.Net.Primitives => 0x95ac8cfb68830758 => 148
	i64 10880838204485145808, ; 239: CommunityToolkit.Maui.dll => 0x970080b2a4d614d0 => 37
	i64 10889380495983713167, ; 240: Microsoft.Data.SqlClient.dll => 0x971ed9dddf2d1b8f => 44
	i64 10964653383833615866, ; 241: System.Diagnostics.Tracing => 0x982a4628ccaffdfa => 131
	i64 11002576679268595294, ; 242: Microsoft.Extensions.Logging.Abstractions => 0x98b1013215cd365e => 50
	i64 11009005086950030778, ; 243: Microsoft.Maui.dll => 0x98c7d7cc621ffdba => 64
	i64 11103970607964515343, ; 244: hu\Microsoft.Maui.Controls.resources => 0x9a193a6fc41a6c0f => 12
	i64 11156122287428000958, ; 245: th\Microsoft.Maui.Controls.resources.dll => 0x9ad2821cdcf6dcbe => 27
	i64 11157797727133427779, ; 246: fr\Microsoft.Maui.Controls.resources.dll => 0x9ad875ea9172e843 => 8
	i64 11162124722117608902, ; 247: Xamarin.AndroidX.ViewPager => 0x9ae7d54b986d05c6 => 105
	i64 11220793807500858938, ; 248: ja\Microsoft.Maui.Controls.resources => 0x9bb8448481fdd63a => 15
	i64 11226290749488709958, ; 249: Microsoft.Extensions.Options.dll => 0x9bcbcbf50c874146 => 51
	i64 11340910727871153756, ; 250: Xamarin.AndroidX.CursorAdapter => 0x9d630238642d465c => 88
	i64 11341245327015630248, ; 251: System.Configuration.ConfigurationManager.dll => 0x9d643289535355a8 => 75
	i64 11347436699239206956, ; 252: System.Xml.XmlSerializer.dll => 0x9d7a318e8162502c => 198
	i64 11485890710487134646, ; 253: System.Runtime.InteropServices => 0x9f6614bf0f8b71b6 => 166
	i64 11517440453979132662, ; 254: Microsoft.IdentityModel.Abstractions.dll => 0x9fd62b122523d2f6 => 55
	i64 11518296021396496455, ; 255: id\Microsoft.Maui.Controls.resources => 0x9fd9353475222047 => 13
	i64 11529969570048099689, ; 256: Xamarin.AndroidX.ViewPager.dll => 0xa002ae3c4dc7c569 => 105
	i64 11530571088791430846, ; 257: Microsoft.Extensions.Logging => 0xa004d1504ccd66be => 49
	i64 11575476872818742106, ; 258: LiveChartsCore.SkiaSharpView.dll => 0xa0a45ae2e61c535a => 41
	i64 11597940890313164233, ; 259: netstandard => 0xa0f429ca8d1805c9 => 200
	i64 11743665907891708234, ; 260: System.Threading.Tasks => 0xa2f9e1ec30c0214a => 189
	i64 11819001862053230205, ; 261: LiveChartsCore.SkiaSharpView.Maui => 0xa4058792e35cf67d => 42
	i64 11855031688536399763, ; 262: vi\Microsoft.Maui.Controls.resources.dll => 0xa485888294361f93 => 30
	i64 12011556116648931059, ; 263: System.Security.Cryptography.ProtectedData => 0xa6b19ea5ec87aef3 => 79
	i64 12040886584167504988, ; 264: System.Net.ServicePoint => 0xa719d28d8e121c5c => 151
	i64 12145679461940342714, ; 265: System.Text.Json => 0xa88e1f1ebcb62fba => 185
	i64 12198439281774268251, ; 266: Microsoft.IdentityModel.Protocols.OpenIdConnect.dll => 0xa9498fe58c538f5b => 59
	i64 12201331334810686224, ; 267: System.Runtime.Serialization.Primitives.dll => 0xa953d6341e3bd310 => 171
	i64 12269460666702402136, ; 268: System.Collections.Immutable.dll => 0xaa45e178506c9258 => 116
	i64 12341818387765915815, ; 269: CommunityToolkit.Maui.Core.dll => 0xab46f26f152bf0a7 => 38
	i64 12439275739440478309, ; 270: Microsoft.IdentityModel.JsonWebTokens => 0xaca12f61007bf865 => 56
	i64 12451044538927396471, ; 271: Xamarin.AndroidX.Fragment.dll => 0xaccaff0a2955b677 => 91
	i64 12466513435562512481, ; 272: Xamarin.AndroidX.Loader.dll => 0xad01f3eb52569061 => 96
	i64 12475113361194491050, ; 273: _Microsoft.Android.Resource.Designer.dll => 0xad2081818aba1caa => 34
	i64 12493213219680520345, ; 274: Microsoft.Data.SqlClient => 0xad60cf3b3e458899 => 44
	i64 12517810545449516888, ; 275: System.Diagnostics.TraceSource.dll => 0xadb8325e6f283f58 => 130
	i64 12538491095302438457, ; 276: Xamarin.AndroidX.CardView.dll => 0xae01ab382ae67e39 => 84
	i64 12550732019250633519, ; 277: System.IO.Compression => 0xae2d28465e8e1b2f => 136
	i64 12699999919562409296, ; 278: System.Diagnostics.StackTrace.dll => 0xb03f76a3ad01c550 => 129
	i64 12700543734426720211, ; 279: Xamarin.AndroidX.Collection => 0xb041653c70d157d3 => 85
	i64 12708922737231849740, ; 280: System.Text.Encoding.Extensions => 0xb05f29e50e96e90c => 183
	i64 12717050818822477433, ; 281: System.Runtime.Serialization.Xml.dll => 0xb07c0a5786811679 => 172
	i64 12753841065332862057, ; 282: Xamarin.AndroidX.Window => 0xb0febee04cf46c69 => 107
	i64 12835242264250840079, ; 283: System.IO.Pipes => 0xb21ff0d5d6c0740f => 139
	i64 12843321153144804894, ; 284: Microsoft.Extensions.Primitives => 0xb23ca48abd74d61e => 52
	i64 12859557719246324186, ; 285: System.Net.WebHeaderCollection.dll => 0xb276539ce04f41da => 154
	i64 12989346753972519995, ; 286: ar\Microsoft.Maui.Controls.resources.dll => 0xb4436e0d5ee7c43b => 0
	i64 13005833372463390146, ; 287: pt-BR\Microsoft.Maui.Controls.resources.dll => 0xb47e008b5d99ddc2 => 21
	i64 13068258254871114833, ; 288: System.Runtime.Serialization.Formatters.dll => 0xb55bc7a4eaa8b451 => 169
	i64 13106026140046202731, ; 289: HarfBuzzSharp.dll => 0xb5e1f555ee70176b => 39
	i64 13343850469010654401, ; 290: Mono.Android.Runtime.dll => 0xb92ee14d854f44c1 => 203
	i64 13381594904270902445, ; 291: he\Microsoft.Maui.Controls.resources => 0xb9b4f9aaad3e94ad => 9
	i64 13431476299110033919, ; 292: System.Net.WebClient => 0xba663087f18829ff => 153
	i64 13463706743370286408, ; 293: System.Private.DataContractSerialization.dll => 0xbad8b1f3069e0548 => 157
	i64 13465488254036897740, ; 294: Xamarin.Kotlin.StdLib => 0xbadf06394d106fcc => 110
	i64 13540124433173649601, ; 295: vi\Microsoft.Maui.Controls.resources => 0xbbe82f6eede718c1 => 30
	i64 13572454107664307259, ; 296: Xamarin.AndroidX.RecyclerView.dll => 0xbc5b0b19d99f543b => 101
	i64 13717397318615465333, ; 297: System.ComponentModel.Primitives.dll => 0xbe5dfc2ef2f87d75 => 121
	i64 13742054908850494594, ; 298: Azure.Identity => 0xbeb596218df25c82 => 36
	i64 13881769479078963060, ; 299: System.Console.dll => 0xc0a5f3cade5c6774 => 124
	i64 13959074834287824816, ; 300: Xamarin.AndroidX.Fragment => 0xc1b8989a7ad20fb0 => 91
	i64 14124974489674258913, ; 301: Xamarin.AndroidX.CardView => 0xc405fd76067d19e1 => 84
	i64 14125464355221830302, ; 302: System.Threading.dll => 0xc407bafdbc707a9e => 192
	i64 14212104595480609394, ; 303: System.Security.Cryptography.Cng.dll => 0xc53b89d4a4518272 => 176
	i64 14254574811015963973, ; 304: System.Text.Encoding.Extensions.dll => 0xc5d26c4442d66545 => 183
	i64 14327709162229390963, ; 305: System.Security.Cryptography.X509Certificates => 0xc6d63f9253cade73 => 180
	i64 14349907877893689639, ; 306: ro\Microsoft.Maui.Controls.resources.dll => 0xc7251d2f956ed127 => 23
	i64 14461014870687870182, ; 307: System.Net.Requests.dll => 0xc8afd8683afdece6 => 149
	i64 14464374589798375073, ; 308: ru\Microsoft.Maui.Controls.resources => 0xc8bbc80dcb1e5ea1 => 24
	i64 14491877563792607819, ; 309: zh-Hans\Microsoft.Maui.Controls.resources.dll => 0xc91d7ddcee4fca4b => 32
	i64 14551742072151931844, ; 310: System.Text.Encodings.Web.dll => 0xc9f22c50f1b8fbc4 => 184
	i64 14552901170081803662, ; 311: SkiaSharp.Views.Maui.Core => 0xc9f64a827617ad8e => 74
	i64 14556034074661724008, ; 312: CommunityToolkit.Maui.Core => 0xca016bdea6b19f68 => 38
	i64 14561513370130550166, ; 313: System.Security.Cryptography.Primitives.dll => 0xca14e3428abb8d96 => 179
	i64 14610046442689856844, ; 314: cs\Microsoft.Maui.Controls.resources.dll => 0xcac14fd5107d054c => 2
	i64 14622043554576106986, ; 315: System.Runtime.Serialization.Formatters => 0xcaebef2458cc85ea => 169
	i64 14648804764802849406, ; 316: Azure.Identity.dll => 0xcb4b0252261f9a7e => 36
	i64 14669215534098758659, ; 317: Microsoft.Extensions.DependencyInjection.dll => 0xcb9385ceb3993c03 => 47
	i64 14690985099581930927, ; 318: System.Web.HttpUtility => 0xcbe0dd1ca5233daf => 194
	i64 14705122255218365489, ; 319: ko\Microsoft.Maui.Controls.resources => 0xcc1316c7b0fb5431 => 16
	i64 14735017007120366644, ; 320: ja\Microsoft.Maui.Controls.resources.dll => 0xcc7d4be604bfbc34 => 15
	i64 14744092281598614090, ; 321: zh-Hans\Microsoft.Maui.Controls.resources => 0xcc9d89d004439a4a => 32
	i64 14832630590065248058, ; 322: System.Security.Claims => 0xcdd816ef5d6e873a => 174
	i64 14852515768018889994, ; 323: Xamarin.AndroidX.CursorAdapter.dll => 0xce1ebc6625a76d0a => 88
	i64 14904040806490515477, ; 324: ar\Microsoft.Maui.Controls.resources => 0xced5ca2604cb2815 => 0
	i64 14931407803744742450, ; 325: HarfBuzzSharp => 0xcf3704499ab36c32 => 39
	i64 14935719434541007538, ; 326: System.Text.Encoding.CodePages.dll => 0xcf4655b160b702b2 => 182
	i64 14954917835170835695, ; 327: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xcf8a8a895a82ecef => 48
	i64 14984936317414011727, ; 328: System.Net.WebHeaderCollection => 0xcff5302fe54ff34f => 154
	i64 14987728460634540364, ; 329: System.IO.Compression.dll => 0xcfff1ba06622494c => 136
	i64 15015154896917945444, ; 330: System.Net.Security.dll => 0xd0608bd33642dc64 => 150
	i64 15024878362326791334, ; 331: System.Net.Http.Json => 0xd0831743ebf0f4a6 => 143
	i64 15076659072870671916, ; 332: System.ObjectModel.dll => 0xd13b0d8c1620662c => 156
	i64 15111608613780139878, ; 333: ms\Microsoft.Maui.Controls.resources => 0xd1b737f831192f66 => 17
	i64 15115185479366240210, ; 334: System.IO.Compression.Brotli.dll => 0xd1c3ed1c1bc467d2 => 135
	i64 15133485256822086103, ; 335: System.Linq.dll => 0xd204f0a9127dd9d7 => 141
	i64 15138356091203993725, ; 336: Microsoft.IdentityModel.Abstractions => 0xd2163ea89395c07d => 55
	i64 15203009853192377507, ; 337: pt\Microsoft.Maui.Controls.resources.dll => 0xd2fbf0e9984b94a3 => 22
	i64 15227001540531775957, ; 338: Microsoft.Extensions.Configuration.Abstractions.dll => 0xd3512d3999b8e9d5 => 46
	i64 15370334346939861994, ; 339: Xamarin.AndroidX.Core.dll => 0xd54e65a72c560bea => 87
	i64 15383240894167415497, ; 340: System.Memory.Data => 0xd57c4016df1c7ac9 => 77
	i64 15391712275433856905, ; 341: Microsoft.Extensions.DependencyInjection.Abstractions => 0xd59a58c406411f89 => 48
	i64 15527772828719725935, ; 342: System.Console => 0xd77dbb1e38cd3d6f => 124
	i64 15536481058354060254, ; 343: de\Microsoft.Maui.Controls.resources => 0xd79cab34eec75bde => 4
	i64 15541854775306130054, ; 344: System.Security.Cryptography.X509Certificates.dll => 0xd7afc292e8d49286 => 180
	i64 15557562860424774966, ; 345: System.Net.Sockets => 0xd7e790fe7a6dc536 => 152
	i64 15582737692548360875, ; 346: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xd841015ed86f6aab => 95
	i64 15609085926864131306, ; 347: System.dll => 0xd89e9cf3334914ea => 199
	i64 15661133872274321916, ; 348: System.Xml.ReaderWriter.dll => 0xd9578647d4bfb1fc => 196
	i64 15783653065526199428, ; 349: el\Microsoft.Maui.Controls.resources => 0xdb0accd674b1c484 => 5
	i64 15817206913877585035, ; 350: System.Threading.Tasks.dll => 0xdb8201e29086ac8b => 189
	i64 15847085070278954535, ; 351: System.Threading.Channels.dll => 0xdbec27e8f35f8e27 => 187
	i64 15928521404965645318, ; 352: Microsoft.Maui.Controls.Compatibility => 0xdd0d79d32c2eec06 => 61
	i64 15937190497610202713, ; 353: System.Security.Cryptography.Cng => 0xdd2c465197c97e59 => 176
	i64 15963349826457351533, ; 354: System.Threading.Tasks.Extensions => 0xdd893616f748b56d => 188
	i64 16018552496348375205, ; 355: System.Net.NetworkInformation.dll => 0xde4d54a020caa8a5 => 147
	i64 16056281320585338352, ; 356: ru\Microsoft.Maui.Controls.resources.dll => 0xded35eca8f3a9df0 => 24
	i64 16154507427712707110, ; 357: System => 0xe03056ea4e39aa26 => 199
	i64 16219561732052121626, ; 358: System.Net.Security => 0xe1177575db7c781a => 150
	i64 16288847719894691167, ; 359: nb\Microsoft.Maui.Controls.resources => 0xe20d9cb300c12d5f => 18
	i64 16321164108206115771, ; 360: Microsoft.Extensions.Logging.Abstractions.dll => 0xe2806c487e7b0bbb => 50
	i64 16324796876805858114, ; 361: SkiaSharp.dll => 0xe28d5444586b6342 => 69
	i64 16454459195343277943, ; 362: System.Net.NetworkInformation => 0xe459fb756d988f77 => 147
	i64 16649148416072044166, ; 363: Microsoft.Maui.Graphics => 0xe70da84600bb4e86 => 66
	i64 16677317093839702854, ; 364: Xamarin.AndroidX.Navigation.UI => 0xe771bb8960dd8b46 => 100
	i64 16803648858859583026, ; 365: ms\Microsoft.Maui.Controls.resources.dll => 0xe9328d9b8ab93632 => 17
	i64 16856067890322379635, ; 366: System.Data.Common.dll => 0xe9ecc87060889373 => 125
	i64 16890310621557459193, ; 367: System.Text.RegularExpressions.dll => 0xea66700587f088f9 => 186
	i64 16942731696432749159, ; 368: sk\Microsoft.Maui.Controls.resources => 0xeb20acb622a01a67 => 25
	i64 16945858842201062480, ; 369: Azure.Core => 0xeb2bc8d57f4e7c50 => 35
	i64 16998075588627545693, ; 370: Xamarin.AndroidX.Navigation.Fragment => 0xebe54bb02d623e5d => 98
	i64 17008137082415910100, ; 371: System.Collections.NonGeneric => 0xec090a90408c8cd4 => 117
	i64 17031351772568316411, ; 372: Xamarin.AndroidX.Navigation.Common.dll => 0xec5b843380a769fb => 97
	i64 17062143951396181894, ; 373: System.ComponentModel.Primitives => 0xecc8e986518c9786 => 121
	i64 17118171214553292978, ; 374: System.Threading.Channels => 0xed8ff6060fc420b2 => 187
	i64 17137864900836977098, ; 375: Microsoft.IdentityModel.Tokens => 0xedd5ed53b705e9ca => 60
	i64 17187273293601214786, ; 376: System.ComponentModel.Annotations.dll => 0xee8575ff9aa89142 => 120
	i64 17197986060146327831, ; 377: Microsoft.Identity.Client.Extensions.Msal => 0xeeab8533ef244117 => 54
	i64 17202182880784296190, ; 378: System.Security.Cryptography.Encoding.dll => 0xeeba6e30627428fe => 178
	i64 17203614576212522419, ; 379: pl\Microsoft.Maui.Controls.resources.dll => 0xeebf844ef3e135b3 => 20
	i64 17230721278011714856, ; 380: System.Private.Xml.Linq => 0xef1fd1b5c7a72d28 => 159
	i64 17234219099804750107, ; 381: System.Transactions.Local.dll => 0xef2c3ef5e11d511b => 193
	i64 17260702271250283638, ; 382: System.Data.Common => 0xef8a5543bba6bc76 => 125
	i64 17310278548634113468, ; 383: hi\Microsoft.Maui.Controls.resources.dll => 0xf03a76a04e6695bc => 10
	i64 17333249706306540043, ; 384: System.Diagnostics.Tracing.dll => 0xf08c12c5bb8b920b => 131
	i64 17342750010158924305, ; 385: hi\Microsoft.Maui.Controls.resources => 0xf0add33f97ecc211 => 10
	i64 17360349973592121190, ; 386: Xamarin.Google.Crypto.Tink.Android => 0xf0ec5a52686b9f66 => 109
	i64 17371436720558481852, ; 387: System.Runtime.Caching => 0xf113bda8d710a1bc => 78
	i64 17514990004910432069, ; 388: fr\Microsoft.Maui.Controls.resources => 0xf311be9c6f341f45 => 8
	i64 17523946658117960076, ; 389: System.Security.Cryptography.ProtectedData.dll => 0xf33190a3c403c18c => 79
	i64 17623389608345532001, ; 390: pl\Microsoft.Maui.Controls.resources => 0xf492db79dfbef661 => 20
	i64 17671790519499593115, ; 391: SkiaSharp.Views.Android => 0xf53ecfd92be3959b => 71
	i64 17685921127322830888, ; 392: System.Diagnostics.Debug.dll => 0xf571038fafa74828 => 126
	i64 17704177640604968747, ; 393: Xamarin.AndroidX.Loader => 0xf5b1dfc36cac272b => 96
	i64 17710060891934109755, ; 394: Xamarin.AndroidX.Lifecycle.ViewModel => 0xf5c6c68c9e45303b => 94
	i64 17712670374920797664, ; 395: System.Runtime.InteropServices.dll => 0xf5d00bdc38bd3de0 => 166
	i64 17777860260071588075, ; 396: System.Runtime.Numerics.dll => 0xf6b7a5b72419c0eb => 168
	i64 17790600151040787804, ; 397: Microsoft.IdentityModel.Logging => 0xf6e4e89427cc055c => 57
	i64 17827813215687577648, ; 398: hr\Microsoft.Maui.Controls.resources.dll => 0xf7691da9f3129030 => 11
	i64 17942426894774770628, ; 399: de\Microsoft.Maui.Controls.resources.dll => 0xf9004e329f771bc4 => 4
	i64 18025913125965088385, ; 400: System.Threading => 0xfa28e87b91334681 => 192
	i64 18121036031235206392, ; 401: Xamarin.AndroidX.Navigation.Common => 0xfb7ada42d3d42cf8 => 97
	i64 18132221390331549284, ; 402: SkiaSharp.Views.Maui.Controls.Compatibility => 0xfba297492f739664 => 73
	i64 18146411883821974900, ; 403: System.Formats.Asn1.dll => 0xfbd50176eb22c574 => 134
	i64 18225059387460068507, ; 404: System.Threading.ThreadPool.dll => 0xfcec6af3cff4a49b => 191
	i64 18245806341561545090, ; 405: System.Collections.Concurrent.dll => 0xfd3620327d587182 => 115
	i64 18305135509493619199, ; 406: Xamarin.AndroidX.Navigation.Runtime.dll => 0xfe08e7c2d8c199ff => 99
	i64 18324163916253801303, ; 407: it\Microsoft.Maui.Controls.resources => 0xfe4c81ff0a56ab57 => 14
	i64 18342408478508122430, ; 408: id\Microsoft.Maui.Controls.resources.dll => 0xfe8d53543697013e => 13
	i64 18358161419737137786 ; 409: he\Microsoft.Maui.Controls.resources.dll => 0xfec54a8ba8b6827a => 9
], align 16

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [410 x i32] [
	i32 52, ; 0
	i32 204, ; 1
	i32 65, ; 2
	i32 140, ; 3
	i32 85, ; 4
	i32 102, ; 5
	i32 103, ; 6
	i32 163, ; 7
	i32 53, ; 8
	i32 190, ; 9
	i32 123, ; 10
	i32 12, ; 11
	i32 90, ; 12
	i32 67, ; 13
	i32 163, ; 14
	i32 35, ; 15
	i32 108, ; 16
	i32 133, ; 17
	i32 98, ; 18
	i32 137, ; 19
	i32 148, ; 20
	i32 62, ; 21
	i32 203, ; 22
	i32 190, ; 23
	i32 40, ; 24
	i32 82, ; 25
	i32 95, ; 26
	i32 68, ; 27
	i32 145, ; 28
	i32 142, ; 29
	i32 158, ; 30
	i32 81, ; 31
	i32 165, ; 32
	i32 6, ; 33
	i32 102, ; 34
	i32 43, ; 35
	i32 132, ; 36
	i32 28, ; 37
	i32 103, ; 38
	i32 63, ; 39
	i32 175, ; 40
	i32 94, ; 41
	i32 188, ; 42
	i32 132, ; 43
	i32 68, ; 44
	i32 83, ; 45
	i32 70, ; 46
	i32 90, ; 47
	i32 115, ; 48
	i32 138, ; 49
	i32 59, ; 50
	i32 93, ; 51
	i32 184, ; 52
	i32 86, ; 53
	i32 173, ; 54
	i32 80, ; 55
	i32 78, ; 56
	i32 27, ; 57
	i32 60, ; 58
	i32 146, ; 59
	i32 47, ; 60
	i32 2, ; 61
	i32 56, ; 62
	i32 75, ; 63
	i32 7, ; 64
	i32 108, ; 65
	i32 172, ; 66
	i32 177, ; 67
	i32 73, ; 68
	i32 92, ; 69
	i32 155, ; 70
	i32 168, ; 71
	i32 152, ; 72
	i32 111, ; 73
	i32 76, ; 74
	i32 72, ; 75
	i32 65, ; 76
	i32 40, ; 77
	i32 70, ; 78
	i32 45, ; 79
	i32 104, ; 80
	i32 201, ; 81
	i32 22, ; 82
	i32 173, ; 83
	i32 46, ; 84
	i32 196, ; 85
	i32 45, ; 86
	i32 200, ; 87
	i32 101, ; 88
	i32 49, ; 89
	i32 63, ; 90
	i32 178, ; 91
	i32 149, ; 92
	i32 142, ; 93
	i32 171, ; 94
	i32 3, ; 95
	i32 160, ; 96
	i32 61, ; 97
	i32 33, ; 98
	i32 123, ; 99
	i32 191, ; 100
	i32 174, ; 101
	i32 140, ; 102
	i32 122, ; 103
	i32 28, ; 104
	i32 139, ; 105
	i32 112, ; 106
	i32 194, ; 107
	i32 137, ; 108
	i32 198, ; 109
	i32 120, ; 110
	i32 80, ; 111
	i32 104, ; 112
	i32 133, ; 113
	i32 146, ; 114
	i32 167, ; 115
	i32 18, ; 116
	i32 26, ; 117
	i32 118, ; 118
	i32 118, ; 119
	i32 153, ; 120
	i32 167, ; 121
	i32 165, ; 122
	i32 126, ; 123
	i32 26, ; 124
	i32 29, ; 125
	i32 135, ; 126
	i32 181, ; 127
	i32 175, ; 128
	i32 106, ; 129
	i32 134, ; 130
	i32 179, ; 131
	i32 23, ; 132
	i32 185, ; 133
	i32 193, ; 134
	i32 157, ; 135
	i32 161, ; 136
	i32 6, ; 137
	i32 34, ; 138
	i32 93, ; 139
	i32 7, ; 140
	i32 11, ; 141
	i32 83, ; 142
	i32 89, ; 143
	i32 107, ; 144
	i32 51, ; 145
	i32 182, ; 146
	i32 69, ; 147
	i32 19, ; 148
	i32 130, ; 149
	i32 197, ; 150
	i32 195, ; 151
	i32 155, ; 152
	i32 159, ; 153
	i32 138, ; 154
	i32 41, ; 155
	i32 141, ; 156
	i32 74, ; 157
	i32 114, ; 158
	i32 77, ; 159
	i32 122, ; 160
	i32 195, ; 161
	i32 156, ; 162
	i32 76, ; 163
	i32 128, ; 164
	i32 144, ; 165
	i32 145, ; 166
	i32 201, ; 167
	i32 72, ; 168
	i32 113, ; 169
	i32 110, ; 170
	i32 14, ; 171
	i32 82, ; 172
	i32 71, ; 173
	i32 25, ; 174
	i32 119, ; 175
	i32 92, ; 176
	i32 143, ; 177
	i32 127, ; 178
	i32 16, ; 179
	i32 202, ; 180
	i32 119, ; 181
	i32 54, ; 182
	i32 66, ; 183
	i32 128, ; 184
	i32 164, ; 185
	i32 181, ; 186
	i32 31, ; 187
	i32 100, ; 188
	i32 162, ; 189
	i32 67, ; 190
	i32 116, ; 191
	i32 158, ; 192
	i32 37, ; 193
	i32 202, ; 194
	i32 113, ; 195
	i32 99, ; 196
	i32 21, ; 197
	i32 127, ; 198
	i32 112, ; 199
	i32 197, ; 200
	i32 170, ; 201
	i32 53, ; 202
	i32 31, ; 203
	i32 58, ; 204
	i32 177, ; 205
	i32 106, ; 206
	i32 81, ; 207
	i32 5, ; 208
	i32 57, ; 209
	i32 29, ; 210
	i32 109, ; 211
	i32 186, ; 212
	i32 129, ; 213
	i32 86, ; 214
	i32 117, ; 215
	i32 1, ; 216
	i32 204, ; 217
	i32 58, ; 218
	i32 64, ; 219
	i32 144, ; 220
	i32 160, ; 221
	i32 62, ; 222
	i32 3, ; 223
	i32 19, ; 224
	i32 89, ; 225
	i32 151, ; 226
	i32 162, ; 227
	i32 161, ; 228
	i32 111, ; 229
	i32 87, ; 230
	i32 43, ; 231
	i32 1, ; 232
	i32 170, ; 233
	i32 114, ; 234
	i32 164, ; 235
	i32 33, ; 236
	i32 42, ; 237
	i32 148, ; 238
	i32 37, ; 239
	i32 44, ; 240
	i32 131, ; 241
	i32 50, ; 242
	i32 64, ; 243
	i32 12, ; 244
	i32 27, ; 245
	i32 8, ; 246
	i32 105, ; 247
	i32 15, ; 248
	i32 51, ; 249
	i32 88, ; 250
	i32 75, ; 251
	i32 198, ; 252
	i32 166, ; 253
	i32 55, ; 254
	i32 13, ; 255
	i32 105, ; 256
	i32 49, ; 257
	i32 41, ; 258
	i32 200, ; 259
	i32 189, ; 260
	i32 42, ; 261
	i32 30, ; 262
	i32 79, ; 263
	i32 151, ; 264
	i32 185, ; 265
	i32 59, ; 266
	i32 171, ; 267
	i32 116, ; 268
	i32 38, ; 269
	i32 56, ; 270
	i32 91, ; 271
	i32 96, ; 272
	i32 34, ; 273
	i32 44, ; 274
	i32 130, ; 275
	i32 84, ; 276
	i32 136, ; 277
	i32 129, ; 278
	i32 85, ; 279
	i32 183, ; 280
	i32 172, ; 281
	i32 107, ; 282
	i32 139, ; 283
	i32 52, ; 284
	i32 154, ; 285
	i32 0, ; 286
	i32 21, ; 287
	i32 169, ; 288
	i32 39, ; 289
	i32 203, ; 290
	i32 9, ; 291
	i32 153, ; 292
	i32 157, ; 293
	i32 110, ; 294
	i32 30, ; 295
	i32 101, ; 296
	i32 121, ; 297
	i32 36, ; 298
	i32 124, ; 299
	i32 91, ; 300
	i32 84, ; 301
	i32 192, ; 302
	i32 176, ; 303
	i32 183, ; 304
	i32 180, ; 305
	i32 23, ; 306
	i32 149, ; 307
	i32 24, ; 308
	i32 32, ; 309
	i32 184, ; 310
	i32 74, ; 311
	i32 38, ; 312
	i32 179, ; 313
	i32 2, ; 314
	i32 169, ; 315
	i32 36, ; 316
	i32 47, ; 317
	i32 194, ; 318
	i32 16, ; 319
	i32 15, ; 320
	i32 32, ; 321
	i32 174, ; 322
	i32 88, ; 323
	i32 0, ; 324
	i32 39, ; 325
	i32 182, ; 326
	i32 48, ; 327
	i32 154, ; 328
	i32 136, ; 329
	i32 150, ; 330
	i32 143, ; 331
	i32 156, ; 332
	i32 17, ; 333
	i32 135, ; 334
	i32 141, ; 335
	i32 55, ; 336
	i32 22, ; 337
	i32 46, ; 338
	i32 87, ; 339
	i32 77, ; 340
	i32 48, ; 341
	i32 124, ; 342
	i32 4, ; 343
	i32 180, ; 344
	i32 152, ; 345
	i32 95, ; 346
	i32 199, ; 347
	i32 196, ; 348
	i32 5, ; 349
	i32 189, ; 350
	i32 187, ; 351
	i32 61, ; 352
	i32 176, ; 353
	i32 188, ; 354
	i32 147, ; 355
	i32 24, ; 356
	i32 199, ; 357
	i32 150, ; 358
	i32 18, ; 359
	i32 50, ; 360
	i32 69, ; 361
	i32 147, ; 362
	i32 66, ; 363
	i32 100, ; 364
	i32 17, ; 365
	i32 125, ; 366
	i32 186, ; 367
	i32 25, ; 368
	i32 35, ; 369
	i32 98, ; 370
	i32 117, ; 371
	i32 97, ; 372
	i32 121, ; 373
	i32 187, ; 374
	i32 60, ; 375
	i32 120, ; 376
	i32 54, ; 377
	i32 178, ; 378
	i32 20, ; 379
	i32 159, ; 380
	i32 193, ; 381
	i32 125, ; 382
	i32 10, ; 383
	i32 131, ; 384
	i32 10, ; 385
	i32 109, ; 386
	i32 78, ; 387
	i32 8, ; 388
	i32 79, ; 389
	i32 20, ; 390
	i32 71, ; 391
	i32 126, ; 392
	i32 96, ; 393
	i32 94, ; 394
	i32 166, ; 395
	i32 168, ; 396
	i32 57, ; 397
	i32 11, ; 398
	i32 4, ; 399
	i32 192, ; 400
	i32 97, ; 401
	i32 73, ; 402
	i32 134, ; 403
	i32 191, ; 404
	i32 115, ; 405
	i32 99, ; 406
	i32 14, ; 407
	i32 13, ; 408
	i32 9 ; 409
], align 16

@marshal_methods_number_of_classes = dso_local local_unnamed_addr constant i32 0, align 4

@marshal_methods_class_cache = dso_local local_unnamed_addr global [0 x %struct.MarshalMethodsManagedClass] zeroinitializer, align 8

; Names of classes in which marshal methods reside
@mm_class_names = dso_local local_unnamed_addr constant [0 x ptr] zeroinitializer, align 8

@mm_method_names = dso_local local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		ptr @.MarshalMethodName.0_name; char* name
	} ; 0
], align 8

; get_function_pointer (uint32_t mono_image_index, uint32_t class_index, uint32_t method_token, void*& target_ptr)
@get_function_pointer = internal dso_local unnamed_addr global ptr null, align 8

; Functions

; Function attributes: "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" uwtable willreturn
define void @xamarin_app_init(ptr nocapture noundef readnone %env, ptr noundef %fn) local_unnamed_addr #0
{
	%fnIsNull = icmp eq ptr %fn, null
	br i1 %fnIsNull, label %1, label %2

1: ; preds = %0
	%putsResult = call noundef i32 @puts(ptr @.str.0)
	call void @abort()
	unreachable 

2: ; preds = %1, %0
	store ptr %fn, ptr @get_function_pointer, align 8, !tbaa !3
	ret void
}

; Strings
@.str.0 = private unnamed_addr constant [40 x i8] c"get_function_pointer MUST be specified\0A\00", align 16

;MarshalMethodName
@.MarshalMethodName.0_name = private unnamed_addr constant [1 x i8] c"\00", align 1

; External functions

; Function attributes: noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8"
declare void @abort() local_unnamed_addr #2

; Function attributes: nofree nounwind
declare noundef i32 @puts(ptr noundef) local_unnamed_addr #1
attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="x86-64" "target-features"="+crc32,+cx16,+cx8,+fxsr,+mmx,+popcnt,+sse,+sse2,+sse3,+sse4.1,+sse4.2,+ssse3,+x87" "tune-cpu"="generic" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="x86-64" "target-features"="+crc32,+cx16,+cx8,+fxsr,+mmx,+popcnt,+sse,+sse2,+sse3,+sse4.1,+sse4.2,+ssse3,+x87" "tune-cpu"="generic" }

; Metadata
!llvm.module.flags = !{!0, !1}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!"Xamarin.Android remotes/origin/release/8.0.1xx-preview7 @ d8764fc950e5e864f357bb0c4d44b6d5a2675229"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}
