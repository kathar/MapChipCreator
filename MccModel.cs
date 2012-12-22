using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KaLib.WinForm;

namespace MapChipCreator
{
	public class MccModel : KaModel
	{
		public Bitmap SampleBlock { get; private set; } 

		protected override void init()
		{
			base.init();

			Bitmap tmpImg = null;
			if ( !KaResource.get( out tmpImg, "SampleBlock" ) )
			{
				// error
			}
			SampleBlock = tmpImg;
		}
	}
}
