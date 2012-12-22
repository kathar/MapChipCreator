﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using KaLib.WinForm;

namespace MapChipCreator
{
	public class MccView : KaView
	{
		private static readonly int blockCols = 8;
		private static readonly int blockRows = 8;
		private static readonly int blockSize = 64;

		public List<PictureBox> blocks { get; set; }
	
		protected override void init()
		{
			base.init();

			initBlockArea();
		}

		public void initBlockArea()
		{
			var m = model as MccModel;
			blocks = new List<PictureBox>();

			for ( var col = 0; col < blockCols; ++col )
			{
				for ( var row = 0; row < blockRows; ++row )
				{
					var pb = new PictureBox();
					pb.Location = new Point( col * blockSize, row * blockSize );
					pb.Size = new Size( blockSize, blockSize );
					pb.Image = m.SampleBlock;
					pb.SizeMode = PictureBoxSizeMode.Zoom;
					blocks.Add( pb );
				}
			}
		}
	}
}