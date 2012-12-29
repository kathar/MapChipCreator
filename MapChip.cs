using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ka.Game;

namespace MapChipCreator
{
	/// <summary>
	/// MapChipCreator 用の PictureBox 
	/// </summary>
	public class MapChip : PictureBox
	{
		MapChipData data;

		public MapChip()
		{
			data = new MapChipData();
			data.chipType = ChipType_e.empty;
		}
	}
}
