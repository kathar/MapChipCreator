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
		public Image ChipEmptyImg { get; private set; }
		public Image ChipOverImg { get; private set; }
		public Image ChipSelectedImg { get; private set; }

		protected override void init()
		{
			base.init();

			Image bmp = null;
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

			bmp = null;
			if ( !KaResource.get( out bmp, "ChipSelectedImg" ) )
			{
				// error
			}
			ChipSelectedImg = bmp;
		 }
	}
}
