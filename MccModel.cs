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
		public Bitmap BlockBgImg { get; private set; }
		public Bitmap BlockOverImg { get; private set; } 

		protected override void init()
		{
			base.init();

			Bitmap tmpImg = null;
			if ( !KaResource.get( out tmpImg, "BlockBgImg" ) )
			{
				// error
			}
			BlockBgImg = tmpImg;

			tmpImg = null;
			if ( !KaResource.get( out tmpImg, "BlockOverImg" ) )
			{
				// error
			}
			BlockOverImg = tmpImg;
		 }
	}
}
