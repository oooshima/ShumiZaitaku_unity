using System.Runtime.InteropServices;

namespace Iphone.vib
{
	/// <summary>
	/// iOSバイブレーションネイティブプラグイン
	/// </summary>
	public static class VibrationPlugin
	{
		#if !UNITY_EDITOR && UNITY_IOS
		[DllImport("__Internal")]
		static extern void _PlayVibration (int i);
		#endif

		public static void PlayVibration(int frequency)
		{
			#if !UNITY_EDITOR && UNITY_IOS
			_PlayVibration(frequency);
			#endif
		}
	}
}