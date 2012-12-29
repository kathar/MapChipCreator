using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using ka.WinForm;

namespace MapChipCreator
{
	public class MccView : KaView
	{
		private static readonly string title = "MapChipCreator";

		private static readonly int Margin = 32;
		private static readonly int ChipCols = 16;
		private static readonly int ChipRows = 16;
		private static readonly int ChipSize = 32;

		public List<MapChip> chips { get; set; }
		public PictureBox detailChip { get; set; }
	
		protected override void init()
		{
			base.init();

			mainForm.Text = title;

			initChipArea();
			initChipInfoArea();
		}

		/// <summary>
		/// チップ一覧エリアの初期化
		/// </summary>
		public void initChipArea()
		{
			var m = model as MccModel;
			chips = new List<MapChip>();

			for ( var col = 0; col < ChipCols; ++col )
			{
				for ( var row = 0; row < ChipRows; ++row )
				{
					var pb = new MapChip();
					pb.Location = new Point(
						col * ChipSize + Margin,
						row * ChipSize + Margin );
					pb.Size = new Size( ChipSize, ChipSize );
					pb.BackgroundImage = m.ChipEmptyImg;
					pb.SizeMode = PictureBoxSizeMode.Zoom;
					pb.AllowDrop = true;
					chips.Add( pb );
				}
			}

			mainForm.Controls.KaAdd( chips );
		}

		/// <summary>
		/// チップ詳細情報の初期化
		/// </summary>
		private void initChipInfoArea()
		{
			var m = model as MccModel;

			// チップエリアの上の値を得る
			var chipAreaTop = Margin;
			// チップエリアの一番右の値を得る
			var chipAreaR = ChipCols * ChipSize + Margin;

			detailChip = new MapChip();
			var left = chipAreaR + Margin;
			detailChip.Location = new Point( left, chipAreaTop );
			detailChip.Size = new Size( ChipSize * 4, ChipSize * 4 );
			detailChip.Image = m.ChipEmptyImg;
			detailChip.SizeMode = PictureBoxSizeMode.Zoom;
			mainForm.Controls.Add( detailChip );
		}
	}
}
