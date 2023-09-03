; ModuleID = 'marshal_methods.armeabi-v7a.ll'
source_filename = "marshal_methods.armeabi-v7a.ll"
target datalayout = "e-m:e-p:32:32-Fi8-i64:64-v128:64:128-a:0:32-n32-S64"
target triple = "armv7-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [205 x ptr] zeroinitializer, align 4

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [410 x i32] [
	i32 2616222, ; 0: System.Net.NetworkInformation.dll => 0x27eb9e => 147
	i32 10166715, ; 1: System.Net.NameResolution.dll => 0x9b21bb => 146
	i32 10266594, ; 2: LiveChartsCore.SkiaSharpView.dll => 0x9ca7e2 => 41
	i32 38948123, ; 3: ar\Microsoft.Maui.Controls.resources.dll => 0x2524d1b => 0
	i32 39109920, ; 4: Newtonsoft.Json.dll => 0x254c520 => 68
	i32 42244203, ; 5: he\Microsoft.Maui.Controls.resources.dll => 0x284986b => 9
	i32 42639949, ; 6: System.Threading.Thread => 0x28aa24d => 190
	i32 66541672, ; 7: System.Diagnostics.StackTrace => 0x3f75868 => 129
	i32 67008169, ; 8: zh-Hant\Microsoft.Maui.Controls.resources => 0x3fe76a9 => 33
	i32 68219467, ; 9: System.Security.Cryptography.Primitives => 0x410f24b => 179
	i32 72070932, ; 10: Microsoft.Maui.Graphics.dll => 0x44bb714 => 66
	i32 83839681, ; 11: ms\Microsoft.Maui.Controls.resources.dll => 0x4ff4ac1 => 17
	i32 117431740, ; 12: System.Runtime.InteropServices => 0x6ffddbc => 166
	i32 122350210, ; 13: System.Threading.Channels.dll => 0x74aea82 => 187
	i32 136584136, ; 14: zh-Hans\Microsoft.Maui.Controls.resources.dll => 0x8241bc8 => 32
	i32 140062828, ; 15: sk\Microsoft.Maui.Controls.resources.dll => 0x859306c => 25
	i32 142721839, ; 16: System.Net.WebHeaderCollection => 0x881c32f => 154
	i32 149972175, ; 17: System.Security.Cryptography.Primitives.dll => 0x8f064cf => 179
	i32 159306688, ; 18: System.ComponentModel.Annotations => 0x97ed3c0 => 120
	i32 165246403, ; 19: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 85
	i32 182336117, ; 20: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 104
	i32 205061960, ; 21: System.ComponentModel => 0xc38ff48 => 123
	i32 209399409, ; 22: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 83
	i32 220171995, ; 23: System.Diagnostics.Debug => 0xd1f8edb => 126
	i32 230752869, ; 24: Microsoft.CSharp.dll => 0xdc10265 => 113
	i32 246610117, ; 25: System.Reflection.Emit.Lightweight => 0xeb2f8c5 => 162
	i32 317674968, ; 26: vi\Microsoft.Maui.Controls.resources => 0x12ef55d8 => 30
	i32 318968648, ; 27: Xamarin.AndroidX.Activity.dll => 0x13031348 => 80
	i32 321963286, ; 28: fr\Microsoft.Maui.Controls.resources.dll => 0x1330c516 => 8
	i32 330147069, ; 29: Microsoft.SqlServer.Server => 0x13ada4fd => 67
	i32 342366114, ; 30: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 92
	i32 367780167, ; 31: System.IO.Pipes => 0x15ebe147 => 139
	i32 374914964, ; 32: System.Transactions.Local => 0x1658bf94 => 193
	i32 375677976, ; 33: System.Net.ServicePoint.dll => 0x16646418 => 151
	i32 379916513, ; 34: System.Threading.Thread.dll => 0x16a510e1 => 190
	i32 385762202, ; 35: System.Memory.dll => 0x16fe439a => 142
	i32 392610295, ; 36: System.Threading.ThreadPool.dll => 0x1766c1f7 => 191
	i32 395744057, ; 37: _Microsoft.Android.Resource.Designer => 0x17969339 => 34
	i32 409257351, ; 38: tr\Microsoft.Maui.Controls.resources.dll => 0x1864c587 => 28
	i32 442565967, ; 39: System.Collections => 0x1a61054f => 119
	i32 450948140, ; 40: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 91
	i32 451504562, ; 41: System.Security.Cryptography.X509Certificates => 0x1ae969b2 => 180
	i32 456227837, ; 42: System.Web.HttpUtility.dll => 0x1b317bfd => 194
	i32 459347974, ; 43: System.Runtime.Serialization.Primitives.dll => 0x1b611806 => 171
	i32 469710990, ; 44: System.dll => 0x1bff388e => 199
	i32 485463106, ; 45: Microsoft.IdentityModel.Abstractions => 0x1cef9442 => 55
	i32 489220957, ; 46: es\Microsoft.Maui.Controls.resources.dll => 0x1d28eb5d => 6
	i32 498788369, ; 47: System.ObjectModel => 0x1dbae811 => 156
	i32 513247710, ; 48: Microsoft.Extensions.Primitives.dll => 0x1e9789de => 52
	i32 525008092, ; 49: SkiaSharp.dll => 0x1f4afcdc => 69
	i32 538707440, ; 50: th\Microsoft.Maui.Controls.resources.dll => 0x201c05f0 => 27
	i32 539058512, ; 51: Microsoft.Extensions.Logging => 0x20216150 => 49
	i32 540030774, ; 52: System.IO.FileSystem.dll => 0x20303736 => 138
	i32 545304856, ; 53: System.Runtime.Extensions => 0x2080b118 => 164
	i32 546455878, ; 54: System.Runtime.Serialization.Xml => 0x20924146 => 172
	i32 548916678, ; 55: Microsoft.Bcl.AsyncInterfaces => 0x20b7cdc6 => 43
	i32 577335427, ; 56: System.Security.Cryptography.Cng => 0x22697083 => 176
	i32 597488923, ; 57: CommunityToolkit.Maui => 0x239cf51b => 37
	i32 613668793, ; 58: System.Security.Cryptography.Algorithms => 0x2493d7b9 => 175
	i32 627609679, ; 59: Xamarin.AndroidX.CustomView => 0x2568904f => 89
	i32 627931235, ; 60: nl\Microsoft.Maui.Controls.resources => 0x256d7863 => 19
	i32 662205335, ; 61: System.Text.Encodings.Web.dll => 0x27787397 => 184
	i32 672442732, ; 62: System.Collections.Concurrent => 0x2814a96c => 115
	i32 683518922, ; 63: System.Net.Security => 0x28bdabca => 150
	i32 690569205, ; 64: System.Xml.Linq.dll => 0x29293ff5 => 195
	i32 722857257, ; 65: System.Runtime.Loader.dll => 0x2b15ed29 => 167
	i32 759454413, ; 66: System.Net.Requests => 0x2d445acd => 149
	i32 762598435, ; 67: System.IO.Pipes.dll => 0x2d745423 => 139
	i32 775507847, ; 68: System.IO.Compression => 0x2e394f87 => 136
	i32 777317022, ; 69: sk\Microsoft.Maui.Controls.resources => 0x2e54ea9e => 25
	i32 778756650, ; 70: SkiaSharp.HarfBuzz.dll => 0x2e6ae22a => 70
	i32 789151979, ; 71: Microsoft.Extensions.Options => 0x2f0980eb => 51
	i32 804715423, ; 72: System.Data.Common => 0x2ff6fb9f => 125
	i32 823281589, ; 73: System.Private.Uri.dll => 0x311247b5 => 158
	i32 830298997, ; 74: System.IO.Compression.Brotli => 0x317d5b75 => 135
	i32 869139383, ; 75: hi\Microsoft.Maui.Controls.resources.dll => 0x33ce03b7 => 10
	i32 878954865, ; 76: System.Net.Http.Json => 0x3463c971 => 143
	i32 880668424, ; 77: ru\Microsoft.Maui.Controls.resources.dll => 0x347def08 => 24
	i32 885823456, ; 78: SpaceSRM.dll => 0x34cc97e0 => 112
	i32 904024072, ; 79: System.ComponentModel.Primitives.dll => 0x35e25008 => 121
	i32 918734561, ; 80: pt-BR\Microsoft.Maui.Controls.resources.dll => 0x36c2c6e1 => 21
	i32 955402788, ; 81: Newtonsoft.Json => 0x38f24a24 => 68
	i32 961460050, ; 82: it\Microsoft.Maui.Controls.resources.dll => 0x394eb752 => 14
	i32 966729478, ; 83: Xamarin.Google.Crypto.Tink.Android => 0x399f1f06 => 109
	i32 967690846, ; 84: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 92
	i32 975236339, ; 85: System.Diagnostics.Tracing => 0x3a20ecf3 => 131
	i32 975874589, ; 86: System.Xml.XDocument => 0x3a2aaa1d => 197
	i32 986514023, ; 87: System.Private.DataContractSerialization.dll => 0x3acd0267 => 157
	i32 990727110, ; 88: ro\Microsoft.Maui.Controls.resources.dll => 0x3b0d4bc6 => 23
	i32 992768348, ; 89: System.Collections.dll => 0x3b2c715c => 119
	i32 994442037, ; 90: System.IO.FileSystem => 0x3b45fb35 => 138
	i32 1012816738, ; 91: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 102
	i32 1019214401, ; 92: System.Drawing => 0x3cbffa41 => 133
	i32 1028951442, ; 93: Microsoft.Extensions.DependencyInjection.Abstractions => 0x3d548d92 => 48
	i32 1034083993, ; 94: LiveChartsCore.SkiaSharpView.Maui.dll => 0x3da2de99 => 42
	i32 1035644815, ; 95: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 81
	i32 1036536393, ; 96: System.Drawing.Primitives.dll => 0x3dc84a49 => 132
	i32 1043950537, ; 97: de\Microsoft.Maui.Controls.resources.dll => 0x3e396bc9 => 4
	i32 1044663988, ; 98: System.Linq.Expressions.dll => 0x3e444eb4 => 140
	i32 1052210849, ; 99: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 94
	i32 1062017875, ; 100: Microsoft.Identity.Client.Extensions.Msal => 0x3f4d1b53 => 54
	i32 1082857460, ; 101: System.ComponentModel.TypeConverter => 0x408b17f4 => 122
	i32 1084122840, ; 102: Xamarin.Kotlin.StdLib => 0x409e66d8 => 110
	i32 1098259244, ; 103: System => 0x41761b2c => 199
	i32 1108272742, ; 104: sv\Microsoft.Maui.Controls.resources.dll => 0x420ee666 => 26
	i32 1117529484, ; 105: pl\Microsoft.Maui.Controls.resources.dll => 0x429c258c => 20
	i32 1118262833, ; 106: ko\Microsoft.Maui.Controls.resources => 0x42a75631 => 16
	i32 1138436374, ; 107: Microsoft.Data.SqlClient.dll => 0x43db2916 => 44
	i32 1149092582, ; 108: Xamarin.AndroidX.Window => 0x447dc2e6 => 107
	i32 1168523401, ; 109: pt\Microsoft.Maui.Controls.resources => 0x45a64089 => 22
	i32 1178241025, ; 110: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 99
	i32 1208641965, ; 111: System.Diagnostics.Process => 0x480a69ad => 128
	i32 1260983243, ; 112: cs\Microsoft.Maui.Controls.resources => 0x4b2913cb => 2
	i32 1283425954, ; 113: LiveChartsCore.SkiaSharpView => 0x4c7f86a2 => 41
	i32 1293217323, ; 114: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 90
	i32 1308624726, ; 115: hr\Microsoft.Maui.Controls.resources.dll => 0x4e000756 => 11
	i32 1309188875, ; 116: System.Private.DataContractSerialization => 0x4e08a30b => 157
	i32 1322716291, ; 117: Xamarin.AndroidX.Window.dll => 0x4ed70c83 => 107
	i32 1324164729, ; 118: System.Linq => 0x4eed2679 => 141
	i32 1335329327, ; 119: System.Runtime.Serialization.Json.dll => 0x4f97822f => 170
	i32 1336711579, ; 120: zh-HK\Microsoft.Maui.Controls.resources.dll => 0x4fac999b => 31
	i32 1373134921, ; 121: zh-Hans\Microsoft.Maui.Controls.resources => 0x51d86049 => 32
	i32 1376866003, ; 122: Xamarin.AndroidX.SavedState => 0x52114ed3 => 102
	i32 1406073936, ; 123: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 86
	i32 1408764838, ; 124: System.Runtime.Serialization.Formatters.dll => 0x53f80ba6 => 169
	i32 1430672901, ; 125: ar\Microsoft.Maui.Controls.resources => 0x55465605 => 0
	i32 1435222561, ; 126: Xamarin.Google.Crypto.Tink.Android.dll => 0x558bc221 => 109
	i32 1452070440, ; 127: System.Formats.Asn1.dll => 0x568cd628 => 134
	i32 1457743152, ; 128: System.Runtime.Extensions.dll => 0x56e36530 => 164
	i32 1458022317, ; 129: System.Net.Security.dll => 0x56e7a7ad => 150
	i32 1460893475, ; 130: System.IdentityModel.Tokens.Jwt => 0x57137723 => 76
	i32 1461004990, ; 131: es\Microsoft.Maui.Controls.resources => 0x57152abe => 6
	i32 1461234159, ; 132: System.Collections.Immutable.dll => 0x5718a9ef => 116
	i32 1462112819, ; 133: System.IO.Compression.dll => 0x57261233 => 136
	i32 1469204771, ; 134: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 82
	i32 1470490898, ; 135: Microsoft.Extensions.Primitives => 0x57a5e912 => 52
	i32 1479771757, ; 136: System.Collections.Immutable => 0x5833866d => 116
	i32 1480492111, ; 137: System.IO.Compression.Brotli.dll => 0x583e844f => 135
	i32 1487239319, ; 138: Microsoft.Win32.Primitives => 0x58a57897 => 114
	i32 1498168481, ; 139: Microsoft.IdentityModel.JsonWebTokens.dll => 0x594c3ca1 => 56
	i32 1526286932, ; 140: vi\Microsoft.Maui.Controls.resources.dll => 0x5af94a54 => 30
	i32 1543031311, ; 141: System.Text.RegularExpressions.dll => 0x5bf8ca0f => 186
	i32 1565310744, ; 142: System.Runtime.Caching => 0x5d4cbf18 => 78
	i32 1573704789, ; 143: System.Runtime.Serialization.Json => 0x5dccd455 => 170
	i32 1582305585, ; 144: Azure.Identity => 0x5e501131 => 36
	i32 1604827217, ; 145: System.Net.WebClient => 0x5fa7b851 => 153
	i32 1622152042, ; 146: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 96
	i32 1623212457, ; 147: SkiaSharp.Views.Maui.Controls => 0x60c041a9 => 72
	i32 1624863272, ; 148: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 106
	i32 1628113371, ; 149: Microsoft.IdentityModel.Protocols.OpenIdConnect => 0x610b09db => 59
	i32 1634654947, ; 150: CommunityToolkit.Maui.Core.dll => 0x616edae3 => 38
	i32 1636350590, ; 151: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 88
	i32 1639515021, ; 152: System.Net.Http.dll => 0x61b9038d => 144
	i32 1639986890, ; 153: System.Text.RegularExpressions => 0x61c036ca => 186
	i32 1657153582, ; 154: System.Runtime => 0x62c6282e => 173
	i32 1658251792, ; 155: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 108
	i32 1677501392, ; 156: System.Net.Primitives.dll => 0x63fca3d0 => 148
	i32 1679769178, ; 157: System.Security.Cryptography => 0x641f3e5a => 181
	i32 1696967625, ; 158: System.Security.Cryptography.Csp => 0x6525abc9 => 177
	i32 1701541528, ; 159: System.Diagnostics.Debug.dll => 0x656b7698 => 126
	i32 1729485958, ; 160: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 84
	i32 1743415430, ; 161: ca\Microsoft.Maui.Controls.resources => 0x67ea6886 => 1
	i32 1744735666, ; 162: System.Transactions.Local.dll => 0x67fe8db2 => 193
	i32 1750313021, ; 163: Microsoft.Win32.Primitives.dll => 0x6853a83d => 114
	i32 1763938596, ; 164: System.Diagnostics.TraceSource.dll => 0x69239124 => 130
	i32 1766324549, ; 165: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 104
	i32 1770582343, ; 166: Microsoft.Extensions.Logging.dll => 0x6988f147 => 49
	i32 1780572499, ; 167: Mono.Android.Runtime.dll => 0x6a216153 => 203
	i32 1782862114, ; 168: ms\Microsoft.Maui.Controls.resources => 0x6a445122 => 17
	i32 1788241197, ; 169: Xamarin.AndroidX.Fragment => 0x6a96652d => 91
	i32 1793755602, ; 170: he\Microsoft.Maui.Controls.resources => 0x6aea89d2 => 9
	i32 1794500907, ; 171: Microsoft.Identity.Client.dll => 0x6af5e92b => 53
	i32 1796167890, ; 172: Microsoft.Bcl.AsyncInterfaces.dll => 0x6b0f58d2 => 43
	i32 1808609942, ; 173: Xamarin.AndroidX.Loader => 0x6bcd3296 => 96
	i32 1813058853, ; 174: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 110
	i32 1813201214, ; 175: Xamarin.Google.Android.Material => 0x6c13413e => 108
	i32 1818569960, ; 176: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 100
	i32 1824175904, ; 177: System.Text.Encoding.Extensions => 0x6cbab720 => 183
	i32 1824722060, ; 178: System.Runtime.Serialization.Formatters => 0x6cc30c8c => 169
	i32 1828688058, ; 179: Microsoft.Extensions.Logging.Abstractions.dll => 0x6cff90ba => 50
	i32 1853025655, ; 180: sv\Microsoft.Maui.Controls.resources => 0x6e72ed77 => 26
	i32 1858542181, ; 181: System.Linq.Expressions => 0x6ec71a65 => 140
	i32 1870277092, ; 182: System.Reflection.Primitives => 0x6f7a29e4 => 163
	i32 1871986876, ; 183: Microsoft.IdentityModel.Protocols.OpenIdConnect.dll => 0x6f9440bc => 59
	i32 1875935024, ; 184: fr\Microsoft.Maui.Controls.resources => 0x6fd07f30 => 8
	i32 1893218855, ; 185: cs\Microsoft.Maui.Controls.resources.dll => 0x70d83a27 => 2
	i32 1910275211, ; 186: System.Collections.NonGeneric.dll => 0x71dc7c8b => 117
	i32 1939592360, ; 187: System.Private.Xml.Linq => 0x739bd4a8 => 159
	i32 1953182387, ; 188: id\Microsoft.Maui.Controls.resources.dll => 0x746b32b3 => 13
	i32 1961813231, ; 189: Xamarin.AndroidX.Security.SecurityCrypto.dll => 0x74eee4ef => 103
	i32 1968388702, ; 190: Microsoft.Extensions.Configuration.dll => 0x75533a5e => 45
	i32 1986222447, ; 191: Microsoft.IdentityModel.Tokens.dll => 0x7663596f => 60
	i32 2003115576, ; 192: el\Microsoft.Maui.Controls.resources => 0x77651e38 => 5
	i32 2019465201, ; 193: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 94
	i32 2040764568, ; 194: Microsoft.Identity.Client.Extensions.Msal.dll => 0x79a39898 => 54
	i32 2045470958, ; 195: System.Private.Xml => 0x79eb68ee => 160
	i32 2055257422, ; 196: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 93
	i32 2066184531, ; 197: de\Microsoft.Maui.Controls.resources => 0x7b277953 => 4
	i32 2070888862, ; 198: System.Diagnostics.TraceSource => 0x7b6f419e => 130
	i32 2079903147, ; 199: System.Runtime.dll => 0x7bf8cdab => 173
	i32 2090596640, ; 200: System.Numerics.Vectors => 0x7c9bf920 => 155
	i32 2127167465, ; 201: System.Console => 0x7ec9ffe9 => 124
	i32 2142473426, ; 202: System.Collections.Specialized => 0x7fb38cd2 => 118
	i32 2143790110, ; 203: System.Xml.XmlSerializer.dll => 0x7fc7a41e => 198
	i32 2159891885, ; 204: Microsoft.Maui => 0x80bd55ad => 64
	i32 2169148018, ; 205: hu\Microsoft.Maui.Controls.resources => 0x814a9272 => 12
	i32 2181898931, ; 206: Microsoft.Extensions.Options.dll => 0x820d22b3 => 51
	i32 2192057212, ; 207: Microsoft.Extensions.Logging.Abstractions => 0x82a8237c => 50
	i32 2193016926, ; 208: System.ObjectModel.dll => 0x82b6c85e => 156
	i32 2201107256, ; 209: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x83323b38 => 111
	i32 2201231467, ; 210: System.Net.Http => 0x8334206b => 144
	i32 2207618523, ; 211: it\Microsoft.Maui.Controls.resources => 0x839595db => 14
	i32 2253551641, ; 212: Microsoft.IdentityModel.Protocols => 0x86527819 => 58
	i32 2266799131, ; 213: Microsoft.Extensions.Configuration.Abstractions => 0x871c9c1b => 46
	i32 2279755925, ; 214: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 101
	i32 2295906218, ; 215: System.Net.Sockets => 0x88d8bfaa => 152
	i32 2298471582, ; 216: System.Net.Mail => 0x88ffe49e => 145
	i32 2303942373, ; 217: nb\Microsoft.Maui.Controls.resources => 0x89535ee5 => 18
	i32 2305521784, ; 218: System.Private.CoreLib.dll => 0x896b7878 => 201
	i32 2340441535, ; 219: System.Runtime.InteropServices.RuntimeInformation.dll => 0x8b804dbf => 165
	i32 2353062107, ; 220: System.Net.Primitives => 0x8c40e0db => 148
	i32 2364201794, ; 221: SkiaSharp.Views.Maui.Core => 0x8ceadb42 => 74
	i32 2366048013, ; 222: hu\Microsoft.Maui.Controls.resources.dll => 0x8d07070d => 12
	i32 2368005991, ; 223: System.Xml.ReaderWriter.dll => 0x8d24e767 => 196
	i32 2369706906, ; 224: Microsoft.IdentityModel.Logging => 0x8d3edb9a => 57
	i32 2371007202, ; 225: Microsoft.Extensions.Configuration => 0x8d52b2e2 => 45
	i32 2378619854, ; 226: System.Security.Cryptography.Csp.dll => 0x8dc6dbce => 177
	i32 2395872292, ; 227: id\Microsoft.Maui.Controls.resources => 0x8ece1c24 => 13
	i32 2401565422, ; 228: System.Web.HttpUtility => 0x8f24faee => 194
	i32 2427813419, ; 229: hi\Microsoft.Maui.Controls.resources => 0x90b57e2b => 10
	i32 2435356389, ; 230: System.Console.dll => 0x912896e5 => 124
	i32 2458678730, ; 231: System.Net.Sockets.dll => 0x928c75ca => 152
	i32 2471841756, ; 232: netstandard.dll => 0x93554fdc => 200
	i32 2475788418, ; 233: Java.Interop.dll => 0x93918882 => 202
	i32 2480646305, ; 234: Microsoft.Maui.Controls => 0x93dba8a1 => 62
	i32 2484371297, ; 235: System.Net.ServicePoint => 0x94147f61 => 151
	i32 2503351294, ; 236: ko\Microsoft.Maui.Controls.resources.dll => 0x95361bfe => 16
	i32 2521915375, ; 237: SkiaSharp.Views.Maui.Controls.Compatibility => 0x96515fef => 73
	i32 2538310050, ; 238: System.Reflection.Emit.Lightweight.dll => 0x974b89a2 => 162
	i32 2550873716, ; 239: hr\Microsoft.Maui.Controls.resources => 0x980b3e74 => 11
	i32 2556439392, ; 240: LiveChartsCore.SkiaSharpView.Maui => 0x98602b60 => 42
	i32 2562349572, ; 241: Microsoft.CSharp => 0x98ba5a04 => 113
	i32 2570120770, ; 242: System.Text.Encodings.Web => 0x9930ee42 => 184
	i32 2576534780, ; 243: ja\Microsoft.Maui.Controls.resources.dll => 0x9992ccfc => 15
	i32 2585220780, ; 244: System.Text.Encoding.Extensions.dll => 0x9a1756ac => 183
	i32 2589602615, ; 245: System.Threading.ThreadPool => 0x9a5a3337 => 191
	i32 2593496499, ; 246: pl\Microsoft.Maui.Controls.resources => 0x9a959db3 => 20
	i32 2605712449, ; 247: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x9b500441 => 111
	i32 2617129537, ; 248: System.Private.Xml.dll => 0x9bfe3a41 => 160
	i32 2620871830, ; 249: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 88
	i32 2625339995, ; 250: SkiaSharp.Views.Maui.Core.dll => 0x9c7b825b => 74
	i32 2626831493, ; 251: ja\Microsoft.Maui.Controls.resources => 0x9c924485 => 15
	i32 2628210652, ; 252: System.Memory.Data => 0x9ca74fdc => 77
	i32 2640290731, ; 253: Microsoft.IdentityModel.Logging.dll => 0x9d5fa3ab => 57
	i32 2640706905, ; 254: Azure.Core => 0x9d65fd59 => 35
	i32 2660759594, ; 255: System.Security.Cryptography.ProtectedData.dll => 0x9e97f82a => 79
	i32 2663698177, ; 256: System.Runtime.Loader => 0x9ec4cf01 => 167
	i32 2664396074, ; 257: System.Xml.XDocument.dll => 0x9ecf752a => 197
	i32 2665622720, ; 258: System.Drawing.Primitives => 0x9ee22cc0 => 132
	i32 2676780864, ; 259: System.Data.Common.dll => 0x9f8c6f40 => 125
	i32 2677098746, ; 260: Azure.Identity.dll => 0x9f9148fa => 36
	i32 2686887180, ; 261: System.Runtime.Serialization.Xml.dll => 0xa026a50c => 172
	i32 2715334215, ; 262: System.Threading.Tasks.dll => 0xa1d8b647 => 189
	i32 2717744543, ; 263: System.Security.Claims => 0xa1fd7d9f => 174
	i32 2719963679, ; 264: System.Security.Cryptography.Cng.dll => 0xa21f5a1f => 176
	i32 2724373263, ; 265: System.Runtime.Numerics.dll => 0xa262a30f => 168
	i32 2732626843, ; 266: Xamarin.AndroidX.Activity => 0xa2e0939b => 80
	i32 2735172069, ; 267: System.Threading.Channels => 0xa30769e5 => 187
	i32 2737747696, ; 268: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 82
	i32 2740051746, ; 269: Microsoft.Identity.Client => 0xa351df22 => 53
	i32 2740698338, ; 270: ca\Microsoft.Maui.Controls.resources.dll => 0xa35bbce2 => 1
	i32 2752995522, ; 271: pt-BR\Microsoft.Maui.Controls.resources => 0xa41760c2 => 21
	i32 2755098380, ; 272: Microsoft.SqlServer.Server.dll => 0xa437770c => 67
	i32 2758225723, ; 273: Microsoft.Maui.Controls.Xaml => 0xa4672f3b => 63
	i32 2764765095, ; 274: Microsoft.Maui.dll => 0xa4caf7a7 => 64
	i32 2765824710, ; 275: System.Text.Encoding.CodePages.dll => 0xa4db22c6 => 182
	i32 2778768386, ; 276: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 105
	i32 2785988530, ; 277: th\Microsoft.Maui.Controls.resources => 0xa60ecfb2 => 27
	i32 2795602088, ; 278: SkiaSharp.Views.Android.dll => 0xa6a180a8 => 71
	i32 2801831435, ; 279: Microsoft.Maui.Graphics => 0xa7008e0b => 66
	i32 2810250172, ; 280: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 86
	i32 2853208004, ; 281: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 105
	i32 2861189240, ; 282: Microsoft.Maui.Essentials => 0xaa8a4878 => 65
	i32 2867946736, ; 283: System.Security.Cryptography.ProtectedData => 0xaaf164f0 => 79
	i32 2868488919, ; 284: CommunityToolkit.Maui.Core => 0xaaf9aad7 => 38
	i32 2909740682, ; 285: System.Private.CoreLib => 0xad6f1e8a => 201
	i32 2912489636, ; 286: SkiaSharp.Views.Android => 0xad9910a4 => 71
	i32 2916838712, ; 287: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 106
	i32 2919462931, ; 288: System.Numerics.Vectors.dll => 0xae037813 => 155
	i32 2924411691, ; 289: SpaceSRM => 0xae4efb2b => 112
	i32 2940926066, ; 290: System.Diagnostics.StackTrace.dll => 0xaf4af872 => 129
	i32 2944313911, ; 291: System.Configuration.ConfigurationManager.dll => 0xaf7eaa37 => 75
	i32 2959614098, ; 292: System.ComponentModel.dll => 0xb0682092 => 123
	i32 2972252294, ; 293: System.Security.Cryptography.Algorithms.dll => 0xb128f886 => 175
	i32 2978675010, ; 294: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 90
	i32 2987532451, ; 295: Xamarin.AndroidX.Security.SecurityCrypto => 0xb21220a3 => 103
	i32 3012788804, ; 296: System.Configuration.ConfigurationManager => 0xb3938244 => 75
	i32 3033605958, ; 297: System.Memory.Data.dll => 0xb4d12746 => 77
	i32 3038032645, ; 298: _Microsoft.Android.Resource.Designer.dll => 0xb514b305 => 34
	i32 3053864966, ; 299: fi\Microsoft.Maui.Controls.resources.dll => 0xb6064806 => 7
	i32 3057625584, ; 300: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 97
	i32 3059408633, ; 301: Mono.Android.Runtime => 0xb65adef9 => 203
	i32 3059793426, ; 302: System.ComponentModel.Primitives => 0xb660be12 => 121
	i32 3075834255, ; 303: System.Threading.Tasks => 0xb755818f => 189
	i32 3081706019, ; 304: LiveChartsCore => 0xb7af1a23 => 40
	i32 3084678329, ; 305: Microsoft.IdentityModel.Tokens => 0xb7dc74b9 => 60
	i32 3090735792, ; 306: System.Security.Cryptography.X509Certificates.dll => 0xb838e2b0 => 180
	i32 3099732863, ; 307: System.Security.Claims.dll => 0xb8c22b7f => 174
	i32 3103600923, ; 308: System.Formats.Asn1 => 0xb8fd311b => 134
	i32 3124832203, ; 309: System.Threading.Tasks.Extensions => 0xba4127cb => 188
	i32 3147165239, ; 310: System.Diagnostics.Tracing.dll => 0xbb95ee37 => 131
	i32 3159123045, ; 311: System.Reflection.Primitives.dll => 0xbc4c6465 => 163
	i32 3178803400, ; 312: Xamarin.AndroidX.Navigation.Fragment.dll => 0xbd78b0c8 => 98
	i32 3220365878, ; 313: System.Threading => 0xbff2e236 => 192
	i32 3258312781, ; 314: Xamarin.AndroidX.CardView => 0xc235e84d => 84
	i32 3265893370, ; 315: System.Threading.Tasks.Extensions.dll => 0xc2a993fa => 188
	i32 3280506390, ; 316: System.ComponentModel.Annotations.dll => 0xc3888e16 => 120
	i32 3290767353, ; 317: System.Security.Cryptography.Encoding => 0xc4251ff9 => 178
	i32 3305363605, ; 318: fi\Microsoft.Maui.Controls.resources => 0xc503d895 => 7
	i32 3312457198, ; 319: Microsoft.IdentityModel.JsonWebTokens => 0xc57015ee => 56
	i32 3316684772, ; 320: System.Net.Requests.dll => 0xc5b097e4 => 149
	i32 3317135071, ; 321: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 89
	i32 3340387945, ; 322: SkiaSharp => 0xc71a4669 => 69
	i32 3346324047, ; 323: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 99
	i32 3357674450, ; 324: ru\Microsoft.Maui.Controls.resources => 0xc8220bd2 => 24
	i32 3358260929, ; 325: System.Text.Json => 0xc82afec1 => 185
	i32 3362522851, ; 326: Xamarin.AndroidX.Core => 0xc86c06e3 => 87
	i32 3366347497, ; 327: Java.Interop => 0xc8a662e9 => 202
	i32 3374879918, ; 328: Microsoft.IdentityModel.Protocols.dll => 0xc92894ae => 58
	i32 3374999561, ; 329: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 101
	i32 3381016424, ; 330: da\Microsoft.Maui.Controls.resources => 0xc9863768 => 3
	i32 3384551493, ; 331: LiveChartsCore.dll => 0xc9bc2845 => 40
	i32 3428513518, ; 332: Microsoft.Extensions.DependencyInjection.dll => 0xcc5af6ee => 47
	i32 3430777524, ; 333: netstandard => 0xcc7d82b4 => 200
	i32 3452344032, ; 334: Microsoft.Maui.Controls.Compatibility.dll => 0xcdc696e0 => 61
	i32 3458724246, ; 335: pt\Microsoft.Maui.Controls.resources.dll => 0xce27f196 => 22
	i32 3466574376, ; 336: SkiaSharp.Views.Maui.Controls.Compatibility.dll => 0xce9fba28 => 73
	i32 3471940407, ; 337: System.ComponentModel.TypeConverter.dll => 0xcef19b37 => 122
	i32 3473156932, ; 338: SkiaSharp.Views.Maui.Controls.dll => 0xcf042b44 => 72
	i32 3476120550, ; 339: Mono.Android => 0xcf3163e6 => 204
	i32 3484440000, ; 340: ro\Microsoft.Maui.Controls.resources => 0xcfb055c0 => 23
	i32 3485117614, ; 341: System.Text.Json.dll => 0xcfbaacae => 185
	i32 3509114376, ; 342: System.Xml.Linq => 0xd128d608 => 195
	i32 3545306353, ; 343: Microsoft.Data.SqlClient => 0xd35114f1 => 44
	i32 3561949811, ; 344: Azure.Core.dll => 0xd44f0a73 => 35
	i32 3570608287, ; 345: System.Runtime.Caching.dll => 0xd4d3289f => 78
	i32 3580758918, ; 346: zh-HK\Microsoft.Maui.Controls.resources => 0xd56e0b86 => 31
	i32 3592228221, ; 347: zh-Hant\Microsoft.Maui.Controls.resources.dll => 0xd61d0d7d => 33
	i32 3608519521, ; 348: System.Linq.dll => 0xd715a361 => 141
	i32 3624195450, ; 349: System.Runtime.InteropServices.RuntimeInformation => 0xd804d57a => 165
	i32 3641597786, ; 350: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 93
	i32 3643446276, ; 351: tr\Microsoft.Maui.Controls.resources => 0xd92a9404 => 28
	i32 3643854240, ; 352: Xamarin.AndroidX.Navigation.Fragment => 0xd930cda0 => 98
	i32 3657292374, ; 353: Microsoft.Extensions.Configuration.Abstractions.dll => 0xd9fdda56 => 46
	i32 3660523487, ; 354: System.Net.NetworkInformation => 0xda2f27df => 147
	i32 3672681054, ; 355: Mono.Android.dll => 0xdae8aa5e => 204
	i32 3682565725, ; 356: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 83
	i32 3700591436, ; 357: Microsoft.IdentityModel.Abstractions.dll => 0xdc928b4c => 55
	i32 3724971120, ; 358: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 97
	i32 3732100267, ; 359: System.Net.NameResolution => 0xde7354ab => 146
	i32 3737834244, ; 360: System.Net.Http.Json.dll => 0xdecad304 => 143
	i32 3748608112, ; 361: System.Diagnostics.DiagnosticSource => 0xdf6f3870 => 127
	i32 3751619990, ; 362: da\Microsoft.Maui.Controls.resources.dll => 0xdf9d2d96 => 3
	i32 3786282454, ; 363: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 85
	i32 3792276235, ; 364: System.Collections.NonGeneric => 0xe2098b0b => 117
	i32 3792835768, ; 365: HarfBuzzSharp => 0xe21214b8 => 39
	i32 3800979733, ; 366: Microsoft.Maui.Controls.Compatibility => 0xe28e5915 => 61
	i32 3802395368, ; 367: System.Collections.Specialized.dll => 0xe2a3f2e8 => 118
	i32 3817368567, ; 368: CommunityToolkit.Maui.dll => 0xe3886bf7 => 37
	i32 3823082795, ; 369: System.Security.Cryptography.dll => 0xe3df9d2b => 181
	i32 3841636137, ; 370: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xe4fab729 => 48
	i32 3844307129, ; 371: System.Net.Mail.dll => 0xe52378b9 => 145
	i32 3849253459, ; 372: System.Runtime.InteropServices.dll => 0xe56ef253 => 166
	i32 3875112723, ; 373: System.Security.Cryptography.Encoding.dll => 0xe6f98713 => 178
	i32 3885497537, ; 374: System.Net.WebHeaderCollection.dll => 0xe797fcc1 => 154
	i32 3896106733, ; 375: System.Collections.Concurrent.dll => 0xe839deed => 115
	i32 3896760992, ; 376: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 87
	i32 3920221145, ; 377: nl\Microsoft.Maui.Controls.resources.dll => 0xe9a9d3d9 => 19
	i32 3928044579, ; 378: System.Xml.ReaderWriter => 0xea213423 => 196
	i32 3931092270, ; 379: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 100
	i32 3953953790, ; 380: System.Text.Encoding.CodePages => 0xebac8bfe => 182
	i32 3955647286, ; 381: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 81
	i32 4003436829, ; 382: System.Diagnostics.Process.dll => 0xee9f991d => 128
	i32 4003906742, ; 383: HarfBuzzSharp.dll => 0xeea6c4b6 => 39
	i32 4025784931, ; 384: System.Memory => 0xeff49a63 => 142
	i32 4046471985, ; 385: Microsoft.Maui.Controls.Xaml.dll => 0xf1304331 => 63
	i32 4054681211, ; 386: System.Reflection.Emit.ILGeneration => 0xf1ad867b => 161
	i32 4066802364, ; 387: SkiaSharp.HarfBuzz => 0xf2667abc => 70
	i32 4068434129, ; 388: System.Private.Xml.Linq.dll => 0xf27f60d1 => 159
	i32 4073602200, ; 389: System.Threading.dll => 0xf2ce3c98 => 192
	i32 4091086043, ; 390: el\Microsoft.Maui.Controls.resources.dll => 0xf3d904db => 5
	i32 4094352644, ; 391: Microsoft.Maui.Essentials.dll => 0xf40add04 => 65
	i32 4099507663, ; 392: System.Drawing.dll => 0xf45985cf => 133
	i32 4100113165, ; 393: System.Private.Uri => 0xf462c30d => 158
	i32 4103439459, ; 394: uk\Microsoft.Maui.Controls.resources.dll => 0xf4958463 => 29
	i32 4126470640, ; 395: Microsoft.Extensions.DependencyInjection => 0xf5f4f1f0 => 47
	i32 4127667938, ; 396: System.IO.FileSystem.Watcher => 0xf60736e2 => 137
	i32 4147896353, ; 397: System.Reflection.Emit.ILGeneration.dll => 0xf73be021 => 161
	i32 4150914736, ; 398: uk\Microsoft.Maui.Controls.resources => 0xf769eeb0 => 29
	i32 4159265925, ; 399: System.Xml.XmlSerializer => 0xf7e95c85 => 198
	i32 4164802419, ; 400: System.IO.FileSystem.Watcher.dll => 0xf83dd773 => 137
	i32 4181436372, ; 401: System.Runtime.Serialization.Primitives => 0xf93ba7d4 => 171
	i32 4182413190, ; 402: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 95
	i32 4196529839, ; 403: System.Net.WebClient.dll => 0xfa21f6af => 153
	i32 4213026141, ; 404: System.Diagnostics.DiagnosticSource.dll => 0xfb1dad5d => 127
	i32 4249188766, ; 405: nb\Microsoft.Maui.Controls.resources.dll => 0xfd45799e => 18
	i32 4263231520, ; 406: System.IdentityModel.Tokens.Jwt.dll => 0xfe1bc020 => 76
	i32 4271975918, ; 407: Microsoft.Maui.Controls.dll => 0xfea12dee => 62
	i32 4274976490, ; 408: System.Runtime.Numerics => 0xfecef6ea => 168
	i32 4292120959 ; 409: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 95
], align 4

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [410 x i32] [
	i32 147, ; 0
	i32 146, ; 1
	i32 41, ; 2
	i32 0, ; 3
	i32 68, ; 4
	i32 9, ; 5
	i32 190, ; 6
	i32 129, ; 7
	i32 33, ; 8
	i32 179, ; 9
	i32 66, ; 10
	i32 17, ; 11
	i32 166, ; 12
	i32 187, ; 13
	i32 32, ; 14
	i32 25, ; 15
	i32 154, ; 16
	i32 179, ; 17
	i32 120, ; 18
	i32 85, ; 19
	i32 104, ; 20
	i32 123, ; 21
	i32 83, ; 22
	i32 126, ; 23
	i32 113, ; 24
	i32 162, ; 25
	i32 30, ; 26
	i32 80, ; 27
	i32 8, ; 28
	i32 67, ; 29
	i32 92, ; 30
	i32 139, ; 31
	i32 193, ; 32
	i32 151, ; 33
	i32 190, ; 34
	i32 142, ; 35
	i32 191, ; 36
	i32 34, ; 37
	i32 28, ; 38
	i32 119, ; 39
	i32 91, ; 40
	i32 180, ; 41
	i32 194, ; 42
	i32 171, ; 43
	i32 199, ; 44
	i32 55, ; 45
	i32 6, ; 46
	i32 156, ; 47
	i32 52, ; 48
	i32 69, ; 49
	i32 27, ; 50
	i32 49, ; 51
	i32 138, ; 52
	i32 164, ; 53
	i32 172, ; 54
	i32 43, ; 55
	i32 176, ; 56
	i32 37, ; 57
	i32 175, ; 58
	i32 89, ; 59
	i32 19, ; 60
	i32 184, ; 61
	i32 115, ; 62
	i32 150, ; 63
	i32 195, ; 64
	i32 167, ; 65
	i32 149, ; 66
	i32 139, ; 67
	i32 136, ; 68
	i32 25, ; 69
	i32 70, ; 70
	i32 51, ; 71
	i32 125, ; 72
	i32 158, ; 73
	i32 135, ; 74
	i32 10, ; 75
	i32 143, ; 76
	i32 24, ; 77
	i32 112, ; 78
	i32 121, ; 79
	i32 21, ; 80
	i32 68, ; 81
	i32 14, ; 82
	i32 109, ; 83
	i32 92, ; 84
	i32 131, ; 85
	i32 197, ; 86
	i32 157, ; 87
	i32 23, ; 88
	i32 119, ; 89
	i32 138, ; 90
	i32 102, ; 91
	i32 133, ; 92
	i32 48, ; 93
	i32 42, ; 94
	i32 81, ; 95
	i32 132, ; 96
	i32 4, ; 97
	i32 140, ; 98
	i32 94, ; 99
	i32 54, ; 100
	i32 122, ; 101
	i32 110, ; 102
	i32 199, ; 103
	i32 26, ; 104
	i32 20, ; 105
	i32 16, ; 106
	i32 44, ; 107
	i32 107, ; 108
	i32 22, ; 109
	i32 99, ; 110
	i32 128, ; 111
	i32 2, ; 112
	i32 41, ; 113
	i32 90, ; 114
	i32 11, ; 115
	i32 157, ; 116
	i32 107, ; 117
	i32 141, ; 118
	i32 170, ; 119
	i32 31, ; 120
	i32 32, ; 121
	i32 102, ; 122
	i32 86, ; 123
	i32 169, ; 124
	i32 0, ; 125
	i32 109, ; 126
	i32 134, ; 127
	i32 164, ; 128
	i32 150, ; 129
	i32 76, ; 130
	i32 6, ; 131
	i32 116, ; 132
	i32 136, ; 133
	i32 82, ; 134
	i32 52, ; 135
	i32 116, ; 136
	i32 135, ; 137
	i32 114, ; 138
	i32 56, ; 139
	i32 30, ; 140
	i32 186, ; 141
	i32 78, ; 142
	i32 170, ; 143
	i32 36, ; 144
	i32 153, ; 145
	i32 96, ; 146
	i32 72, ; 147
	i32 106, ; 148
	i32 59, ; 149
	i32 38, ; 150
	i32 88, ; 151
	i32 144, ; 152
	i32 186, ; 153
	i32 173, ; 154
	i32 108, ; 155
	i32 148, ; 156
	i32 181, ; 157
	i32 177, ; 158
	i32 126, ; 159
	i32 84, ; 160
	i32 1, ; 161
	i32 193, ; 162
	i32 114, ; 163
	i32 130, ; 164
	i32 104, ; 165
	i32 49, ; 166
	i32 203, ; 167
	i32 17, ; 168
	i32 91, ; 169
	i32 9, ; 170
	i32 53, ; 171
	i32 43, ; 172
	i32 96, ; 173
	i32 110, ; 174
	i32 108, ; 175
	i32 100, ; 176
	i32 183, ; 177
	i32 169, ; 178
	i32 50, ; 179
	i32 26, ; 180
	i32 140, ; 181
	i32 163, ; 182
	i32 59, ; 183
	i32 8, ; 184
	i32 2, ; 185
	i32 117, ; 186
	i32 159, ; 187
	i32 13, ; 188
	i32 103, ; 189
	i32 45, ; 190
	i32 60, ; 191
	i32 5, ; 192
	i32 94, ; 193
	i32 54, ; 194
	i32 160, ; 195
	i32 93, ; 196
	i32 4, ; 197
	i32 130, ; 198
	i32 173, ; 199
	i32 155, ; 200
	i32 124, ; 201
	i32 118, ; 202
	i32 198, ; 203
	i32 64, ; 204
	i32 12, ; 205
	i32 51, ; 206
	i32 50, ; 207
	i32 156, ; 208
	i32 111, ; 209
	i32 144, ; 210
	i32 14, ; 211
	i32 58, ; 212
	i32 46, ; 213
	i32 101, ; 214
	i32 152, ; 215
	i32 145, ; 216
	i32 18, ; 217
	i32 201, ; 218
	i32 165, ; 219
	i32 148, ; 220
	i32 74, ; 221
	i32 12, ; 222
	i32 196, ; 223
	i32 57, ; 224
	i32 45, ; 225
	i32 177, ; 226
	i32 13, ; 227
	i32 194, ; 228
	i32 10, ; 229
	i32 124, ; 230
	i32 152, ; 231
	i32 200, ; 232
	i32 202, ; 233
	i32 62, ; 234
	i32 151, ; 235
	i32 16, ; 236
	i32 73, ; 237
	i32 162, ; 238
	i32 11, ; 239
	i32 42, ; 240
	i32 113, ; 241
	i32 184, ; 242
	i32 15, ; 243
	i32 183, ; 244
	i32 191, ; 245
	i32 20, ; 246
	i32 111, ; 247
	i32 160, ; 248
	i32 88, ; 249
	i32 74, ; 250
	i32 15, ; 251
	i32 77, ; 252
	i32 57, ; 253
	i32 35, ; 254
	i32 79, ; 255
	i32 167, ; 256
	i32 197, ; 257
	i32 132, ; 258
	i32 125, ; 259
	i32 36, ; 260
	i32 172, ; 261
	i32 189, ; 262
	i32 174, ; 263
	i32 176, ; 264
	i32 168, ; 265
	i32 80, ; 266
	i32 187, ; 267
	i32 82, ; 268
	i32 53, ; 269
	i32 1, ; 270
	i32 21, ; 271
	i32 67, ; 272
	i32 63, ; 273
	i32 64, ; 274
	i32 182, ; 275
	i32 105, ; 276
	i32 27, ; 277
	i32 71, ; 278
	i32 66, ; 279
	i32 86, ; 280
	i32 105, ; 281
	i32 65, ; 282
	i32 79, ; 283
	i32 38, ; 284
	i32 201, ; 285
	i32 71, ; 286
	i32 106, ; 287
	i32 155, ; 288
	i32 112, ; 289
	i32 129, ; 290
	i32 75, ; 291
	i32 123, ; 292
	i32 175, ; 293
	i32 90, ; 294
	i32 103, ; 295
	i32 75, ; 296
	i32 77, ; 297
	i32 34, ; 298
	i32 7, ; 299
	i32 97, ; 300
	i32 203, ; 301
	i32 121, ; 302
	i32 189, ; 303
	i32 40, ; 304
	i32 60, ; 305
	i32 180, ; 306
	i32 174, ; 307
	i32 134, ; 308
	i32 188, ; 309
	i32 131, ; 310
	i32 163, ; 311
	i32 98, ; 312
	i32 192, ; 313
	i32 84, ; 314
	i32 188, ; 315
	i32 120, ; 316
	i32 178, ; 317
	i32 7, ; 318
	i32 56, ; 319
	i32 149, ; 320
	i32 89, ; 321
	i32 69, ; 322
	i32 99, ; 323
	i32 24, ; 324
	i32 185, ; 325
	i32 87, ; 326
	i32 202, ; 327
	i32 58, ; 328
	i32 101, ; 329
	i32 3, ; 330
	i32 40, ; 331
	i32 47, ; 332
	i32 200, ; 333
	i32 61, ; 334
	i32 22, ; 335
	i32 73, ; 336
	i32 122, ; 337
	i32 72, ; 338
	i32 204, ; 339
	i32 23, ; 340
	i32 185, ; 341
	i32 195, ; 342
	i32 44, ; 343
	i32 35, ; 344
	i32 78, ; 345
	i32 31, ; 346
	i32 33, ; 347
	i32 141, ; 348
	i32 165, ; 349
	i32 93, ; 350
	i32 28, ; 351
	i32 98, ; 352
	i32 46, ; 353
	i32 147, ; 354
	i32 204, ; 355
	i32 83, ; 356
	i32 55, ; 357
	i32 97, ; 358
	i32 146, ; 359
	i32 143, ; 360
	i32 127, ; 361
	i32 3, ; 362
	i32 85, ; 363
	i32 117, ; 364
	i32 39, ; 365
	i32 61, ; 366
	i32 118, ; 367
	i32 37, ; 368
	i32 181, ; 369
	i32 48, ; 370
	i32 145, ; 371
	i32 166, ; 372
	i32 178, ; 373
	i32 154, ; 374
	i32 115, ; 375
	i32 87, ; 376
	i32 19, ; 377
	i32 196, ; 378
	i32 100, ; 379
	i32 182, ; 380
	i32 81, ; 381
	i32 128, ; 382
	i32 39, ; 383
	i32 142, ; 384
	i32 63, ; 385
	i32 161, ; 386
	i32 70, ; 387
	i32 159, ; 388
	i32 192, ; 389
	i32 5, ; 390
	i32 65, ; 391
	i32 133, ; 392
	i32 158, ; 393
	i32 29, ; 394
	i32 47, ; 395
	i32 137, ; 396
	i32 161, ; 397
	i32 29, ; 398
	i32 198, ; 399
	i32 137, ; 400
	i32 171, ; 401
	i32 95, ; 402
	i32 153, ; 403
	i32 127, ; 404
	i32 18, ; 405
	i32 76, ; 406
	i32 62, ; 407
	i32 168, ; 408
	i32 95 ; 409
], align 4

@marshal_methods_number_of_classes = dso_local local_unnamed_addr constant i32 0, align 4

@marshal_methods_class_cache = dso_local local_unnamed_addr global [0 x %struct.MarshalMethodsManagedClass] zeroinitializer, align 4

; Names of classes in which marshal methods reside
@mm_class_names = dso_local local_unnamed_addr constant [0 x ptr] zeroinitializer, align 4

@mm_method_names = dso_local local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		ptr @.MarshalMethodName.0_name; char* name
	} ; 0
], align 8

; get_function_pointer (uint32_t mono_image_index, uint32_t class_index, uint32_t method_token, void*& target_ptr)
@get_function_pointer = internal dso_local unnamed_addr global ptr null, align 4

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
	store ptr %fn, ptr @get_function_pointer, align 4, !tbaa !3
	ret void
}

; Strings
@.str.0 = private unnamed_addr constant [40 x i8] c"get_function_pointer MUST be specified\0A\00", align 1

;MarshalMethodName
@.MarshalMethodName.0_name = private unnamed_addr constant [1 x i8] c"\00", align 1

; External functions

; Function attributes: noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8"
declare void @abort() local_unnamed_addr #2

; Function attributes: nofree nounwind
declare noundef i32 @puts(ptr noundef) local_unnamed_addr #1
attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-thumb-mode,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-thumb-mode,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }

; Metadata
!llvm.module.flags = !{!0, !1, !7}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!"Xamarin.Android remotes/origin/release/8.0.1xx-preview7 @ d8764fc950e5e864f357bb0c4d44b6d5a2675229"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}
!7 = !{i32 1, !"min_enum_size", i32 4}
