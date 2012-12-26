using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using ka.WinForm;

namespace MapChipCreator
{
	static class MapChipCreator
	{
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main()
		{
			KaMvcMgr.Run();
			var tmp = Properties.Resources.ResourceManager;
		}
	}
}
