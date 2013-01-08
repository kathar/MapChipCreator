using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using ka;
using ka.WinForm;

namespace MapChipCreator
{
	public class MccView : KaView
	{
		public static readonly string title = "MapChipCreator";

		public static readonly int Margin = 32;
		public static readonly int ChipCols = 16;
		public static readonly int ChipRows = 16;
		public static readonly int ChipSize = 32;
		public static readonly int DetailSizeRate = 4;

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

			var datMgr = new KaBmpDatMgr( m.ChipEmptyImg as Bitmap );
			var img = datMgr.magnify( ChipSize / m.ChipEmptyImg.Width );
			for ( var col = 0; col < ChipCols; ++col )
			{
				for ( var row = 0; row < ChipRows; ++row )
				{
					var chip = new MapChip();
					chip.Location = new Point(
						col * ChipSize + Margin,
						row * ChipSize + Margin );
					chip.Size = new Size( ChipSize, ChipSize );
					chip.BackgroundImage = img;
					chip.SizeMode = PictureBoxSizeMode.Zoom;
					chip.BackgroundImageLayout = ImageLayout.Zoom;
					chip.AllowDrop = true;
					chips.Add( chip );
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
			var datMgr = new KaBmpDatMgr( m.ChipEmptyImg as Bitmap );

			detailChip.Location = new Point( left, chipAreaTop );
			detailChip.Size = new Size( ChipSize * DetailSizeRate, ChipSize * DetailSizeRate );
			detailChip.Image = datMgr.magnify( DetailSizeRate );
			detailChip.SizeMode = PictureBoxSizeMode.Zoom;
			detailChip.BackgroundImageLayout = ImageLayout.Zoom;
			mainForm.Controls.Add( detailChip );
		}
	}
}
