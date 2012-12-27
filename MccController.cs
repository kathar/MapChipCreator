using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ka;
using ka.WinForm;

namespace MapChipCreator
{
	public class MccController : KaController
	{
		protected override void init()
		{
			base.init();

			bindBlocks();
		}

		// ブロックにイベントを設定
		private void bindBlocks()
		{
			var m = model as MccModel;
			var v = view as MccView;

			var bgImg = m.BlockBgImg;
			var overImg = m.BlockOverImg;
			Bitmap dropImg = null;
			var blocks = v.blocks;
			foreach ( var block in blocks )
			{
				// マウスオーバーイベント
				block.MouseEnter += ( s, e ) =>
				{
					block.Image = overImg;
				};
				block.MouseLeave += ( s, e ) =>
				{
					block.Image = null;
				};

				// D&D イベント
				/// ドラッグオーバー
				block.DragEnter += ( s, e ) =>
				{
					var fileNames = e.Data.GetData( DataFormats.FileDrop ) as string[];

					// エラー処理
					/// null の場合
					if ( !fileNames.KaIs() ) return;
					/// ドラッグ対象が1つ以外
					if ( fileNames.Length != 1 ) return;
					/// ドラッグ対象が画像以外
					try { dropImg = new Bitmap( fileNames[ 0 ] ); }
					catch( ArgumentException ) { return; }

					// ドラッグ対象が1つで、画像ファイルの場合
					e.Effect = DragDropEffects.All;
					block.Image = overImg;
				};
				/// ドラッグリーブ
				block.DragLeave += ( s, e ) =>
				{
					block.Image = null;
				};
				/// ドロップ
				block.DragDrop += ( s, e ) =>
				{
					// サイズチェック
					if( dropImg.Width != block.Width
						|| dropImg.Height != block.Height )
					{
						return;
					}

					block.BackgroundImage = dropImg;
				};
				
				// クリックイベント
				block.Click += ( s, e ) =>
				{
					//v.mainForm.Text = block.Location.ToString();
				};
			}
		}
	}
}
