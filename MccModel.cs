using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

using ka;
using ka.WinForm;

namespace MapChipCreator
{
	public class MccModel : KaModel
	{
		public Bitmap ChipEmptyImg { get; private set; }
		public Bitmap ChipOverImg { get; private set; } 

		protected override void init()
		{
			base.init();

			Bitmap bmp = null;
			if ( !KaResource.get( out bmp, "ChipEmptyImg" ) )
			{
				// error
			}
			ChipEmptyImg = bmp;

			bmp = null;
			if ( !KaResource.get( out bmp, "ChipOverImg" ) )
			{
				// error
			}
			ChipOverImg = bmp;
		 }
	}
}
