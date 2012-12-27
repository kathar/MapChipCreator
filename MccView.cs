using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ka.WinForm;

namespace MapChipCreator
{
	public class MccView : KaView
	{
		private static readonly string title = "MapChipCreator";

		private static readonly int Margin = 32;
		private static readonly int BlockCols = 16;
		private static readonly int BlockRows = 16;
		private static readonly int BlockSize = 32;

		public List<PictureBox> blocks { get; set; }
	
		protected override void init()
		{
			base.init();

			mainForm.Text = title;

			initBlockArea();
		}

		public void initBlockArea()
		{
			var m = model as MccModel;
			blocks = new List<PictureBox>();

			for ( var col = 0; col < BlockCols; ++col )
			{
				for ( var row = 0; row < BlockRows; ++row )
				{
					var pb = new PictureBox();
					pb.Location = new Point(
						col * BlockSize + Margin,
						row * BlockSize + Margin );
					pb.Size = new Size( BlockSize, BlockSize );
					pb.BackgroundImage = m.BlockBgImg;
					pb.SizeMode = PictureBoxSizeMode.Zoom;
					pb.AllowDrop = true;
					blocks.Add( pb );
				}
			}

			mainForm.Controls.KaAdd( blocks );
		}
	}
}
